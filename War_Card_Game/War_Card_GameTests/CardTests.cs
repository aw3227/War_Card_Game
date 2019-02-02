using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class CardTests
    {
        Card TestCardTenHearts = new Card(10, "Hearts");
        Card TestCardJackHearts = new Card(11, "Hearts");
        Card TestCardQueenSpades = new Card(12, "Spades");
        Card TestCardKingClubs = new Card(13, "Clubs");
        Card TestCardAceDiamonds = new Card(14, "Diamonds");

        [TestMethod()]
        public void CardNameCreateTenTest()
        {
            Assert.AreEqual(TestCardTenHearts.CardNameCreate(), "10 of Hearts");
        }

        [TestMethod()]
        public void CardNameCreateJackTest()
        {
            Assert.AreEqual(TestCardJackHearts.CardNameCreate(), "Jack of Hearts");
        }

        [TestMethod()]
        public void CardNameCreateQueenTest()
        {
            Assert.AreEqual(TestCardQueenSpades.CardNameCreate(), "Queen of Spades");
        }

        [TestMethod()]
        public void CardNameCreateKingTest()
        {
            Assert.AreEqual(TestCardKingClubs.CardNameCreate(), "King of Clubs");
        }

        [TestMethod()]
        public void CardNameCreateAceTest()
        {
            Assert.AreEqual(TestCardAceDiamonds.CardNameCreate(), "Ace of Diamonds");
        }
    }
}