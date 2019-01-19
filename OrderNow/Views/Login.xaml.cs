using System;
using System.Collections.Generic;
using Resturant.Models;
using Resturant.RestAPIClient;
using Xamarin.Forms;
using OrderNow.RestAPIClient;
using Resturant.Class;

namespace OrderNow.Views
{
    public partial class Login : ContentPage
    {
        RestClient<UserDetailCredentials> _restClient = new RestClient<UserDetailCredentials>();
        string username_Input, password_Input;
        public Login()
        {
            InitializeComponent();

            SettingsCross.UEmail = null;
            Constants.userDetailCredentials = null;
            Constants.OrderClass = new List<OrderClass>();
            Constants.TableId = 1;
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            username_Input = usernameEntry.Text;
            password_Input = passwordEntry.Text;
            if (username_Input == null)
            {
                await DisplayAlert("Alert", "please enter userName", "ok");
            }
            else if (string.IsNullOrWhiteSpace(password_Input))
            {
                await DisplayAlert("Alert", "please enter password", "ok");
            }
            else
            {
                stackLoading.IsVisible = true;
                indecator.IsRunning = true; 
                var check = await _restClient.checkLogin(usernameEntry.Text, passwordEntry.Text);
                if (!check)
                {
                    messageLabel.Text = "Invalid login or password!";
                    passwordEntry.Text = string.Empty;
                    stackLoading.IsVisible = false;
                    return;
                }
                else
                {
                    if (Constants.userDetailCredentials.Role == "Supervisor")
                    {
                        messageLabel.Text = "You are not authorized!";
                        passwordEntry.Text = string.Empty;
                        stackLoading.IsVisible = false;
                        return;
                    }
                    SettingsCross.UEmail = Constants.userDetailCredentials.access_token;
                    SettingsCross.UserName = Constants.userDetailCredentials.Username;
                    SettingsCross.UserId = Constants.userDetailCredentials.UserId;
                    stackLoading.IsVisible = false;
                    Application.Current.MainPage = new MainPage();
                   
                    //Application.Current.MainPage = new MyPage();
                }
            }
        }
        void OnRegisterClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SignUpPage());
            //Application.Current.MainPage = new SignUpPage();
        }
    }
}
