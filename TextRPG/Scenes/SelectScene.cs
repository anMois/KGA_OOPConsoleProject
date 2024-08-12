﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.Scenes
{
    public class SelectScene : Scene
    {
        private string input;

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
            input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            Console.Write("캐릭터 이름을 정하시오. : ");
        }

        public override void Update()
        {
            if (input == string.Empty)
                return;

            game.ChangeScene(SceneType.Confirm);
        }
    }
}
