using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class Shape
    {
        public ShapeEnum type = ShapeEnum.UNKNOWN;
        virtual public void Draw(Graphics g){}
        virtual public void Save(BinaryWriter bw){}
        virtual public void Read(BinaryReader br){}
    }
}
