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
            var millGame = new MillGame();
            Assert.IsFalse(millGame.Set(1, Player.Black));
        }

        [TestMethod]
        public void TestGet()
        {
            var millGame = new MillGame();
            Assert.IsTrue(millGame.Set(1, Player.White));
            Assert.AreEqual(millGame.Get(1), Player.White);
        }

        [TestMethod]
        public void TestIllegalMove()
        {
            var millGame = new MillGame();
            Assert.IsFalse(millGame.Move(1, 2, Player.White));
        }

        [TestMethod]
        public void TestEntireGame()
        {
            var millGame = new MillGame();
            Assert.IsTrue(millGame.Set(5, Player.White));
            Assert.IsTrue(millGame.Set(20, Player.Black));
            Assert.IsTrue(millGame.Set(14, Player.White));
            Assert.IsTrue(millGame.Set(6, Player.Black));
            Assert.IsTrue(millGame.Set(9, Player.White));
            Assert.IsTrue(millGame.Set(8, Player.Black));
            Assert.IsTrue(millGame.Set(13, Player.White));
            Assert.IsTrue(millGame.Set(15, Player.Black));
            Assert.IsTrue(millGame.Set(18, Player.White));
            Assert.IsTrue(millGame.Take(8, Player.White));
            Assert.IsTrue(millGame.Set(8, Player.Black));
            Assert.IsTrue(millGame.Set(3, Player.White));
            Assert.IsTrue(millGame.Set(21, Player.Black));
            Assert.IsTrue(millGame.Set(19, Player.White));
            Assert.IsTrue(millGame.Set(1, Player.Black));
            Assert.IsTrue(millGame.Set(11, Player.White));
            Assert.IsTrue(millGame.Set(4, Player.Black));
            Assert.IsTrue(millGame.Set(23, Player.White));
            Assert.IsTrue(millGame.Set(24, Player.Black));

            Assert.IsFalse(millGame.Set(19, Player.White));
            Assert.IsFalse(millGame.Set(10, Player.Black));

            Assert.IsFalse(millGame.Take(19, Player.Black));

            Assert.IsFalse(millGame.Move(19, 4, Player.White));

            Assert.IsTrue(millGame.Move(18, 17, Player.White));
            Assert.IsTrue(millGame.Move(1, 2, Player.Black));
            Assert.IsTrue(millGame.Move(17, 18, Player.White));
            Assert.IsFalse(millGame.Move(2, 1, Player.Black));
            Assert.IsTrue(millGame.Take(20, Player.White));
            Assert.IsTrue(millGame.Move(21, 20, Player.Black));
            Assert.IsTrue(millGame.Move(18, 17, Player.White));
            Assert.IsTrue(millGame.Move(2, 1, Player.Black));
            Assert.IsTrue(millGame.Move(17, 18, Player.White));
            Assert.IsTrue(millGame.Take(20, Player.White));
            Assert.IsTrue(millGame.Move(1, 2, Player.Black));
            Assert.IsTrue(millGame.Move(19, 20, Player.White));
            Assert.IsTrue(millGame.Move(2, 1, Player.Black));
            Assert.IsTrue(millGame.Move(5, 2, Player.White));
            Assert.IsTrue(millGame.Move(8, 5, Player.Black));
            Assert.IsFalse(millGame.Take(18, Player.Black));
            Assert.IsTrue(millGame.Take(11, Player.Black));
            Assert.IsTrue(millGame.Move(18, 17, Player.White));
            Assert.IsFalse(millGame.Take(5, Player.White));
            Assert.IsTrue(millGame.Take(1, Player.White));
            Assert.IsTrue(millGame.Move(5, 8, Player.Black));
            Assert.IsTrue(millGame.Move(17, 18, Player.White));
            Assert.IsTrue(millGame.Take(8, Player.White));
            Assert.IsTrue(millGame.Move(24, 1, Player.Black));
            Assert.IsTrue(millGame.Move(18, 17, Player.White));
            Assert.IsTrue(millGame.Take(15, Player.White));
            Assert.IsTrue(millGame.Move(6, 19, Player.Black));
            Assert.IsTrue(millGame.Move(17, 18, Player.White));
            Assert.IsTrue(millGame.Take(4, Player.White));
            Assert.AreEqual(millGame.WhiteWins, 1);
        }

        [TestMethod]
        public void TestWinByNoMove()
        {
            var millGame = new MillGame();
            Assert.IsTrue(millGame.Set(2, Player.White));
            Assert.IsTrue(millGame.Set(1, Player.Black));
            Assert.IsTrue(millGame.Set(3, Player.White));
            Assert.IsTrue(millGame.Set(5, Player.Black));
            Assert.IsTrue(millGame.Set(4, Player.White));
            Assert.IsTrue(millGame.Set(11, Player.Black));
            Assert.IsTrue(millGame.Set(6, Player.White));
            Assert.IsTrue(millGame.Set(12, Player.Black));
            Assert.IsTrue(millGame.Set(10, Player.White));
            Assert.IsTrue(millGame.Set(14, Player.Black));
            Assert.IsTrue(millGame.Set(15, Player.White));
            Assert.IsTrue(millGame.Set(18, Player.Black));
            Assert.IsTrue(millGame.Set(19, Player.White));
            Assert.IsTrue(millGame.Set(20, Player.Black));
            Assert.IsTrue(millGame.Set(22, Player.White));
            Assert.IsTrue(millGame.Set(21, Player.Black));
            Assert.IsTrue(millGame.Set(23, Player.White));
            Assert.IsTrue(millGame.Set(24, Player.Black));

            Assert.AreEqual(millGame.BlackWins, 1);

            Assert.IsTrue(millGame.Set(1, Player.White));
            Assert.IsTrue(millGame.Set(2, Player.Black));
            Assert.IsTrue(millGame.Set(5, Player.White));
            Assert.IsTrue(millGame.Set(3, Player.Black));
            Assert.IsTrue(millGame.Set(11, Player.White));
            Assert.IsTrue(millGame.Set(4, Player.Black));
            Assert.IsTrue(millGame.Set(12, Player.White));
            Assert.IsTrue(millGame.Set(6, Player.Black));
            Assert.IsTrue(millGame.Set(14, Player.White));
            Assert.IsTrue(millGame.Set(10, Player.Black));
            Assert.IsTrue(millGame.Set(18, Player.White));
            Assert.IsTrue(millGame.Set(15, Player.Black));
            Assert.IsTrue(millGame.Set(20, Player.White));
            Assert.IsTrue(millGame.Set(19, Player.Black));
            Assert.IsTrue(millGame.Set(21, Player.White));
            Assert.IsTrue(millGame.Set(22, Player.Black));
            Assert.IsTrue(millGame.Set(24, Player.White));
            Assert.IsTrue(millGame.Set(23, Player.Black));

            Assert.IsTrue(millGame.Move(12, 7, Player.White));

            Assert.AreEqual(millGame.WhiteWins, 1);
        }
    }
}