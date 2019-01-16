using System;
using System.Collections.ObjectModel;
using OrderNow.Models;
using Resturant.Class; 
using Resturant.Models;

namespace OrderNow.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public ObservableCollection<Sizes> SizeList { get; set; }
        public Item Item { get; set; }
        public OrderClass CurrentOrder { get; set; }
      
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

       
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Text;
            Item = item;
           

        }
    }
}
