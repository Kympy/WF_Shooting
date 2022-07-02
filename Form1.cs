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
            InitButton();
            InitLabels();

            timer1.Enabled = true;
            timer1.Interval = 1000 / 90;
        }
        public void InitForm()
        {
            StartPosition = FormStartPosition.CenterScreen;
            //FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
        }
        public void InitButton()
        {
            // 시작 버튼
            // 폰트
            button1.Text = "START";
            button1.Font = new Font("Myriad Hebrew", 20, FontStyle.Bold);
            button1.ForeColor = buttonTextColor;
            // 버튼 스타일
            button1.FlatStyle = FlatStyle.Popup;
            button1.BringToFront();
            // 색상
            button1.BackColor = buttonBackColor;
            // 크기 위치
            button1.Width = 150;
            button1.Height = 50;
            button1.Location = new Point(225, 450);

            // 종료 버튼
            // 폰트
            button2.Text = "EXIT";
            button2.Font = new Font("Myriad Hebrew", 20, FontStyle.Bold);
            button2.ForeColor = buttonTextColor;
            // 버튼 스타일
            button2.FlatStyle = FlatStyle.Popup;
            button2.BringToFront();
            //QuitButton.FlatAppearance.BorderSize = 0;
            // 색상
            button2.BackColor = buttonBackColor;
            // 크기 위치
            button2.Width = 150;
            button2.Height = 50;
            button2.Location = new Point(225, 550);
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

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button1.Visible = false;
            button2.Visible = false;

            StartGame();
        }
        private void StartGame()
        {

        }
    }
}