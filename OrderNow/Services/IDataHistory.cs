using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderNow.Services
{
    public interface IDataHistory<T>
    {
       
        Task<T> GetHistoryAsync(long id);
        Task<IEnumerable<T>> GetHistoryAsync(bool forceRefresh = false);
    }
}
