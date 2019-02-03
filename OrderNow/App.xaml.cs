using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using OrderNow.Views;
using OrderNow.RestAPIClient;
using Resturant.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace OrderNow
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            if (string.IsNullOrEmpty(SettingsCross.UEmail))
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.iOS:
                        Application.Current.MainPage = new TabedPage();
                        break;
                    case Device.Android:
                        Application.Current.MainPage = new MainPage();
                        break;
                }
            }
            else
            {
                MainPage = new Login();
            }
            //MainPage = Application.Current.MainPage = new iOS_SettingsPage();
          
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
