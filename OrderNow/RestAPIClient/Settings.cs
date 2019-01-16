using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using Resturant.Models;

namespace OrderNow.RestAPIClient
{
    public class SettingsCross
    {
        private static ISettings AppSettings => CrossSettings.Current;

        public static string UEmail
        {
            get => AppSettings.GetValueOrDefault(nameof(UEmail), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(UEmail), value);
        }
        public static int UserId
        {
            get => AppSettings.GetValueOrDefault(nameof(UserId), 0);

            set => AppSettings.AddOrUpdateValue(nameof(UserId), value);
        }

        public static string Phone
        {
            get => AppSettings.GetValueOrDefault(nameof(Phone), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Phone), value);
        }
        public static string Password
        {
            get => AppSettings.GetValueOrDefault(nameof(Password), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(Password), value);
        }
        public static string ResturantName
        {
            get => AppSettings.GetValueOrDefault(nameof(ResturantName), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(ResturantName), value);
        }
        public static string ResturantDesc
        {
            get => AppSettings.GetValueOrDefault(nameof(ResturantDesc), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(ResturantDesc), value);
        }
        public static string ResturantLogo
        {
            get => AppSettings.GetValueOrDefault(nameof(ResturantLogo), string.Empty);

            set => AppSettings.AddOrUpdateValue(nameof(ResturantLogo), value);
        }
    }
}
