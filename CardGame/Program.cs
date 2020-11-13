using System;
using System.Collections.Generic;
using static Card;

namespace CardGame
{
    class Program
    {

        public string[] playerNames = { "Hagen", "Chris", "Hakon", "Ola"};
        public static int amountOfPlayers;
        public static List<Player> players = new List<Player>();
        
        private static Deck deck = new Deck();
        //private static Player player1 = new Player();
        private static Player player2 = new Player();
        private static Player player3 = new Player();
        private static Player player4 = new Player();
        private static int amountOfCardsForEachPlayer = 4;

        static void Main(string[] args)
        {


            AssignPlayers();
            GameStart();
            CheckVictories();
            //Console.WriteLine();

            /* Prints the entire deck
            for (int i = 0; i < deck.theDeck.Count; i++)
            {
                if (deck.theDeck[i].specialty == (Specialty)0)
                {
                    Console.WriteLine(deck.theDeck[i].suit + " " + deck.theDeck[i].rank);
                }
                else
                {
                    Console.WriteLine(deck.theDeck[i].suit + " " + deck.theDeck[i].rank + " " + deck.theDeck[i].specialty);
                }
            }*/
            Console.WriteLine(deck.theDeck.Count);
            /* Prints the entire player hand
            Console.WriteLine(players[0].ToString(players[0].playerHand[0]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[1]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[2]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[3]));
            */

        }



        public static void dealInitialCards()
        {
            for (int i = 0; i < amountOfCardsForEachPlayer; i++)
            {
                for (int j = 0; j < amountOfPlayers; j++)
                {
                    Random rnd = new Random();
                    int randomnum = rnd.Next(0, deck.theDeck.Count);
                    players[j].playerHand.Add(deck.theDeck[randomnum]);
                    Console.WriteLine(players[j].name + ": Got " + deck.theDeck[randomnum].ToString(deck.theDeck[randomnum]));
                    deck.theDeck.RemoveAt(randomnum);
                }
            }
        }

        
        public static void AssignPlayers()
        {
            Console.WriteLine("How many total players do you want? (2-4)");
            amountOfPlayers = Convert.ToInt32(Console.ReadLine());
            //string[] playerAssignments = { "player1", "player2", "player3", "player4" };
            
            //REPLACE WITH FOR LOOP, THIS IS A VERY KRISE LØSNING
            Player player1 = new Player();
            player1.name = "Player1";
            players.Add(player1);
            if (amountOfPlayers >= 2)
            {
                Player player2 = new Player();
                player2.name = "Player2";
                players.Add(player2);
            }
            if (amountOfPlayers >= 3)
            {
                Player player3 = new Player();
                player3.name = "Player3";
                players.Add(player3);
            }
            if (amountOfPlayers >= 4)
            {
                Player player4 = new Player();
                player4.name = "Player4";
                players.Add(player4);
            }
        }

        public static void GameStart()
        {
            deck.createDeck();
            dealInitialCards();
        }

        public static bool CheckVictories()
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                if (players[i].playerHand[0].suit == players[i].playerHand[1].suit & players[i].playerHand[0].suit == players[i].playerHand[2].suit && players[i].playerHand[0].suit == players[i].playerHand[3].suit)
                {
                    Console.WriteLine("someone won");
                    return true;
                }
            }
            Console.WriteLine("nobody won");
            return false;
        }

        void TossCard(Player player)
        {
            List<int> amountOfSuitsInPlayerHand = new List<int>
            {
                0,
                0,
                0,
                0
            };
            //For loop to cycle thru
            for (int j = 0; j < player.playerHand.Count; j++)
            {
                if (player.playerHand[j].suit == (Card.Suit)0){  amountOfSuitsInPlayerHand[0]++; }
                if (player.playerHand[j].suit == (Card.Suit)1) { amountOfSuitsInPlayerHand[1]++; }
                if (player.playerHand[j].suit == (Card.Suit)2) { amountOfSuitsInPlayerHand[2]++; }
                if (player.playerHand[j].suit == (Card.Suit)3) { amountOfSuitsInPlayerHand[3]++; }
            }

            amountOfSuitsInPlayerHand.Sort();
            if (player.playerHand[0].suit != (Card.Suit)amountOfSuitsInPlayerHand[player.playerHand.Count -1])
            {
                //player.playerHand[0].RemoveAt(0);
            }
        }

    }
}

