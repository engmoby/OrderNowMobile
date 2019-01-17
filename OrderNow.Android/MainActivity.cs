using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace OrderNow.Droid
{
    [Activity(Label = "OrderNow", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            var fontName = "irohamaru-mikami-Regular.ttf";
            var fontPath = System.IO.Path.Combine(CacheDir.AbsolutePath, fontName);
            using (var asset = Assets.Open(fontName))
            {
                using (var dest = System.IO.File.Open(fontPath, System.IO.FileMode.Create))
                {
                    asset.CopyTo(dest);
                }
            }

            // overriding default font with custom font that supports Japanese symbols
            var font = SkiaSharp.SKTypeface.FromFile(fontPath);
            Infragistics.Core.Controls.TypefaceManager.Instance.OverrideDefaultTypeface(font);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}