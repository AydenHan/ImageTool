using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{

    public partial class SButton : Button
    {
        private Color backColor, borderColor;

        [Description("按钮圆角的弧度")]
        public int Radius { get; set; }
        [Description("鼠标移至按钮上方时的背景颜色")]
        public Color OnBackColor { get; set; }
        [Description("鼠标移至按钮上方时的边框颜色")]
        public Color OnBorderColor { get; set; }

        public SButton() { PropInit(); }
        public SButton(int rad)
        {
            PropInit();

            Radius = rad;
        }

        protected void PropInit()
        {
            Radius = 9;
            OnBackColor = Color.FromArgb(Convert.ToInt32("FFE3F3FB", 16));
            OnBorderColor = Color.FromArgb(Convert.ToInt32("FF3283C4", 16));

            ForeColor = Color.Black;
            BackColor = Color.White;
            FlatAppearance.BorderSize = 1;
            FlatAppearance.BorderColor = Color.Black;
        }

        #region 重写事件

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = ClientRectangle;
            Brush brhBorder = new SolidBrush(FlatAppearance.BorderColor);
            Brush brhBack = new SolidBrush(BackColor);
            Brush brhFore = new SolidBrush(ForeColor);

            try
            {
                int borderSize = FlatAppearance.BorderSize;
                g.Clear(Parent.BackColor);
                GraphicsPath path = RoundRect(rect.Left, rect.Top, rect.Width, rect.Height, Radius);
                g.FillPath(brhBorder, path);
                path.Dispose();
                path = RoundRect(rect.Left + borderSize, rect.Top + borderSize, rect.Width - borderSize * 2, rect.Height - borderSize * 2, Radius);
                g.FillPath(brhBack, path);
                path.Dispose();

                if (Text != string.Empty)
                {
                    StringFormat sf = StringFormat.GenericTypographic;
                    sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                    SizeF txtSize = g.MeasureString(Text, Font);
                    float tx = (Width - txtSize.Width) / 2.0f;
                    float ty = (Height - txtSize.Height) / 2.0f;
                    g.DrawString(Text, Font, brhFore, tx, ty);
                }
            }
            finally
            {
                brhBorder.Dispose();
                brhBack.Dispose();
                brhFore.Dispose();
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            backColor = BackColor;
            borderColor = FlatAppearance.BorderColor;
            BackColor = OnBackColor;
            FlatAppearance.BorderColor = OnBorderColor;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = backColor;
            FlatAppearance.BorderColor = borderColor;
        }

        #endregion

        public void SetOpacity(int per)
        {
            BackColor = Color.FromArgb(per, BackColor);
            FlatAppearance.BorderColor = Color.FromArgb(per, FlatAppearance.BorderColor); ;
        }

        private GraphicsPath RoundRect(float left, float top, float width, float height, int radius = 0)
        {
            float shift = 3;
            width -= shift;
            height -= shift;

            if (width > height)
            {
                if (radius > height / 2) radius = (int)(height / 2);
            }
            else
            {
                if (radius > width / 2) radius = (int)(width / 2);
            }
            int d = radius * 2;

            GraphicsPath path = new GraphicsPath(FillMode.Winding);
            RectangleF row = new RectangleF(left, top + radius, width, height - d);
            RectangleF col = new RectangleF(left + radius, top, width - d, height);

            path.AddRectangle(row);
            path.AddRectangle(col);
            path.AddEllipse(left, top, d, d);
            path.AddEllipse(left + width - d, top, d, d);
            path.AddEllipse(left, top + height - d, d, d);
            path.AddEllipse(left + width - d, top + height - d, d, d);

            return path;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
