using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class TabedPage : TabbedPage
    {
        public TabedPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, true);
        }
    }
}
