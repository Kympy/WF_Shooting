using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    public class Bullet
    {
        // ================================ 사용할 총알 이미지 ======================================= //

        public Image playerBullet = Image.FromFile("bullet.png"); // 플레이어 총알
        public Image bossBullet = Image.FromFile("fire.png"); // 보스 총알

        // ======================= 맞은 물체 와 때린 물체의 충돌체크 ======================================= //
        public bool CheckCollision(PictureBox mainObject, PictureBox hitObject)
        {
            if (mainObject.Top <= hitObject.Bottom && mainObject.Bottom >= hitObject.Top) // Top 과 Left 이용해서 좌표가 범위에 속하면 충돌
            {
                if (mainObject.Left + 8 <= hitObject.Right && mainObject.Right - 8 >= hitObject.Left)
                {
                    return true; // 충돌했다
                }
                else return false; // 충돌 안했다
            }
            else return false;  // 충돌 안했다
        }
    }
}
