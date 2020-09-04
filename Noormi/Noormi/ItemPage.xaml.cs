using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Noormi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    
    public partial class ItemPage : ContentPage
    {
        private StackLayout _detailInfo;


        public ItemPage(Device device, int index, int size)
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            var idx = FindByName("Index") as Label;
            var sz = FindByName("Size") as Label;
            var button = FindByName("Button") as Label;
            var restDate = FindByName("ResisterDate") as Label;
            var lastDate = FindByName("LastDate") as Label;
            var preDate = FindByName("PredictionDate") as Label;
            var numOfUsers = FindByName("NumberOfUsers") as Label;
            var bottleBlur = FindByName("Bottle") as Image;
            _detailInfo = FindByName("DetailInfo") as StackLayout;
       
            button.Text = device.Battery + "%";

            SetArrow(index, size);
            Charge(device.Battery, device);
            BottleAni();

            idx.Text = (index + 1).ToString();
            sz.Text = size.ToString();


            button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                Command = new Command(() =>
                {
                    Console.WriteLine("TEST!!!");
                    
                    _detailInfo.IsVisible = !_detailInfo.IsVisible;
                    
                })
            });
            OnBackButtonPressed();
            BindingContext = device;
        }
        // public SkiaSharp.SKImageFilter CreateBlur (float sigmaX, float sigmaY,
        //     SKImageFilter input = null,
        //     SKImageFilter.CropRect cropRect = null);
        // public abstract SkiaSharp.SKMaskFilter CreateBlur (SkiaSharp.SKBlurStyle blurStyle, float sigma,
        //     SkiaSharp.SKRect occluder, SkiaSharp.SKBlurMaskFilterFlags flags);

        private async void BottleAni()
        {
            var bottle = FindByName("Bottle") as Image;
            while (true)
            {
                await bottle.RotateTo(15, 1300, Easing.SinInOut);
                await bottle.RotateTo(-5, 1300, Easing.SinInOut);
            }
        }

        private void SetArrow(int index, int size)
        {
            var left = FindByName("Left") as ImageButton;
            var right = FindByName("Right") as ImageButton;

            if (index + 1 != size)
                right.Source = ImageSource.FromResource("Noormi.Images.enable.png");
            if (index != 0)
                left.Source = ImageSource.FromResource("Noormi.Images.enable.png");
        }

        protected override bool OnBackButtonPressed()
        {
            if (_detailInfo.IsVisible == true)
            {
                _detailInfo.IsVisible = false;
                return true;
            }

            else return base.OnBackButtonPressed();
        }

        private void Charge(int persentage, Device device)
        {
            var battery = FindByName("Battery") as Image;
            var button1 = FindByName("Button1") as Label; //위에 있는 배터리
            button1.Text = device.Battery + "%";

            if (persentage <= 100)
            {
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery100.png");
                button1.TextColor = Color.FromHex("#0B4BDB");
            }

            if (persentage <= 70 & persentage > 30)
            {
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery70.png");
                button1.TextColor = Color.FromHex("#DB830B");
            }

            if (persentage <= 30 & persentage > 0)
            {
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery30.png");
                button1.TextColor = Color.FromHex("#DB0B0B");
            }

            if (persentage == 0)
                battery.Source = ImageSource.FromResource("Noormi.Images.Battery0.png");
        }
    }
}