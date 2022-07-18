using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    public class Enemy
    {
        private Image enemyImg1; // 적 1 이미지
        private Image enemyImg2; // 적 2 이미지
        private Image bossImg; // 보스 이미지

        public int bossHP; // 보스의 체력
        public int enemySpeed = 3; // 적 이동속도
        public int bossSpeed = 3; // 보스 이동속도


        public Enemy()
        {
            bossHP = 100;
            GetBossImg();
        }
        // =================================== 보스 이미지 가져오기 ============================ //
        public Image GetBossImg() 
        {
            bossImg = Image.FromFile("boss01.png");
            return bossImg;
            
            if (GameManager.Instance.gameInfo.stage == 2) // 2스테이지 라면
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
        // =================================== 적 랜덤 이미지 가져오기 ============================ //
        public Image SpawnRandom() // 랜덤한 이미지 생성
        {
            Random rnd = new Random(); // 랜덤 클래스
            int value = rnd.Next(1, 3); // 1 ~ 2 까지 랜덤
            switch (value)
            {
                case 1:
                    {
                        enemyImg1 = Image.FromFile("enemy01.png");
                        return enemyImg1;
                    }
                case 2:
                    {
                        enemyImg2 = Image.FromFile("enemy02.png");
                        return enemyImg2;
                    }
                default: // 만약 오류 발생 시 1번 이미지
                    {
                        enemyImg1 = Image.FromFile("enemy01.png");
                        return enemyImg1;
                    }
            }
        }
        // =================================== 보스 체력 초기화 ============================ //
        public void ResetBossHP()
        {
            bossHP = 100;
        }
    }
}
