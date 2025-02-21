using Poker.view;
using Poker.viewmodel.networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Poker.viewmodel
{
    public struct Card
    {
        public Values value;
        public Suits suit;

        public Card(Values _value, Suits _suit)
        {
            value = _value;
            suit = _suit;
        }

        public override string ToString()
        {
            return (int)value + "_" + (int)suit;
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
        public Player OtherPlayer { get; set; }
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
                Client = new ClientService(this);
            }
            else
            {
                Host = new HostService(this);
            }
            //Me = new Player("placeholder", -69696969);
            Table = new TablePage(this);
            Setup();
        }

        public void AddPlayer(string name)
        {
            Player temp = new Player(name, Startingchips);
            OtherPlayer = temp;
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
            Me = new Player(name, Startingchips);
            Table.AddPlayerToTable(Me);
            Table.CloseSetup();
            Table.ArrangePlayers();
        }

        public void SubmitClientSetup(string name, string ipAndPort)
        {
            if (Client.TryConnect(ipAndPort))
            {
                Client.TryJoin(name);
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
            
            if(Me.Chips > 0) Me.StillPlaying = true;
            if (OtherPlayer.Chips > 0) OtherPlayer.StillPlaying = true;
            
            //place blind bets and set player after BB as active
            NextPlayer();
            PlaceBet(BB / 2);
            NextPlayer();
            PlaceBet(BB);
            NextPlayer();

            //deal cards to players
            DealtCards.Clear();
            
            Me.Card1 = DealNewCard();
            Me.Card2 = DealNewCard();

            OtherPlayer.Card1 = DealNewCard();
            OtherPlayer.Card2 = DealNewCard();

            Me.DisplayBox.DisplayCards(true);
            OtherPlayer.DisplayBox.DisplayCards(false);
            Host.Sendmessage("5" + OtherPlayer.Card1.ToString() + ";" + OtherPlayer.Card2.ToString());

            
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
            //TODO
            
        }

        public void SubmitBet(int amount)
        {
            if (amount < 1) return;
            Client.Sendmessage("2" +  amount);
        }

        public void NextPlayer()
        {
            if(ActivePlayer == Me)
            {
                ActivePlayer = OtherPlayer;
            }
            else
            {
                ActivePlayer = Me;
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
            if(Me.Chips > 0 && OtherPlayer.Chips > 0) return false;
            return true;
        }

        public void GetBetFromClient(string bet)
        {

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

        public void JoinAttemt(string name)
        {
            
                if(Me.Name == name)
                {
                    Host.Sendmessage( "2");
                    return;
                }
            
            AddPlayer(name);
            Host.Sendmessage("1" + Startingchips + ";" + name + ";" + Me.Name);
            Play();
        }

        public void JoinSuccess(string response)
        {
            string[] temp = response.Split(';');
            string name = temp[1];
            Startingchips = int.Parse(temp[0]);

            OtherPlayer = new Player(temp[2],Startingchips);
            Me = new Player(name, Startingchips);

            //Me = new Player(response, 69);

            Table.AddPlayerToTable(Me);
            Table.AddPlayerToTable(OtherPlayer);
            Table.CloseSetup();
        }

        public void GetCardsFromHost(string messageContent)
        {
            string[] temp = messageContent.Split(";");
            string[] card1 = temp[0].Split("_");
            string[] card2 = temp[1].Split("_");
            Me.Card1 = new Card((Values)int.Parse(card1[0]),(Suits)int.Parse(card1[1]));
            Me.Card2 = new Card((Values)int.Parse(card2[0]),(Suits)int.Parse(card2[1]));

            Me.DisplayBox.DisplayCards(true);
            OtherPlayer.DisplayBox.DisplayCards(false);
        }
    }


}
