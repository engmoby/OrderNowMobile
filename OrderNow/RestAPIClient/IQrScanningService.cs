using System;
using System.Threading.Tasks;

namespace OrderNow.RestAPIClient
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
