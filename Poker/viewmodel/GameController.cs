using Poker.view;
using Poker.viewmodel.networking;
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
        two = 2,
        three = 3,
        four = 4,
        five = 5,
        six = 6,
        seven = 7,
        eight = 8,
        nine = 9,
        ten = 10,
        jack = 11,
        queen = 12,
        king = 13,
        ace = 14
    }
    public enum Suits
    {
        hearts = 0,
        diamonds = 1,
        clubs = 2,
        spades = 3
    }
    public class GameController
    {
        public bool Hosting { get; set; }
        public Player Me { get; set; }
        public Player Dealer { get; set; }
        public TablePage Table {  get; set; }
        public List<Player> Players { get; } = new List<Player>();
        public int Startingchips { get; set; }
        public int Pot { get; set; }
        public int BB { get; set; }
        public HostService Host { get; set; }
        public ClientService Client { get; set; }

        //flop
        public Card Card1 { get; set; }
        public Card Card2 { get; set; }
        public Card Card3 { get; set; }

        //turn
        public Card Card4 { get; set; }

        //river
        public Card Card5 { get; set; }

        public GameController(bool hosting)
        {
            Hosting = hosting;
            Table = new TablePage(this);
            Setup();
            if (!Hosting)
            {
                Client = new ClientService();
            }
        }

        public void AddPlayer(string name)
        {
            Player temp = new Player(name, Startingchips);
            if (Me != null)
            {
                Me = temp;
            }
                Players.Add(temp);
                Table.AddPlayerToTable(temp);
        }

        public void Setup()
        {
            //Me = new Player("placeholder", Startingchips);
            Table.Setup(Hosting);
        }

        public void SubmitSetup(string name, string startingChips, string bigBlind)
        {
            BB = int.Parse(bigBlind);
            Startingchips = int.Parse(startingChips);
            if (Hosting)
            {
                AddPlayer(name);
            }

            Table.CloseSetup();
        }
    }


}
