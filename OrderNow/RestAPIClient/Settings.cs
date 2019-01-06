using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

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
    }
}
