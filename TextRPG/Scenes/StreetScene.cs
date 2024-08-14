using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects;

namespace TextRPG.Scenes
{
    public class StreetScene : Scene
    {
        private char[,] map;
        private Point playerPos;
        private GameObject potal;

        private ConsoleKey input;

        public StreetScene(Game game) : base(game)
        {
            map = new char[,]
                {
                    { 's','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s'},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                    { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
                };
            playerPos = new Point(0, 1);

            //potal = new GameObject(this);
            //potal.color = ConsoleColor.Cyan;
            //potal.simbol = 't';
            //potal.point = new Point(map.GetLength(1) - 1, 1);
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
            input = Console.ReadKey().Key;
        }

        public override void Render()
        {
            PrintMap();
            PrintPlayerSimpleInfo();
            PrintObject();
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

        private void PrintObject()
        {
            Console.SetCursorPosition(potal.point.X, potal.point.Y);
            Console.ForegroundColor = potal.color;
            Console.WriteLine($"{potal.simbol}");
            Console.ResetColor();
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
            Move();
        }

        private void Move()
        {
            Point next = playerPos;

            switch (input)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    next = new Point(playerPos.X, playerPos.Y - 1);
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    next = new Point(playerPos.X, playerPos.Y + 1);
                    break;
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    next = new Point(playerPos.X - 1, playerPos.Y);
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    next = new Point(playerPos.X + 1, playerPos.Y);
                    break;
            }

            if (map[next.Y, next.X] == ' ')
            {
                playerPos = next;
            }
        }
    }
}
