﻿using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace OrderNow.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        void BackClicked(object sender, System.EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}