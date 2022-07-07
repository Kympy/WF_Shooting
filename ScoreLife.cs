using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    internal class ScoreLife
    {
        public static int score = 0;
        public static int life = 3;
        public static int stage = 1;
        public static void GetScore() // 점수 획득
        {
            score += 100;
        }
        public static void CheckStage()
        {
            if (score >= 0 && score < 1000)
            {
                stage = 1;
            }
            else if (score >= 1000 && score < 2000)
            {
                stage = 2;
                Form2.isBoss = true;
            }
            else if (score >= 2000 && score < 3000)
            {
                stage = 3;
            }
            else if (score >= 4000 && score < 6000)
            {
                stage = 4;
                Form2.isBoss = true;
            }
            else stage = 5;
        }
        public static void DecreaseLife() // 목숨 감소
        {
            life -= 1;
        }
        public static void Restart()
        {
            score = 0;
            life = 3;
            Enemy.speed = 3;
            Form2.gameSpeed = 5;
        }
    }
}
