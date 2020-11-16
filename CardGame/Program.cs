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
        public static Player playerToSkip;
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
            GameLoop();
        }

        public static void dealInitialCards()
        {
            for (int i = 0; i < amountOfCardsForEachPlayer; i++)
            {
                for (int j = 0; j < amountOfPlayers; j++)
                {
                    Card randomCard = SelectARandomCard();
                    players[j].Hand.Add(randomCard);
                    Console.WriteLine(players[j].name + " got: " + randomCard.ToString());
                    deck.theDeck.Remove(randomCard);
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
                List<int> amountOfSuitsInHand = SuitAmounts(players[i]);
                //For loop to cycle thru player cards
                amountOfSuitsInHand.Sort();
                Suit SuitToTest = players[i].Hand[0].suit;
                if (amountOfSuitsInHand[3] == 4)
                {
                    VictoryMessage(players[i]);
                    return true;
                }else if (amountOfSuitsInHand[3] == 3 && players[i].HasJoker)
                {
                    VictoryMessage(players[i]);
                    return true;
                }
            }
            return false;
        }

        public static void GameLoop()
        {
            while (!CheckVictories())
            {
                Player randomPlayer = SelectRandomPlayer();
                Card randomCard = SelectARandomCard();
                randomPlayer.Hand.Add(randomCard);
                if (deck.theDeck.Count > 0)
                {
                    TossCard(randomPlayer);
                    Console.WriteLine(randomPlayer.name + " got: " + randomCard.ToString());
                }
                if (randomCard.specialty != 0)
                {
                    PlayerHasSpecial(randomCard, randomPlayer);
                }

                deck.theDeck.Remove(randomCard);

            }

            Console.WriteLine(deck.theDeck.Count);
        }

        public static void TossCard(Player player)
        {
            List<int> amountOfSuitsInHand = SuitAmounts(player);
            //For loop to cycle thru player cards
            amountOfSuitsInHand.Sort();
            if (player.Hand[0].suit != (Suit)amountOfSuitsInHand[3] && player.Hand[0].specialty != (Specialty)4)
            {
                deck.theDeck.Add(player.Hand[0]);
                Console.WriteLine(player.name + " tossed card: " + player.Hand[0].ToString());
                player.Hand.RemoveAt(0);
            } else if(player.Hand[1].suit != (Suit)amountOfSuitsInHand[3] && player.Hand[1].specialty != (Specialty)4)
            {
                deck.theDeck.Add(player.Hand[1]);
                Console.WriteLine(player.name + " tossed card: " + player.Hand[1].ToString());
                player.Hand.RemoveAt(1);
            } else if (player.Hand[2].suit != (Suit)amountOfSuitsInHand[3] && player.Hand[2].specialty != (Specialty)4)
            {
                deck.theDeck.Add(player.Hand[2]);
                Console.WriteLine(player.name + " tossed card: " + player.Hand[2].ToString());
                player.Hand.RemoveAt(2);
            } else if (player.Hand[3].suit != (Suit)amountOfSuitsInHand[3] && player.Hand[3].specialty != (Specialty)4)
            {
                deck.theDeck.Add(player.Hand[3]);
                Console.WriteLine(player.name + " tossed card: " + player.Hand[3].ToString());
                player.Hand.RemoveAt(3);
            }
        }

        public static void PlayerHasSpecial(Card card, Player player)
        {
            Random rnd = new Random();
            int randomSpecial = rnd.Next(0, 3);
            
                if (card.specialty == (Specialty)1) { Vulture(player); }
                if (card.specialty == (Specialty)2) { Bomb(player); }
                if (card.specialty == (Specialty)3) { Quarantine(player); }
                if (card.specialty == (Specialty)4) { Joker(player); }
           
        }

        public static void Quarantine(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(player.name + " got a Quarantine card and will be skipped next turn!");
            Console.ResetColor();
            playerToSkip = player;
        }

        public static void Bomb(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(player.name + " got a Bomb card and must hand in all his cards!");
            Console.ResetColor();
            for (int i = 0; i < player.Hand.Count; i++)
            {
                Card randomCard = SelectARandomCard();
                player.Hand.Add(randomCard);
                deck.theDeck.Remove(randomCard);
                Console.WriteLine(player.name + " got: " + randomCard.ToString());
                player.Hand.RemoveAt(i);
                deck.theDeck.Add(player.Hand[i]);
                Console.WriteLine(player.name + " tossed: " + player.Hand[i]);
            }
        }

        public static void Vulture(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(player.name + " got a Vulture card and gets an extra card!");
            Console.ResetColor();
            Card randomCard = SelectARandomCard();
            player.Hand.Add(randomCard);
        }

        public static void Joker(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(player.name + " got a Joker card and only needs three equal suits to win!");
            Console.ResetColor();
            player.HasJoker = true;
        }

        public static Player SelectRandomPlayer()
        {
            int randomPlayer = rnd.Next(0, amountOfPlayers);
            if (playerToSkip == players[randomPlayer])
            {
                return SelectRandomPlayer();
            }
            else 
            {
                playerToSkip = null;
                return players[randomPlayer];
            }
        }

        public static Card SelectARandomCard()
        {
            int randomCard = rnd.Next(0, deck.theDeck.Count - 1);
            return deck.theDeck[randomCard];
        }

        //Made this into a function so the code doesn't have to be repeated
        public static void VictoryMessage(Player player)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===============================");
            Console.WriteLine("<<<----- " + player.name.ToUpper() + " WON!! ----->>>");
            Console.WriteLine("===============================");
            Console.ResetColor();
            Console.WriteLine(player.name + "'s hand:");
            for (int i = 0; i < player.Hand.Count; i++)
            {
                if(player.Hand[i].specialty != (Specialty)4)
                {
                    Console.WriteLine(" * " + player.Hand[i].ToString());
                    Console.WriteLine(player.Hand.Count);
                }
                else
                {
                    Console.WriteLine(" * " + player.Hand[i].ToString() + " (Joker)");
                    Console.WriteLine(player.Hand.Count);
                }
            }
        }

        public static List<int> SuitAmounts(Player player)
        {
            List<int> amountOfSuitsInHand = new List<int> { 0, 0, 0, 0 };
            //For loop to cycle thru player cards
            for (int j = 0; j < player.Hand.Count; j++)
            {
                if (player.Hand[j].suit == (Suit)0) { amountOfSuitsInHand[0]++; }
                if (player.Hand[j].suit == (Suit)1) { amountOfSuitsInHand[1]++; }
                if (player.Hand[j].suit == (Suit)2) { amountOfSuitsInHand[2]++; }
                if (player.Hand[j].suit == (Suit)3) { amountOfSuitsInHand[3]++; }
            }
            return amountOfSuitsInHand;
        }
        /*
        * Quarantine card skipping a player is buggy
        * Victory function rarely runs twice
        * Players can toss the same card they just got(allow?)
        * Joker card act as a 3-suit-and-joker-to-win card instead of as a any-color card
        * 
        */
    }
}