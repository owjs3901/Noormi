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
    /**
     * 아이템 페이지 컨트롤 클래스
     */
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemPage : ContentPage
    {
        // 세부정보 레이아웃
        private StackLayout _detailInfo;

        // 백그라운드 이미지
        private Image _bottleBlur;

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
            _bottleBlur = FindByName("Bottle") as Image;
            _detailInfo = FindByName("DetailInfo") as StackLayout;

            button.Text = device.Battery + "%";

            SetArrow(index, size);
            Charge(device.Battery, device);
            BottleAni();

            idx.Text = (index + 1).ToString();
            sz.Text = size.ToString();


            button.GestureRecognizers.Add(new TapGestureRecognizer()
            {
                /*
                 * 버튼 클릭 이벤트를 통하여 배경을 치환해 줌과 함께 세부 정보 레이아웃을 나타냄
                 */
                Command = new Command(() =>
                {
                    _detailInfo.IsVisible = !_detailInfo.IsVisible;
                    _bottleBlur.Source = ImageSource.FromResource(_detailInfo.IsVisible
                        ? "Noormi.Images.bottleBlur.png"
                        : "Noormi.Images.bottle.png");
                })
            });
            OnBackButtonPressed();
            BindingContext = device;
        }

        /*
         * 배경 병 애니메이션
         */
        private async void BottleAni()
        {
            var bottle = FindByName("Bottle") as Image;
            while (true)
            {
                await bottle.RotateTo(15, 1300, Easing.SinInOut);
                await bottle.RotateTo(-5, 1300, Easing.SinInOut);
            }
        }

        /*
         * 다음 혹은 이전 디바이스를 나타냄
         */
        private void SetArrow(int index, int size)
        {
            var left = FindByName("Left") as ImageButton;
            var right = FindByName("Right") as ImageButton;

            if (index + 1 != size)
                right.Source = ImageSource.FromResource("Noormi.Images.enable.png");
            if (index != 0)
                left.Source = ImageSource.FromResource("Noormi.Images.enable.png");
        }

        /*
         * 뒤로가기 버튼을 눌렀을때 이벤트
         * 세부정보가 보일때는 숨김
         * 그 외에는 뒤로가기
         */
        protected override bool OnBackButtonPressed()
        {
            if (_detailInfo.IsVisible)
            {
                _detailInfo.IsVisible = false;
                _bottleBlur.Source = ImageSource.FromResource("Noormi.Images.bottle.png");
                return true;
            }

            return base.OnBackButtonPressed();
        }

        /* Charge
         * ItemList 상단에 있는 배터리 아이콘과 텍스트 상황에 맞게 나타냄
         */
        protected void Charge(int persentage, Device device)
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