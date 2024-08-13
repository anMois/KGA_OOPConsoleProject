using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interfaces;

namespace TextRPG.Items
{
    public class Weapon : Item
    {
        private int level;
        private int attackDamage;

        public int Level { get { return level; } set { level = value; } }
        public int AtkDamage { get { return attackDamage; } set { attackDamage = value; } }

        public Weapon()
        {
            Name = "검";
            level = 0;
            attackDamage = 15;
        }
    }
}
