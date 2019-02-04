using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OrderNow.Services;
using Plugin.LocalNotifications;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;
using System.Linq.Expressions;

namespace OrderNow.Views
{
    public partial class ScanPage : ContentPage
    {
       // List<Category> categories; 
        RestClientMenu _restControl = new RestClientMenu();

        public ScanPage()
        {
            InitializeComponent(); 
            QrScanner();


        }
        public  void QrScanner()
        {
            try
            {
                ZXingScannerPage scan = new ZXingScannerPage();
                scan.HasTorch = true;
                QrLayout.Content= scan.Content;

                //Application.Current.MainPage = scan;
                scan.OnScanResult += (result) =>
                {
                    Device.BeginInvokeOnMainThread(() =>
                    { 
                        if (IsNumber(result.Text))
                        {
                            Constants.TableId = Convert.ToInt32(result.Text); 
                             List<Resturant.Models.Category> checckList;
                            checckList = _restControl.GetAllICategoriesByTable(Constants.TableId);
                            if (checckList == null)
                            {
                                DependencyService.Get<Toast>().Show("Wrong QR Code");
                                CrossLocalNotifications.Current.Show("Error", "Wrong QR Code");
                                return;
                            }

                            else Application.Current.MainPage = new MainPage();

                        }
                        else
                        {
                            DependencyService.Get<Toast>().Show("Wrong QR Code");
                            CrossLocalNotifications.Current.Show("Error", "Wrong QR Code");
                            return;
                        } 

                    });
                };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        bool IsNumber(string text)
        {
            Regex regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }

    }
}
