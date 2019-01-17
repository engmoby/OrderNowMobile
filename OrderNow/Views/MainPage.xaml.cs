using OrderNow.Models;
using Resturant.Class;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;
            if (Constants.TableId == 0)
            {
                MenuPages.Add(2, new NavigationPage(new ScanPage()));
                var newPage = MenuPages[2];

                if (newPage != null && Detail != newPage)
                {
                    Detail = newPage;
                    IsPresented = false;
                }
            }
            //  MenuPages.Add((int)MenuItemType.Foods, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Foods:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage(null)));
                        break;
                    case (int)MenuItemType.About:
                        MenuPages.Add(id, new NavigationPage(new AboutPage()));
                        break;
                    case (int)MenuItemType.Scan:
                        MenuPages.Add(id, new NavigationPage(new ScanPage()));
                        break;
                    case (int)MenuItemType.Account:
                        MenuPages.Add(id, new NavigationPage(new AccountPage()));
                        break;
                    case (int)MenuItemType.History:
                        MenuPages.Add(id, new NavigationPage(new HistoryPage()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new Settings()));
                        break;
                    case (int)MenuItemType.Category:
                        MenuPages.Add(id, new NavigationPage(new CategoryPage()));
                        break;
                    case (int)MenuItemType.SignOut:
                        MenuPages.Add(id, new NavigationPage(new SignUpPage()));
                        break; 
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

               // if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}