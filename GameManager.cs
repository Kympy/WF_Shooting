using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_Shooting
{
    public class GameManager
    {
        // ================================ 관리할 클래스들 ======================================= //

        public GameInfo gameInfo = new GameInfo(); // 게임 종합 관리 클래스
        public Player playerClass = new Player(); //  플레이어 클래스
        public Enemy enemyClass = new Enemy(); // 적 클래스
        public Bullet bulletClass = new Bullet(); // 총알 클래스

        // ================================ 게임 매니저 인스턴스 ======================================= //
        private static GameManager instance = null;
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        protected GameManager()
        {

        }

    }
}
