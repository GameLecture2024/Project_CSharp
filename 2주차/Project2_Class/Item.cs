using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_Class
{
    public class Item
    {
        public string Name { get; private set; }
        public string Type { get; private set; }
        public int BasePrice { get; private set; }

        public Item(string name, string type, int basePrice)
        {
            Name = name;
            Type = type;
            BasePrice = basePrice;
        }
    }
}
