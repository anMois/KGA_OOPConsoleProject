using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TextRPG.GameObjects;
using TextRPG.GameObjects.Factorys;
using TextRPG.GameObjects.Monsters;

namespace TextRPG.Scenes
{
    public class StreetScene : Scene
    {
        private char[,] map;
        private Point playerPos;

        private List<GameObject> gameObjects;

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
            gameObjects = new List<GameObject>();

            Place potal = new Place(this);
            potal.color = ConsoleColor.Cyan;
            potal.simbol = 't';
            potal.point = new Point(map.GetLength(1) - 1, 1);
            potal.type = SceneType.Amhurst; 

            Bord bord = new Bord(this);
            bord.color = ConsoleColor.White;
            bord.simbol = 'b';
            bord.point = new Point(12, 1);

            gameObjects.Add(potal);
            gameObjects.Add(bord);

            Monster snail = MonsterFactory.MonsterCreate(this, "달팽이", MonsterType.Animal);
            snail.color = ConsoleColor.Red;
            snail.simbol = 'm';
            snail.point = new Point(8, 1);

            gameObjects.Add(snail);
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
            Console.Clear();
            PrintMap();
            PrintObject();
            PrintPlayer();
            PrintPlayerSimpleInfo();
        }

        private void PrintMap()
        {
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
            Console.SetCursorPosition(0, map.GetLength(0));
            Console.WriteLine($"Lv.{game.Player.State.Level.ToString("D2")}  {game.Player.Name}");
            Console.WriteLine($"HP {game.Player.State.CurHp,+4} / {game.Player.State.MaxHp,-4}");
            Console.WriteLine($"Exp {game.Player.State.CurExp,+3} / {game.Player.MaxExp[game.Player.State.Level - 1],-3}");
        }

        private void PrintObject()
        {
            foreach (GameObject obj in gameObjects)
            {
                if (obj.removeWhenInteract)
                {
                    gameObjects.Remove(obj);
                    return;
                }

                Console.SetCursorPosition(obj.point.X, obj.point.Y);
                Console.ForegroundColor = obj.color;
                Console.WriteLine($"{obj.simbol}");
                Console.ResetColor();
            }
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
            base.PlayerView(input);
            Move();
            Interaction();
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

        private void Interaction()
        {
            foreach (GameObject obj in gameObjects)
            {
                if (playerPos.X == obj.point.X && playerPos.Y == obj.point.Y)
                {
                    obj.Interaction(game.Player);

                    return;
                }
            }
        }
    }
}
