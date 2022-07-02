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
    picturebox 1 = player
    picturebox 2,3 = background;
    picturebox 4, 5 = playerbullet;
    picturebox 6,7,8 = enemy;
 */
namespace WF_Shooting
{
    public partial class Form2 : Form
    {
        // 조작 변수
        bool isRight = false;
        bool isLeft = false;
        bool isUp = false;
        bool isDown = false;
        bool isAttack = false;
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            InitForm2();
            InitBackGround2();
            InitTimer();
            InitPlayer();
            InitBullet();
            ChangeAttackState(false);
            RandomInitEnemy();
        }
        private void InitForm2()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void InitPlayer()
        {
            Player.InitPlayerInfo();
            pictureBox1.Image = Player.GetPlayerImg();
            pictureBox1.Width = 80;
            pictureBox1.Height = 80;
            pictureBox1.BringToFront();
            pictureBox1.Location = Player.GetLocation();
        }
        private void RandomInitEnemy()
        {
            Random rnd = new Random();
            int randomPosX;
            int randomPosY;
            
            pictureBox6.Image = Enemy.SpawnRandom();
            pictureBox7.Image = Enemy.SpawnRandom();
            pictureBox8.Image = Enemy.SpawnRandom();

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
        }
        private void EnemyAI(int speed)
        {
            if(pictureBox6.Top >= 750)
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

            if(pictureBox6.Top >= 750 && pictureBox7.Top >= 750 && pictureBox8.Top >= 750)
            {
                RandomInitEnemy();
            }
        }
        public void InitBackGround2()
        {
            BackColor = Color.FromArgb(38, 38, 67);
            pictureBox2.Image = Image.FromFile("Stars.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;

            pictureBox3.Image = Image.FromFile("Stars.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Location = new Point(0, 700);
            pictureBox3.Width = Width;
            pictureBox3.Height = Height;
        }
        private void InitTimer()
        {
            timer1.Enabled = true;
            timer1.Interval = 1000 / 90;
            timer2.Enabled = true;
            timer2.Interval = 1000 / 90;
            timer3.Enabled = true;
            timer3.Interval = 1000 / 90;
        }
        // 배경 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(5);
        }
        // 이동 타이머 기반
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isRight)
            {
                if (pictureBox1.Right < 600)
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);
            }
            if (isLeft)
            {
                if (pictureBox1.Left > 0)
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);
            }
            if (isUp)
            {
                if (pictureBox1.Top >= 300)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 2);
            }
            if (isDown)
            {
                if (pictureBox1.Bottom <= 650)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 2);
            }
            if (isAttack)
            {
                ChangeAttackState(true);
            }
        }
        private void timer3_Tick(object sender, EventArgs e) // 적 움직임 소환, 충돌체크 타이머
        {
            if (isAttack == false)
            {
                pictureBox4.Top = pictureBox1.Location.Y;
                pictureBox4.Left = pictureBox1.Left + 15;
                pictureBox5.Top = pictureBox1.Location.Y;
                pictureBox5.Left = pictureBox1.Left + 45;
            }
            else
            {
                MoveBullet(20);
            }
            EnemyAI(Enemy.speed); // 적 움직임
            CheckPlayerEnemy(); // 플레이어 충돌체크
            CheckBulletEnemy(); // 총알 충돌 체크
        }
        private void CheckPlayerEnemy() // 플레이어와 적 체크
        {
            if (Bullet.CheckCollision(pictureBox1, pictureBox6))
            {
                pictureBox6.Top = 750;
            }
            if (Bullet.CheckCollision(pictureBox1, pictureBox7))
            {
                pictureBox7.Top = 750;
            }
            if (Bullet.CheckCollision(pictureBox1, pictureBox8))
            {
                pictureBox8.Top = 750;
            }
        }
        private void CheckBulletEnemy() // 총알과 적 체크
        {
            if ((Bullet.CheckCollision(pictureBox4, pictureBox6) || Bullet.CheckCollision(pictureBox5, pictureBox6)))
            {
                pictureBox6.Top = 750;
            }
            if ((Bullet.CheckCollision(pictureBox4, pictureBox7) || Bullet.CheckCollision(pictureBox5, pictureBox7)))
            {
                pictureBox7.Top = 750;
            }
            if ((Bullet.CheckCollision(pictureBox4, pictureBox8) || Bullet.CheckCollision(pictureBox5, pictureBox8)))
            {
                pictureBox8.Top = 750;
            }
        }
        // 배경 움직이기
        private void MoveBackGround(int speed)
        {
            if (pictureBox2.Top >= 700)
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
        // 키 누를때 이동변수 조작
        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right: // 오른쪽
                    {
                        isRight = true;
                        break;
                    }
                case Keys.Left: // 왼쪽
                    {
                        isLeft = true;
                        break;
                    }
                case Keys.Up: // 위
                    {
                        isUp = true;
                        break;
                    }
                case Keys.Down: // 아래
                    {
                        isDown = true;
                        break;
                    }
                case Keys.Space: // 공격
                    {
                        isAttack = true;
                        break;
                    }
            }
        }
        // 키 땔 때 이동제한
        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    {
                        isRight = false;
                        break;
                    }
                case Keys.Left:
                    {
                        isLeft = false;
                        break;
                    }
                case Keys.Up:
                    {
                        isUp = false;
                        break;
                    }
                case Keys.Down:
                    {
                        isDown = false;
                        break;
                    }
                case Keys.Space:
                    {
                        isAttack = false;
                        ChangeAttackState(false);
                        break;
                    }
            }
        }
        private void MoveBullet(int speed)
        {
            if (pictureBox4.Top <= 0)
            {
                pictureBox4.Top = pictureBox1.Location.Y;
                pictureBox4.Left = pictureBox1.Left + 15;
            }
            else
            {
                pictureBox4.Top -= speed;
            }

            if(pictureBox5.Top <= 0)
            {
                pictureBox5.Top = pictureBox1.Location.Y;
                pictureBox5.Left = pictureBox1.Left + 45;
            }
            else
            {
                pictureBox5.Top -= speed;
            }
        }
        private void InitBullet()
        {
            pictureBox4.Image = Bullet.playerBullet;
            pictureBox4.Width = Bullet.playerBullet.Width;
            pictureBox4.Height = Bullet.playerBullet.Height;
            pictureBox4.BringToFront();
            pictureBox4.Visible = false;
            pictureBox4.Enabled = false;

            pictureBox5.Image = Bullet.playerBullet;
            pictureBox5.Width = Bullet.playerBullet.Width;
            pictureBox5.Height = Bullet.playerBullet.Height;
            pictureBox5.BringToFront();
            pictureBox5.Visible = false;
            pictureBox5.Enabled = false;

            pictureBox4.Location = new Point(pictureBox1.Location.X + 15, pictureBox1.Location.Y);
            pictureBox5.Location = new Point(pictureBox1.Location.X + 45, pictureBox1.Location.Y);
        }
        private void ChangeAttackState(bool isTrue)
        {
            pictureBox4.Enabled = isTrue;
            pictureBox4.Visible = isTrue;
            pictureBox5.Enabled = isTrue;
            pictureBox5.Visible = isTrue;
        }
        private int NotSameRandomNumber(int before)
        {
            Random rnd = new Random();
            int randomPosX;
            randomPosX = rnd.Next(20, 530);

            while (!(randomPosX >= before + 30 || randomPosX <= before - 30))
            {
                randomPosX = rnd.Next(20, 530);
            }
            return randomPosX;
        }
    }
}
