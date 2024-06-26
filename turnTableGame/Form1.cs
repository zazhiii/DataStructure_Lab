namespace turnTableGame
{
    public partial class Form1 : Form
    {

        public class Player//玩家类
        {
            public String name = "";
            public Icon headIcon;
            public Player next;
            public int x;
            public int y;
            public Player(String name, Icon headIcon, Player next)
            {
                this.name = name;
                this.headIcon = headIcon;
                this.next = next;
            }
            public Player() { }
        }
        Random random = new Random();
        Player player0 = new Player();//头节点(头节点不存储元素）
        int count = 0;//记录当前玩家数量
        int gunPos = 1;//枪的位置
        Graphics g;// 画布
        Icon[] headIcons;//玩家头像
        Icon scareIcon = new Icon("icons/scare.ico");
        Icon deadIcon = new Icon("icons/dead.ico");
        Icon winIcon = new Icon("icons/win.ico");
        Icon gunIcon = new Icon("icons/tank.ico");
        public Form1()
        {
            InitializeComponent();
            fire_btn.Enabled = false;
            restart.Enabled = false;
            //加载头像
            string[] iconFiles = Directory.GetFiles("icons/players", "*.ico");
            headIcons = new Icon[iconFiles.Length];
            for (int i = 0; i < iconFiles.Length; i++)
            {
                // 使用 FromHandle 方法加载图标文件
                using (FileStream fs = new FileStream(iconFiles[i], FileMode.Open, FileAccess.Read))
                {
                    headIcons[i] = new Icon(fs);
                }
            }
        }
        /*
         * 开始游戏
         */
        private void startGame_btn_Click(object sender, EventArgs e)
        {   
            fire_btn.Enabled = true;
            restart.Enabled = true;
            int PlayerNum = int.Parse(playersNum.Text);
            count = PlayerNum;
            Player last = player0;
            for (int i = 1; i <= PlayerNum; i++)//生成玩家链表
            {
                Player curPlayer = new Player("玩家" + i, headIcons[random.Next(1, headIcons.Length)], null);
                last.next = curPlayer;
                last = curPlayer;
            }
            drawPlayers();//绘制玩家头像
        }
        /*
         * 绘制所有玩家
         */
        private void drawPlayers()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            g = pictureBox1.CreateGraphics();//画布

            double a = 360 / count * Math.PI / 180;//计算角度（弧度制）
            int R = Math.Min(width, height) / 2 - winIcon.Height;
            Player p = player0.next;
            //
            Rectangle rtg = new Rectangle(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            for (int i = 0; i <= count - 1; i++)
            {
                int x = (int)(width / 2 - R * Math.Cos(a * i)) - p.headIcon.Width / 2;
                int y = (int)(height / 2 - R * Math.Sin(a * i)) - p.headIcon.Height / 2;
                drawPlayer(p.headIcon, p, x, y);
                p = p.next;
            }
            drawGun();
        }

        /*
         * 绘制头像
         */
        private void drawPlayer(Icon icon, Player p, int x, int y)
        {
            Rectangle rtg = new Rectangle(x, y, icon.Width, icon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            p.x = x;
            p.y = y;
            g.DrawIcon(icon, x, y);
            g.DrawString(p.name, new Font("Arial", 10), new SolidBrush(Color.Black), x, y + icon.Height);
        }

        /*
         * 绘制枪
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            double a = 360 / count * Math.PI / 180;//计算角度（弧度制）
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2, gunIcon.Width, gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gunPos - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * 开枪
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if (isFire())//成功开枪则将玩家从链表删除
            {
                //startGame_btn.Text = gunPos + "";

                Player p = player0.next;
                Player last = player0;
                for (int i = 1; i <= count; i++)
                {
                    if (i == gunPos)
                    {
                        last.next = p.next;
                        count--;
                        deadbox.Items.Add(p.name + "被淘汰了！");
                        drawPlayer(deadIcon, p, p.x, p.y);//绘制淘汰图标
                        Thread.Sleep(500);//等待
                        drawPlayers();
                        break;
                    }
                    last = p;
                    p = p.next;
                }
            }
            else//没开腔成功则枪位置+1
            {
                Player p = player0;
                for (int i = 1; i <= gunPos; i++) p = p.next;//找到gun的位置的玩家
                drawPlayer(scareIcon, p, p.x, p.y);//绘制淘汰图标
                Thread.Sleep(500);//等待
                drawPlayer(p.headIcon, p, p.x, p.y);
                gunPos++;
            }
            if (count == 1)
            {
                fire_btn.Enabled = false;
                Player p = player0.next;
                drawPlayer(winIcon, p, p.x, p.y);
                deadbox.Items.Add(player0.next.name + "取得了游戏胜利！！！");
            }
            if (gunPos > count) gunPos = 1;
            drawGun();
        }
        /**
         * 判断是否开枪成功
         */
        private bool isFire()
        {
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
            count = 0;
        }
    }
}
