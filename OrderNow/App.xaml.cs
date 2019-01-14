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
            if (!string.IsNullOrEmpty(SettingsCross.UEmail))
            {
                //   SettingsCross.UEmail = null;
                Application.Current.MainPage = new MainPage();
            }
            else
            {
                MainPage = new Login();
            }
          //  MainPage = new BasketPage();
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
