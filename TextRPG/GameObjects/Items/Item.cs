using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.GameObjects.Items
{
    public abstract class Item
    {
        private string name;
        private string description;
        private bool use;
        private int price;

        public string Name { get { return name; } set { name = value; } }
        public string Description { get { return description; } set { description = value; } }
        public bool Use { get { return use; } set { use = value; } }
        public int Price { get { return price; } set { price = value; } }
    }
}
