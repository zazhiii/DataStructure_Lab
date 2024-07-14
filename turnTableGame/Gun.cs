using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    class Gun
    {
        private int pos;     //枪指向位置
        private int attack;  //攻击力

        public int Pos { get => pos; set => pos = value; }
        public int Attack { get => attack; set => attack = value; }

        public Gun(int pos, int attack)
        {
            this.Pos = pos;
            this.Attack = attack;
        }
        /**
         * 开枪
         */
        public Boolean Fire()
        {
            Random random = new Random();
            return random.Next(0, 3) == 1;//    1/3的概率开枪
        }
    }
}
