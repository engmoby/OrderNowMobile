using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Resturant.Class;
using Resturant.Models;

namespace Resturant.RestAPIClient
{
    public class RestClient<T>
    {
        
		public async Task<bool> checkLogin(string username, string password)
        { 
            HttpClient client;
            Uri baseUri = new Uri(Constants.ApiUrl); client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var uri = new Uri(baseUri, "api/token");


            var postBody = new Dictionary<string, string>()
                {
                {"username", username},
                {"password", password},
                {"grant_type", "password"}
                };

            var content = new FormUrlEncodedContent(postBody);
            var response = await client.PostAsync(uri, content);

            var sdsd = new UserDetailCredentials();
            if (response.IsSuccessStatusCode)
            {
                //var storeService = DependencyService.Get<IUserDetailsStore>();
                var result = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UserDetailCredentials>(result);
                sdsd = jsonData;
                //var token = jsonData["access_token"].Value<string>();
                //Token should be saved in key chain instead of singleton class
                //But for demo purposes, ill put it here
                //  AccountDetailsStore.Instance.Token = token;
                //storeService.SaveCredentials(phoneNumber, token);
            }
            Constants.userDetailCredentials = sdsd;

            return response.IsSuccessStatusCode;
        }
        public async Task<bool> SignUp(Dictionary<string, string> userModel)
        {
            HttpClient client;
            Uri baseUri = new Uri(Constants.ApiUrl); client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;
            var uri = new Uri(baseUri, "api/Users/Client");


            var postBody = new Dictionary<string, string>();
            postBody = userModel;

            var content = new FormUrlEncodedContent(postBody);
            var response = await client.PostAsync(uri, content);

            var userData = new UserDetailCredentials();
            if (response.IsSuccessStatusCode)
            {
                //var storeService = DependencyService.Get<IUserDetailsStore>();
                var result = await response.Content.ReadAsStringAsync();
                var jsonData = JsonConvert.DeserializeObject<UserDetailCredentials>(result);
                userData = jsonData;
                //var token = jsonData["access_token"].Value<string>();
                //Token should be saved in key chain instead of singleton class
                //But for demo purposes, ill put it here
                //  AccountDetailsStore.Instance.Token = token;
                //storeService.SaveCredentials(phoneNumber, token);
                Constants.userDetailCredentials = userData;
            }

            return response.IsSuccessStatusCode;
        }
    }
}
