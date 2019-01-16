using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Java.Lang;
using Resturant.RestAPIClient;
using OrderNow.RestAPIClient;

namespace OrderNow.Views
{
    public partial class ConfirmOrder : ContentPage
    {
        RestClientMenu _restClient = new RestClientMenu();
        RequestModel _request = new RequestModel();
        public ConfirmOrder(RequestModel request)
        {
            _request = request;


            InitializeComponent( );
            base.OnAppearing();

            submit();
            Device.StartTimer(TimeSpan.FromMilliseconds(6000), () =>
            {
                Application.Current.MainPage = new MainPage();
                return false;
            });

        }
        private async void submit ()
        {
            await _restClient.SubmitOrder(_request);
        }

       
                   private void btnGoMenu_Clicked(object sender, EventArgs e)
        {

            Application.Current.MainPage = new MainPage();
        }
    }
}
