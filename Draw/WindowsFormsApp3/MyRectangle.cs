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

        public MyRectangle() {
            this.type = ShapeEnum.RECT;
        }
        public MyRectangle(Color drawColor, float drawWidth, Point p0, int width, int height)
        {
            type = ShapeEnum.RECT;
            this.drawColor = drawColor;
            this.drawWidth = drawWidth;
            this.p0 = p0;
            this.width = width;
            this.height = height;
        }
        override public void Draw(Graphics g)
        {
            Pen pen = new Pen(drawColor, drawWidth);
            g.DrawRectangle(pen, p0.X, p0.Y, width, height);
        }
        public override void Save(BinaryWriter bw)
        {
            bw.Write((int)type);
            bw.Write(drawWidth);
            bw.Write(drawColor.R);
            bw.Write(drawColor.G);
            bw.Write(drawColor.B);
            bw.Write(p0.X);
            bw.Write(p0.Y);
            bw.Write(width);
            bw.Write(height);
        }
        public override void Read(BinaryReader br)
        {
            this.drawWidth = br.ReadSingle();
            byte r = br.ReadByte();
            byte g = br.ReadByte();
            byte b = br.ReadByte();
            this.drawColor = Color.FromArgb(r, g, b);
            this.p0.X = br.ReadInt32();
            this.p0.Y = br.ReadInt32();
            this.width = br.ReadInt32();
            this.height = br.ReadInt32();
        }
    }
}
