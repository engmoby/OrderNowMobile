using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Resturant.Class;
using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class Settings : ContentPage
    {
        public Settings()
        {
            InitializeComponent();
            RefreshData();
        } 
        public void RefreshData()
        {
            ObservableCollection<LanguageItem> LanguageItems = new ObservableCollection<LanguageItem>
            {
                new LanguageItem { LanguageName = "Arabic" },
                new LanguageItem { LanguageName = "English" }
            };

            listviewCategory.ItemsSource = LanguageItems;

        }
        async void Handle_ItemTappedAsync(object sender, ItemTappedEventArgs e)
        {
            var LanguageItem = e.Item as LanguageItem;
            switch (LanguageItem.LanguageName)
            {
                case "Arabic":
                    Constants.CurrentLang = "ar-eg";

                    break;
                case "English":
                    Constants.CurrentLang = "en-us";
                    break;


                default:
                    break;
            }
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    Application.Current.MainPage = new TabedPage();
                    break;
                case Device.Android:
                    Application.Current.MainPage = new MainPage();
                    break;
            }


        }

        public class LanguageItem
         {
            public string LanguageName { get; set; }
         }

        void BackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}
