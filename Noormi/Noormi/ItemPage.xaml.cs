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
    public partial class ItemPage : ContentPage
    {
        public ItemPage(Device device, int index, int size)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            var idx = FindByName("Index") as Label;
            var sz = FindByName("Size") as Label;

            idx.Text = (index + 1).ToString();
            sz.Text = size.ToString();
            
            BindingContext = device;
        }
    }
}