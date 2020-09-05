using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Noormi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        private ListView _listView;
        private bool _isRefreshing = false;

        /*
         * 새로고침 프로퍼티
         * 새고로침 될때마다 프로퍼티를 다시 렌더링함
         */
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged(nameof(IsRefreshing));
                OnPropertyChanged(nameof(Devices));
            }
        }

        /*
         * 리프레쉬가 될때 이벤트
         * 서버에서 데이터를 가져와서 갱신함
         */
        public ICommand RefreshCommand
        {
            get
            {
                return new Command(async () =>
                {
                    IsRefreshing = true;

                    await RefreshData();

                    IsRefreshing = false;
                });
            }
        }

        /*
         * 서버에서 데이터를 가져오는 코드
         */
        private async Task RefreshData()
        {
            Devices.Clear();
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create("http://mbs-b.com:3000/api/devices/all");
                request.Timeout = 3000;
                using (Stream stream = request.GetResponse().GetResponseStream())
                {
                    string str = new StreamReader(stream).ReadToEnd();
                    JObject jObject = JObject.Parse(str);
                    foreach (var obj in jObject.SelectToken("devices"))
                        Devices.Add(JsonConvert.DeserializeObject<Device>(obj.ToString()));
                }
            }
            catch
            {
                Devices.Add(new Device("PNAME", "LOC", 75,
                    "2020.02.30", "2020.02.30", "D-20", 30));
                Devices.Add(new Device("PNAME1", "LOC2", 100,
                    "2020.02.30", "2020.02.30", "D-20", 30));
            }

            /*
             * 가져온 디바이스 정보를 토대로 리스트의 엘레먼트를 렌러딩함
             */
            for (var i = 0; i < _listView.TemplatedItems.Count; i++)
            {
                var viewcell = (_listView.TemplatedItems[i] as ViewCell);
                (viewcell.FindByName("cell_index") as Label).Text = (i + 1).ToString();
                int persentage = Devices[i].Battery;
                var battery = (viewcell.FindByName("battery") as Image);
                var batteryText = viewcell.FindByName("battery_text") as Label;
                batteryText.Text = persentage + "%";

                if (persentage <= 100)
                {
                    battery.Source = ImageSource.FromResource("Noormi.Images.Charge100.png");
                    batteryText.TextColor = Color.FromHex("#0B4BDB");
                }

                if (persentage <= 70 & persentage > 30)
                {
                    battery.Source = ImageSource.FromResource("Noormi.Images.Charge70.png");
                    batteryText.TextColor = Color.FromHex("#DB830B");
                }

                if (persentage <= 30 & persentage > 0)
                {
                    battery.Source = ImageSource.FromResource("Noormi.Images.Charge30.png");
                    batteryText.TextColor = Color.FromHex("#DB830B");
                }

                if (persentage == 0)
                {
                    battery.Source = ImageSource.FromResource("Noormi.Images.Charge0.png");
                    batteryText.TextColor = Color.FromHex("#DB830B");
                }
            }
        }

        /*
         * 바인딩 될 디바이스 리스트 프로퍼티
         */
        public List<Device> Devices { get; private set; }

        public ListPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            IsRefreshing = false;
            _listView = FindByName("ItemList") as ListView;

            Devices = new List<Device>();

            BindingContext = this;

            Task.WaitAll(RefreshData());
        }

        /*
         * 리스트 엘레먼트를 클릭했을때 이벤트
         * 클릭하면 해당 디바이스를 토대로 정보를 렌더링하는 ItemPage로 이동함
         */
        private void ItemList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            int index = e.ItemIndex < 0 ? 0 : e.ItemIndex;
            Device device = Devices[index];

            Navigation.PushAsync(new ItemPage(device, e.ItemIndex, Devices.Count));
        }
    }
}