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

namespace OrderNow.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Category { get; set; }
        public Command LoadCategoryCommand { get; set; }
        public Command LoadMoreCategoryCommand { get; set; }
        bool isLoading = false;


       //-------------------------------//

        private List<CategoryList> _listOfCategories;
        public List<CategoryList> ListOfCategories { get { return _listOfCategories; } set { _listOfCategories = value; base.OnPropertyChanged(); } }

        public class CategoryList : List<Category>
        {
            public string Heading { get; set; }
            public List<Category> Persons => this;
        }
        //------------------------------//
        public CategoryViewModel()
        {
            ///////////////////////////////////////
            var sList = new CategoryList()
            {
                new Category () { Text = "chiecken crispy", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null},
                new Category () { Text = "faheta fra5", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null},
                new Category () { Text = "baneh", itemsKareem = {Description="hello from the other side", imageURL = "logo"}, items = null}
            };
            sList.Heading = "Chicken";

            var dList = new CategoryList()
            {
                new Category () { Text = "beef"},
                new Category () { Text = "meet balls"}
            };
            dList.Heading = "Meat";


            var jList = new CategoryList()
            {
                new Category () { Text = "tuna salad"},
                new Category () { Text = "green salad"}
            };

            jList.Heading = "Salads";

            var list = new List<CategoryList>()
            {
                sList,
                dList,
                jList
            };

            ListOfCategories = list;
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