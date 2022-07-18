using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    internal static class Player
    {
        private static int life;
        private static int speed;
        private static int level;
        private static Point location;
        private static Image player1;
        private static Image player2;
        private static Image player3;
        private static Image error = Image.FromFile("error.png");
        public static void InitPlayerInfo()
        {
            life = 3;
            speed = 1;
            level = 1;
            location = new Point(230, 500);

            player1 = ResizeImage(Image.FromFile("player01.png"));
            player2 = ResizeImage(Image.FromFile("player02.png"));
            player3 = ResizeImage(Image.FromFile("player03.png"));
        }
        private static Image ResizeImage(Image original)
        {
            int width = original.Width / 5;
            int height = original.Height / 5;
            Size resize = new Size(width, height);

            Bitmap resizedImg = new Bitmap(original, resize);
            return resizedImg;
        }
        public static Point GetLocation()
        {
            return location;
        }
        public static int GetLife()
        {
            return life;
        }
        public static int GetSpeed()
        {
            return speed;
        }
        public static int GetLevel()
        {
            return level;
        }
        public static void ChangeLevel(int newlevel)
        {
            level = newlevel;
        }
        public static void ChangeLife(int minus)
        {
            life -= minus;
        }
        public static void ChangeSpeed(int newSpeed)
        {
            speed = newSpeed;
        }
        public static Image GetPlayerImg()
        {
            if (level == 1)
            {
                return player1;
            }
            else if (level == 2)
            {
                return player2;
            }
            else if (level == 3)
            {
                return player3;
            }
            else return error;
        }
        public static Point MoveRight()
        {
            Point right = new Point(2, 0);
            return right;
        }
    }
}
