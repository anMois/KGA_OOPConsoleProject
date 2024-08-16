using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG.GameObjects.Items
{
    public class Potion : Item
    {
        string effect;
        int amount;

        public string Effect { get { return effect; } set { effect = value; } }
        public int Amount { get { return amount; } set { amount = value; } }

        public Potion()
        {
            base.Name = "회복 포션";
            base.Description = "둥그런 유리병에 담겨있는 약초로 만든 물약";
            base.Use = true;
            effect = "사용 시 일정의 체력을 회복한다.";
            amount = 3;
        }
    }
}
