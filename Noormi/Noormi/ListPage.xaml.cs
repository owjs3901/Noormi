using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Devices.Add(new Device("PNAME", "LOC", 56, 
                "2020.08.27", "2020.08.26", "D-1", "30명"));
            Devices.Add(new Device("PNAME1", "LOC2", 100,
                "2020.08.27", "2020.08.26", "D-1", "100명"));

            BindingContext = this;
        }

        private void ItemList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Device device = Devices[e.ItemIndex];
            Navigation.PushAsync(new ItemPage(device, e.ItemIndex, Devices.Count));
        }
    }
}