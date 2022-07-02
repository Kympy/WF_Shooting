# Shooting_Galaxy_WindowForm
 
### 의의
 
그동안 3편까지는 콘솔로 했었다면, 이번에는 Window Form형태로 도전해 볼 것이다.
Window Form을 사용하면서 좀 더 2차원적인 그래픽 표현 능력이 향상되다보니 더 게임다운 모습을 하게 된다.
콘솔로 그래픽을 문자로 표현하면서 노가다 적인 부분들이 있는데,
그 부분들이 많이 개선되겠지만, 윈폼을 쓰면서 오히려 더 신경써야할 부분들도 생기는 것 같다.
 
리소스는 캐릭터는 유니티 에셋스토어를 활용하였고, >>

https://assetstore.unity.com/packages/2d/textures-materials/pixel-art-starships-package-terran-fleet-205131

 
나머지는 직접 포토샵으로 작업한 개인 창작물이다.

### 구현
이번에는 전체 코드를 공개하지 않고, 구현을 하면서 조금 특징적인 부분이었다고 생각되는 부분만
적어보도록 하겠다.
 
#### 키 입력과 이동
아직, 게임엔진 급은 아니지만 Timer를 사용하면 좀 더 유니티에 Update문과 비슷한 코드를 쓸 수 있게 되었다.
처음에 KeyDown이벤트를 받아, 움직이고자 하는 물체의 Location을 new Point로 재 할당하면서 움직였는데,
이렇게 하게 되면, 마치 그리드 위에서 1칸씩 끊기며 움직이는 부적합한 이동이 발생한다.
 
이를 해결하기 위해, 이동관련 키 입력을 타이머의 Tick마다 받아서 키의 입력여부를 판정하는
Bool 변수를 만들었다. 이 Bool값을 통해 이동과 공격이 실행되면, 프레임마다 부드럽게 이동시킬 수 있으며,
속도도 일정하다.

  ```C#
   // 이동 타이머 기반
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isRight) // 우측
            {
                if (pictureBox1.Right < 600)
                    pictureBox1.Location = new Point(pictureBox1.Location.X + 2, pictureBox1.Location.Y);
            }
            if (isLeft) // 좌측
            {
                if (pictureBox1.Left > 0)
                    pictureBox1.Location = new Point(pictureBox1.Location.X - 2, pictureBox1.Location.Y);
            }
            if (isUp) // 전방
            {
                if (pictureBox1.Top >= 300)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y - 2);
            }
            if (isDown) // 후방
            {
                if (pictureBox1.Bottom <= 650)
                    pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y + 2);
            }
            if (isAttack) // 공격
            {
                ChangeAttackState(true);
            }
        }
   ```
        
각각의 isRight, isLeft 같은 변수를 통해 타이머를 거쳐 90프레임이 나오도록 만들었다.
 
####배경 무한 이동

   ```C#
      public void InitBackGround2() // 배경 속성 초기화
        {
            BackColor = Color.FromArgb(38, 38, 67);
            pictureBox2.Image = Image.FromFile("Stars.png");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.Location = new Point(0, 0); // 배경 시작위치
            pictureBox2.Width = Width;
            pictureBox2.Height = Height;

            pictureBox3.Image = Image.FromFile("Stars.png");
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.Location = new Point(0, 700); // 배경 시작위치
            pictureBox3.Width = Width;
            pictureBox3.Height = Height;
        }
   ```
무한으로 이동하는 게임에서 캐릭터는 실제로 고정되어 있지만, 움직이는 느낌을 주기 위해서는
캐릭터를 제외한 주변 배경이 움직여야 한다. 이 원리로 뒷 배경을 위에서 아래로 움직이도록 하였다.
   ```C#
       // 배경 움직이기
        private void MoveBackGround(int speed)
        {
            if (pictureBox2.Top >= 700) // 창 크기를 벗어나면
            {
                pictureBox2.Top = -700; // 초기화
            }
            else
            {
                pictureBox2.Top += speed; // 아니면 이동
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
   ```
이 게임의 창 크기는 600 X 700 이다. 세로가 700이고 배경은 세로 방향으로 이동한다.
따라서, 배경 이미지를 2개를 준비하여 하나가 내려와서 화면을 벗어나면 다른 하나가 맨 위로 올라가서 또 내려오는
위에서 아래로 내려와 다시 쌓이는 구조를 만들어 줄 수 있다.

#### 충돌체크
 
그림과 그림끼리의 충돌로 볼 수 있다. 충돌을 계산하기 위해서는 각 그림끼리의 좌표를 활용해야한다.
나는 좌표대신에, 창의 위치를 기준으로 떨어져있는 거리를 가져올 수 있는 속성 .Left .Top .Right .Bottom 을 사용했다.

   ```C#
      // 맞은 물체 와 때린 물체의 충돌체크
        public static bool CheckCollision(PictureBox mainObject, PictureBox hitObject)
        {	// 세로 체크
            if (mainObject.Top + 3 <= hitObject.Bottom && mainObject.Bottom - 3 >= hitObject.Top)
            {	// 가로 체크
                if (mainObject.Left + 8 <= hitObject.Right && mainObject.Right - 8>= hitObject.Left)
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }
   ```
main 은 충돌 당한 물체이고, hit은 충돌을 일으킨 물체이다.
첫 번째 조건 만 예를 들어 보자면, 맞은 물체의 Top이 때린 물체의 Bottom 부분 보다 작다면, 때린물체의 하단이 맞은 물체의 윗부분과 겹치기 시작하므로, 충돌하였다고 판정할 수 있다.
여기서, 세밀한 충돌을 체크하기 위해 ( 이미지의 그림과 상관없이 여백끼리 충돌 방지 )
개인적으로 +3 , -8 등의 수치를 조정하여 주었다. 필요에 따라 조절하면 될 것 같다.
이렇게 정의한 함수로 게임 내의 모든 충돌관계를 체크할 수 있었다.
