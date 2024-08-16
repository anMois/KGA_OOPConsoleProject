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
            else if (name == "빨간포션")
            {
                Potion potion = new Potion();
                potion.Name = name;
                potion.Description = "둥그런 유리병에 담겨있는 약초로 만든 빨간 물약";
                potion.Effect = "일정량 체력을 회복한다.";
                potion.Amount = 5;
                return potion;
            }
            else if (name == "하얀포션")
            {
                Potion potion = new Potion();
                potion.Name = name;
                potion.Description = "둥그런 유리병에 담겨있는 약초로 만든 하얀 물약";
                potion.Effect = "일정량 체력을 회복한다.";
                potion.Amount = 10;
                return potion;
            }
            else
            {
                Console.WriteLine("해당 이름을 가진 포션이 없습니다.");
                return null;
            }
        }
    }
}
