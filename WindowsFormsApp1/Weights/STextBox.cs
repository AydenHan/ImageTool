using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;

namespace ImageTool.Weights
{
    [DefaultEvent("Scrolled")]
    public partial class STextBox : TextBox
    {
        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private Color borderColor;
        private int editStatus = 0;

        // 外观
        [Description("文本框边框的颜色"), Category("自定义外观")]
        public Color BorderColor { get; set; } = Color.FromArgb(220, 220, 220);
        [Description("鼠标移至文本框上方时，边框的颜色"), Category("自定义外观")]
        public Color OnBorderColor { get; set; } = Color.FromArgb(150, 150, 150);
        [Description("边框的圆角尺寸"), Category("自定义外观")]
        public int Radius { get; set; } = 3;

        public STextBox()
        {
            borderColor = BorderColor;
        }

        #region 重写事件

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xf || m.Msg == 0x133) {
                IntPtr hDC = GetWindowDC(m.HWnd);
                if (hDC.ToInt32() != 0) {
                    using(Graphics g = Graphics.FromHdc(hDC)) {
                        g.SmoothingMode = SmoothingMode.AntiAlias;
                        // 遮盖原边框
                        Pen pBack = new Pen(Color.White, 1);
                        g.DrawRectangle(pBack, 0, 0, Width - 1, Height - 1);
                        // 绘制新边框
                        int d = Radius * 2;
                        Pen pBorder = new Pen(borderColor, 1.5f);
                        g.DrawLine(pBorder, Radius, 0, Width - 1 - Radius, 0);
                        g.DrawLine(pBorder, Radius, Height - 1, Width - 1 - Radius, Height - 1);
                        g.DrawLine(pBorder, 0, Radius, 0, Height - 1 - Radius);
                        g.DrawLine(pBorder, Width - 1, Radius, Width - 1, Height - 1 - Radius);
                        if (Radius > 0)
                        {
                            g.DrawArc(pBorder, 0, 0, d, d, 180, 90);
                            g.DrawArc(pBorder, Width - 1 - d, 0, d, d, 270, 90);
                            g.DrawArc(pBorder, Width - 1 - d, Height - 1 - d, d, d, 0, 90);
                            g.DrawArc(pBorder, 0, Height - 1 - d, d, d, 90, 90);
                        }

                        pBorder.Dispose();
                        pBack.Dispose();
                    }
                }
                m.Result = IntPtr.Zero;
                ReleaseDC(m.HWnd, hDC);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            editStatus = 1;
            //Invalidate();
            //Focus();
            base.OnMouseClick(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            borderColor = OnBorderColor;
            //Cursor = Cursors.IBeam;
            //Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            borderColor = BorderColor;
            //Cursor = Cursors.Default;
            //Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            //StringFormat sf = StringFormat.GenericTypographic;
            //sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
            //SizeF txtSize = CreateGraphics().MeasureString("abc", Font);
            //Height = (int)txtSize.Height + (Margin.Vertical < Radius * 2 ? Margin.Vertical : Radius * 2);
            base.OnSizeChanged(e);
        }

        #endregion


        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
