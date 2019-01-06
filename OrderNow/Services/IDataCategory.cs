using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderNow.Services
{
    public interface IDataCategory<T>
    {
       
        Task<T> GetCategoryAsync(long id);
        Task<IEnumerable<T>> GetCategoryAsync(bool forceRefresh = false);
       
    }
}
