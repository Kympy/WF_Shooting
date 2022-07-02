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

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(5);
        }
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

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.Right:
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X + 10, pictureBox1.Location.Y);
                        break;
                    }
                case Keys.Left:
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X - 10, pictureBox1.Location.Y);
                        break;
                    }
                case Keys.Up:
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 10);
                        break;
                    }
                case Keys.Down:
                    {
                        pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 10);
                        break;
                    }
            }
        }
    }
}
