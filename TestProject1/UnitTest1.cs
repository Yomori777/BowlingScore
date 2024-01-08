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
            Assert.IsTrue(game.GetFrameScore(0) == 7);
        }
        [TestMethod]
        public void TestSpare()
        {
            var game = new BowlingGame();
            game.Bowl(5);
            game.Bowl(5);
            Assert.IsTrue(game.Score == 10);
            game.Bowl(5);
            Assert.IsTrue(game.GetFrameScore(0) == 15);
            game.Bowl(4);
            Assert.IsTrue(game.GetFrameScore(1) == 9);
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
            Assert.IsTrue(game.GetFrameScore(0) == 19);
            Assert.IsTrue(game.GetFrameScore(1) == 9);
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
        [TestMethod]
        public void TestGetFrameNumber()
        {
            var game = new BowlingGame();
            Assert.IsTrue(game.FrameNumber == 0);
            game.Bowl(5);
            Assert.IsTrue(game.FrameNumber == 0);
            game.Bowl(4);
            Assert.IsTrue(game.FrameNumber == 1);
            game.Bowl(10);
            Assert.IsTrue(game.FrameNumber == 2);
        }
        [TestMethod]
        public void TestFrameState()
        {
            var game = new BowlingGame();
            game.Bowl(5);
            game.Bowl(4);
            Assert.IsTrue(false == game.IsStrike(0));
            Assert.IsTrue(false == game.IsSpare(0));
            game.Bowl(10);
            Assert.IsTrue(true == game.IsStrike(1));
            Assert.IsTrue(false == game.IsSpare(1));
            game.Bowl(5);
            game.Bowl(5);
            Assert.IsTrue(false == game.IsStrike(2));
            Assert.IsTrue(true == game.IsSpare(2));
        }
        [TestMethod]
        public void TestFrameEnd()
        {
            var game = new BowlingGame();
            game.Bowl(5);
            game.Bowl(4);
            for (var i = 0; i < 11; i++)
            {
                Assert.IsTrue(false == game.IsEnd);
                game.Bowl(10);
            }
            Assert.IsTrue(true == game.IsEnd);
        }
        [TestMethod]
        public void TestFrameEnd10s()
        {
            var game = new BowlingGame();
            foreach (var _ in Enumerable.Range(0, 10))
            {
                Assert.IsTrue(false == game.IsEnd);
                game.Bowl(5);
                Assert.IsTrue(false == game.IsEnd);
                game.Bowl(4);
            }
            Assert.IsTrue(true == game.IsEnd);
        }
        [TestMethod]
        public void TestFrameEnd11s()
        {
            var game = new BowlingGame();
            foreach (var _ in Enumerable.Range(0, 9))
            {
                Assert.IsTrue(false == game.IsEnd);
                game.Bowl(5);
                game.Bowl(4);
            }
            Assert.IsTrue(false == game.IsEnd);
            game.Bowl(5);
            game.Bowl(5);
            Assert.IsTrue(false == game.IsEnd);
            game.Bowl(10);
            Assert.IsTrue(true == game.IsEnd);
        }
        [TestMethod]
        public void TestFrameEnd11sStrike()
        {
            var game = new BowlingGame();
            foreach (var _ in Enumerable.Range(0, 9))
            {
                Assert.IsTrue(false == game.IsEnd);
                game.Bowl(5);
                game.Bowl(4);
            }
            Assert.IsTrue(false == game.IsEnd);
            game.Bowl(10);
            Assert.IsTrue(false == game.IsEnd);
            game.Bowl(5);
            Assert.IsTrue(false == game.IsEnd);
            game.Bowl(4);
            Assert.IsTrue(true == game.IsEnd);
        }
    }
}