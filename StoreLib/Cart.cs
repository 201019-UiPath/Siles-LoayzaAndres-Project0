using System;
using System.Collections.Generic;

namespace StoreLib
{
    public class Cart : ICart
    {
        Dictionary<string, Item> items;
        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public Cart()
        {
            items = new Dictionary<string, Item>();
        }

        public void AddItem(Item item, int numOfItem)
        {
            //if item is already in cart, add num of item to stock
            if (items.ContainsKey(item.Name))
            {
                items[item.Name].NumOfStock += numOfItem;
            }
            //if item is not already in cart, add item
            else
            {
                item.NumOfStock = numOfItem;
                items.Add(item.Name, item);
            }
        }

        public void Write()
        {
            Console.WriteLine($"{Count} items in your cart.");
            foreach(var pair in items)
            {
                pair.Value.Write();
            }
        }
    }
}