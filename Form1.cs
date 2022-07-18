namespace WF_Shooting
{
    public partial class Form1 : Form
    {
        // ================================= 필요한 색상 정의 ================================= //
        Color backgroundColor = Color.FromArgb(38, 38, 67);
        Color textColor = Color.FromArgb(38, 38, 67);
        Color backColor = Color.FromArgb(255, 255, 134);

        private int time = 0; // 깜빡임을 만들기 위한 변수
        // ================================= 메인 폼 초기화 ================================= //
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
        // ================================= 폼 정의 ================================= //
        public void InitForm()
        {
            Name = "Shooting Galaxy ver 1.0.2";
            StartPosition = FormStartPosition.CenterScreen;
            MaximizeBox = false;
            Width = 600;
            Height = 700;
        }
        // ================================= 배경 초기화 ================================= //
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
        // ================================= 제목 이미지 초기화 ================================= //
        private void InitTitle()
        {
            Image title = Image.FromFile("title.png");
            pictureBox3.Image = title;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Width = title.Width;
            pictureBox3.Height = title.Height;
          
        }
        // ================================= 폼 라벨 초기화 ================================= //
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
        // ================================= 배경 이동 & 메뉴 깜빡임 타이머 ================================= //
        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveBackGround(5);
            BlinkText(5);
        }
        // ================================= 배경 이동 함수 ================================= //
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
        // ================================= 메뉴 깜빡임 함수 ================================= //
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
        // ================================= 게임 시작 화면 이동 ================================= //
        private void StartGame()
        {
            this.Visible = false;
            Form2 gameForm = new Form2();
            gameForm.ShowDialog();
            this.Close();
        }
        // ================================= 게임 시작을 위한 키 입력 처리 ================================= //
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
             switch(e.KeyCode)
            {
                case Keys.S: // 시작
                    {
                        StartGame();
                        break;
                    }
                case Keys.Q: // 종료
                    {
                        Application.Exit();
                        break;
                    }
            }
        }
    }
}