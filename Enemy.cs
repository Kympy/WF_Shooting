using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    internal class Enemy
    {
        private static Image enemyImg1 = Image.FromFile("enemy01.png"); // 적 1 이미지
        private static Image enemyImg2 = Image.FromFile("enemy02.png"); // 적 2 이미지
        private static Image bossImg = Image.FromFile("boss01.png");
        public static int speed = 3;
        public static int bossHP = 100;
        public static Image GetBossImg() // 보스 이미지 가져오기
        {
            if(ScoreLife.stage == 2) // 2스테이지 라면
            {
                bossImg = Image.FromFile("boss01.png");
                return bossImg;
            }
            else
            {
                bossImg = Image.FromFile("boss02.png");
                return bossImg;
            }
        }
        public static Image SpawnRandom() // 랜덤한 이미지 생성
        {
            Random rnd = new Random();
            int value = rnd.Next(1, 3); // 1 ~ 2 까지 랜덤
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
                default: // 만약 오류 발생 시 1번 이미지
                    {
                        return enemyImg1;
                    }
            }
        }
    }
}
