using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Timers;
using OrderNow.RestAPIClient;
using OrderNow.ViewModels;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BasketPage : ContentPage
    {
        public ObservableCollection<OrderClass> Orders { get; set; }
        RestClientMenu _restClient = new RestClientMenu();

        Timer timer = new Timer();
        OrderViewModel viewModel;
        public BasketPage()
        {
            InitializeComponent();
        }
        public BasketPage(OrderViewModel viewModel)
        {
            InitializeComponent();
            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);
            var changeLang = this.viewModel = viewModel;
            foreach (var chan in changeLang.Orders)
            {
                chan.Item.Text = chan.Item.ItemNameDictionary[Constants.CurrentLang];
                chan.Item.TextFull = (chan.Item.ItemNameDictionary[Constants.CurrentLang].Length > 25) ? chan.Item.ItemNameDictionary[Constants.CurrentLang].Substring(0, 25) : chan.Item.ItemNameDictionary[Constants.CurrentLang];

                chan.Item.Description = chan.Item.ItemDescriptionDictionary[Constants.CurrentLang];
                chan.Item.DescriptionFull = (chan.Item.ItemDescriptionDictionary[Constants.CurrentLang].Length > 50) ? chan.Item.ItemDescriptionDictionary[Constants.CurrentLang].Substring(0, 50) : chan.Item.ItemDescriptionDictionary[Constants.CurrentLang];

            }
            BindingContext = changeLang;
            ordersLst.ItemsSource = viewModel.Orders;
            txtOrderCount.Text = Constants.OrderClass.Count.ToString();

        }
        void SubmitOrder_ClickedAsync(object sender, System.EventArgs e)
        {

            if (Constants.OrderClass.Count == 0)
            {
                DisplayAlert("Alert", "No Items in your cart", "ok");
                return;
            }
            var request = new RequestModel();
            request.RequestDetails = new List<RequestDetailModel>();
            foreach (var orderObj in this.viewModel.Orders)
            {
                request.RestaurantId = Constants.RestaurantId;
                request.TableId = Constants.TableId;
                request.UserId = SettingsCross.UserId;
                // request.Comment = "noooo";

                request.RequestDetails.Add(new RequestDetailModel
                {
                    ItemId = orderObj.Item.Id,
                    Number = orderObj.Quantity,
                    Price = Convert.ToDecimal(orderObj.Size.Price),
                    ItemSizeId = orderObj.Size.SizeId
                });
            }
            //await _restClient.SubmitOrder(request);
            // Constants.OrderClass = new List<OrderClass>();
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Navigation.PushModalAsync(new ConfirmOrder(request));
                    break;
                case Device.Android:
                    Navigation.PushAsync(new ConfirmOrder(request));
                    break;
            }
            //Navigation.PushAsync(new ConfirmOrder(request));
        }

        void Delete_Clicked(object sender, System.EventArgs e)
        {
            var button = ((MenuItem)sender);
            var item = button.BindingContext as OrderClass;
            Constants.OrderClass.RemoveAll(x => x.Item == item.Item && x.Size == item.Size);
            ordersLst.ItemsSource = null;
            ordersLst.ItemsSource = this.viewModel.Orders;
            Device.BeginInvokeOnMainThread(() =>
            {
                this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);

            });
        }

        void deleteFromBasket(OrderClass item)
        {

            if (item.Quantity == 0)
                Constants.OrderClass.RemoveAll(x => x.Item == item.Item && x.Size == item.Size);

            if (Constants.OrderClass.Count == 0)
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    Constants.OrderClass = new List<OrderClass>();
                    // this.viewModel = null;
                    // BindingContext = null;
                    ordersLst.ItemsSource = null;
                    if (Constants.OrderClass.Count != 0)
                    {
                        this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);
                    }
                    txtOrderCount.Text = Constants.OrderClass.Count.ToString();
                    this.viewModel.TotalOrder = 0;
                });

                // Application.Current.MainPage = new MainPage();
            }
            else
            {
                ordersLst.ItemsSource = null;
                ordersLst.ItemsSource = this.viewModel.Orders;
                // timer.Elapsed += OnTimerElapsed;
                //timer.Start();


                Device.BeginInvokeOnMainThread(() =>
                {

                    this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);
                    txtOrderCount.Text = Constants.OrderClass.Count.ToString();
                });

            }
        }
        private void ButtonDown_OnClicked(object sender, EventArgs e)
        {
            //var button = sender as Button;
            //var item = button.BindingContext as OrderClass;
            //Constants.OrderClass.RemoveAll(x => x.Item == item.Item && x.Size == item.Size);
            //ordersLst.ItemsSource = null;
            //ordersLst.ItemsSource = this.viewModel.Orders;
            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);

            //});
            //item.Quantity--;
            //item.TotalPrice = item.Quantity * Convert.ToInt64(item.Size.Price);
            //deleteFromBasket(item);
            var button = sender as Button;
            var item = button.BindingContext as OrderClass;
            //if (item.Quantity ==1)
            //{
            //    return;
            //}
            item.Quantity--;
            item.TotalPrice = item.Quantity * Convert.ToInt64(item.Size.Price);

            //if (item.Quantity != 0)
            //{
            //this.viewModel.TotalOrder = item.Quantity * Convert.ToInt64(item.Item.Price);
            //this.viewModel.Orders.FirstOrDefault
            //(x => x.Item == item.Item && x.Item.Sizes.Any(z => z.SizeId == item.Item.Sizes[0].SizeId)).TotalPrice = item.Quantity * Convert.ToInt64(item.Item.Price);

            // this.viewModel.Orders.Where(x => x.Item.Id == item.Item.Id && x.Item.Sizes.Any(z => z.SizeId == item.Item.Sizes[0].SizeId)).FirstOrDefault().TotalPrice = item.Quantity * Convert.ToInt64(item.Item.Price);
            //this.viewModel.Orders.FirstOrDefault
            //(x => x.Item == item.Item && x.Item.Sizes.Any(z => z.SizeId == item.Item.Sizes[0].SizeId)).Quantity = item.Quantity;

            // }
            if (item.Quantity == 0)
                Constants.OrderClass.RemoveAll(x => x.Item == item.Item && x.Size == item.Size);

            if (Constants.OrderClass.Count == 0)
            {

                Device.BeginInvokeOnMainThread(() =>
                {
                    Constants.OrderClass = new List<OrderClass>();
                    this.viewModel = null;
                    BindingContext = null;
                    ordersLst.ItemsSource = null;
                    if (Constants.OrderClass.Count != 0)
                    {
                        this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);
                    }
                });

                // Application.Current.MainPage = new MainPage();
            }
            else
            {
                ordersLst.ItemsSource = null;
                ordersLst.ItemsSource = this.viewModel.Orders;
                // timer.Elapsed += OnTimerElapsed;
                //timer.Start();


                Device.BeginInvokeOnMainThread(() =>
                {

                    this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);

                });

            }

        }
        //private void Handle_Clicked(object sender, EventArgs e)
        //{
        //    var button = sender as Button;
        //    var item = button.BindingContext as OrderClass;
        //    Constants.OrderClass.RemoveAll(x => x.Item == item.Item && x.Size == item.Size);
        //    ordersLst.ItemsSource = null;
        //    ordersLst.ItemsSource = this.viewModel.Orders;
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);

        //    });
        //}

        public void ButtonUp_OnClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var item = button.BindingContext as OrderClass;
            item.Quantity++;
            item.TotalPrice = item.Quantity * Convert.ToInt64(item.Size.Price);

            ordersLst.ItemsSource = null;
            ordersLst.ItemsSource = this.viewModel.Orders;

            Device.BeginInvokeOnMainThread(() =>
            {
                this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);

            });
        }
        protected override void OnAppearing()
        {

            OrderViewModel vm = this.BindingContext as OrderViewModel;
            BindingContext = vm;
        }

        //public void OnTimerElapsed(object o, ElapsedEventArgs e)
        //{
        //    Device.BeginInvokeOnMainThread(() =>
        //    {
        //        ordersLst.ItemsSource = null;
        //        ordersLst.ItemsSource = this.viewModel.Orders;
        //    });

        //    timer.Stop();
        //    timer.Enabled = false;
        //    timer.AutoReset = false;
        //    if (Constants.OrderClass != null)
        //    {
        //        this.viewModel.TotalOrder = Constants.OrderClass.Sum(x => x.TotalPrice);
        //    }
        //    else
        //    {

        //    }

        //}
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        void GoToCategory(object sender, System.EventArgs e)
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Navigation.PopModalAsync();
                    break;
                case Device.Android:
                    Navigation.PopAsync();
                    break;
            }

            //Application.Current.MainPage = new MainPage();
        }
    }
}
