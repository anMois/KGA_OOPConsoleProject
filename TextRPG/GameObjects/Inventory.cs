using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Items;

namespace TextRPG.GameObjects
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public int GetItemCount()
        {
            return items.Count;
        }

        public Item GetItem(int index)
        {
            Item item = items[index];
            return item;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name}을(를) 얻었습니다.");
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void RemoveAtItem(int index)
        {
            if (index < 0 && index > items.Count)
                return;

            items.RemoveAt(index);
        }

        public void ShowInven()
        {
            Console.WriteLine("======인벤토리======");
            if (items.Count == 0)
            {
                Console.WriteLine("   비어 있음");
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name}");
                }
            }
            Console.WriteLine("===================");
        }
    }
}
