using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Noormi
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            /*
             * 스플레쉬 페이지에서 앱 실행
             */
            MainPage = new Splash();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}