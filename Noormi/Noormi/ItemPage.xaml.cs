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
        private int clickTotal;
        public ItemPage(Device device, int index, int size)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            var idx = FindByName("Index") as Label;
            var sz = FindByName("Size") as Label;
            var button = FindByName("Button") as Label;
            
            SetArrow(index, size);

            idx.Text = (index + 1).ToString();
            sz.Text = size.ToString();
            
            button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Console.WriteLine("TEST!!!");
                })
            });
            
            BindingContext = device;
        }

        private void SetArrow(int index, int size)
        {
            var left = FindByName("Left") as ImageButton;
            var right = FindByName("Right") as ImageButton;
            
            if(index + 1 != size)
                right.Source = ImageSource.FromResource("Noormi.Images.enable.png");
            if(index != 0)
                left.Source = ImageSource.FromResource("Noormi.Images.enable.png");
                
        }
        
        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            var bottom = FindByName("Bottom") as ImageButton;
            clickTotal += 1;
            Console.WriteLine("clicked button");
        }

    }
}