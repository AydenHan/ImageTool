namespace ImageTool.Controls
{
    partial class PageSwitch
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
            this.panel_Image = new System.Windows.Forms.Panel();
            this.tblp_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Control = new System.Windows.Forms.Panel();
            this.rbAsmLine = new ImageTool.Weights.SRadioButton();
            this.rbGraph = new ImageTool.Weights.SRadioButton();
            this.rbImage = new ImageTool.Weights.SRadioButton();
            this.panel_Page = new System.Windows.Forms.Panel();
            this.scr_Funcs = new ImageTool.Weights.SScroll();
            this.panel_Graph = new System.Windows.Forms.Panel();
            this.panel_AsmLine = new System.Windows.Forms.Panel();
            this.tblp_Main.SuspendLayout();
            this.panel_Control.SuspendLayout();
            this.panel_Page.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Image
            // 
            this.panel_Image.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_Image.AutoSize = true;
            this.panel_Image.Location = new System.Drawing.Point(17, 27);
            this.panel_Image.Margin = new System.Windows.Forms.Padding(1);
            this.panel_Image.Name = "panel_Image";
            this.panel_Image.Size = new System.Drawing.Size(200, 350);
            this.panel_Image.TabIndex = 36;
            // 
            // tblp_Main
            // 
            this.tblp_Main.ColumnCount = 1;
            this.tblp_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Main.Controls.Add(this.panel_Control, 0, 1);
            this.tblp_Main.Controls.Add(this.panel_Page, 0, 0);
            this.tblp_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblp_Main.Location = new System.Drawing.Point(0, 0);
            this.tblp_Main.Name = "tblp_Main";
            this.tblp_Main.RowCount = 2;
            this.tblp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblp_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tblp_Main.Size = new System.Drawing.Size(287, 472);
            this.tblp_Main.TabIndex = 37;
            // 
            // panel_Control
            // 
            this.panel_Control.Controls.Add(this.rbAsmLine);
            this.panel_Control.Controls.Add(this.rbGraph);
            this.panel_Control.Controls.Add(this.rbImage);
            this.panel_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Control.Location = new System.Drawing.Point(3, 432);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(281, 37);
            this.panel_Control.TabIndex = 0;
            // 
            // rbAsmLine
            // 
            this.rbAsmLine.AutoSize = true;
            this.rbAsmLine.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(190)))), ((int)(((byte)(77)))));
            this.rbAsmLine.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.rbAsmLine.ForeCheckColor = System.Drawing.Color.White;
            this.rbAsmLine.Location = new System.Drawing.Point(168, 7);
            this.rbAsmLine.Name = "rbAsmLine";
            this.rbAsmLine.Size = new System.Drawing.Size(66, 23);
            this.rbAsmLine.TabIndex = 42;
            this.rbAsmLine.Text = "流水线";
            this.rbAsmLine.UseVisualStyleBackColor = true;
            this.rbAsmLine.CheckedChanged += new System.EventHandler(this.rbAsmLine_CheckedChanged);
            // 
            // rbGraph
            // 
            this.rbGraph.AutoSize = true;
            this.rbGraph.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(190)))), ((int)(((byte)(77)))));
            this.rbGraph.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.rbGraph.ForeCheckColor = System.Drawing.Color.White;
            this.rbGraph.Location = new System.Drawing.Point(93, 7);
            this.rbGraph.Name = "rbGraph";
            this.rbGraph.Size = new System.Drawing.Size(53, 23);
            this.rbGraph.TabIndex = 41;
            this.rbGraph.Text = "图形";
            this.rbGraph.UseVisualStyleBackColor = true;
            this.rbGraph.CheckedChanged += new System.EventHandler(this.rbGraph_CheckedChanged);
            // 
            // rbImage
            // 
            this.rbImage.AutoSize = true;
            this.rbImage.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(190)))), ((int)(((byte)(77)))));
            this.rbImage.Checked = true;
            this.rbImage.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.rbImage.ForeCheckColor = System.Drawing.Color.White;
            this.rbImage.Location = new System.Drawing.Point(18, 7);
            this.rbImage.Name = "rbImage";
            this.rbImage.Size = new System.Drawing.Size(53, 23);
            this.rbImage.TabIndex = 40;
            this.rbImage.TabStop = true;
            this.rbImage.Text = "图像";
            this.rbImage.UseVisualStyleBackColor = true;
            this.rbImage.CheckedChanged += new System.EventHandler(this.rbImage_CheckedChanged);
            // 
            // panel_Page
            // 
            this.panel_Page.Controls.Add(this.scr_Funcs);
            this.panel_Page.Controls.Add(this.panel_Image);
            this.panel_Page.Controls.Add(this.panel_Graph);
            this.panel_Page.Controls.Add(this.panel_AsmLine);
            this.panel_Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Page.Location = new System.Drawing.Point(3, 3);
            this.panel_Page.Name = "panel_Page";
            this.panel_Page.Size = new System.Drawing.Size(281, 423);
            this.panel_Page.TabIndex = 1;
            this.panel_Page.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_Page_MouseMove);
            // 
            // scr_Funcs
            // 
            this.scr_Funcs.BackColor = System.Drawing.Color.White;
            this.scr_Funcs.DocSize = 100F;
            this.scr_Funcs.DocSliderDis = 0F;
            this.scr_Funcs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.scr_Funcs.IsHorizon = false;
            this.scr_Funcs.IsRound = true;
            this.scr_Funcs.Location = new System.Drawing.Point(263, 3);
            this.scr_Funcs.Name = "scr_Funcs";
            this.scr_Funcs.OnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.scr_Funcs.PageSize = 30F;
            this.scr_Funcs.Size = new System.Drawing.Size(10, 411);
            this.scr_Funcs.SliderLength = 30F;
            this.scr_Funcs.TabIndex = 39;
            this.scr_Funcs.Text = "uiScroll1";
            this.scr_Funcs.Scrolled += new ImageTool.Weights.SScroll.ScrolledEventHandler(this.scr_Funcs_Scrolled);
            this.scr_Funcs.Leave += new System.EventHandler(this.scr_Funcs_Leave);
            // 
            // panel_Graph
            // 
            this.panel_Graph.AutoScroll = true;
            this.panel_Graph.AutoScrollMinSize = new System.Drawing.Size(200, 300);
            this.panel_Graph.AutoSize = true;
            this.panel_Graph.Location = new System.Drawing.Point(30, 39);
            this.panel_Graph.Margin = new System.Windows.Forms.Padding(1);
            this.panel_Graph.Name = "panel_Graph";
            this.panel_Graph.Size = new System.Drawing.Size(200, 350);
            this.panel_Graph.TabIndex = 38;
            // 
            // panel_AsmLine
            // 
            this.panel_AsmLine.AutoSize = true;
            this.panel_AsmLine.Location = new System.Drawing.Point(46, 56);
            this.panel_AsmLine.Margin = new System.Windows.Forms.Padding(1);
            this.panel_AsmLine.Name = "panel_AsmLine";
            this.panel_AsmLine.Size = new System.Drawing.Size(200, 350);
            this.panel_AsmLine.TabIndex = 0;
            // 
            // PageSwitch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tblp_Main);
            this.Name = "PageSwitch";
            this.Size = new System.Drawing.Size(287, 472);
            this.SizeChanged += new System.EventHandler(this.PageSwitch_SizeChanged);
            this.tblp_Main.ResumeLayout(false);
            this.panel_Control.ResumeLayout(false);
            this.panel_Control.PerformLayout();
            this.panel_Page.ResumeLayout(false);
            this.panel_Page.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tblp_Main;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Panel panel_Page;
        public System.Windows.Forms.Panel panel_Image;
        public System.Windows.Forms.Panel panel_Graph;
        public System.Windows.Forms.Panel panel_AsmLine;
        private Weights.SScroll scr_Funcs;
        private Weights.SRadioButton rbGraph;
        private Weights.SRadioButton rbImage;
        private Weights.SRadioButton rbAsmLine;
    }
}
