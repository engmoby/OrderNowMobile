using OrderNow.Models;
using Resturant.Class;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage RootPage { get => Application.Current.MainPage as MainPage; }

        List<HomeMenuItem> menuItems;
        public MenuPage()
        {
            InitializeComponent();
            ListViewMenu.SelectedItem = null;
            this.FlowDirection = (Constants.CurrentLang == "en-us" ? FlowDirection.LeftToRight : FlowDirection.RightToLeft);

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Category, Title= Constants.CurrentLang == "en-us" ? "Menu" : "قائمة الطعام"  },
                new HomeMenuItem {Id = MenuItemType.Scan, Title= Constants.CurrentLang == "en-us" ? "Scan" :"مسح"  },
                new HomeMenuItem {Id = MenuItemType.Account, Title= Constants.CurrentLang == "en-us" ? "Account" :"الحساب"  },
                //new HomeMenuItem {Id = MenuItemType.History, Title= Constants.CurrentLang == "en-us" ? "History" : "الطلبات السابقه"  },
                new HomeMenuItem {Id = MenuItemType.About, Title=Constants.CurrentLang == "en-us" ? "About" : "عن الشركه " },
                new HomeMenuItem {Id = MenuItemType.Settings, Title= Constants.CurrentLang == "en-us" ? "Settings" :"الاعدادات"  },
                new HomeMenuItem {Id = MenuItemType.SignOut, Title= Constants.CurrentLang == "en-us" ? "Logout" :"خروج"  }
            };

            ListViewMenu.ItemsSource = menuItems;

            //ListViewMenu.SelectedItem = menuItems[0];
            
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                ListViewMenu.SelectedItem = null;
                if (e.SelectedItem == null)
                    return;
                if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
                {
                    if (Constants.CurrentLang == "en-us")
                        await DisplayAlert("Alert", "No Internet Connection!! ", "ok");
                    else
                        await DisplayAlert("تنبيه", "لا يوجد اتصال بالانترنت ", "موافق");
                    return;
                }

                MainPage RootPage = Application.Current.MainPage as MainPage;


                
                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                if (id == 7)
                {
                    Application.Current.MainPage = new Login();
                }
                //else if (id == 2 ){
                //    ScanPage scanPage = new ScanPage();
                //    //scanPage.QrScanner();
                //}
                else
                {
                    try
                    {
                        await RootPage.NavigateFromMenu(id);
                    }
                    catch (Exception ex)
                    {
                        throw (ex);

                    }


                }
            };
        }
    


    }
}