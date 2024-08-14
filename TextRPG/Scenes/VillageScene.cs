using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class VillageScene : Scene
    {
        private char[,] map;

        public VillageScene(Game game) : base(game)
        {
            map = new char[,]
                {
                    { 's','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s','s'},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
                    { ' ',' ',' ',' ',' ',' ',' ','f','f','f','f','f','h','f','f','f',' ',' ',' ',' '},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','h',' ',' ',' ',' ',' ',' ',' '},
                    { ' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','h',' ',' ',' ',' ',' ',' ',' '},
                    { 'f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f','f'}
                };
        }

        public override void Enter()
        {
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

        public override void Update()
        {
        }
    }
}
