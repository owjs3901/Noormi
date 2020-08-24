using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Noormi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();
            Task.Delay(3000)
                .ContinueWith(t =>
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                        Application.Current.MainPage = new NavigationPage(new ListPage())
                    )
                );
        }

    }
}