using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Vending_machine
{
    public class User
    {
        public string Name { get; }
        public decimal Money { get; set; }

        public User(string name, decimal money)
        {
            Name = name;
            Money = money;
        }
    }
}
