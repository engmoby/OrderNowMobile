using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrderNow.Models;
using OrderNow.ViewModels;
using Resturant.Class;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel viewModel;
        bool isLoading;

        public ItemsPage(){
            InitializeComponent();
        }

        public ItemsPage(ItemsViewModel viewModel)
        {
            InitializeComponent();

            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);
            if (Constants.OrderClass != null)
              if (Constants.OrderClass.Count > 0)
                {
                    cartNo.Text = Constants.OrderClass.Count.ToString();

                }

            BindingContext = this.viewModel = viewModel;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }



        async void GotoBasket_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BasketPage(new OrderViewModel(Constants.OrderClass)));

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Constants.OrderClass != null)
            if (Constants.OrderClass.Count > 0)
            {
                cartNo.Text = Constants.OrderClass.Count.ToString();

            }

            if (viewModel.Items.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);

            }


        }

        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            if (isLoading || viewModel.Items.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.Items[viewModel.Items.Count - 1])
            {
                Constants.Page++;
                LoadItems();
            }

        }
        private async Task LoadItems()
        {
            isLoading = true;
            // page.Title = "Loading";

            //simulator delayed load
            Device.StartTimer(TimeSpan.FromSeconds(2), () =>
            {
                viewModel.LoadMoreItemsCommand.Execute(null);
                //for (int i = 0; i < 20; i++)
                //{
                //    Items.Add(string.Format("Item {0}", Items.Count));
                //}
                // page.Title = "Done";
                isLoading = false;
                //stop timer
                return false;
            });
        }

    }
}