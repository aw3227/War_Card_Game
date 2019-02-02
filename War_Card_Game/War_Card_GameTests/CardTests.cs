using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class CardTests
    {
        Card testCardTenHearts = new Card(10, "Hearts");
        Card testCardJackHearts = new Card(11, "Hearts");
        Card testCardQueenSpades = new Card(12, "Spades");
        Card testCardKingClubs = new Card(13, "Clubs");
        Card testCardAceDiamonds = new Card(14, "Diamonds");

        [TestMethod()]
        public void CardNameCreateTenTest()
        {
            Assert.AreEqual(testCardTenHearts.CardNameCreate(), "10 of Hearts");
        }

        [TestMethod()]
        public void CardNameCreateJackTest()
        {
            Assert.AreEqual(testCardJackHearts.CardNameCreate(), "Jack of Hearts");
        }

        [TestMethod()]
        public void CardNameCreateQueenTest()
        {
            Assert.AreEqual(testCardQueenSpades.CardNameCreate(), "Queen of Spades");
        }

        [TestMethod()]
        public void CardNameCreateKingTest()
        {
            Assert.AreEqual(testCardKingClubs.CardNameCreate(), "King of Clubs");
        }

        [TestMethod()]
        public void CardNameCreateAceTest()
        {
            Assert.AreEqual(testCardAceDiamonds.CardNameCreate(), "Ace of Diamonds");
        }
    }
}