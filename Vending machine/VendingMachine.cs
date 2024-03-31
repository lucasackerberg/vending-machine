using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
public class VendingMachine
    {
        private Inventory _inventory;
        private Bank _bank;
        private List<(string itemName, decimal itemPrice)> _history;

        public VendingMachine(Inventory inventory, Bank bank)
        {
            _inventory = inventory;
            _bank = bank;
            _history = new List<(string, decimal)>();
        }

        public bool PurchaseItem(User user, string itemName)
        {
            // Check if the item exists in the inventory
            if (!_inventory.HasItem(itemName))
            {
                Console.WriteLine($"Item '{itemName}' is not available.");
                return false;
            }

            // Get the price of the item
            decimal itemPrice = _inventory.GetItemPrice(itemName);

            // Check if the user has enough money
            if (user.Money < itemPrice)
            {
                Console.WriteLine($"Insufficient funds. Price of '{itemName}' is {itemPrice:C}.");
                return false;
            }

            // Process the transaction
            _bank.ProcessTransaction(user, itemPrice);
            _inventory.RemoveItem(itemName, 1);

            // Lägg till itemet till historiken.
            _history.Add((itemName, itemPrice));

            Console.WriteLine($"Purchase successful! '{itemName}' has been dispensed.");
            return true;
        }

        public void purchaseHistory(User user)
        {
            if (_history.Count > 0)
            {
                Console.WriteLine($"Purchase history for {user.Name}:");
                foreach (var purchase in _history)
                {
                    Console.WriteLine($"{purchase.itemName}:");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{purchase.itemPrice:C}");
                    Console.ResetColor();
                    Console.WriteLine("--------------------");
                }
            }
            else
            {
                Console.WriteLine($"No purchase history found for {user.Name}.");
            }
        }
    }
}
