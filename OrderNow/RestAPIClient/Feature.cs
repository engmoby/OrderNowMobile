using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderNow.Models;

namespace Resturant.Models
{
    public class FeatureList
    {
        public List<Item> Results { get; set; }
        public int TotalCount { get; set; }
        public string NextPageURL { get; set; }
        public string PrevPageURL { get; set; }
    }
    public class Feature
    {
        public int FeatureId { get; set; }
        public Dictionary<string, string> FeatureNameDictionary { get; set; }
        public string imageURL { get; set; }
        public string type { get; set; }
        public List<FeatureControls> FeatureControl { get; set; }
        public List<Restaurants> Restaurants { get; set; }
    }


    public class FeatureControls
    {
        public int FeatureControlId { get; set; }
        public int Order { get; set; }
        public int FeatureId { get; set; }
        public int Control { get; set; }
        public string ControlType { get; set; }
        public List<FeatureDetails> FeatureDetails { get; set; }
    }

    public class FeatureDetails
    {
        public int featureControlId { get; set; }
        public int featureDetailId { get; set; }
        public string imageURL { get; set; }
        public Dictionary<string, string> DescriptionDictionary { get; set; }
        public string Link { get; set; }

    }

    public class Restaurants
    {
        public int RestaurantId { get; set; }
        public Dictionary<string, string> RestaurantNameDictionary { get; set; }
        public string imageURL { get; set; }
    }
    public class MenuList
    {
        public List<Menus> Results { get; set; }
    }
    public class Menus
    {
        public int MenuId { get; set; }
        public Dictionary<string, string> MenuNameDictionary { get; set; }
        public string imageURL { get; set; }
    }
    public class CategoryList
    {
        public List<Category> Results { get; set; }
    }
    public class Category
    {
        public long CategoryId { get; set; }
        public long RestaurantId { get; set; }
        public Dictionary<string, string> CategoryNameDictionary { get; set; }
        public string imageURL { get; set; }
        public List<Item> items { get; set; }
        public string Text { get; set; }

    }
    public class ItemList
    {
        public List<Templates> Templates { get; set; }
    }
    public class Templates
    {
        public List<ItemModels> ItemModels { get; set; }
    }

    public class ItemModels
    {

        public int ItemID { get; set; }
        public Dictionary<string, string> ItemNameDictionary { get; set; }
        public Dictionary<string, string> ItemDescriptionDictionary { get; set; }
        public string imageURL { get; set; }

        //public List<Item> Item { get; set; }
    }
    public class Items
    {
        public long ItemID { get; set; }
        public Dictionary<string, string> ItemNameDictionary { get; set; }
        public Dictionary<string, string> ItemDescriptionDictionary { get; set; }
        public string imageURL { get; set; }
        public int CategoryId { get; set; }

    }
    public class OrderClass
    {
        public Item Item { get; set; }
        public Sizes Size { get; set; }
        public long OrderId { get; set; }
        public int Quantity { get; set; } = 1;
        public float TotalPrice { get; set; }
        public float TotalOrder { get; set; }
    }
}
