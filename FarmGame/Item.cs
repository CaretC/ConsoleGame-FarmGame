using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmGame
{
    class Item
    {
        private string name;
        private int cost;

        public Item(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        
        public int Cost
        {
            get { return cost; }
            set { cost = value; }
        }
                     
    }
}
