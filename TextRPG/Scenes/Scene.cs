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
                        game.ChangeScene(SceneType.State);
                        break;
                }

            }
        }
    }
}
