using System;
using OrderNow.ViewModels;
using Resturant.Class;
using Resturant.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel viewModel;
        bool isLoading;

        public CategoryPage()
        {
            InitializeComponent();
            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);
            if (Constants.OrderClass != null)
                if (Constants.OrderClass.Count > 0)
                {
                    cartNo.Text = Constants.OrderClass.Count.ToString();

                }
                 

            BindingContext = viewModel = new CategoryViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var categoryObj = args.SelectedItem as Category;
            if (categoryObj == null)
                return;

            await Navigation.PushAsync(new ItemsPage(new ItemsViewModel(categoryObj.items)));

            // Manually deselect item.
            CategoryListView.SelectedItem = null;
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

            if (viewModel.Category.Count == 0)
            {
                viewModel.LoadCategoryCommand.Execute(null);

            }


        }

        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            if (isLoading || viewModel.Category.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.Category[viewModel.Category.Count - 1])
            {
                Constants.Page++;
                // LoadCategory();
            }

        }
        //private async Task LoadCategory()
        //{
        //    isLoading = true;
        //    // page.Title = "Loading";

        //    //simulator delayed load
        //    Device.StartTimer(TimeSpan.FromSeconds(2), () =>
        //    {
        //        viewModel.LoadMoreCategoryCommand.Execute(null);
        //        //for (int i = 0; i < 20; i++)
        //        //{
        //        //    Category.Add(string.Format("Item {0}", Category.Count));
        //        //    Category.Add(string.Format("Item {0}", Category.Count));
        //        //}
        //        // page.Title = "Done";
        //        isLoading = false;
        //        //stop timer
        //        return false;
        //    });
        //}

    }
}