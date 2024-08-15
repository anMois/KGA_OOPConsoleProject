using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Interfaces;
using TextRPG.Players;
using TextRPG.Scenes;

namespace TextRPG.GameObjects.Monsters
{
    public class Monster : GameObject, IDamgeable
    {
        private string name;
        private int level;
        private int hp;
        private int attack;
        private int defense;
        private int exp;
        private int gold;
        private MonsterType type;

        public Monster(Scene scene) : base(scene)
        {
            this.name = "연습용 허수아비";
            this.level = 0;
            this.hp = 10;
            this.attack = 0;
            this.defense = 1;
            this.exp = 0;
            this.gold = 0;
            this.type = MonsterType.Intangible;
        }

        public string Name { get { return name; } set { name = value; } }
        public int Level { get { return level; } set { level = value; } }
        public int HP { get { return hp; } set { hp = value; } }
        public int Atk { get { return attack; } set { attack = value; } }
        public int Def { get { return defense; } set { defense = value; } }
        public int Exp { get { return exp; } set { exp = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public MonsterType MonsterType { get { return type; } set { type = value; } }

        public void GetDamage(int damge)
        {
            if(damge > 0)
                Console.WriteLine($"{name}은(는) {damge}의 피해를 입었다.");

            hp -= damge;

            if(hp < 0)
            {
                //base.removeWhenInteract = true;
                Console.WriteLine($"{name} 죽였다.");
                Console.WriteLine($"플레이어는 {exp}경험치와 {gold}를 획득했다.");
            }
            Thread.Sleep(1000);
        }

        public override void Interaction(Player player)
        {
            //나 이녀석이랑 충돌했어 이거 할꺼야
            game.StartBattle(this);
        }
    }
}
