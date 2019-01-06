using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrderNow.Models;
using OrderNow.Views;
using Resturant.Class;
using System.Collections.Generic;

namespace OrderNow.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Item> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command LoadMoreItemsCommand { get; set; }
        bool isLoading = false;

        public ItemsViewModel(List<Item> items = null)
        {
            Title = Constants.CurrentLang == "en-us" ? "Menu" : "قائمة الطعام";
            Items = new ObservableCollection<Item>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            LoadMoreItemsCommand = new Command(async () => await ExecuteLoadMoreItemsCommand());
            foreach (var item in items)
            {
                var sizesLang = new List<Sizes>();
                foreach (var sizeObj in item.Sizes)
                {
                    sizesLang.Add(new Sizes
                    {
                        SizeId = sizeObj.SizeId,
                        SizeName = sizeObj.SizeNameDictionary[Constants.CurrentLang],
                        SizeNameDictionary = sizeObj.SizeNameDictionary,
                        Price = sizeObj.Price
                    });
                }
                Items.Add(new Item
                {
                    Id = item.ItemID,
                    Text = item.ItemNameDictionary[Constants.CurrentLang],
                    TextFull = (item.ItemNameDictionary[Constants.CurrentLang].Length >= 25) ? item.ItemNameDictionary[Constants.CurrentLang].Substring(0, 25) : item.ItemNameDictionary[Constants.CurrentLang],
                    ItemNameDictionary = item.ItemNameDictionary,
                    Description = item.ItemDescriptionDictionary[Constants.CurrentLang],
                    DescriptionFull = (item.ItemDescriptionDictionary[Constants.CurrentLang].Length >= 50) ? item.ItemDescriptionDictionary[Constants.CurrentLang].Substring(0, 50) : item.ItemDescriptionDictionary[Constants.CurrentLang],
                    ItemDescriptionDictionary = item.ItemDescriptionDictionary,
                    imageURL = item.imageURL + "?type='thumbnail'",
                    Sizes = sizesLang,
                    // Price = "35",
                    PriceText = Constants.CurrentLang == "en-us" ? "SAR" : "ريال"
                });

            }
            MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Item;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            Constants.Page = 1;
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Un")
                {

                }
                //  await Navigation.PushAsync(new BasketPage(new OrderViewModel(Constants.OrderClass)));
                Application.Current.MainPage = new Login();
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task ExecuteLoadMoreItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
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
    }
}