using System;
using Vending_machine;

namespace Vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a user and a bank
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"

                                                *                                                           
                     (                        (  `                  )                   (  (       )     )  
 (   (    (          )\ )  (          (  (    )\))(      )       ( /( (            (    )\))(   ( /(  ( /(  
 )\  )\  ))\  (     (()/(  )\   (     )\))(  ((_)()\  ( /(   (   )\()))\   (      ))\  ((_)()\  )\()) )\()) 
((_)((_)/((_) )\ )   ((_))((_)  )\ ) ((_))\  (_()((_) )(_))  )\ ((_)\((_)  )\ )  /((_)  (()((_)((_)\ ((_)\  
\ \ / /(_))  _(_/(   _| |  (_) _(_/(  (()(_) |  \/  |((_)_  ((_)| |(_)(_) _(_/( (_))     | __| /  (_)/  (_) 
 \ V / / -_)| ' \))/ _` |  | || ' \))/ _` |  | |\/| |/ _` |/ _| | ' \ | || ' \))/ -_)    |__ \| () || () |  
  \_/  \___||_||_| \__,_|  |_||_||_| \__, |  |_|  |_|\__,_|\__| |_||_||_||_||_| \___|    |___/ \__/  \__/   
                                     |___/                                                                  
");
            Console.WriteLine("Hello and welcome to the vending machine, please write out your name:");
            Console.ResetColor();
            var name = Console.ReadLine();
            User user = new User(name, 100.00m);
            Bank bank = new Bank(1000.00m);

            // Initialize vending machine items
            Inventory inventory = new Inventory();
            inventory.AddItem("Coke", 16, 5.00m);
            inventory.AddItem("Chips", 20, 5.00m);
            inventory.AddItem("Candy", 15, 5.00m);
            inventory.AddItem("Galactic Geyser", 12, 7.50m);
            inventory.AddItem("Nebula Nuggets", 20, 6.50m);
            inventory.AddItem("Alien Ambrosia", 11, 8.00m);
            inventory.AddItem("Cosmic Crystals", 17, 4.50m);
            inventory.AddItem("Quantum Quencher", 7, 6.00m);
            inventory.AddItem("Berserker Brew", 20, 9.00m);
            inventory.AddItem("Doomsday Double", 20, 8.50m);
            inventory.AddItem("Apocalypse Ale", 20, 10.00m);
            inventory.AddItem("Cataclysmic Crunch", 20, 7.50m);
            inventory.AddItem("Armageddon Ammunition", 20, 9.50m);

            // Create vending machine with the inventory and bank
            VendingMachine vendingMachine = new VendingMachine(inventory, bank);

            // Display initial user balance
            Console.WriteLine($"Welcome, {user.Name}! Your balance is: {user.Money:C}\n");

            // Display available items
            inventory.ListItems();

            // Main vending machine loop
            while (true)
            {
                // Prompt user to select an item
                Console.Write("\nEnter the name of the item you want to purchase, write help for a list of commands (or 'exit' to quit): ");
                string input = Console.ReadLine().Trim();

                if (input.ToLower() == "exit")
                {
                    Console.WriteLine("Thank you for using the vending machine. Goodbye!");
                    break;
                }
                else if (input.ToLower() == "help")
                {
                    // Display list of commands
                    Console.WriteLine("Available commands:");
                    Console.WriteLine("'exit' - Exit the vending machine");
                    Console.WriteLine("'help' - Display available commands");
                    Console.WriteLine("'list' - Display available items");
                    Console.WriteLine("'balance' - Display your current balance");
                    Console.WriteLine("'history' - Display purchase history");
                    continue; // Continue to prompt for user input
                }
                else if (input.ToLower() == "list")
                {
                    // Display available items
                    Console.WriteLine("Available Items:");
                    inventory.ListItems();
                    continue; // Continue to prompt for user input
                }
                else if (input.ToLower() == "balance")
                {
                    Console.WriteLine($"Your current balance is {user.Money}");
                    continue;
                }
                else if (input.ToLower() == "history")
                {
                    vendingMachine.purchaseHistory(user);
                    continue;
                }
                // Process the purchase
                bool purchaseResult = vendingMachine.PurchaseItem(user, input);
                if (!purchaseResult)
                {
                    Console.WriteLine("Purchase failed. Please try again.");
                }
            }
        }
    }
}
