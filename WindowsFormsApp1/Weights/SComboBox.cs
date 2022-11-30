using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{
    [DefaultEvent("DropBtnClick")]
    public partial class SComboBox : Control
    {
        private RectangleF dropBtn;
        private float dropBtnWidth = 14;
        private bool isDropArea = false;

        public Color BorderColor { get; set; } = Color.Black;
        public Color DropAreaColor { get; set; } = Color.Black;
        public bool UseRadius { get; set; } = true;

        public SComboBox() {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

        }

        #region 重写事件

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Brush bBack = new SolidBrush(BackColor);
            Brush bFore = new SolidBrush(ForeColor);
            Pen pBorder = new Pen(BorderColor, 2);

            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            SizeF txtSize = g.MeasureString("abc", Font);
            Height = (int)txtSize.Height + 8;

            float radius = UseRadius ? Height / 2 : 0;
            dropBtn = new RectangleF(ClientRectangle.Width - 2 - dropBtnWidth - radius / 2, 0, dropBtnWidth, Height);

            // 画字
            if (Text != string.Empty && Enabled)
            {
                float tx = radius - 2;
                float ty = radius - txtSize.Height / 2f + 0.5f;
                g.DrawString(Text, Font, bFore, tx, ty);
            }
            // 画背景
            g.FillRectangle(bBack, dropBtn);
            // 画圆角框
            g.DrawLine(pBorder, radius, 0, Width - 1 - radius, 0);
            g.DrawLine(pBorder, radius, Height - 1, Width - 1 - radius, Height - 1);
            if (UseRadius) {
                g.DrawArc(pBorder, 1, 0, Height, Height - 1, 90, 180);
                g.DrawArc(pBorder, Width - 2 - Height, 0, Height, Height - 1, 270, 180);
            }
            else {
                g.DrawLine(pBorder, 0, 0, 0, Height - 1);
                g.DrawLine(pBorder, Width - 1, 0, Width - 1, Height - 1);
            }
            // 画下拉按钮
            g.DrawLine(pBorder, dropBtn.Left + 2, dropBtn.Height * 0.4f, dropBtn.Left + dropBtn.Width / 2f, dropBtn.Height * 0.6f);
            g.DrawLine(pBorder, dropBtn.Right - 2, dropBtn.Height * 0.4f, dropBtn.Left + dropBtn.Width / 2f, dropBtn.Height * 0.6f);
            if (isDropArea) {
                if (UseRadius)
                    g.FillEllipse(new SolidBrush(Color.FromArgb(33, DropAreaColor)),
                        dropBtn.Left - dropBtnWidth / 3, dropBtn.Top + 0.5f, dropBtnWidth * 1.67f, dropBtn.Height - 1);
                else
                    g.FillRectangle(new SolidBrush(Color.FromArgb(33, DropAreaColor)), dropBtn);
            }
            bBack.Dispose();
            bFore.Dispose();
            pBorder.Dispose();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (isDropArea)
                DropBtnClick?.Invoke(this, e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            isDropArea = IsDropArea(e.Location);
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            isDropArea = false;
            Invalidate();
        }
        
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            Invalidate();
        }

        #endregion


        #region 自定义函数

        public delegate void ShowListHandler(object sender, EventArgs e);
        [Description("当点击下拉按钮时触发"), Category("自定义事件")]
        public event ShowListHandler DropBtnClick;

        private bool IsDropArea(Point p)
        {
            if (p.X < dropBtn.Right && p.X > dropBtn.Left
                    && p.Y < dropBtn.Bottom && p.Y > dropBtn.Top)
                return true;

            return false;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
