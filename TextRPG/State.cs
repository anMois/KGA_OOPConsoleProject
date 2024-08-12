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
        private float maxExp;
        private int curHp;
        private int maxHp;
        private int strength;
        private int dexterity;
        private int intelligence;
        private int luck;

        public int Level { get { return level; } set { level = value; } }
        public float CurExp { get { return curExp; } set { curExp = value; } }
        public float MaxExp { get {return maxExp; } set { maxExp = value; } }
        public int CurHp { get { return curHp; } set { curHp = value; } }
        public int MaxHp { get {return maxHp; } set {maxHp = value; } }
        public int STR { get { return strength; } set { strength = value; } }
        public int DEX { get { return dexterity; } set { dexterity = value; } }
        public int INT { get { return intelligence; } set { intelligence = value; } }
        public int LIK { get { return luck; } set { luck = value; } }
    }
}
