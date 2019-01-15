using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrderNow.Models;
using OrderNow.Views;
using Resturant.Class;
using Resturant.Models;
using System.Collections.Generic;
using Resturant.RestAPIClient;
using System.Linq;

namespace OrderNow.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        RestClientMenu _restControl = new RestClientMenu();
        public ObservableCollection<Category> Category { get; set; }
        public Command LoadCategoryCommand { get; set; }
        public Command LoadMoreCategoryCommand { get; set; }
        bool isLoading = false;


        //-------------------------------//

        private List<CategoryList> _listOfCategories;
        public List<CategoryList> ListOfCategories { get { return _listOfCategories; } set { _listOfCategories = value; base.OnPropertyChanged(); } }


        public List<String> Headers { get; set; }
        public class CategoryList : List<Category>
        {
            public string Heading { get; set; }
            public List<Category> Persons => this;
        }
        //------------------------------//
        public CategoryViewModel()
        {
            if (Constants.TableId == 0)
            {
                return;
            }
            var getCategoryList = _restControl.GetAllICategoriesByTable(Constants.TableId);

            Headers = getCategoryList.Select(a => a.CategoryNameDictionary[Constants.CurrentLang]).ToList();
            Headers.Insert(0, "All");
            ///////////////////////////////////////// 
            foreach (var cat in getCategoryList)
            {
                var _List = new CategoryList();
                var itemObj = new Item();
                foreach (var item in cat.items)
                {
                    var sizesLang = new List<Sizes>();
                    foreach (var sizeObj in item.Sizes)
                    {
                        sizesLang.Add(new Sizes
                        {
                            SizeId = sizeObj.SizeId,
                            SizeName = sizeObj.SizeNameDictionary[Constants.CurrentLang],
                            SizeNameDictionary = sizeObj.SizeNameDictionary,
                            Price = sizeObj.Price
                        });
                    }

                    itemObj = (new Item
                    {
                        Id = item.ItemID,
                        TextFull = item.ItemNameDictionary[Constants.CurrentLang],
                        Text = (item.ItemNameDictionary[Constants.CurrentLang].Length >= 25) ? item.ItemNameDictionary[Constants.CurrentLang].Substring(0, 25) : item.ItemNameDictionary[Constants.CurrentLang],
                        ItemNameDictionary = item.ItemNameDictionary,
                        DescriptionFull = item.ItemDescriptionDictionary[Constants.CurrentLang],
                        Description = (item.ItemDescriptionDictionary[Constants.CurrentLang].Length >= 35) ? item.ItemDescriptionDictionary[Constants.CurrentLang].Substring(0, 35) : item.ItemDescriptionDictionary[Constants.CurrentLang],
                        ItemDescriptionDictionary = item.ItemDescriptionDictionary,
                        imageURL = item.imageURL + "?type='thumbnail'&date=" + DateTime.Now,
                        Sizes = sizesLang,
                        PriceText = Constants.CurrentLang == "en-us" ? "SAR" : "ريال"
                    });
                    _List.Add(new Category()
                    {
                        Text = item.ItemNameDictionary[Constants.CurrentLang],
                        categoryItemObj = itemObj
                    });

                }
                _List.Heading = cat.CategoryNameDictionary[Constants.CurrentLang];

                if (ListOfCategories == null)
                {
                    var bindList = new List<CategoryList>()
                    {
                      _List
                    };
                    ListOfCategories = bindList;
                }
                else
                    ListOfCategories.Add(_List);
            }

            //var sList = new CategoryList()
            //{
            //    new Category () { Text = "chiecken crispy", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null},
            //    new Category () { Text = "faheta fra5", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null},
            //    new Category () { Text = "baneh", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null}
            //};
            //sList.Heading = "Chicken";

            //var dList = new CategoryList()
            //{
            //    new Category () { Text = "beef"},
            //    new Category () { Text = "meet balls"}
            //};
            //dList.Heading = "Meat";


            //var jList = new CategoryList()
            //{
            //    new Category () { Text = "tuna salad"},
            //    new Category () { Text = "green salad"}
            //};

            //jList.Heading = "Salads";

            //var list = new List<CategoryList>()
            //{
            //    sList,
            //    dList,
            //    jList
            //};

            // ListOfCategories = list;
            ///////////////////////////////////////



            Title = Constants.CurrentLang == "en-us" ? "Category" : "التصنيف";
            Category = new ObservableCollection<Category>();
            LoadCategoryCommand = new Command(async () => await ExecuteLoadCategoryCommand());
            LoadMoreCategoryCommand = new Command(async () => await ExecuteLoadMoreCategoryCommand());

        }

        async Task ExecuteLoadCategoryCommand()
        {
            Constants.Page = 1;
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Category.Clear();
                if (Constants.TableId != 0)
                {
                    var Categories = await DataCategory.GetCategoryAsync(true);
                    foreach (Category item in Categories)
                    {
                        Category.Add(item);
                        Constants.RestaurantId = (int)item.RestaurantId;
                    }

                }
                else
                {
                    Application.Current.MainPage = new MainPage();

                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Un")
                {

                }
                Application.Current.MainPage = new ScanPage();
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task ExecuteLoadMoreCategoryCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var Categories = await DataCategory.GetCategoryAsync(true);
                foreach (var item in Categories)
                {
                    Category.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public bool IsLoading
        {
            get
            {
                return isLoading;
            }
            set
            {
                isLoading = value;
                OnPropertyChanged();
            }
        }
    }
}