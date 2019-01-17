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
                Application.Current.MainPage = new GradientNavigationHeader.Controls.NavigationPageGradientHeader(new MainPage())
                {
                    LeftColor = Color.FromHex("#713C86"),
                    RightColor = Color.FromHex("#F5803A"),
                    Title = "hehe"
                };
            }
            else
            {
                MainPage = new Login();
            }
           // MainPage = new Login();
            //MainPage = new GradientNavigationHeader.Controls.NavigationPageGradientHeader(new Login())
            //{
            //    LeftColor = Color.FromHex("#36ED81"),
            //    RightColor = Color.FromHex("#109F8D")
            //};
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
