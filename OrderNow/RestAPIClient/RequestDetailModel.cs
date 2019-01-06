using System;
namespace OrderNow.RestAPIClient
{
    public class RequestDetailModel
    {
        public long RequestDetailId { get; set; }
        public long ItemId { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public long? ItemSizeId { get; set; }
    }
}
