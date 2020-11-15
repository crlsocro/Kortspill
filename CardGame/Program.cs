using System;
using System.Collections.Generic;
using System.Threading;
using static Card;

namespace CardGame
{
    class Program
    {

        public static int amountOfPlayers;
        public static List<Player> players = new List<Player>();
        public static Random rnd = new Random();
        //public bool quarantine

        private static Deck deck = new Deck();
        private static Player player2 = new Player();
        private static Player player3 = new Player();
        private static Player player4 = new Player();
        private static int amountOfCardsForEachPlayer = 4;

        static void Main(string[] args)
        {
            AssignPlayers();
            GameStart();
            CheckVictories();
            Console.WriteLine(deck.theDeck.Count);
            GameLoop();
            /*
             * BUG: PLAYERHAND HAS 6 CARDS
             * BUG: PLAYERHAND HAS 6 CARDS
             * BUG: PLAYERHAND HAS 6 CARDS
             * BUG: PLAYERHAND HAS 6 CARDS
             * BUG: PLAYERHAND HAS 6 CARDS
             * Getting these cards are not written to console??????
            */

        }

        public static void dealInitialCards()
        {
            for (int i = 0; i < amountOfCardsForEachPlayer; i++)
            {
                for (int j = 0; j < amountOfPlayers; j++)
                {
                    //Random rnd = new Random();
                    Card randomCard = SelectARandomCard();
                    players[j].playerHand.Add(randomCard);
                    Console.WriteLine(players[j].name + " got: " + randomCard.ToString());
                    deck.theDeck.Remove(randomCard);
                    //Thread.Sleep(100);
                }
            }
        }

        
        public static void AssignPlayers()
        {
            Console.WriteLine("How many total players do you want? (2-4)");
            amountOfPlayers = Convert.ToInt32(Console.ReadLine());

            if (amountOfPlayers >= 2)
            {
                Player player1 = new Player { name = "Player1" };
                player1.name = "Player1";
                players.Add(player1);

                Player player2 = new Player { name = "Player2" };
                player2.name = "Player2";
                players.Add(player2);
            }
            if (amountOfPlayers >= 3)
            {
                Player player3 = new Player{ name = "Player3" };

                players.Add(player3);
            }
            if (amountOfPlayers >= 2 && amountOfPlayers < 5)
            {
                Player player4 = new Player{ name = "Player4" };
                players.Add(player4);
            }
            else
            {
                Console.WriteLine("Please input a number between 2 and 4");
                AssignPlayers();
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
                    Console.WriteLine(players[i].name + " won!!");
                    Console.WriteLine(players[i].playerHand[0].ToString());
                    Console.WriteLine(players[i].playerHand[1].ToString());
                    Console.WriteLine(players[i].playerHand[2].ToString());
                    Console.WriteLine(players[i].playerHand[3].ToString());
                    return true;
                }
            }
            //Console.WriteLine("nobody won");
            return false;
        }

        public static void GameLoop()
        {

            while (!CheckVictories())
            {
                Player randomPlayer = SelectRandomPlayer();
                Card randomCard = SelectARandomCard();
                randomPlayer.playerHand.Add(randomCard);
                if (randomCard.specialty != 0)
                {
                    PlayerHasSpecial(randomCard, randomPlayer);
                }
                if (deck.theDeck.Count > 0)
                {
                    Console.WriteLine(randomPlayer.name + " got: " + randomCard.ToString());
                }
                TossCard(randomPlayer);
                deck.theDeck.Remove(randomCard);
                //............SLOW MODE............Simulates irl time
                //Thread.Sleep(500);

            }

            Console.WriteLine(deck.theDeck.Count);
        }

        public static void TossCard(Player player)
        {
            List<int> amountOfSuitsInPlayerHand = new List<int>{0,0,0,0};
            //For loop to cycle thru player cards
            for (int j = 0; j < player.playerHand.Count; j++)
            {
                if (player.playerHand[j].suit == (Suit)0) { amountOfSuitsInPlayerHand[0]++; }
                if (player.playerHand[j].suit == (Suit)1) { amountOfSuitsInPlayerHand[1]++; }
                if (player.playerHand[j].suit == (Suit)2) { amountOfSuitsInPlayerHand[2]++; }
                if (player.playerHand[j].suit == (Suit)3) { amountOfSuitsInPlayerHand[3]++; }
            }

            amountOfSuitsInPlayerHand.Sort();
            if (player.playerHand[0].suit != (Suit)amountOfSuitsInPlayerHand[3])
            {
                deck.theDeck.Add(player.playerHand[0]);
                Console.WriteLine(player.name + " tossed card: " + player.playerHand[0].ToString());
                player.playerHand.RemoveAt(0);
            } else
            {
                Console.WriteLine(player.name + " tossed card: " + player.playerHand[0].ToString());
                deck.theDeck.Add(player.playerHand[1]);
                player.playerHand.RemoveAt(1);
            }
        }

        public static void PlayerHasSpecial(Card card, Player player)
        {
            Random rnd = new Random();
            int randomSpecial = rnd.Next(0, 3);
            
                if (card.specialty == (Specialty)0) { Vulture(player); }
                if (card.specialty == (Specialty)1) { Bomb(player); }
                if (card.specialty == (Specialty)2) { Quarantine(player); }
                if (card.specialty == (Specialty)3) { Joker(player); }
           
        }

        public static void Quarantine(Player player)
        {
            Console.WriteLine(player.name + " got a Quarantine card and will be skipped next turn!");
            player.SkipThisPlayer = true;
        }

        public static void Bomb(Player player)
        {
            Console.WriteLine(player.name + " got a Bomb card and must hand in all his cards!");
            for (int i = 0; i < player.playerHand.Count; i++)
            {
                Card randomCard = SelectARandomCard();
                player.playerHand.RemoveAt(i);
                player.playerHand.Add(randomCard);
                Console.WriteLine(player.name + " got: " + randomCard.ToString());
            }
        }

        public static void Vulture(Player player)
        {
            Console.WriteLine(player.name + " got a Vulture card and gets an extra card!");
            Card randomCard = SelectARandomCard();
            player.playerHand.Add(randomCard);
        }

        public static void Joker(Player player)
        {
            Console.WriteLine(player.name + " got a Joker card and only needs three equal suits to win!");
            player.HasJoker = true;
        }

        public static Player SelectRandomPlayer()
        {
            int randomPlayer = rnd.Next(0, amountOfPlayers);
            if (players[randomPlayer].SkipThisPlayer)
            {
                players[randomPlayer].SkipThisPlayer = false;
                return SelectRandomPlayer();
            }
            else 
            {
                return players[randomPlayer];
            }
        }

        public static Card SelectARandomCard()
        {
            int randomCard = rnd.Next(0, deck.theDeck.Count - 1);
            return deck.theDeck[randomCard];
        }

        //TODO a function to reset all players joker and quarantine bools
        //TODO
    }
}