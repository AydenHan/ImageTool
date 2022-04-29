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

        public void DrawLine(Graphics g, Point startPoint, Point endPoint)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLine(DrawPen, startPoint, endPoint);
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

        public void DrawRect(Graphics g, Point[] point)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawLines(DrawPen, point);
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

    public abstract class AbstractGraph
    {
        protected float penSize = 1.0f;
        protected Color penColor = Color.Red;
        protected Pen drawPen = new Pen(Color.Red, 1.0f);

        protected bool isShowRange = false;
        protected Rectangle borderRectangle = Rectangle.Empty;

        private Control drawContainer;

        public float PenSize
        {
            get => penSize;
            set => penSize = value;
        }

        public Color PenColor
        {
            get => penColor;
        }
        public void SetPenColor(Color clr)
        {
            penColor = clr;
        }
        public void SetPenColor(int r, int g, int b)
        {
            penColor = Color.FromArgb(r, g, b);
        }

        public bool IsShowRange
        {
            get => isShowRange;
            set => isShowRange = value;
        }

        public Rectangle BorderRectangle
        {
            get => borderRectangle;
            set => borderRectangle = value;
        }
        public Control DrawContainer
        {
            get => drawContainer;
            set
            {
                drawContainer = value;
            }
        }


        public abstract void Drawing_LeftMouseDownHandler(Point mouseLocation);
        public abstract void Drawing_MouseMoveHandler(Point mouseLocation);
        public abstract void Drawing_LeftMouseUpHandler();
        public abstract void Drawing(Graphics graphics);
    }

    public class LineGragh : AbstractGraph
    {
        private Point drawStart;
        private Point drawEnd;
        private readonly int defaultLen = 20;

        public override void Drawing_LeftMouseDownHandler(Point mouseLocation)
        {
            drawEnd = drawStart = mouseLocation;
        }

        public override void Drawing_MouseMoveHandler(Point mouseLocation)
        {
            drawEnd = mouseLocation;

            DrawContainer.Invalidate(false);
        }

        public override void Drawing_LeftMouseUpHandler()
        {
            if (drawEnd == drawStart) drawEnd.X += defaultLen;
        }

        public override void Drawing(Graphics graphics)
        {
            graphics.DrawLine(drawPen, drawStart, drawEnd);
        }
    }
}
