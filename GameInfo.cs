using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    public class GameInfo
    {
        public int score = 0; // 점수
        public int life = 3; // 목숨
        public int stage = 1; // 현재 스테이지
        public bool isBoss = false; // 보스 전 인지 확인
        public bool isDead = true; // 보스 사망여부 // 보스가 살아있다면 보스가 계속 생성되지 않게 제어
        public int gameSpeed = 5; // 게임 속도

        // =================================== 점수 획득 ============================ //
        public void GetScore() // 점수 획득
        {
            score += 100;
        }
        // =================================== 스테이지 조작 ============================ //
        public void CheckStage()
        {
            if (score >= 0 && score < 1000)
            {
                stage = 1;
            }
            else if (score >= 1000 && score < 2000)
            {
                stage = 2;
                isBoss = true;
            }
            else if (score >= 2000 && score < 3000)
            {
                stage = 3;
            }
            else if (score >= 4000 && score < 6000)
            {
                stage = 4;
                isBoss = true;
            }
            else stage = 5;
        }
        // =================================== 플레이어 목숨 조작 ============================ //
        public void DecreaseLife() // 목숨 감소
        {
            life -= 1;
        }
        // =================================== 재시작을 위한 초기화 ============================ //
        public void Restart()
        {
            score = 0;
            life = 3;
            GameManager.Instance.enemyClass.enemySpeed = 3;
            gameSpeed = 5;
            stage = 1;
            isBoss = false;
            isDead = true;
        }
    }
}
