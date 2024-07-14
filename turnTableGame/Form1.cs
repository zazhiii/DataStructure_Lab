namespace turnTableGame
{
    public partial class Form1 : Form
    {
        Graphics g;                     // 画布
        Gun gun;                        //枪对象
        Icons icons = new Icons();      //图标资源
        PlayerList players; // 存储玩家的链表
        int PlayerNumber = 6;
        int gunAtk = 25;
        int health = 100;
        public Form1()
        { 
            InitializeComponent();
        }
        /*
         * 开始游戏
         */
        private void startGame_btn_Click(object sender, EventArgs e)
        {   
            fire_btn.Enabled = true;
            restart.Enabled = true;
            if(playersNum.Text != "") PlayerNumber = int.Parse(playersNum.Text);  // 玩家数量
            if (gunAttack.Text != "") gunAtk = int.Parse(gunAttack.Text);         // 子弹伤害
            if (healthValue.Text != "") health = int.Parse(healthValue.Text);       // 玩家生命值
            players = new PlayerList();                     // 初始化玩家链表
            gun = new Gun(1, gunAtk);                       // 初始化枪对象
            Random random = new Random();
            for (int i = 1; i <= PlayerNumber; i++)//生成玩家链表
            {
                Player player = new Player("玩家" + i, icons.HeadIcons[random.Next(1, icons.HeadIcons.Length)], null, health);
                players.Add(player);
            }
            drawPlayers(players);//绘制玩家头像
        }
        /*
         * 绘制所有玩家
         */
        private void drawPlayers(PlayerList players)
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            g = pictureBox1.CreateGraphics();//画布
            var a = 360 / players.Size() * Math.PI / 180;//计算角度（弧度制）
            int R = Math.Min(width, height) / 2 - icons.WinIcon.Height;
            Player player = players.GetFirst();

            Rectangle rtg = new Rectangle(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);

            //Rectangle rtg2 = new Rectangle(0, 0, 10, 10);
            //g.FillRectangle(new SolidBrush(Color.Green), rtg2);
           
            for (int i = 0; i < players.Size(); i++)
            {
                int x = (int)(width / 2 - R * Math.Cos(a * i)) - player.HeadIcon.Width / 2;
                int y = (int)(height / 2 - R * Math.Sin(a * i)) - player.HeadIcon.Height / 2;
                player.X = x;
                player.Y = y;
                drawPlayer(player.HeadIcon, player);
                player = player.Next;
            }
            drawGun();
        }

        /*
         * 绘制头像
         */
        private void drawPlayer(Icon icon, Player player)
        {   
            int x = player.X;
            int y = player.Y;
            // 覆盖整个头像
            Rectangle rtg = new Rectangle(x - icon.Width / 2, y - icon.Height / 2 - 10, 2 * icon.Width, 2 * icon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            // 绘制所有信息
            //绘制血条
            Color color = Color.Green;
            if(player.Health <= health / 2) color = Color.Orange;
            if (player.Health <= health / 4) color = Color.Red;
            Rectangle healthBar = new Rectangle(x, y - 12, (int)1.0 * player.Health * icon.Width / health, 10);
            g.FillRectangle(new SolidBrush(color), healthBar);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(x, y - 12, icon.Width, 10));
            //绘制图标、名字、血量
            g.DrawIcon(icon, x, y);
            g.DrawString(player.Name, new Font("Arial", 10), new SolidBrush(Color.Black), x, y + icon.Height);
            g.DrawString(player.Health + "/" + health, new Font("Arial", 10), new SolidBrush(Color.Black), x - 10, y - 32);
        }
        /*
         *  绘制表情
         */
        public void drawEmoji(Icon icon, int x, int y)
        {
            Rectangle rtg = new Rectangle(x, y, icon.Width, icon.Height);
            
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(icon, x, y);
        }
        /*
         * 绘制枪
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Icon gunIcon = icons.GunIcon;
            double a = 360 / players.Size() * Math.PI / 180;//计算角度（弧度制）
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2, gunIcon.Width, gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gun.Pos - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * 开枪
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if (gun.Fire())//成功开枪则将玩家从链表删除
            {
                Player aimPlayer = players.Get(gun.Pos);    // 中枪玩家
                aimPlayer.Health = aimPlayer.Health - gun.Attack;   // 减少血量
                drawEmoji(icons.DeadIcon, aimPlayer.X, aimPlayer.Y); // 绘制中枪图标
                Thread.Sleep(500);//等待
                if (aimPlayer.Health <= 0)
                {
                    deadbox.Items.Add(aimPlayer.Name + "被淘汰了！");
                    players.Remove(gun.Pos);
                    drawPlayers(players);
                }
                else
                {
                    gun.Pos = gun.Pos + 1;
                    drawPlayer(aimPlayer.HeadIcon, aimPlayer);
                }
            }
            else//没开腔成功则枪位置+1
            {   
                Player player = players.Get(gun.Pos);
                drawEmoji(icons.ScareIcon, player.X, player.Y);
                Thread.Sleep(500);//等待
                drawEmoji(player.HeadIcon, player.X, player.Y);
                gun.Pos = gun.Pos + 1;
            }
            if (players.Size() == 1)
            {
                fire_btn.Enabled = false;
                Player winPlayer = players.GetFirst();
                drawEmoji(icons.WinIcon, winPlayer.X, winPlayer.Y);
                deadbox.Items.Add(winPlayer.Name + "取得了游戏胜利！！！");
            }
            if (gun.Pos > players.Size()) gun.Pos = 1;
            drawGun();
        }

        ///**
        // * 判断是否开枪成功
        // */
        //private bool isFire()
        //{
        //    Random random = new Random();
        //    return random.Next(0, 3) == 1;//    1/3的概率开枪
        //}

        /*
         * 旋转Icon
         */
        public static Icon rotateIcon(Icon icon, float angle)
        {
            // 创建一个空白的位图作为旋转后的图标容器
            Bitmap rotatedBitmap = new Bitmap(icon.Width, icon.Height);
            // 在位图上绘制旋转后的图标
            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.TranslateTransform(icon.Width / 2, icon.Height / 2); // 将原点移到图标中心
                g.RotateTransform(angle); // 旋转图标
                g.TranslateTransform(-icon.Width / 2, -icon.Height / 2); // 将原点还原到左上角
                g.DrawIcon(icon, new Rectangle(0, 0, icon.Width, icon.Height)); // 绘制图标
            }

            // 创建旋转后的图标
            Icon rotatedIcon = Icon.FromHandle(rotatedBitmap.GetHicon());
            return rotatedIcon;
        }
        /*
         * 重新开始
         */
        private void restart_Click(object sender, EventArgs e)
        {
            deadbox.Items.Clear();
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Rectangle rtg = new Rectangle(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            fire_btn.Enabled = false;
            restart.Enabled = false;
        }
    }
}
