﻿namespace ImageTool
{
    partial class Image_Form
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

        public UserControl userControl1 = new ImageTool.UserControl();

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.userControl1 = new ImageTool.UserControl();
            this.SuspendLayout();
            // 
            // userControl1
            // 
            this.userControl1.Location = new System.Drawing.Point(12, 12);
            this.userControl1.Name = "userControl1";
            this.userControl1.Size = new System.Drawing.Size(889, 648);
            this.userControl1.TabIndex = 0;
            // 
            // Image_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 673);
            this.Controls.Add(this.userControl1);
            this.Name = "Image_Form";
            this.Text = "图像处理";
            this.ResumeLayout(false);

        }

        #endregion

    }
}

