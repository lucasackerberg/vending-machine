using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
    public class Item
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }

    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(string itemName, int quantity, decimal price)
        {
            var existingItem = _items.Find(item => item.Name == itemName);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                _items.Add(new Item { Name = itemName, Quantity = quantity, Price = price });
            }
        }

        public bool RemoveItem(string itemName, int quantity)
        {
            var existingItem = _items.Find(item => item.Name == itemName);
            if (existingItem == null || existingItem.Quantity < quantity)
            {
                return false;
            }

            existingItem.Quantity -= quantity;
            return true;
        }

        public int GetQuantity(string itemName)
        {
            var existingItem = _items.Find(item => item.Name == itemName);
            return existingItem != null ? existingItem.Quantity : 0;
        }

        public bool HasItem(string itemName)
        {
            var existingItem = _items.Find(item => item.Name == itemName);
            return existingItem != null && existingItem.Quantity > 1;
        }

        public decimal GetItemPrice(string itemName) 
        {
            var existingItem = _items.Find(item => item.Name == itemName);
            return existingItem != null ? existingItem.Price : 0;
        }

        public void ListItems()
        {
            foreach (var item in _items)
            {
                Console.Write($"{item.Name} - Quantity: {item.Quantity} Price: ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{item.Price:C}");
                Console.ResetColor(); // Reset color to default
                Console.WriteLine();
            }
        }

    }
}
