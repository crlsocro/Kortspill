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

            Card card = ;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
    }
}