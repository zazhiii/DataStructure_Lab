using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    internal class PlayerList
    {
        ///**
        // * 节点内部类
        // */
        //public class Player
        //{
        //    public E value;
        //    public Player next;
        //    public Node(E value, Player next)
        //    {
        //        this.value = value;
        //        this.next = next;
        //    }
        //    public Node() { }
        //}

        public int size = 0;        // 链表大小
        public Player head = new Player();    // 头节点（不存储元素）

        /**
         * 构造器
         */
        public PlayerList() { }

        /**
         * 添加元素（头部）
         */
        public void Add(Player player)
        {
            player.next = head.next;
            head.next = player;
            size++;
        }

        /**
         * 删除玩家
         */
        public Player Remove(int index)
        {
            int p = 1;
            Player pre = head, cur = head.next;
            while (cur != null)
            {
                if (p == index)
                {
                    pre.next = cur.next;
                    size--;
                    return cur;
                }
                else
                {
                    pre = cur;
                }
                cur = cur.next;
                p++;
            }
            return head;
        }
        /**
         * 获取链表大小
         */
        public int Size()
        {
            return size;
        }
        /**
         * 查找元素
         */
        public Player Get(int index)
        {
            Player player = head.next;
            int p = 1;
            while (player != null)
            {
                if (p == index)
                {
                    return player;
                }
                p++;
                player = player.next;
            }
            return head;
        }
        /**
         * 获取第一个玩家
         */
        public Player GetFirst()
        {
            return head.next;
        }
    }
}
