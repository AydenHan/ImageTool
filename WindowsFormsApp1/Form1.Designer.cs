namespace ImageTool
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Image_Form));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle37 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle38 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle39 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle40 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tlPanel_Main = new System.Windows.Forms.TableLayoutPanel();
            this.panel_Display = new System.Windows.Forms.Panel();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip_Image = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsItem_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_Control = new System.Windows.Forms.Panel();
            this.cb_BackUp = new ImageTool.Controls.UComboBox();
            this.btn_BackOnce = new ImageTool.Weights.SButton();
            this.btn_Start = new ImageTool.Weights.SButton();
            this.btn_Load = new ImageTool.Weights.SButton();
            this.lbl_Size = new System.Windows.Forms.Label();
            this.lbl_MouseHSV = new System.Windows.Forms.Label();
            this.lbl_MouseRGB = new System.Windows.Forms.Label();
            this.lbl_MousePos = new System.Windows.Forms.Label();
            this.ss_Status = new System.Windows.Forms.StatusStrip();
            this.tssl_Path = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Error = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssb_AddRegister = new System.Windows.Forms.ToolStripSplitButton();
            this.tssl_Runtime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_RtLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssl_Func = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel_ToolBar = new System.Windows.Forms.Panel();
            this.cbx_AsmLine = new ImageTool.Weights.SCheckBox();
            this.btn_ToolCut = new System.Windows.Forms.Button();
            this.btn_ToolGraphClear = new System.Windows.Forms.Button();
            this.btn_ToolRect = new System.Windows.Forms.Button();
            this.btn_ToolPRect = new System.Windows.Forms.Button();
            this.btn_ToolCircle = new System.Windows.Forms.Button();
            this.btn_ToolLine = new System.Windows.Forms.Button();
            this.btn_ToolPts = new System.Windows.Forms.Button();
            this.tc_Image = new System.Windows.Forms.TabControl();
            this.tabPage_ImageInfo = new System.Windows.Forms.TabPage();
            this.btn_ImageHandleForm = new ImageTool.Weights.SButton();
            this.lbl_CalibratePts = new System.Windows.Forms.Label();
            this.tb_CalibratePts = new System.Windows.Forms.TextBox();
            this.lbl_BorWData = new System.Windows.Forms.Label();
            this.lbl_PixelMean = new System.Windows.Forms.Label();
            this.tabPage_CutImage = new System.Windows.Forms.TabPage();
            this.label_CutRect = new System.Windows.Forms.Label();
            this.label_StartXY = new System.Windows.Forms.Label();
            this.nud_CutH = new System.Windows.Forms.NumericUpDown();
            this.nud_CutW = new System.Windows.Forms.NumericUpDown();
            this.nud_CutY = new System.Windows.Forms.NumericUpDown();
            this.label_CutSize = new System.Windows.Forms.Label();
            this.label_CutStartPos = new System.Windows.Forms.Label();
            this.nud_CutX = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Resize = new System.Windows.Forms.TabPage();
            this.ckb_Resize = new ImageTool.Weights.SCheckBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tb_ResizeH = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.tb_ResizeW = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tb_ResizeHScale = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tb_ResizeWScale = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.tabPage_Rotate = new System.Windows.Forms.TabPage();
            this.tkb_RotateAngle = new ImageTool.Weights.STrackBar();
            this.label45 = new System.Windows.Forms.Label();
            this.tb_RotateCenterY = new System.Windows.Forms.TextBox();
            this.tb_RotateCenterX = new System.Windows.Forms.TextBox();
            this.tb_RotateAngle = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tabPage_Median = new System.Windows.Forms.TabPage();
            this.label_Kernel = new System.Windows.Forms.Label();
            this.nud_Median = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Gaussian = new System.Windows.Forms.TabPage();
            this.tb_gsKer = new System.Windows.Forms.TextBox();
            this.tb_gsSigma = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.tabPage_Gray = new System.Windows.Forms.TabPage();
            this.cb_GrayChannel = new ImageTool.Controls.UComboBox();
            this.tabPage_Binary = new System.Windows.Forms.TabPage();
            this.cb_ThresType = new ImageTool.Controls.UComboBox();
            this.gb_ExtendBox = new System.Windows.Forms.GroupBox();
            this.cb_Adaptive = new ImageTool.Controls.UComboBox();
            this.tb_AdaptiveDelta = new System.Windows.Forms.TextBox();
            this.lbl_Adaptive3 = new System.Windows.Forms.Label();
            this.tb_AdaptiveSize = new System.Windows.Forms.TextBox();
            this.lbl_Adaptive2 = new System.Windows.Forms.Label();
            this.lbl_Adaptive1 = new System.Windows.Forms.Label();
            this.lbl_OTSU = new System.Windows.Forms.Label();
            this.gb_BasicBox = new System.Windows.Forms.GroupBox();
            this.label15 = new System.Windows.Forms.Label();
            this.nud_BinarySel = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.nud_MaxPixelVal = new System.Windows.Forms.NumericUpDown();
            this.nud_BinaryThres = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage_EdgeDetect = new System.Windows.Forms.TabPage();
            this.cb_EdgeDetect = new ImageTool.Controls.UComboBox();
            this.gb_CannyPara = new System.Windows.Forms.GroupBox();
            this.tb_GSKsize = new System.Windows.Forms.TextBox();
            this.tb_HighThres = new System.Windows.Forms.TextBox();
            this.tb_LowThres = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gb_Sobel = new System.Windows.Forms.GroupBox();
            this.tb_SobelKsize = new System.Windows.Forms.TextBox();
            this.tb_Sobeldy = new System.Windows.Forms.TextBox();
            this.tb_Sobeldx = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.gb_Laplacian = new System.Windows.Forms.GroupBox();
            this.tb_LapKsize = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPage_Dilate = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.nud_DilateKerY = new System.Windows.Forms.NumericUpDown();
            this.label_DilateKernel = new System.Windows.Forms.Label();
            this.nud_DilateKerX = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Erode = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.nud_ErodeKerY = new System.Windows.Forms.NumericUpDown();
            this.label_ErodeKernel = new System.Windows.Forms.Label();
            this.nud_ErodeKerX = new System.Windows.Forms.NumericUpDown();
            this.tabPage_FindContours = new System.Windows.Forms.TabPage();
            this.cbx_ConMinPRect = new ImageTool.Weights.SCheckBox();
            this.cbx_ConMinRect = new ImageTool.Weights.SCheckBox();
            this.lbl_ConPointNum = new System.Windows.Forms.Label();
            this.lbl_ConArea = new System.Windows.Forms.Label();
            this.lbl_ConNum = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_ConRect = new System.Windows.Forms.TextBox();
            this.tb_ConCtr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nud_ConIdx = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Substract = new System.Windows.Forms.TabPage();
            this.btn_SubImage = new ImageTool.Weights.SButton();
            this.cbx_UseAbs = new ImageTool.Weights.SCheckBox();
            this.panel_SubDisplay = new System.Windows.Forms.Panel();
            this.pb_Substract = new System.Windows.Forms.PictureBox();
            this.tb_SubScale = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.tabPage_AddImage = new System.Windows.Forms.TabPage();
            this.btn_AddImage = new ImageTool.Weights.SButton();
            this.panel_AddDisplay = new System.Windows.Forms.Panel();
            this.pb_AddImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage_ConnectArea = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_Area = new System.Windows.Forms.Label();
            this.tb_AreaCtr = new System.Windows.Forms.TextBox();
            this.tb_AreaRect = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.tb_AreaMin = new System.Windows.Forms.TextBox();
            this.tb_AreaMaxNum = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.nud_AreaIdx = new System.Windows.Forms.NumericUpDown();
            this.tabPage_HoughDetect = new System.Windows.Forms.TabPage();
            this.cb_HoughDetect = new ImageTool.Controls.UComboBox();
            this.gb_HoughLineP = new System.Windows.Forms.GroupBox();
            this.tb_LineMaxGap = new System.Windows.Forms.TextBox();
            this.tb_LineMinLen = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tb_LineRHO = new System.Windows.Forms.TextBox();
            this.tb_LineThres = new System.Windows.Forms.TextBox();
            this.tb_LineTheta = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.tabPage_Perspective = new System.Windows.Forms.TabPage();
            this.btn_PersDstPts = new ImageTool.Weights.SButton();
            this.btn_PersSrcPts = new ImageTool.Weights.SButton();
            this.cb_PersSize = new System.Windows.Forms.ComboBox();
            this.tb_PersHeight = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.tb_PersWidth = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.tb_PersDstPts = new System.Windows.Forms.TextBox();
            this.tb_PersSrcPts = new System.Windows.Forms.TextBox();
            this.tabPage_Equalize = new System.Windows.Forms.TabPage();
            this.tabPage_Normalize = new System.Windows.Forms.TabPage();
            this.tb_NormHigh = new System.Windows.Forms.TextBox();
            this.tb_NormLow = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.tabPage_DrawCanvas = new System.Windows.Forms.TabPage();
            this.tb_CanvasC = new System.Windows.Forms.TextBox();
            this.tb_CanvasH = new System.Windows.Forms.TextBox();
            this.tb_CanvasW = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.pnl_CanvasColor = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.nud_CanvasB = new System.Windows.Forms.NumericUpDown();
            this.nud_CanvasG = new System.Windows.Forms.NumericUpDown();
            this.nud_CanvasR = new System.Windows.Forms.NumericUpDown();
            this.tabPage_DrawPts = new System.Windows.Forms.TabPage();
            this.tb_PtsSet = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.pnl_PtsColor = new System.Windows.Forms.Panel();
            this.label41 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.nud_PtsB = new System.Windows.Forms.NumericUpDown();
            this.nud_PtsG = new System.Windows.Forms.NumericUpDown();
            this.nud_PtsR = new System.Windows.Forms.NumericUpDown();
            this.nud_PtsThick = new System.Windows.Forms.NumericUpDown();
            this.tabPage_DrawLine = new System.Windows.Forms.TabPage();
            this.pnl_LineColor = new System.Windows.Forms.Panel();
            this.Grid_Line = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_LineThickness = new System.Windows.Forms.Label();
            this.label_LineColor = new System.Windows.Forms.Label();
            this.nud_LineB = new System.Windows.Forms.NumericUpDown();
            this.nud_LineG = new System.Windows.Forms.NumericUpDown();
            this.nud_LineR = new System.Windows.Forms.NumericUpDown();
            this.nud_LineThick = new System.Windows.Forms.NumericUpDown();
            this.label_LinePos = new System.Windows.Forms.Label();
            this.tabPage_DrawRect = new System.Windows.Forms.TabPage();
            this.cbx_IsPRect = new ImageTool.Weights.SCheckBox();
            this.pnl_RectColor = new System.Windows.Forms.Panel();
            this.Grid_Rect = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_RectThickness = new System.Windows.Forms.Label();
            this.label_RectColor = new System.Windows.Forms.Label();
            this.nud_RectB = new System.Windows.Forms.NumericUpDown();
            this.nud_RectG = new System.Windows.Forms.NumericUpDown();
            this.nud_RectR = new System.Windows.Forms.NumericUpDown();
            this.nud_RectThick = new System.Windows.Forms.NumericUpDown();
            this.label_RectPos = new System.Windows.Forms.Label();
            this.tabPage_DrawCircle = new System.Windows.Forms.TabPage();
            this.pnl_CircleColor = new System.Windows.Forms.Panel();
            this.Grid_Circle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.R = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label_CircleThickness = new System.Windows.Forms.Label();
            this.label_CircleColor = new System.Windows.Forms.Label();
            this.nud_CircleB = new System.Windows.Forms.NumericUpDown();
            this.nud_CircleG = new System.Windows.Forms.NumericUpDown();
            this.nud_CircleR = new System.Windows.Forms.NumericUpDown();
            this.nud_CircleThick = new System.Windows.Forms.NumericUpDown();
            this.label_CirclePos = new System.Windows.Forms.Label();
            this.tabPage_Flip = new System.Windows.Forms.TabPage();
            this.label47 = new System.Windows.Forms.Label();
            this.tb_FlipDirect = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.tabPage_Thin = new System.Windows.Forms.TabPage();
            this.cb_ThinTypes = new ImageTool.Controls.UComboBox();
            this.tabPage_HSV2Binary = new System.Windows.Forms.TabPage();
            this.btn_ExportHSV = new ImageTool.Weights.SButton();
            this.nud_HighV = new System.Windows.Forms.NumericUpDown();
            this.label_Value = new System.Windows.Forms.Label();
            this.nud_LowV = new System.Windows.Forms.NumericUpDown();
            this.nud_HighS = new System.Windows.Forms.NumericUpDown();
            this.label_Saturability = new System.Windows.Forms.Label();
            this.nud_LowS = new System.Windows.Forms.NumericUpDown();
            this.nud_HighH = new System.Windows.Forms.NumericUpDown();
            this.label_Hue = new System.Windows.Forms.Label();
            this.nud_LowH = new System.Windows.Forms.NumericUpDown();
            this.tabPage_Bilateral = new System.Windows.Forms.TabPage();
            this.tb_bilaSpace = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.tb_bilaKSize = new System.Windows.Forms.TextBox();
            this.tb_bilaColor = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.tabPage_Gray2RGB = new System.Windows.Forms.TabPage();
            this.cb_ColorMapTypes = new ImageTool.Controls.UComboBox();
            this.tabPage_fitLine = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_FitLinePos2 = new System.Windows.Forms.TextBox();
            this.textBox_FitLinePos1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView_FitLine = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_LineCross = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridView_CrossPos = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_CrossPos = new System.Windows.Forms.TextBox();
            this.label_CrossPos = new System.Windows.Forms.Label();
            this.tabPage_UserDef = new System.Windows.Forms.TabPage();
            this.cb_UserDef = new System.Windows.Forms.ComboBox();
            this.tb_UserDef1 = new System.Windows.Forms.TextBox();
            this.ps_Funcs = new ImageTool.Controls.PageSwitch();
            this.toolTip_UseRemark = new System.Windows.Forms.ToolTip(this.components);
            this.tlPanel_Main.SuspendLayout();
            this.panel_Display.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.contextMenuStrip_Image.SuspendLayout();
            this.panel_Control.SuspendLayout();
            this.ss_Status.SuspendLayout();
            this.panel_ToolBar.SuspendLayout();
            this.tc_Image.SuspendLayout();
            this.tabPage_ImageInfo.SuspendLayout();
            this.tabPage_CutImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutX)).BeginInit();
            this.tabPage_Resize.SuspendLayout();
            this.tabPage_Rotate.SuspendLayout();
            this.tabPage_Median.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Median)).BeginInit();
            this.tabPage_Gaussian.SuspendLayout();
            this.tabPage_Gray.SuspendLayout();
            this.tabPage_Binary.SuspendLayout();
            this.gb_ExtendBox.SuspendLayout();
            this.gb_BasicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BinarySel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxPixelVal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BinaryThres)).BeginInit();
            this.tabPage_EdgeDetect.SuspendLayout();
            this.gb_CannyPara.SuspendLayout();
            this.gb_Sobel.SuspendLayout();
            this.gb_Laplacian.SuspendLayout();
            this.tabPage_Dilate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DilateKerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DilateKerX)).BeginInit();
            this.tabPage_Erode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErodeKerY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErodeKerX)).BeginInit();
            this.tabPage_FindContours.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ConIdx)).BeginInit();
            this.tabPage_Substract.SuspendLayout();
            this.panel_SubDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Substract)).BeginInit();
            this.tabPage_AddImage.SuspendLayout();
            this.panel_AddDisplay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddImage)).BeginInit();
            this.tabPage_ConnectArea.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AreaIdx)).BeginInit();
            this.tabPage_HoughDetect.SuspendLayout();
            this.gb_HoughLineP.SuspendLayout();
            this.tabPage_Perspective.SuspendLayout();
            this.tabPage_Normalize.SuspendLayout();
            this.tabPage_DrawCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasR)).BeginInit();
            this.tabPage_DrawPts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsThick)).BeginInit();
            this.tabPage_DrawLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Line)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineThick)).BeginInit();
            this.tabPage_DrawRect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Rect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectThick)).BeginInit();
            this.tabPage_DrawCircle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Circle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleThick)).BeginInit();
            this.tabPage_Flip.SuspendLayout();
            this.tabPage_Thin.SuspendLayout();
            this.tabPage_HSV2Binary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowH)).BeginInit();
            this.tabPage_Bilateral.SuspendLayout();
            this.tabPage_Gray2RGB.SuspendLayout();
            this.tabPage_fitLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FitLine)).BeginInit();
            this.tabPage_LineCross.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CrossPos)).BeginInit();
            this.tabPage_UserDef.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlPanel_Main
            // 
            this.tlPanel_Main.ColumnCount = 2;
            this.tlPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanel_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tlPanel_Main.Controls.Add(this.panel_Display, 0, 0);
            this.tlPanel_Main.Controls.Add(this.panel_Control, 1, 2);
            this.tlPanel_Main.Controls.Add(this.ss_Status, 0, 3);
            this.tlPanel_Main.Controls.Add(this.panel_ToolBar, 0, 1);
            this.tlPanel_Main.Controls.Add(this.tc_Image, 0, 2);
            this.tlPanel_Main.Controls.Add(this.ps_Funcs, 1, 0);
            this.tlPanel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlPanel_Main.Location = new System.Drawing.Point(0, 0);
            this.tlPanel_Main.Name = "tlPanel_Main";
            this.tlPanel_Main.RowCount = 4;
            this.tlPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 207F));
            this.tlPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlPanel_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlPanel_Main.Size = new System.Drawing.Size(923, 703);
            this.tlPanel_Main.TabIndex = 40;
            // 
            // panel_Display
            // 
            this.panel_Display.Controls.Add(this.picBox);
            this.panel_Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Display.Location = new System.Drawing.Point(3, 3);
            this.panel_Display.Name = "panel_Display";
            this.panel_Display.Size = new System.Drawing.Size(624, 422);
            this.panel_Display.TabIndex = 27;
            // 
            // picBox
            // 
            this.picBox.AllowDrop = true;
            this.picBox.ContextMenuStrip = this.contextMenuStrip_Image;
            this.picBox.Location = new System.Drawing.Point(9, 9);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(602, 402);
            this.picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBox.TabIndex = 1;
            this.picBox.TabStop = false;
            this.picBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
            this.picBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragDrop);
            this.picBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.pictureBox_DragEnter);
            this.picBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
            this.picBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            this.picBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            this.picBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
            // 
            // contextMenuStrip_Image
            // 
            this.contextMenuStrip_Image.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsItem_Save,
            this.cmsItem_SaveAs});
            this.contextMenuStrip_Image.Name = "contextMenuStrip_Image";
            this.contextMenuStrip_Image.Size = new System.Drawing.Size(113, 48);
            // 
            // cmsItem_Save
            // 
            this.cmsItem_Save.Name = "cmsItem_Save";
            this.cmsItem_Save.Size = new System.Drawing.Size(112, 22);
            this.cmsItem_Save.Text = "保存";
            this.cmsItem_Save.Click += new System.EventHandler(this.cmsItem_Save_Click);
            // 
            // cmsItem_SaveAs
            // 
            this.cmsItem_SaveAs.Name = "cmsItem_SaveAs";
            this.cmsItem_SaveAs.Size = new System.Drawing.Size(112, 22);
            this.cmsItem_SaveAs.Text = "另存为";
            this.cmsItem_SaveAs.Click += new System.EventHandler(this.cmsItem_SaveAs_Click);
            // 
            // panel_Control
            // 
            this.panel_Control.Controls.Add(this.cb_BackUp);
            this.panel_Control.Controls.Add(this.btn_BackOnce);
            this.panel_Control.Controls.Add(this.btn_Start);
            this.panel_Control.Controls.Add(this.btn_Load);
            this.panel_Control.Controls.Add(this.lbl_Size);
            this.panel_Control.Controls.Add(this.lbl_MouseHSV);
            this.panel_Control.Controls.Add(this.lbl_MouseRGB);
            this.panel_Control.Controls.Add(this.lbl_MousePos);
            this.panel_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Control.Location = new System.Drawing.Point(633, 474);
            this.panel_Control.Name = "panel_Control";
            this.panel_Control.Size = new System.Drawing.Size(287, 201);
            this.panel_Control.TabIndex = 37;
            // 
            // cb_BackUp
            // 
            this.cb_BackUp.BackColor = System.Drawing.Color.Transparent;
            this.cb_BackUp.BorderColor = System.Drawing.Color.MediumOrchid;
            this.cb_BackUp.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_BackUp.Location = new System.Drawing.Point(19, 69);
            this.cb_BackUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_BackUp.Name = "cb_BackUp";
            this.cb_BackUp.SelectedColor = System.Drawing.Color.DeepSkyBlue;
            this.cb_BackUp.SelectedIndex = 1;
            this.cb_BackUp.Size = new System.Drawing.Size(120, 26);
            this.cb_BackUp.TabIndex = 35;
            this.cb_BackUp.UseRadius = true;
            this.cb_BackUp.SelectedIndexChanged += new ImageTool.Controls.UComboBox.SelectChangeHandler(this.cb_BackUp_SelectedIndexChanged);
            // 
            // btn_BackOnce
            // 
            this.btn_BackOnce.BackColor = System.Drawing.Color.White;
            this.btn_BackOnce.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_BackOnce.FlatAppearance.BorderSize = 2;
            this.btn_BackOnce.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btn_BackOnce.ForeColor = System.Drawing.Color.Black;
            this.btn_BackOnce.Location = new System.Drawing.Point(149, 68);
            this.btn_BackOnce.Name = "btn_BackOnce";
            this.btn_BackOnce.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_BackOnce.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_BackOnce.Radius = 12;
            this.btn_BackOnce.Size = new System.Drawing.Size(120, 30);
            this.btn_BackOnce.TabIndex = 34;
            this.btn_BackOnce.Text = "撤销";
            this.btn_BackOnce.UseVisualStyleBackColor = false;
            this.btn_BackOnce.Click += new System.EventHandler(this.button_backOnce_Click);
            // 
            // btn_Start
            // 
            this.btn_Start.BackColor = System.Drawing.Color.White;
            this.btn_Start.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Start.FlatAppearance.BorderSize = 2;
            this.btn_Start.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btn_Start.ForeColor = System.Drawing.Color.Black;
            this.btn_Start.Location = new System.Drawing.Point(149, 31);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_Start.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_Start.Radius = 12;
            this.btn_Start.Size = new System.Drawing.Size(120, 30);
            this.btn_Start.TabIndex = 33;
            this.btn_Start.Text = "启动";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // btn_Load
            // 
            this.btn_Load.BackColor = System.Drawing.Color.White;
            this.btn_Load.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btn_Load.FlatAppearance.BorderSize = 2;
            this.btn_Load.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.btn_Load.ForeColor = System.Drawing.Color.Black;
            this.btn_Load.Location = new System.Drawing.Point(19, 31);
            this.btn_Load.Name = "btn_Load";
            this.btn_Load.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_Load.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_Load.Radius = 12;
            this.btn_Load.Size = new System.Drawing.Size(120, 30);
            this.btn_Load.TabIndex = 32;
            this.btn_Load.Text = "加载";
            this.btn_Load.UseVisualStyleBackColor = false;
            this.btn_Load.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // lbl_Size
            // 
            this.lbl_Size.AutoSize = true;
            this.lbl_Size.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Size.Location = new System.Drawing.Point(22, 108);
            this.lbl_Size.Name = "lbl_Size";
            this.lbl_Size.Size = new System.Drawing.Size(73, 20);
            this.lbl_Size.TabIndex = 21;
            this.lbl_Size.Text = "宽：  高：";
            // 
            // lbl_MouseHSV
            // 
            this.lbl_MouseHSV.AutoSize = true;
            this.lbl_MouseHSV.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MouseHSV.Location = new System.Drawing.Point(151, 148);
            this.lbl_MouseHSV.Name = "lbl_MouseHSV";
            this.lbl_MouseHSV.Size = new System.Drawing.Size(79, 20);
            this.lbl_MouseHSV.TabIndex = 31;
            this.lbl_MouseHSV.Text = "H：S：V：";
            // 
            // lbl_MouseRGB
            // 
            this.lbl_MouseRGB.AutoSize = true;
            this.lbl_MouseRGB.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MouseRGB.Location = new System.Drawing.Point(151, 108);
            this.lbl_MouseRGB.Name = "lbl_MouseRGB";
            this.lbl_MouseRGB.Size = new System.Drawing.Size(79, 20);
            this.lbl_MouseRGB.TabIndex = 29;
            this.lbl_MouseRGB.Text = "R：G：B：";
            // 
            // lbl_MousePos
            // 
            this.lbl_MousePos.AutoSize = true;
            this.lbl_MousePos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_MousePos.Location = new System.Drawing.Point(22, 148);
            this.lbl_MousePos.Name = "lbl_MousePos";
            this.lbl_MousePos.Size = new System.Drawing.Size(40, 20);
            this.lbl_MousePos.TabIndex = 28;
            this.lbl_MousePos.Text = "坐标:";
            // 
            // ss_Status
            // 
            this.ss_Status.BackColor = System.Drawing.SystemColors.Control;
            this.tlPanel_Main.SetColumnSpan(this.ss_Status, 2);
            this.ss_Status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ss_Status.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.ss_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssl_Path,
            this.tssl_Error,
            this.tssb_AddRegister,
            this.tssl_Runtime,
            this.tssl_RtLbl,
            this.tssl_Func});
            this.ss_Status.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ss_Status.Location = new System.Drawing.Point(0, 678);
            this.ss_Status.Name = "ss_Status";
            this.ss_Status.Size = new System.Drawing.Size(923, 25);
            this.ss_Status.TabIndex = 41;
            this.ss_Status.Text = "statusStrip1";
            // 
            // tssl_Path
            // 
            this.tssl_Path.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_Path.Name = "tssl_Path";
            this.tssl_Path.Size = new System.Drawing.Size(94, 20);
            this.tssl_Path.Text = "当前图片路径: ";
            // 
            // tssl_Error
            // 
            this.tssl_Error.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssl_Error.ForeColor = System.Drawing.Color.Red;
            this.tssl_Error.Name = "tssl_Error";
            this.tssl_Error.Size = new System.Drawing.Size(21, 20);
            this.tssl_Error.Text = "  ";
            this.tssl_Error.TextChanged += new System.EventHandler(this.tssl_Error_TextChanged);
            // 
            // tssb_AddRegister
            // 
            this.tssb_AddRegister.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssb_AddRegister.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tssb_AddRegister.Image = ((System.Drawing.Image)(resources.GetObject("tssb_AddRegister.Image")));
            this.tssb_AddRegister.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssb_AddRegister.Name = "tssb_AddRegister";
            this.tssb_AddRegister.Size = new System.Drawing.Size(32, 23);
            this.tssb_AddRegister.Text = "toolStripSplitButton1";
            this.tssb_AddRegister.ButtonClick += new System.EventHandler(this.tssb_AddRegister_ButtonClick);
            // 
            // tssl_Runtime
            // 
            this.tssl_Runtime.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssl_Runtime.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tssl_Runtime.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_Runtime.Name = "tssl_Runtime";
            this.tssl_Runtime.Size = new System.Drawing.Size(21, 20);
            this.tssl_Runtime.Text = "0";
            // 
            // tssl_RtLbl
            // 
            this.tssl_RtLbl.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssl_RtLbl.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.tssl_RtLbl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_RtLbl.Name = "tssl_RtLbl";
            this.tssl_RtLbl.Size = new System.Drawing.Size(72, 20);
            this.tssl_RtLbl.Text = "运行时长: ";
            // 
            // tssl_Func
            // 
            this.tssl_Func.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tssl_Func.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssl_Func.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(190)))), ((int)(((byte)(77)))));
            this.tssl_Func.Name = "tssl_Func";
            this.tssl_Func.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tssl_Func.Size = new System.Drawing.Size(87, 20);
            this.tssl_Func.Text = "请先打开图片";
            // 
            // panel_ToolBar
            // 
            this.panel_ToolBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel_ToolBar.Controls.Add(this.cbx_AsmLine);
            this.panel_ToolBar.Controls.Add(this.btn_ToolCut);
            this.panel_ToolBar.Controls.Add(this.btn_ToolGraphClear);
            this.panel_ToolBar.Controls.Add(this.btn_ToolRect);
            this.panel_ToolBar.Controls.Add(this.btn_ToolPRect);
            this.panel_ToolBar.Controls.Add(this.btn_ToolCircle);
            this.panel_ToolBar.Controls.Add(this.btn_ToolLine);
            this.panel_ToolBar.Controls.Add(this.btn_ToolPts);
            this.panel_ToolBar.Location = new System.Drawing.Point(3, 431);
            this.panel_ToolBar.Name = "panel_ToolBar";
            this.panel_ToolBar.Size = new System.Drawing.Size(624, 37);
            this.panel_ToolBar.TabIndex = 37;
            // 
            // cbx_AsmLine
            // 
            this.cbx_AsmLine.AutoSize = true;
            this.cbx_AsmLine.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.cbx_AsmLine.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cbx_AsmLine.ForeCheckColor = System.Drawing.Color.White;
            this.cbx_AsmLine.Location = new System.Drawing.Point(525, 6);
            this.cbx_AsmLine.Name = "cbx_AsmLine";
            this.cbx_AsmLine.Size = new System.Drawing.Size(93, 23);
            this.cbx_AsmLine.Stroke = 3F;
            this.cbx_AsmLine.TabIndex = 84;
            this.cbx_AsmLine.Text = "启用流水线";
            this.cbx_AsmLine.UseVisualStyleBackColor = true;
            // 
            // btn_ToolCut
            // 
            this.btn_ToolCut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolCut.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolCut.FlatAppearance.BorderSize = 0;
            this.btn_ToolCut.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolCut.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolCut.Image")));
            this.btn_ToolCut.Location = new System.Drawing.Point(173, 2);
            this.btn_ToolCut.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolCut.Name = "btn_ToolCut";
            this.btn_ToolCut.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolCut.TabIndex = 37;
            this.btn_ToolCut.UseVisualStyleBackColor = false;
            this.btn_ToolCut.Click += new System.EventHandler(this.btn_ToolCut_Click);
            // 
            // btn_ToolGraphClear
            // 
            this.btn_ToolGraphClear.FlatAppearance.BorderSize = 0;
            this.btn_ToolGraphClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolGraphClear.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolGraphClear.Image")));
            this.btn_ToolGraphClear.Location = new System.Drawing.Point(206, 2);
            this.btn_ToolGraphClear.Name = "btn_ToolGraphClear";
            this.btn_ToolGraphClear.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolGraphClear.TabIndex = 83;
            this.btn_ToolGraphClear.UseVisualStyleBackColor = true;
            this.btn_ToolGraphClear.Click += new System.EventHandler(this.btn_ToolGraphClear_Click);
            // 
            // btn_ToolRect
            // 
            this.btn_ToolRect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolRect.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolRect.FlatAppearance.BorderSize = 0;
            this.btn_ToolRect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolRect.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolRect.Image")));
            this.btn_ToolRect.Location = new System.Drawing.Point(140, 3);
            this.btn_ToolRect.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolRect.Name = "btn_ToolRect";
            this.btn_ToolRect.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolRect.TabIndex = 4;
            this.btn_ToolRect.UseVisualStyleBackColor = false;
            this.btn_ToolRect.Click += new System.EventHandler(this.btn_ToolRect_Click);
            // 
            // btn_ToolPRect
            // 
            this.btn_ToolPRect.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolPRect.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolPRect.FlatAppearance.BorderSize = 0;
            this.btn_ToolPRect.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolPRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolPRect.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolPRect.Image")));
            this.btn_ToolPRect.Location = new System.Drawing.Point(107, 3);
            this.btn_ToolPRect.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolPRect.Name = "btn_ToolPRect";
            this.btn_ToolPRect.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolPRect.TabIndex = 3;
            this.btn_ToolPRect.UseVisualStyleBackColor = false;
            this.btn_ToolPRect.Click += new System.EventHandler(this.btn_ToolPRect_Click);
            // 
            // btn_ToolCircle
            // 
            this.btn_ToolCircle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolCircle.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolCircle.FlatAppearance.BorderSize = 0;
            this.btn_ToolCircle.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolCircle.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolCircle.Image")));
            this.btn_ToolCircle.Location = new System.Drawing.Point(74, 3);
            this.btn_ToolCircle.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolCircle.Name = "btn_ToolCircle";
            this.btn_ToolCircle.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolCircle.TabIndex = 2;
            this.btn_ToolCircle.UseVisualStyleBackColor = false;
            this.btn_ToolCircle.Click += new System.EventHandler(this.btn_ToolCircle_Click);
            // 
            // btn_ToolLine
            // 
            this.btn_ToolLine.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolLine.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolLine.FlatAppearance.BorderSize = 0;
            this.btn_ToolLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolLine.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolLine.Image")));
            this.btn_ToolLine.Location = new System.Drawing.Point(41, 3);
            this.btn_ToolLine.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolLine.Name = "btn_ToolLine";
            this.btn_ToolLine.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolLine.TabIndex = 1;
            this.btn_ToolLine.UseVisualStyleBackColor = false;
            this.btn_ToolLine.Click += new System.EventHandler(this.btn_ToolLine_Click);
            // 
            // btn_ToolPts
            // 
            this.btn_ToolPts.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_ToolPts.FlatAppearance.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.btn_ToolPts.FlatAppearance.BorderSize = 0;
            this.btn_ToolPts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.btn_ToolPts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ToolPts.Image = ((System.Drawing.Image)(resources.GetObject("btn_ToolPts.Image")));
            this.btn_ToolPts.Location = new System.Drawing.Point(8, 3);
            this.btn_ToolPts.Margin = new System.Windows.Forms.Padding(0);
            this.btn_ToolPts.Name = "btn_ToolPts";
            this.btn_ToolPts.Size = new System.Drawing.Size(30, 30);
            this.btn_ToolPts.TabIndex = 0;
            this.toolTip_UseRemark.SetToolTip(this.btn_ToolPts, "画点");
            this.btn_ToolPts.UseVisualStyleBackColor = false;
            this.btn_ToolPts.Click += new System.EventHandler(this.btn_ToolPts_Click);
            // 
            // tc_Image
            // 
            this.tc_Image.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.tc_Image.Controls.Add(this.tabPage_ImageInfo);
            this.tc_Image.Controls.Add(this.tabPage_CutImage);
            this.tc_Image.Controls.Add(this.tabPage_Resize);
            this.tc_Image.Controls.Add(this.tabPage_Rotate);
            this.tc_Image.Controls.Add(this.tabPage_Median);
            this.tc_Image.Controls.Add(this.tabPage_Gaussian);
            this.tc_Image.Controls.Add(this.tabPage_Gray);
            this.tc_Image.Controls.Add(this.tabPage_Binary);
            this.tc_Image.Controls.Add(this.tabPage_EdgeDetect);
            this.tc_Image.Controls.Add(this.tabPage_Dilate);
            this.tc_Image.Controls.Add(this.tabPage_Erode);
            this.tc_Image.Controls.Add(this.tabPage_FindContours);
            this.tc_Image.Controls.Add(this.tabPage_Substract);
            this.tc_Image.Controls.Add(this.tabPage_AddImage);
            this.tc_Image.Controls.Add(this.tabPage_ConnectArea);
            this.tc_Image.Controls.Add(this.tabPage_HoughDetect);
            this.tc_Image.Controls.Add(this.tabPage_Perspective);
            this.tc_Image.Controls.Add(this.tabPage_Equalize);
            this.tc_Image.Controls.Add(this.tabPage_Normalize);
            this.tc_Image.Controls.Add(this.tabPage_DrawCanvas);
            this.tc_Image.Controls.Add(this.tabPage_DrawPts);
            this.tc_Image.Controls.Add(this.tabPage_DrawLine);
            this.tc_Image.Controls.Add(this.tabPage_DrawRect);
            this.tc_Image.Controls.Add(this.tabPage_DrawCircle);
            this.tc_Image.Controls.Add(this.tabPage_Flip);
            this.tc_Image.Controls.Add(this.tabPage_Thin);
            this.tc_Image.Controls.Add(this.tabPage_HSV2Binary);
            this.tc_Image.Controls.Add(this.tabPage_Bilateral);
            this.tc_Image.Controls.Add(this.tabPage_Gray2RGB);
            this.tc_Image.Controls.Add(this.tabPage_fitLine);
            this.tc_Image.Controls.Add(this.tabPage_LineCross);
            this.tc_Image.Controls.Add(this.tabPage_UserDef);
            this.tc_Image.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.tc_Image.Location = new System.Drawing.Point(4, 477);
            this.tc_Image.Name = "tc_Image";
            this.tc_Image.SelectedIndex = 0;
            this.tc_Image.Size = new System.Drawing.Size(621, 198);
            this.tc_Image.TabIndex = 2;
            // 
            // tabPage_ImageInfo
            // 
            this.tabPage_ImageInfo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_ImageInfo.Controls.Add(this.btn_ImageHandleForm);
            this.tabPage_ImageInfo.Controls.Add(this.lbl_CalibratePts);
            this.tabPage_ImageInfo.Controls.Add(this.tb_CalibratePts);
            this.tabPage_ImageInfo.Controls.Add(this.lbl_BorWData);
            this.tabPage_ImageInfo.Controls.Add(this.lbl_PixelMean);
            this.tabPage_ImageInfo.Location = new System.Drawing.Point(4, 28);
            this.tabPage_ImageInfo.Name = "tabPage_ImageInfo";
            this.tabPage_ImageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ImageInfo.Size = new System.Drawing.Size(613, 166);
            this.tabPage_ImageInfo.TabIndex = 17;
            this.tabPage_ImageInfo.Text = "图像信息处理";
            // 
            // btn_ImageHandleForm
            // 
            this.btn_ImageHandleForm.BackColor = System.Drawing.Color.White;
            this.btn_ImageHandleForm.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ImageHandleForm.ForeColor = System.Drawing.Color.Black;
            this.btn_ImageHandleForm.Location = new System.Drawing.Point(506, 122);
            this.btn_ImageHandleForm.Name = "btn_ImageHandleForm";
            this.btn_ImageHandleForm.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_ImageHandleForm.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_ImageHandleForm.Radius = 9;
            this.btn_ImageHandleForm.Size = new System.Drawing.Size(100, 37);
            this.btn_ImageHandleForm.TabIndex = 85;
            this.btn_ImageHandleForm.Text = "图像调整";
            this.btn_ImageHandleForm.UseVisualStyleBackColor = false;
            this.btn_ImageHandleForm.Click += new System.EventHandler(this.button_ImgaeHandleForm_Click);
            // 
            // lbl_CalibratePts
            // 
            this.lbl_CalibratePts.AutoSize = true;
            this.lbl_CalibratePts.Location = new System.Drawing.Point(6, 32);
            this.lbl_CalibratePts.Name = "lbl_CalibratePts";
            this.lbl_CalibratePts.Size = new System.Drawing.Size(81, 19);
            this.lbl_CalibratePts.TabIndex = 84;
            this.lbl_CalibratePts.Text = "标定点坐标 :";
            // 
            // tb_CalibratePts
            // 
            this.tb_CalibratePts.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tb_CalibratePts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_CalibratePts.Location = new System.Drawing.Point(93, 32);
            this.tb_CalibratePts.Name = "tb_CalibratePts";
            this.tb_CalibratePts.ReadOnly = true;
            this.tb_CalibratePts.Size = new System.Drawing.Size(513, 18);
            this.tb_CalibratePts.TabIndex = 82;
            // 
            // lbl_BorWData
            // 
            this.lbl_BorWData.AutoSize = true;
            this.lbl_BorWData.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.lbl_BorWData.Location = new System.Drawing.Point(272, 7);
            this.lbl_BorWData.Name = "lbl_BorWData";
            this.lbl_BorWData.Size = new System.Drawing.Size(110, 19);
            this.lbl_BorWData.TabIndex = 81;
            this.lbl_BorWData.Text = "二值图 - 黑 : 白 : \r\n";
            // 
            // lbl_PixelMean
            // 
            this.lbl_PixelMean.AutoSize = true;
            this.lbl_PixelMean.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.lbl_PixelMean.Location = new System.Drawing.Point(6, 7);
            this.lbl_PixelMean.Name = "lbl_PixelMean";
            this.lbl_PixelMean.Size = new System.Drawing.Size(120, 19);
            this.lbl_PixelMean.TabIndex = 80;
            this.lbl_PixelMean.Text = "像素均值 R : G : B :\r\n";
            // 
            // tabPage_CutImage
            // 
            this.tabPage_CutImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_CutImage.Controls.Add(this.label_CutRect);
            this.tabPage_CutImage.Controls.Add(this.label_StartXY);
            this.tabPage_CutImage.Controls.Add(this.nud_CutH);
            this.tabPage_CutImage.Controls.Add(this.nud_CutW);
            this.tabPage_CutImage.Controls.Add(this.nud_CutY);
            this.tabPage_CutImage.Controls.Add(this.label_CutSize);
            this.tabPage_CutImage.Controls.Add(this.label_CutStartPos);
            this.tabPage_CutImage.Controls.Add(this.nud_CutX);
            this.tabPage_CutImage.Location = new System.Drawing.Point(4, 28);
            this.tabPage_CutImage.Name = "tabPage_CutImage";
            this.tabPage_CutImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_CutImage.Size = new System.Drawing.Size(613, 166);
            this.tabPage_CutImage.TabIndex = 5;
            this.tabPage_CutImage.Text = "剪切图片";
            // 
            // label_CutRect
            // 
            this.label_CutRect.AutoSize = true;
            this.label_CutRect.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CutRect.Location = new System.Drawing.Point(347, 68);
            this.label_CutRect.Name = "label_CutRect";
            this.label_CutRect.Size = new System.Drawing.Size(56, 48);
            this.label_CutRect.TabIndex = 12;
            this.label_CutRect.Text = "Width\r\n\r\nHeight";
            // 
            // label_StartXY
            // 
            this.label_StartXY.AutoSize = true;
            this.label_StartXY.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_StartXY.Location = new System.Drawing.Point(93, 68);
            this.label_StartXY.Name = "label_StartXY";
            this.label_StartXY.Size = new System.Drawing.Size(16, 48);
            this.label_StartXY.TabIndex = 11;
            this.label_StartXY.Text = "x\r\n\r\ny";
            // 
            // nud_CutH
            // 
            this.nud_CutH.Location = new System.Drawing.Point(409, 97);
            this.nud_CutH.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nud_CutH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CutH.Name = "nud_CutH";
            this.nud_CutH.Size = new System.Drawing.Size(69, 25);
            this.nud_CutH.TabIndex = 10;
            this.nud_CutH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CutH.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_CutH.ValueChanged += new System.EventHandler(this.nud_CutH_ValueChanged);
            // 
            // nud_CutW
            // 
            this.nud_CutW.Location = new System.Drawing.Point(409, 70);
            this.nud_CutW.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nud_CutW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_CutW.Name = "nud_CutW";
            this.nud_CutW.Size = new System.Drawing.Size(69, 25);
            this.nud_CutW.TabIndex = 9;
            this.nud_CutW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CutW.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nud_CutW.ValueChanged += new System.EventHandler(this.nud_CutW_ValueChanged);
            // 
            // nud_CutY
            // 
            this.nud_CutY.Location = new System.Drawing.Point(130, 97);
            this.nud_CutY.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nud_CutY.Name = "nud_CutY";
            this.nud_CutY.Size = new System.Drawing.Size(69, 25);
            this.nud_CutY.TabIndex = 8;
            this.nud_CutY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CutY.ValueChanged += new System.EventHandler(this.nud_CutY_ValueChanged);
            // 
            // label_CutSize
            // 
            this.label_CutSize.AutoSize = true;
            this.label_CutSize.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CutSize.Location = new System.Drawing.Point(390, 32);
            this.label_CutSize.Name = "label_CutSize";
            this.label_CutSize.Size = new System.Drawing.Size(79, 20);
            this.label_CutSize.TabIndex = 8;
            this.label_CutSize.Text = "CutRect";
            // 
            // label_CutStartPos
            // 
            this.label_CutStartPos.AutoSize = true;
            this.label_CutStartPos.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_CutStartPos.Location = new System.Drawing.Point(90, 32);
            this.label_CutStartPos.Name = "label_CutStartPos";
            this.label_CutStartPos.Size = new System.Drawing.Size(109, 20);
            this.label_CutStartPos.TabIndex = 6;
            this.label_CutStartPos.Text = "StartPoint";
            // 
            // nud_CutX
            // 
            this.nud_CutX.Location = new System.Drawing.Point(130, 70);
            this.nud_CutX.Maximum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.nud_CutX.Name = "nud_CutX";
            this.nud_CutX.Size = new System.Drawing.Size(69, 25);
            this.nud_CutX.TabIndex = 7;
            this.nud_CutX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CutX.ValueChanged += new System.EventHandler(this.nud_CutX_ValueChanged);
            // 
            // tabPage_Resize
            // 
            this.tabPage_Resize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Resize.Controls.Add(this.ckb_Resize);
            this.tabPage_Resize.Controls.Add(this.label36);
            this.tabPage_Resize.Controls.Add(this.tb_ResizeH);
            this.tabPage_Resize.Controls.Add(this.label35);
            this.tabPage_Resize.Controls.Add(this.tb_ResizeW);
            this.tabPage_Resize.Controls.Add(this.label34);
            this.tabPage_Resize.Controls.Add(this.tb_ResizeHScale);
            this.tabPage_Resize.Controls.Add(this.label33);
            this.tabPage_Resize.Controls.Add(this.tb_ResizeWScale);
            this.tabPage_Resize.Controls.Add(this.label32);
            this.tabPage_Resize.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Resize.Name = "tabPage_Resize";
            this.tabPage_Resize.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Resize.TabIndex = 22;
            this.tabPage_Resize.Text = "Resize";
            // 
            // ckb_Resize
            // 
            this.ckb_Resize.AutoSize = true;
            this.ckb_Resize.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.ckb_Resize.ForeCheckColor = System.Drawing.Color.White;
            this.ckb_Resize.Location = new System.Drawing.Point(404, 58);
            this.ckb_Resize.Name = "ckb_Resize";
            this.ckb_Resize.Size = new System.Drawing.Size(93, 23);
            this.ckb_Resize.Stroke = 3F;
            this.ckb_Resize.TabIndex = 9;
            this.ckb_Resize.Text = "保持纵横比";
            this.ckb_Resize.UseVisualStyleBackColor = true;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.ForeColor = System.Drawing.Color.Coral;
            this.label36.Location = new System.Drawing.Point(224, 123);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(386, 38);
            this.label36.TabIndex = 8;
            this.label36.Text = "注：当使用第一列参数直接修改宽高时，不需要修改第二列参数。\r\n      当使用第二列参数按比例缩放时，不需要修改第一列参数。";
            // 
            // tb_ResizeH
            // 
            this.tb_ResizeH.Location = new System.Drawing.Point(162, 76);
            this.tb_ResizeH.Name = "tb_ResizeH";
            this.tb_ResizeH.Size = new System.Drawing.Size(49, 25);
            this.tb_ResizeH.TabIndex = 7;
            this.tb_ResizeH.Text = "0";
            this.tb_ResizeH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ResizeH.TextChanged += new System.EventHandler(this.tb_ResizeH_TextChanged);
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(264, 79);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(51, 19);
            this.label35.TabIndex = 6;
            this.label35.Text = "ScaleH";
            // 
            // tb_ResizeW
            // 
            this.tb_ResizeW.Location = new System.Drawing.Point(162, 44);
            this.tb_ResizeW.Name = "tb_ResizeW";
            this.tb_ResizeW.Size = new System.Drawing.Size(49, 25);
            this.tb_ResizeW.TabIndex = 5;
            this.tb_ResizeW.Text = "0";
            this.tb_ResizeW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ResizeW.TextChanged += new System.EventHandler(this.tb_ResizeW_TextChanged);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(264, 47);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(54, 19);
            this.label34.TabIndex = 4;
            this.label34.Text = "ScaleW";
            // 
            // tb_ResizeHScale
            // 
            this.tb_ResizeHScale.Location = new System.Drawing.Point(327, 76);
            this.tb_ResizeHScale.Name = "tb_ResizeHScale";
            this.tb_ResizeHScale.Size = new System.Drawing.Size(49, 25);
            this.tb_ResizeHScale.TabIndex = 3;
            this.tb_ResizeHScale.Text = "1";
            this.tb_ResizeHScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ResizeHScale.TextChanged += new System.EventHandler(this.tb_ResizeHScale_TextChanged);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(99, 79);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(50, 19);
            this.label33.TabIndex = 2;
            this.label33.Text = "Height";
            // 
            // tb_ResizeWScale
            // 
            this.tb_ResizeWScale.Location = new System.Drawing.Point(327, 44);
            this.tb_ResizeWScale.Name = "tb_ResizeWScale";
            this.tb_ResizeWScale.Size = new System.Drawing.Size(49, 25);
            this.tb_ResizeWScale.TabIndex = 1;
            this.tb_ResizeWScale.Text = "1";
            this.tb_ResizeWScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ResizeWScale.TextChanged += new System.EventHandler(this.tb_ResizeWScale_TextChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(99, 47);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(46, 19);
            this.label32.TabIndex = 0;
            this.label32.Text = "Width";
            // 
            // tabPage_Rotate
            // 
            this.tabPage_Rotate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Rotate.Controls.Add(this.tkb_RotateAngle);
            this.tabPage_Rotate.Controls.Add(this.label45);
            this.tabPage_Rotate.Controls.Add(this.tb_RotateCenterY);
            this.tabPage_Rotate.Controls.Add(this.tb_RotateCenterX);
            this.tabPage_Rotate.Controls.Add(this.tb_RotateAngle);
            this.tabPage_Rotate.Controls.Add(this.label44);
            this.tabPage_Rotate.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Rotate.Name = "tabPage_Rotate";
            this.tabPage_Rotate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Rotate.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Rotate.TabIndex = 27;
            this.tabPage_Rotate.Text = "旋转";
            this.tabPage_Rotate.ParentChanged += new System.EventHandler(this.tabPage_Rotate_ParentChanged);
            // 
            // tkb_RotateAngle
            // 
            this.tkb_RotateAngle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(247)))), ((int)(((byte)(247)))));
            this.tkb_RotateAngle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(204)))), ((int)(((byte)(102)))));
            this.tkb_RotateAngle.IsHorizon = true;
            this.tkb_RotateAngle.IsRound = true;
            this.tkb_RotateAngle.LargeChange = 20;
            this.tkb_RotateAngle.Location = new System.Drawing.Point(360, 85);
            this.tkb_RotateAngle.MaxNum = 3600;
            this.tkb_RotateAngle.MinNum = 0;
            this.tkb_RotateAngle.Name = "tkb_RotateAngle";
            this.tkb_RotateAngle.OnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.tkb_RotateAngle.Size = new System.Drawing.Size(183, 12);
            this.tkb_RotateAngle.SliderRatio = 0F;
            this.tkb_RotateAngle.SmallChange = 5;
            this.tkb_RotateAngle.TabIndex = 10;
            this.tkb_RotateAngle.Text = "sTrackBar1";
            this.tkb_RotateAngle.Value = 0;
            this.tkb_RotateAngle.Scrolled += new ImageTool.Weights.STrackBar.ScrolledEventHandler(this.tkb_RotateAngle_Scrolled);
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(136, 47);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(103, 19);
            this.label45.TabIndex = 9;
            this.label45.Text = "中心点坐标(x, y)";
            // 
            // tb_RotateCenterY
            // 
            this.tb_RotateCenterY.Location = new System.Drawing.Point(188, 78);
            this.tb_RotateCenterY.Name = "tb_RotateCenterY";
            this.tb_RotateCenterY.Size = new System.Drawing.Size(64, 25);
            this.tb_RotateCenterY.TabIndex = 8;
            this.tb_RotateCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_RotateCenterX
            // 
            this.tb_RotateCenterX.Location = new System.Drawing.Point(118, 78);
            this.tb_RotateCenterX.Name = "tb_RotateCenterX";
            this.tb_RotateCenterX.Size = new System.Drawing.Size(64, 25);
            this.tb_RotateCenterX.TabIndex = 7;
            this.tb_RotateCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_RotateAngle
            // 
            this.tb_RotateAngle.Location = new System.Drawing.Point(448, 44);
            this.tb_RotateAngle.Name = "tb_RotateAngle";
            this.tb_RotateAngle.Size = new System.Drawing.Size(64, 25);
            this.tb_RotateAngle.TabIndex = 1;
            this.tb_RotateAngle.Text = "0";
            this.tb_RotateAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_RotateAngle.TextChanged += new System.EventHandler(this.tb_RotateAngle_TextChanged);
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(380, 47);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(61, 19);
            this.label44.TabIndex = 0;
            this.label44.Text = "旋转角度";
            // 
            // tabPage_Median
            // 
            this.tabPage_Median.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Median.Controls.Add(this.label_Kernel);
            this.tabPage_Median.Controls.Add(this.nud_Median);
            this.tabPage_Median.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Median.Name = "tabPage_Median";
            this.tabPage_Median.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Median.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Median.TabIndex = 2;
            this.tabPage_Median.Text = "中值滤波";
            // 
            // label_Kernel
            // 
            this.label_Kernel.AutoSize = true;
            this.label_Kernel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Kernel.Location = new System.Drawing.Point(237, 56);
            this.label_Kernel.Name = "label_Kernel";
            this.label_Kernel.Size = new System.Drawing.Size(109, 20);
            this.label_Kernel.TabIndex = 3;
            this.label_Kernel.Text = "KernelSize";
            // 
            // nud_Median
            // 
            this.nud_Median.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_Median.Location = new System.Drawing.Point(237, 85);
            this.nud_Median.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_Median.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nud_Median.Name = "nud_Median";
            this.nud_Median.Size = new System.Drawing.Size(109, 25);
            this.nud_Median.TabIndex = 5;
            this.nud_Median.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_Median.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage_Gaussian
            // 
            this.tabPage_Gaussian.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Gaussian.Controls.Add(this.tb_gsKer);
            this.tabPage_Gaussian.Controls.Add(this.tb_gsSigma);
            this.tabPage_Gaussian.Controls.Add(this.label28);
            this.tabPage_Gaussian.Controls.Add(this.label29);
            this.tabPage_Gaussian.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Gaussian.Name = "tabPage_Gaussian";
            this.tabPage_Gaussian.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Gaussian.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Gaussian.TabIndex = 20;
            this.tabPage_Gaussian.Text = "高斯滤波";
            // 
            // tb_gsKer
            // 
            this.tb_gsKer.Location = new System.Drawing.Point(220, 81);
            this.tb_gsKer.Name = "tb_gsKer";
            this.tb_gsKer.Size = new System.Drawing.Size(50, 25);
            this.tb_gsKer.TabIndex = 5;
            this.tb_gsKer.Text = "3";
            this.tb_gsKer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_gsSigma
            // 
            this.tb_gsSigma.Location = new System.Drawing.Point(330, 81);
            this.tb_gsSigma.Name = "tb_gsSigma";
            this.tb_gsSigma.Size = new System.Drawing.Size(50, 25);
            this.tb_gsSigma.TabIndex = 7;
            this.tb_gsSigma.Text = "0.8";
            this.tb_gsSigma.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(332, 52);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(45, 19);
            this.label28.TabIndex = 6;
            this.label28.Text = "sigma";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(208, 52);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(74, 19);
            this.label29.TabIndex = 4;
            this.label29.Text = "高斯滤波核";
            // 
            // tabPage_Gray
            // 
            this.tabPage_Gray.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Gray.Controls.Add(this.cb_GrayChannel);
            this.tabPage_Gray.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Gray.Name = "tabPage_Gray";
            this.tabPage_Gray.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Gray.TabIndex = 15;
            this.tabPage_Gray.Text = "转灰度";
            // 
            // cb_GrayChannel
            // 
            this.cb_GrayChannel.BackColor = System.Drawing.Color.Transparent;
            this.cb_GrayChannel.BorderColor = System.Drawing.Color.Black;
            this.cb_GrayChannel.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_GrayChannel.Items.AddRange(new object[] {
            "全通道",
            "R",
            "G",
            "B"});
            this.cb_GrayChannel.Location = new System.Drawing.Point(240, 50);
            this.cb_GrayChannel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_GrayChannel.Name = "cb_GrayChannel";
            this.cb_GrayChannel.SelectedColor = System.Drawing.Color.Black;
            this.cb_GrayChannel.SelectedIndex = 1;
            this.cb_GrayChannel.Size = new System.Drawing.Size(111, 26);
            this.cb_GrayChannel.TabIndex = 0;
            this.cb_GrayChannel.UseRadius = true;
            // 
            // tabPage_Binary
            // 
            this.tabPage_Binary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Binary.Controls.Add(this.cb_ThresType);
            this.tabPage_Binary.Controls.Add(this.gb_ExtendBox);
            this.tabPage_Binary.Controls.Add(this.gb_BasicBox);
            this.tabPage_Binary.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Binary.Name = "tabPage_Binary";
            this.tabPage_Binary.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Binary.TabIndex = 14;
            this.tabPage_Binary.Text = "二值化";
            // 
            // cb_ThresType
            // 
            this.cb_ThresType.BackColor = System.Drawing.Color.Transparent;
            this.cb_ThresType.BorderColor = System.Drawing.Color.Black;
            this.cb_ThresType.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_ThresType.Items.AddRange(new object[] {
            "固定阈值",
            "大津法",
            "局部自适应"});
            this.cb_ThresType.Location = new System.Drawing.Point(36, 43);
            this.cb_ThresType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_ThresType.Name = "cb_ThresType";
            this.cb_ThresType.SelectedColor = System.Drawing.Color.Black;
            this.cb_ThresType.SelectedIndex = -1;
            this.cb_ThresType.Size = new System.Drawing.Size(111, 26);
            this.cb_ThresType.TabIndex = 21;
            this.cb_ThresType.UseRadius = true;
            this.cb_ThresType.SelectedIndexChanged += new ImageTool.Controls.UComboBox.SelectChangeHandler(this.cb_ThresType_SelectedIndexChanged);
            // 
            // gb_ExtendBox
            // 
            this.gb_ExtendBox.Controls.Add(this.cb_Adaptive);
            this.gb_ExtendBox.Controls.Add(this.tb_AdaptiveDelta);
            this.gb_ExtendBox.Controls.Add(this.lbl_Adaptive3);
            this.gb_ExtendBox.Controls.Add(this.tb_AdaptiveSize);
            this.gb_ExtendBox.Controls.Add(this.lbl_Adaptive2);
            this.gb_ExtendBox.Controls.Add(this.lbl_Adaptive1);
            this.gb_ExtendBox.Controls.Add(this.lbl_OTSU);
            this.gb_ExtendBox.Location = new System.Drawing.Point(402, 7);
            this.gb_ExtendBox.Name = "gb_ExtendBox";
            this.gb_ExtendBox.Size = new System.Drawing.Size(200, 150);
            this.gb_ExtendBox.TabIndex = 20;
            this.gb_ExtendBox.TabStop = false;
            this.gb_ExtendBox.Text = "扩展参数";
            // 
            // cb_Adaptive
            // 
            this.cb_Adaptive.BackColor = System.Drawing.Color.Transparent;
            this.cb_Adaptive.BorderColor = System.Drawing.Color.Black;
            this.cb_Adaptive.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_Adaptive.Items.AddRange(new object[] {
            "均值",
            "高斯",
            "中值"});
            this.cb_Adaptive.Location = new System.Drawing.Point(113, 53);
            this.cb_Adaptive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_Adaptive.Name = "cb_Adaptive";
            this.cb_Adaptive.SelectedColor = System.Drawing.Color.Black;
            this.cb_Adaptive.SelectedIndex = -1;
            this.cb_Adaptive.Size = new System.Drawing.Size(69, 26);
            this.cb_Adaptive.TabIndex = 7;
            this.cb_Adaptive.UseRadius = true;
            // 
            // tb_AdaptiveDelta
            // 
            this.tb_AdaptiveDelta.Location = new System.Drawing.Point(113, 117);
            this.tb_AdaptiveDelta.Name = "tb_AdaptiveDelta";
            this.tb_AdaptiveDelta.Size = new System.Drawing.Size(69, 25);
            this.tb_AdaptiveDelta.TabIndex = 6;
            this.tb_AdaptiveDelta.Text = "8";
            this.tb_AdaptiveDelta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Adaptive3
            // 
            this.lbl_Adaptive3.AutoSize = true;
            this.lbl_Adaptive3.Location = new System.Drawing.Point(20, 120);
            this.lbl_Adaptive3.Name = "lbl_Adaptive3";
            this.lbl_Adaptive3.Size = new System.Drawing.Size(74, 19);
            this.lbl_Adaptive3.TabIndex = 5;
            this.lbl_Adaptive3.Text = "偏移量 ( - )";
            // 
            // tb_AdaptiveSize
            // 
            this.tb_AdaptiveSize.Location = new System.Drawing.Point(113, 86);
            this.tb_AdaptiveSize.Name = "tb_AdaptiveSize";
            this.tb_AdaptiveSize.Size = new System.Drawing.Size(69, 25);
            this.tb_AdaptiveSize.TabIndex = 4;
            this.tb_AdaptiveSize.Text = "7";
            this.tb_AdaptiveSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lbl_Adaptive2
            // 
            this.lbl_Adaptive2.AutoSize = true;
            this.lbl_Adaptive2.Location = new System.Drawing.Point(20, 89);
            this.lbl_Adaptive2.Name = "lbl_Adaptive2";
            this.lbl_Adaptive2.Size = new System.Drawing.Size(61, 19);
            this.lbl_Adaptive2.TabIndex = 3;
            this.lbl_Adaptive2.Text = "邻域大小";
            // 
            // lbl_Adaptive1
            // 
            this.lbl_Adaptive1.AutoSize = true;
            this.lbl_Adaptive1.Location = new System.Drawing.Point(20, 56);
            this.lbl_Adaptive1.Name = "lbl_Adaptive1";
            this.lbl_Adaptive1.Size = new System.Drawing.Size(87, 19);
            this.lbl_Adaptive1.TabIndex = 2;
            this.lbl_Adaptive1.Text = "局部阈值算法";
            // 
            // lbl_OTSU
            // 
            this.lbl_OTSU.AutoSize = true;
            this.lbl_OTSU.Location = new System.Drawing.Point(20, 27);
            this.lbl_OTSU.Name = "lbl_OTSU";
            this.lbl_OTSU.Size = new System.Drawing.Size(68, 19);
            this.lbl_OTSU.TabIndex = 0;
            this.lbl_OTSU.Text = "最佳阈值: ";
            // 
            // gb_BasicBox
            // 
            this.gb_BasicBox.Controls.Add(this.label15);
            this.gb_BasicBox.Controls.Add(this.nud_BinarySel);
            this.gb_BasicBox.Controls.Add(this.label13);
            this.gb_BasicBox.Controls.Add(this.nud_MaxPixelVal);
            this.gb_BasicBox.Controls.Add(this.nud_BinaryThres);
            this.gb_BasicBox.Controls.Add(this.label14);
            this.gb_BasicBox.Location = new System.Drawing.Point(193, 7);
            this.gb_BasicBox.Name = "gb_BasicBox";
            this.gb_BasicBox.Size = new System.Drawing.Size(200, 150);
            this.gb_BasicBox.TabIndex = 19;
            this.gb_BasicBox.TabStop = false;
            this.gb_BasicBox.Text = "基础参数";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(18, 36);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 19);
            this.label15.TabIndex = 12;
            this.label15.Text = "填充区域";
            // 
            // nud_BinarySel
            // 
            this.nud_BinarySel.Location = new System.Drawing.Point(98, 34);
            this.nud_BinarySel.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_BinarySel.Name = "nud_BinarySel";
            this.nud_BinarySel.Size = new System.Drawing.Size(77, 25);
            this.nud_BinarySel.TabIndex = 13;
            this.nud_BinarySel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_BinarySel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(18, 114);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 19);
            this.label13.TabIndex = 17;
            this.label13.Text = "阈值";
            // 
            // nud_MaxPixelVal
            // 
            this.nud_MaxPixelVal.Location = new System.Drawing.Point(98, 74);
            this.nud_MaxPixelVal.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_MaxPixelVal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_MaxPixelVal.Name = "nud_MaxPixelVal";
            this.nud_MaxPixelVal.Size = new System.Drawing.Size(77, 25);
            this.nud_MaxPixelVal.TabIndex = 15;
            this.nud_MaxPixelVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_MaxPixelVal.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            // 
            // nud_BinaryThres
            // 
            this.nud_BinaryThres.Location = new System.Drawing.Point(98, 112);
            this.nud_BinaryThres.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_BinaryThres.Name = "nud_BinaryThres";
            this.nud_BinaryThres.Size = new System.Drawing.Size(77, 25);
            this.nud_BinaryThres.TabIndex = 16;
            this.nud_BinaryThres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_BinaryThres.Value = new decimal(new int[] {
            127,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(18, 76);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(48, 19);
            this.label14.TabIndex = 14;
            this.label14.Text = "最大值";
            // 
            // tabPage_EdgeDetect
            // 
            this.tabPage_EdgeDetect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_EdgeDetect.Controls.Add(this.cb_EdgeDetect);
            this.tabPage_EdgeDetect.Controls.Add(this.gb_CannyPara);
            this.tabPage_EdgeDetect.Controls.Add(this.gb_Sobel);
            this.tabPage_EdgeDetect.Controls.Add(this.gb_Laplacian);
            this.tabPage_EdgeDetect.Location = new System.Drawing.Point(4, 28);
            this.tabPage_EdgeDetect.Name = "tabPage_EdgeDetect";
            this.tabPage_EdgeDetect.Size = new System.Drawing.Size(613, 166);
            this.tabPage_EdgeDetect.TabIndex = 19;
            this.tabPage_EdgeDetect.Text = "边缘检测";
            // 
            // cb_EdgeDetect
            // 
            this.cb_EdgeDetect.BackColor = System.Drawing.Color.Transparent;
            this.cb_EdgeDetect.BorderColor = System.Drawing.Color.Black;
            this.cb_EdgeDetect.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_EdgeDetect.Items.AddRange(new object[] {
            "sobel",
            "laplacian",
            "canny"});
            this.cb_EdgeDetect.Location = new System.Drawing.Point(20, 50);
            this.cb_EdgeDetect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_EdgeDetect.Name = "cb_EdgeDetect";
            this.cb_EdgeDetect.SelectedColor = System.Drawing.Color.Black;
            this.cb_EdgeDetect.SelectedIndex = -1;
            this.cb_EdgeDetect.Size = new System.Drawing.Size(100, 26);
            this.cb_EdgeDetect.TabIndex = 10;
            this.cb_EdgeDetect.UseRadius = true;
            this.cb_EdgeDetect.SelectedIndexChanged += new ImageTool.Controls.UComboBox.SelectChangeHandler(this.cb_EdgeDetect_SelectedIndexChanged);
            // 
            // gb_CannyPara
            // 
            this.gb_CannyPara.Controls.Add(this.tb_GSKsize);
            this.gb_CannyPara.Controls.Add(this.tb_HighThres);
            this.gb_CannyPara.Controls.Add(this.tb_LowThres);
            this.gb_CannyPara.Controls.Add(this.label12);
            this.gb_CannyPara.Controls.Add(this.label8);
            this.gb_CannyPara.Controls.Add(this.label2);
            this.gb_CannyPara.Location = new System.Drawing.Point(138, 3);
            this.gb_CannyPara.Name = "gb_CannyPara";
            this.gb_CannyPara.Size = new System.Drawing.Size(472, 161);
            this.gb_CannyPara.TabIndex = 2;
            this.gb_CannyPara.TabStop = false;
            this.gb_CannyPara.Text = "canny参数";
            // 
            // tb_GSKsize
            // 
            this.tb_GSKsize.Location = new System.Drawing.Point(94, 54);
            this.tb_GSKsize.Name = "tb_GSKsize";
            this.tb_GSKsize.Size = new System.Drawing.Size(50, 25);
            this.tb_GSKsize.TabIndex = 1;
            this.tb_GSKsize.Text = "3";
            this.tb_GSKsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_HighThres
            // 
            this.tb_HighThres.Location = new System.Drawing.Point(344, 54);
            this.tb_HighThres.Name = "tb_HighThres";
            this.tb_HighThres.Size = new System.Drawing.Size(50, 25);
            this.tb_HighThres.TabIndex = 3;
            this.tb_HighThres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LowThres
            // 
            this.tb_LowThres.Location = new System.Drawing.Point(233, 54);
            this.tb_LowThres.Name = "tb_LowThres";
            this.tb_LowThres.Size = new System.Drawing.Size(50, 25);
            this.tb_LowThres.TabIndex = 2;
            this.tb_LowThres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(346, 31);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 19);
            this.label12.TabIndex = 2;
            this.label12.Text = "高阈值";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 19);
            this.label8.TabIndex = 1;
            this.label8.Text = "低阈值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "卷积核Size";
            // 
            // gb_Sobel
            // 
            this.gb_Sobel.Controls.Add(this.tb_SobelKsize);
            this.gb_Sobel.Controls.Add(this.tb_Sobeldy);
            this.gb_Sobel.Controls.Add(this.tb_Sobeldx);
            this.gb_Sobel.Controls.Add(this.label23);
            this.gb_Sobel.Controls.Add(this.label24);
            this.gb_Sobel.Controls.Add(this.label25);
            this.gb_Sobel.Location = new System.Drawing.Point(138, 3);
            this.gb_Sobel.Name = "gb_Sobel";
            this.gb_Sobel.Size = new System.Drawing.Size(472, 161);
            this.gb_Sobel.TabIndex = 9;
            this.gb_Sobel.TabStop = false;
            this.gb_Sobel.Text = "Sobel参数";
            // 
            // tb_SobelKsize
            // 
            this.tb_SobelKsize.Location = new System.Drawing.Point(94, 54);
            this.tb_SobelKsize.Name = "tb_SobelKsize";
            this.tb_SobelKsize.Size = new System.Drawing.Size(50, 25);
            this.tb_SobelKsize.TabIndex = 1;
            this.tb_SobelKsize.Text = "-1";
            this.tb_SobelKsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Sobeldy
            // 
            this.tb_Sobeldy.Location = new System.Drawing.Point(344, 54);
            this.tb_Sobeldy.Name = "tb_Sobeldy";
            this.tb_Sobeldy.Size = new System.Drawing.Size(50, 25);
            this.tb_Sobeldy.TabIndex = 3;
            this.tb_Sobeldy.Text = "0";
            this.tb_Sobeldy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_Sobeldx
            // 
            this.tb_Sobeldx.Location = new System.Drawing.Point(233, 54);
            this.tb_Sobeldx.Name = "tb_Sobeldx";
            this.tb_Sobeldx.Size = new System.Drawing.Size(50, 25);
            this.tb_Sobeldx.TabIndex = 2;
            this.tb_Sobeldx.Text = "1";
            this.tb_Sobeldx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(357, 32);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(24, 19);
            this.label23.TabIndex = 2;
            this.label23.Text = "dy";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(244, 32);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(24, 19);
            this.label24.TabIndex = 1;
            this.label24.Text = "dx";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(98, 32);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(38, 19);
            this.label25.TabIndex = 0;
            this.label25.Text = "ksize";
            // 
            // gb_Laplacian
            // 
            this.gb_Laplacian.Controls.Add(this.tb_LapKsize);
            this.gb_Laplacian.Controls.Add(this.label22);
            this.gb_Laplacian.Location = new System.Drawing.Point(138, 3);
            this.gb_Laplacian.Name = "gb_Laplacian";
            this.gb_Laplacian.Size = new System.Drawing.Size(472, 161);
            this.gb_Laplacian.TabIndex = 4;
            this.gb_Laplacian.TabStop = false;
            this.gb_Laplacian.Text = "laplacian参数";
            // 
            // tb_LapKsize
            // 
            this.tb_LapKsize.Location = new System.Drawing.Point(207, 79);
            this.tb_LapKsize.Name = "tb_LapKsize";
            this.tb_LapKsize.Size = new System.Drawing.Size(50, 25);
            this.tb_LapKsize.TabIndex = 2;
            this.tb_LapKsize.Text = "3";
            this.tb_LapKsize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(213, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(38, 19);
            this.label22.TabIndex = 1;
            this.label22.Text = "ksize";
            // 
            // tabPage_Dilate
            // 
            this.tabPage_Dilate.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Dilate.Controls.Add(this.label21);
            this.tabPage_Dilate.Controls.Add(this.nud_DilateKerY);
            this.tabPage_Dilate.Controls.Add(this.label_DilateKernel);
            this.tabPage_Dilate.Controls.Add(this.nud_DilateKerX);
            this.tabPage_Dilate.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Dilate.Name = "tabPage_Dilate";
            this.tabPage_Dilate.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Dilate.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Dilate.TabIndex = 3;
            this.tabPage_Dilate.Text = "膨胀";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(331, 56);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(79, 20);
            this.label21.TabIndex = 8;
            this.label21.Text = "KernelY";
            // 
            // nud_DilateKerY
            // 
            this.nud_DilateKerY.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_DilateKerY.Location = new System.Drawing.Point(314, 79);
            this.nud_DilateKerY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_DilateKerY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_DilateKerY.Name = "nud_DilateKerY";
            this.nud_DilateKerY.Size = new System.Drawing.Size(109, 25);
            this.nud_DilateKerY.TabIndex = 9;
            this.nud_DilateKerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_DilateKerY.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_DilateKernel
            // 
            this.label_DilateKernel.AutoSize = true;
            this.label_DilateKernel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_DilateKernel.Location = new System.Drawing.Point(178, 56);
            this.label_DilateKernel.Name = "label_DilateKernel";
            this.label_DilateKernel.Size = new System.Drawing.Size(79, 20);
            this.label_DilateKernel.TabIndex = 6;
            this.label_DilateKernel.Text = "KernelX";
            // 
            // nud_DilateKerX
            // 
            this.nud_DilateKerX.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_DilateKerX.Location = new System.Drawing.Point(161, 79);
            this.nud_DilateKerX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_DilateKerX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_DilateKerX.Name = "nud_DilateKerX";
            this.nud_DilateKerX.Size = new System.Drawing.Size(109, 25);
            this.nud_DilateKerX.TabIndex = 7;
            this.nud_DilateKerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_DilateKerX.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage_Erode
            // 
            this.tabPage_Erode.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Erode.Controls.Add(this.label26);
            this.tabPage_Erode.Controls.Add(this.nud_ErodeKerY);
            this.tabPage_Erode.Controls.Add(this.label_ErodeKernel);
            this.tabPage_Erode.Controls.Add(this.nud_ErodeKerX);
            this.tabPage_Erode.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Erode.Name = "tabPage_Erode";
            this.tabPage_Erode.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Erode.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Erode.TabIndex = 4;
            this.tabPage_Erode.Text = "腐蚀";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(331, 56);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(79, 20);
            this.label26.TabIndex = 10;
            this.label26.Text = "KernelY";
            // 
            // nud_ErodeKerY
            // 
            this.nud_ErodeKerY.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_ErodeKerY.Location = new System.Drawing.Point(314, 79);
            this.nud_ErodeKerY.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_ErodeKerY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ErodeKerY.Name = "nud_ErodeKerY";
            this.nud_ErodeKerY.Size = new System.Drawing.Size(109, 25);
            this.nud_ErodeKerY.TabIndex = 11;
            this.nud_ErodeKerY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_ErodeKerY.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label_ErodeKernel
            // 
            this.label_ErodeKernel.AutoSize = true;
            this.label_ErodeKernel.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_ErodeKernel.Location = new System.Drawing.Point(178, 56);
            this.label_ErodeKernel.Name = "label_ErodeKernel";
            this.label_ErodeKernel.Size = new System.Drawing.Size(79, 20);
            this.label_ErodeKernel.TabIndex = 8;
            this.label_ErodeKernel.Text = "KernelX";
            // 
            // nud_ErodeKerX
            // 
            this.nud_ErodeKerX.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nud_ErodeKerX.Location = new System.Drawing.Point(161, 79);
            this.nud_ErodeKerX.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nud_ErodeKerX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_ErodeKerX.Name = "nud_ErodeKerX";
            this.nud_ErodeKerX.Size = new System.Drawing.Size(109, 25);
            this.nud_ErodeKerX.TabIndex = 9;
            this.nud_ErodeKerX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_ErodeKerX.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // tabPage_FindContours
            // 
            this.tabPage_FindContours.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_FindContours.Controls.Add(this.cbx_ConMinPRect);
            this.tabPage_FindContours.Controls.Add(this.cbx_ConMinRect);
            this.tabPage_FindContours.Controls.Add(this.lbl_ConPointNum);
            this.tabPage_FindContours.Controls.Add(this.lbl_ConArea);
            this.tabPage_FindContours.Controls.Add(this.lbl_ConNum);
            this.tabPage_FindContours.Controls.Add(this.label6);
            this.tabPage_FindContours.Controls.Add(this.label7);
            this.tabPage_FindContours.Controls.Add(this.tb_ConRect);
            this.tabPage_FindContours.Controls.Add(this.tb_ConCtr);
            this.tabPage_FindContours.Controls.Add(this.label5);
            this.tabPage_FindContours.Controls.Add(this.nud_ConIdx);
            this.tabPage_FindContours.Location = new System.Drawing.Point(4, 28);
            this.tabPage_FindContours.Name = "tabPage_FindContours";
            this.tabPage_FindContours.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_FindContours.Size = new System.Drawing.Size(613, 166);
            this.tabPage_FindContours.TabIndex = 11;
            this.tabPage_FindContours.Text = "找轮廓";
            // 
            // cbx_ConMinPRect
            // 
            this.cbx_ConMinPRect.AutoSize = true;
            this.cbx_ConMinPRect.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.cbx_ConMinPRect.ForeCheckColor = System.Drawing.Color.White;
            this.cbx_ConMinPRect.Location = new System.Drawing.Point(390, 90);
            this.cbx_ConMinPRect.Name = "cbx_ConMinPRect";
            this.cbx_ConMinPRect.Size = new System.Drawing.Size(67, 23);
            this.cbx_ConMinPRect.Stroke = 3F;
            this.cbx_ConMinPRect.TabIndex = 23;
            this.cbx_ConMinPRect.Text = "正矩形";
            this.cbx_ConMinPRect.UseVisualStyleBackColor = true;
            this.cbx_ConMinPRect.CheckedChanged += new System.EventHandler(this.cbx_ConMinPRect_CheckedChanged);
            // 
            // cbx_ConMinRect
            // 
            this.cbx_ConMinRect.AutoSize = true;
            this.cbx_ConMinRect.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.cbx_ConMinRect.Checked = true;
            this.cbx_ConMinRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_ConMinRect.ForeCheckColor = System.Drawing.Color.White;
            this.cbx_ConMinRect.Location = new System.Drawing.Point(304, 90);
            this.cbx_ConMinRect.Name = "cbx_ConMinRect";
            this.cbx_ConMinRect.Size = new System.Drawing.Size(80, 23);
            this.cbx_ConMinRect.Stroke = 3F;
            this.cbx_ConMinRect.TabIndex = 22;
            this.cbx_ConMinRect.Text = "旋转矩形";
            this.cbx_ConMinRect.UseVisualStyleBackColor = true;
            this.cbx_ConMinRect.CheckedChanged += new System.EventHandler(this.cbx_ConMinRect_CheckedChanged);
            // 
            // lbl_ConPointNum
            // 
            this.lbl_ConPointNum.AutoSize = true;
            this.lbl_ConPointNum.Location = new System.Drawing.Point(472, 87);
            this.lbl_ConPointNum.Name = "lbl_ConPointNum";
            this.lbl_ConPointNum.Size = new System.Drawing.Size(87, 19);
            this.lbl_ConPointNum.TabIndex = 19;
            this.lbl_ConPointNum.Text = "轮廓点集数：";
            // 
            // lbl_ConArea
            // 
            this.lbl_ConArea.AutoSize = true;
            this.lbl_ConArea.Location = new System.Drawing.Point(472, 57);
            this.lbl_ConArea.Name = "lbl_ConArea";
            this.lbl_ConArea.Size = new System.Drawing.Size(74, 19);
            this.lbl_ConArea.TabIndex = 18;
            this.lbl_ConArea.Text = "轮廓面积：";
            // 
            // lbl_ConNum
            // 
            this.lbl_ConNum.AutoSize = true;
            this.lbl_ConNum.Location = new System.Drawing.Point(472, 27);
            this.lbl_ConNum.Name = "lbl_ConNum";
            this.lbl_ConNum.Size = new System.Drawing.Size(74, 19);
            this.lbl_ConNum.TabIndex = 17;
            this.lbl_ConNum.Text = "轮廓总数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(174, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 20);
            this.label6.TabIndex = 16;
            this.label6.Text = "最小外接矩坐标";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(174, 27);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 15;
            this.label7.Text = "中心点坐标";
            // 
            // tb_ConRect
            // 
            this.tb_ConRect.Location = new System.Drawing.Point(178, 119);
            this.tb_ConRect.Name = "tb_ConRect";
            this.tb_ConRect.Size = new System.Drawing.Size(279, 25);
            this.tb_ConRect.TabIndex = 14;
            // 
            // tb_ConCtr
            // 
            this.tb_ConCtr.Location = new System.Drawing.Point(178, 52);
            this.tb_ConCtr.Name = "tb_ConCtr";
            this.tb_ConCtr.Size = new System.Drawing.Size(180, 25);
            this.tb_ConCtr.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(65, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "轮廓序号\r\n";
            // 
            // nud_ConIdx
            // 
            this.nud_ConIdx.Location = new System.Drawing.Point(50, 85);
            this.nud_ConIdx.Maximum = new decimal(new int[] {
            66,
            0,
            0,
            0});
            this.nud_ConIdx.Name = "nud_ConIdx";
            this.nud_ConIdx.Size = new System.Drawing.Size(91, 25);
            this.nud_ConIdx.TabIndex = 11;
            this.nud_ConIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_ConIdx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage_Substract
            // 
            this.tabPage_Substract.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Substract.Controls.Add(this.btn_SubImage);
            this.tabPage_Substract.Controls.Add(this.cbx_UseAbs);
            this.tabPage_Substract.Controls.Add(this.panel_SubDisplay);
            this.tabPage_Substract.Controls.Add(this.tb_SubScale);
            this.tabPage_Substract.Controls.Add(this.label38);
            this.tabPage_Substract.Controls.Add(this.label37);
            this.tabPage_Substract.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Substract.Name = "tabPage_Substract";
            this.tabPage_Substract.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Substract.TabIndex = 23;
            this.tabPage_Substract.Text = "图像作差";
            // 
            // btn_SubImage
            // 
            this.btn_SubImage.BackColor = System.Drawing.Color.White;
            this.btn_SubImage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_SubImage.ForeColor = System.Drawing.Color.Black;
            this.btn_SubImage.Location = new System.Drawing.Point(442, 111);
            this.btn_SubImage.Name = "btn_SubImage";
            this.btn_SubImage.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_SubImage.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_SubImage.Radius = 9;
            this.btn_SubImage.Size = new System.Drawing.Size(88, 33);
            this.btn_SubImage.TabIndex = 19;
            this.btn_SubImage.Text = "选择子图片";
            this.btn_SubImage.UseVisualStyleBackColor = false;
            this.btn_SubImage.Click += new System.EventHandler(this.btn_SubImage_Click);
            // 
            // cbx_UseAbs
            // 
            this.cbx_UseAbs.AutoSize = true;
            this.cbx_UseAbs.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.cbx_UseAbs.ForeCheckColor = System.Drawing.Color.White;
            this.cbx_UseAbs.Location = new System.Drawing.Point(429, 77);
            this.cbx_UseAbs.Name = "cbx_UseAbs";
            this.cbx_UseAbs.Size = new System.Drawing.Size(119, 23);
            this.cbx_UseAbs.Stroke = 3F;
            this.cbx_UseAbs.TabIndex = 18;
            this.cbx_UseAbs.Text = "是否使用绝对值";
            this.cbx_UseAbs.UseVisualStyleBackColor = true;
            // 
            // panel_SubDisplay
            // 
            this.panel_SubDisplay.Controls.Add(this.pb_Substract);
            this.panel_SubDisplay.Location = new System.Drawing.Point(45, 3);
            this.panel_SubDisplay.Name = "panel_SubDisplay";
            this.panel_SubDisplay.Size = new System.Drawing.Size(322, 160);
            this.panel_SubDisplay.TabIndex = 17;
            // 
            // pb_Substract
            // 
            this.pb_Substract.AllowDrop = true;
            this.pb_Substract.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pb_Substract.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_Substract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Substract.Location = new System.Drawing.Point(0, 0);
            this.pb_Substract.Name = "pb_Substract";
            this.pb_Substract.Size = new System.Drawing.Size(322, 160);
            this.pb_Substract.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Substract.TabIndex = 13;
            this.pb_Substract.TabStop = false;
            this.pb_Substract.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb_Substract_DragDrop);
            this.pb_Substract.DragEnter += new System.Windows.Forms.DragEventHandler(this.pb_Substract_DragEnter);
            // 
            // tb_SubScale
            // 
            this.tb_SubScale.Location = new System.Drawing.Point(507, 36);
            this.tb_SubScale.Name = "tb_SubScale";
            this.tb_SubScale.Size = new System.Drawing.Size(49, 25);
            this.tb_SubScale.TabIndex = 15;
            this.tb_SubScale.Text = "1";
            this.tb_SubScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Location = new System.Drawing.Point(401, 39);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(100, 19);
            this.label38.TabIndex = 14;
            this.label38.Text = "差值放大倍数：";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label37.Location = new System.Drawing.Point(11, 39);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(22, 76);
            this.label37.TabIndex = 12;
            this.label37.Text = "减\r\n数\r\n图\r\n片";
            // 
            // tabPage_AddImage
            // 
            this.tabPage_AddImage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_AddImage.Controls.Add(this.btn_AddImage);
            this.tabPage_AddImage.Controls.Add(this.panel_AddDisplay);
            this.tabPage_AddImage.Controls.Add(this.label1);
            this.tabPage_AddImage.Location = new System.Drawing.Point(4, 28);
            this.tabPage_AddImage.Name = "tabPage_AddImage";
            this.tabPage_AddImage.Size = new System.Drawing.Size(613, 166);
            this.tabPage_AddImage.TabIndex = 34;
            this.tabPage_AddImage.Text = "图像求和";
            // 
            // btn_AddImage
            // 
            this.btn_AddImage.BackColor = System.Drawing.Color.White;
            this.btn_AddImage.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_AddImage.ForeColor = System.Drawing.Color.Black;
            this.btn_AddImage.Location = new System.Drawing.Point(442, 111);
            this.btn_AddImage.Name = "btn_AddImage";
            this.btn_AddImage.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_AddImage.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_AddImage.Radius = 9;
            this.btn_AddImage.Size = new System.Drawing.Size(88, 33);
            this.btn_AddImage.TabIndex = 22;
            this.btn_AddImage.Text = "选择子图片";
            this.btn_AddImage.UseVisualStyleBackColor = false;
            this.btn_AddImage.Click += new System.EventHandler(this.btn_AddImage_Click);
            // 
            // panel_AddDisplay
            // 
            this.panel_AddDisplay.Controls.Add(this.pb_AddImage);
            this.panel_AddDisplay.Location = new System.Drawing.Point(45, 3);
            this.panel_AddDisplay.Name = "panel_AddDisplay";
            this.panel_AddDisplay.Size = new System.Drawing.Size(322, 160);
            this.panel_AddDisplay.TabIndex = 21;
            // 
            // pb_AddImage
            // 
            this.pb_AddImage.AllowDrop = true;
            this.pb_AddImage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.pb_AddImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pb_AddImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_AddImage.Location = new System.Drawing.Point(0, 0);
            this.pb_AddImage.Name = "pb_AddImage";
            this.pb_AddImage.Size = new System.Drawing.Size(322, 160);
            this.pb_AddImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_AddImage.TabIndex = 13;
            this.pb_AddImage.TabStop = false;
            this.pb_AddImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.pb_AddImage_DragDrop);
            this.pb_AddImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.pb_AddImage_DragEnter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label1.Location = new System.Drawing.Point(11, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 76);
            this.label1.TabIndex = 20;
            this.label1.Text = "加\r\n数\r\n图\r\n片";
            // 
            // tabPage_ConnectArea
            // 
            this.tabPage_ConnectArea.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_ConnectArea.Controls.Add(this.groupBox1);
            this.tabPage_ConnectArea.Controls.Add(this.label57);
            this.tabPage_ConnectArea.Controls.Add(this.label58);
            this.tabPage_ConnectArea.Controls.Add(this.tb_AreaMin);
            this.tabPage_ConnectArea.Controls.Add(this.tb_AreaMaxNum);
            this.tabPage_ConnectArea.Controls.Add(this.label56);
            this.tabPage_ConnectArea.Controls.Add(this.nud_AreaIdx);
            this.tabPage_ConnectArea.Location = new System.Drawing.Point(4, 28);
            this.tabPage_ConnectArea.Name = "tabPage_ConnectArea";
            this.tabPage_ConnectArea.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_ConnectArea.Size = new System.Drawing.Size(613, 166);
            this.tabPage_ConnectArea.TabIndex = 30;
            this.tabPage_ConnectArea.Text = "连通域";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_Area);
            this.groupBox1.Controls.Add(this.tb_AreaCtr);
            this.groupBox1.Controls.Add(this.tb_AreaRect);
            this.groupBox1.Controls.Add(this.label55);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Location = new System.Drawing.Point(261, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 161);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输出";
            // 
            // lbl_Area
            // 
            this.lbl_Area.AutoSize = true;
            this.lbl_Area.Location = new System.Drawing.Point(215, 27);
            this.lbl_Area.Name = "lbl_Area";
            this.lbl_Area.Size = new System.Drawing.Size(87, 19);
            this.lbl_Area.TabIndex = 24;
            this.lbl_Area.Text = "连通域面积：";
            // 
            // tb_AreaCtr
            // 
            this.tb_AreaCtr.Location = new System.Drawing.Point(20, 50);
            this.tb_AreaCtr.Name = "tb_AreaCtr";
            this.tb_AreaCtr.Size = new System.Drawing.Size(103, 25);
            this.tb_AreaCtr.TabIndex = 19;
            // 
            // tb_AreaRect
            // 
            this.tb_AreaRect.Location = new System.Drawing.Point(20, 117);
            this.tb_AreaRect.Name = "tb_AreaRect";
            this.tb_AreaRect.Size = new System.Drawing.Size(233, 25);
            this.tb_AreaRect.TabIndex = 20;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label55.Location = new System.Drawing.Point(16, 25);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(79, 20);
            this.label55.TabIndex = 21;
            this.label55.Text = "中心点坐标";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label54.Location = new System.Drawing.Point(16, 90);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(107, 20);
            this.label54.TabIndex = 22;
            this.label54.Text = "最小外接矩坐标";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label57.Location = new System.Drawing.Point(163, 94);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(65, 20);
            this.label57.TabIndex = 26;
            this.label57.Text = "最小面积";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label58.Location = new System.Drawing.Point(163, 29);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(79, 20);
            this.label58.TabIndex = 25;
            this.label58.Text = "连通域数量";
            // 
            // tb_AreaMin
            // 
            this.tb_AreaMin.Location = new System.Drawing.Point(167, 121);
            this.tb_AreaMin.Name = "tb_AreaMin";
            this.tb_AreaMin.Size = new System.Drawing.Size(75, 25);
            this.tb_AreaMin.TabIndex = 24;
            this.tb_AreaMin.Text = "0";
            this.tb_AreaMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_AreaMaxNum
            // 
            this.tb_AreaMaxNum.Location = new System.Drawing.Point(167, 54);
            this.tb_AreaMaxNum.Name = "tb_AreaMaxNum";
            this.tb_AreaMaxNum.Size = new System.Drawing.Size(75, 25);
            this.tb_AreaMaxNum.TabIndex = 23;
            this.tb_AreaMaxNum.Text = "20";
            this.tb_AreaMaxNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label56.Location = new System.Drawing.Point(65, 59);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(65, 20);
            this.label56.TabIndex = 17;
            this.label56.Text = "轮廓序号\r\n";
            // 
            // nud_AreaIdx
            // 
            this.nud_AreaIdx.Location = new System.Drawing.Point(50, 85);
            this.nud_AreaIdx.Maximum = new decimal(new int[] {
            66,
            0,
            0,
            0});
            this.nud_AreaIdx.Name = "nud_AreaIdx";
            this.nud_AreaIdx.Size = new System.Drawing.Size(91, 25);
            this.nud_AreaIdx.TabIndex = 18;
            this.nud_AreaIdx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_AreaIdx.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage_HoughDetect
            // 
            this.tabPage_HoughDetect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_HoughDetect.Controls.Add(this.cb_HoughDetect);
            this.tabPage_HoughDetect.Controls.Add(this.gb_HoughLineP);
            this.tabPage_HoughDetect.Location = new System.Drawing.Point(4, 28);
            this.tabPage_HoughDetect.Name = "tabPage_HoughDetect";
            this.tabPage_HoughDetect.Size = new System.Drawing.Size(613, 166);
            this.tabPage_HoughDetect.TabIndex = 26;
            this.tabPage_HoughDetect.Text = "霍夫检测";
            // 
            // cb_HoughDetect
            // 
            this.cb_HoughDetect.BackColor = System.Drawing.Color.Transparent;
            this.cb_HoughDetect.BorderColor = System.Drawing.Color.Black;
            this.cb_HoughDetect.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_HoughDetect.Items.AddRange(new object[] {
            "HoughLineP"});
            this.cb_HoughDetect.Location = new System.Drawing.Point(20, 50);
            this.cb_HoughDetect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_HoughDetect.Name = "cb_HoughDetect";
            this.cb_HoughDetect.SelectedColor = System.Drawing.Color.Black;
            this.cb_HoughDetect.SelectedIndex = -1;
            this.cb_HoughDetect.Size = new System.Drawing.Size(100, 26);
            this.cb_HoughDetect.TabIndex = 11;
            this.cb_HoughDetect.UseRadius = true;
            this.cb_HoughDetect.SelectedIndexChanged += new ImageTool.Controls.UComboBox.SelectChangeHandler(this.cb_HoughDetect_SelectedIndexChanged);
            // 
            // gb_HoughLineP
            // 
            this.gb_HoughLineP.Controls.Add(this.tb_LineMaxGap);
            this.gb_HoughLineP.Controls.Add(this.tb_LineMinLen);
            this.gb_HoughLineP.Controls.Add(this.label20);
            this.gb_HoughLineP.Controls.Add(this.label19);
            this.gb_HoughLineP.Controls.Add(this.tb_LineRHO);
            this.gb_HoughLineP.Controls.Add(this.tb_LineThres);
            this.gb_HoughLineP.Controls.Add(this.tb_LineTheta);
            this.gb_HoughLineP.Controls.Add(this.label16);
            this.gb_HoughLineP.Controls.Add(this.label17);
            this.gb_HoughLineP.Controls.Add(this.label18);
            this.gb_HoughLineP.Location = new System.Drawing.Point(138, 3);
            this.gb_HoughLineP.Name = "gb_HoughLineP";
            this.gb_HoughLineP.Size = new System.Drawing.Size(472, 161);
            this.gb_HoughLineP.TabIndex = 8;
            this.gb_HoughLineP.TabStop = false;
            this.gb_HoughLineP.Text = "霍夫直线检测";
            // 
            // tb_LineMaxGap
            // 
            this.tb_LineMaxGap.Location = new System.Drawing.Point(233, 115);
            this.tb_LineMaxGap.Name = "tb_LineMaxGap";
            this.tb_LineMaxGap.Size = new System.Drawing.Size(50, 25);
            this.tb_LineMaxGap.TabIndex = 5;
            this.tb_LineMaxGap.Text = "0";
            this.tb_LineMaxGap.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LineMinLen
            // 
            this.tb_LineMinLen.Location = new System.Drawing.Point(94, 115);
            this.tb_LineMinLen.Name = "tb_LineMinLen";
            this.tb_LineMinLen.Size = new System.Drawing.Size(50, 25);
            this.tb_LineMinLen.TabIndex = 4;
            this.tb_LineMinLen.Text = "0";
            this.tb_LineMinLen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(214, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(87, 19);
            this.label20.TabIndex = 8;
            this.label20.Text = "点间最大间距";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(90, 93);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(61, 19);
            this.label19.TabIndex = 7;
            this.label19.Text = "最小线长";
            // 
            // tb_LineRHO
            // 
            this.tb_LineRHO.Location = new System.Drawing.Point(94, 54);
            this.tb_LineRHO.Name = "tb_LineRHO";
            this.tb_LineRHO.Size = new System.Drawing.Size(50, 25);
            this.tb_LineRHO.TabIndex = 1;
            this.tb_LineRHO.Text = "1";
            this.tb_LineRHO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LineThres
            // 
            this.tb_LineThres.Location = new System.Drawing.Point(350, 53);
            this.tb_LineThres.Name = "tb_LineThres";
            this.tb_LineThres.Size = new System.Drawing.Size(50, 25);
            this.tb_LineThres.TabIndex = 3;
            this.tb_LineThres.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_LineTheta
            // 
            this.tb_LineTheta.Location = new System.Drawing.Point(233, 54);
            this.tb_LineTheta.Name = "tb_LineTheta";
            this.tb_LineTheta.Size = new System.Drawing.Size(50, 25);
            this.tb_LineTheta.TabIndex = 2;
            this.tb_LineTheta.Text = "180";
            this.tb_LineTheta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(340, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 19);
            this.label16.TabIndex = 2;
            this.label16.Text = "累加器阈值";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(218, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 19);
            this.label17.TabIndex = 1;
            this.label17.Text = "角度分辨率";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(70, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(100, 19);
            this.label18.TabIndex = 0;
            this.label18.Text = "像素距离分辨率";
            // 
            // tabPage_Perspective
            // 
            this.tabPage_Perspective.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Perspective.Controls.Add(this.btn_PersDstPts);
            this.tabPage_Perspective.Controls.Add(this.btn_PersSrcPts);
            this.tabPage_Perspective.Controls.Add(this.cb_PersSize);
            this.tabPage_Perspective.Controls.Add(this.tb_PersHeight);
            this.tabPage_Perspective.Controls.Add(this.label51);
            this.tabPage_Perspective.Controls.Add(this.tb_PersWidth);
            this.tabPage_Perspective.Controls.Add(this.label50);
            this.tabPage_Perspective.Controls.Add(this.label49);
            this.tabPage_Perspective.Controls.Add(this.label48);
            this.tabPage_Perspective.Controls.Add(this.tb_PersDstPts);
            this.tabPage_Perspective.Controls.Add(this.tb_PersSrcPts);
            this.tabPage_Perspective.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Perspective.Name = "tabPage_Perspective";
            this.tabPage_Perspective.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Perspective.TabIndex = 29;
            this.tabPage_Perspective.Text = "透视变换";
            this.tabPage_Perspective.ParentChanged += new System.EventHandler(this.tabPage_Perspective_ParentChanged);
            // 
            // btn_PersDstPts
            // 
            this.btn_PersDstPts.BackColor = System.Drawing.Color.White;
            this.btn_PersDstPts.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_PersDstPts.ForeColor = System.Drawing.Color.Black;
            this.btn_PersDstPts.Location = new System.Drawing.Point(434, 56);
            this.btn_PersDstPts.Name = "btn_PersDstPts";
            this.btn_PersDstPts.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_PersDstPts.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_PersDstPts.Radius = 9;
            this.btn_PersDstPts.Size = new System.Drawing.Size(91, 33);
            this.btn_PersDstPts.TabIndex = 12;
            this.btn_PersDstPts.Text = "更新区域";
            this.btn_PersDstPts.UseVisualStyleBackColor = false;
            this.btn_PersDstPts.Click += new System.EventHandler(this.btn_PersDstPts_Click);
            // 
            // btn_PersSrcPts
            // 
            this.btn_PersSrcPts.BackColor = System.Drawing.Color.White;
            this.btn_PersSrcPts.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_PersSrcPts.ForeColor = System.Drawing.Color.Black;
            this.btn_PersSrcPts.Location = new System.Drawing.Point(434, 16);
            this.btn_PersSrcPts.Name = "btn_PersSrcPts";
            this.btn_PersSrcPts.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_PersSrcPts.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_PersSrcPts.Radius = 9;
            this.btn_PersSrcPts.Size = new System.Drawing.Size(91, 33);
            this.btn_PersSrcPts.TabIndex = 11;
            this.btn_PersSrcPts.Text = "更新区域";
            this.btn_PersSrcPts.UseVisualStyleBackColor = false;
            this.btn_PersSrcPts.Click += new System.EventHandler(this.btn_PersSrcPts_Click);
            // 
            // cb_PersSize
            // 
            this.cb_PersSize.FormattingEnabled = true;
            this.cb_PersSize.Items.AddRange(new object[] {
            "原图尺寸",
            "目标顶点组成的正矩形尺寸",
            "自定义尺寸"});
            this.cb_PersSize.Location = new System.Drawing.Point(142, 113);
            this.cb_PersSize.Name = "cb_PersSize";
            this.cb_PersSize.Size = new System.Drawing.Size(148, 27);
            this.cb_PersSize.TabIndex = 10;
            this.cb_PersSize.SelectedIndexChanged += new System.EventHandler(this.cb_PersSize_SelectedIndexChanged);
            // 
            // tb_PersHeight
            // 
            this.tb_PersHeight.Location = new System.Drawing.Point(353, 130);
            this.tb_PersHeight.Name = "tb_PersHeight";
            this.tb_PersHeight.Size = new System.Drawing.Size(75, 25);
            this.tb_PersHeight.TabIndex = 9;
            this.tb_PersHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(296, 94);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(51, 57);
            this.label51.TabIndex = 8;
            this.label51.Text = "|--宽：\r\n|\r\n|--高：";
            // 
            // tb_PersWidth
            // 
            this.tb_PersWidth.Location = new System.Drawing.Point(353, 91);
            this.tb_PersWidth.Name = "tb_PersWidth";
            this.tb_PersWidth.Size = new System.Drawing.Size(75, 25);
            this.tb_PersWidth.TabIndex = 7;
            this.tb_PersWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Location = new System.Drawing.Point(49, 116);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(87, 19);
            this.label50.TabIndex = 6;
            this.label50.Text = "目标图像尺寸";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(75, 63);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(61, 19);
            this.label49.TabIndex = 5;
            this.label49.Text = "目标顶点";
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(88, 23);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(48, 19);
            this.label48.TabIndex = 4;
            this.label48.Text = "源顶点";
            // 
            // tb_PersDstPts
            // 
            this.tb_PersDstPts.Location = new System.Drawing.Point(142, 60);
            this.tb_PersDstPts.Name = "tb_PersDstPts";
            this.tb_PersDstPts.Size = new System.Drawing.Size(286, 25);
            this.tb_PersDstPts.TabIndex = 3;
            this.toolTip_UseRemark.SetToolTip(this.tb_PersDstPts, "输入格式：\r\nx1,y1,x2,y2,x3,y3,x4,y4");
            // 
            // tb_PersSrcPts
            // 
            this.tb_PersSrcPts.Location = new System.Drawing.Point(142, 20);
            this.tb_PersSrcPts.Name = "tb_PersSrcPts";
            this.tb_PersSrcPts.Size = new System.Drawing.Size(286, 25);
            this.tb_PersSrcPts.TabIndex = 2;
            this.toolTip_UseRemark.SetToolTip(this.tb_PersSrcPts, "输入格式：\r\nx1,y1,x2,y2,x3,y3,x4,y4");
            // 
            // tabPage_Equalize
            // 
            this.tabPage_Equalize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Equalize.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Equalize.Name = "tabPage_Equalize";
            this.tabPage_Equalize.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Equalize.TabIndex = 25;
            this.tabPage_Equalize.Text = "均衡化";
            // 
            // tabPage_Normalize
            // 
            this.tabPage_Normalize.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Normalize.Controls.Add(this.tb_NormHigh);
            this.tabPage_Normalize.Controls.Add(this.tb_NormLow);
            this.tabPage_Normalize.Controls.Add(this.label39);
            this.tabPage_Normalize.Controls.Add(this.label40);
            this.tabPage_Normalize.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Normalize.Name = "tabPage_Normalize";
            this.tabPage_Normalize.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Normalize.TabIndex = 24;
            this.tabPage_Normalize.Text = "归一化";
            // 
            // tb_NormHigh
            // 
            this.tb_NormHigh.Location = new System.Drawing.Point(371, 70);
            this.tb_NormHigh.Name = "tb_NormHigh";
            this.tb_NormHigh.Size = new System.Drawing.Size(49, 25);
            this.tb_NormHigh.TabIndex = 11;
            this.tb_NormHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_NormLow
            // 
            this.tb_NormLow.Location = new System.Drawing.Point(228, 70);
            this.tb_NormLow.Name = "tb_NormLow";
            this.tb_NormLow.Size = new System.Drawing.Size(49, 25);
            this.tb_NormLow.TabIndex = 10;
            this.tb_NormLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(316, 73);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(38, 19);
            this.label39.TabIndex = 9;
            this.label39.Text = "High";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(179, 73);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(34, 19);
            this.label40.TabIndex = 8;
            this.label40.Text = "Low";
            // 
            // tabPage_DrawCanvas
            // 
            this.tabPage_DrawCanvas.Controls.Add(this.tb_CanvasC);
            this.tabPage_DrawCanvas.Controls.Add(this.tb_CanvasH);
            this.tabPage_DrawCanvas.Controls.Add(this.tb_CanvasW);
            this.tabPage_DrawCanvas.Controls.Add(this.label60);
            this.tabPage_DrawCanvas.Controls.Add(this.label59);
            this.tabPage_DrawCanvas.Controls.Add(this.label43);
            this.tabPage_DrawCanvas.Controls.Add(this.label42);
            this.tabPage_DrawCanvas.Controls.Add(this.pnl_CanvasColor);
            this.tabPage_DrawCanvas.Controls.Add(this.label3);
            this.tabPage_DrawCanvas.Controls.Add(this.nud_CanvasB);
            this.tabPage_DrawCanvas.Controls.Add(this.nud_CanvasG);
            this.tabPage_DrawCanvas.Controls.Add(this.nud_CanvasR);
            this.tabPage_DrawCanvas.Location = new System.Drawing.Point(4, 28);
            this.tabPage_DrawCanvas.Name = "tabPage_DrawCanvas";
            this.tabPage_DrawCanvas.Size = new System.Drawing.Size(613, 166);
            this.tabPage_DrawCanvas.TabIndex = 35;
            this.tabPage_DrawCanvas.Text = "画布";
            this.tabPage_DrawCanvas.UseVisualStyleBackColor = true;
            // 
            // tb_CanvasC
            // 
            this.tb_CanvasC.Location = new System.Drawing.Point(180, 104);
            this.tb_CanvasC.Name = "tb_CanvasC";
            this.tb_CanvasC.Size = new System.Drawing.Size(63, 25);
            this.tb_CanvasC.TabIndex = 88;
            this.tb_CanvasC.Text = "3";
            this.tb_CanvasC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_CanvasC.TextChanged += new System.EventHandler(this.tb_CanvasC_TextChanged);
            // 
            // tb_CanvasH
            // 
            this.tb_CanvasH.Location = new System.Drawing.Point(180, 77);
            this.tb_CanvasH.Name = "tb_CanvasH";
            this.tb_CanvasH.Size = new System.Drawing.Size(63, 25);
            this.tb_CanvasH.TabIndex = 87;
            this.tb_CanvasH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_CanvasW
            // 
            this.tb_CanvasW.Location = new System.Drawing.Point(180, 50);
            this.tb_CanvasW.Name = "tb_CanvasW";
            this.tb_CanvasW.Size = new System.Drawing.Size(63, 25);
            this.tb_CanvasW.TabIndex = 86;
            this.tb_CanvasW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label60.Location = new System.Drawing.Point(131, 106);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(35, 19);
            this.label60.TabIndex = 85;
            this.label60.Text = "通道";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label59.Location = new System.Drawing.Point(137, 79);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(22, 19);
            this.label59.TabIndex = 84;
            this.label59.Text = "高";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label43.Location = new System.Drawing.Point(137, 52);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(22, 19);
            this.label43.TabIndex = 83;
            this.label43.Text = "宽";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label42.Location = new System.Drawing.Point(157, 15);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(74, 19);
            this.label42.TabIndex = 82;
            this.label42.Text = "背景布尺寸";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_CanvasColor
            // 
            this.pnl_CanvasColor.Location = new System.Drawing.Point(340, 66);
            this.pnl_CanvasColor.Name = "pnl_CanvasColor";
            this.pnl_CanvasColor.Size = new System.Drawing.Size(25, 25);
            this.pnl_CanvasColor.TabIndex = 81;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label3.Location = new System.Drawing.Point(379, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 19);
            this.label3.TabIndex = 80;
            this.label3.Text = "背景布颜色";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_CanvasB
            // 
            this.nud_CanvasB.Location = new System.Drawing.Point(386, 104);
            this.nud_CanvasB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CanvasB.Name = "nud_CanvasB";
            this.nud_CanvasB.Size = new System.Drawing.Size(64, 25);
            this.nud_CanvasB.TabIndex = 79;
            this.nud_CanvasB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CanvasB.ValueChanged += new System.EventHandler(this.nud_CanvasB_ValueChanged);
            // 
            // nud_CanvasG
            // 
            this.nud_CanvasG.Location = new System.Drawing.Point(386, 77);
            this.nud_CanvasG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CanvasG.Name = "nud_CanvasG";
            this.nud_CanvasG.Size = new System.Drawing.Size(64, 25);
            this.nud_CanvasG.TabIndex = 78;
            this.nud_CanvasG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CanvasG.ValueChanged += new System.EventHandler(this.nud_CanvasG_ValueChanged);
            // 
            // nud_CanvasR
            // 
            this.nud_CanvasR.Location = new System.Drawing.Point(386, 50);
            this.nud_CanvasR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CanvasR.Name = "nud_CanvasR";
            this.nud_CanvasR.Size = new System.Drawing.Size(64, 25);
            this.nud_CanvasR.TabIndex = 77;
            this.nud_CanvasR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CanvasR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CanvasR.ValueChanged += new System.EventHandler(this.nud_CanvasR_ValueChanged);
            // 
            // tabPage_DrawPts
            // 
            this.tabPage_DrawPts.Controls.Add(this.tb_PtsSet);
            this.tabPage_DrawPts.Controls.Add(this.label53);
            this.tabPage_DrawPts.Controls.Add(this.pnl_PtsColor);
            this.tabPage_DrawPts.Controls.Add(this.label41);
            this.tabPage_DrawPts.Controls.Add(this.label52);
            this.tabPage_DrawPts.Controls.Add(this.nud_PtsB);
            this.tabPage_DrawPts.Controls.Add(this.nud_PtsG);
            this.tabPage_DrawPts.Controls.Add(this.nud_PtsR);
            this.tabPage_DrawPts.Controls.Add(this.nud_PtsThick);
            this.tabPage_DrawPts.Location = new System.Drawing.Point(4, 28);
            this.tabPage_DrawPts.Name = "tabPage_DrawPts";
            this.tabPage_DrawPts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DrawPts.Size = new System.Drawing.Size(613, 166);
            this.tabPage_DrawPts.TabIndex = 33;
            this.tabPage_DrawPts.Text = "画点";
            this.tabPage_DrawPts.UseVisualStyleBackColor = true;
            // 
            // tb_PtsSet
            // 
            this.tb_PtsSet.Location = new System.Drawing.Point(36, 39);
            this.tb_PtsSet.Multiline = true;
            this.tb_PtsSet.Name = "tb_PtsSet";
            this.tb_PtsSet.Size = new System.Drawing.Size(242, 112);
            this.tb_PtsSet.TabIndex = 78;
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(121, 15);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(61, 19);
            this.label53.TabIndex = 77;
            this.label53.Text = "点集坐标";
            // 
            // pnl_PtsColor
            // 
            this.pnl_PtsColor.Location = new System.Drawing.Point(340, 66);
            this.pnl_PtsColor.Name = "pnl_PtsColor";
            this.pnl_PtsColor.Size = new System.Drawing.Size(25, 25);
            this.pnl_PtsColor.TabIndex = 76;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label41.Location = new System.Drawing.Point(483, 15);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(61, 19);
            this.label41.TabIndex = 74;
            this.label41.Text = "点的尺寸";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label52.Location = new System.Drawing.Point(391, 15);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(48, 19);
            this.label52.TabIndex = 73;
            this.label52.Text = "点颜色";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_PtsB
            // 
            this.nud_PtsB.Location = new System.Drawing.Point(386, 104);
            this.nud_PtsB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_PtsB.Name = "nud_PtsB";
            this.nud_PtsB.Size = new System.Drawing.Size(64, 25);
            this.nud_PtsB.TabIndex = 71;
            this.nud_PtsB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_PtsB.ValueChanged += new System.EventHandler(this.nud_PtsB_ValueChanged);
            // 
            // nud_PtsG
            // 
            this.nud_PtsG.Location = new System.Drawing.Point(386, 77);
            this.nud_PtsG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_PtsG.Name = "nud_PtsG";
            this.nud_PtsG.Size = new System.Drawing.Size(64, 25);
            this.nud_PtsG.TabIndex = 70;
            this.nud_PtsG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_PtsG.ValueChanged += new System.EventHandler(this.nud_PtsG_ValueChanged);
            // 
            // nud_PtsR
            // 
            this.nud_PtsR.Location = new System.Drawing.Point(386, 50);
            this.nud_PtsR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_PtsR.Name = "nud_PtsR";
            this.nud_PtsR.Size = new System.Drawing.Size(64, 25);
            this.nud_PtsR.TabIndex = 69;
            this.nud_PtsR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_PtsR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_PtsR.ValueChanged += new System.EventHandler(this.nud_PtsR_ValueChanged);
            // 
            // nud_PtsThick
            // 
            this.nud_PtsThick.Location = new System.Drawing.Point(487, 50);
            this.nud_PtsThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_PtsThick.Name = "nud_PtsThick";
            this.nud_PtsThick.Size = new System.Drawing.Size(64, 25);
            this.nud_PtsThick.TabIndex = 72;
            this.nud_PtsThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_PtsThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tabPage_DrawLine
            // 
            this.tabPage_DrawLine.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_DrawLine.Controls.Add(this.pnl_LineColor);
            this.tabPage_DrawLine.Controls.Add(this.Grid_Line);
            this.tabPage_DrawLine.Controls.Add(this.label_LineThickness);
            this.tabPage_DrawLine.Controls.Add(this.label_LineColor);
            this.tabPage_DrawLine.Controls.Add(this.nud_LineB);
            this.tabPage_DrawLine.Controls.Add(this.nud_LineG);
            this.tabPage_DrawLine.Controls.Add(this.nud_LineR);
            this.tabPage_DrawLine.Controls.Add(this.nud_LineThick);
            this.tabPage_DrawLine.Controls.Add(this.label_LinePos);
            this.tabPage_DrawLine.Location = new System.Drawing.Point(4, 28);
            this.tabPage_DrawLine.Name = "tabPage_DrawLine";
            this.tabPage_DrawLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DrawLine.Size = new System.Drawing.Size(613, 166);
            this.tabPage_DrawLine.TabIndex = 8;
            this.tabPage_DrawLine.Text = "画线";
            // 
            // pnl_LineColor
            // 
            this.pnl_LineColor.Location = new System.Drawing.Point(340, 66);
            this.pnl_LineColor.Name = "pnl_LineColor";
            this.pnl_LineColor.Size = new System.Drawing.Size(25, 25);
            this.pnl_LineColor.TabIndex = 68;
            // 
            // Grid_Line
            // 
            this.Grid_Line.AllowUserToResizeColumns = false;
            this.Grid_Line.AllowUserToResizeRows = false;
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Line.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.Grid_Line.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Grid_Line.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_Line.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_Line.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Line.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.Grid_Line.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Line.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Line.DefaultCellStyle = dataGridViewCellStyle23;
            this.Grid_Line.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Line.Location = new System.Drawing.Point(12, 29);
            this.Grid_Line.Name = "Grid_Line";
            this.Grid_Line.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Line.RowHeadersDefaultCellStyle = dataGridViewCellStyle24;
            this.Grid_Line.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Grid_Line.RowTemplate.Height = 23;
            this.Grid_Line.Size = new System.Drawing.Size(300, 135);
            this.Grid_Line.TabIndex = 38;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "X";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Y";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // label_LineThickness
            // 
            this.label_LineThickness.AutoSize = true;
            this.label_LineThickness.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_LineThickness.Location = new System.Drawing.Point(483, 15);
            this.label_LineThickness.Name = "label_LineThickness";
            this.label_LineThickness.Size = new System.Drawing.Size(61, 19);
            this.label_LineThickness.TabIndex = 50;
            this.label_LineThickness.Text = "直线粗细";
            // 
            // label_LineColor
            // 
            this.label_LineColor.AutoSize = true;
            this.label_LineColor.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_LineColor.Location = new System.Drawing.Point(382, 15);
            this.label_LineColor.Name = "label_LineColor";
            this.label_LineColor.Size = new System.Drawing.Size(61, 19);
            this.label_LineColor.TabIndex = 49;
            this.label_LineColor.Text = "直线颜色";
            this.label_LineColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_LineB
            // 
            this.nud_LineB.Location = new System.Drawing.Point(386, 104);
            this.nud_LineB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_LineB.Name = "nud_LineB";
            this.nud_LineB.Size = new System.Drawing.Size(64, 25);
            this.nud_LineB.TabIndex = 41;
            this.nud_LineB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_LineB.ValueChanged += new System.EventHandler(this.nud_LineB_ValueChanged);
            // 
            // nud_LineG
            // 
            this.nud_LineG.Location = new System.Drawing.Point(386, 77);
            this.nud_LineG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_LineG.Name = "nud_LineG";
            this.nud_LineG.Size = new System.Drawing.Size(64, 25);
            this.nud_LineG.TabIndex = 40;
            this.nud_LineG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_LineG.ValueChanged += new System.EventHandler(this.nud_LineG_ValueChanged);
            // 
            // nud_LineR
            // 
            this.nud_LineR.Location = new System.Drawing.Point(386, 50);
            this.nud_LineR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_LineR.Name = "nud_LineR";
            this.nud_LineR.Size = new System.Drawing.Size(64, 25);
            this.nud_LineR.TabIndex = 39;
            this.nud_LineR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_LineR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_LineR.ValueChanged += new System.EventHandler(this.nud_LineR_ValueChanged);
            // 
            // nud_LineThick
            // 
            this.nud_LineThick.Location = new System.Drawing.Point(487, 50);
            this.nud_LineThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_LineThick.Name = "nud_LineThick";
            this.nud_LineThick.Size = new System.Drawing.Size(64, 25);
            this.nud_LineThick.TabIndex = 42;
            this.nud_LineThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_LineThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_LinePos
            // 
            this.label_LinePos.AutoSize = true;
            this.label_LinePos.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_LinePos.Location = new System.Drawing.Point(112, 5);
            this.label_LinePos.Name = "label_LinePos";
            this.label_LinePos.Size = new System.Drawing.Size(87, 19);
            this.label_LinePos.TabIndex = 42;
            this.label_LinePos.Text = "直线两点坐标";
            // 
            // tabPage_DrawRect
            // 
            this.tabPage_DrawRect.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_DrawRect.Controls.Add(this.cbx_IsPRect);
            this.tabPage_DrawRect.Controls.Add(this.pnl_RectColor);
            this.tabPage_DrawRect.Controls.Add(this.Grid_Rect);
            this.tabPage_DrawRect.Controls.Add(this.label_RectThickness);
            this.tabPage_DrawRect.Controls.Add(this.label_RectColor);
            this.tabPage_DrawRect.Controls.Add(this.nud_RectB);
            this.tabPage_DrawRect.Controls.Add(this.nud_RectG);
            this.tabPage_DrawRect.Controls.Add(this.nud_RectR);
            this.tabPage_DrawRect.Controls.Add(this.nud_RectThick);
            this.tabPage_DrawRect.Controls.Add(this.label_RectPos);
            this.tabPage_DrawRect.Location = new System.Drawing.Point(4, 28);
            this.tabPage_DrawRect.Name = "tabPage_DrawRect";
            this.tabPage_DrawRect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DrawRect.Size = new System.Drawing.Size(613, 166);
            this.tabPage_DrawRect.TabIndex = 10;
            this.tabPage_DrawRect.Text = "画矩形";
            // 
            // cbx_IsPRect
            // 
            this.cbx_IsPRect.AutoSize = true;
            this.cbx_IsPRect.BackCheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.cbx_IsPRect.Checked = true;
            this.cbx_IsPRect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbx_IsPRect.ForeCheckColor = System.Drawing.Color.White;
            this.cbx_IsPRect.Location = new System.Drawing.Point(539, 137);
            this.cbx_IsPRect.Name = "cbx_IsPRect";
            this.cbx_IsPRect.Size = new System.Drawing.Size(67, 23);
            this.cbx_IsPRect.Stroke = 3F;
            this.cbx_IsPRect.TabIndex = 72;
            this.cbx_IsPRect.Text = "正矩形";
            this.cbx_IsPRect.UseVisualStyleBackColor = true;
            // 
            // pnl_RectColor
            // 
            this.pnl_RectColor.Location = new System.Drawing.Point(340, 66);
            this.pnl_RectColor.Name = "pnl_RectColor";
            this.pnl_RectColor.Size = new System.Drawing.Size(25, 25);
            this.pnl_RectColor.TabIndex = 69;
            // 
            // Grid_Rect
            // 
            this.Grid_Rect.AllowUserToResizeColumns = false;
            this.Grid_Rect.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Rect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.Grid_Rect.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Grid_Rect.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_Rect.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_Rect.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Rect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.Grid_Rect.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Rect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Rect.DefaultCellStyle = dataGridViewCellStyle27;
            this.Grid_Rect.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Rect.Location = new System.Drawing.Point(12, 29);
            this.Grid_Rect.Name = "Grid_Rect";
            this.Grid_Rect.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Rect.RowHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.Grid_Rect.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Grid_Rect.RowTemplate.Height = 23;
            this.Grid_Rect.Size = new System.Drawing.Size(300, 135);
            this.Grid_Rect.TabIndex = 54;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "X";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Y";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // label_RectThickness
            // 
            this.label_RectThickness.AutoSize = true;
            this.label_RectThickness.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_RectThickness.Location = new System.Drawing.Point(483, 15);
            this.label_RectThickness.Name = "label_RectThickness";
            this.label_RectThickness.Size = new System.Drawing.Size(61, 19);
            this.label_RectThickness.TabIndex = 63;
            this.label_RectThickness.Text = "线条粗细";
            // 
            // label_RectColor
            // 
            this.label_RectColor.AutoSize = true;
            this.label_RectColor.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_RectColor.Location = new System.Drawing.Point(382, 15);
            this.label_RectColor.Name = "label_RectColor";
            this.label_RectColor.Size = new System.Drawing.Size(61, 19);
            this.label_RectColor.TabIndex = 62;
            this.label_RectColor.Text = "矩形颜色\r\n";
            this.label_RectColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_RectB
            // 
            this.nud_RectB.Location = new System.Drawing.Point(386, 104);
            this.nud_RectB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_RectB.Name = "nud_RectB";
            this.nud_RectB.Size = new System.Drawing.Size(64, 25);
            this.nud_RectB.TabIndex = 57;
            this.nud_RectB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_RectB.ValueChanged += new System.EventHandler(this.nud_RectB_ValueChanged);
            // 
            // nud_RectG
            // 
            this.nud_RectG.Location = new System.Drawing.Point(386, 77);
            this.nud_RectG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_RectG.Name = "nud_RectG";
            this.nud_RectG.Size = new System.Drawing.Size(64, 25);
            this.nud_RectG.TabIndex = 56;
            this.nud_RectG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_RectG.ValueChanged += new System.EventHandler(this.nud_RectG_ValueChanged);
            // 
            // nud_RectR
            // 
            this.nud_RectR.Location = new System.Drawing.Point(386, 50);
            this.nud_RectR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_RectR.Name = "nud_RectR";
            this.nud_RectR.Size = new System.Drawing.Size(64, 25);
            this.nud_RectR.TabIndex = 55;
            this.nud_RectR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_RectR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_RectR.ValueChanged += new System.EventHandler(this.nud_RectR_ValueChanged);
            // 
            // nud_RectThick
            // 
            this.nud_RectThick.Location = new System.Drawing.Point(487, 50);
            this.nud_RectThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_RectThick.Name = "nud_RectThick";
            this.nud_RectThick.Size = new System.Drawing.Size(64, 25);
            this.nud_RectThick.TabIndex = 58;
            this.nud_RectThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_RectThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_RectPos
            // 
            this.label_RectPos.AutoSize = true;
            this.label_RectPos.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_RectPos.Location = new System.Drawing.Point(112, 5);
            this.label_RectPos.Name = "label_RectPos";
            this.label_RectPos.Size = new System.Drawing.Size(87, 19);
            this.label_RectPos.TabIndex = 61;
            this.label_RectPos.Text = "矩形四点坐标";
            // 
            // tabPage_DrawCircle
            // 
            this.tabPage_DrawCircle.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_DrawCircle.Controls.Add(this.pnl_CircleColor);
            this.tabPage_DrawCircle.Controls.Add(this.Grid_Circle);
            this.tabPage_DrawCircle.Controls.Add(this.label_CircleThickness);
            this.tabPage_DrawCircle.Controls.Add(this.label_CircleColor);
            this.tabPage_DrawCircle.Controls.Add(this.nud_CircleB);
            this.tabPage_DrawCircle.Controls.Add(this.nud_CircleG);
            this.tabPage_DrawCircle.Controls.Add(this.nud_CircleR);
            this.tabPage_DrawCircle.Controls.Add(this.nud_CircleThick);
            this.tabPage_DrawCircle.Controls.Add(this.label_CirclePos);
            this.tabPage_DrawCircle.Location = new System.Drawing.Point(4, 28);
            this.tabPage_DrawCircle.Name = "tabPage_DrawCircle";
            this.tabPage_DrawCircle.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_DrawCircle.Size = new System.Drawing.Size(613, 166);
            this.tabPage_DrawCircle.TabIndex = 9;
            this.tabPage_DrawCircle.Text = "画圆";
            // 
            // pnl_CircleColor
            // 
            this.pnl_CircleColor.Location = new System.Drawing.Point(340, 66);
            this.pnl_CircleColor.Name = "pnl_CircleColor";
            this.pnl_CircleColor.Size = new System.Drawing.Size(25, 25);
            this.pnl_CircleColor.TabIndex = 70;
            // 
            // Grid_Circle
            // 
            this.Grid_Circle.AllowUserToResizeColumns = false;
            this.Grid_Circle.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Circle.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.Grid_Circle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Grid_Circle.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Grid_Circle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Grid_Circle.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Circle.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.Grid_Circle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Circle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.R});
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Circle.DefaultCellStyle = dataGridViewCellStyle31;
            this.Grid_Circle.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.Grid_Circle.Location = new System.Drawing.Point(12, 29);
            this.Grid_Circle.Name = "Grid_Circle";
            this.Grid_Circle.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid_Circle.RowHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.Grid_Circle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.Grid_Circle.RowTemplate.Height = 23;
            this.Grid_Circle.Size = new System.Drawing.Size(300, 135);
            this.Grid_Circle.TabIndex = 55;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "X";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Y";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 60;
            // 
            // R
            // 
            this.R.HeaderText = "R";
            this.R.Name = "R";
            this.R.Width = 60;
            // 
            // label_CircleThickness
            // 
            this.label_CircleThickness.AutoSize = true;
            this.label_CircleThickness.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_CircleThickness.Location = new System.Drawing.Point(483, 15);
            this.label_CircleThickness.Name = "label_CircleThickness";
            this.label_CircleThickness.Size = new System.Drawing.Size(61, 19);
            this.label_CircleThickness.TabIndex = 63;
            this.label_CircleThickness.Text = "线条粗细";
            // 
            // label_CircleColor
            // 
            this.label_CircleColor.AutoSize = true;
            this.label_CircleColor.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_CircleColor.Location = new System.Drawing.Point(382, 15);
            this.label_CircleColor.Name = "label_CircleColor";
            this.label_CircleColor.Size = new System.Drawing.Size(61, 19);
            this.label_CircleColor.TabIndex = 62;
            this.label_CircleColor.Text = "圆的颜色\r\n";
            this.label_CircleColor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // nud_CircleB
            // 
            this.nud_CircleB.Location = new System.Drawing.Point(386, 104);
            this.nud_CircleB.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CircleB.Name = "nud_CircleB";
            this.nud_CircleB.Size = new System.Drawing.Size(64, 25);
            this.nud_CircleB.TabIndex = 58;
            this.nud_CircleB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CircleB.ValueChanged += new System.EventHandler(this.nud_CircleB_ValueChanged);
            // 
            // nud_CircleG
            // 
            this.nud_CircleG.Location = new System.Drawing.Point(386, 77);
            this.nud_CircleG.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CircleG.Name = "nud_CircleG";
            this.nud_CircleG.Size = new System.Drawing.Size(64, 25);
            this.nud_CircleG.TabIndex = 57;
            this.nud_CircleG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CircleG.ValueChanged += new System.EventHandler(this.nud_CircleG_ValueChanged);
            // 
            // nud_CircleR
            // 
            this.nud_CircleR.Location = new System.Drawing.Point(386, 50);
            this.nud_CircleR.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CircleR.Name = "nud_CircleR";
            this.nud_CircleR.Size = new System.Drawing.Size(64, 25);
            this.nud_CircleR.TabIndex = 56;
            this.nud_CircleR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CircleR.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nud_CircleR.ValueChanged += new System.EventHandler(this.nud_CircleR_ValueChanged);
            // 
            // nud_CircleThick
            // 
            this.nud_CircleThick.Location = new System.Drawing.Point(487, 50);
            this.nud_CircleThick.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.nud_CircleThick.Name = "nud_CircleThick";
            this.nud_CircleThick.Size = new System.Drawing.Size(64, 25);
            this.nud_CircleThick.TabIndex = 59;
            this.nud_CircleThick.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_CircleThick.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_CirclePos
            // 
            this.label_CirclePos.AutoSize = true;
            this.label_CirclePos.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_CirclePos.Location = new System.Drawing.Point(112, 5);
            this.label_CirclePos.Name = "label_CirclePos";
            this.label_CirclePos.Size = new System.Drawing.Size(61, 19);
            this.label_CirclePos.TabIndex = 61;
            this.label_CirclePos.Text = "圆点坐标";
            // 
            // tabPage_Flip
            // 
            this.tabPage_Flip.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Flip.Controls.Add(this.label47);
            this.tabPage_Flip.Controls.Add(this.tb_FlipDirect);
            this.tabPage_Flip.Controls.Add(this.label46);
            this.tabPage_Flip.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Flip.Name = "tabPage_Flip";
            this.tabPage_Flip.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Flip.TabIndex = 28;
            this.tabPage_Flip.Text = "图片翻转";
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.ForeColor = System.Drawing.Color.Coral;
            this.label47.Location = new System.Drawing.Point(489, 101);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(115, 57);
            this.label47.TabIndex = 2;
            this.label47.Text = "0：绕 x 轴翻转\r\n1：绕 y 轴翻转\r\n-1：绕 y = x 翻转";
            // 
            // tb_FlipDirect
            // 
            this.tb_FlipDirect.Location = new System.Drawing.Point(264, 81);
            this.tb_FlipDirect.Name = "tb_FlipDirect";
            this.tb_FlipDirect.Size = new System.Drawing.Size(56, 25);
            this.tb_FlipDirect.TabIndex = 1;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(248, 54);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(87, 19);
            this.label46.TabIndex = 0;
            this.label46.Text = "图片翻转方向";
            // 
            // tabPage_Thin
            // 
            this.tabPage_Thin.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Thin.Controls.Add(this.cb_ThinTypes);
            this.tabPage_Thin.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Thin.Name = "tabPage_Thin";
            this.tabPage_Thin.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Thin.TabIndex = 32;
            this.tabPage_Thin.Text = "二值图细化";
            // 
            // cb_ThinTypes
            // 
            this.cb_ThinTypes.BackColor = System.Drawing.Color.Transparent;
            this.cb_ThinTypes.BorderColor = System.Drawing.Color.Black;
            this.cb_ThinTypes.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_ThinTypes.Items.AddRange(new object[] {
            "背景为白色",
            "背景为黑色"});
            this.cb_ThinTypes.Location = new System.Drawing.Point(240, 50);
            this.cb_ThinTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_ThinTypes.Name = "cb_ThinTypes";
            this.cb_ThinTypes.SelectedColor = System.Drawing.Color.Black;
            this.cb_ThinTypes.SelectedIndex = -1;
            this.cb_ThinTypes.Size = new System.Drawing.Size(111, 26);
            this.cb_ThinTypes.TabIndex = 1;
            this.cb_ThinTypes.UseRadius = true;
            // 
            // tabPage_HSV2Binary
            // 
            this.tabPage_HSV2Binary.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_HSV2Binary.Controls.Add(this.btn_ExportHSV);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_HighV);
            this.tabPage_HSV2Binary.Controls.Add(this.label_Value);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_LowV);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_HighS);
            this.tabPage_HSV2Binary.Controls.Add(this.label_Saturability);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_LowS);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_HighH);
            this.tabPage_HSV2Binary.Controls.Add(this.label_Hue);
            this.tabPage_HSV2Binary.Controls.Add(this.nud_LowH);
            this.tabPage_HSV2Binary.Location = new System.Drawing.Point(4, 28);
            this.tabPage_HSV2Binary.Name = "tabPage_HSV2Binary";
            this.tabPage_HSV2Binary.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_HSV2Binary.Size = new System.Drawing.Size(613, 166);
            this.tabPage_HSV2Binary.TabIndex = 6;
            this.tabPage_HSV2Binary.Text = "过滤颜色";
            // 
            // btn_ExportHSV
            // 
            this.btn_ExportHSV.BackColor = System.Drawing.Color.White;
            this.btn_ExportHSV.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_ExportHSV.ForeColor = System.Drawing.Color.Black;
            this.btn_ExportHSV.Location = new System.Drawing.Point(556, 128);
            this.btn_ExportHSV.Name = "btn_ExportHSV";
            this.btn_ExportHSV.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(243)))), ((int)(((byte)(251)))));
            this.btn_ExportHSV.OnBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(131)))), ((int)(((byte)(196)))));
            this.btn_ExportHSV.Radius = 9;
            this.btn_ExportHSV.Size = new System.Drawing.Size(51, 32);
            this.btn_ExportHSV.TabIndex = 34;
            this.btn_ExportHSV.Text = "导出";
            this.btn_ExportHSV.UseVisualStyleBackColor = false;
            this.btn_ExportHSV.Click += new System.EventHandler(this.btn_ExportHSV_Click);
            // 
            // nud_HighV
            // 
            this.nud_HighV.DecimalPlaces = 2;
            this.nud_HighV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_HighV.Location = new System.Drawing.Point(412, 89);
            this.nud_HighV.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_HighV.Name = "nud_HighV";
            this.nud_HighV.Size = new System.Drawing.Size(89, 25);
            this.nud_HighV.TabIndex = 16;
            this.nud_HighV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_HighV.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Value
            // 
            this.label_Value.AutoSize = true;
            this.label_Value.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Value.Location = new System.Drawing.Point(450, 40);
            this.label_Value.Name = "label_Value";
            this.label_Value.Size = new System.Drawing.Size(16, 16);
            this.label_Value.TabIndex = 14;
            this.label_Value.Text = "V";
            // 
            // nud_LowV
            // 
            this.nud_LowV.DecimalPlaces = 2;
            this.nud_LowV.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_LowV.Location = new System.Drawing.Point(412, 62);
            this.nud_LowV.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_LowV.Name = "nud_LowV";
            this.nud_LowV.Size = new System.Drawing.Size(89, 25);
            this.nud_LowV.TabIndex = 15;
            this.nud_LowV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud_HighS
            // 
            this.nud_HighS.DecimalPlaces = 2;
            this.nud_HighS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_HighS.Location = new System.Drawing.Point(267, 89);
            this.nud_HighS.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_HighS.Name = "nud_HighS";
            this.nud_HighS.Size = new System.Drawing.Size(89, 25);
            this.nud_HighS.TabIndex = 13;
            this.nud_HighS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_HighS.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Saturability
            // 
            this.label_Saturability.AutoSize = true;
            this.label_Saturability.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Saturability.Location = new System.Drawing.Point(305, 40);
            this.label_Saturability.Name = "label_Saturability";
            this.label_Saturability.Size = new System.Drawing.Size(16, 16);
            this.label_Saturability.TabIndex = 11;
            this.label_Saturability.Text = "S";
            // 
            // nud_LowS
            // 
            this.nud_LowS.DecimalPlaces = 2;
            this.nud_LowS.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nud_LowS.Location = new System.Drawing.Point(267, 62);
            this.nud_LowS.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_LowS.Name = "nud_LowS";
            this.nud_LowS.Size = new System.Drawing.Size(89, 25);
            this.nud_LowS.TabIndex = 12;
            this.nud_LowS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // nud_HighH
            // 
            this.nud_HighH.Location = new System.Drawing.Point(116, 89);
            this.nud_HighH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nud_HighH.Name = "nud_HighH";
            this.nud_HighH.Size = new System.Drawing.Size(89, 25);
            this.nud_HighH.TabIndex = 10;
            this.nud_HighH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nud_HighH.Value = new decimal(new int[] {
            360,
            0,
            0,
            0});
            // 
            // label_Hue
            // 
            this.label_Hue.AutoSize = true;
            this.label_Hue.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_Hue.Location = new System.Drawing.Point(147, 40);
            this.label_Hue.Name = "label_Hue";
            this.label_Hue.Size = new System.Drawing.Size(16, 16);
            this.label_Hue.TabIndex = 8;
            this.label_Hue.Text = "H";
            // 
            // nud_LowH
            // 
            this.nud_LowH.Location = new System.Drawing.Point(116, 62);
            this.nud_LowH.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.nud_LowH.Name = "nud_LowH";
            this.nud_LowH.Size = new System.Drawing.Size(89, 25);
            this.nud_LowH.TabIndex = 9;
            this.nud_LowH.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabPage_Bilateral
            // 
            this.tabPage_Bilateral.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Bilateral.Controls.Add(this.tb_bilaSpace);
            this.tabPage_Bilateral.Controls.Add(this.label31);
            this.tabPage_Bilateral.Controls.Add(this.tb_bilaKSize);
            this.tabPage_Bilateral.Controls.Add(this.tb_bilaColor);
            this.tabPage_Bilateral.Controls.Add(this.label27);
            this.tabPage_Bilateral.Controls.Add(this.label30);
            this.tabPage_Bilateral.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Bilateral.Name = "tabPage_Bilateral";
            this.tabPage_Bilateral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Bilateral.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Bilateral.TabIndex = 21;
            this.tabPage_Bilateral.Text = "双边滤波";
            // 
            // tb_bilaSpace
            // 
            this.tb_bilaSpace.Location = new System.Drawing.Point(375, 80);
            this.tb_bilaSpace.Name = "tb_bilaSpace";
            this.tb_bilaSpace.Size = new System.Drawing.Size(50, 25);
            this.tb_bilaSpace.TabIndex = 13;
            this.tb_bilaSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(377, 50);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(53, 19);
            this.label31.TabIndex = 12;
            this.label31.Text = "sigmaS";
            // 
            // tb_bilaKSize
            // 
            this.tb_bilaKSize.Location = new System.Drawing.Point(167, 79);
            this.tb_bilaKSize.Name = "tb_bilaKSize";
            this.tb_bilaKSize.Size = new System.Drawing.Size(50, 25);
            this.tb_bilaKSize.TabIndex = 9;
            this.tb_bilaKSize.Text = "3";
            this.tb_bilaKSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_bilaColor
            // 
            this.tb_bilaColor.Location = new System.Drawing.Point(277, 80);
            this.tb_bilaColor.Name = "tb_bilaColor";
            this.tb_bilaColor.Size = new System.Drawing.Size(50, 25);
            this.tb_bilaColor.TabIndex = 11;
            this.tb_bilaColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(279, 50);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(54, 19);
            this.label27.TabIndex = 10;
            this.label27.Text = "sigmaC";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(169, 50);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(48, 19);
            this.label30.TabIndex = 8;
            this.label30.Text = "滤波核";
            // 
            // tabPage_Gray2RGB
            // 
            this.tabPage_Gray2RGB.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_Gray2RGB.Controls.Add(this.cb_ColorMapTypes);
            this.tabPage_Gray2RGB.Location = new System.Drawing.Point(4, 28);
            this.tabPage_Gray2RGB.Name = "tabPage_Gray2RGB";
            this.tabPage_Gray2RGB.Size = new System.Drawing.Size(613, 166);
            this.tabPage_Gray2RGB.TabIndex = 31;
            this.tabPage_Gray2RGB.Text = "转伪彩色";
            // 
            // cb_ColorMapTypes
            // 
            this.cb_ColorMapTypes.BackColor = System.Drawing.Color.Transparent;
            this.cb_ColorMapTypes.BorderColor = System.Drawing.Color.Black;
            this.cb_ColorMapTypes.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.cb_ColorMapTypes.Items.AddRange(new object[] {
            "autumn",
            "bone",
            "jet",
            "winter",
            "rainbow",
            "ocean",
            "summer",
            "spring",
            "cool",
            "HSV",
            "pink",
            "hot",
            "parula",
            "magma",
            "inferno",
            "plasma",
            "viridis",
            "cividis",
            "twilight",
            "twilight-shifted",
            "turbo"});
            this.cb_ColorMapTypes.Location = new System.Drawing.Point(240, 50);
            this.cb_ColorMapTypes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_ColorMapTypes.Name = "cb_ColorMapTypes";
            this.cb_ColorMapTypes.SelectedColor = System.Drawing.Color.Black;
            this.cb_ColorMapTypes.SelectedIndex = -1;
            this.cb_ColorMapTypes.Size = new System.Drawing.Size(111, 26);
            this.cb_ColorMapTypes.TabIndex = 1;
            this.cb_ColorMapTypes.UseRadius = true;
            // 
            // tabPage_fitLine
            // 
            this.tabPage_fitLine.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_fitLine.Controls.Add(this.label10);
            this.tabPage_fitLine.Controls.Add(this.label11);
            this.tabPage_fitLine.Controls.Add(this.textBox_FitLinePos2);
            this.tabPage_fitLine.Controls.Add(this.textBox_FitLinePos1);
            this.tabPage_fitLine.Controls.Add(this.label9);
            this.tabPage_fitLine.Controls.Add(this.dataGridView_FitLine);
            this.tabPage_fitLine.Location = new System.Drawing.Point(4, 28);
            this.tabPage_fitLine.Name = "tabPage_fitLine";
            this.tabPage_fitLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_fitLine.Size = new System.Drawing.Size(613, 166);
            this.tabPage_fitLine.TabIndex = 13;
            this.tabPage_fitLine.Text = "直线拟合";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(372, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 16);
            this.label10.TabIndex = 45;
            this.label10.Text = "pos2";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(372, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 16);
            this.label11.TabIndex = 44;
            this.label11.Text = "pos1";
            // 
            // textBox_FitLinePos2
            // 
            this.textBox_FitLinePos2.Location = new System.Drawing.Point(418, 84);
            this.textBox_FitLinePos2.Name = "textBox_FitLinePos2";
            this.textBox_FitLinePos2.Size = new System.Drawing.Size(146, 25);
            this.textBox_FitLinePos2.TabIndex = 43;
            // 
            // textBox_FitLinePos1
            // 
            this.textBox_FitLinePos1.Location = new System.Drawing.Point(418, 44);
            this.textBox_FitLinePos1.Name = "textBox_FitLinePos1";
            this.textBox_FitLinePos1.Size = new System.Drawing.Size(146, 25);
            this.textBox_FitLinePos1.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(82, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(147, 14);
            this.label9.TabIndex = 41;
            this.label9.Text = "输入要拟合的点的坐标";
            // 
            // dataGridView_FitLine
            // 
            this.dataGridView_FitLine.AllowUserToResizeColumns = false;
            this.dataGridView_FitLine.AllowUserToResizeRows = false;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_FitLine.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle33;
            this.dataGridView_FitLine.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_FitLine.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_FitLine.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_FitLine.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle34.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_FitLine.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridView_FitLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_FitLine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle35.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle35.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle35.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle35.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle35.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle35.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_FitLine.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridView_FitLine.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_FitLine.Location = new System.Drawing.Point(30, 26);
            this.dataGridView_FitLine.Name = "dataGridView_FitLine";
            this.dataGridView_FitLine.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_FitLine.RowHeadersDefaultCellStyle = dataGridViewCellStyle36;
            this.dataGridView_FitLine.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_FitLine.RowTemplate.Height = 23;
            this.dataGridView_FitLine.Size = new System.Drawing.Size(300, 135);
            this.dataGridView_FitLine.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "X";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "Y";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // tabPage_LineCross
            // 
            this.tabPage_LineCross.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_LineCross.Controls.Add(this.label4);
            this.tabPage_LineCross.Controls.Add(this.dataGridView_CrossPos);
            this.tabPage_LineCross.Controls.Add(this.textBox_CrossPos);
            this.tabPage_LineCross.Controls.Add(this.label_CrossPos);
            this.tabPage_LineCross.Location = new System.Drawing.Point(4, 28);
            this.tabPage_LineCross.Name = "tabPage_LineCross";
            this.tabPage_LineCross.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_LineCross.Size = new System.Drawing.Size(613, 166);
            this.tabPage_LineCross.TabIndex = 7;
            this.tabPage_LineCross.Text = "两条直线交点";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(100, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 39;
            this.label4.Text = "输入坐标";
            // 
            // dataGridView_CrossPos
            // 
            this.dataGridView_CrossPos.AllowUserToResizeColumns = false;
            this.dataGridView_CrossPos.AllowUserToResizeRows = false;
            dataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView_CrossPos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle37;
            this.dataGridView_CrossPos.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dataGridView_CrossPos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView_CrossPos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_CrossPos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle38.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CrossPos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle38;
            this.dataGridView_CrossPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CrossPos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            dataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle39.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_CrossPos.DefaultCellStyle = dataGridViewCellStyle39;
            this.dataGridView_CrossPos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_CrossPos.Location = new System.Drawing.Point(20, 28);
            this.dataGridView_CrossPos.Name = "dataGridView_CrossPos";
            this.dataGridView_CrossPos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle40.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle40.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            dataGridViewCellStyle40.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle40.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle40.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle40.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_CrossPos.RowHeadersDefaultCellStyle = dataGridViewCellStyle40;
            this.dataGridView_CrossPos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dataGridView_CrossPos.RowTemplate.Height = 23;
            this.dataGridView_CrossPos.Size = new System.Drawing.Size(285, 135);
            this.dataGridView_CrossPos.TabIndex = 38;
            // 
            // X
            // 
            this.X.HeaderText = "X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Y";
            this.Y.Name = "Y";
            // 
            // textBox_CrossPos
            // 
            this.textBox_CrossPos.Location = new System.Drawing.Point(393, 84);
            this.textBox_CrossPos.Name = "textBox_CrossPos";
            this.textBox_CrossPos.Size = new System.Drawing.Size(141, 25);
            this.textBox_CrossPos.TabIndex = 36;
            this.textBox_CrossPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label_CrossPos
            // 
            this.label_CrossPos.AutoSize = true;
            this.label_CrossPos.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.label_CrossPos.Location = new System.Drawing.Point(432, 53);
            this.label_CrossPos.Name = "label_CrossPos";
            this.label_CrossPos.Size = new System.Drawing.Size(61, 19);
            this.label_CrossPos.TabIndex = 23;
            this.label_CrossPos.Text = "交点坐标";
            // 
            // tabPage_UserDef
            // 
            this.tabPage_UserDef.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tabPage_UserDef.Controls.Add(this.cb_UserDef);
            this.tabPage_UserDef.Controls.Add(this.tb_UserDef1);
            this.tabPage_UserDef.Location = new System.Drawing.Point(4, 28);
            this.tabPage_UserDef.Name = "tabPage_UserDef";
            this.tabPage_UserDef.Size = new System.Drawing.Size(613, 166);
            this.tabPage_UserDef.TabIndex = 18;
            this.tabPage_UserDef.Text = "自定义";
            // 
            // cb_UserDef
            // 
            this.cb_UserDef.FormattingEnabled = true;
            this.cb_UserDef.Items.AddRange(new object[] {
            "胡椒噪声",
            "盐粒噪声",
            "test"});
            this.cb_UserDef.Location = new System.Drawing.Point(20, 27);
            this.cb_UserDef.Name = "cb_UserDef";
            this.cb_UserDef.Size = new System.Drawing.Size(121, 27);
            this.cb_UserDef.TabIndex = 1;
            // 
            // tb_UserDef1
            // 
            this.tb_UserDef1.Location = new System.Drawing.Point(158, 27);
            this.tb_UserDef1.Name = "tb_UserDef1";
            this.tb_UserDef1.Size = new System.Drawing.Size(100, 25);
            this.tb_UserDef1.TabIndex = 0;
            this.tb_UserDef1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ps_Funcs
            // 
            this.ps_Funcs.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ps_Funcs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ps_Funcs.Location = new System.Drawing.Point(633, 3);
            this.ps_Funcs.Name = "ps_Funcs";
            this.tlPanel_Main.SetRowSpan(this.ps_Funcs, 2);
            this.ps_Funcs.Size = new System.Drawing.Size(287, 465);
            this.ps_Funcs.TabIndex = 42;
            this.ps_Funcs.PageSignal += new ImageTool.Controls.PageSwitch.PageSwitchEventHandler(this.ps_Funcs_PageSignal);
            // 
            // Image_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(923, 703);
            this.Controls.Add(this.tlPanel_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Image_Form";
            this.Text = "图像处理 v2.0.0 Beta";
            this.Load += new System.EventHandler(this.Image_Form_Load);
            this.SizeChanged += new System.EventHandler(this.Image_Form_SizeChanged);
            this.tlPanel_Main.ResumeLayout(false);
            this.tlPanel_Main.PerformLayout();
            this.panel_Display.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.contextMenuStrip_Image.ResumeLayout(false);
            this.panel_Control.ResumeLayout(false);
            this.panel_Control.PerformLayout();
            this.ss_Status.ResumeLayout(false);
            this.ss_Status.PerformLayout();
            this.panel_ToolBar.ResumeLayout(false);
            this.panel_ToolBar.PerformLayout();
            this.tc_Image.ResumeLayout(false);
            this.tabPage_ImageInfo.ResumeLayout(false);
            this.tabPage_ImageInfo.PerformLayout();
            this.tabPage_CutImage.ResumeLayout(false);
            this.tabPage_CutImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CutX)).EndInit();
            this.tabPage_Resize.ResumeLayout(false);
            this.tabPage_Resize.PerformLayout();
            this.tabPage_Rotate.ResumeLayout(false);
            this.tabPage_Rotate.PerformLayout();
            this.tabPage_Median.ResumeLayout(false);
            this.tabPage_Median.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Median)).EndInit();
            this.tabPage_Gaussian.ResumeLayout(false);
            this.tabPage_Gaussian.PerformLayout();
            this.tabPage_Gray.ResumeLayout(false);
            this.tabPage_Binary.ResumeLayout(false);
            this.gb_ExtendBox.ResumeLayout(false);
            this.gb_ExtendBox.PerformLayout();
            this.gb_BasicBox.ResumeLayout(false);
            this.gb_BasicBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BinarySel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_MaxPixelVal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_BinaryThres)).EndInit();
            this.tabPage_EdgeDetect.ResumeLayout(false);
            this.gb_CannyPara.ResumeLayout(false);
            this.gb_CannyPara.PerformLayout();
            this.gb_Sobel.ResumeLayout(false);
            this.gb_Sobel.PerformLayout();
            this.gb_Laplacian.ResumeLayout(false);
            this.gb_Laplacian.PerformLayout();
            this.tabPage_Dilate.ResumeLayout(false);
            this.tabPage_Dilate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DilateKerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_DilateKerX)).EndInit();
            this.tabPage_Erode.ResumeLayout(false);
            this.tabPage_Erode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErodeKerY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ErodeKerX)).EndInit();
            this.tabPage_FindContours.ResumeLayout(false);
            this.tabPage_FindContours.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_ConIdx)).EndInit();
            this.tabPage_Substract.ResumeLayout(false);
            this.tabPage_Substract.PerformLayout();
            this.panel_SubDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Substract)).EndInit();
            this.tabPage_AddImage.ResumeLayout(false);
            this.tabPage_AddImage.PerformLayout();
            this.panel_AddDisplay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_AddImage)).EndInit();
            this.tabPage_ConnectArea.ResumeLayout(false);
            this.tabPage_ConnectArea.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_AreaIdx)).EndInit();
            this.tabPage_HoughDetect.ResumeLayout(false);
            this.gb_HoughLineP.ResumeLayout(false);
            this.gb_HoughLineP.PerformLayout();
            this.tabPage_Perspective.ResumeLayout(false);
            this.tabPage_Perspective.PerformLayout();
            this.tabPage_Normalize.ResumeLayout(false);
            this.tabPage_Normalize.PerformLayout();
            this.tabPage_DrawCanvas.ResumeLayout(false);
            this.tabPage_DrawCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CanvasR)).EndInit();
            this.tabPage_DrawPts.ResumeLayout(false);
            this.tabPage_DrawPts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_PtsThick)).EndInit();
            this.tabPage_DrawLine.ResumeLayout(false);
            this.tabPage_DrawLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Line)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LineThick)).EndInit();
            this.tabPage_DrawRect.ResumeLayout(false);
            this.tabPage_DrawRect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Rect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_RectThick)).EndInit();
            this.tabPage_DrawCircle.ResumeLayout(false);
            this.tabPage_DrawCircle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Circle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_CircleThick)).EndInit();
            this.tabPage_Flip.ResumeLayout(false);
            this.tabPage_Flip.PerformLayout();
            this.tabPage_Thin.ResumeLayout(false);
            this.tabPage_HSV2Binary.ResumeLayout(false);
            this.tabPage_HSV2Binary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_HighH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_LowH)).EndInit();
            this.tabPage_Bilateral.ResumeLayout(false);
            this.tabPage_Bilateral.PerformLayout();
            this.tabPage_Gray2RGB.ResumeLayout(false);
            this.tabPage_fitLine.ResumeLayout(false);
            this.tabPage_fitLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_FitLine)).EndInit();
            this.tabPage_LineCross.ResumeLayout(false);
            this.tabPage_LineCross.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CrossPos)).EndInit();
            this.tabPage_UserDef.ResumeLayout(false);
            this.tabPage_UserDef.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlPanel_Main;
        private System.Windows.Forms.Panel panel_Display;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Panel panel_Control;
        private System.Windows.Forms.Label lbl_Size;
        private System.Windows.Forms.Label lbl_MouseHSV;
        private System.Windows.Forms.Label lbl_MouseRGB;
        private System.Windows.Forms.Label lbl_MousePos;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_Image;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_Save;
        private System.Windows.Forms.ToolStripMenuItem cmsItem_SaveAs;
        private System.Windows.Forms.StatusStrip ss_Status;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Path;
        private System.Windows.Forms.ToolStripStatusLabel tssl_RtLbl;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Runtime;
        private System.Windows.Forms.ToolTip toolTip_UseRemark;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Error;
        private System.Windows.Forms.ToolStripSplitButton tssb_AddRegister;
        private System.Windows.Forms.Panel panel_ToolBar;
        private System.Windows.Forms.Button btn_ToolPts;
        private System.Windows.Forms.Button btn_ToolRect;
        private System.Windows.Forms.Button btn_ToolPRect;
        private System.Windows.Forms.Button btn_ToolCircle;
        private System.Windows.Forms.Button btn_ToolLine;
        private System.Windows.Forms.TabControl tc_Image;
        private System.Windows.Forms.TabPage tabPage_ImageInfo;
        private System.Windows.Forms.Label lbl_CalibratePts;
        private System.Windows.Forms.Button btn_ToolGraphClear;
        private System.Windows.Forms.TextBox tb_CalibratePts;
        private System.Windows.Forms.Label lbl_BorWData;
        private System.Windows.Forms.Label lbl_PixelMean;
        private System.Windows.Forms.TabPage tabPage_CutImage;
        private System.Windows.Forms.Label label_CutRect;
        private System.Windows.Forms.Label label_StartXY;
        private System.Windows.Forms.NumericUpDown nud_CutH;
        private System.Windows.Forms.NumericUpDown nud_CutW;
        private System.Windows.Forms.NumericUpDown nud_CutY;
        private System.Windows.Forms.Label label_CutSize;
        private System.Windows.Forms.Label label_CutStartPos;
        private System.Windows.Forms.NumericUpDown nud_CutX;
        private System.Windows.Forms.TabPage tabPage_Resize;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox tb_ResizeH;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.TextBox tb_ResizeW;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox tb_ResizeHScale;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.TextBox tb_ResizeWScale;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.TabPage tabPage_Rotate;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.TextBox tb_RotateCenterY;
        private System.Windows.Forms.TextBox tb_RotateCenterX;
        private System.Windows.Forms.TextBox tb_RotateAngle;
        private System.Windows.Forms.Label label44;
        private System.Windows.Forms.TabPage tabPage_Median;
        private System.Windows.Forms.Label label_Kernel;
        private System.Windows.Forms.NumericUpDown nud_Median;
        private System.Windows.Forms.TabPage tabPage_Gaussian;
        private System.Windows.Forms.TextBox tb_gsKer;
        private System.Windows.Forms.TextBox tb_gsSigma;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TabPage tabPage_Gray;
        private System.Windows.Forms.TabPage tabPage_Binary;
        private System.Windows.Forms.GroupBox gb_ExtendBox;
        private System.Windows.Forms.TextBox tb_AdaptiveDelta;
        private System.Windows.Forms.Label lbl_Adaptive3;
        private System.Windows.Forms.TextBox tb_AdaptiveSize;
        private System.Windows.Forms.Label lbl_Adaptive2;
        private System.Windows.Forms.Label lbl_Adaptive1;
        private System.Windows.Forms.Label lbl_OTSU;
        private System.Windows.Forms.GroupBox gb_BasicBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown nud_BinarySel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown nud_MaxPixelVal;
        private System.Windows.Forms.NumericUpDown nud_BinaryThres;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage tabPage_EdgeDetect;
        private System.Windows.Forms.GroupBox gb_CannyPara;
        private System.Windows.Forms.TextBox tb_GSKsize;
        private System.Windows.Forms.TextBox tb_HighThres;
        private System.Windows.Forms.TextBox tb_LowThres;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gb_Sobel;
        private System.Windows.Forms.TextBox tb_SobelKsize;
        private System.Windows.Forms.TextBox tb_Sobeldy;
        private System.Windows.Forms.TextBox tb_Sobeldx;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox gb_Laplacian;
        private System.Windows.Forms.TextBox tb_LapKsize;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TabPage tabPage_Dilate;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.NumericUpDown nud_DilateKerY;
        private System.Windows.Forms.Label label_DilateKernel;
        private System.Windows.Forms.NumericUpDown nud_DilateKerX;
        private System.Windows.Forms.TabPage tabPage_Erode;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.NumericUpDown nud_ErodeKerY;
        private System.Windows.Forms.Label label_ErodeKernel;
        private System.Windows.Forms.NumericUpDown nud_ErodeKerX;
        private System.Windows.Forms.TabPage tabPage_FindContours;
        private System.Windows.Forms.Label lbl_ConPointNum;
        private System.Windows.Forms.Label lbl_ConArea;
        private System.Windows.Forms.Label lbl_ConNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_ConRect;
        private System.Windows.Forms.TextBox tb_ConCtr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nud_ConIdx;
        private System.Windows.Forms.TabPage tabPage_Substract;
        private System.Windows.Forms.Panel panel_SubDisplay;
        private System.Windows.Forms.PictureBox pb_Substract;
        private System.Windows.Forms.TextBox tb_SubScale;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TabPage tabPage_ConnectArea;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_Area;
        private System.Windows.Forms.TextBox tb_AreaCtr;
        private System.Windows.Forms.TextBox tb_AreaRect;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox tb_AreaMin;
        private System.Windows.Forms.TextBox tb_AreaMaxNum;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.NumericUpDown nud_AreaIdx;
        private System.Windows.Forms.TabPage tabPage_HoughDetect;
        private System.Windows.Forms.GroupBox gb_HoughLineP;
        private System.Windows.Forms.TextBox tb_LineMaxGap;
        private System.Windows.Forms.TextBox tb_LineMinLen;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox tb_LineRHO;
        private System.Windows.Forms.TextBox tb_LineThres;
        private System.Windows.Forms.TextBox tb_LineTheta;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TabPage tabPage_Perspective;
        private System.Windows.Forms.ComboBox cb_PersSize;
        private System.Windows.Forms.TextBox tb_PersHeight;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox tb_PersWidth;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox tb_PersDstPts;
        private System.Windows.Forms.TextBox tb_PersSrcPts;
        private System.Windows.Forms.TabPage tabPage_Equalize;
        private System.Windows.Forms.TabPage tabPage_Normalize;
        private System.Windows.Forms.TextBox tb_NormHigh;
        private System.Windows.Forms.TextBox tb_NormLow;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TabPage tabPage_DrawLine;
        private System.Windows.Forms.Panel pnl_LineColor;
        private System.Windows.Forms.DataGridView Grid_Line;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Label label_LineThickness;
        private System.Windows.Forms.Label label_LineColor;
        private System.Windows.Forms.NumericUpDown nud_LineB;
        private System.Windows.Forms.NumericUpDown nud_LineG;
        private System.Windows.Forms.NumericUpDown nud_LineR;
        private System.Windows.Forms.NumericUpDown nud_LineThick;
        private System.Windows.Forms.Label label_LinePos;
        private System.Windows.Forms.TabPage tabPage_DrawRect;
        private System.Windows.Forms.Panel pnl_RectColor;
        private System.Windows.Forms.DataGridView Grid_Rect;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Label label_RectThickness;
        private System.Windows.Forms.Label label_RectColor;
        private System.Windows.Forms.NumericUpDown nud_RectB;
        private System.Windows.Forms.NumericUpDown nud_RectG;
        private System.Windows.Forms.NumericUpDown nud_RectR;
        private System.Windows.Forms.NumericUpDown nud_RectThick;
        private System.Windows.Forms.Label label_RectPos;
        private System.Windows.Forms.TabPage tabPage_DrawCircle;
        private System.Windows.Forms.Panel pnl_CircleColor;
        private System.Windows.Forms.DataGridView Grid_Circle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn R;
        private System.Windows.Forms.Label label_CircleThickness;
        private System.Windows.Forms.Label label_CircleColor;
        private System.Windows.Forms.NumericUpDown nud_CircleB;
        private System.Windows.Forms.NumericUpDown nud_CircleG;
        private System.Windows.Forms.NumericUpDown nud_CircleR;
        private System.Windows.Forms.NumericUpDown nud_CircleThick;
        private System.Windows.Forms.Label label_CirclePos;
        private System.Windows.Forms.TabPage tabPage_Flip;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox tb_FlipDirect;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TabPage tabPage_HSV2Binary;
        private System.Windows.Forms.NumericUpDown nud_HighV;
        private System.Windows.Forms.Label label_Value;
        private System.Windows.Forms.NumericUpDown nud_LowV;
        private System.Windows.Forms.NumericUpDown nud_HighS;
        private System.Windows.Forms.Label label_Saturability;
        private System.Windows.Forms.NumericUpDown nud_LowS;
        private System.Windows.Forms.NumericUpDown nud_HighH;
        private System.Windows.Forms.Label label_Hue;
        private System.Windows.Forms.NumericUpDown nud_LowH;
        private System.Windows.Forms.TabPage tabPage_Bilateral;
        private System.Windows.Forms.TextBox tb_bilaSpace;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.TextBox tb_bilaKSize;
        private System.Windows.Forms.TextBox tb_bilaColor;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.TabPage tabPage_fitLine;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_FitLinePos2;
        private System.Windows.Forms.TextBox textBox_FitLinePos1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView_FitLine;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.TabPage tabPage_LineCross;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView_CrossPos;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.TextBox textBox_CrossPos;
        private System.Windows.Forms.Label label_CrossPos;
        private System.Windows.Forms.TabPage tabPage_UserDef;
        private System.Windows.Forms.ComboBox cb_UserDef;
        private System.Windows.Forms.TextBox tb_UserDef1;
        private System.Windows.Forms.Button btn_ToolCut;
        private System.Windows.Forms.TabPage tabPage_Gray2RGB;
        private System.Windows.Forms.TabPage tabPage_Thin;
        private Controls.PageSwitch ps_Funcs;
        private Weights.SButton btn_Load;
        private Weights.SButton btn_BackOnce;
        private Weights.SButton btn_Start;
        private Weights.SCheckBox cbx_AsmLine;
        private Weights.SButton btn_ImageHandleForm;
        private Controls.UComboBox cb_GrayChannel;
        private Controls.UComboBox cb_BackUp;
        private System.Windows.Forms.ToolStripStatusLabel tssl_Func;
        private Controls.UComboBox cb_ThresType;
        private Controls.UComboBox cb_Adaptive;
        private Controls.UComboBox cb_EdgeDetect;
        private Controls.UComboBox cb_HoughDetect;
        private Controls.UComboBox cb_ThinTypes;
        private Controls.UComboBox cb_ColorMapTypes;
        private Weights.STrackBar tkb_RotateAngle;
        private Weights.SButton btn_ExportHSV;
        private Weights.SCheckBox cbx_UseAbs;
        private Weights.SButton btn_SubImage;
        private Weights.SCheckBox ckb_Resize;
        private System.Windows.Forms.TabPage tabPage_DrawPts;
        private System.Windows.Forms.Panel pnl_PtsColor;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.NumericUpDown nud_PtsB;
        private System.Windows.Forms.NumericUpDown nud_PtsG;
        private System.Windows.Forms.NumericUpDown nud_PtsR;
        private System.Windows.Forms.NumericUpDown nud_PtsThick;
        private System.Windows.Forms.TextBox tb_PtsSet;
        private System.Windows.Forms.Label label53;
        private Weights.SButton btn_PersDstPts;
        private Weights.SButton btn_PersSrcPts;
        private Weights.SCheckBox cbx_ConMinPRect;
        private Weights.SCheckBox cbx_ConMinRect;
        private Weights.SCheckBox cbx_IsPRect;
        private System.Windows.Forms.TabPage tabPage_AddImage;
        private System.Windows.Forms.Panel panel_AddDisplay;
        private System.Windows.Forms.PictureBox pb_AddImage;
        private System.Windows.Forms.Label label1;
        private Weights.SButton btn_AddImage;
        private System.Windows.Forms.TabPage tabPage_DrawCanvas;
        private System.Windows.Forms.Panel pnl_CanvasColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nud_CanvasB;
        private System.Windows.Forms.NumericUpDown nud_CanvasG;
        private System.Windows.Forms.NumericUpDown nud_CanvasR;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.TextBox tb_CanvasC;
        private System.Windows.Forms.TextBox tb_CanvasH;
        private System.Windows.Forms.TextBox tb_CanvasW;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.Label label43;
    }
}

