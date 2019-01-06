using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderNow.Models;
using Resturant.Class;
using Resturant.Models;
using Resturant.RestAPIClient;

namespace OrderNow.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;
        RestClientFeature<Feature> _restClient = new RestClientFeature<Feature>();
        RestClientFeature<FeatureControls> _restFeatureControl = new RestClientFeature<FeatureControls>();

        public List<Category> GetItemsByTableId(int tableId)
        {
            return _restFeatureControl.GetAllICategoriesByTable(tableId);
        }

        public MockDataStore()
        {
            var categoryList = GetItemsByTableId(Constants.TableId);
            items = new List<Item>();

            //foreach (Item item in itemList)
            //{
            //    items.Add(new Item
            //    {
            //        Id = item.ItemID,
            //        Text = item.ItemNameDictionary[Constants.CurrentLang],
            //        ItemNameDictionary = item.ItemNameDictionary,
            //        Description = item.ItemDescriptionDictionary[Constants.CurrentLang],
            //        ItemDescriptionDictionary = item.ItemDescriptionDictionary,
            //        imageURL = item.imageURL,
            //        Sizes = item.Sizes,
            //        Price = "35",
            //        PriceText = Constants.CurrentLang == "en-us" ? "SAR" : "ريال"
            //    });
            //}
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(long id)
        {
            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(long id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}