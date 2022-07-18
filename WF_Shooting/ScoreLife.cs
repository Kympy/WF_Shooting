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

        public static void GetScore() // 점수 획득
        {
            score += 100;
            if (score % 1000 == 0 && GameManager.Instance.enemyClass.enemySpeed < 12 && GameManager.Instance.gameInfo.gameSpeed < 13)
            {
                GameManager.Instance.enemyClass.enemySpeed += 3; // 1000 점 마다 난이도 상승
                GameManager.Instance.gameInfo.gameSpeed += 2; // 최대 3000점까지 상승
            }
        }
        public static void DecreaseLife() // 목숨 감소
        {
            life -= 1;
        }
        public static void Restart()
        {
            score = 0;
            life = 3;
            GameManager.Instance.enemyClass.enemySpeed = 3;
            GameManager.Instance.gameInfo.gameSpeed = 5;
        }
    }
}
