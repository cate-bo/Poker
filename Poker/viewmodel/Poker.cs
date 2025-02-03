using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.viewmodel
{
    public struct Card
    {
        Values value;
        Suits suit;
    }

    public enum Values
    {
        two = 1,
        three = 2,
        four = 3,
        five = 4,
        six = 5,
        seven = 6,
        eight = 7,
        nine = 8,
        ten = 9,
        jack = 10,
        queen = 11,
        king = 12,
        ace = 13
    }
    public enum Suits
    {
        hearts = 0,
        diamonds = 1,
        clubs = 2,
        spades = 3
    }
    public class Poker
    {
        public List<Player> Players { get; } = new List<Player>();
        public int Pot { get; set; }

        //flop
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
        public Card Card3 { get; set; }

        //turn
        public Card Card4 { get; set; }

        //river
        public Card Card5 { get; set; }
    }
}
