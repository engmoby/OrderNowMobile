using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
//using Java.Lang;
using Resturant.RestAPIClient;
using OrderNow.RestAPIClient;
using Resturant.Class;
using Resturant.Models;
using System.Linq;

namespace OrderNow.Views
{
    public partial class ConfirmOrder : ContentPage
    {
        RestClientMenu _restClient = new RestClientMenu();
        RequestModel _request = new RequestModel();
        public ConfirmOrder()
        {
            InitializeComponent();
        }

        public ConfirmOrder(RequestModel request)
        {
            InitializeComponent();
            _request = request;


            LblTotalOrder.Text = Constants.OrderClass.Sum(x => x.TotalPrice).ToString() ;
            LblTime.Text = DateTime.Now.ToShortTimeString();


            InitializeComponent();
            base.OnAppearing();

            submit();
            Device.StartTimer(TimeSpan.FromMilliseconds(6000), () =>
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


                return false;
            });
            Constants.OrderClass = new List<OrderClass>();

        }
        private async void submit()
        {
            await _restClient.SubmitOrder(_request);
        }


        private void btnGoMenu_Clicked(object sender, EventArgs e)
        {

            Application.Current.MainPage = new MainPage();
        }
    }
}
