using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class StateScene : Scene
    {
        private string input;
        public StateScene(Game game) : base(game)
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
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            game.Player.ShowInfo();
            NextPlay();
        }

        private void NextPlay()
        {
            Console.WriteLine();
            Console.WriteLine("다음 할 행동은 무엇입니까?");
            Console.WriteLine("1. 능력치 설명 2. 돌아가기");
            Console.Write("입력 : ");
        }

        public override void Update()
        {
            switch(input)
            {
                case "1":
                    StatDescription();
                    break;
                case "2":
                    game.ReturnScene();
                    break;
                default:
                    return;
            }
        }

        private void StatDescription()
        {
            Console.WriteLine("근력 : '남자는 힘!'");
            Console.WriteLine("민첩 : '행동이 빨라지겠는걸'");
            Console.WriteLine("지력 : '세계의 대한 지식이 늘어나겠어'");
            Console.WriteLine("행운 : '몬스터에서 맞을 확률이 낮아 지는거 아니야?'");
            Console.ReadKey();
        }
    }
}
