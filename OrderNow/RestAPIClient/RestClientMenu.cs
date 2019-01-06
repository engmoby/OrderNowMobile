using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OrderNow.RestAPIClient;
using Resturant.Class;
using Resturant.Models;

namespace Resturant.RestAPIClient
{
    public class RestClientMenu
    {
        HttpClient client;
        readonly Uri baseUri = new Uri(Constants.ApiUrl);


        public List<RequestModel> GetAllIHistoryByUserId()
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; 
            var uri = new Uri(baseUri, "/api/Requests" );
            var access_token = SettingsCross.UEmail;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", access_token));


            var response = client.GetAsync(uri).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                return null;


            var result = response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<RequestList>(result.Result);
            var ss = new List<RequestModel>();
            ss = jsonData.Results;

            response.EnsureSuccessStatusCode();

            return ss;
        }
        public List<Category> GetAllICategoriesByTable(int categoryId)
        {
            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000; 
            var uri = new Uri(baseUri, "/api/Categories/GetAllCategoriesByTable/" + Constants.TableId);
            var access_token =  SettingsCross.UEmail;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", access_token));


            var response = client.GetAsync(uri).Result;
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)  
                return null;
 

            var result = response.Content.ReadAsStringAsync();
            var jsonData = JsonConvert.DeserializeObject<List<Category>>(result.Result);
          

            response.EnsureSuccessStatusCode();

            return jsonData;
        }
       
        public async Task SubmitOrder(RequestModel item)
        { 
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                //  send a POST request  
                var uri = "http://ordernowservice.azurewebsites.net/api/Requests";
                var result = await client.PostAsync(uri, content);

                // on error throw a exception  
                result.EnsureSuccessStatusCode();

                // handling the answer  
                var resultString = await result.Content.ReadAsStringAsync();

            }
             
        }

    }
}
