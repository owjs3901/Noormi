using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Noormi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public List<Device> Devices { get; private set; }
        public ListPage()
        {
            InitializeComponent();
            
            NavigationPage.SetHasNavigationBar(this, false);
            
            Devices = new List<Device>();

            WebRequest request = WebRequest.Create("http://mbs-b.com:3000/api/devices/all");
            using (Stream stream = request.GetResponse().GetResponseStream())
            {
                string str = new StreamReader(stream).ReadToEnd();
                JObject jObject= JObject.Parse(str);
                foreach (var obj in jObject.SelectToken("devices"))
                    Devices.Add(JsonConvert.DeserializeObject<Device>(obj.ToString()));
            }
            
            if (Devices.Count == 0)
            {
                Devices.Add(new Device("PNAME", "LOC", 75,
                    "2020.02.30", "2020.02.30","D-20","2020.02.30"));
                Devices.Add(new Device("PNAME1", "LOC2", 100,
                    "2020.02.30", "2020.02.30","D-20","2020.02.30"));
            }

            BindingContext = this;
        }

        private void ItemList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Device device = Devices[e.ItemIndex];
            
            Navigation.PushAsync(new ItemPage(device, e.ItemIndex, Devices.Count));
        }
    }
}