using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using OrderNow.Models;
using OrderNow.ViewModels;
using Resturant.Class;

using System.Linq;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using Plugin.LocalNotifications;
using System.Windows.Input;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;
        int currentCount = 1;
        Sizes selectedItemSize = new Sizes();
        float value = 0;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();
            ItemsListViewPrice.SelectedItem = null;
            ItemsListViewPrice.ItemsSource = viewModel.Item.Sizes;
            if (Constants.OrderClass != null)
                if (Constants.OrderClass.Count > 0)
                {
                    cartNo.Text = Constants.OrderClass.Count.ToString();
                }

            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);
            ItemsListViewPrice.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);

            BindingContext = this.viewModel = viewModel;

            value = Convert.ToInt32(this.viewModel.Item.Price);
            StepLabel.Text = currentCount.ToString();
            lblTotal.Text = value.ToString();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (Constants.OrderClass != null)
                if (Constants.OrderClass.Count == 0)
                {
                    cartNo.Text = "";

                }


        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var index = (ItemsListViewPrice.ItemsSource as List<Sizes>).IndexOf(args.SelectedItem as Sizes);

            var item = args.SelectedItem as Sizes;
            if (item == null)
                return;

            foreach (var element in viewModel.Item.Sizes)
            {
                element.BtnColor = 3;
            }
            ItemsListViewPrice.ItemsSource = null;
            viewModel.Item.Sizes[index].BtnColor = 9;
            ItemsListViewPrice.ItemsSource = viewModel.Item.Sizes;

            selectedItemSize = item;
            this.viewModel.Item.Price = item.Price.ToString();
            lblTotal.Text = item.Price.ToString();
            currentCount = 1;
            StepLabel.Text = currentCount.ToString();
            value = Convert.ToInt32(this.viewModel.Item.Price);

       
        }

        void MinusButton_OnClicked(object sender, EventArgs e)
        {
            currentCount--;

            if (currentCount == 0)
            {
                currentCount = 1;
                return;
            }
            value = currentCount * Convert.ToInt32(this.viewModel.Item.Price);
            lblTotal.Text = value.ToString();
            StepLabel.Text = currentCount.ToString();
        }
        void PlusButton_OnClicked(object sender, EventArgs e)
        {
            if (lblTotal.Text.Trim() == "0")
            {
                return;
            }
            currentCount++;
            value = currentCount * Convert.ToInt32(this.viewModel.Item.Price);
            lblTotal.Text = value.ToString();
            StepLabel.Text = currentCount.ToString();
        }

        async void GotoBasket_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new BasketPage(new OrderViewModel(Constants.OrderClass)));

        }
        void AddItemToCart_Clicked(object sender, EventArgs e)
        {
            if (selectedItemSize.SizeId == 0) return;
            var checkItemExist = Constants.OrderClass.Where(x => x.Item == this.viewModel.Item && x.Size == selectedItemSize).FirstOrDefault();
            if (checkItemExist == null)
            {
                var addItemInfo = new Item();

                addItemInfo = this.viewModel.Item;

                Constants.OrderClass.Add(new Resturant.Models.OrderClass
                {
                    Item = addItemInfo,
                    Size = selectedItemSize,
                    Quantity = currentCount,
                    TotalPrice = value,
                });
                cartNo.Text = Constants.OrderClass.Count.ToString();
            }
            else
            {
                checkItemExist.Quantity += currentCount;
                checkItemExist.TotalPrice += value;
                Constants.OrderClass.Remove(checkItemExist);
                Constants.OrderClass.Add(checkItemExist);
            }
            StepLabel.Text = "1";
            lblTotal.Text = "0";
            selectedItemSize = new Sizes();

        }
        public ItemDetailPage()
        {
            InitializeComponent();

        }
    }
}