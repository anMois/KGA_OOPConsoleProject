using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items;

namespace TextRPG
{
    public class Inventory
    {

        private List<Item> inven;

        public Inventory()
        {
            inven = new List<Item>();
        }

        public void AddItem(Item item)
        {
            inven.Add(item);
        }

        public void RemoveItem(Item item)
        {
            inven.Remove(item);
        }

        public void RemoveAtItem(int index)
        {
            if (index < 0 && index > inven.Count)
                return;

            inven.RemoveAt(index);
        }

        public void ShowInven()
        {
            Console.WriteLine("======인벤토리======");
            if (inven.Count == 0)
            {
                Console.WriteLine("   비어 있음");
            }
            else
            {
                for (int i = 0; i < inven.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {inven[i].Name}");
                }
            }
            Console.WriteLine("===================");
        }
    }
}
