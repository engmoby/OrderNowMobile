using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using OrderNow.Models;
using OrderNow.Views;
using Resturant.Class;
using Resturant.Models;
using OrderNow.RestAPIClient;
using OrderNow.Services;

namespace OrderNow.ViewModels
{
    public class HistoryViewModel : BaseViewModel
    {
        public ObservableCollection<RequestModel> History { get; set; }
        public Command LoadHistoryCommand { get; set; }
        public Command LoadMoreHistoryCommand { get; set; }
        bool isLoading = false;

        public HistoryViewModel()
        {
            Title = Constants.CurrentLang == "en-us" ? "History" : "الطلبات السابقه";
            History = new ObservableCollection<RequestModel>();
            LoadHistoryCommand = new Command(async () => await ExecuteLoadHistoryCommand());
            LoadMoreHistoryCommand = new Command(async () => await ExecuteLoadMoreHistoryCommand());

        }

        async Task ExecuteLoadHistoryCommand()
        {
            Constants.Page = 1;
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                History.Clear();
                if (Constants.TableId != 0)
                {
                    var historyList = await  DataHistory.GetHistoryAsync(true);
                    foreach (RequestModel item in historyList)
                    {
                        History.Add(item);
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
               // Application.Current.MainPage = new ScanPage();
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        async Task ExecuteLoadMoreHistoryCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var historyList = await DataHistory.GetHistoryAsync(true);
                foreach (var item in historyList)
                {
                    History.Add(item);
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