using System;
using System.Collections.Generic;
using OrderNow.RestAPIClient;
using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class HistoryDetailsPage : ContentPage
    {
        List<RequestDetailModel> _requestDetailModel = new List<RequestDetailModel>();
        public HistoryDetailsPage(List<RequestDetailModel> requestDetailModel)
        {
            InitializeComponent();

            _requestDetailModel = requestDetailModel;
        }
    }
}
