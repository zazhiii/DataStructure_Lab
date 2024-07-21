using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    internal class Line : Shape
    {
        public Point start;
        public Point end;
        public Line() {
            this.type = ShapeEnum.LINE;
        }
        public Line(Color drawColor, float drawWidth, Point start, Point end)
        {
            type = ShapeEnum.LINE;
            this.drawColor = drawColor;
            this.drawWidth = drawWidth;
            this.start = start;
            this.end = end;
        }
        override public void Draw(Graphics g)
        {
            Pen pen = new Pen(drawColor, drawWidth);
            g.DrawLines(pen, new Point[] {start, end});
        }

        public override void Save(BinaryWriter bw)
        {
            bw.Write((int)type);
            bw.Write(drawWidth);
            bw.Write(drawColor.R);
            bw.Write(drawColor.G);
            bw.Write(drawColor.B);
            bw.Write(start.X);
            bw.Write(start.Y);
            bw.Write(end.X);
            bw.Write(end.Y);
        }
        override public void Read(BinaryReader br)
        {   
            //this.type = (ShapeEnum)br.ReadInt32();
            this.drawWidth = br.ReadSingle();
            byte r = br.ReadByte();
            byte g = br.ReadByte();
            byte b = br.ReadByte();
            this.drawColor = Color.FromArgb(r, g, b);
            int sx = br.ReadInt32();
            int sy = br.ReadInt32();
            int ex = br.ReadInt32();
            int ey = br.ReadInt32();
            this.start = new Point(sx, sy);
            this.end = new Point(ex, ey);
        }
    }
}
