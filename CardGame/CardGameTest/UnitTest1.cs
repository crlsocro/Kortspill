using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CardGame;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CardGameTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestIfDeckIsCreatedCorrectly()
        {
            Deck deck = new Deck();
            deck.createDeck();

            Card card = new Card((Card.Suit)0, (Card.Rank)0, (Card.Specialty)0);
            Assert.AreEqual(deck.theDeck[0], card);
        }

        [TestMethod]
        public void TestIfTossingRightCard()
        {
            Card c1 = new Card(Card.Suit.Clubs, Card.Rank.Ace, Card.Specialty.None);
            Card c2 = new Card(Card.Suit.Diamonds, Card.Rank.Two, Card.Specialty.None);
            Card c3 = new Card(Card.Suit.Clubs, Card.Rank.Three, Card.Specialty.None);
            Card c4 = new Card(Card.Suit.Clubs, Card.Rank.Four, Card.Specialty.None);

            Player player = new Player();
            player.Hand.Add(c1);
            player.Hand.Add(c2);
            player.Hand.Add(c3);
            player.Hand.Add(c4);

            Assert.AreEqual(deck.theDeck[0], card);
        }
    }
}
