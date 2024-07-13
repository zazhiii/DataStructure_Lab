using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    class Gun
    {
        public int pos;     //枪指向位置
        public int attack;  //攻击力
        public Gun(int pos, int attack)
        {
            this.pos = pos;
            this.attack = attack;
        }
    }
}
