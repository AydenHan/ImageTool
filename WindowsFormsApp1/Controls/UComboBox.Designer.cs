namespace ImageTool.Controls
{
    partial class UComboBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.cbx = new ImageTool.Weights.SComboBox();
            this.lbx = new ImageTool.Weights.SListBox();
            this.SuspendLayout();
            // 
            // cbx
            // 
            this.cbx.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbx.BorderColor = System.Drawing.Color.Black;
            this.cbx.DropAreaColor = System.Drawing.Color.Black;
            this.cbx.Location = new System.Drawing.Point(0, 0);
            this.cbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbx.Name = "cbx";
            this.cbx.Size = new System.Drawing.Size(144, 26);
            this.cbx.TabIndex = 0;
            this.cbx.UseRadius = true;
            this.cbx.DropBtnClick += new ImageTool.Weights.SComboBox.ShowListHandler(this.cbx_DropBtnClick);
            this.cbx.SizeChanged += new System.EventHandler(this.cbx_SizeChanged);
            // 
            // lbx
            // 
            this.lbx.BorderColor = System.Drawing.Color.Black;
            this.lbx.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbx.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbx.FormattingEnabled = true;
            this.lbx.Location = new System.Drawing.Point(0, 25);
            this.lbx.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lbx.Name = "lbx";
            this.lbx.Radius = 0F;
            this.lbx.SelectedColor = System.Drawing.Color.Black;
            this.lbx.Size = new System.Drawing.Size(144, 39);
            this.lbx.TabIndex = 1;
            this.lbx.UseRadius = true;
            this.lbx.Visible = false;
            this.lbx.ItemClick += new ImageTool.Weights.SListBox.SelectItemHandler(this.lbx_ItemClick);
            this.lbx.VisibleChanged += new System.EventHandler(this.lbx_VisibleChanged);
            // 
            // UComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.cbx);
            this.Controls.Add(this.lbx);
            this.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UComboBox";
            this.Size = new System.Drawing.Size(144, 26);
            this.FontChanged += new System.EventHandler(this.UComboBox_FontChanged);
            this.SizeChanged += new System.EventHandler(this.UComboBox_SizeChanged);
            this.Leave += new System.EventHandler(this.UComboBox_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private Weights.SComboBox cbx;
        private Weights.SListBox lbx;
    }
}
