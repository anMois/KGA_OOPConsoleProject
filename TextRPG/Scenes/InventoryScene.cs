using TextRPG.GameObjects.Items;

namespace TextRPG.Scenes
{
    public class InventoryScene : Scene
    {
        private enum StateType { None, Select, Confirm }
        private StateType curState;

        private int value;

        private Item item;
        public Item Item { get { return item; } }

        public InventoryScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            curState = StateType.None;
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
            if (curState == StateType.Select)
                SelectItem();
            else if (curState == StateType.Confirm)
                ConfirmItem();
            else
                base.NextPlay("아이템 선택");
        }

        private void SelectItem()
        {
            Console.WriteLine();
            Console.WriteLine("아이템을 선택하십시오. 0 - 돌아가기");
            Console.Write("입력 : ");
        }

        private void ConfirmItem()
        {
            item = game.Player.Inventory.GetItem(value - 1);
            Console.WriteLine();
            Console.WriteLine($" {item.Name}");
            Console.WriteLine("1. 아이템 설명 2. 아이템 사용 3. 돌아가기");
            Console.Write("입력 : ");
        }

        public override void Update()
        {
            if (curState == StateType.Select)
            {
                //아이템 선택
                int.TryParse(base.input, out value);

                if (value > game.Player.Inventory.GetItemCount())
                    return;

                if (value == 0)
                {
                    curState = StateType.None;
                    return;
                }

                curState = StateType.Confirm;
            }
            else if (curState == StateType.Confirm)
            {
                switch (base.input)
                {
                    case "1":
                        ItemDescription();
                        break;
                    case "2":
                        ItemUse();
                        break;
                    case "3":
                        curState = StateType.Select;
                        break;
                    default:
                        return;
                }
            }
            else
            {
                //처음상태
                switch (base.input)
                {
                    case "1":
                        curState = StateType.Select;
                        break;
                    case "2":
                        game.ReturnScene();
                        break;
                    default:
                        return;
                }
            }
        }

        private void ItemDescription()
        {
            if (item is Weapon)
            {
                Console.WriteLine($"무기 이름 : {Item.Name}");
                Console.WriteLine($"무기 착용레벨 : {((Weapon)Item).Level}");
                Console.WriteLine($"무기 공격력 : {((Weapon)Item).AtkDamage}");
            }
            else if (item is Potion)
            {
                Console.WriteLine($"아이템 이름 : {((Potion)item).Name}");
                Console.WriteLine($"아이템 설명 : {((Potion)item).Description}");
                Console.WriteLine($"아이템 효과 : {((Potion)item).Effect}");
            }
            else
            {
                Console.WriteLine($"아이템 이름 : {item.Name}");
                Console.WriteLine($"아이템 설명 : {item.Description}");
            }
            Console.ReadKey();
        }

        private void ItemUse()
        {
            if (!item.Use)
            {
                Console.WriteLine("사용 불가 아이템입니다.");
                Console.ReadKey();
                return;
            }

            if (item is Potion)
            {
                if (game.Player.State.CurHp == game.Player.State.MaxHp)
                {
                    Console.WriteLine("체력이 최대치입니다.");
                    Console.ReadKey();
                    return;
                }

                game.Player.State.CurHp += ((Potion)item).Amount;
                Console.WriteLine($"{((Potion)item).Amount} 회복했습니다.");

                if (game.Player.State.CurHp > game.Player.State.MaxHp)
                    game.Player.State.CurHp = game.Player.State.MaxHp;

                game.Player.Inventory.RemoveItem(item);
                curState = StateType.Select;
            }

            Console.ReadKey();
        }
    }
}
