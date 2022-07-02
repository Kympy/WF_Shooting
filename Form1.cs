namespace WF_Shooting
{
    public partial class Form1 : Form
    {
        Color backgroundColor = Color.FromArgb(38, 38, 67);
        Color textColor = Color.FromArgb(38, 38, 67);
        Color backColor = Color.FromArgb(255, 255, 134);
        int time = 0;
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
            Name = "Shooting Galaxy ver 1.0.0";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
        }
        public void InitBackGround()
        {
            BackColor = backgroundColor;
            pictureBox1.Image = Image.FromFile("Stars.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Width = Width;
            pictureBox1.Height = Height;

            pictureBox2.Image = Image.FromFile("Stars.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 700);
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;
        }
        private void InitTitle()
        {
            Image title = Image.FromFile("title.png");
            pictureBox3.Image = title;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Width = title.Width;
            pictureBox3.Height = title.Height;
          
        }
        private void InitLabels()
        {
            label3.Text = "PRESS 'S' TO START GAME";
            label3.ForeColor = backColor;
            label3.Font = new Font("Myriad Hebrew", 20, FontStyle.Bold);
            label3.TextAlign = ContentAlignment.MiddleCenter;

            label4.Text = "PRESS 'Q' TO EXIT GAME";
            label4.ForeColor = backColor;
            label4.Font = new Font("Myriad Hebrew", 20, FontStyle.Bold);
            label4.TextAlign = ContentAlignment.MiddleCenter;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(5);
            BlinkText(5);
        }
        // 화면 이동
        private void MoveBackGround(int speed)
        {
            if (pictureBox1.Top >= 700)
            {
                pictureBox1.Top = -700;
            }
            else
            {
                pictureBox1.Top += speed;
            }

            if (pictureBox2.Top >= 700)
            {
                pictureBox2.Top = -700;
            }
            else
            {
                pictureBox2.Top += speed;
            }
        }
        private void BlinkText(int speed)
        {
            time += speed;
            if(time >= 80)
            {
                label3.Visible = !label3.Visible;
                label4.Visible = !label4.Visible;
                time = 0;
            }
        }
        // 게임시작
        private void StartGame()
        {
            this.Visible = false;
            Form2 gameForm = new Form2();
            gameForm.ShowDialog();
            
        }
        // 키 입력
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             switch(e.KeyCode)
            {
                case Keys.S:
                    {
                        StartGame();
                        break;
                    }
                case Keys.Q:
                    {
                        Application.Exit();
                        break;
                    }
            }
        }
    }
}