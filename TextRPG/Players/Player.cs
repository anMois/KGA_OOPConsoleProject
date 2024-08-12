namespace TextRPG.Players
{
    public class Player
    {
        private string name;
        private int gold;
        private Job job;
        private State state;
        private int[] maxExp;

        public string Name { get { return name; } set { name = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public Job Job { get { return job; } set { job = value; } }
        public State State { get { return state; } set { state = value; } }
        public int[] MaxExp { get { return maxExp; } set { maxExp = value; } }

        public Player(string name)
        {
            this.name = name;
            gold = 100;
            job = Job.Beginner;
            state = new State();
            maxExp = GetMaxExps();
        }

        public int[] GetMaxExps()
        {
            MaxExp = new int[10];

            for (int i = 0; i < MaxExp.Length; i++)
            {
                if (i == 0)
                    MaxExp[i] = 3;
                else if (i == 1)
                    MaxExp[i] = 6;
                else
                    MaxExp[i] = MaxExp[i - 1] + MaxExp[i - 2];
            }

            return MaxExp;
        }

        public void ShowInfo()
        {
            Console.WriteLine("========캐릭터 상태창========");
            Console.WriteLine($"이름 : {name,8}");
            Console.WriteLine($"직업 : {job,8}");
            Console.WriteLine($"레벨 : {state.Level,8}");
            Console.WriteLine($"경험치 : {state.CurExp,6}");
            Console.WriteLine($"체력 : {state.MaxHp,8}");
            Console.WriteLine($"근력 : {state.STR,2} | 민첩 : {state.DEX,2}");
            Console.WriteLine($"지력 : {state.INT,2} | 행운 : {state.LUK,2}");
            Console.WriteLine($"소지 골드 : {gold} G");
            Console.WriteLine("=============================\n");
        }
    }
}
