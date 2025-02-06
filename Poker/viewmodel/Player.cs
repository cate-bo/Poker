using Poker.view;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.viewmodel
{
    public class Player
    {
        public bool IsNPC { get; }
        public string Name { get; set; }
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
        public int Chips { get; set; }
        public int Bet { get; set; }
        public PlayerGrid DisplayBox { get; set; }

        public Player(bool isNPC, string name, int chips)
        {
            IsNPC = isNPC;
            Name = name;
            Chips = chips;
            DisplayBox = new PlayerGrid(this);
        }
    }
}
