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
        public bool StillPlaying { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                DisplayBox.UpdateName();
            }
        }
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
        private int _chips;
        public int Chips
        {
            get { return _chips; }
            set
            {
                _chips = value;
                DisplayBox.UpdateChipcount();
            }
        }
        public int Bet { get; set; }
        public PlayerGrid DisplayBox { get; set; }

        public Player(string name, int chips)
        {
            DisplayBox = new PlayerGrid(this);
            Name = name;
            Chips = chips;
            DisplayBox.UpdateName();
        }
    }
}
