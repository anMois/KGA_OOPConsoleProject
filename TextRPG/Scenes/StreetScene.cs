using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class StreetScene : Scene
    {
        private char[,] map;
        private Point playerPos;

        public StreetScene(Game game) : base(game)
        {
            map = new char[,]
                {
                    { 's','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s'},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                    { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
                };
            playerPos = new Point(0, 1);


        }

        public override void Enter()
        {
            Console.CursorVisible = false;
        }

        public override void Exit()
        {
        }

        public override void Input()
        {
            Console.ReadKey();
        }

        public override void Render()
        {
            PrintMap();
            PrintPlayerSimpleInfo();
            PrintPlayer();
        }

        private void PrintMap()
        {
            Console.Clear();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for(int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 's' || map[y, x] == ' ')
                    {
                        Console.Write(" ");
                    }
                    else if (map[y,x] == 'f')
                    {
                        Console.Write("-");
                    }
                }
                Console.WriteLine();
            }
        }

        private void PrintPlayerSimpleInfo()
        {
            Console.WriteLine($"Lv.{game.Player.State.Level.ToString("D2")}  {game.Player.Name}");
            Console.WriteLine($"HP {game.Player.State.CurHp,+4} / {game.Player.State.MaxHp,-4}");
            Console.WriteLine($"Exp {game.Player.State.CurExp,+3} / {game.Player.MaxExp[game.Player.State.Level - 1],-3}");
        }

        private void PrintPlayer()
        {
            Console.SetCursorPosition(playerPos.X, playerPos.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("p");
            Console.ResetColor();
        }

        public override void Update()
        {
        }
    }
}
