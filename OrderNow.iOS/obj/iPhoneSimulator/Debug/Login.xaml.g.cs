//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("OrderNow.iOS.Login.xaml", "Login.xaml", typeof(global::OrderNow.Views.Login))]

namespace OrderNow.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("/Users/kareemmohamed/Projects/OrderNowMobile/OrderNow/Views/Login.xaml")]
    public partial class Login : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout uiMain;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry usernameEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::OrderNow.Controls.ImageEntry passwordEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label messageLabel;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout loginStack;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.StackLayout stackLoading;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.ActivityIndicator indecator;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Login));
            uiMain = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "uiMain");
            usernameEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "usernameEntry");
            passwordEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::OrderNow.Controls.ImageEntry>(this, "passwordEntry");
            messageLabel = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "messageLabel");
            loginStack = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "loginStack");
            stackLoading = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.StackLayout>(this, "stackLoading");
            indecator = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.ActivityIndicator>(this, "indecator");
        }
    }
}
