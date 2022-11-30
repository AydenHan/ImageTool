using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{

    public partial class SRadioButton : RadioButton
    {
        private Color backCheckColor;

        [Description("Radio框的颜色")]
        public Color BackCheckColor { get; set; } = Color.FromArgb(Convert.ToInt32("FFFF7700", 16));
        [Description("圆点的颜色")]
        public Color ForeCheckColor { get; set; } = Color.White;

        public SRadioButton() { }


        #region 重写事件

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Pen pBack = new Pen(BackColor, Height + 2);
            Brush bFore = new SolidBrush(Checked ? BackCheckColor : ForeColor); 
            Brush pChecked = new SolidBrush(BackCheckColor);
            Pen pUnCheck = new Pen(BackCheckColor, 1);
            SizeF txtSize = new SizeF(0, Height * 0.75f);

            g.DrawLine(pBack, -1, Height / 2f, Width + 1, Height / 2f);
            if (Text != string.Empty) {
                StringFormat sf = StringFormat.GenericTypographic;
                sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
                txtSize = g.MeasureString(Text, Font);
                float tx = txtSize.Height + 4;
                float ty = (Height - txtSize.Height) / 2.0f;
                g.DrawString(Text, Font, bFore, tx, ty);
            }

            int y = (int)((Height - txtSize.Height * 0.8f) / 2.0f);
            Rectangle box = new Rectangle(y, y, (int)(txtSize.Height * 0.8f), (int)(txtSize.Height * 0.8f));

            g.DrawEllipse(pUnCheck, box);
            if (Checked)  {
                g.FillEllipse(pChecked, box.Left + 3, box.Top + 3, box.Width - 6, box.Height - 6);
            }
            
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
