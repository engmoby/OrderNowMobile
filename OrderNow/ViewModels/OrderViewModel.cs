using System;
using System.Collections.Generic;

using OrderNow.Models;
using Resturant.Class;
using Resturant.Models;
using System.Linq;
using Xamarin.Forms;

namespace OrderNow.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        public List<OrderClass> Orders { get; set; }
        bool isLoading = false;
        float _totalOrder = 0;

        public OrderClass CurrentOrder { get; set; }
        public string PriceText
        {
            get => (Constants.CurrentLang == "en-us" ? "Price" : "السعر");
        }
        public string TitleText
        {
            get => (Constants.CurrentLang == "en-us" ? "Name" : "الاسم");
        }
        public string DescriptionText
        {
            get => (Constants.CurrentLang == "en-us" ? "Description" : "الوصف");
        }
        public string AddToBasketText
        {
            get => (Constants.CurrentLang == "en-us" ? "Add To Basket" : "اضف الي السلة");
        }
        public string TotalText
        {
            get => (Constants.CurrentLang == "en-us" ? "Total" : "المجموع");
        }
        public string TotalOrderText
        {
            get => (Constants.CurrentLang == "en-us" ? "Total Order :" : "المجموع الكلي: ");
        }
        public string OtherItemText
        {
            get => (Constants.CurrentLang == "en-us" ? "Add Other Item" : "اضافه عنصر جديد");
        }
        public string OrderDetailsText
        {
            get => (Constants.CurrentLang == "en-us" ? "Order Details" : "تفاصيل الطلب");
        }
        public string CheckoutText
        {
            get => (Constants.CurrentLang == "en-us" ? "Check out Order :" : "الدفع: ");
        }
        public string Title
        {
            get => (Constants.CurrentLang == "en-us" ? "Your Basket :" : "السلة الخاصة بك");
        }
        public Command ChangeCommand { get; set; }
        public void AddOrder()
        { 
            TotalOrder = 500;
        }

        public float TotalOrder
        {
            get
            {
                return _totalOrder;
            }
            set
            {
                _totalOrder = value;
                OnPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }

        public OrderViewModel(List<OrderClass> orders = null)
        {
            Orders = orders;
            TotalOrder = Orders.Sum(item => item.TotalPrice);

        }



    }
}