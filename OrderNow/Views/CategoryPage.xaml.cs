using System;
using OrderNow.ViewModels;
using Resturant.Class;
using Resturant.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Java.Security;
using System.Collections.Generic;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel viewModel;

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
            if ( viewModel.Category.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.Category[viewModel.Category.Count - 1])
            {
                Constants.Page++; 
            }

        } 

    }
}