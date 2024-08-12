using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Player
    {
        private string name;
        private int gold;
        private State state;
        private Job job;

        public string Name { get { return name; } set { name = value; } }
        public int Gold { get { return gold; } set { gold = value; } }
        public State State { get { return state; } set { state = value; } }
        public Job Job { get { return job; } set { job = value; } }

        public Player()
        {
            name = "모험가";
            gold = 100;
            job = Job.Beginner;
            state = new State();
        }
    }
}
