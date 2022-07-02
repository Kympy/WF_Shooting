namespace WF_Shooting
{
    public partial class Form1 : Form
    {
        Color backgroundColor = Color.FromArgb(38, 38, 67);
        Color buttonTextColor = Color.FromArgb(38, 38, 67);
        Color buttonBackColor = Color.FromArgb(255, 255, 134);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitForm();
            InitBackGround();
            InitTitle();
            InitLabels();

            timer1.Enabled = true;
            timer1.Interval = 1000 / 90;
        }
        public void InitForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
        }
        public void InitBackGround()
        {
            BackColor = backgroundColor;
            pictureBox1.Image = Image.FromFile("background.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(0, -300);
            pictureBox1.Width = Width;
            pictureBox1.Height = Height / 2;

            pictureBox2.Image = Image.FromFile("background.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0);
            pictureBox2.Width = Width;
            pictureBox2.Height = Height / 2;

            pictureBox3.Image = Image.FromFile("background.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Location = new Point(0, 300);
            pictureBox3.Width = Width;
            pictureBox3.Height = Height / 2;
        }
        private void InitTitle()
        {
            label1.Text = "SHOOTING";
            label2.Text = "GALAXY";
            label1.ForeColor = Color.LawnGreen;
            label2.ForeColor = Color.Aqua;
            label1.Font = new Font("Myriad Hebrew", 50, FontStyle.Bold);
            label2.Font = new Font("Myriad Hebrew", 45, FontStyle.Bold);
        }
        private void InitLabels()
        {
            label3.Text = "SCORE";
            label4.Text = "000";
            label5.Text = "LIFE";
            label6.Text = "♥♥♥";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(10);
        }

        private void MoveBackGround(int speed)
        {
            if (pictureBox1.Top >= 0)
            {
                pictureBox1.Top = -300;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= 300)
            {
                pictureBox2.Top = 0;
            }
            else
            {
                pictureBox2.Top += speed;
            }

            if (pictureBox3.Top >= 600)
            {
                pictureBox3.Top = 300;
            }
            else
            {
                pictureBox3.Top += speed;
            }
        }
        // 종료
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartGame()
        {
            this.Visible = false;
            Form2 gameForm = new Form2();
            gameForm.ShowDialog();
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             switch(e.KeyCode)
            {
                case Keys.S:
                    {
                        StartGame();
                        break;
                    }
            }
        }
    }
}