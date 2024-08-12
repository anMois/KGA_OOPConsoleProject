using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class State
    {
        private int level;
        private float curExp;
        private int curHp;
        private int maxHp;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int luck;

        public int Level { get { return level; } set { level = value; } }
        public float CurExp { get { return curExp; } set { curExp = value; } }
        public int CurHp { get { return curHp; } set { curHp = value; } }
        public int MaxHp { get {return maxHp; } set {maxHp = value; } }
        public int STR { get { return strength; } set { strength = value; } }
        public int DEX { get { return dexterity; } set { dexterity = value; } }
        public int INT { get { return intelligence; } set { intelligence = value; } }
        public int LUK { get { return luck; } set { luck = value; } }

        public State()
        {
            level = 1;
            curExp = 0;
            curHp = maxHp;
            maxHp = 10;
            strength = 4;
            dexterity = 4;
            intelligence = 4;
            luck = 4;
        }

        public void RandomGetStets()
        {
            Random random = new Random();

            STR = random.Next(4, 13);
            DEX = random.Next(4, 13);
            INT = random.Next(4, 13);
            LUK = random.Next(4, 13);
        }
    }
}
