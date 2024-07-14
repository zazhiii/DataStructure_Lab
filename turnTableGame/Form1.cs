namespace turnTableGame
{
    public partial class Form1 : Form
    {
        Graphics g;                     // ����
        Gun gun;                        //ǹ����
        Icons icons = new Icons();      //ͼ����Դ
        PlayerList players = new PlayerList(); // �洢��ҵ�����
        public Form1()
        { 
            InitializeComponent();
        }
        /*
         * ��ʼ��Ϸ
         */
        private void startGame_btn_Click(object sender, EventArgs e)
        {   
            fire_btn.Enabled = true;
            restart.Enabled = true;
            int PlayerNumber = int.Parse(playersNum.Text);  // �������
            int gunAtk = int.Parse(gunAttack.Text);         // �ӵ��˺�
            int health = int.Parse(healthValue.Text);       // �������ֵ
            gun = new Gun(1, gunAtk);                       // ��ʼ��ǹ����
            Random random = new Random();
            for (int i = 1; i <= PlayerNumber; i++)//�����������
            {
                Player player = new Player("���" + i, icons.headIcons[random.Next(1, icons.headIcons.Length)], null, health);
                players.Add(player);
            }
            drawPlayers(players);//�������ͷ��
        }
        /*
         * �����������
         */
        private void drawPlayers(PlayerList players)
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            g = pictureBox1.CreateGraphics();//����

            double a = 360 / players.Size() * Math.PI / 180;//����Ƕȣ������ƣ�
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
         * ����ͷ��
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
         * ����ǹ
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Icon gunIcon = icons.gunIcon;
            double a = 360 / players.Size() * Math.PI / 180;//����Ƕȣ������ƣ�
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2, gunIcon.Width, gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gun.GetPos() - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * ��ǹ
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if (isFire())//�ɹ���ǹ����Ҵ�����ɾ��
            {
                Player rmvPlayer = players.Remove(gun.GetPos());
                deadbox.Items.Add(rmvPlayer.name + "����̭�ˣ�");
                drawPlayer(icons.deadIcon, rmvPlayer, rmvPlayer.x, rmvPlayer.y);//������̭ͼ��
                Thread.Sleep(500);//�ȴ�
                drawPlayers(players);
            }
            else//û��ǻ�ɹ���ǹλ��+1
            {   
                Player player = players.Get(gun.GetPos());
                drawPlayer(icons.scareIcon, player, player.x, player.y);//������̭ͼ��
                Thread.Sleep(500);//�ȴ�
                drawPlayer(player.headIcon, player, player.x, player.y);
                gun.incPos();
            }
            if (players.Size() == 1)
            {
                fire_btn.Enabled = false;
                Player winPlayer = players.GetFirst();
                drawPlayer(icons.winIcon, winPlayer, winPlayer.x, winPlayer.y);
                deadbox.Items.Add(winPlayer.name + "ȡ������Ϸʤ��������");
            }
            if (gun.GetPos() > players.Size()) gun.setPos(1);
            drawGun();
        }
        /**
         * �ж��Ƿ�ǹ�ɹ�
         */
        private bool isFire()
        {
            Random random = new Random();
            return random.Next(0, 3) == 1;//    1/3�ĸ��ʿ�ǹ
        }
        /*
         * ��תIcon
         */
        public static Icon rotateIcon(Icon icon, float angle)
        {
            // ����һ���հ׵�λͼ��Ϊ��ת���ͼ������
            Bitmap rotatedBitmap = new Bitmap(icon.Width, icon.Height);
            // ��λͼ�ϻ�����ת���ͼ��
            using (Graphics g = Graphics.FromImage(rotatedBitmap))
            {
                g.TranslateTransform(icon.Width / 2, icon.Height / 2); // ��ԭ���Ƶ�ͼ������
                g.RotateTransform(angle); // ��תͼ��
                g.TranslateTransform(-icon.Width / 2, -icon.Height / 2); // ��ԭ�㻹ԭ�����Ͻ�
                g.DrawIcon(icon, new Rectangle(0, 0, icon.Width, icon.Height)); // ����ͼ��
            }

            // ������ת���ͼ��
            Icon rotatedIcon = Icon.FromHandle(rotatedBitmap.GetHicon());
            return rotatedIcon;
        }
        /*
         * ���¿�ʼ
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
