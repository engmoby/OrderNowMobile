using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class ConfirmOrder : ContentPage
    {
        public ConfirmOrder()
        {
            InitializeComponent();
            base.OnAppearing();
            Device.StartTimer(TimeSpan.FromMilliseconds(6000), () =>
            {
                Application.Current.MainPage = new MainPage();
                return false;
            });

        }
        private void btnGoMenu_Clicked(object sender, EventArgs e)
        {

            Application.Current.MainPage = new MainPage();
        }
    }
}
