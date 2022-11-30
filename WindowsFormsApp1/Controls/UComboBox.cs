using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using ImageTool.Weights;
using System.Drawing.Design;

namespace ImageTool.Controls
{
    [DefaultEvent("SelectedIndexChanged")]
    public partial class UComboBox : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [Localizable(true)]
        [MergableProperty(false)]
        [Description("列表框中的项"), Category("自定义属性")]
        public ListBox.ObjectCollection Items
        {
            get => lbx.Items;
            set
            {
                if (lbx.Items != value)
                {
                    lbx.Items.Clear();
                    lbx.Items.AddRange(value);
                }
            }
        }
        
        [Description("边框的颜色"), Category("自定义属性")]
        public Color BorderColor {
            get => lbx.BorderColor;
            set {
                lbx.BorderColor = value;
                cbx.BorderColor = value;
            }
        }

        [Description("选中项或下拉按钮时的颜色"), Category("自定义属性")]
        public Color SelectedColor
        {
            get => lbx.SelectedColor;
            set {
                lbx.SelectedColor = value;
                cbx.DropAreaColor = value;
            }
        }

        [Description("是否启用圆角"), Category("自定义属性")]
        public bool UseRadius
        {
            get => lbx.UseRadius;
            set {
                lbx.UseRadius = value;
                cbx.UseRadius = value;
            }
        }

        private int selectedIndex = -1;
        [Browsable(false)]
        public int SelectedIndex
        {
            get => selectedIndex;
            set
            {
                if (selectedIndex != value)
                {
                    selectedIndex = value;
                    if (Items.Count > 0)    cbx.Text = (String)Items[selectedIndex];
                    SelectedIndexChanged?.Invoke(this, selectedIndex);
                }
            }
        }

        //public int DefaultIdx { get; set; } = 0;

        public UComboBox()
        {
            InitializeComponent();
        }

        public delegate void SelectChangeHandler(object sender, int index);
        [Description("当选项改变时触发"), Category("自定义事件")]
        public event SelectChangeHandler SelectedIndexChanged;

        private void cbx_DropBtnClick(object sender, EventArgs e)
        {
            if (Items.Count > 0)    lbx.Visible = !lbx.Visible;
            Focus();
        }

        private void lbx_ItemClick(object sender, int index)
        {
            if (Items.Count > 0)
            {
                SelectedIndex = index;
                lbx.Hide();
            }
        }
        
        private void UComboBox_SizeChanged(object sender, EventArgs e)
        {
            cbx.Width = Width;
            lbx.Width = Width;
            if (!lbx.Visible)
                Height = cbx.Height;
        }

        private void UComboBox_FontChanged(object sender, EventArgs e)
        {
            cbx.Font = Font;
            lbx.Font = Font;
        }

        private void cbx_SizeChanged(object sender, EventArgs e)
        {
            lbx.Location = new Point(0, cbx.Height - 1);
        }

        private void lbx_VisibleChanged(object sender, EventArgs e)
        {
            int height = lbx.Visible ? cbx.Height + lbx.Height - 1 : cbx.Height;
            int upRange = (int)(Parent?.ClientRectangle.Height);
            Height = upRange < Top + height ? upRange - Top : height;
            lbx.Height = Height - cbx.Height + 1;
        }

        private void UComboBox_Leave(object sender, EventArgs e)
        {
            lbx.Hide();
        }
    }
}
