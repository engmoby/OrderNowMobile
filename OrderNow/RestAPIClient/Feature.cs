using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderNow.Models;

namespace Resturant.Models
{
   
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
    //public class ItemList
    //{
    //    public List<Templates> Templates { get; set; }
    //}
    //public class Templates
    //{
    //    public List<ItemModels> ItemModels { get; set; }
    //}

    //public class ItemModels
    //{

    //    public int ItemID { get; set; }
    //    public Dictionary<string, string> ItemNameDictionary { get; set; }
    //    public Dictionary<string, string> ItemDescriptionDictionary { get; set; }
    //    public string imageURL { get; set; }

    //}
    //public class Items
    //{
    //    public long ItemID { get; set; }
    //    public Dictionary<string, string> ItemNameDictionary { get; set; }
    //    public Dictionary<string, string> ItemDescriptionDictionary { get; set; }
    //    public string imageURL { get; set; }
    //    public int CategoryId { get; set; }

    //}
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
