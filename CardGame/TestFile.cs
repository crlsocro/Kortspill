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
            Assert.AreEqual(deck.theDeck[0], card);
        }
    }
}

//Hold over TestClass � bruk sann "tips" greier til � installere test frameworket
//https://docs.microsoft.com/en-us/visualstudio/test/walkthrough-creating-and-running-unit-tests-for-managed-code?view=vs-2019