using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class MyRectangle : Shape
    {
        public Point p0;
        public int width = 0;
        public int height = 0;
        public MyRectangle()
        {
            type = ShapeEnum.RECT;
        }
        override public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Black, p0.X, p0.Y,width, height);
        }
        public override void Save(BinaryWriter bw)
        {
            bw.Write((int)type);
            bw.Write(p0.X);
            bw.Write(p0.Y);
            bw.Write(width);
            bw.Write(height);
        }
        public override void Read(BinaryReader br)
        {
            p0.X = br.ReadInt32();
            p0.Y = br.ReadInt32();
            width = br.ReadInt32();
            height = br.ReadInt32();
        }
    }
}
