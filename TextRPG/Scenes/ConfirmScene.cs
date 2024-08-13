using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class ConfirmScene : Scene
    {
        private string input;

        public ConfirmScene(Game game) : base(game)
        {
        }

        public override void Enter()
        {
            game.Player.State.RandomGetStats();
        }

        public override void Exit()
        {
            
        }

        public override void Render()
        {
            Console.WriteLine("캐릭터의 스텟이 정해지는 중입니다...");
            Console.WriteLine("(주사위가 굴러가는 소리...) 데굴... 데굴...\n");
            Thread.Sleep(2000);

            game.Player.ShowInfo();

            Console.WriteLine("해당 플레이어의 데이터 입니다. 플레이 하시겠습니까?");
            Console.WriteLine("Y - 이대로 플레이 / N - 스텟 다시 정하기 / 그 외 - 이름부터 시작");
            Console.Write("입력 : ");
        }

        public override void Input()
        {
            input = Console.ReadLine();
        }

        public override void Update()
        {
            switch (input)
            {
                case "y":
                case "Y":
                    game.ChangeScene(SceneType.Intro);
                    break;
                case "n":
                case "N":
                    Console.Clear();
                    game.ChangeScene(SceneType.Confirm);
                    break;
                default:
                    game.ChangeScene(SceneType.Select);
                    break;
            }
        }
    }
}
