﻿using TextRPG.GameObjects.Monsters;
using TextRPG.Players;

namespace TextRPG.Scenes
{
    public class BattleScene : Scene
    {
        private Player player;
        private Monster monster;

        private int damge;

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
            damge = player.State.Atk + player.Weapon.AtkDamage;
        }

        public override void Exit()
        {
            if (player.State.CurExp == player.MaxExp[player.State.Level - 1])
            {
                player.State.Level++;
                player.State.CurExp = 0;
                if (player.State.CurHp != player.State.MaxHp)
                    player.State.CurHp = player.State.MaxHp;
            }
        }

        public override void Input()
        {
            base.input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
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
            Console.WriteLine($"HP {player.State.CurHp} / {player.State.MaxHp} ");
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
            //플레이어 체력 확인
            if (player.State.CurHp < 0)
            {

            }

            //플레이어 턴
            switch (base.input)
            {
                case "1":
                    Attack(monster);
                    break;
                case "2":
                    Defence(monster);
                    break;
                case "3":
                    if (Run())
                        return;
                    else
                        break;
                default:
                    return;
            }

            //몬스터 체력확인
            if (monster.HP < 0)
            {
                monster.removeWhenInteract = true;
                player.Gold += monster.Gold;
                player.State.CurExp += monster.Exp;
                game.ReturnScene();
                return;
            }

            //몬스터 턴
            Random rand = new Random();
            int randNum = rand.Next(0, 100) % 10;

            if (randNum < 3)
                Defence(player);
            else
                Attack(player);
        }

        private void Attack<T>(T obj)
        {
            int playerDamege, monsterDamge;

            if (player.State.Level > monster.Level)
            {
                playerDamege = damge - monster.Def;
                monsterDamge = monster.Atk - player.State.Def - (player.State.Level - monster.Level);
            }
            else if (player.State.Level < monster.Level)
            {
                playerDamege = damge - monster.Def - (monster.Level - player.State.Level);
                monsterDamge = monster.Atk - player.State.Def;
            }
            else
            {
                playerDamege = damge - monster.Def;
                monsterDamge = monster.Atk - player.State.Def;
            }

            if (obj is Monster)
                monster.GetDamage(playerDamege < 0 ? 0 : playerDamege);
            else if (obj is Player)
                player.GetDamage(monsterDamge < 0 ? 0 : monsterDamge);
        }

        private void Defence<T>(T obj)
        {
            if (obj is Player)
                player.State.Def += 10;
            else if (obj is Monster)
                monster.Def += 10;
        }

        private bool Run()
        {
            Random rand = new Random();
            int randNum = rand.Next(0, 100) % 10;

            if (randNum < 5)
            {
                Console.WriteLine("무사히 도망쳤습니다.");
                Thread.Sleep(750);

                game.ReturnScene();
                return true;
            }
            else
            {
                Console.WriteLine("도망치기에 몬스터에게 잡혔습니다.");
                Thread.Sleep(750);
                return false;
            }
        }
    }
}
