using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    //public enum ShapeEnum
    //{
    //    unknown = -1,
    //    line = 0,
    //    Rect = 1,
    //    Polygon = 2,
    //}
    //public class Shape
    //{
    //    public ShapeEnum type = ShapeEnum.UNKNOWN;
    //    virtual public void Draw(Graphics g) 
    //    {

    //    }
    //    virtual public void Save(BinaryWriter bw)
    //    {

    //    }
    //    virtual public void Read(BinaryReader br)
    //    {

    //    }
    //}
    internal class Line: Shape
    {
        public List<Point>Points = new List<Point>();
        public Line() 
        {
            type = ShapeEnum.LINE; 
        }
        override public void Draw(Graphics g)
        {
            g.DrawLines(Pens.Black, Points.ToArray());
        }

        public override void Save(BinaryWriter bw)
        {
            bw.Write((int)type);
            bw.Write(Points.Count);
            for (int i=0;i<  Points.Count;i++) 
            {
                Point point = Points[i];
                bw.Write(point.X);
                bw.Write(point.Y);
            }
        }
        override public void Read(BinaryReader br)
        {
            int n = br.ReadInt32();
            for (int i = 0; i < n; i++)
            {
                int x = br.ReadInt32();
                int y = br.ReadInt32();
                Point p = new Point(x,y);
                Points.Add(p);
            }
        }

        public override string ToString()
        {
            return "点数：" + Points.Count;
        }

    }
}
