using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    public class Player
    {
        public String name = "";    // 玩家名称
        public Icon headIcon;       // 头像
        public Player next;         // 下一个玩家
        public int x, y;            // 坐标
        public int health;          // 生命值
        public Player(String name, Icon headIcon, Player next, int health)
        {
            this.name = name;
            this.headIcon = headIcon;
            this.next = next;
            this.health = health;
        }
        public Player() { }
    }
}
