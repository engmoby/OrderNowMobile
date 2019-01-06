using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrderNow.Models;
using OrderNow.RestAPIClient;
using OrderNow.ViewModels;
using Resturant.Class;
using Resturant.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    public partial class HistoryPage : ContentPage
    {
        HistoryViewModel viewModel;
        bool isLoading;

        public HistoryPage()
        {
            InitializeComponent();
            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft); 

            BindingContext = viewModel = new HistoryViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var historyObj = args.SelectedItem as RequestModel;
            if (historyObj == null)
                return;

            await Navigation.PushAsync(new HistoryDetailsPage(historyObj.RequestDetails));

            // Manually deselect item.
            HistoryListView.SelectedItem = null;
        }

             
        protected override void OnAppearing()
        {
            base.OnAppearing();

            viewModel.LoadHistoryCommand.Execute(null);

        }

        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            if (isLoading || viewModel.History.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.History[viewModel.History.Count - 1])
            {
                Constants.Page++;
                // LoadHistory();
            }

        }

    }
}
