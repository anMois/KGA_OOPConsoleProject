using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Factorys;
using TextRPG.GameObjects.Items;

namespace TextRPG.Scenes
{
    public class IntroScene : Scene
    {
        public IntroScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
            Item sword = ItemFactory.WeaponCreate("검");
            Item potion = ItemFactory.PotionCreate("");
            game.Player.Weapon = (Weapon)sword;
            game.Player.Inventory.AddItem(sword);
            game.Player.Inventory.AddItem(potion);
        }

        public override void Input()
        {
            Console.Write("\n 계속하려면 아무키나 누르세요.");
            Console.ReadKey();
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("당신은 거대한 단풍나무 아래에서 눈이 떠졌습니다.");
            Console.WriteLine("단풍나무는 거대한 언덕 위에 있었습니다.");
            Console.WriteLine("눈이 떠진 당신은 일어나서 주위를 둘러봅니다.");
            Console.WriteLine("주위를 둘러보니 멀리 마을 하나가 보입니다.");
            Console.WriteLine("확인한 당신은 나무에 걸쳐있는 무기를 챙깁니다.");
            Console.WriteLine("당신은 언덕에서 내려와 아까 보였던 마을을 향해 걸어갑니다.");
            Console.WriteLine("─────────────────────────────────────────────────────────");
            Thread.Sleep(1000);
        }

        public override void Update()
        {
            game.ChangeScene(SceneType.Street);
        }
    }
}
