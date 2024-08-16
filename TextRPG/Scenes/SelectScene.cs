using TextRPG.Players;

namespace TextRPG.Scenes
{
    public class SelectScene : Scene
    {
        public SelectScene(Game game) : base(game)
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
            Console.Write("캐릭터 이름을 정하시오. : ");
        }

        public override void Update()
        {
            if (base.input == string.Empty)
                return;

            game.Player = new Player(input);
            game.ChangeScene(SceneType.Confirm);
        }
    }
}
