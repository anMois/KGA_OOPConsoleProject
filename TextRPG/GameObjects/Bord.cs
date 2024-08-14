using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Players;
using TextRPG.Scenes;

namespace TextRPG.GameObjects
{
    public class Bord : GameObject
    {
        private bool collider;

        public Bord(Scene scene) : base(scene)
        {
        }

        public override void Interaction(Player player)
        {
            Console.WriteLine("전방에 마을이 있습니다");
            Thread.Sleep(1000);
        }
    }
}
