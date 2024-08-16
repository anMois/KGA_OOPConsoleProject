using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects;

namespace TextRPG.Scenes
{
    public class VillageScene : Scene
    {
        private char[,] map;
        private Point playerPos;

        private List<GameObject> gameObjects;

        private ConsoleKey input;

        public VillageScene(Game game) : base(game)
        {
            map = new char[,]
                {
                    { 's','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s'},
                    { 's','s','s','s','s','s','s',' ',' ',' ',' ',' ',' ',' ',' ',' ','s','s','s','s'},
                    { 's','s','s','s','s','s','s','f','f','f','f','f','h','f','f','f','s','s','s','s'},
                    { 's','s','s','s','s','s','s','s','s','s','s','s','h','s','s','s','s','s','s','s'},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','h',' ',' ',' ',' ',' ',' ',' '},
                    { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
                };
            playerPos = new Point(1, 4);
            gameObjects = new List<GameObject>();

            Place nextPotal = new Place(this);
            nextPotal.color = ConsoleColor.Cyan;
            nextPotal.simbol = 't';
            nextPotal.point = new Point(map.GetLength(1) - 1, 4);

            Place prevPotal = new Place(this);
            prevPotal.color = ConsoleColor.Cyan;
            prevPotal.simbol = 't';
            prevPotal.point = new Point(0, 4);
            prevPotal.type = SceneType.Street;

            Place storePotal = new Place(this);
            storePotal.color = ConsoleColor.Cyan;
            storePotal.simbol = 't';
            storePotal.point = new Point(7, 1);
            storePotal.type = SceneType.Store;

            gameObjects.Add(nextPotal);
            gameObjects.Add(prevPotal);
            gameObjects.Add(storePotal);
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
            PrintObject();
            PrintPlayer();
            PrintPlayerSimpleInfo();
        }

        private void PrintMap()
        {
            Console.Clear();
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == 's' || map[y, x] == ' ')
                    {
                        Console.Write(" ");
                    }
                    else if (map[y, x] == 'f')
                    {
                        Console.Write("-");
                    }
                    else if (map[y,x] == 'h')
                    {
                        Console.Write("H");
                    }
                }
                Console.WriteLine();
            }
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

        private void PrintPlayerSimpleInfo()
        {
            Console.SetCursorPosition(0, map.GetLength(0));
            Console.WriteLine($"Lv.{game.Player.State.Level.ToString("D2")}  {game.Player.Name}");
            Console.WriteLine($"HP {game.Player.State.CurHp,+4} / {game.Player.State.MaxHp,-4}");
            Console.WriteLine($"Exp {game.Player.State.CurExp,+3} / {game.Player.MaxExp[game.Player.State.Level - 1],-3}");
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

            if (map[next.Y, next.X] == ' ' || map[next.Y, next.X] == 'h')
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
