using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderNow.Models;
using OrderNow.RestAPIClient;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;

namespace OrderNow.Services
{
    public class MockDataHistory : IDataHistory<RequestModel>
    {
        List<RequestModel> historyLostObj; 
        RestClientMenu _restControl = new RestClientMenu();


        public MockDataHistory()
        {

            var HistoryList = _restControl.GetAllIHistoryByUserId();
            historyLostObj = new List<RequestModel>(); 
            foreach (RequestModel item in HistoryList.ToList())
            {
                decimal total = 0;


                foreach (var details in item.RequestDetails)
                {
                    total += (decimal)(details.Price * details.Number);
                }

                historyLostObj.Add(new RequestModel
                {
                    RequestId = item.RequestId,
                    CreateTime = item.CreateTime,
                    RestaurantName = item.RestaurantName,
                    LogoURL=item.LogoURL,
                    TableName = item.TableName,
                    RequestDetails = item.RequestDetails,
                    RestaurantId = item.RestaurantId,
                    Status = item.Status,
                    TotalOrder = total
                });
            }

        }



        public async Task<RequestModel> GetHistoryAsync(long id)
        {
            return await Task.FromResult(historyLostObj.FirstOrDefault(s => s.RequestId == id));
        }

        public async Task<IEnumerable<RequestModel>> GetHistoryAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(historyLostObj);
        }
    }
}