using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    public class Player
    {
        // =============================== 플레이어 변수 =================================== //

        private int speed; // 속도
        private Point location; // 위치
        private Image playerImg; // 플레이어 이미지

        // =============================== 키 입력 이동 조작 변수 =================================== //
        public bool isRight = false;
        public bool isLeft = false;
        public bool isUp = false;
        public bool isDown = false;
        public bool isAttack = false;
        public Player() // 생성자
        {
            speed = 3;
            location = new Point(230, 500);
            playerImg = ResizeImage(Image.FromFile("player.png"));

        }
        // =============================== 이미지 사이즈 조절 함수 =================================== //
        private Image ResizeImage(Image original) // 플레이어 이미지가 너무 커서 5분의 1로 줄이는 함수
        {
            int width = original.Width / 5;
            int height = original.Height / 5;
            Size resize = new Size(width, height);
            try
            {
                Bitmap resizedImg = new Bitmap(original, resize);
                return resizedImg;
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("File Load Error", ex);
            }           

        }
        // ================================= 위치, 속도, 이미지 Get함수 ======================================= //
        public Point GetLocation() // 플레이어 위치를 가져오기 >> 쓴적은 없음
        {
            return location;
        }
        public int GetSpeed() // 현재 속도
        {
            return speed;
        }
        public Image GetPlayerImg() // 플레이어 이미지 가져오기
        {
            return playerImg;
        }
    }
}
