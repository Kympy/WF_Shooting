using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    internal class Enemy
    {
        private static Image enemyImg1 = Image.FromFile("enemy01.png");
        private static Image enemyImg2 = Image.FromFile("enemy02.png");
        public static int speed = 3;

        public static Image SpawnRandom()
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 3);
            switch (value)
            {
                case 1:
                    {
                        return enemyImg1;
                    }
                case 2:
                    {
                        return enemyImg2;
                    }
                default:
                    {
                        return enemyImg1;
                    }
            }
        }
    }
}
