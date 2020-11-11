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
        private static Player player1;
        private static Player player2;
        private static Player player3;
        private static Player player4;

        static void Main(string[] args)
        {


            AssignPlayers();
            GameStart();
            deck.createDeck();


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
            Console.WriteLine(player1.Hand[0].suit);
            Console.WriteLine(player1.Hand[0].rank);


        }



        public static void dealInitialCards()
        {
            for (int i = 0; i < amountOfPlayers; i++)
            {
                Random rnd = new Random();
                int randomnum = rnd.Next();
                player1.Hand.Add(deck.theDeck[randomnum]);
                player2.Hand.Add(deck.theDeck[randomnum]);
                player3.Hand.Add(deck.theDeck[randomnum]);
                player4.Hand.Add(deck.theDeck[randomnum]);
                //Card card = new
                //Deck.theDeck[rnd];
                //players[i].Hand.Add();
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

