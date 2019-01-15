using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class AccountPage : ContentPage
    {
        List<string> listTest = new List<string>();
        Grid grid = new Grid();
        public AccountPage()
        {
            InitializeComponent();
            grid.ColumnDefinitions = new ColumnDefinitionCollection();
            for (int MyCount = 0; MyCount < 5; MyCount++)
            {

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                grid.Children.Add(new Label { BackgroundColor = Color.Red, Text="Hello" }, MyCount, 0);


            }

            layout.Children.Add(grid);

        }
    }
}
