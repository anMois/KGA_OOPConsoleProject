using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextRPG.Players;

namespace TextRPG.Interfaces
{
    public interface IInteractable
    {
        public void Interaction(Player player);
    }
}
