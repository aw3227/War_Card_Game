using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class WarTests
    {
        string general1String = "name1";
        string general2String = "name2";

        War testWar = new War("name1", "name2");

        [TestMethod()]
        public void WarInitializeTest()
        {
            
            Assert.AreEqual(testWar.general1.name, general1String);
            Assert.AreEqual(testWar.general2.name, general2String);
        }

        [TestMethod()]
        public void EndWarTruceTest()
        {
            testWar.truce = true;
            Assert.IsTrue(testWar.EndWar());
        }

        [TestMethod()]
        public void EndWarGeneralOneWinsTest()
        {
            testWar.general2.cards.Clear();
            Assert.IsTrue(testWar.EndWar());
        }

        [TestMethod()]
        public void EndWarGeneralTwoWinsTest()
        {
            testWar.general1.cards.Clear();
            Assert.IsTrue(testWar.EndWar());
        }

        [TestMethod()]
        public void EndWarFalseTest()
        {
            Assert.IsFalse(testWar.EndWar());
        }

        [TestMethod()]
        public void BattleTest()
        {
            Assert.AreEqual(testWar.general1.cards.Count + testWar.general2.cards.Count, 52);
        }
    }
}