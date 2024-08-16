using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public abstract class Scene
    {
        public Game game;

        protected string input;

        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void Enter();
        public abstract void Render();
        public abstract void Input();
        public abstract void Update();
        public abstract void Exit();

        protected void PlayerView(ConsoleKey input)
        {
            if(game.CurScene is StreetScene || game.CurScene is VillageScene)
            {
                switch (input)
                {
                    case ConsoleKey.E:
                        game.ChangeScene(SceneType.State);
                        break;
                    case ConsoleKey.I:
                        game.ChangeScene(SceneType.Inventory);
                        break;
                }
            }
        }

        protected void NextPlay(string msg)
        {
            Console.WriteLine();
            Console.WriteLine("다음 할 행동은 무엇입니까?");
            Console.WriteLine($"1. {msg} 2. 돌아가기");
            Console.Write("입력 : ");
        }
    }
}
