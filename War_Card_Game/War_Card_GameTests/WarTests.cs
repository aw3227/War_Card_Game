using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass()]
    public class WarTests
    {
        string General1String = "name1";
        string General2String = "name2";

        War TestWar = new War("name1", "name2");

        [TestMethod()]
        public void WarInitializeTest()
        {
            
            Assert.AreEqual(TestWar.General1.Name, General1String);
            Assert.AreEqual(TestWar.General2.Name, General2String);
        }

        [TestMethod()]
        public void EndWarTruceTest()
        {
            TestWar.truce = true;
            Assert.IsTrue(TestWar.EndWar());
        }

        [TestMethod()]
        public void EndWarGeneralOneWinsTest()
        {
            TestWar.General2.Cards.Clear();
            Assert.IsTrue(TestWar.EndWar());
        }

        [TestMethod()]
        public void EndWarGeneralTwoWinsTest()
        {
            TestWar.General1.Cards.Clear();
            Assert.IsTrue(TestWar.EndWar());
        }

        [TestMethod()]
        public void EndWarFalseTest()
        {
            Assert.IsFalse(TestWar.EndWar());
        }

        [TestMethod()]
        public void BattleTest()
        {
            Assert.AreEqual(TestWar.General1.Cards.Count + TestWar.General2.Cards.Count, 52);
        }
    }
}