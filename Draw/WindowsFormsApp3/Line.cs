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
            //bw.Write((int)type);
            //bw.Write(Points.Count);
            //for (int i=0;i<  Points.Count;i++) 
            //{
            //    Point point = Points[i];
            //    bw.Write(point.X);
            //    bw.Write(point.Y);
            //}
        }
        override public void Read(BinaryReader br)
        {
            //int n = br.ReadInt32();
            //for (int i = 0; i < n; i++)
            //{
            //    int x = br.ReadInt32();
            //    int y = br.ReadInt32();
            //    Point p = new Point(x,y);
            //    Points.Add(p);
            //}
        }

        //public override string ToString()
        //{
        //    //return "点数：" + Points.Count;
        //}

    }
}
