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
        bool isRight = false;
        bool isLeft = false;
        bool isUp = false;
        bool isDown = false;
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
            timer2.Interval = 1000 / 90;
            GetPlayer();
        }
        private void InitForm2()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void GetPlayer()
        {
            Player.InitPlayer();
            pictureBox1.Image = Player.GetPlayerImg();
            pictureBox1.Width = 80;
            pictureBox1.Height = 80;
            pictureBox1.BringToFront();
            pictureBox1.Location = Player.GetLocation();
        }
        public void InitBackGround2()
        {
            BackColor = Color.FromArgb(38, 38, 67);
            pictureBox2.Image = Image.FromFile("background.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;

            pictureBox3.Image = Image.FromFile("background.png");
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
                case Keys.Right:
                    {
                        isRight = true;
                        timer2.Enabled = true;
                        break;
                    }
                case Keys.Left:
                    {
                        isLeft = true;
                        timer2.Enabled = true;
                        break;
                    }
                case Keys.Up:
                    {
                        isUp = true;
                        timer2.Enabled = true;
                        break;
                    }
                case Keys.Down:
                    {
                        isDown = true;
                        timer2.Enabled = true;
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
            }
        }
    }
}
