using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    internal class Bullet
    {
        public static Image playerBullet = Image.FromFile("bullet.png");
        // 맞은 물체 와 때린 물체의 충돌체크
        public static bool CheckCollision(PictureBox mainObject, PictureBox hitObject)
        {
            if (mainObject.Top + 3 <= hitObject.Bottom && mainObject.Bottom - 3 >= hitObject.Top)
            {
                if (mainObject.Left + 8 <= hitObject.Right && mainObject.Right - 8>= hitObject.Left)
                {
                    return true;
                }
                else return false;
            }
            else return false;

        }
    }
}
