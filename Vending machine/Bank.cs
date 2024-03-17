using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_machine
{
    public class Bank
    {
        private decimal _totalBalance;

        public Bank(decimal initialBalance)
        {
            _totalBalance = initialBalance;
        }

        public void ProcessTransaction(User user, decimal amount)
        {
            if (user.Money >= amount && amount > 0)
            {
                user.Money -= amount;
                _totalBalance += amount;
                Console.WriteLine($"Transaction successful! {amount:C} has been deducted from {user.Name}'s account.");
            }
            else
            {
                Console.WriteLine($"Transaction failed! {user.Name} does not have sufficient funds.");
            }
        }

        public void Deposit(decimal amount)
        {
            _totalBalance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (_totalBalance >= amount && amount > 0)
            {
                _totalBalance -= amount;
                Console.WriteLine($"Withdrawal of {amount:C} successful!");
            }
            else
            {
                Console.WriteLine("Withdrawal failed! Insufficient funds.");
            }
        }

        public decimal GetTotalBalance()
        {
            return _totalBalance;
        }
    }
}
