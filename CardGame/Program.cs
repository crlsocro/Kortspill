using System;

namespace CardGame
{
    class Program
    {
        private int amountOfPlayers;

        static void Main(string[] args)
        {
            Console.WriteLine("How many total players do you want? (2-4)");
             int amountOfPlayers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(amountOfPlayers);
        }
    }
}
