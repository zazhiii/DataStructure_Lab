﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    internal class PlayerList
    {
        private int size = 0;        // 链表大小
        private Player head = new Player();    // 头节点（不存储元素）

        public int Size1 { get => size; set => size = value; }
        public Player Head { get => head; set => head = value; }

        /**
         * 构造器
         */
        public PlayerList() { }

        /**
         * 添加元素（头部）
         */
        public void Add(Player player)
        {
            player.Next = Head.Next;
            Head.Next = player;
            Size1++;
        }

        /**
         * 删除玩家
         */
        public Player Remove(int index)
        {
            int p = 1;
            Player pre = Head, cur = Head.Next;
            while (cur != null)
            {
                if (p == index)
                {
                    pre.Next = cur.Next;
                    Size1--;
                    return cur;
                }
                else
                {
                    pre = cur;
                }
                cur = cur.Next;
                p++;
            }
            return Head;
        }
        /**
         * 获取链表大小
         */
        public int Size()
        {
            return Size1;
        }
        /**
         * 查找元素
         */
        public Player Get(int index)
        {
            Player player = Head.Next;
            int p = 1;
            while (player != null)
            {
                if (p == index)
                {
                    return player;
                }
                p++;
                player = player.Next;
            }
            return Head;
        }
        /**
         * 获取第一个玩家
         */
        public Player GetFirst()
        {
            return Head.Next;
        }
    }
}
