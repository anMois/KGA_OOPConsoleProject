using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Scenes;

namespace TextRPG
{
    public class GameObject
    {
        public Game game;
        public Scene scene;

        public ConsoleColor color;
        public Point point;
        public char simbol;

        public GameObject(Scene scene)
        {
            this.game = scene.game;
            this.scene = scene;
        }
    }
}
