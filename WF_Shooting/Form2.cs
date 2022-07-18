using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
    picturebox 1 :  플레이어
    picturebox 2, 3 = 배경 이미지 상, 하
    picturebox 4, 5 = 플레이어 좌, 우 총알
    picturebox 6,7,8,9 = 적 1, 2, 3, 4
    picturebox 10, 11 = 보스, 보스 총알

 */
namespace WF_Shooting
{
    public partial class Form2 : Form
    {
        //================ 참조할 클래스 목록 ==============================================================/
        GameInfo gameManager = GameManager.Instance.gameInfo; // 게임 종합 관리 클래스
        Player playerClass = GameManager.Instance.playerClass; //  플레이어 클래스
        Enemy enemyClass = GameManager.Instance.enemyClass; // 적 클래스
        Bullet bulletClass = GameManager.Instance.bulletClass; // 총알 클래스
        //================ 폼 생성 및 초기화 ==============================================================/
        public Form2()
        {
            InitializeComponent();  
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            InitForm(); // 폼 세팅
            InitBackGround2(); // 배경 세팅
            InitTimer(); // 타이머 세팅
            InitPlayer(); // 플레이어 초기화
            InitBullet(); // 총알 초기화
            ChangeAttackState(false); // 공격 변수 초기화
            RandomInitEnemy(); // 적 생성 초기화
            gameManager.Restart(); // 점수 초기화
        }
        // ==================== 폼 내부 요소 속성 초기화 ==============================================//
        private void InitForm()
        {
            Name = "Shooting Galaxy ver 1.0.2";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
            // ================ 점수 =============================================//
            label1.Text = "SCORE";
            label1.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            label1.ForeColor = Color.LightGoldenrodYellow;
            label1.Location = new Point(10, 20);
            // ================ 점수 값 ============================================//
            label2.Text = Convert.ToString(gameManager.score);
            label2.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            label2.ForeColor = Color.LightGoldenrodYellow;
            label2.TextAlign = ContentAlignment.MiddleRight;
            label2.Location = new Point(200, 20);
            // ================ 목숨 ============================================//
            label3.Text = "LIFE";
            label3.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            label3.ForeColor = Color.LightGoldenrodYellow;
            label3.Location = new Point(330, 20);
            // ================ 목숨 값 ============================================//
            label4.Text = "♥♥♥";
            label4.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label2.TextAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(420, 20);
            // ================ 게임 오버 화면 ============================================//
            label5.Visible = false;
            label5.Text = "GAME OVER";
            label5.Font = new Font("맑은 고딕", 30, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(160, 300);
            // ================ 메인 돌아가기 안내문 ============================================//
            label6.Visible = false;
            label6.Text = "MAIN : R  EXIT : Q";
            label6.Font = new Font("맑은 고딕", 20, FontStyle.Bold);
            label6.ForeColor = Color.LightGoldenrodYellow;
            label6.Location = new Point(160, 400);
            // ================ 조작 키 안내문 ============================================ //
            label7.Text = "MOVE : ARROW    ATTACK : SPACE BAR     MAIN : R    EXIT : Q";
            label7.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
            label7.ForeColor = Color.Gold;
            label7.Location = new Point(70, 640);
            // ================ 각 picture box 위치 초기화 ============================================//
            pictureBox6.Top = 800;
            pictureBox7.Top = 800;
            pictureBox8.Top = 800;
            pictureBox9.Top = 800;
            pictureBox10.Top = 800;
            pictureBox11.Top = 800;
        }
        //================ 배경 이미지 초기화 ==============================================================//
        public void InitBackGround2()
        {
            // ============== 1번 이미지 ============================ //
            BackColor = Color.FromArgb(38, 38, 67);
            pictureBox2.Image = Image.FromFile("Stars.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;
            // ============== 2번 이미지 ============================ //
            pictureBox3.Image = Image.FromFile("Stars.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Location = new Point(0, 700);
            pictureBox3.Width = Width;
            pictureBox3.Height = Height;
        }
        //================ 타이머 초기화 =====================================================================//
        private void InitTimer()
        {
            timer1.Enabled = true;
            timer1.Interval = 1000 / 90;
            timer2.Enabled = true;
            timer2.Interval = 1000 / 90;
            timer3.Enabled = true;
            timer3.Interval = 1000 / 90;
        }
        //================ 플레이어 이미지 속성 초기화 ===================================================== //
        private void InitPlayer() // 플레이어 초기화
        {
            pictureBox1.Image = playerClass.GetPlayerImg();
            pictureBox1.Width = 80;
            pictureBox1.Height = 80;
            pictureBox1.BringToFront();
            pictureBox1.Location = playerClass.GetLocation();
        }
        // ============== 보스 이미지 속성 초기화 =============================================================== //
        public void SpawnBoss()
        {
            pictureBox10.Image = enemyClass.GetBossImg();
            pictureBox10.Width = pictureBox10.Image.Width;
            pictureBox10.Height = pictureBox10.Image.Height;
            pictureBox10.BringToFront();
            pictureBox10.Left = 600 / 2 - pictureBox10.Width / 2;
            pictureBox10.Top = -400;
            gameManager.isDead = false;

            pictureBox11.Image = bulletClass.bossBullet;
            pictureBox11.Width = pictureBox11.Image.Width * 2;
            pictureBox11.Height = pictureBox11.Image.Height * 2;
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.BringToFront();
            pictureBox11.Left = pictureBox10.Left + pictureBox10.Width / 2;
            pictureBox11.Top = pictureBox10.Top + 40;
        }
        //================ 적 이미지 속성 초기화 ==============================================================/
        private void RandomInitEnemy() // 적을 랜덤한 위치에 주기적으로 생성
        {
            Random rnd = new Random();
            int randomPosX;
            int randomPosY;

            pictureBox6.Image = enemyClass.SpawnRandom();
            pictureBox7.Image = enemyClass.SpawnRandom();
            pictureBox8.Image = enemyClass.SpawnRandom();
            pictureBox9.Image = enemyClass.SpawnRandom();

            pictureBox6.Width = pictureBox6.Image.Width;
            pictureBox6.Height = pictureBox6.Image.Height;
            pictureBox6.BringToFront();
            randomPosX = NotSameRandomNumber(0);
            randomPosY = rnd.Next(-300, 0);
            pictureBox6.Left = randomPosX;
            pictureBox6.Top = randomPosY;

            pictureBox7.Width = pictureBox7.Image.Width;
            pictureBox7.Height = pictureBox7.Image.Height;
            pictureBox7.BringToFront();
            randomPosX = NotSameRandomNumber(randomPosX);
            randomPosY = rnd.Next(-300, 0);
            pictureBox7.Left = randomPosX;
            pictureBox7.Top = randomPosY;

            pictureBox8.Width = pictureBox8.Image.Width;
            pictureBox8.Height = pictureBox8.Image.Height;
            pictureBox8.BringToFront();
            randomPosX = NotSameRandomNumber(randomPosX);
            randomPosY = rnd.Next(-300, 0);
            pictureBox8.Left = randomPosX;
            pictureBox8.Top = randomPosY;

            pictureBox9.Width = pictureBox9.Image.Width;
            pictureBox9.Height = pictureBox9.Image.Height;
            pictureBox9.BringToFront();
            // ============== 2000점 이상 몬스터 추가 ============================ //
            if (gameManager.score >= 2000)
            {
                randomPosX = NotSameRandomNumber(randomPosX);
                randomPosY = rnd.Next(-300, 0);
                pictureBox9.Left = randomPosX;
                pictureBox9.Top = randomPosY;
            }
            else pictureBox9.Top = 750;
        }
        //================ 폼에서의 적의 이동 ==============================================================/
        private void EnemyMovement(int speed, bool isBoss) // 적의 이동
        {
            if(isBoss) // ============== 보스전 중이라면 =================================================== //
            {
                if(gameManager.isDead) SpawnBoss();
                if (pictureBox10.Top >= 50) // 보스 등장
                {
                    pictureBox10.Top = 50;
                }
                else pictureBox10.Top += 3;

                pictureBox10.Left += enemyClass.bossSpeed;

                if(pictureBox10.Left <= 70) // 보스 좌우 이동
                {
                    enemyClass.bossSpeed = -enemyClass.bossSpeed; // 좌측 끝이면 방향전환
                }
                else if(pictureBox10.Left >= 450)
                {
                    enemyClass.bossSpeed = -enemyClass.bossSpeed; // 우측 끝이면 방향 전환
                }
                // ======================= 보스의 총알 이동 ================================================= //
                if (pictureBox11.Top >= 750) // 보스 총알 이동
                {
                    pictureBox11.Top = pictureBox10.Top + 40;
                    pictureBox11.Left = pictureBox10.Left + pictureBox10.Width / 2;
                }
                else pictureBox11.Top += 6; // 총알 속도

                // ========== 적들의 이동 단, 보스전이므로 마지막으로 생성된 적들의 최종 움직임을 의미함 ======== //
                if (pictureBox6.Top >= 750)
                {
                    pictureBox6.Top = 750;
                }
                else pictureBox6.Top += speed;

                if (pictureBox7.Top >= 750)
                {
                    pictureBox7.Top = 750;
                }
                else pictureBox7.Top += speed;

                if (pictureBox8.Top >= 750)
                {
                    pictureBox8.Top = 750;
                }
                else pictureBox8.Top += speed;

                if (pictureBox9.Top >= 750)
                {
                    pictureBox9.Top = 750;
                }
                else pictureBox9.Top += speed;
            }
            else // ================ 보스전이 아닐 경우에는 적들 이동 ============================== //
            {
                if (pictureBox6.Top >= 750)
                {
                    pictureBox6.Top = 750;
                }
                else pictureBox6.Top += speed;

                if (pictureBox7.Top >= 750)
                {
                    pictureBox7.Top = 750;
                }
                else pictureBox7.Top += speed;

                if (pictureBox8.Top >= 750)
                {
                    pictureBox8.Top = 750;
                }
                else pictureBox8.Top += speed;

                if (pictureBox9.Top >= 750)
                {
                    pictureBox9.Top = 750;
                }
                else pictureBox9.Top += speed;
                // ======================= 보스전이 아니고 적이 다 죽으면 재 소환 ============================= //
                if (pictureBox6.Top >= 750 && pictureBox7.Top >= 750 && pictureBox8.Top >= 750 && pictureBox9.Top >= 750
                    && isBoss == false)
                {
                    RandomInitEnemy(); // 재소환 위치 초기화
                }
            }
        }
        // ======================================== 타이머 관련 ============================================= //

        // ============================ 배경 & 게임 상황 타이머 ======================================= //
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(gameManager.gameSpeed); // 배경 움직이기
            gameManager.score += 1; // 1 점 씩 시간당 증가
            label2.Text = Convert.ToString(gameManager.score); // 점수 갱신
            gameManager.CheckStage(); // 스테이지 체크
            if (enemyClass.enemySpeed < 20 && gameManager.gameSpeed < 20) // 게임속도, 적 속도가 최대가 아니라면
            {
                enemyClass.enemySpeed = gameManager.stage + 3; // 1000 점 마다 속도 상승
                gameManager.gameSpeed = gameManager.stage + 5; // 최대 20의 속도 밑까지 상승
            }
            // ============================ 목숨에 따른 표기 ======================================= //
            switch (gameManager.life) // 목숨 갱신
            {
                case 1: { label4.Text = "♥"; break; }
                case 2: { label4.Text = "♥♥"; break; }
                case 3: { label4.Text = "♥♥♥"; break; }
                case 0: 
                    {   // 플레이어 사망 시 모든 연산 정지
                        label4.Text = "-";
                        timer1.Stop();
                        timer2.Stop();
                        timer3.Stop();
                        EndGame(); // 종료 화면 호출
                        break; 
                    }
            }
        }
        // ============================ 플레이어 키 입력 타이머 ======================================= //
        private void timer2_Tick(object sender, EventArgs e)
        {
            // ============================ 좌, 우 ======================================= //
            if (playerClass.isRight) // 플레이어 속도 기반 playerClass.GetSpeed() 으로 이동함
            {
                if (pictureBox1.Right < 600)
                    pictureBox1.Location = new Point(pictureBox1.Location.X + playerClass.GetSpeed(), pictureBox1.Location.Y);
            }
            if (playerClass.isLeft)
            {
                if (pictureBox1.Left > 0)
                    pictureBox1.Location = new Point(pictureBox1.Location.X - playerClass.GetSpeed(), pictureBox1.Location.Y);
            }
            // ============================ 상, 하 ======================================= //
            if (playerClass.isUp)
            {
                if (pictureBox1.Top >= 300)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - playerClass.GetSpeed());
            }
            if (playerClass.isDown)
            {
                if (pictureBox1.Bottom <= 650)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + playerClass.GetSpeed());
            }
            // ============================ 공 격 ======================================= //
            if (playerClass.isAttack) // 공격 중이면
            {
                ChangeAttackState(true); // 공격 상태로 변경
            }
        }
        // ============================ 적 움직임 & 충돌 체크 타이머 ======================================= //
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (playerClass.isAttack == false) // 공격 중이 아니면
            {
                BulletReset(); // 총알 리셋
            }
            else
            {
                MoveBullet(20); // 총알 움직임
            }
            EnemyMovement(enemyClass.enemySpeed, gameManager.isBoss); // 적 움직임
            CheckBulletEnemy(); // 총알 충돌 체크
            CheckPlayerEnemy(); // 플레이어 충돌체크
        }
        // ============================ 플레이어 - 적 충돌 체크 ======================================= //
        private void CheckPlayerEnemy()
        {
            if (bulletClass.CheckCollision(pictureBox1, pictureBox6))
            {
                pictureBox6.Top = 750;
                if (gameManager.life > 0) gameManager.DecreaseLife();
            }
            if (bulletClass.CheckCollision(pictureBox1, pictureBox7))
            {
                pictureBox7.Top = 750;
                if (gameManager.life > 0) gameManager.DecreaseLife();
            }
            if (bulletClass.CheckCollision(pictureBox1, pictureBox8))
            {
                pictureBox8.Top = 750;
                if (gameManager.life > 0) gameManager.DecreaseLife();
            }
            if (bulletClass.CheckCollision(pictureBox1, pictureBox9))
            {
                pictureBox9.Top = 750;
                if (gameManager.life > 0) gameManager.DecreaseLife();
            }
            // ============================ 보스 총알과의 충돌 ======================================= //
            if (bulletClass.CheckCollision(pictureBox1, pictureBox11))
            {
                pictureBox11.Top = pictureBox10.Top + 40;
                if (gameManager.life > 0) gameManager.DecreaseLife(); ;
            }
        }
        // ============================ 플레이어의 총알 - 적 충돌 체크 ======================================= //
        private void CheckBulletEnemy()
        {
            // =================== 좌측 총알 ========================================= 우측 총알 =========================== //
            if ((bulletClass.CheckCollision(pictureBox4, pictureBox6) || bulletClass.CheckCollision(pictureBox5, pictureBox6)))
            {
                pictureBox6.Top = 750;
                BulletReset(); // 충돌 시 총알 위치 초기화
                gameManager.GetScore();
            }
            if ((bulletClass.CheckCollision(pictureBox4, pictureBox7) || bulletClass.CheckCollision(pictureBox5, pictureBox7)))
            {
                pictureBox7.Top = 750;
                BulletReset();
                gameManager.GetScore();
            }
            if ((bulletClass.CheckCollision(pictureBox4, pictureBox8) || bulletClass.CheckCollision(pictureBox5, pictureBox8)))
            {
                pictureBox8.Top = 750;
                BulletReset();
                gameManager.GetScore();
            }
            if ((bulletClass.CheckCollision(pictureBox4, pictureBox9) || bulletClass.CheckCollision(pictureBox5, pictureBox9)))
            {
                pictureBox9.Top = 750;
                BulletReset();
                gameManager.GetScore();
            }
            // ====================================== 보스와의 체크 ======================================= //
            if ((bulletClass.CheckCollision(pictureBox4, pictureBox10) || bulletClass.CheckCollision(pictureBox5, pictureBox10)))
            {
                BulletReset();
                enemyClass.bossHP -= 4; // 보스 체력은 4씩 감소
                if(enemyClass.bossHP <= 0) // 보스 체력이 0 이 되면
                {
                    gameManager.isBoss = false;
                    gameManager.isDead = true;
                    pictureBox10.Top = 800; // 보스 위치 초기화
                    pictureBox11.Top = pictureBox10.Top + 40; // 보스 총알 위치 초기화
                    enemyClass.ResetBossHP(); // 보스 체력 초기화
                }
            }
        }
        // ====================================== 배경 이미지 이동 함수 ======================================= //
        private void MoveBackGround(int speed)
        {
            if (pictureBox2.Top >= 700) // 배경 이동
            {
                pictureBox2.Top = -700;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 700)
            {
                pictureBox3.Top = -700;
            }
            else
            {
                pictureBox3.Top += speed;
            }
        }
        // ====================================== 플레이어 키 누름 변수 조작 ======================================= //
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right: // 오른쪽
                    {
                        playerClass.isRight = true;
                        break;
                    }
                case Keys.Left: // 왼쪽
                    {
                        playerClass.isLeft = true;
                        break;
                    }
                case Keys.Up: // 위
                    {
                        playerClass.isUp = true;
                        break;
                    }
                case Keys.Down: // 아래
                    {
                        playerClass.isDown = true;
                        break;
                    }
                case Keys.Space: // 공격
                    {
                        playerClass.isAttack = true;
                        break;
                    }
                case Keys.R:
                    {
                        this.Visible = false;
                        Form1 main = new Form1(); // 메인 로비 폼
                        main.ShowDialog(); // 메인으로 돌아가고
                        this.Close(); // 현재 폼 종료
                        break;
                    }
                case Keys.Q:
                    {
                        Application.Exit(); // 아예 종료
                        break;
                    }
            }
        }
        // ====================================== 플레이어 키 뗌 변수 조작 ======================================= //
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    {
                        playerClass.isRight = false;
                        break;
                    }
                case Keys.Left:
                    {
                        playerClass.isLeft = false;
                        break;
                    }
                case Keys.Up:
                    {
                        playerClass.isUp = false;
                        break;
                    }
                case Keys.Down:
                    {
                        playerClass.isDown = false;
                        break;
                    }
                case Keys.Space:
                    {
                        playerClass.isAttack = false;
                        ChangeAttackState(false); // 공격 키를 떼면 공격중이 아님
                        break;
                    }
            }
        }
        // ====================================== 플레이어 총알 이동 함수 ======================================= //
        private void MoveBullet(int speed) // 총알 이동
        {
            if (pictureBox4.Top <= 40) // 총알이 시야 벗어나면 초기화
            {
                pictureBox4.Top = pictureBox1.Location.Y;
                pictureBox4.Left = pictureBox1.Left + 15;
            }
            else
            {
                pictureBox4.Top -= speed;
            }
            if(pictureBox5.Top <= 40)
            {
                pictureBox5.Top = pictureBox1.Location.Y;
                pictureBox5.Left = pictureBox1.Left + 45;
            }
            else
            {
                pictureBox5.Top -= speed;
            }
        }
        // ====================================== 총알 초기화 함수 ======================================= //
        private void BulletReset()
        {
            pictureBox4.Top = pictureBox1.Location.Y; // 총알 위치 초기화
            pictureBox4.Left = pictureBox1.Left + 15;
            pictureBox5.Top = pictureBox1.Location.Y;
            pictureBox5.Left = pictureBox1.Left + 45;
        }
        private void InitBullet() // 총알 초기화
        {
            pictureBox4.Image = bulletClass.playerBullet;
            pictureBox4.Width = bulletClass.playerBullet.Width;
            pictureBox4.Height = bulletClass.playerBullet.Height;
            pictureBox4.BringToFront();
            pictureBox4.Visible = false;
            pictureBox4.Enabled = false;

            pictureBox5.Image = bulletClass.playerBullet;
            pictureBox5.Width = bulletClass.playerBullet.Width;
            pictureBox5.Height = bulletClass.playerBullet.Height;
            pictureBox5.BringToFront();
            pictureBox5.Visible = false;
            pictureBox5.Enabled = false;

            pictureBox4.Location = new Point(pictureBox1.Location.X + 15, pictureBox1.Location.Y);
            pictureBox5.Location = new Point(pictureBox1.Location.X + 45, pictureBox1.Location.Y);
        }
        // ================================== 공격 상태에 따른 총알 숨김 유무 ======================================= //
        private void ChangeAttackState(bool isTrue) // 공격 상태 변경 시 총알의 활성여부 변경
        {
            pictureBox4.Enabled = isTrue;
            pictureBox4.Visible = isTrue;
            pictureBox5.Enabled = isTrue;
            pictureBox5.Visible = isTrue;
        }
        // ====================================== 적의 가로 위치 난수 생성 ======================================= //
        private int NotSameRandomNumber(int before) // 중복 되지않는 난수 생성 >> 직전 숫자와만 중복 아니면 됨
        {
            Random rnd = new Random();
            int randomPosX;
            randomPosX = rnd.Next(20, 530);

            while (!(randomPosX >= before + 30 || randomPosX <= before - 30)) // 일정 범위 내면 중복으로 처리하고 다시 생성 >> 적끼리 너무 겹쳐서 안보이는 걸 방지
            {
                randomPosX = rnd.Next(20, 530);
            }
            return randomPosX; // 랜덤한 가로 위치 리턴
        }
        // ====================================== 종료 화면 출력 ======================================= //
        private void EndGame() // 게임 종료시 화면 출력
        {
            label5.Visible = true;
            label5.BringToFront();
            label6.Visible = true;
            label6.BringToFront();
        }
    }
}
