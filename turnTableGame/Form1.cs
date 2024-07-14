namespace turnTableGame
{
    public partial class Form1 : Form
    {
        Graphics g;                     // 画布
        Gun gun;                        //枪对象
        Icons icons = new Icons();      //图标资源
        PlayerList players = new PlayerList(); // 存储玩家的链表
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
            int PlayerNumber = int.Parse(playersNum.Text);  // 玩家数量
            int gunAtk = int.Parse(gunAttack.Text);         // 子弹伤害
            int health = int.Parse(healthValue.Text);       // 玩家生命值
            gun = new Gun(1, gunAtk);                       // 初始化枪对象
            Random random = new Random();
            for (int i = 1; i <= PlayerNumber; i++)//生成玩家链表
            {
                Player player = new Player("玩家" + i, icons.headIcons[random.Next(1, icons.headIcons.Length)], null, health);
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

            double a = 360 / players.Size() * Math.PI / 180;//计算角度（弧度制）
            int R = Math.Min(width, height) / 2 - icons.winIcon.Height;
            Player player = players.GetFirst();
            
            Rectangle rtg = new Rectangle(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            for (int i = 0; i < players.Size(); i++)
            {
                int x = (int)(width / 2 - R * Math.Cos(a * i)) - player.headIcon.Width / 2;
                int y = (int)(height / 2 - R * Math.Sin(a * i)) - player.headIcon.Height / 2;
                drawPlayer(player.headIcon, player, x, y);
                player = player.next;
            }
            drawGun();
        }

        /*
         * 绘制头像
         */
        private void drawPlayer(Icon icon, Player player, int x, int y)
        {
            Rectangle rtg = new Rectangle(x, y, icon.Width, icon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            player.x = x;
            player.y = y;
            g.DrawIcon(icon, x, y);
            g.DrawString(player.name, new Font("Arial", 10), new SolidBrush(Color.Black), x, y + icon.Height);
        }

        /*
         * 绘制枪
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Icon gunIcon = icons.gunIcon;
            double a = 360 / players.Size() * Math.PI / 180;//计算角度（弧度制）
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2, gunIcon.Width, gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gun.GetPos() - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * 开枪
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if (isFire())//成功开枪则将玩家从链表删除
            {
                Player rmvPlayer = players.Remove(gun.GetPos());
                deadbox.Items.Add(rmvPlayer.name + "被淘汰了！");
                drawPlayer(icons.deadIcon, rmvPlayer, rmvPlayer.x, rmvPlayer.y);//绘制淘汰图标
                Thread.Sleep(500);//等待
                drawPlayers(players);
            }
            else//没开腔成功则枪位置+1
            {   
                Player player = players.Get(gun.GetPos());
                drawPlayer(icons.scareIcon, player, player.x, player.y);//绘制淘汰图标
                Thread.Sleep(500);//等待
                drawPlayer(player.headIcon, player, player.x, player.y);
                gun.incPos();
            }
            if (players.Size() == 1)
            {
                fire_btn.Enabled = false;
                Player winPlayer = players.GetFirst();
                drawPlayer(icons.winIcon, winPlayer, winPlayer.x, winPlayer.y);
                deadbox.Items.Add(winPlayer.name + "取得了游戏胜利！！！");
            }
            if (gun.GetPos() > players.Size()) gun.setPos(1);
            drawGun();
        }
        /**
         * 判断是否开枪成功
         */
        private bool isFire()
        {
            Random random = new Random();
            return random.Next(0, 3) == 1;//    1/3的概率开枪
        }
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
        }
    }
}
