using System;
using System.Collections.Generic;
using static Card;

namespace CardGame
{
    class Program
    {

        public string[] playerNames = { "Hagen", "Chris", "Håkon", "Ola", "Magnus Carlsen", "John Cena", "AleksiB" };
        int amountOfPlayers;
        static List<Player> players = new List<Player>();
        static void Main(string[] args)
        {

            assignPlayers();

            Deck deck = new Deck();
            deck.getDeck();
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

            
        }

        public static void assignPlayers()
        {
            Console.WriteLine("How many total players do you want? (2-4)");
            int amountOfPlayers = Convert.ToInt32(Console.ReadLine());
            string[] playerAssignments = { "player1", "player2", "player3", "player4" };
            //REPLACE WITH FOR LOOP, THIS IS A VERY KRISE LØSNING
            Player player1 = new Player();
            players.Add(player1);
            if (amountOfPlayers >= 2)
            {
                Player player2 = new Player();
            }
            if (amountOfPlayers >= 3)
            {
                Player player3 = new Player();
            }
            if (amountOfPlayers >= 4)
            {
                Player player4 = new Player();
            }
        }
    }
}
