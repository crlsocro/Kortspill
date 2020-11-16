using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGame
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void TestIfDeckIsCreatedCorrectly()
        {
            Deck deck = new Deck();
            deck.createDeck();

            Card card = new Card((Card.Suit)0, (Card.Rank)0, (Card.Specialty)0);
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}