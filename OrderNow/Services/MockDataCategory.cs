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
    public class MockDataCategory : IDataCategory<Category>
    {
        List<Category> categories;
        RestClientFeature<Feature> _restClient = new RestClientFeature<Feature>();
        RestClientFeature<FeatureControls> _restFeatureControl = new RestClientFeature<FeatureControls>();

        public List<Category> GetItemsByTableId(int tableId)
        {

            return _restFeatureControl.GetAllICategoriesByTable(tableId);
        }

        public MockDataCategory()
        {
            if (Constants.TableId != 0)
            {

                var categoryList = GetItemsByTableId(Constants.TableId);
                categories = new List<Category>();

                foreach (Category item in categoryList)
                {
                    categories.Add(new Category
                    {
                        CategoryId = item.CategoryId,
                        Text = item.CategoryNameDictionary[Constants.CurrentLang],
                        CategoryNameDictionary = item.CategoryNameDictionary,
                        imageURL = item.imageURL,
                        items = item.items,
                        RestaurantId = item.RestaurantId
                    });
                }
            }
        }



        public async Task<Category> GetCategoryAsync(long id)
        {
            return await Task.FromResult(categories.FirstOrDefault(s => s.CategoryId == id));
        }

        public async Task<IEnumerable<Category>> GetCategoryAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(categories);
        }
    }
}