namespace turnTableGame
{
    public partial class Form1 : Form
    {
        Graphics g;                     // ����
        Gun gun;                        //ǹ����
        Icons icons = new Icons();      //ͼ����Դ
        PlayerList players; // �洢��ҵ�����
        int PlayerNumber = 6;
        int gunAtk = 25;
        int health = 100;
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
            if(playersNum.Text != "") PlayerNumber = int.Parse(playersNum.Text);  // �������
            if (gunAttack.Text != "") gunAtk = int.Parse(gunAttack.Text);         // �ӵ��˺�
            if (healthValue.Text != "") health = int.Parse(healthValue.Text);       // �������ֵ
            players = new PlayerList();                     // ��ʼ���������
            gun = new Gun(1, gunAtk);                       // ��ʼ��ǹ����
            Random random = new Random();
            for (int i = 1; i <= PlayerNumber; i++)//�����������
            {
                Player player = new Player("���" + i, icons.HeadIcons[random.Next(1, icons.HeadIcons.Length)], null, health);
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
            var a = 360 / players.Size() * Math.PI / 180;//����Ƕȣ������ƣ�
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
         * ����ͷ��
         */
        private void drawPlayer(Icon icon, Player player)
        {   
            int x = player.X;
            int y = player.Y;
            // ��������ͷ��
            Rectangle rtg = new Rectangle(x - icon.Width / 2, y - icon.Height / 2 - 10, 2 * icon.Width, 2 * icon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            // ����������Ϣ
            //����Ѫ��
            Color color = Color.Green;
            if(player.Health <= health / 2) color = Color.Orange;
            if (player.Health <= health / 4) color = Color.Red;
            Rectangle healthBar = new Rectangle(x, y - 12, (int)1.0 * player.Health * icon.Width / health, 10);
            g.FillRectangle(new SolidBrush(color), healthBar);
            g.DrawRectangle(new Pen(Color.Black), new Rectangle(x, y - 12, icon.Width, 10));
            //����ͼ�ꡢ���֡�Ѫ��
            g.DrawIcon(icon, x, y);
            g.DrawString(player.Name, new Font("Arial", 10), new SolidBrush(Color.Black), x, y + icon.Height);
            g.DrawString(player.Health + "/" + health, new Font("Arial", 10), new SolidBrush(Color.Black), x - 10, y - 32);
        }
        /*
         *  ���Ʊ���
         */
        public void drawEmoji(Icon icon, int x, int y)
        {
            Rectangle rtg = new Rectangle(x, y, icon.Width, icon.Height);
            
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(icon, x, y);
        }
        /*
         * ����ǹ
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            Icon gunIcon = icons.GunIcon;
            double a = 360 / players.Size() * Math.PI / 180;//����Ƕȣ������ƣ�
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2, gunIcon.Width, gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gun.Pos - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * ��ǹ
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if (gun.Fire())//�ɹ���ǹ����Ҵ�����ɾ��
            {
                Player aimPlayer = players.Get(gun.Pos);    // ��ǹ���
                aimPlayer.Health = aimPlayer.Health - gun.Attack;   // ����Ѫ��
                drawEmoji(icons.DeadIcon, aimPlayer.X, aimPlayer.Y); // ������ǹͼ��
                Thread.Sleep(500);//�ȴ�
                if (aimPlayer.Health <= 0)
                {
                    deadbox.Items.Add(aimPlayer.Name + "����̭�ˣ�");
                    players.Remove(gun.Pos);
                    drawPlayers(players);
                }
                else
                {
                    gun.Pos = gun.Pos + 1;
                    drawPlayer(aimPlayer.HeadIcon, aimPlayer);
                }
            }
            else//û��ǻ�ɹ���ǹλ��+1
            {   
                Player player = players.Get(gun.Pos);
                drawEmoji(icons.ScareIcon, player.X, player.Y);
                Thread.Sleep(500);//�ȴ�
                drawEmoji(player.HeadIcon, player.X, player.Y);
                gun.Pos = gun.Pos + 1;
            }
            if (players.Size() == 1)
            {
                fire_btn.Enabled = false;
                Player winPlayer = players.GetFirst();
                drawEmoji(icons.WinIcon, winPlayer.X, winPlayer.Y);
                deadbox.Items.Add(winPlayer.Name + "ȡ������Ϸʤ��������");
            }
            if (gun.Pos > players.Size()) gun.Pos = 1;
            drawGun();
        }

        ///**
        // * �ж��Ƿ�ǹ�ɹ�
        // */
        //private bool isFire()
        //{
        //    Random random = new Random();
        //    return random.Next(0, 3) == 1;//    1/3�ĸ��ʿ�ǹ
        //}

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
            fire_btn.Enabled = false;
            restart.Enabled = false;
        }
    }
}
