//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("OrderNow.iOS.Views.AccountPage.xaml", "Views/AccountPage.xaml", typeof(global::OrderNow.Views.AccountPage))]

namespace OrderNow.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("/Users/mac/Projects/OrderNow/OrderNow/Views/AccountPage.xaml")]
    public partial class AccountPage : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry TxtUsername;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label lblmailvalidaiton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry TxtPhone;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label lblphonevalidaiton;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry TxtPassword;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.AnimateButton btnRegister;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout stackLoading;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator indecator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(AccountPage));
            TxtUsername = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "TxtUsername");
            lblmailvalidaiton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "lblmailvalidaiton");
            TxtPhone = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "TxtPhone");
            lblphonevalidaiton = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "lblphonevalidaiton");
            TxtPassword = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "TxtPassword");
            btnRegister = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.AnimateButton>(this, "btnRegister");
            stackLoading = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "stackLoading");
            indecator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "indecator");
        }
    }
}
