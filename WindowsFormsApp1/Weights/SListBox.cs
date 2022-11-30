using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace ImageTool.Weights
{
    [DefaultEvent("ItemClick")]
    public partial class SListBox : ListBox
    {
        private ItemsList itemsList = new ItemsList();

        public Color BorderColor { get; set; } = Color.Black;
        public Color SelectedColor { get; set; } = Color.Black;
        public bool UseRadius { get; set; } = true;
        public float Radius { get; set; } = 9;

        // 禁用系统垂直滚动条
        protected override CreateParams CreateParams {
            get {
                CreateParams cp = base.CreateParams;
                cp.Style = cp.Style & ~0x200000;
                return cp;
            }
        }

        public SListBox()
        {
            InitializeComponent();

            base.DrawMode = DrawMode.OwnerDrawFixed;
            BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        #region 重写事件

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //Brush bBack = new SolidBrush(BackColor);
            Brush bFore = new SolidBrush(ForeColor);
            Pen pBorder = new Pen(BorderColor, 2);
            Radius = UseRadius ? itemsList.Interval / 2f : 0;

            StringFormat sf = StringFormat.GenericTypographic;
            sf.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;

            for (int i = itemsList.ShowItemStart; i <= itemsList.ShowItemEnd; i++) {
                Rectangle bounds = itemsList.GetRect(i);

                if (i == itemsList.MsSelItemIndex) {
                    using (Brush bSel = new SolidBrush(Color.FromArgb(33, SelectedColor))) {
                        g.FillRectangle(bSel, bounds.Left + Radius, bounds.Top, bounds.Width - Radius * 2, bounds.Height);
                        if (UseRadius) {
                            g.FillPie(bSel, bounds.Left, bounds.Top, bounds.Height, bounds.Height, 90, 180);
                            g.FillPie(bSel, bounds.Width - bounds.Height, bounds.Top, bounds.Height, bounds.Height, 270, 180);
                        }
                    }
                }
                g.DrawString(itemsList.GetString(i), Font, bFore, bounds.Height / 2, bounds.Top);
            }

            g.DrawLine(pBorder, Radius, 0, Width - 1 - Radius, 0);
            g.DrawLine(pBorder, Radius, Height - 1, Width - 1 - Radius, Height - 1);
            g.DrawLine(pBorder, 0, Radius, 0, Height - 1 - Radius);
            g.DrawLine(pBorder, Width - 1, Radius, Width - 1, Height - 1 - Radius);
            if (UseRadius) {
                g.DrawArc(pBorder, 0, 0, Radius * 2, Radius * 2, 180, 90);
                g.DrawArc(pBorder, Width - 1 - Radius * 2, 0, Radius * 2, Radius * 2, 270, 90);
                g.DrawArc(pBorder, 0, Height - 1 - Radius * 2, Radius * 2, Radius * 2, 90, 90);
                g.DrawArc(pBorder, Width - 1 - Radius * 2, Height - 1 - Radius * 2, Radius * 2, Radius * 2, 0, 90);
            }
            if (!itemsList.IsShowAll) {
                g.DrawLine(pBorder, Width / 2f - 4, Height - 5, Width / 2f - 1, Height - 2);
                g.DrawLine(pBorder, Width / 2f + 2, Height - 5, Width / 2f - 1, Height - 2);
            }
            bFore.Dispose();
            pBorder.Dispose();
            base.OnPaint(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible && Items.Count > 0) {
                int txtHeight = (int)(CreateGraphics().MeasureString("abc", Font).Height);
                itemsList.DataBinding(Items, GetItemRectangle(0), txtHeight, Margin.Vertical);
                // TODO: 13不确定是否为恒定值
                Height = (itemsList.ListHeight / 13 + 1) * 13;
            }
            base.OnVisibleChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (Items.Count > 0) itemsList.ViewHeight = Height;
            base.OnSizeChanged(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            int times = (int)(Convert.ToSingle(e.Delta) / -120f);
            itemsList.ChangeStartIndex(times);
            Invalidate();
            base.OnMouseWheel(e);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            ItemClick?.Invoke(this, itemsList.MsSelItemIndex);
            base.OnMouseClick(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            itemsList.GetMsSelItemIndex(e.Location);
            base.OnMouseMove(e);
            Invalidate();
        }

        #endregion


        #region 自定义函数

        public delegate void SelectItemHandler(object sender, int index);
        [Description("当点击选项时触发"), Category("自定义事件")]
        public event SelectItemHandler ItemClick;

        #endregion

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);
        }
    }
    
    public class ItemsList
    {
        public int ShowItemsNum {
            get => ViewHeight < ListHeight ? ViewHeight / Interval : Count; }
        public int ShowItemStart { get; set; } = 0;
        public int ShowItemEnd { get => ShowItemsNum + ShowItemStart - 1; }
        public int MsSelItemIndex { get; private set; } = -1;
        public bool IsShowAll { get => ShowItemsNum == Count; }
        public int Interval { get; private set; }
        public int Margin { get; private set; }
        public int Count { get; private set; }
        public int ListHeight { get => Interval * Count + Margin; }
        public int ViewHeight { get; set; }

        private List<String> Contents = new List<String>();
        private Rectangle AnchorRect;

        public ItemsList() {
            ShowItemStart = 0;
            Count = 0;
            AnchorRect = new Rectangle(0,0,10,10);
            Interval = 12;
            Margin = 6;
        }

        public void DataBinding(ListBox.ObjectCollection items, Rectangle anchor, int interval, int margin)
        {
            Contents.Clear();
            foreach (var item in items)
                Contents.Add((String)item);
            ShowItemStart = 0;

            Count = items.Count;
            AnchorRect = anchor;
            Interval = interval;
            Margin = margin;
        }

        public Rectangle GetRect(int index)
        {
            return new Rectangle(AnchorRect.X, 
                2 + (index - ShowItemStart) * Interval, 
                AnchorRect.Width, Interval);
        }

        public String GetString(int index)
        {
            return Contents[index];
        }

        public void GetMsSelItemIndex(Point p)
        {
            for (int i = ShowItemStart; i <= ShowItemEnd; i++) {
                if (GetRect(i).Contains(p)) {
                    MsSelItemIndex = i;
                    break;
                }
            }
        }

        public void ChangeStartIndex(int times)
        {
            int idx = ShowItemStart + times;
            if (idx >= 0 && idx <= Count - ShowItemsNum)
                ShowItemStart = idx;
        }
    }

}
