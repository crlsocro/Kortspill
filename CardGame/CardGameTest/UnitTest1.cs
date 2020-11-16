using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
