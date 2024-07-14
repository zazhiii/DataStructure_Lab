using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    class Icons
    {
        private Icon[] headIcons;    //玩家头像
        /**
         * 四种表情图标
         */
        private Icon scareIcon = new Icon("icons/scare.ico");
        private Icon deadIcon = new Icon("icons/dead.ico");
        private Icon winIcon = new Icon("icons/win.ico");
        private Icon gunIcon = new Icon("icons/tank.ico");

        public Icon[] HeadIcons { get => headIcons; set => headIcons = value; }
        public Icon ScareIcon { get => scareIcon; set => scareIcon = value; }
        public Icon DeadIcon { get => deadIcon; set => deadIcon = value; }
        public Icon WinIcon { get => winIcon; set => winIcon = value; }
        public Icon GunIcon { get => gunIcon; set => gunIcon = value; }

        public Icons()
        {
            string[] iconFiles = Directory.GetFiles("icons/players", "*.ico");
            this.HeadIcons = new Icon[iconFiles.Length];
            for (int i = 0; i < iconFiles.Length; i++)
            {
                // 使用 FromHandle 方法加载图标文件
                using (FileStream fs = new FileStream(iconFiles[i], FileMode.Open, FileAccess.Read))
                {
                    HeadIcons[i] = new Icon(fs);
                }
            }
        }
    }
}
