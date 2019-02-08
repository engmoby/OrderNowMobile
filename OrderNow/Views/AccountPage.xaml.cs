using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using OrderNow.RestAPIClient;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;
using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class AccountPage : ContentPage
    {
        RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();
        string username_Input, password_Input, phone_Input;
        public AccountPage()
        {
            InitializeComponent();
            Title = (Constants.CurrentLang != "en-us" ? "الحساب" : "Account");
            stackLoading.IsVisible = false;

            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                if (Constants.CurrentLang == "en-us")
                    DisplayAlert("Alert", "No Internet Connection!! ", "ok");
                else
                    DisplayAlert("تنبيه", "لا يوجد اتصال بالانترنت ", "موافق");
                return;
            }

            if (SettingsCross.Phone == string.Empty)
            {
                var getUser = _restClient.GetUserInfo();
                SettingsCross.Phone = getUser.Phone;
                SettingsCross.Password = getUser.Password;

                TxtPhone.Text = getUser.Phone;
                TxtPassword.Text = getUser.Password;
                TxtUsername.Text = getUser.Username;
            }
            else
            {
                TxtPhone.Text = SettingsCross.Phone;
                TxtPassword.Text = SettingsCross.Password;
                TxtUsername.Text = SettingsCross.UserName;
            }
        }

        async void SignUp_ClickedAsync(object sender, System.EventArgs e)
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                if (Constants.CurrentLang == "en-us")
                    await DisplayAlert("Alert", "No Internet Connection!! ", "ok");
                else
                    await DisplayAlert("تنبيه", "لا يوجد اتصال بالانترنت ", "موافق");
                return;
            }

            username_Input = TxtUsername.Text;
            password_Input = TxtPassword.Text;
            phone_Input = TxtPhone.Text;

            if (username_Input == null)
            {
                await DisplayAlert("Alert", "please enter Email", "ok");
                btnRegister.IsEnabled = false;
            }
            else if (string.IsNullOrWhiteSpace(password_Input))
            {
                await DisplayAlert("Alert", "please enter password", "ok");
                btnRegister.IsEnabled = false;
            }
            else if (string.IsNullOrWhiteSpace(phone_Input))
            {
                await DisplayAlert("Alert", "please enter phone number", "ok");
                btnRegister.IsEnabled = false;
            }
            else
            {
                stackLoading.IsVisible = true;
                indecator.IsRunning = true;

                var userModel = new Dictionary<string, string>()
                {
                {"userId", RestAPIClient.SettingsCross.UserId.ToString()},
                {"username", TxtUsername.Text},
                {"password", TxtPassword.Text},
                {"clientname", "clientname"},
                {"phone", TxtPhone.Text},
                };
                var check = await _restClient.UpdateUserInfo(userModel);
                if (check)
                {
                    stackLoading.IsVisible = false;
                    await DisplayAlert("Info", "your info updated", "ok");
                }
                else
                {
                    //await DisplayAlert("Alert", "Email Or Phone Aleady Exist", "ok");
                    stackLoading.IsVisible = false;
                    indecator.IsRunning = false;
                }
            }
        }

        void EMail_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(TxtUsername.Text, emailPattern))
            {
                lblmailvalidaiton.IsVisible = false;
                btnRegister.IsEnabled = true;
                lblmailvalidaiton.Text = "";
            }
            else
            {
                lblmailvalidaiton.Text = "EMail is InValid";
                lblmailvalidaiton.IsVisible = true;

                btnRegister.IsEnabled = false;
            }
        }

        void phone_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            int result;

            bool isValid = int.TryParse(e.NewTextValue, out result);
            if (isValid)
            {
                lblphonevalidaiton.IsVisible = false;
                btnRegister.IsEnabled = true;
                lblphonevalidaiton.Text = "";
            }
            else
            {
                lblphonevalidaiton.Text = "Phone is InValid";
                lblphonevalidaiton.IsVisible = true;

                btnRegister.IsEnabled = false;
            }

            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;

        }


    }
}
