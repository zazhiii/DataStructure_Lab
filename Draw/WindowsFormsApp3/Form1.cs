using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {

        Color drawColor = Color.Black;
        float drawWidth = 1.0f;

        Point start;
        Point end;

        
        //图元对象临时变量
        Line line;
        MyRectangle rect;

        //图形对象栈
        Stack<Shape> undoStack = new Stack<Shape>();
        Stack<Shape> redoStack = new Stack<Shape>();
        
        //鼠标状态的变量
        bool bMouseDown = false;  //鼠标是否按下
        Point lastp = new Point();//鼠标上一次位置（移动前）
        Point curp = new Point(); //鼠标当前位置

        //当前绘图模式状态
        DrawingMode drawMode = DrawingMode.NONE;

        public Form1()
        {
            InitializeComponent();

            DoubleBuffered = true; //解决绘图屏幕闪烁问题
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);//解决绘图屏幕闪烁问题
        }

        private void drawLineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawingMode.LINE;
            Cursor = Cursors.Cross;
        }

        private void drawRectangleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawMode = DrawingMode.RECTANGLE;
            Cursor = Cursors.Cross;
        }
        
        /**
         * 鼠标按下
         */
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            start = e.Location;
        }
        /**
         * 鼠标抬起
         */
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            end = e.Location;
            if(drawMode == DrawingMode.LINE)
            {
                undoStack.Push(new Line(drawColor, drawWidth, start, end));
            }
            if (drawMode == DrawingMode.RECTANGLE)
            {   
                Point s = new Point(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));
                MyRectangle rtg = new MyRectangle(drawColor, drawWidth, s, Math.Abs(start.X - end.X), Math.Abs(start.Y - end.Y));
                undoStack.Push(rtg);
            }
            //if ( bMouseDown && drawMode == DrawingMode.RECTANGLE)
            //{
            //    rect.width = p.X - rect.p0.X;
            //    rect.height = p.Y - rect.p0.Y;
            //    undoStack.Push(rect);
            //    lastp = new Point(-1,-1);

            //    //还原绘图模式
            //    drawMode = DrawingMode.NONE;
            //    Cursor = Cursors.Arrow;

            //    //刷新显示
            //    Invalidate();
            //}
        }
        void Draw(Graphics g)
        {
            //绘制栈里面的图形
            Shape [] shapes = undoStack.ToArray();
            for(int i = 0; i < shapes.Length; i++) 
            {
                Shape shape = shapes[i];
                shape.Draw(g);
            }

            ////绘制动态线
            //if (drawMode == DrawingMode.LINE && (lastp.X > 0 && lastp.Y > 0))
            //{
            //    if(line.Points.Count > 1)line.Draw(g, drawPen);
            //    g.DrawLine(drawPen, lastp, curp);
            //}
            ////绘制动态矩形
            //if (drawMode == DrawingMode.RECTANGLE && (lastp.X > 0 && lastp.Y > 0))
            //{
            //    Rectangle rect = new Rectangle(lastp.X,lastp.Y,curp.X-lastp.X,curp.Y-lastp.Y);
            //    g.DrawRectangle(drawPen, rect);
            //}

        }
        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //绘制line
            if (drawMode == DrawingMode.LINE)
            {
                undoStack.Push(line);
                lastp = new Point(-1, -1);
                
                //还原绘图模式
                drawMode = DrawingMode.NONE;
                Cursor = Cursors.Arrow;

                //刷新显示
                Invalidate();
            }
        }


        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(undoStack.Count > 0) 
            {
                Shape shape = undoStack.Pop();
                redoStack.Push(shape);
                Invalidate();
            }            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(redoStack.Count > 0)
            {
                Shape shape = redoStack.Pop();
                undoStack.Push(shape);
                Invalidate();
            }           

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {          
            curp = e.Location;
            if( drawMode == DrawingMode.LINE ||
                drawMode == DrawingMode.RECTANGLE)
            {
                Invalidate();
            }
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.draw | *.draw";
            if (dlg.ShowDialog() != DialogResult.OK) return;

            string file = dlg.FileName;
            BinaryWriter bw = new BinaryWriter(new FileStream(file,FileMode.Create));
            
            Shape []shapes = undoStack.ToArray();
            bw.Write(shapes.Length);

            for (int i=0; i<shapes.Length; i++)
            {
                Shape shp = shapes[i]; 
                shp.Save(bw);//多态
            }

            bw.Close();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.draw|*.draw";
            if (dlg.ShowDialog() != DialogResult.OK) return;
            string filenmae = dlg.FileName;

            BinaryReader br = new BinaryReader(new FileStream(filenmae, FileMode.Open));

            undoStack.Clear();//清空当前的数据--从文件中读取
            int n = br.ReadInt32();
            for (int i = 0; i < n; i++)
            {                
                ShapeEnum type = (ShapeEnum)br.ReadInt32();
                if(type == ShapeEnum.LINE) 
                {
                    //line = new Line();
                    line.Read(br);
                    undoStack.Push(line);
                }
                else if (type == ShapeEnum.RECT)
                {
                    //rect = new MyRectangle();
                    rect.Read(br);
                    undoStack.Push(rect);
                }                
            }

            br.Close();

            Invalidate(); //刷新绘制
        }

        /**
         * 选择颜色 TODO
         */
        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.ShowDialog();
            drawColor = colorDialog.Color;
        }
    }
}
