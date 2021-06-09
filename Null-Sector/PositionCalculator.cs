using System.Drawing;
using User;

namespace Null_Sector
{
    public class PositionCalculator
    {
        public static bool CanPlayerMoveHorizontal(int border, 
            int dirSign, 
            ref Point playerPosition)
        {
            if (playerPosition.X == border || Character.Food <= 0)
            {
                return false;
            }

            DecrementFoodByStep(playerPosition);
            playerPosition.X += dirSign;
            return true;
        }

        public static void CanPlayerMoveVertical(int border, 
            int dirSign, 
            ref Point playerPosition)
        {
            if (playerPosition.Y == border || Character.Food <= 0)
            {
                return;
            }

            DecrementFoodByStep(playerPosition);
            playerPosition.Y += dirSign;
        }

        public static void DecrementFoodByStep(Point playerPosition)
        {
            Character.Food -= IsTile("ShipFloor", playerPosition.X, playerPosition.Y) ? 0 : 2;
        }

        public static bool IsTile(string name, int x, int y) => UserSettings.Map().TileMap[y, x].Name == name;

    }
}
