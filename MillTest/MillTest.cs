using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mill;

namespace MillTest
{
    [TestClass]
    public class MillTest
    {
        [TestMethod]
        public void TestIllegalSet()
        {
            MillGame MillGame = new Mill.MillGame();
            Assert.IsFalse(MillGame.Set(1, Color.black));
        }

        [TestMethod]
        public void TestGet()
        {
            MillGame Mill = new MillGame();
            Assert.IsTrue(Mill.Set(1, Color.white));
            Assert.AreEqual(Mill.Get(1), Color.white);
        }

        [TestMethod]
        public void TestIllegalMove()
        {
            MillGame Mill = new MillGame();
            Assert.IsFalse(Mill.Move(1, 2, Color.white));
        }

        [TestMethod]
        public void TestEntireGame()
        {
            MillGame Mill = new MillGame();
            Assert.IsTrue(Mill.Set(5, Color.white));
            Assert.IsTrue(Mill.Set(20, Color.black));
            Assert.IsTrue(Mill.Set(14, Color.white));
            Assert.IsTrue(Mill.Set(6, Color.black));
            Assert.IsTrue(Mill.Set(9, Color.white));
            Assert.IsTrue(Mill.Set(8, Color.black));
            Assert.IsTrue(Mill.Set(13, Color.white));
            Assert.IsTrue(Mill.Set(15, Color.black));
            Assert.IsTrue(Mill.Set(18, Color.white));
            Assert.IsTrue(Mill.Take(8, Color.white));
            Assert.IsTrue(Mill.Set(8, Color.black));
            Assert.IsTrue(Mill.Set(3, Color.white));
            Assert.IsTrue(Mill.Set(21, Color.black));
            Assert.IsTrue(Mill.Set(19, Color.white));
            Assert.IsTrue(Mill.Set(1, Color.black));
            Assert.IsTrue(Mill.Set(11, Color.white));
            Assert.IsTrue(Mill.Set(4, Color.black));
            Assert.IsTrue(Mill.Set(23, Color.white));
            Assert.IsTrue(Mill.Set(24, Color.black));

            Assert.IsFalse(Mill.Set(19, Color.white));
            Assert.IsFalse(Mill.Set(10, Color.black));

            Assert.IsFalse(Mill.Take(19, Color.black));

            Assert.IsFalse(Mill.Move(19, 4, Color.white));

            Assert.IsTrue(Mill.Move(18, 17, Color.white));
            Assert.IsTrue(Mill.Move(1, 2, Color.black));
            Assert.IsTrue(Mill.Move(17, 18, Color.white));
            Assert.IsFalse(Mill.Move(2, 1, Color.black));
            Assert.IsTrue(Mill.Take(20, Color.white));
            Assert.IsTrue(Mill.Move(21, 20, Color.black));
            Assert.IsTrue(Mill.Move(18, 17, Color.white));
            Assert.IsTrue(Mill.Move(2, 1, Color.black));
            Assert.IsTrue(Mill.Move(17, 18, Color.white));
            Assert.IsTrue(Mill.Take(20, Color.white));
            Assert.IsTrue(Mill.Move(1, 2, Color.black));
            Assert.IsTrue(Mill.Move(19, 20, Color.white));
            Assert.IsTrue(Mill.Move(2, 1, Color.black));
            Assert.IsTrue(Mill.Move(5, 2, Color.white));
            Assert.IsTrue(Mill.Move(8, 5, Color.black));
            Assert.IsFalse(Mill.Take(18, Color.black));
            Assert.IsTrue(Mill.Take(11, Color.black));
            Assert.IsTrue(Mill.Move(18, 17, Color.white));
            Assert.IsFalse(Mill.Take(5, Color.white));
            Assert.IsTrue(Mill.Take(1, Color.white));
            Assert.IsTrue(Mill.Move(5, 8, Color.black));
            Assert.IsTrue(Mill.Move(17, 18, Color.white));
            Assert.IsTrue(Mill.Take(8, Color.white));
            Assert.IsTrue(Mill.Move(24, 1, Color.black));
            Assert.IsTrue(Mill.Move(18, 17, Color.white));
            Assert.IsTrue(Mill.Take(15, Color.white));
            Assert.IsTrue(Mill.Move(6, 19, Color.black));
            Assert.IsTrue(Mill.Move(17, 18, Color.white));
            Assert.IsTrue(Mill.Take(4, Color.white));
            Assert.AreEqual(Mill.WhiteWins, 1);
        }

        [TestMethod]
        public void TestWinByNoMove()
        {
            MillGame Mill = new MillGame();
            Assert.IsTrue(Mill.Set(2, Color.white));
            Assert.IsTrue(Mill.Set(1, Color.black));
            Assert.IsTrue(Mill.Set(3, Color.white));
            Assert.IsTrue(Mill.Set(5, Color.black));
            Assert.IsTrue(Mill.Set(4, Color.white));
            Assert.IsTrue(Mill.Set(11, Color.black));
            Assert.IsTrue(Mill.Set(6, Color.white));
            Assert.IsTrue(Mill.Set(12, Color.black));
            Assert.IsTrue(Mill.Set(10, Color.white));
            Assert.IsTrue(Mill.Set(14, Color.black));
            Assert.IsTrue(Mill.Set(15, Color.white));
            Assert.IsTrue(Mill.Set(18, Color.black));
            Assert.IsTrue(Mill.Set(19, Color.white));
            Assert.IsTrue(Mill.Set(20, Color.black));
            Assert.IsTrue(Mill.Set(22, Color.white));
            Assert.IsTrue(Mill.Set(21, Color.black));
            Assert.IsTrue(Mill.Set(23, Color.white));
            Assert.IsTrue(Mill.Set(24, Color.black));

            Assert.AreEqual(Mill.BlackWins, 1);

            Assert.IsTrue(Mill.Set(1, Color.white));
            Assert.IsTrue(Mill.Set(2, Color.black));
            Assert.IsTrue(Mill.Set(5, Color.white));
            Assert.IsTrue(Mill.Set(3, Color.black));
            Assert.IsTrue(Mill.Set(11, Color.white));
            Assert.IsTrue(Mill.Set(4, Color.black));
            Assert.IsTrue(Mill.Set(12, Color.white));
            Assert.IsTrue(Mill.Set(6, Color.black));
            Assert.IsTrue(Mill.Set(14, Color.white));
            Assert.IsTrue(Mill.Set(10, Color.black));
            Assert.IsTrue(Mill.Set(18, Color.white));
            Assert.IsTrue(Mill.Set(15, Color.black));
            Assert.IsTrue(Mill.Set(20, Color.white));
            Assert.IsTrue(Mill.Set(19, Color.black));
            Assert.IsTrue(Mill.Set(21, Color.white));
            Assert.IsTrue(Mill.Set(22, Color.black));
            Assert.IsTrue(Mill.Set(24, Color.white));
            Assert.IsTrue(Mill.Set(23, Color.black));

            Assert.IsTrue(Mill.Move(12, 7, Color.white));

            Assert.AreEqual(Mill.WhiteWins, 1);
        }
    }
}