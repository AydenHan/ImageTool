using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{

    public partial class SCheckBox : CheckBox
    {
        private Color backCheckColor;

        [Description("复选框以及勾的粗细")]
        public float Stroke { get; set; } = 3;
        [Description("复选框的颜色")]
        public Color BackCheckColor { get; set; } = Color.FromArgb(Convert.ToInt32("FFFF7F00", 16));
        [Description("勾的颜色")]
        public Color ForeCheckColor { get; set; } = Color.White;

        public SCheckBox() { }


        #region 重写事件

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Rectangle box = new Rectangle((int)(Height * 0.15f), (int)(Height * 0.15f), (int)(Height * 0.7f), (int)(Height * 0.7f));
            if (Stroke > box.Height / 3f) Stroke = box.Height / 3f;
            if (Stroke <= 0) Stroke = 0.5f;

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pGou = new Pen(ForeCheckColor, Stroke);
            Pen pUnCheck = new Pen(BackCheckColor, Stroke);
            Pen pChecked = new Pen(BackCheckColor, box.Height + 2);
            Pen pBack = new Pen(BackColor, Height + 2);
            Brush bFore = new SolidBrush(ForeColor);

            g.DrawLine(pBack, -1, Height / 2f, Width + 1, Height / 2f);
            if (Checked)  {
                bFore = new SolidBrush(BackCheckColor);
                g.DrawLine(pChecked, box.Left, Height / 2f, box.Right, Height / 2f);
                g.DrawLine(pGou, box.Left + 1, Height / 2f, box.Left + 0.4f * box.Width, box.Bottom - 1);
                g.DrawLine(pGou, box.Left + 0.4f * box.Width, box.Bottom - 1, box.Right - 1, box.Top + 1);
            }
            else {
                g.DrawRectangle(pUnCheck, box);
            }
            if (Text != string.Empty) {
                StringFormat sf = StringFormat.GenericTypographic;
                sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                SizeF txtSize = g.MeasureString(Text, Font);
                float tx = box.Right + 4;
                float ty = (Height - txtSize.Height) / 2.0f;
                g.DrawString(Text, Font, bFore, tx, ty);
            }

            pGou.Dispose();
            pUnCheck.Dispose();
            pChecked.Dispose();
            pBack.Dispose();
            bFore.Dispose();
        }

        protected override void OnMouseEnter(EventArgs eventargs)
        {
            base.OnMouseEnter(eventargs);
            backCheckColor = BackCheckColor;
            BackCheckColor = Color.FromArgb((int)(backCheckColor.A * 0.75), backCheckColor);
            Invalidate();
            Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs eventargs)
        {
            base.OnMouseLeave(eventargs);
            BackCheckColor = backCheckColor;
            Invalidate();
            Cursor = Cursors.Default;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
