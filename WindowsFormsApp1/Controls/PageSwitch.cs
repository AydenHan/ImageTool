using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using ImageTool.Weights;

namespace ImageTool.Controls
{
    [DefaultEvent("PageSignal")]
    public partial class PageSwitch : UserControl
    {
        private Graphics gAsmL;

        private Panel curPanel;
        private Panel CurPanel {
            get => curPanel;
            set {
                if (value != curPanel) {
                    curPanel = value;
                    if (curPanel != null)   ScrollLengthAdjust();
                }
            }
        }

        public PageSwitch()
        {
            InitializeComponent();

            Bindings();
        }

        private void Bindings()
        {
            panel_Page.MouseWheel += AllMouseWheel;

            gAsmL = panel_AsmLine.CreateGraphics();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PropInit();
        }

        private void PropInit()
        {
            Size isize = new Size(panel_Page.Width - 20, panel_Page.Height);
            Point ipts = new Point(0, 0);
            panel_Image.Size = isize;
            panel_Graph.Size = isize;
            panel_AsmLine.Size = isize;
            panel_Image.Location = ipts;
            panel_Graph.Location = ipts;
            panel_AsmLine.Location = ipts;
            panel_Image.Show();
            panel_Graph.Hide();
            panel_AsmLine.Hide();
            CurPanel = panel_Image;
        }

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImage.Checked)
            {
                panel_Image.Show();
                panel_Graph.Hide();
                panel_AsmLine.Hide();
                rbGraph.Checked = false;
                rbAsmLine.Checked = false;
                CurPanel = panel_Image;
            }
        }
        private void rbGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGraph.Checked)
            {
                panel_Graph.Show();
                panel_Image.Hide();
                panel_AsmLine.Hide();
                rbImage.Checked = false;
                rbAsmLine.Checked = false;
                CurPanel = panel_Graph;
            }
        }
        private void rbAsmLine_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAsmLine.Checked) {
                panel_AsmLine.Show();
                panel_Image.Hide();
                panel_Graph.Hide();
                rbImage.Checked = false;
                rbGraph.Checked = false;
                CurPanel = panel_AsmLine;
                PageSignal?.Invoke(sender, e, 1);
            }
            else {
                PageSignal?.Invoke(sender, e, 0);
            }
        }

        private void ScrollLengthAdjust()
        {
            scr_Funcs.DocSize = CurPanel.Height;
            scr_Funcs.PageSize = panel_Page.Height;
        }

        private void PageSwitch_SizeChanged(object sender, EventArgs e)
        {
            scr_Funcs.Height = panel_Page.Height - 3 * 2;
            if (CurPanel != null) ScrollLengthAdjust();
        }


        // 滚动条事件
        private void AllMouseWheel(object sender, MouseEventArgs e)
        {
            scr_Funcs.Focus();
            scr_Funcs.Show();
            scr_Funcs.MouseWheelBinding(e);
        }

        private void scr_Funcs_Scrolled(object sender, EventArgs e)
        {
            CurPanel.Location = new Point(0, -(int)scr_Funcs.DocSliderDis);
        }

        private void scr_Funcs_Leave(object sender, EventArgs e)
        {
            //FuncDef.Delay(1000);
            scr_Funcs.Hide();
        }

        private void panel_Page_MouseMove(object sender, MouseEventArgs e)
        {
            scr_Funcs.Focus();
            scr_Funcs.Show();
        }


        // 自定义函数
        public void AddIGButton(SButton btn, int[] posInfo, int pageOrder)
        {
            if (pageOrder == 0) {
                btn.Location = new Point(posInfo[0], posInfo[1] + posInfo[2] * panel_Image.Controls.Count);
                panel_Image.Controls.Add(btn);
            }
            else if (pageOrder == 1) {
                btn.Location = new Point(posInfo[0], posInfo[1] + posInfo[2] * panel_Graph.Controls.Count);
                panel_Graph.Controls.Add(btn);
            }
        }

        public void AddAsmLineButton(SButton btn, int[] posInfo, MouseEventHandler[] msEvents)
        {
            btn.Location = new Point(posInfo[0], posInfo[1] + posInfo[2] * panel_AsmLine.Controls.Count);
            btn.MouseDown += msEvents[0];
            btn.MouseMove += msEvents[1];
            btn.MouseUp += msEvents[2];

            panel_AsmLine.Controls.Add(btn);
        }

        public void MoveAsmLineButton(int index, int target, int[] posInfo)
        {
            int cnt = 0;
            panel_AsmLine.Controls.SetChildIndex(panel_AsmLine.Controls[index], target);
            foreach (Control item in panel_AsmLine.Controls)
            {
                item.Location = new Point(posInfo[0], posInfo[1] + posInfo[2] * cnt);
                cnt++;
            }
        }

        public void DelAsmLineButton(int index, int[] posInfo)
        {
            int cnt = 0;
            panel_AsmLine.Controls.RemoveAt(index);
            foreach (Control item in panel_AsmLine.Controls)
            {
                item.Location = new Point(posInfo[0], posInfo[1] + posInfo[2] * cnt);
                cnt++;
            }
        }

        public void ShowMoveDotLine(int target, int[] posInfo)
        {
            ClearAsmL();

            Pen p = new Pen(Color.Gray);
            p.DashStyle = DashStyle.Dash;

            int y = posInfo[1] + posInfo[2] * (target - 1) + panel_AsmLine.Controls[0].Height + 1;
            if (y < 0) y = 1;
            gAsmL.DrawLine(p, posInfo[0], y, panel_AsmLine.Width, y);
        }

        public void ClearAsmL()
        {
            gAsmL.Clear(Color.White);
        }

        public delegate void PageSwitchEventHandler(object sender, EventArgs e, int type);
        [Description("当滚动发生时触发"), Category("自定义事件")]
        public event PageSwitchEventHandler PageSignal;
    }
}
