using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;
using Xamarin.Forms;

namespace OrderNow.Views
{
    public partial class SignUpPage : ContentPage
    {
        RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();
        string username_Input, password_Input, confirmpassword_Input, phone_Input;

        public SignUpPage()
        {
            InitializeComponent();
            stackLoading.IsVisible = false;
            btnRegister.IsEnabled = false;
            NavigationPage.SetHasNavigationBar(this, true);
            NavigationPage.SetHasBackButton(this, true);


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

            username_Input = usernameEntry.Text;
            password_Input = passwordEntry.Text;
            confirmpassword_Input = confirmpasswordEntry.Text;
            phone_Input = phoneEntry.Text;
            bool IsValid = false;
            IsValid = confirmpasswordEntry.Text == passwordEntry.Text;

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
            else if (string.IsNullOrWhiteSpace(confirmpassword_Input))
            {
                await DisplayAlert("Alert", "please enter confirm password", "ok");
                btnRegister.IsEnabled = false;
            }
            else if (string.IsNullOrWhiteSpace(phone_Input))
            {
                await DisplayAlert("Alert", "please enter phone number", "ok");
                btnRegister.IsEnabled = false;
            }
            else if (!IsValid)
            {
                await DisplayAlert("Alert", "password not the same", "ok");
                btnRegister.IsEnabled = false;
            }
            else
            {
                stackLoading.IsVisible = true;
                indecator.IsRunning = true;

                var userModel = new Dictionary<string, string>()
                {
                {"username", usernameEntry.Text},
                {"password", passwordEntry.Text},
                {"clientname", "clientname"},
                {"phone", phoneEntry.Text},
             //  {"grant_type", "password"}
                };
                var check = await _restClient.SignUp(userModel);
                if (check)
                {
                    RestAPIClient.SettingsCross.UEmail = Constants.userDetailCredentials.access_token;
                    stackLoading.IsVisible = false;
                    Application.Current.MainPage = new MainPage();

                }
                else
                {
                    await DisplayAlert("Alert", "Email Or Phone Aleady Exist", "ok");
                    stackLoading.IsVisible = false;
                    indecator.IsRunning =false;
                }
            }
        }

        void EMail_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            var emailPattern = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
            if (Regex.IsMatch(usernameEntry.Text, emailPattern))
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

        void confirm_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            bool IsValid = false;
            IsValid = e.NewTextValue == passwordEntry.Text;
            if (IsValid)
            {
                lblconfirmvalidaiton.IsVisible = false;
                lblconfirmvalidaiton.Text = "";
                btnRegister.IsEnabled = true;
            }
            else
            {
                lblconfirmvalidaiton.Text = "password not the same";
                lblconfirmvalidaiton.IsVisible = true;
                btnRegister.IsEnabled = false;
            }
        }

        void onloginClick(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Login();
        }
    }
}
