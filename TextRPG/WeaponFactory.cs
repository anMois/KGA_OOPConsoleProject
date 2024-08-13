using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Items;

namespace TextRPG
{
    public class WeaponFactory
    {
        public static Item Create(string name)
        {
            if(name == "검")
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
    }
}
