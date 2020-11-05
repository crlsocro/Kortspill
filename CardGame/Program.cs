using System;
using static Card;

namespace CardGame
{
    class Program
    {
        private int amountOfPlayers;
        Card card;

        static void Main(string[] args)
        {
            Deck deck = new Deck();
            deck.getDeck();
            //Console.WriteLine(deck.getDeck());
            for (int i = 0; i < deck.theDeck.Count; i++)
            {
                Console.WriteLine(deck.theDeck[i].suit);
            }
            Console.WriteLine(deck.theDeck.Count);

            /*Console.WriteLine("How many total players do you want? (2-4)");
             int amountOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(amountOfPlayers);*/
        }
    }
}
