using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Items;

namespace TextRPG.GameObjects.Factorys
{
    public class ItemFactory
    {
        public static Weapon WeaponCreate(string name)
        {
            if (name == "검" || name == string.Empty)
            {
                Weapon sword = new Weapon();
                sword.Name = name;
                sword.Level = 0;
                sword.AtkDamage = 15;

                return sword;
            }
            else
            {
                Console.WriteLine("해당 이름을 가진 무기가 없습니다.");
                return null;
            }
        }

        public static Potion PotionCreate(string name)
        {
            if(name == "포션" || name == string.Empty)
            {
                Potion healPotion = new Potion();
                return healPotion;
            }
            else
            {
                Console.WriteLine("해당 이름을 가진 포션이 없습니다.");
                return null;
            }
        }
    }
}
