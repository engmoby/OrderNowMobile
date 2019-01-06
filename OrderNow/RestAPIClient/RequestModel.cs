using System;
using System.Collections.Generic;

namespace OrderNow.RestAPIClient
{
    public class RequestModel
    {
        public long RequestId { get; set; }
        public long? RestaurantId { get; set; }
        public long? TableId { get; set; }
        public string TableName { get; set; }
        public string Status { get; set; }
        public long UserId { get; set; }
        public List<RequestDetailModel> RequestDetails { get; set; }
        public string Comment { get; set; }
        public DateTime? RequestTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public Dictionary<string, string> RestaurantName { get; set; }
        public string LogoURL { get; set; }
        public decimal TotalOrder { get; set; }

    }

    public class RequestList
    {
        public List<RequestModel> Results { get; set; }
        public int TotalCount { get; set; }
        public string NextPageURL { get; set; }
        public string PrevPageURL { get; set; }
    }
}
