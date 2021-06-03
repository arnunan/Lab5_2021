using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameProject
{
    public class Animation
    {
        int staticFramePlayer1 = 1;
        int movingFramePlayer2 = 6;
        int staticFramePlayer2 = 1;
        int attackFramePlayer1 = 19;
        static int attackFramePlayer2 = 5;
        public void PlayStaticAnimationPlayer1(Player player)
        {
            player.Image = Image.FromFile(String.Format("..\\..\\Resources\\Images\\OrangeRobot{0}.png", staticFramePlayer1));
            staticFramePlayer1++;
            if (staticFramePlayer1 == 6)
                staticFramePlayer1 = 1;
        }

        public void PlayMovingAnimationPlayer1(Player player)
        {
            player.Image = Image.FromFile(String.Format("..\\..\\Resources\\Images\\OrangeRobot{0}.png", movingFramePlayer2));
            movingFramePlayer2++;
            if (movingFramePlayer2 == 12)
                movingFramePlayer2 = 6;
        }

        public void PlayAnimationPlayer2(Player player)
        {
            player.Image = Image.FromFile(String.Format("..\\..\\Resources\\Images\\EnemyRobot{0}.png", staticFramePlayer2));
            staticFramePlayer2++;
            if (staticFramePlayer2 == 5)
                staticFramePlayer2 = 1;
        }

        public void PlayAttackAnimationPlayer2(Player player)
        {
            player.Image = Image.FromFile(String.Format("..\\..\\Resources\\Images\\EnemyRobot{0}.png", attackFramePlayer2));
            attackFramePlayer2++;
            if (attackFramePlayer2 == 9)
            {
                attackFramePlayer2 = 5;
                player.IsAttacking = false;
            }

        }

        public void PlayAttackAnimationPlayer1(Player player)
        {
            player.Image = Image.FromFile(String.Format("..\\..\\Resources\\Images\\OrangeRobot{0}.png", attackFramePlayer1));
            attackFramePlayer1++;
            if (attackFramePlayer1 == 28)
            {
                attackFramePlayer1 = 19;
                player.IsAttacking = false;
            }

        }
    }
}
