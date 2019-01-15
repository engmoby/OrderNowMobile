using System;
using OrderNow.ViewModels;
using Resturant.Class;
using Resturant.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
//using Java.Security;
using System.Collections.Generic;
using System.Linq;
using Android.Media.Audiofx;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CategoryPage : ContentPage
    {
        CategoryViewModel viewModel;
        Button button;
       

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

            Grid grid = new Grid();
            grid.ColumnDefinitions = new ColumnDefinitionCollection();
            for (int MyCount = 0; MyCount < viewModel.Headers.Count; MyCount++)
            {

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                button = new Button() 
                {
                    TextColor = Color.Black,
                    Text = viewModel.Headers[MyCount],
                    ClassId = MyCount.ToString(),  // will be the categoryID to switch on it and do the filtering 
                    BackgroundColor = Color.FromHex("#f9f9f9"),
                    BorderRadius = 20
                };
           
                grid.Children.Add(button, MyCount,0);
            }

            HeaderStack.Children.Add(grid);
        }

       


        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {

            var categoryObj = args.SelectedItem as Category;

            if (categoryObj == null)
                return;

            // we need to revist models and edit them to fit the changes done in UI

            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(categoryObj.categoryItemObj)));

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

            if (Constants.TableId != 0)
                if (viewModel.Category.Count == 0)
                {
                    viewModel.LoadCategoryCommand.Execute(null);

                }


        }

        void Handle_ItemAppearing(object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
            if (viewModel.Category.Count == 0)
                return;

            //hit bottom!
            if (e.Item == viewModel.Category[viewModel.Category.Count - 1])
            {
                Constants.Page++;
            }

        }

    }
}