using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class InventoryScene : Scene
    {
        public InventoryScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
        }

        public override void Exit()
        {
        }

        public override void Input()
        {
            base.input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            game.Player.Inventory.ShowInven();
            NextPlay();
        }

        private void NextPlay()
        {
            Console.WriteLine();
            Console.WriteLine("1. 아이템 설명 2. 아이템 사용 3. 닫기");
            Console.Write("입력 : ");
        }

        public override void Update()
        {
            switch (base.input)
            {
                case "1":
                    SelectItem();
                    break;
                case "2":
                    ItemUse();
                    break;
                case "3":
                    game.ReturnScene();
                    break;
                default:
                    return;
            }
        }

        private void SelectItem()
        {
            
        }

        private void ItemUse()
        {

        }
    }
}
