using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace turnTableGame
{
    class Icons
    {
        public Icon[] headIcons;    //玩家头像
        /**
         * 四种表情图标
         */
        public Icon scareIcon = new Icon("icons/scare.ico");
        public Icon deadIcon = new Icon("icons/dead.ico");
        public Icon winIcon = new Icon("icons/win.ico");
        public Icon gunIcon = new Icon("icons/tank.ico");
        public Icons()
        {
            string[] iconFiles = Directory.GetFiles("icons/players", "*.ico");
            this.headIcons = new Icon[iconFiles.Length];
            for (int i = 0; i < iconFiles.Length; i++)
            {
                // 使用 FromHandle 方法加载图标文件
                using (FileStream fs = new FileStream(iconFiles[i], FileMode.Open, FileAccess.Read))
                {
                    headIcons[i] = new Icon(fs);
                }
            }
        }
    }
}
