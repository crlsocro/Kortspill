using System;
using static Card;

namespace CardGame
{
    class Program
    {
 
 
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

        public void assignPlayers()
        {
            Console.WriteLine("How many total players do you want? (2-4)");
            int amountOfPlayers = Convert.ToInt32(Console.ReadLine());
        }
    }
}
