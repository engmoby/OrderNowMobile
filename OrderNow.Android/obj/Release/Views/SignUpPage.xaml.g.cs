//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("OrderNow.Droid.Views.SignUpPage.xaml", "Views/SignUpPage.xaml", typeof(global::OrderNow.Views.SignUpPage))]

namespace OrderNow.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("/Users/kareemmohamed/Desktop/OrderNowMobile/OrderNow/Views/SignUpPage.xaml")]
    public partial class SignUpPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry usernameEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label lblmailvalidaiton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry passwordEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry confirmpasswordEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label lblconfirmvalidaiton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry phoneEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label lblphonevalidaiton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.AnimateButton btnRegister;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout stackLoading;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator indecator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(SignUpPage));
            usernameEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "usernameEntry");
            lblmailvalidaiton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "lblmailvalidaiton");
            passwordEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "passwordEntry");
            confirmpasswordEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "confirmpasswordEntry");
            lblconfirmvalidaiton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "lblconfirmvalidaiton");
            phoneEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "phoneEntry");
            lblphonevalidaiton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "lblphonevalidaiton");
            btnRegister = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.AnimateButton>(this, "btnRegister");
            stackLoading = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "stackLoading");
            indecator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "indecator");
        }
    }
}
