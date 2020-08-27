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
        public Label label;
        public ItemPage(Device device, int index, int size)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var idx = FindByName("Index") as Label;
            var sz = FindByName("Size") as Label;
            var button = FindByName("Button") as Label;
            var button1 = FindByName("Button1") as Label; //위에 있는 배터리
            
            var restDate = FindByName("ResisterDate") as Label; 
            var lastDate = FindByName("LastDate") as Label; 
            var preDate = FindByName("PredictionDate") as Label; 
            var numOfUsers = FindByName("NumberOfUsers") as Label;

            var detailInfo = FindByName("DetailInfo") as StackLayout;
            
            button.Text = device.Battery + "%";
            button1.Text = device.Battery + "%";
            
            
            SetArrow(index, size);
            Charge(device.Battery);

            idx.Text = (index + 1).ToString();
            sz.Text = size.ToString();

            //SKPaint paint = new SKPaint
            button.GestureRecognizers.Add(new TapGestureRecognizer()
            {


                Command = new Command(() =>
                {
                    Console.WriteLine("TEST!!!");
                    detailInfo.IsVisible = true;


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

        private void Charge(int persentage)
        {
            var battery = FindByName("Battery") as Image;
            
            if(persentage == 100)
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery100.png");
            if(persentage <= 70)
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery70.png");
            if(persentage <= 30)
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery30.png");

        }
        
        public void OnImageButtonClicked(object sender, EventArgs e)
        {
            var bottom = FindByName("Bottom") as ImageButton;
            clickTotal += 1;
            Console.WriteLine("clicked button");
        }

    }
}