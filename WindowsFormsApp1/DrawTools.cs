using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImageTool
{
    public interface DrawTool
    {
        float PenSize { get; set; }
        Color PenColor { get; set; }
        Pen DrawPen { get; }
        Brush DrawBrush { get; }
        Image DrawLine(Image image, Point startPoint, Point endPoint);
    }

    public abstract class AbstractDrawTool : DrawTool
    {
        protected float penSize;
        protected Color penColor;
        //protected Pen drawPen = new Pen(PenColor, penSize);

        public abstract float PenSize { get; set; }

        public Color PenColor
        {
            get => penColor;
            set
            {
                penColor = value;
            }
        }

        public Pen DrawPen
        {
            get => new Pen(PenColor, penSize);
        }

        public Brush DrawBrush
        {
            get => new SolidBrush(PenColor);
        }

        public AbstractDrawTool()
        {

        }

        public abstract Image DrawLine(Image image, Point startPoint, Point endPoint);
    }

    public class ImageLine : AbstractDrawTool
    {
        public override float PenSize
        {
            get => penSize;
            set => penSize = value;
        }

        public ImageLine(Color color, float size)
        {
            PenSize = size;
            PenColor = color;
        }

        public override Image DrawLine(Image image, Point startPoint, Point endPoint)
        {
            Bitmap bmp = new Bitmap(image);
            Graphics.FromImage(bmp).DrawLine(DrawPen, startPoint, endPoint);

            return bmp;
        }

        public void Init(float size, Color clr)
        {
            penSize = size;
            penColor = clr;
        }

        public void Init(decimal size, int[] rgb)
        {
            penSize = float.Parse(size.ToString());
            penColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        public void DrawLine(Graphics g, Point startPoint, Point endPoint)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(DrawPen, startPoint, endPoint);
        }

        public void DrawPts(Graphics g, Point Point)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            RectangleF rect = new RectangleF(Point.X - penSize, Point.Y - penSize, penSize * 2, penSize * 2);
            g.FillEllipse(new SolidBrush(DrawPen.Color), rect);
        }

        public void DrawCircle(Graphics g, Point startPoint, Point endPoint)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int R = (int)Math.Pow(Math.Pow(endPoint.X - startPoint.X, 2) + Math.Pow(endPoint.Y - startPoint.Y, 2), 0.5);
            int x = startPoint.X - R;
            int y = startPoint.Y - R;
            int width = R * 2;
            g.DrawEllipse(DrawPen, x, y, width, width);
        }
        public void DrawCircle(Graphics g, Point startPoint, int R)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            int x = startPoint.X - R;
            int y = startPoint.Y - R;
            if (PenSize == -1)
                g.FillEllipse(DrawBrush, x, y, R * 2, R * 2);
            else
                g.DrawEllipse(DrawPen, x, y, R * 2, R * 2);
        }

        public void DrawRect(Graphics g, Point[] points)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (PenSize == -1)
                g.FillPolygon(DrawBrush, points);
            else
                g.DrawLines(DrawPen, points);
        }

        public void DrawPRect(Graphics g, Point start, Point end)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (PenSize == -1)
                g.FillRectangle(DrawBrush, start.X, start.Y, end.X - start.X, end.Y - start.Y);
            else
                g.DrawRectangle(DrawPen, start.X, start.Y, end.X - start.X, end.Y - start.Y);
        }

        public void DrawCut(Graphics g, Point startPoint, Point endPoint)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(DrawPen, startPoint, new Point(endPoint.X, startPoint.Y));
            g.DrawLine(DrawPen, startPoint, new Point(startPoint.X, endPoint.Y));
            g.DrawLine(DrawPen, new Point(endPoint.X, startPoint.Y), endPoint);
            g.DrawLine(DrawPen, new Point(startPoint.X, endPoint.Y), endPoint);
        }

        public void DrawClear(Graphics g)
        {
            g.Clear(Color.LightSlateGray);
        }
    }
}
