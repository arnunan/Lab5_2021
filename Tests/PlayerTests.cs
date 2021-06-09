using System.Drawing;
using Null_Sector;
using NUnit.Framework;
using User;

namespace Tests
{
    public partial class Tests
    {
        private static Point playerPosition = new Point(Map.Size / 2, Map.Size / 2);

        [SetUp]
        public void PlayerSetUp()
        {
            byte[] p = new byte[SaveFile.ParametersLengthInBytes];
            p[5] = 8;
            UserSettings.File =
                new SaveFile("test", p, Map.GenerateNewMap());
            p = UserSettings.File.ParametersInfo;
            Character.UpdateCharacter(p[0] * 256 + p[1],
                p[2] * 256 + p[3],
                p[4] * 256 + p[5],
                p[6] * 256 + p[7],
                p[8] * 256 + p[9],
                p[10] * 256 + p[11]);
        }

        [Test]
        public void GameOverWhenFoodIsEqualToZero()
        {
            TestMove(Direction.Right);
            TestMove(Direction.Right);
            TestMove(Direction.Up);
            TestMove(Direction.Left);
            TestMove(Direction.Down);
            int expectedX = playerPosition.X;
            int expectedY = playerPosition.Y;
            TestMove(Direction.Right);
            Assert.AreEqual(expectedX, playerPosition.X);
            Assert.AreEqual(expectedY, playerPosition.Y);
        }

        [Test]
        public void MovingInShip()
        {
            TestMove(Direction.Up);
            TestMove(Direction.Left);
            TestMove(Direction.Down);
            TestMove(Direction.Right);
            int expectedX = playerPosition.X;
            int expectedY = playerPosition.Y - 1;
            TestMove(Direction.Up);
            Assert.AreEqual(expectedX, playerPosition.X);
            Assert.AreEqual(expectedY, playerPosition.Y);
        }

        [Test]
        public void TryToMoveBeyondBorder()
        {
            Character.UpdateCharacter(0, 0, 100, 0, 0, 0);
            while (playerPosition.X != Map.Size - 1)
                TestMove(Direction.Right);
            int expectedX = playerPosition.X;
            int expectedY = playerPosition.Y;
            int expectedFood = Character.Food;
            TestMove(Direction.Right);
            Assert.AreEqual(expectedX, playerPosition.X);
            Assert.AreEqual(expectedY, playerPosition.Y);
            Assert.AreEqual(expectedFood, Character.Food);
        }

        private static void TestMove(Direction dir)
        {
            int border;
            int dirSign;

            switch (dir)
            {
                case Direction.Down:
                    border = Map.Size - 1;
                    dirSign = 1;
                    PositionCalculator.CanPlayerMoveVertical(border, dirSign, ref playerPosition);
                    break;
                case Direction.Right:
                    border = Map.Size - 1;
                    dirSign = 1;
                    PositionCalculator.CanPlayerMoveHorizontal(border, dirSign, ref playerPosition);
                    break;
                case Direction.Left:
                    border = 0;
                    dirSign = -1;
                    PositionCalculator.CanPlayerMoveHorizontal(border, dirSign, ref playerPosition);
                    break;
                case Direction.Up:
                    border = 0;
                    dirSign = -1;
                    PositionCalculator.CanPlayerMoveVertical(border, dirSign, ref playerPosition);
                    break;
            }
        }
    }
}
