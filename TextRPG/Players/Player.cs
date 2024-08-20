using TextRPG.GameObjects;
using TextRPG.GameObjects.Items;
using TextRPG.GameObjects.Monsters;
using TextRPG.Interfaces;

namespace TextRPG.Players
{
    public class Player : IDamgeable
    {
        private string name;
        private int gold;
        private int[] maxExp;
        private Job job;
        private State state;
        private Weapon weapon;
        private Inventory inventory;

        public string Name { get { return name; } set { name = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public int[] MaxExp { get { return maxExp; } set { maxExp = value; } }
        public Job Job { get { return job; } set { job = value; } }
        public State State { get { return state; } set { state = value; } }
        public Weapon Weapon { get { return weapon; } set { weapon = value; } }
        public Inventory Inventory { get { return inventory; } set { inventory = value; } }

        public Player(string name)
        {
            this.name = name;
            gold = 100;
            job = Job.Beginner;
            state = new State();
            maxExp = GetMaxExps();
            inventory = new Inventory();
        }

        //레벨별 최대 경험치
        private int[] GetMaxExps()
        {
            maxExp = new int[10];

            for (int i = 0; i < maxExp.Length; i++)
            {
                if (i == 0)
                    maxExp[i] = 3;
                else if (i == 1)
                    maxExp[i] = 6;
                else
                    maxExp[i] = maxExp[i - 1] + maxExp[i - 2];
            }

            return maxExp;
        }

        public void ShowInfo()
        {
            Console.WriteLine("========캐릭터 상태창========");
            Console.WriteLine($"Lv. {state.Level.ToString("D2")} |  {name} | {job}\n");
            Console.WriteLine($"체력 : {state.CurHp,6} | {state.MaxHp}");
            Console.WriteLine($"마력 : {state.CurMp,6} | {state.MaxMp}");
            Console.WriteLine($"경험치 : {state.CurExp,4} | {maxExp[state.Level - 1]}");
            Console.WriteLine($"공격력 : {state.Atk,4}");
            Console.WriteLine($"마법력 : {state.Mag,4}");
            Console.WriteLine($"방어력 : {state.Def,4}");
            Console.WriteLine($"소지 골드 : {gold} G");
            Console.WriteLine("\n능력치");
            Console.WriteLine("─────────────────────────────");
            Console.WriteLine($"근력 : {state.STR,2} | 민첩 : {state.DEX,2}");
            Console.WriteLine($"지력 : {state.INT,2} | 행운 : {state.LUK,2}");
            Console.WriteLine("=============================\n");
        }

        public void GetDamage(int damge)
        {
            if (damge < 0)
            {
                Console.WriteLine("플레이어가 피해를 입지 않았습니다.");
                return;
            }

            Console.WriteLine($"플레이어 {damge}의 피해를 입었습니다.");
            state.CurHp -= damge;

            if (state.CurHp < 0)
            {
                Console.WriteLine("플레이어가 죽었습니다.");
            }

            Thread.Sleep(1000);
        }
    }
}
