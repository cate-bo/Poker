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

        public Card(Values _value, Suits _suit)
        {
            value = _value;
            suit = _suit;
        }
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
        public Random rand { get; set; } = new Random();
        public bool Hosting { get; set; }
        public Player Me { get; set; }
        public Player Dealer { get; set; }
        private Player _activePlayer;
        public Player ActivePlayer
        {
            get
            {
                return _activePlayer;
            }
            set
            {
                _activePlayer = value;
                UpdateActivePlayer();
            }
        }
        public TablePage Table {  get; set; }
        public List<Player> Players { get; } = new List<Player>();
        public int Startingchips { get; set; }
        public int Pot { get; set; }
        public int BB { get; set; }
        public HostService Host { get; set; }
        public ClientService Client { get; set; }
        public List<Card> DealtCards { get; set; } = new List<Card>();
        public int CurrentMinBet { get; set; }

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
            if (!Hosting)
            {
                Client = new ClientService();
            }
            else
            {
                Host = new HostService();
            }
            Me = new Player("placeholder", -69696969);
            Table = new TablePage(this);
            Setup();
        }

        public void AddPlayer(string name)
        {
            Player temp = new Player(name, Startingchips);
            Players.Add(temp);
            Table.AddPlayerToTable(temp);
        }

        public void UpdateActivePlayer()
        {
            if (Hosting)
            {

            }
        }

        public void Setup()
        {
            //Me = new Player("placeholder", Startingchips);
            Table.Setup(Hosting);
        }

        public void SubmitHostSetup(string name, string startingChips, string bigBlind)
        {
            BB = int.Parse(bigBlind);
            Startingchips = int.Parse(startingChips);
            AddPlayer(name);
            Me = Players[0];
            Table.CloseSetup();
            Table.ArrangePlayers();
        }

        public void SubmitClientSetup(string name, string ipAndPort)
        {
            if (Client.TryConnect(ipAndPort))
            {
                AddPlayer(name);
            }
        }

        public void Play()
        {
            //starting host as dealer
            ActivePlayer = Me;
            Dealer = ActivePlayer;
            while (!IsGameOver())
            {
                StartRound();
            }
        }

        public void StartRound()
        {
            //set players that are still playing
            foreach(Player player in Players)
            {
                if(player.Chips > 0) player.StillPlaying = true;
            }
            //place blind bets and set player after BB as active
            NextPlayer();
            PlaceBet(BB / 2);
            NextPlayer();
            PlaceBet(BB);
            NextPlayer();

            //deal cards to players
            DealtCards.Clear();
            foreach(Player player in Players)
            {
                player.Card1 = DealNewCard();
                player.Card2 = DealNewCard();
            }

            
            //first round of betting
            BettingRound();
            //flop
            Card1 = DealNewCard();
            Card2 = DealNewCard();
            Card3 = DealNewCard();
            BettingRound();
            //turn
            Card4 = DealNewCard();
            BettingRound();
            //river
            Card5 = DealNewCard();
            BettingRound();
            EndRound();
        }

        public void EndRound()
        {
            //TODO
        }

        public void BettingRound()
        {
            ////TODO
            //if (Hosting)
            //{
            //    if(ActivePlayer == Me)
            //    {

            //    }
            //}
        }

        public void NextPlayer()
        {
            if (Players.IndexOf(ActivePlayer) == Players.Count - 1)
            {
                if(Players[0].StillPlaying) ActivePlayer = Players[0];
            }
            else
            {
                if(Players[Players.IndexOf(ActivePlayer) + 1].StillPlaying) ActivePlayer = Players[Players.IndexOf(ActivePlayer) + 1];
            }

        }

        public Card DealNewCard()
        {
            while (true)
            {
                Card temp = new Card((Values)rand.Next(2, 15), (Suits)rand.Next(0, 4));
                if(!DealtCards.Contains(temp))
                {
                    return temp;
                }
            }
        }

        public bool IsGameOver()
        {
            byte playersStillIn = 0;
            foreach(Player player in Players)
            {
                if(player.Chips > 0)
                {
                    playersStillIn++;
                }
            }
            if (playersStillIn > 1) return false;
            return true;
        }

        public bool PlaceBet(int amount)
        {
            if(amount < CurrentMinBet) return false;
            if(ActivePlayer.Chips < amount)
            {
                ActivePlayer.Bet = ActivePlayer.Chips;
                ActivePlayer.Chips = 0;
            }
            else
            {
                ActivePlayer.Bet = amount;
                ActivePlayer.Chips -= amount;
                if(amount > CurrentMinBet) CurrentMinBet = amount;
            }
            return true;
        }
    }


}
