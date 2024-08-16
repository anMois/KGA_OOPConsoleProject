using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Factorys;
using TextRPG.GameObjects.Items;

namespace TextRPG.Scenes
{
    public class StoreScene : Scene
    {
        private enum StateType { None, Buy, Sell}
        private StateType curType;

        private List<Item> storeItems;

        public StoreScene(Game game) : base(game)
        {
            storeItems = new List<Item>();

            Item redPotion = ItemFactory.PotionCreate("빨간포션");
            Item whitePotion = ItemFactory.PotionCreate("하얀포션");
            storeItems.Add(redPotion);
            storeItems.Add(whitePotion);
        }

        public override void Enter()
        {
            curType = StateType.None;
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

            if (curType == StateType.Buy)
                PrintStoreItemList();
            else if (curType == StateType.Sell)
                PrintPlayerItemList();
            else
                PrintStoreMenu();
        }

        private void PrintPlayerItemList()
        {
            Console.WriteLine("=======Store=======");

            game.Player.Inventory.ShowInven();

            Console.WriteLine("===================");
            Console.WriteLine();
            Console.WriteLine("판매할 아이템 번호 0 - 돌아가기");
            Console.Write("입력 : ");
        }

        private void PrintStoreItemList()
        {
            Console.WriteLine("=======Store=======");

            for (int i = 0; i < storeItems.Count; i++)
            {
                Console.WriteLine($" {i + 1}. {storeItems[i].Name}");
            }

            Console.WriteLine("===================");
            Console.WriteLine();
            Console.WriteLine("구매할 아이템 번호 0 - 돌아가기");
            Console.Write("입력 : ");
        }

        private void PrintStoreMenu()
        {
            Console.WriteLine("=======Store=======");
            Console.WriteLine(" 1. 구매하기");
            Console.WriteLine(" 2. 판매하기");
            Console.WriteLine(" 3. 나가기");
            Console.WriteLine("===================");
            Console.WriteLine();
            Console.Write("입력 : ");
        }

        public override void Update()
        {
            if (curType == StateType.Buy)
            { }
            else if (curType == StateType.Sell)
            { }
            else
            {
                switch (base.input)
                {
                    case "1":
                        curType = StateType.Buy;
                        break;
                    case "2":
                        curType = StateType.Sell;
                        break;
                    case "3":
                        game.ReturnScene();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
