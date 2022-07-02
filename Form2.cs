using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            timer1.Enabled = true;
            timer1.Interval = 1000 / 90;
            timer2.Enabled = true;
            timer2.Interval = 1000 / 90;
            timer3.Enabled = false;
            timer3.Interval = 1000 / 90;
            InitPlayer();
            InitBullet();
            ChangeAttackState(false);
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
        // 배경 타이머
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(5);
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
        // 이동 타이머 기반
        private void timer2_Tick(object sender, EventArgs e)
        {
            if(isRight)
            {
                if(pictureBox1.Right < 600)
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);
            }
            if(isLeft)
            {
                if (pictureBox1.Left > 0)
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);
            }
            if(isUp)
            {
                if (pictureBox1.Top >= 300)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 2);
            }
            if(isDown)
            {
                if (pictureBox1.Bottom <= 650)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 2);
            }
            if(isAttack)
            {
                timer3.Enabled = true;
                ChangeAttackState(true);
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
                        timer3.Enabled = false;
                        ChangeAttackState(false);
                        break;
                    }
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            MoveBullet(20);
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
    }
}
