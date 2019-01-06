using System.Collections.Generic;
using Resturant.Models;

namespace Resturant.Class
{
    public struct Constants
    { 
        public static string ApiUrl = "http://ordernowservice.azurewebsites.net/";
        public static UserDetailCredentials userDetailCredentials;
        public static string CurrentLang = "ar-eg";
        public static int Page = 1;
        public static List<OrderClass> OrderClass = new List<OrderClass>();

        public static int TableId =0;
        public static int RestaurantId = 0;
        public static int UserId ;

    }
}
