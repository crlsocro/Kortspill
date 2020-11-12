using System;
using System.Collections.Generic;
using static Card;

namespace CardGame
{
    class Program
    {

        public string[] playerNames = { "Hagen", "Chris", "Håkon", "Ola", "Magnus Carlsen", "John Cena", "AleksiB" };
        public static int amountOfPlayers;
        public static List<Player> players = new List<Player>();
        
        private static Deck deck = new Deck();
        private static Player player1 = new Player();
        private static Player player2 = new Player();
        private static Player player3 = new Player();
        private static Player player4 = new Player();
        private static int amountOfCardsForEachPlayer = 4;

        static void Main(string[] args)
        {


            AssignPlayers();
            GameStart();

            //Console.WriteLine(deck.getDeck());
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
            }
            Console.WriteLine(deck.theDeck.Count);
            Console.WriteLine(players[0].ToString(players[0].playerHand[0]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[1]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[2]));
            Console.WriteLine(players[0].ToString(players[0].playerHand[3]));


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
                    Console.WriteLine(deck.theDeck[randomnum]);
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
            players.Add(player1);
            if (amountOfPlayers >= 2)
            {
                Player player2 = new Player();
                players.Add(player2);
            }
            if (amountOfPlayers >= 3)
            {
                Player player3 = new Player();
                players.Add(player3);
            }
            if (amountOfPlayers >= 4)
            {
                Player player4 = new Player();
                players.Add(player4);
            }
        }

        public static void GameStart()
        {
            deck.createDeck();
            dealInitialCards();
        }

    }
}

