using System;
using System.Collections.Generic;
using Resturant.Class;

namespace OrderNow.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Text { get; set; }
        public string TextFull { get; set; }
        public string Description { get; set; }
        public string DescriptionFull { get; set; }
        public long ItemID { get; set; }
        public Dictionary<string, string> ItemNameDictionary { get; set; }
        public Dictionary<string, string> ItemDescriptionDictionary { get; set; }
        public string imageURL { get; set; }
        public string Price { get; set; }
        public string PriceText { get; set; }
        public List<Sizes> Sizes { get; set; }

    }
    public class Sizes
    {
        public long SizeId { get; set; }
        public Dictionary<string, string> SizeNameDictionary { get; set; }
        public string SizeName { get; set; }
        public float Price { get; set; }
        public string CurrencyText
        {
            get => (Constants.CurrentLang == "en-us" ? "SAR" : "ريال");
        }
    }
}