using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace ImageTool.Weights
{
    [DefaultEvent("Scrolled")]
    public partial class STrackBar : Control
    {
        // 滑动块状态
        private Color sliderColor;
        private int msStatus = 666;
        private float capSize;
        private float shortLen, longLen;

        private float sliderPos = 10;
        private bool isHorizon = true;
        private int val = 50;

        // 外观
        [Description("滑动条和背景条是否使用圆角"), Category("自定义外观")]
        public bool IsRound { get; set; } = true;
        [Description("设置滑动条方向为垂直或水平"), Category("自定义外观")]
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
        [Description("鼠标移至滑动条上方时，滑动条可拖拽处的颜色"), Category("自定义外观")]
        public Color OnForeColor { get; set; } = Color.FromArgb(Convert.ToInt32("FF00FF66", 16));

        // 数据
        [Description("滑动条上滑块位置的最小值"), Category("自定义属性")]
        public int MinNum { get; set; } = 0;
        [Description("滑动条上滑块位置的最大值"), Category("自定义属性")]
        public int MaxNum { get; set; } = 100;
        [Description("滑动条上滑块位置的当前值"), Category("自定义属性")]
        public int Value {
            get => val;
            set {
                if (val != value) {
                    val = value;
                    SliderPos = SliderRatio * longLen;
                    ValueChanged?.Invoke(this, val);
                }
            }
        }
        [Description("滑动条为响应鼠标滚轮或键盘输入（箭头键）而变化的值"), Category("自定义属性")]
        public int SmallChange { get; set; } = 1;
        [Description("滑动条为响应鼠标单击或PgUp和PgDn键而变化的值"), Category("自定义属性")]
        public int LargeChange { get; set; } = 5;

        [Browsable(false)]
        public float SliderRatio
        {
            get => Value * 1f / (MaxNum - MinNum);
            set => Value = (int)((MaxNum - MinNum) * value);
        }
        private float SliderPos {
            get => sliderPos;
            set
            {
                if (value != sliderPos)
                {
                    sliderPos = value;
                    if (sliderPos < 0)
                        sliderPos = 0;
                    else if (sliderPos > longLen)
                        sliderPos = longLen;
                    SliderRatio = sliderPos / longLen;
                    Invalidate();
                    Scrolled?.Invoke(this, Value);
                }
            }
        }


        #region 自定义事件

        public delegate void ScrolledEventHandler(object sender, int value);
        [Description("当滑动发生时触发"), Category("自定义事件")]
        public event ScrolledEventHandler Scrolled;
        public delegate void ValueChangedEventHandler(object sender, int value);
        [Description("当滑动条值改变时触发"), Category("自定义事件")]
        public event ValueChangedEventHandler ValueChanged;

        #endregion


        public STrackBar()
        {
            BackColor = Color.FromArgb(Convert.ToInt32("FFF7F7F7", 16));
            ForeColor = Color.FromArgb(Convert.ToInt32("FF33CC66", 16));

            Width = 120;
            Height = 12;
            shortLen = Height;
            longLen = Width - shortLen;
            SliderPos = longLen * SliderRatio;

            sliderColor = ForeColor;
        }

        #region 重写事件

        protected override void OnPaint(PaintEventArgs pevent)
        {
            capSize = shortLen / 2f;

            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = ClientRectangle;
            Brush bBack = new SolidBrush(Color.White);
            Brush bHead = new SolidBrush(sliderColor);
            Pen pBack = new Pen(BackColor, shortLen);
            Pen pFore = new Pen(ForeColor, shortLen);


            if (IsRound) {
                pBack.StartCap = pBack.EndCap = LineCap.Round;
                pFore.StartCap = pFore.EndCap = LineCap.Round;
            }

            g.FillRectangle(bBack, rect);
            if (IsHorizon) {
                g.DrawLine(pBack, capSize, capSize, Width - capSize, capSize);
                g.DrawLine(pFore, capSize - 0.5f, capSize - 0.5f, capSize + SliderPos, capSize - 0.5f);
                g.FillEllipse(bHead, SliderPos, -0.5f, shortLen, shortLen);
            }
            else {
                g.DrawLine(pBack, capSize, capSize, capSize, Height - capSize);
                g.DrawLine(pFore, capSize - 0.5f, Height - capSize - 0.5f, capSize - 0.5f, Height - capSize - SliderPos);
                g.FillEllipse(bHead, -0.5f, Height - SliderPos, shortLen, shortLen);
            }

            bBack.Dispose();
            bHead.Dispose();
            pBack.Dispose();
            pFore.Dispose();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.PageUp)
                SetSliderPosLarge(1);
            else if (e.KeyCode == Keys.PageDown || e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
                SetSliderPosLarge(-1);
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
                SetSliderPosSmall(1);
            else if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left)
                SetSliderPosSmall(-1);

            base.OnKeyDown(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            Focus();
            msStatus = GetMousePos(e.Location);
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            SetSliderPosLarge(e.Location, msStatus == 0 ? 0 : 666);
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            SetSliderPosLarge(e.Location, msStatus);
            msStatus = 666;
            base.OnMouseUp(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int times = e.Delta / -120;
            SetSliderPosSmall(times > 0 ? 1 : -1, Math.Abs(times));
            base.OnMouseWheel(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            sliderColor = OnForeColor;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            sliderColor = ForeColor;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            shortLen = IsHorizon ? Height : Width;
            longLen = (IsHorizon ? Width : Height) - shortLen;
            SliderPos = longLen * SliderRatio;
            base.OnSizeChanged(e);
        }

        #endregion


        private int GetMousePos(Point p)
        {
            int pos = IsHorizon? p.X: Height - p.Y;
            if (pos < SliderPos)
                return -1;
            else if (pos < SliderPos + capSize * 2)
                return 0;
            else
                return 1;
        }
        private void SetSliderPosLarge(Point p, int st)
        {
            if (st == -1) {
                Value -= LargeChange;
                //SliderPos = SliderRatio * longLen;
            }
            else if (st == 0) {
                SliderPos = (IsHorizon ? p.X : Height - p.Y) - capSize;
            }
            else if (st == 1) {
                Value += LargeChange;
                //SliderPos = SliderRatio * longLen;
            }
        }
        private void SetSliderPosLarge(int st)
        {
            if (st == -1)
            {
                Value -= LargeChange;
                //SliderPos = SliderRatio * longLen;
            }
            else if (st == 1)
            {
                Value += LargeChange;
                //SliderPos = SliderRatio * longLen;
            }
        }
        private void SetSliderPosSmall(int st, int times = 1)
        {
            if (st == -1)
            {
                Value -= SmallChange * times;
                //SliderPos = SliderRatio * longLen;
            }
            else if (st == 1)
            {
                Value += SmallChange * times;
                //SliderPos = SliderRatio * longLen;
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
}
