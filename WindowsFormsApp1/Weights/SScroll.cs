using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{
    [DefaultEvent("Scrolled")]
    public partial class SScroll : Control
    {
        // 滑动块状态
        private Color sliderColor;
        private float msOnSliderShift = 0;
        private float msMoveRange = 100;
        private int msStatus = -1;
        private float capSize;

        private float sliderPos;
        private bool isHorizon = true;

        // 关联信息
        private float docSize;
        private float pageSize;

        [Description("滚动条和背景条是否使用圆角"), Category("自定义属性")]
        public bool IsRound { get; set; }
        [Description("设置滚动条方向为垂直或水平"), Category("自定义属性")]
        public bool IsHorizon {
            get => isHorizon;
            set
            {
                if (value != isHorizon)
                {
                    isHorizon = value;

                    int temp = Width;
                    Width = Height;
                    Height = temp;
                }
            }
        }
        [Description("鼠标移至滚动条上方时，滚动条的颜色"), Category("自定义属性")]
        public Color OnForeColor { get; set; }
        [Description("滚动条的长度"), Category("自定义属性")]
        public float SliderLength { get; set; }
        [Description("绑定控件的真实长度，用于计算滑动比例关系"), Category("自定义属性")]
        public float DocSize {
            get => docSize;
            set
            {
                if (value != docSize)
                {
                    docSize = value;
                    SetLength();
                }
            }
        }
        [Description("绑定控件的显示长度，用于计算滑动比例关系"), Category("自定义属性")]
        public float PageSize
        {
            get => pageSize;
            set
            {
                if (value != pageSize)
                {
                    pageSize = value;
                    SetLength();
                }
            }
        }


        [Browsable(false)]
        public float SliderPos {
            get => sliderPos;
            private set
            {
                if (value != sliderPos)
                {
                    sliderPos = value;
                    DocSliderDis = sliderPos / msMoveRange * (DocSize - PageSize);
                    if (sliderPos >= 0 && sliderPos <= msMoveRange)
                        Scrolled?.Invoke(this, new EventArgs());
                }
            }
        }
        [Browsable(false)]
        public float DocSliderDis { get; set; }

        public SScroll() { PropInit(); }

        protected void PropInit()
        {
            IsHorizon = false;
            IsRound = true;
            SliderLength = 30;
            SliderPos = 0;

            BackColor = Color.White;
            ForeColor = Color.FromArgb(Convert.ToInt32("FF33CC66", 16));
            OnForeColor = Color.FromArgb(Convert.ToInt32("FF00FF66", 16));
            Width = IsHorizon ? 100 : 10;
            Height = IsHorizon ? 10 : 100;

            sliderColor = ForeColor;
            PageSize = 30;
            DocSize = 100;
        }

        #region 重写事件

        protected override void OnPaint(PaintEventArgs pevent)
        {
            //base.OnPaint(pevent);
            int longLen = IsHorizon ? Width : Height;
            int shortLen = IsHorizon ? Height : Width;
            capSize = shortLen / 2f;
            msMoveRange = longLen - capSize * 2 - SliderLength;

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = ClientRectangle;
            Pen pBack = new Pen(BackColor, shortLen);
            Pen pFore = new Pen(sliderColor, shortLen - 2);

            if (IsRound) {
                pBack.StartCap = pBack.EndCap = LineCap.Round;
                pFore.StartCap = pFore.EndCap = LineCap.Round;
            }

            if (IsHorizon) {
                g.DrawLine(pBack, capSize, capSize, Width - capSize, capSize);
                g.DrawLine(pFore, capSize + SliderPos, capSize, capSize + SliderPos + SliderLength, capSize);
            }
            else {
                g.DrawLine(pBack, capSize, capSize, capSize, Height - capSize);
                g.DrawLine(pFore, capSize, capSize + SliderPos, capSize, capSize + SliderPos + SliderLength);
            }

            pBack.Dispose();
            pFore.Dispose();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (DocSize > PageSize) {
                float times = Convert.ToSingle(Math.Abs(e.Delta)) / 120f;
                if (e.Delta < 0) {
                    SliderPos += SliderLength * times / 10;
                    if (SliderPos > msMoveRange) SliderPos = msMoveRange;
                    Invalidate();
                }
                else
                {
                    SliderPos -= SliderLength * times / 10;
                    if (SliderPos < 0) SliderPos = 0;
                    Invalidate();
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            int posCheck = CheckClickPos(e.Location);
            float pos = (IsHorizon ? e.Location.X : e.Location.Y) - SliderLength / 2;
            if (pos < 0) pos = 0;
            if (pos > msMoveRange) pos = msMoveRange;

            if (posCheck == -1) {
                SliderPos = pos;
                Invalidate();
            }
            else if (posCheck == 0) {
                msStatus = 0;
                msOnSliderShift = (IsHorizon ? e.Location.X : e.Location.Y) - SliderPos;
            }
            else if (posCheck == 1) {
                SliderPos = pos;
                Invalidate();
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (msStatus == 0)
                SliderPos = (IsHorizon ? e.Location.X : e.Location.Y) - msOnSliderShift;
            if (SliderPos < 0)
                SliderPos = 0;
            if (SliderPos > msMoveRange)
                SliderPos = msMoveRange;
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            msStatus = -1;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            sliderColor = OnForeColor;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            sliderColor = ForeColor;
            Invalidate();
        }

        #endregion


        #region 自定义事件

        private void SetLength()
        {
            float per = PageSize / DocSize;
            if (per >= 1) {
                SliderLength = IsHorizon ? Width - capSize * 2 : Height - capSize * 2;
                SliderPos = 0;
            }
            else
                SliderLength = per * (IsHorizon ? Width : Height);
            Invalidate();
        }

        public void MouseWheelBinding(MouseEventArgs e)
        {
            OnMouseWheel(e);
        }

        public delegate void ScrolledEventHandler(object sender, EventArgs e);
        [Description("当滚动发生时触发"), Category("自定义事件")]
        public event ScrolledEventHandler Scrolled;

        #endregion


        #region 功能函数

        private int CheckClickPos(Point pos)
        {
            int p = IsHorizon ? pos.X : pos.Y;
            if (p < SliderPos)
                return -1;
            else if (p < SliderPos + SliderLength)
                return 0;
            else
                return 1;
        }

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
