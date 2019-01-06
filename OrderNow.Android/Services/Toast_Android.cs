using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using OrderNow.Droid.Services;
using OrderNow.Services;
[assembly: Xamarin.Forms.Dependency(typeof(Toast_Android))]

namespace OrderNow.Droid.Services
{
    public class Toast_Android : OrderNow.Services.Toast
    {
        public void Show(string message)
        {
            Android.Widget.Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }
    }
}
