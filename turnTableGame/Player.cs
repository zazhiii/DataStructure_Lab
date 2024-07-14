using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    public class Player
    {
        private String name = "";    // 玩家名称
        private Icon headIcon;       // 头像
        private Player next;         // 下一个玩家
        private int y;            // 坐标
        private int health;          // 生命值
        private int x;

        public int Health { get => Health1; set => Health1 = value; }
        public string Name { get => name; set => name = value; }
        public Icon HeadIcon { get => headIcon; set => headIcon = value; }
        public Player Next { get => next; set => next = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int Health1 { get => health; set => health = value; }

        public Player(String name, Icon headIcon, Player next, int health)
        {
            this.Name = name;
            this.HeadIcon = headIcon;
            this.Next = next;
            this.Health = health;
        }
        public Player() { }

    }
}
