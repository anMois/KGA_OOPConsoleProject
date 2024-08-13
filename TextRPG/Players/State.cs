using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Players
{
    public class State
    {
        private int level;
        private int curExp;
        private int curHp;
        private int maxHp;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int luck;

        public int Level { get { return level; } set { level = value; } }
        public int CurExp { get { return curExp; } set { curExp = value; } }
        public int CurHp { get { return curHp; } set { curHp = value; } }
        public int MaxHp { get { return maxHp; } set { maxHp = value; } }
        public int STR { get { return strength; } set { strength = value; } }
        public int DEX { get { return dexterity; } set { dexterity = value; } }
        public int INT { get { return intelligence; } set { intelligence = value; } }
        public int LUK { get { return luck; } set { luck = value; } }

        public State()
        {
            level = 1;
            curExp = 0;
            maxHp = 10;
            curHp = maxHp;
            strength = 4;
            dexterity = 4;
            intelligence = 4;
            luck = 4;
        }

        public void RandomGetStats()
        {
            Random random = new Random();

            strength = random.Next(4, 13);
            dexterity = random.Next(4, 13);
            intelligence = random.Next(4, 13);
            luck = random.Next(4, 13);
        }
    }
}
