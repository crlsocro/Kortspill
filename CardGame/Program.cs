﻿using System;
using System.Collections.Generic;
using System.Threading;
using static Card;

namespace CardGame
{
    class Program
    {

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
                    Console.WriteLine(players[i].name + "won!!");
                    Console.WriteLine(players[i].playerHand[0].ToString(players[i].playerHand[0]));
                    Console.WriteLine(players[i].playerHand[1].ToString(players[i].playerHand[1]));
                    Console.WriteLine(players[i].playerHand[2].ToString(players[i].playerHand[2]));
                    Console.WriteLine(players[i].playerHand[3].ToString(players[i].playerHand[3]));
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
                Random random = new Random();
                int randomPlayer = random.Next(0, amountOfPlayers);
                int randomCard = random.Next(0, deck.theDeck.Count -1);
                players[randomPlayer].playerHand.Add(deck.theDeck[randomCard]);
                if (deck.theDeck[randomCard].specialty != (Card.Specialty)0)
                {
                    PlayerHasSpecial(deck.theDeck[randomCard], players[randomPlayer]);
                }
                if (deck.theDeck.Count > 0)
                {
                    Console.WriteLine(players[randomPlayer].name + ": Got " + deck.theDeck[randomCard].ToString(deck.theDeck[randomCard]));
                }
                TossCard(players[randomPlayer]);
                deck.theDeck.RemoveAt(randomCard);
                //............SLOW MODE............Simulates irl time
                Thread.Sleep(500);

            }

            Console.WriteLine(deck.theDeck.Count);
        }

        public static void TossCard(Player player)
        {
            List<int> amountOfSuitsInPlayerHand = new List<int>{0,0,0,0};
            //For loop to cycle thru player cards
            for (int j = 0; j < player.playerHand.Count; j++)
            {
                if (player.playerHand[j].suit == (Card.Suit)0) { amountOfSuitsInPlayerHand[0]++; }
                if (player.playerHand[j].suit == (Card.Suit)1) { amountOfSuitsInPlayerHand[1]++; }
                if (player.playerHand[j].suit == (Card.Suit)2) { amountOfSuitsInPlayerHand[2]++; }
                if (player.playerHand[j].suit == (Card.Suit)3) { amountOfSuitsInPlayerHand[3]++; }
            }

            amountOfSuitsInPlayerHand.Sort();
            //ERROR HERE
            if (player.playerHand[0].suit != (Card.Suit)amountOfSuitsInPlayerHand[3])
            {
                deck.theDeck.Add(player.playerHand[0]);
                player.playerHand.RemoveAt(0);
            } else
            {
                deck.theDeck.Add(player.playerHand[1]);
                player.playerHand.RemoveAt(1);
            }
        }

        public static void PlayerHasSpecial(Card card, Player player)
        {
            for (int i = 1; i < 3; i++)
            {
                if (card.specialty == (Card.Specialty)i) { Vulture(player); }
                if (card.specialty == (Card.Specialty)i) { Bomb(player); }
                if (card.specialty == (Card.Specialty)i) { Quarantine(player); }
                if (card.specialty == (Card.Specialty)i) { Joker(player); }
            }
        }

        public static void Quarantine(Player player)
        {
            player.SkipThisPlayer = true;
        }

        public static void Bomb(Player player)
        {
            for (int i = 0; i < player.playerHand.Count; i++)
            {
                player.playerHand.RemoveAt(i);
                Random random = new Random();
                int randomCard = random.Next(0, deck.theDeck.Count - 1);
                player.playerHand.Add(deck.theDeck[randomCard]);
            }
        }

        public static void Vulture(Player player)
        {
            Random random = new Random();
            int randomCard = random.Next(0, deck.theDeck.Count - 1);
            player.playerHand.Add(deck.theDeck[randomCard]);
        }

        public static void Joker(Player player)
        {
            player.HasJoker = true;
        }

        //TODO a function to reset all players joker and quarantine bools
    }
}