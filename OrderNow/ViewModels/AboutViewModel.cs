using System;
using System.Windows.Input;
using Resturant.Class;
using Xamarin.Forms;

namespace OrderNow.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = Constants.CurrentLang == "en-us" ? "About" : "عن الشركه ";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://xamarin.com/platform")));
        }

        public ICommand OpenWebCommand { get; }
    }
}