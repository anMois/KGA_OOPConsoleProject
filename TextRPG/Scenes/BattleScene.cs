using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Monsters;
using TextRPG.Players;

namespace TextRPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        private Monster monster;

        private string input;

        public BattleScene(Game game) : base(game)
        {
        }

        public void SetBattle(Player player, Monster monster)
        {
            this.player = player;
            this.monster = monster;
        }

        public override void Enter()
        {
            Console.Clear();
            Console.CursorVisible = true;
        }

        public override void Exit()
        {
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Render()
        {
            PrintMonsterInfo();
            Console.WriteLine("\n");
            PrintPlayerInfo();
            PrintBattleMenu();
        }

        private void PrintMonsterInfo()
        {
            Console.WriteLine("몬스터의 정보");
            Console.WriteLine($" Lv.{monster.Level.ToString("D2")}  {monster.Name}  HP {monster.HP}");
            Console.WriteLine("─────────────────────────────────────────────────");
        }

        private void PrintPlayerInfo()
        {
            Console.WriteLine("─────────────────────────────────────────────────");
            Console.WriteLine($"Lv.{player.State.Level.ToString("D2")}   {player.Name}");
            Console.WriteLine($"HP {player.State.CurHp} / {player.State.MaxHp}");
        }

        private void PrintBattleMenu()
        {
            Console.WriteLine();
            Console.WriteLine("다음 행동을 입력하시오.");
            Console.WriteLine("1. 공격 2. 방어 3. 도망가기");
            Console.Write("입력 : ");
        }

        public override void Update()
        {
        }
    }
}
