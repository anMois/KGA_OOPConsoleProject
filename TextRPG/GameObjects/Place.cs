using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Players;
using TextRPG.Scenes;

namespace TextRPG.GameObjects
{
    public class Place : GameObject
    {
        public SceneType type;

        public Place(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            game.ChangeScene(type);
        }
    }
}
