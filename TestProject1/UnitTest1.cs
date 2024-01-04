using Bowling;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFirst()
        {
            var game = new BowlingGame();
            game.Bowl(2);
            Assert.IsTrue(game.Score == 2);
        }
        [TestMethod]
        public void TestSecond()
        {
            var game = new BowlingGame();
            game.Bowl(2);
            game.Bowl(5);
            Assert.IsTrue(game.Score == 7);
            Assert.IsTrue(game.GetFrameScore(1) == 7);
        }
        [TestMethod]
        public void TestSpare()
        {
            var game = new BowlingGame();
            game.Bowl(5);
            game.Bowl(5);
            Assert.IsTrue(game.Score == 10);
            game.Bowl(5);
            Assert.IsTrue(game.GetFrameScore(1) == 15);
            game.Bowl(4);
            Assert.IsTrue(game.GetFrameScore(2) == 9);
            Assert.IsTrue(game.Score == 24);
        }
        [TestMethod]
        public void TestStlike()
        {
            var game = new BowlingGame();
            game.Bowl(10);
            Assert.IsTrue(game.Score == 10);
            game.Bowl(5);
            game.Bowl(4);
            Assert.IsTrue(game.GetFrameScore(1) == 19);
            Assert.IsTrue(game.GetFrameScore(2) == 9);
            Assert.IsTrue(game.Score == 28);
        }
        [TestMethod]
        public void TestPerfect()
        {
            var game = new BowlingGame();
            for (var i = 0; i < 12; i++)
            {
                game.Bowl(10);
            }
            Assert.IsTrue(game.Score == 300);
        }
    }
}