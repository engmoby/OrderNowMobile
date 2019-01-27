using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace OrderNow.Views
{
    public partial class iOS_SettingsPage : ContentPage
    {
        public iOS_SettingsPage()
        {
            InitializeComponent();
            display();
        }

        private async void display (){
            int angel = 10;
            while(true)
            {
                settings.Rotation = angel;
                settingsSmall.Rotation = angel * -1;
                await  Task.Delay(TimeSpan.FromMilliseconds(80));
                angel += 10;
                
            }
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            var btn = sender as Button;
            switch(btn.ClassId)
            {
                case "lang":
                    Navigation.PushModalAsync(new Settings());
                    break;
                case "about":
                    Navigation.PushModalAsync(new AboutPage());
                    break;
                case "logOut":
                    Navigation.PushModalAsync(new Login());
                    break;
            }
        }
    }
}
