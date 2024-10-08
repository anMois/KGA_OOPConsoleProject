﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interfaces;

namespace TextRPG.Scenes
{
    public class StateScene : Scene
    {
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
            base.input = Console.ReadLine();
        }

        public override void Render()
        {
            Console.Clear();
            game.Player.ShowInfo();
            base.NextPlay("능력치 설명");
        }

        public override void Update()
        {
            switch(base.input)
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
            Console.WriteLine("근력 : '공격는 힘!' 공격력과 관련이 있다.");
            Console.WriteLine("민첩 : '행동이 빨라지겠는걸' 방어력과 관련이 있다.");
            Console.WriteLine("지력 : '세계의 대한 지식이 늘어나겠어' 마법력과 관력이 있다.");
            Console.WriteLine("행운 : '몬스터에서 맞을 확률이 낮아 지는거 아니야?' 방어력과 관련이 있다.");
            Console.ReadKey();
        }
    }
}
