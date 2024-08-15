using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.GameObjects.Monsters;
using TextRPG.Scenes;

namespace TextRPG.GameObjects.Factorys
{
    public class MonsterFactory
    {
        public static Monster MonsterCreate(Scene scene, string name, MonsterType type)
        {
            if(name == "달팽이" && type == MonsterType.Animal)
            {
                Monster snail = new Monster(scene);
                snail.Name = name;
                snail.MonsterType = type;
                snail.Level = 1;
                snail.HP = 50;
                snail.Exp = 3;
                snail.Gold = 10;
                snail.Atk = 2;
                snail.Def = 1;

                return snail;
            }
            else
            {
                Console.WriteLine("해당 이름과 타입을 가진 몬스터가 없습니다.");
                return null;
            }
            return null;
        }
    }
}
