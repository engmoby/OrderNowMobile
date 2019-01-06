using System;
using System.Collections.Generic;
using System.Text;

namespace OrderNow.Models
{
    public enum MenuItemType
    {
        Category,
        Foods,
        Scan,
        Account,
        History,
        About,
        Settings,
        SignOut

    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
        public string Icon { get; set; }
    }
}
