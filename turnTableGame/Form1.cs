namespace turnTableGame
{
    public partial class Form1 : Form
    {   

        public class Player//�����
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
            public Player(){}
        }
        Player player0 = new Player();//ͷ�ڵ�(ͷ�ڵ㲻�洢Ԫ�أ�
        int count = 0;//��¼��ǰ�������
        int gunPos = 1;//ǹ��λ��
        Graphics g;// ����
        Icon smileIcon = new Icon("icons/smile.ico");
        Icon scareIcon = new Icon("icons/scare.ico");
        Icon deadIcon = new Icon("icons/dead.ico");
        Icon winIcon = new Icon("icons/win.ico");
        Icon gunIcon = new Icon("icons/tank.ico");
        public Form1()
        {
            InitializeComponent();
        }
        /*
         * ��ʼ��Ϸ
         */
        private void startGame_btn_Click(object sender, EventArgs e)
        {
           int PlayerNum = int.Parse(playersNum.Text);
           count = PlayerNum;
           Player last = player0; 
           for(int i = 1; i<=PlayerNum; i++)//�����������
            {
                Player curPlayer = new Player("���"+i, smileIcon, null);
                last.next = curPlayer;
                last = curPlayer;
            }
            drawPlayers();//�������ͷ��
        }
        /*
         * �����������
         */
        private void drawPlayers()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            g = pictureBox1.CreateGraphics();//����
            
            double a = 360 / count * Math.PI / 180;//����Ƕȣ������ƣ�
            int R = Math.Min(width, height)/2 - smileIcon.Height;
            Player p = player0.next;
            //
            Rectangle rtg = new Rectangle(0, 0, width, height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            for (int i = 0; i <= count - 1; i++)
            {
                int x = (int)(width / 2 - R * Math.Cos(a * i)) - smileIcon.Width / 2;
                int y = (int)(height / 2 - R * Math.Sin(a * i)) - smileIcon.Height / 2;
                drawPlayer(smileIcon, p, x, y);
                //g.DrawIcon(smileIcon, x, y);
                //g.DrawString(p.name, new Font("Arial", 10),new SolidBrush(Color.Black), x, y + smileIcon.Height);
                p = p.next;
            }
            drawGun();
        }

        /*
         * ����ͷ��
         */
        private void drawPlayer(Icon icon,Player p,int x, int y) {
            p.x = x;
            p.y = y;
            g.DrawIcon(icon, x, y);
            g.DrawString(p.name, new Font("Arial", 10), new SolidBrush(Color.Black), x, y + icon.Height);
        }

        /*
         * ����ǹ
         */
        private void drawGun()
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            double a = 360 / count * Math.PI / 180;//����Ƕȣ������ƣ�
            Rectangle rtg = new Rectangle(width / 2 - gunIcon.Width/2, height / 2 - gunIcon.Height/2, gunIcon.Width,gunIcon.Height);
            g.FillRectangle(new SolidBrush(Color.White), rtg);
            g.DrawIcon(rotateIcon(gunIcon, (float)(a * (gunPos - 1) / Math.PI * 180) - 90), width / 2 - gunIcon.Width / 2, height / 2 - gunIcon.Height / 2);
        }

        /*
         * ��ǹ
         */
        private void fire_btn_Click(object sender, EventArgs e)
        {
            if ( isFire() )//�ɹ���ǹ����Ҵ�����ɾ��
            {
                //startGame_btn.Text = gunPos + "";
                
                Player p = player0.next;
                Player last = player0;
                for(int i = 1; i <= count; i++)
                {
                    if (i == gunPos)
                    {
                        last.next = p.next;
                        count--;
                        deadbox.Items.Add(p.name + "����̭�ˣ�");
                        drawPlayer(deadIcon, p, p.x, p.y);//������̭ͼ��
                        Thread.Sleep(500);//�ȴ�
                        drawPlayers();
                        break;
                    }
                    last = p;
                    p = p.next;
                }
            }
            else//û��ǻ�ɹ���ǹλ��+1
            {   Player p = player0;
                for (int i = 1; i <= gunPos; i++) p = p.next;
                drawPlayer(scareIcon, p, p.x, p.y);//������̭ͼ��
                Thread.Sleep(500);//�ȴ�
                drawPlayer(smileIcon, p, p.x, p.y);
                gunPos++;
            }
            if(count == 1) 
            {
                fire_btn.Enabled = false;
                Player p = player0.next;
                drawPlayer(winIcon, p, p.x, p.y);
                deadbox.Items.Add(player0.next.name + "ȡ������Ϸʤ��������");
            }
            if (gunPos > count) gunPos = 1;
            drawGun();
        }
        /**
         * �ж��Ƿ�ǹ�ɹ�
         */
        private bool isFire()
        {
            Random rd = new Random();
            return rd.Next(0, 3) == 1;//    1/3�ĸ��ʿ�ǹ
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
    }
}