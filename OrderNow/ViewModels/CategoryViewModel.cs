using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrderNow.Models;
using OrderNow.Views;
using Resturant.Class;
using Resturant.Models;

namespace OrderNow.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public ObservableCollection<Category> Category { get; set; }
        public Command LoadCategoryCommand { get; set; }
        public Command LoadMoreCategoryCommand { get; set; }
        bool isLoading = false;

        public CategoryViewModel()
            {
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