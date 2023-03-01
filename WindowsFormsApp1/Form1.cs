using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Runtime.ExceptionServices;
using System.IO;
using Microsoft.Win32;

using ImageTool.Weights;

namespace ImageTool
{
    public partial class Image_Form : Form
    {

        #region 函数声明
        // ---------------- 函数导入 -----------------------
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void readImage(string file, int mode, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void writeImage(string file, ref byte srcImage, int srcWidth, int srcHeight, int srcChannel);
        //start

        #region 图像功能块
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cutImage(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] pos, int[] size);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int resize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int newWidth, int newHeight, float scaleX, float scaleY, int interpolation);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int rotate(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float clockwiseAngle, float[] center);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int flip(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int XY);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int HSV2Binary(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int region, float lowH, float highH, float lowS, float highS, float lowV, float highV);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void thresholdBinary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, float maxval, int region);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int thresholdBinaryOTSU(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float maxval, int region, float[] thresh);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int thresholdBinaryAdaptive(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float maxval, int region, int type, int ksize, int delta);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void stripBackground(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte bkImage, int bkWidth, int bkHeight, int bkChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float contraThresh, int mode);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int medianBlur(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m, int n);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int gaussianBlur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m, int n, float sigmaX, float sigmaY);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int addImage(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte subImage, int subWidth, int subHeight, int subChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int substract(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte subImage, int subWidth, int subHeight, int subChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int scale, bool use_abs);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int bilateralFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int ksize, float sigma_color, float sigma_space);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int dilate(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelX, int kernelY);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int erode(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelX, int kernelY);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int normalize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int low, int high);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int equalize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int RGB2Gray(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cvtColorCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorCode);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int GrayFromRGB(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorChn);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int connectedComponent(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int index, int conNums, int minConArea, int[] area, int[] center, int[] rect);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int thinImage(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int region);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int findAllContoursCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int selectSize, bool isRotated, float[] centerPoint, float[] rectPoint, int[] conArea, int[] conPointNum, int[] conNum);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawLineCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] LinePoint);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawRectCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] RectPoint, bool isPRect);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawCircleCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] CirclePoint, int radius);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int matchTemplateCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte templateImage, int templateWidth, int templateLength, int templateChannel, float[] rect, float[] similarity);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int matchShapesCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte tImage, int tWidth, int tLength, int tChannel, float[] similarity);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int Gray2Pseudo(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorMapTypes);
        #endregion

        #region 图形功能块
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int lineCross(float[] LinePoint1, float[] LinePoint2, float[] Point2D);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int IMG_CvFitLine(float[] pts, float[] line);
        #endregion

        #region 边缘检测

        // 自定义
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int roberts(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int sobel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int dx, int dy, int ksize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int prewitt(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int laplacian(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int ksize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int kirsch(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int nevitia(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int scharr(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int canny(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int gaussianSize, int low_threshold, int high_threshold);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cannyFromSobel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte srcImage2, int srcWidth2, int srcHeight2, int srcChannel2, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int low_threshold, int high_threshold);

        // opencv
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int sobelCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int dx, int dy, int ksize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int sobelXYCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int dx, int dy, int ksize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int laplacianCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int ksize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cannyCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int gaussianSize, int low_threshold, int high_threshold);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int houghLinesPCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] lines, float rho, float theta, int threshold, float minLineLen, float maxLineGap);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawHoughLinesCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] lines);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int warpPerspectiveCV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float[] srcPt, float[] dstPt, int[] size);

        #endregion

        #region 图像信息函数
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int meanPixel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] meanPixel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int RGB2HSV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] H, float[] S, float[] V);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int saveRGBinHSV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float lowH, float highH, float lowS, float highS, float lowV, float highV);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int RGB2Binary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, float maxval, int region);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int brightnessAndContrast(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float alpha, float beta);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int channelCommingler(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorChn, float red, float green, float blue, float constant);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int RGB2GrayDefined(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float red, float green, float blue, float constant);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int complementaryPixel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int adjustHSL(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int changeH, int changeS, int changeL);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int getHistogram(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] outHistogram);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int getDirectPixNum(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, bool isX, int pixel);

        #endregion

        // 自定义功能块
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int saltNoise(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int num);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int pepperNoise(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int num);


        #endregion


        #region 全局变量

        public string savePath = "";
        public string sourcePath;
        string imgName = "";

        Regex isNumber = new Regex("^[-]?[\\d]+$");//^[0-9]*$
        Regex isFloatNumber = new Regex("^[-]?[\\d]+\\.[\\d]+$");//^[0-9]*$
        Regex isPositiveNumber = new Regex("^[\\d]+$");
        bool isChangedW = false, isChangedH = false;

        // 功能块相关

        private int ImageFuncNum = 29;
        // 控件初始化信息
        private Size funcBtnSize = new Size(226, 30);
        private int[] posInfo = new int[3] {16, 4, 36};
        // 流水线执行列表
        private List<TabPage> asmLineTabs = new List<TabPage>();
        // 流水线按钮交互
        private bool catchAsmLBtn = false;
        private bool delAsmLBtn = false;
        private bool moveAsmLBtn = false;
        private int AsmLBtnMoveDis = 0;
        private int AsmLBtnMoveNum = 0;
        private Point AsmLBtnMoveStart;

        // 显示相关
        ImageStorage curImage = new ImageStorage();
        ImageStorage perCurImage = new ImageStorage();

        TabPage curTab;
        List<TabPage> stepTab = new List<TabPage>();

        Dictionary<Button, TabPage> FuncBindings = new Dictionary<Button, TabPage> { };

        // 工具实例化
        private ImageInfoHandle ImageForm = new ImageInfoHandle();
        private Stopwatch Timepiece = new Stopwatch();
        private Error error = new Error(5000);

        // 图像数据变量
        Dictionary<int, ImageData> inputImage = new Dictionary<int, ImageData> { };
        Dictionary<int, ImageData> outputImage = new Dictionary<int, ImageData> {
            {0, new ImageData()}
        };

        // 图像缩放和移动
        private Point dragStart;
        private bool dragFlag = false;

        private float smallStep = 0.002f;
        private float imageScale = 1;
        private float minScale = 1f;
        private float maxScale = 5f;
        private Size displaySize;
        private Size imageInitSize;
        private Point imageInitLoc;
        private Rectangle imageLocRange;

        // 绘制事件相关
        Image oriImg;
        ImageLine line = new ImageLine(Color.Red, 1.5f);
        private Point lineStartPoint;
        private Point lineEndPoint;

        private int graphNum = 0;
        private bool startDrawFlag = false;
        private bool startPtsFlag = false;
        private bool startLineFlag = false;
        private bool startCutFlag = false;
        private bool startCircleFlag = false;
        private bool startPRectFlag = false;
        private int startRectFlag = -1;
        private Point[] rectPoints = new Point[4];

        #endregion


        public Image_Form()
        {
            InitializeComponent();

            savePath = FuncDef.GetFolderPath();

            InitBTN();

            InitTP();

            InitError();

            EventBinding();
        }

        private void InitError()
        {
            error.PrintCtrl = tssl_Error;
            error.Init();
        }

        // 初始化功能块
        private void InitTP()
        {
            stepTab.Add(tabPage_ImageInfo);
            curTab = tabPage_ImageInfo;

            int cnt = tc_Image.TabCount - 1;
            for (int i = cnt; i > 0; i--) {
                tc_Image.TabPages[i].Parent = null;
            }

            cb_GrayChannel.SelectedIndex = 0;
            cb_EdgeDetect.SelectedIndex = 0;
            cb_HoughDetect.SelectedIndex = 0;
            cb_ThresType.SelectedIndex = 0;
            cb_Adaptive.SelectedIndex = 0;
            cb_ColorMapTypes.SelectedIndex = 0;
            cb_ThinTypes.SelectedIndex = 1;

            // DataGrid 初始化
            if (Grid_Line.RowCount < 2) {
                Grid_Line.Rows.Clear();
                Grid_Line.Rows.Add(0, 0);
                Grid_Line.Rows[0].HeaderCell.Value = (1).ToString();
                Grid_Line.Rows.Add(0, 0);
                Grid_Line.Rows[1].HeaderCell.Value = (2).ToString();
            }
            if (Grid_Rect.RowCount < 4) {
                Grid_Rect.Rows.Clear();
                Grid_Rect.Rows.Add(0, 0);
                Grid_Rect.Rows[0].HeaderCell.Value = (1).ToString();
                Grid_Rect.Rows.Add(0, 0);
                Grid_Rect.Rows[1].HeaderCell.Value = (2).ToString();
                Grid_Rect.Rows.Add(0, 0);
                Grid_Rect.Rows[2].HeaderCell.Value = (3).ToString();
                Grid_Rect.Rows.Add(0, 0);
                Grid_Rect.Rows[3].HeaderCell.Value = (4).ToString();
            }
            if (Grid_Circle.RowCount < 1) {
                Grid_Circle.Rows.Clear();
                Grid_Circle.Rows.Add(100, 100, 88);
                Grid_Circle.Rows[0].HeaderCell.Value = "1";
            }
            if (dataGridView_CrossPos.RowCount < 4) {
                this.dataGridView_CrossPos.Rows.Clear();
                dataGridView_CrossPos.Rows.Add(0, 0);
                dataGridView_CrossPos.Rows[0].HeaderCell.Value = (1).ToString();
                dataGridView_CrossPos.Rows.Add(0, 0);
                dataGridView_CrossPos.Rows[1].HeaderCell.Value = (2).ToString();
                dataGridView_CrossPos.Rows.Add(0, 0);
                dataGridView_CrossPos.Rows[2].HeaderCell.Value = (3).ToString();
                dataGridView_CrossPos.Rows.Add(0, 0);
                dataGridView_CrossPos.Rows[3].HeaderCell.Value = (4).ToString();
            }
            if (dataGridView_FitLine.RowCount == 0) {
                dataGridView_FitLine.Rows.Clear();
                dataGridView_FitLine.Rows.Add(0, 0);
                dataGridView_FitLine.Rows[0].HeaderCell.Value = (1).ToString();
            }
        }
        
        // 绑定自定义事件
        private void EventBinding()
        {
            // 图像变量
            curImage.OnValueChanged += CurImageChanged;

            // 图片缩放
            picBox.MouseWheel += new MouseEventHandler(pictureBox_MouseWheel);

            // 表格粘贴
            Grid_Line.KeyDown += new KeyEventHandler(Table_KeyDown);
            Grid_Rect.KeyDown += new KeyEventHandler(Table_KeyDown);
            Grid_Circle.KeyDown += new KeyEventHandler(Table_KeyDown);
            dataGridView_CrossPos.KeyDown += new KeyEventHandler(Table_KeyDown);
            dataGridView_FitLine.KeyDown += new KeyEventHandler(Table_KeyDown);

            // 图像信息界面
            ImageForm.correctBrightAndContrast += correctBrightAndContrast;
            ImageForm.correctHSL += correctHSL;
            ImageForm.correctThreshold += correctThreshold;
            ImageForm.correctContrastImage += correctContrastImage;
            ImageForm.GetDirectPixNum += GetDirectPixNum;
            ImageForm.correctChannelCommingler += correctChannelCommingler;
            ImageForm.correctHSV += correctHSV;
            ImageForm.SetHSV_Click += SetHSV_Click;

            ImageForm.saveToInput += saveToInput;
            ImageForm.backToPrimary += backToPrimary;
        }


        #region 功能块初始化

        private void InitBTN()
        {
            int cnt = tc_Image.TabCount;

            for (int i = 1; i < cnt; i++) {
                TabPage tp = tc_Image.TabPages[i];
                SButton createBtn = new SButton();
                createBtn.Size = funcBtnSize;
                createBtn.Name = tp.Name.Replace("tabPage", "btn");
                createBtn.Text = tp.Text;
                createBtn.Click += new EventHandler(FuncBtn_Click);
                ps_Funcs.AddIGButton(createBtn, posInfo, i / ImageFuncNum);

                FuncBindings[createBtn] = tp;
            }
        }

        private void FuncBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            TabPageDisplay(FuncBindings[btn]);

            if (cbx_AsmLine.Checked) {
                SButton createBtn = new SButton();
                createBtn.Size = btn.Size;
                createBtn.Text = btn.Text;
                MouseEventHandler[] events = new MouseEventHandler[] {
                    AsmLineBtnDown,
                    AsmLineBtnMove,
                    AsmLineBtnUp
                };
                ps_Funcs.AddAsmLineButton(createBtn, posInfo, events);

                FuncBindings[createBtn] = FuncBindings[btn];
                asmLineTabs.Add(FuncBindings[btn]);
            }
        }

        private void AsmLineBtnDown(object sender, MouseEventArgs e)
        {
            catchAsmLBtn = true;
            AsmLBtnMoveStart = e.Location;
        }
        private void AsmLineBtnMove(object sender, MouseEventArgs e)
        {
            if (catchAsmLBtn) {
                SButton btn = (SButton)sender;
                int idx = asmLineTabs.IndexOf(FuncBindings[btn]);

                AsmLBtnMoveNum = (e.Y - AsmLBtnMoveStart.Y) / posInfo[2];
                AsmLBtnMoveDis = AsmLBtnMoveNum * posInfo[2];

                if (Math.Abs(e.Location.X - AsmLBtnMoveStart.X) > funcBtnSize.Width) {
                    delAsmLBtn = true;
                    Cursor = Cursors.No;
                }
                else if (AsmLBtnMoveNum != 0 && idx + AsmLBtnMoveNum >= 0 && idx + AsmLBtnMoveNum < asmLineTabs.Count) {
                    ps_Funcs.ShowMoveDotLine(idx + AsmLBtnMoveNum, posInfo);

                    moveAsmLBtn = true;
                    delAsmLBtn = false;
                    Cursor = Cursors.AppStarting;
                }
                else {
                    ps_Funcs.ClearAsmL();
                    moveAsmLBtn = false;
                    delAsmLBtn = false;
                    Cursor = Cursors.Default;
                }

                btn.SetOpacity((int)(255 * 0.3));
            }
        }
        private void AsmLineBtnUp(object sender, MouseEventArgs e)
        {
            SButton btn = (SButton)sender;
            int idx = asmLineTabs.IndexOf(FuncBindings[btn]);
            if (delAsmLBtn) {
                // 删除
                ps_Funcs.DelAsmLineButton(idx, posInfo);
                asmLineTabs.Remove(FuncBindings[btn]);

                delAsmLBtn = false;
            }
            else if (catchAsmLBtn && moveAsmLBtn) {
                // 数据移动
                ValueHelper.MoveList(ref asmLineTabs, idx, idx + AsmLBtnMoveNum);
                // 控件移动 / 删除
                ps_Funcs.MoveAsmLineButton(idx, idx + AsmLBtnMoveNum, posInfo);
                ps_Funcs.ClearAsmL();

                TabPageDisplay(FuncBindings[btn]);
            }

            Cursor = Cursors.Default;
            AsmLBtnMoveNum = 0;
            catchAsmLBtn = false;
        }

        private void AsmLineBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)((Button)sender).Parent;
            TabPageDisplay(FuncBindings[btn]);
        }
        private void AsmLineUp_Click(object sender, EventArgs e)
        {
            MoveButton mbtn = (MoveButton)((Button)sender).Parent;
            Control.ControlCollection set = ps_Funcs.panel_AsmLine.Controls;
            int idx = set.GetChildIndex(mbtn);

            if (idx > 0) {
                set.SetChildIndex(mbtn, idx - 1);
                ValueHelper.SwapList(ref asmLineTabs, idx, idx - 1);

                ControlHelper.SwapLocation(set[idx], mbtn);
            }
        }
        private void AsmLineDown_Click(object sender, EventArgs e)
        {
            MoveButton mbtn = (MoveButton)((Button)sender).Parent;
            Control.ControlCollection set = ps_Funcs.panel_AsmLine.Controls;
            int idx = set.GetChildIndex(mbtn);

            if (idx < asmLineTabs.Count - 1) {
                set.SetChildIndex(mbtn, idx + 1);
                ValueHelper.SwapList(ref asmLineTabs, idx, idx + 1);

                ControlHelper.SwapLocation(set[idx], mbtn);
            }
        }
        private void AsmLineDel_Click(object sender, EventArgs e)
        {
            MoveButton mbtn = (MoveButton)((Button)sender).Parent;
            Control.ControlCollection set = ps_Funcs.panel_AsmLine.Controls;
            int idx = set.GetChildIndex(mbtn);

            set.Remove(mbtn);
            mbtn.Dispose();
            asmLineTabs.Remove(FuncBindings[mbtn]);
            // 根据asmLineTabs重排
            if (asmLineTabs.Count > 0) ControlHelper.SupplementLocation(set, idx);
        }

        #endregion

        
        #region 数据处理

        private void EmptyInputImage()
        {
            inputImage.Clear();
        }

        private void UpdateInputImage(int index, ImageData data)
        {
            inputImage[index] = data;
        }

        private void UpdateInputImage(int index, byte[] s, int[] a, int[] b, int[] c)
        {
            inputImage[index] = new ImageData(s, a, b, c);
        }

        private void UpdateOutputImage(int index, ImageData data)
        {
            outputImage[index] = data;
        }

        private void UpdateOutputImage(int index, byte[] s, int[] a, int[] b, int[] c)
        {
            if (a[0] != 0 && b[0] != 0 && c[0] != 0) {
                outputImage[index] = new ImageData(s, a, b, c);
            }
        }

        private void UpdateCurImage(int IO, int index)
        {
            perCurImage = curImage;
            curImage.IO = IO;
            curImage.index = index;
            curImage.img = IO == 0 ? inputImage[index] : outputImage[index];
            DisplayFromMemory(picBox, curImage.img);

            // 更新交互信息
            lbl_Size.Text = "宽高通道:\n" + curImage.img.Width + ", " + curImage.img.Height + ", " + curImage.img.Channel;

            int[] pixel = new int[3];
            meanPixel(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, pixel);
            lbl_PixelMean.Text = "像素均值: R : " + pixel[2] + " G : " + pixel[1] + " B : " + pixel[0];

            int[] hist = new int[256];
            if (getHistogram(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, hist) == 1) {
                lbl_BorWData.Visible = true;
                double black = 100.0 * hist[0] / (hist[0] + hist[255]);
                double white = 100.0 * hist[255] / (hist[0] + hist[255]);

                lbl_BorWData.Text = "二值图 - 黑 : " 
                    + hist[0] + " - " + String.Format("{0:f1}", black) + "%"
                    + " 白 : " + hist[255] + " - " + String.Format("{0:f1}", white) + "%";
            }
            else
                lbl_BorWData.Visible = false;
        }

        private void SavePicImageInMemory(PictureBox pic, string path, Dictionary<int, ImageData> image, int index)
        {
            int[] a = new int[1]; int[] b = new int[1]; int[] c = new int[1];
            int readMode = 1;
            if (Image.GetPixelFormatSize(pic.Image.PixelFormat) == 8)
                readMode = 0;
            else
                readMode = 1;
            byte[] s = new byte[pic.Image.Width * pic.Image.Height * (readMode == 0 ? 1 : 3)];

            try {
                Timepiece.Restart();
                readImage(path, readMode, ref s[0], a, b, c);
                Timepiece.Stop();
                tssl_Runtime.Text = String.Format("{0:f3}ms", Timepiece.ElapsedTicks * 1000 / (double)Stopwatch.Frequency);
            }
            catch {
                error.Print(ErrorInfo.DLL_LOAD_FAILED);
            }

            image[index] = new ImageData();
            image[index].WriteInMemory(s, a, b, c);
        }

        #endregion


        #region 图像显示处理

        private void loadImage(string fileName)
        {
            // 获取路径信息
            sourcePath = fileName;
            imgName = sourcePath.Remove(0, sourcePath.LastIndexOf("\\") + 1);
            imgName = imgName.Remove(imgName.LastIndexOf("."));

            // 先存到picBox里，要获取数据
            DisplayFromFile(picBox, fileName);

            // 再存到内存里
            if (inputImage.Count > 0) inputImage.Remove(1);
            SavePicImageInMemory(picBox, fileName, inputImage, 1);
            outputImage[0] = inputImage[1];

            // 显示更新
            UpdateCurImage(0, 1);
            CalImageInfo(picBox.Image);
            AdaptImage();

            // 更新一些交互控件
            if (cb_BackUp.Items.Contains("原图")) {
                cb_BackUp.Items.Clear();
            }
            cb_BackUp.Items.Add("原图");
            cb_BackUp.SelectedIndex = 0;

            tssl_Path.Text = "当前图片路径: " + sourcePath;
        }
        private void loadCanvas()
        {
            //try {
            //    int[] color = getCanvasColor(false);
            //    int w = int.Parse(tb_CanvasW.Text);
            //    int h = int.Parse(tb_CanvasH.Text);
            //    int c = int.Parse(tb_CanvasC.Text);
            //    UpdateInputImage(1, new ImageData(w, h, c, color[0], color[1], color[2]));

            //    // 更新一些交互控件
            //    if (cb_BackUp.Items.Contains("原图"))
            //    {
            //        cb_BackUp.Items.Clear();
            //    }
            //    cb_BackUp.Items.Add("原图");
            //    cb_BackUp.SelectedIndex = 0;
            //}
            //catch (Exception e) {
            //    error.Print(ErrorInfo.CANVAS_DATA_ERROR);
            //}
        }

        private void DisplayFromFile(PictureBox pic, string path)
        {
            try {
                FileStream pFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
                pic.Image = Image.FromStream(pFileStream);
                pFileStream.Close();
                pFileStream.Dispose();
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_OPEN_FAILED);
            }
        }
        private void DisplayFromMemory(PictureBox pic, ImageData data)
        {
            Bitmap bmp = ValueHelper.ToBitmap(data.Data, data.Width, data.Height, data.Channel);
            pic.Image = bmp;
            CalImageInfo(pic.Image);
            AdaptImage();
        }

        private void TabPageDisplay(TabPage tab)
        {
            if (curTab != null && curTab != tabPage_ImageInfo)
                curTab.Parent = null;
            curTab = tab;
            curTab.Parent = tc_Image;
            tc_Image.SelectedTab = curTab;

            tssl_Func.Text = tab.Text;
        }

        private TabPage TabPageJudge(int index)
        {
            return stepTab.IndexOf(curTab) > index ? stepTab[index + 1] : stepTab[index];
        }

        #endregion


        #region 操作部分的控件事件

        // 加载图片
        private void LoadImage_Click(object sender, EventArgs e)
        {
                string file = FuncDef.OpenFile();
                if (file == "")
                    error.Print(ErrorInfo.IMAGE_PATH_ERROR);
                else
                    loadImage(file);
            if (curTab != tabPage_DrawCanvas)
            {
            }
            else
                loadCanvas();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try {
                if (asmLineTabs.Count > 0 && cbx_AsmLine.Checked) {
                    for (int i = 0; i < asmLineTabs.Count; i++) {
                        TabPageDisplay(asmLineTabs[i]);
                        ImageHandle();
                    }
                }
                else {
                    ImageHandle();
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, curTab.Text);
            }
        }

        private void ImageHandle()
        {
            // 清除内存中多余的输出存储，更新输入
            UpdateImageInput();

            int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
            byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

            // 图形处理
            if (curTab == tabPage_LineCross) {
                float[] posF = new float[4];//lineCross
                float[] posS = new float[4];

                for (int i = 0; i < 4; i++) {
                    posF[i] = float.Parse(dataGridView_CrossPos.Rows[i / 2].Cells[i % 2].Value.ToString());
                }
                for (int i = 0; i < 4; i++) {
                    posS[i] = float.Parse(dataGridView_CrossPos.Rows[i / 2 + 2].Cells[i % 2].Value.ToString());
                }
                float[] Point2D = new float[2];

                lineCross(posF, posS, Point2D);
                textBox_CrossPos.Text = Point2D[0].ToString() + ", " + Point2D[1].ToString();
            }
            else if (curTab == tabPage_fitLine) {
                float[] pos = new float[dataGridView_FitLine.RowCount * 2 + 2]; //fitLine
                int rowCnt = 2;
                for (int i = 0; i < dataGridView_FitLine.RowCount * 2; i++) {
                    if (dataGridView_FitLine.Rows[i / 2].Cells[i % 2].Value != null)
                        pos[rowCnt++] = float.Parse(dataGridView_FitLine.Rows[i / 2].Cells[i % 2].Value.ToString());
                }
                pos[1] = (rowCnt - 2) / 2;
                float[] slop = new float[4];

                IMG_CvFitLine(pos, slop);

                float k = slop[1] / slop[0];
                float b = slop[3] - k * slop[2];
                textBox_FitLinePos1.Text = slop[0].ToString() + "," + slop[1].ToString();
                textBox_FitLinePos2.Text = slop[2].ToString() + "," + slop[3].ToString();
            }

            // 图像处理
            else if (curTab == tabPage_CutImage) {
                int[] Pos = new int[] { (int)nud_CutX.Value, (int)nud_CutY.Value };
                int[] Size = new int[] { (int)nud_CutW.Value, (int)nud_CutH.Value };

                cutImage(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Pos, Size);
            }
            else if (curTab == tabPage_HSV2Binary) {
                float LowH = (float)nud_LowH.Value;
                float HighH = (float)nud_HighH.Value;
                float LowS = (float)nud_LowS.Value;
                float HighS = (float)nud_HighS.Value;
                float LowV = (float)nud_LowV.Value;
                float HighV = (float)nud_HighV.Value;

                saveRGBinHSV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, LowH, HighH, LowS, HighS, LowV, HighV);
                //HSV2Binary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Region, LowH, HighH, LowS, HighS, LowV, HighV);
            }
            else if (curTab == tabPage_Median) {
                int M = (int)nud_Median.Value;
                int N = (int)nud_Median.Value;

                medianBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, M, N);
            }
            else if (curTab == tabPage_Gaussian) {
                int M = int.Parse(tb_gsKer.Text);
                int N = int.Parse(tb_gsKer.Text);
                float sigmaX = float.Parse(tb_gsSigma.Text);
                float sigmaY = float.Parse(tb_gsSigma.Text);

                gaussianBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, M, N, sigmaX, sigmaY);
            }
            else if (curTab == tabPage_Bilateral) {
                int ksize = int.Parse(tb_bilaKSize.Text);
                float color = float.Parse(tb_bilaColor.Text);
                float space = float.Parse(tb_bilaSpace.Text);

                bilateralFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, ksize, color, space);
            }
            else if (curTab == tabPage_FindContours) {
                int Size = int.Parse(nud_ConIdx.Value.ToString());
                float[] Center = new float[2];
                float[] Rect = new float[8];
                int[] conArea = new int[1];
                int[] conNum = new int[1];
                int[] conPointNum = new int[1];

                findAllContoursCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Size, cbx_ConMinRect.Checked, Center, Rect, conArea, conPointNum, conNum);

                tb_ConCtr.Text = string.Join(",", Array.ConvertAll(Center, x => (int)x));
                tb_ConRect.Text = string.Join(",", Array.ConvertAll(Rect, x => (int)x));
                lbl_ConNum.Text = "轮廓总数：" + conNum[0].ToString();
                lbl_ConArea.Text = "轮廓面积：" + conArea[0].ToString();
                lbl_ConPointNum.Text = "轮廓点集数：" + conPointNum[0].ToString();
            }
            else if (curTab == tabPage_Substract) {
                int scale = int.Parse(tb_SubScale.Text);
                bool use_abs = cbx_UseAbs.Checked;

                substract(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, ref s1[0], a1, b1, c1, scale, use_abs);
            }
            else if (curTab == tabPage_AddImage)
            {
                addImage(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, ref s1[0], a1, b1, c1);
            }
            else if (curTab == tabPage_Gray) {
                int method = cb_GrayChannel.SelectedIndex;

                if (method == 0)
                    RGB2Gray(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1);
                else
                    GrayFromRGB(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, method - 1);
            }
            else if (curTab == tabPage_Binary) {
                float Threshold = float.Parse(nud_BinaryThres.Value.ToString());
                float MaxVal = float.Parse(nud_MaxPixelVal.Value.ToString());
                int Region = int.Parse(nud_BinarySel.Value.ToString());
                float[] otsuThres = new float[1];
                int ksize = int.Parse(tb_AdaptiveSize.Text);
                int delta = int.Parse(tb_AdaptiveDelta.Text);

                if (cb_ThresType.SelectedIndex == 0) {
                    thresholdBinary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Threshold, MaxVal, Region);
                }
                else if (cb_ThresType.SelectedIndex == 1) {
                    thresholdBinaryOTSU(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, MaxVal, Region, otsuThres);
                    lbl_OTSU.Text = "最佳阈值: " + (int)otsuThres[0];
                }
                else if (cb_ThresType.SelectedIndex == 2) {
                    thresholdBinaryAdaptive(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, MaxVal, Region, cb_Adaptive.SelectedIndex, ksize, delta);
                }
            }
            else if (curTab == tabPage_Dilate) {
                int kx = int.Parse(nud_DilateKerX.Value.ToString());
                int ky = int.Parse(nud_DilateKerY.Value.ToString());

                dilate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, kx, ky);
            }
            else if (curTab == tabPage_Erode) {
                int kx = int.Parse(nud_ErodeKerX.Value.ToString());
                int ky = int.Parse(nud_ErodeKerY.Value.ToString());

                erode(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, kx, ky);
            }
            else if (curTab == tabPage_Equalize) {
                equalize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1);
            }
            else if (curTab == tabPage_Normalize) {
                int low = int.Parse(tb_NormLow.Text);
                int high = int.Parse(tb_NormHigh.Text);

                normalize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, low, high);
            }
            else if (curTab == tabPage_EdgeDetect) {
                if (cb_EdgeDetect.SelectedIndex == 0) {
                    int ksize = int.Parse(tb_SobelKsize.Text);
                    int dx = int.Parse(tb_Sobeldx.Text);
                    int dy = int.Parse(tb_Sobeldy.Text);
                    sobel(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, dx, dy, ksize);
                }
                else if (cb_EdgeDetect.SelectedIndex == 1) {
                    int ksize = int.Parse(tb_LapKsize.Text);
                    laplacian(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, ksize);
                }
                else if (cb_EdgeDetect.SelectedIndex == 2) {
                    int ksize = int.Parse(tb_GSKsize.Text);
                    int lthres = int.Parse(tb_LowThres.Text);
                    int hthres = int.Parse(tb_HighThres.Text);
                    cannyCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, ksize, lthres, hthres);
                }
            }
            else if (curTab == tabPage_ConnectArea)
            {
                int Size = int.Parse(nud_AreaIdx.Value.ToString());
                int AreaNum = int.Parse(tb_AreaMaxNum.Text);
                int MinArea = int.Parse(tb_AreaMin.Text);
                int[] Center = new int[2];
                int[] Rect = new int[8];
                int[] conArea = new int[1];

                connectedComponent(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Size, AreaNum, MinArea, conArea, Center, Rect);

                tb_AreaCtr.Text = string.Join(",", Array.ConvertAll(Center, x => x));
                tb_AreaRect.Text = string.Join(",", Array.ConvertAll(Rect, x => x));
                lbl_Area.Text = "轮廓面积：" + conArea[0].ToString();
            }
            else if (curTab == tabPage_HoughDetect) {
                if (cb_HoughDetect.SelectedIndex == 0) {
                    int[] linesTest = new int[100000];
                    float rho = float.Parse(tb_LineRHO.Text);
                    float theta = float.Parse(tb_LineTheta.Text);
                    int thres = int.Parse(tb_LineThres.Text);
                    float minLen = float.Parse(tb_LineMinLen.Text);
                    float maxGap = float.Parse(tb_LineMaxGap.Text);

                    houghLinesPCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, linesTest, rho, (float)Math.PI / theta, thres, minLen, maxGap);
                    drawHoughLinesCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, linesTest);
                }
            }
            // 绘制执行
            else if (curTab == tabPage_DrawPts) {
                int[] color = getPtsColor(false);
                int thickness = int.Parse(nud_PtsThick.Value.ToString());
                string ptsText = tb_PtsSet.Text;
                if (ptsText.IndexOf(",") != -1)
                {
                    string[] temp = ptsText.Trim().Split(',');
                    if (temp.Length % 2 == 0) {
                        float[] pts = new float[3];
                        for (int i = 0; i < temp.Length; i++, i++)
                        {
                            pts[1] = float.Parse(temp[i]);
                            pts[2] = float.Parse(temp[i + 1]);
                            if (i == 0)
                                drawCircleCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, -1, pts, thickness);
                            else
                                drawCircleCV(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1, color, -1, pts, thickness);
                        }
                    }
                    else
                        error.Print(ErrorInfo.PTS_DATA_ERROR);
                }
                else if (ptsText.IndexOf("\n") != -1) {
                    string[] temp = ptsText.Trim().Split('\n');
                    if (temp.Length % 2 == 0)
                    {
                        float[] pts = new float[3];
                        for (int i = 0; i < temp.Length; i++, i++)
                        {
                            pts[1] = float.Parse(temp[i]);
                            pts[2] = float.Parse(temp[i + 1]);
                            if (i == 0)
                                drawCircleCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, -1, pts, thickness);
                            else
                                drawCircleCV(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1, color, -1, pts, thickness);
                        }
                    }
                    else
                        error.Print(ErrorInfo.PTS_DATA_ERROR);
                }
                else
                    error.Print(ErrorInfo.PTS_DATA_ERROR);
            }
            else if (curTab == tabPage_DrawLine) {
                float[] pos = new float[5];
                for (int i = 0; i < 4; i++) {
                    pos[i + 1] = float.Parse(Grid_Line.Rows[i / 2].Cells[i % 2].Value.ToString());
                }
                int[] color = getLineColor(false);
                int thickness = int.Parse(nud_LineThick.Value.ToString());

                drawLineCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos);
            }
            else if (curTab == tabPage_DrawCircle) {
                float[] pos = new float[3];
                for (int i = 0; i < 2; i++) {
                    pos[i + 1] = float.Parse(Grid_Circle.Rows[i / 2].Cells[i % 2].Value.ToString());
                }
                int radius = int.Parse(Grid_Circle.Rows[0].Cells[2].Value.ToString());
                int thickness = int.Parse(nud_CircleThick.Value.ToString());
                int[] color = getCircleColor(false);

                drawCircleCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos, radius);
            }
            else if (curTab == tabPage_DrawRect) {
                float[] pos = new float[9];
                for (int i = 0; i < 8; i++) {
                    pos[i + 1] = float.Parse(Grid_Rect.Rows[i / 2].Cells[i % 2].Value.ToString());
                }
                int thickness = int.Parse(nud_RectThick.Value.ToString());
                int[] color = getRectColor(false);

                drawRectCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos, cbx_IsPRect.Checked);
            }
            else if (curTab == tabPage_Rotate) {
                float angle = float.Parse(tb_RotateAngle.Text);
                float[] center = new float[2] { int.Parse(tb_RotateCenterX.Text), int.Parse(tb_RotateCenterY.Text) };

                rotate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, angle, center);
            }
            else if (curTab == tabPage_Flip) {
                int direct = int.Parse(tb_FlipDirect.Text);

                flip(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, direct);
            }
            else if (curTab == tabPage_Thin)
            {
                thinImage(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, cb_ThinTypes.SelectedIndex);
            }
            else if (curTab == tabPage_Perspective) {
                float[] src = new float[8];
                float[] dst = new float[8];
                string[] srcStr = tb_PersSrcPts.Text.Trim().Split(',');
                string[] dstStr = tb_PersDstPts.Text.Trim().Split(',');
                for (int i = 0; i < srcStr.Length; i++) 
                    src[i] = float.Parse(srcStr[i]);
                for (int i = 0; i < dstStr.Length; i++)
                    dst[i] = float.Parse(dstStr[i]);
                int[] size = new int[2] { int.Parse(tb_PersWidth.Text), int.Parse(tb_PersHeight.Text) };

                warpPerspectiveCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, src, dst, size);
            }
            //-----------
            else if (curTab == tabPage_UserDef) {
                int num1 = int.Parse(tb_UserDef1.Text);
                if (cb_UserDef.SelectedIndex == 0) {
                    pepperNoise(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, num1);
                }
                else if (cb_UserDef.SelectedIndex == 1) {
                    saltNoise(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, num1);
                }
                else if (cb_UserDef.SelectedIndex == 2)
                {
                    
                    //thinImage(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, num1);
                }
            }

            UpdateOutputImage(outputImage.Count, s1, a1, b1, c1);
            UpdateImageOutput();

            // 特例
            if (curTab == tabPage_Resize) {
                int w = int.Parse(tb_ResizeW.Text);
                int h = int.Parse(tb_ResizeH.Text);
                float ws = float.Parse(tb_ResizeWScale.Text);
                float hs = float.Parse(tb_ResizeHScale.Text);

                int[] a2 = new int[1]; int[] b2 = new int[1]; int[] c2 = new int[1];
                byte[] s2 = new byte[(w == 0 ? (int)(inputImage[1].Width * ws) : w)
                                        * (h == 0 ? (int)(inputImage[1].Height * hs) : h)
                                            * inputImage[1].Channel];

                resize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s2[0], a2, b2, c2, w, h, ws, hs, 0);

                UpdateOutputImage(outputImage.Count, s2, a2, b2, c2);
                UpdateImageOutput();
            }
            else if (curTab == tabPage_Gray2RGB)
            {
                int[] a2 = new int[1]; int[] b2 = new int[1]; int[] c2 = new int[1];
                byte[] s2 = new byte[inputImage[1].Width * inputImage[1].Height * 3];

                Gray2Pseudo(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s2[0], a2, b2, c2, cb_ColorMapTypes.SelectedIndex);

                UpdateOutputImage(outputImage.Count, s2, a2, b2, c2);
                UpdateImageOutput();
            }
        }

        private void UpdateImageInput()
        {
            // 清除内存中多余的输出存储，更新输入
            if (cb_BackUp.Items.Count > 0) {
                int curIndex = cb_BackUp.SelectedIndex;
                for (int i = outputImage.Count - 1; i > curIndex; i--) {
                    outputImage.Remove(i);
                    if (cb_BackUp.Items.Count > i)
                        cb_BackUp.Items.RemoveAt(i);
                }
                stepTab.RemoveRange(curIndex + 1, stepTab.Count - curIndex - 1);
                UpdateInputImage(1, outputImage[curIndex]);
            }
            Timepiece.Restart();
        }

        private void UpdateImageOutput()
        {
            Timepiece.Stop();
            tssl_Runtime.Text = String.Format("{0:f3}ms", Timepiece.ElapsedTicks * 1000 / (double)Stopwatch.Frequency);

            int index = outputImage.Count;
            if (index > 0 && index > cb_BackUp.Items.Count) {
                stepTab.Add(curTab);
                // 图像数据处理
                cb_BackUp.Items.Add(cb_BackUp.Items.Count.ToString() + "." + curTab.Text);
                cb_BackUp.SelectedIndex = cb_BackUp.Items.Count - 1;
            }
        }

        // 显示图像回退至选择位置
        private void cb_BackUp_SelectedIndexChanged(object sender, int index)
        {
            if (cb_BackUp.Items.Count > 0) {
                UpdateCurImage(1, index);
                TabPageDisplay(TabPageJudge(index));
            }
        }

        // 显示图像回退一次
        private void button_backOnce_Click(object sender, EventArgs e)
        {
            if (cb_BackUp.SelectedIndex > 0) {
                cb_BackUp.SelectedIndex = curImage.index - 1;
            }
        }

        #endregion


        #region 输入参数部分的事件

        // 打开图像信息处理窗口
        private void button_ImgaeHandleForm_Click(object sender, EventArgs e)
        {
            if (inputImage.Count > 0) {
                ImageForm.Show();
                ImageForm.Location = PointToScreen(
                    new Point(tc_Image.Location.X,
                    tc_Image.Location.Y + 50));
            }
        }

        // 清空绘制数据
        private void btn_ToolGraphClear_Click(object sender, EventArgs e)
        {
            graphNum = 0;
            picBox.Image = oriImg;

            tb_CalibratePts.Clear();
        }


        #region 绘制设置

        #region 调色板

        // 画布通道数限制
        private void tb_CanvasC_TextChanged(object sender, EventArgs e)
        {
            int chn = int.Parse(tb_CanvasC.Text);
            if (chn != 1 && chn != 3) 
                tb_CanvasC.Text = chn > 3 ? "3" : "1";
        }

        // 获取绘制颜色
        private int[] getCanvasColor(bool rgb = true)
        {
            int r = int.Parse(nud_CanvasR.Value.ToString());
            int g = int.Parse(nud_CanvasG.Value.ToString());
            int b = int.Parse(nud_CanvasB.Value.ToString());
            return int.Parse(tb_CanvasC.Text) == 1 ? new int[3] { r, r, r } :
                (rgb ? new int[3] { r, g, b } : new int[3] { b, g, r });
        }
        private int[] getPtsColor(bool rgb = true)
        {
            int r = int.Parse(nud_PtsR.Value.ToString());
            int g = int.Parse(nud_PtsG.Value.ToString());
            int b = int.Parse(nud_PtsB.Value.ToString());
            return curImage.img.Channel == 1 ? new int[3] { r, r, r } :
                (rgb ? new int[3] { r, g, b } : new int[3] { b, g, r });
        }
        private int[] getLineColor(bool rgb = true)
        {
            int r = int.Parse(nud_LineR.Value.ToString());
            int g = int.Parse(nud_LineG.Value.ToString());
            int b = int.Parse(nud_LineB.Value.ToString());
            return curImage.img.Channel == 1 ? new int[3] { r, r, r } :
                (rgb ? new int[3] { r, g, b } : new int[3] { b, g, r });
        }
        private int[] getRectColor(bool rgb = true)
        {
            int r = int.Parse(nud_RectR.Value.ToString());
            int g = int.Parse(nud_RectG.Value.ToString());
            int b = int.Parse(nud_RectB.Value.ToString());
            return curImage.img.Channel == 1 ? new int[3] { r, r, r } :
                (rgb ? new int[3] { r, g, b } : new int[3] { b, g, r });
        }
        private int[] getCircleColor(bool rgb = true)
        {
            int r = int.Parse(nud_CircleR.Value.ToString());
            int g = int.Parse(nud_CircleG.Value.ToString());
            int b = int.Parse(nud_CircleB.Value.ToString());
            return curImage.img.Channel == 1 ? new int[3] { r, r, r } :
                (rgb ? new int[3] { r, g, b } : new int[3] { b, g, r });
        }

        // 更新颜色显示
        private void nud_CanvasR_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CanvasColor, getCanvasColor());
        }
        private void nud_CanvasG_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CanvasColor, getCanvasColor());
        }
        private void nud_CanvasB_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CanvasColor, getCanvasColor());
        }
        private void nud_PtsR_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_PtsColor, getPtsColor());
        }
        private void nud_PtsG_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_PtsColor, getPtsColor());
        }
        private void nud_PtsB_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_PtsColor, getPtsColor());
        }
        private void nud_LineR_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_LineColor, getLineColor());
        }
        private void nud_LineG_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_LineColor, getLineColor());
        }
        private void nud_LineB_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_LineColor, getLineColor());
        }
        private void nud_RectR_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_RectColor, getRectColor());
        }
        private void nud_RectG_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_RectColor, getRectColor());
        }
        private void nud_RectB_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_RectColor, getRectColor());
        }
        private void nud_CircleR_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CircleColor, getCircleColor());
        }
        private void nud_CircleG_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CircleColor, getCircleColor());
        }
        private void nud_CircleB_ValueChanged(object sender, EventArgs e)
        {
            updateColorPalette(pnl_CircleColor, getCircleColor());
        }
        // 更新调色板
        private void updateColorPalette(Control pnl, int[] rgb)
        {
            pnl.BackColor = Color.FromArgb(rgb[0], rgb[1], rgb[2]);
        }

        #endregion

        // 手动截取启动
        private void btn_ToolCut_Click(object sender, EventArgs e)
        {
            try { 
                // 页面显示
                TabPageDisplay(tabPage_CutImage);

                // 初始化画笔
                line.Init(nud_RectThick.Value, getRectColor());

                // 启动标志置位
                dragFlag = false;
                startCutFlag = !startCutFlag;
                Cursor = startCutFlag ? Cursors.Cross : Cursors.Default;

                oriImg = startCutFlag ? (Image)picBox.Image.Clone() : oriImg;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }

        // 手动标点
        private void btn_ToolPts_Click(object sender, EventArgs e)
        {
            try {
                TabPageDisplay(tabPage_ImageInfo);

                line.Init(nud_PtsThick.Value, getPtsColor());

                dragFlag = false;
                startPtsFlag = !startPtsFlag;
                Cursor = startPtsFlag ? Cursors.Cross : Cursors.Default;

                oriImg = startPtsFlag && tb_CalibratePts.Text == "" 
                            ? (Image)picBox.Image.Clone() : oriImg;
                startDrawFlag = false;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }

        // 手动画线启动
        private void btn_ToolLine_Click(object sender, EventArgs e)
        {
            try
            {
                TabPageDisplay(tabPage_DrawLine);

                line.Init(nud_LineThick.Value, getLineColor());

                dragFlag = false;
                startLineFlag = !startLineFlag;
                Cursor = startLineFlag ? Cursors.Cross : Cursors.Default;

                oriImg = startLineFlag && graphNum == 0 
                            ? (Image)picBox.Image.Clone() : oriImg;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }

        // 手动画圆启动
        private void btn_ToolCircle_Click(object sender, EventArgs e)
        {
            try
            {
                TabPageDisplay(tabPage_DrawCircle);

                line.Init(nud_CircleThick.Value, getCircleColor());

                dragFlag = false;
                startCircleFlag = !startCircleFlag;
                Cursor = startCircleFlag ? Cursors.Cross : Cursors.Default;

                oriImg = startCircleFlag && graphNum == 0
                            ? (Image)picBox.Image.Clone() : oriImg;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }

        // 手动画正矩形启动
        private void btn_ToolPRect_Click(object sender, EventArgs e)
        {
            try
            {
                if (curTab != tabPage_Perspective)
                    TabPageDisplay(tabPage_DrawRect);

                line.Init(nud_RectThick.Value, getRectColor());

                dragFlag = false;
                startPRectFlag = !startPRectFlag;
                cbx_IsPRect.Checked = true;
                Cursor = startPRectFlag ? Cursors.Cross : Cursors.Default;

                oriImg = startPRectFlag && graphNum == 0
                            ? (Image)picBox.Image.Clone() : oriImg;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }
        // 手动画矩形启动
        private void btn_ToolRect_Click(object sender, EventArgs e)
        {
            try {
                if (curTab != tabPage_Perspective)
                    TabPageDisplay(tabPage_DrawRect);

                line.Init(nud_RectThick.Value, getRectColor());
                
                dragFlag = false;
                startRectFlag = startRectFlag > -1 ? -1 : 0;
                cbx_IsPRect.Checked = false;
                Cursor = startRectFlag > -1 ? Cursors.Cross : Cursors.Default;

                oriImg = startRectFlag == 0 && graphNum == 0
                            ? (Image)picBox.Image.Clone() : oriImg;
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.IMAGE_NOEXIST_ERROR);
            }
        }
        

        #endregion


        #region 功能块引脚控件事件

        // 透视变换
        private void btn_PersSrcPts_Click(object sender, EventArgs e)
        {
            tb_PersSrcPts.Clear();
            tb_PersSrcPts.Text += ((int)Grid_Rect.Rows[0].Cells[0].Value).ToString();
            for (int i = 1; i < 8; i++) {
                tb_PersSrcPts.Text += "," +
                    ((int)Grid_Rect.Rows[i / 2].Cells[i % 2].Value).ToString();
            }
        }
        private void btn_PersDstPts_Click(object sender, EventArgs e)
        {
            tb_PersDstPts.Clear();
            tb_PersDstPts.Text += ((int)Grid_Rect.Rows[0].Cells[0].Value).ToString();
            for (int i = 1; i < 8; i++)
            {
                tb_PersDstPts.Text += "," +
                    ((int)Grid_Rect.Rows[i / 2].Cells[i % 2].Value).ToString();
            }
        }
        private void tabPage_Perspective_ParentChanged(object sender, EventArgs e)
        {
            if (tabPage_Perspective.Parent != null && curImage.img != null) 
                cb_PersSize.SelectedIndex = 0;
        }
        private void cb_PersSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_PersSize.SelectedIndex == 0) {
                tb_PersWidth.Text = curImage.img.Width.ToString();
                tb_PersHeight.Text = curImage.img.Height.ToString();
            }
            else if (cb_PersSize.SelectedIndex == 1) {
                if (tb_PersDstPts.Text.Contains(',')) {
                    string[] str = tb_PersDstPts.Text.Split(',');

                    tb_PersWidth.Text = (int.Parse(str[7]) - int.Parse(str[1])).ToString();
                    tb_PersHeight.Text = (int.Parse(str[2]) - int.Parse(str[0])).ToString();
                }
                else {
                    tb_PersWidth.Clear();
                    tb_PersHeight.Clear();
                }
            }
            else if (cb_PersSize.SelectedIndex == 2) {
                tb_PersWidth.Clear();
                tb_PersHeight.Clear();
            }
        }

        // 二值化

        private void cb_ThresType_SelectedIndexChanged(object sender, int index)
        {
            gb_ExtendBox.Visible = index != 0;

            lbl_OTSU.Visible = index == 1;

            lbl_Adaptive1.Visible = index == 2;
            cb_Adaptive.Visible = index == 2;
            lbl_Adaptive2.Visible = index == 2;
            tb_AdaptiveSize.Visible = index == 2;
            lbl_Adaptive3.Visible = index == 2;
            tb_AdaptiveDelta.Visible = index == 2;
        }

        // 旋转预览
        private void tkb_RotateAngle_Scroll(object sender, EventArgs e)
        {
            float angle = tkb_RotateAngle.Value / 10.0f;
            tb_RotateAngle.Text = angle.ToString();
        }
        private void tkb_RotateAngle_Scrolled(object sender, int value)
        {
            float angle = value / 10.0f;
            tb_RotateAngle.Text = angle.ToString();
        }
        private void tb_RotateAngle_TextChanged(object sender, EventArgs e)
        {
            if ((isFloatNumber.IsMatch(tb_RotateAngle.Text) || isPositiveNumber.IsMatch(tb_RotateAngle.Text)) && !string.IsNullOrEmpty(tb_RotateAngle.Text)) {
                float angle = float.Parse(tb_RotateAngle.Text);
                if (angle < 0) angle = 0;
                else if (angle > 360) angle = 360;

                tkb_RotateAngle.Value = (int)(angle * 10);

                if (inputImage.Count > 0) {
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];
                    float[] center = new float[2] { int.Parse(tb_RotateCenterX.Text), int.Parse(tb_RotateCenterY.Text) };

                    UpdateInputImage(1, outputImage[cb_BackUp.SelectedIndex]);

                    rotate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, angle, center);
                    UpdateInputImage(88, s1, a1, b1, c1);

                    UpdateCurImage(0, 88);
                    // DisplayFromMemory(picBox, inputImage[88]);
                }
            }
        }
        private void tabPage_Rotate_ParentChanged(object sender, EventArgs e)
        {
            if (tabPage_Rotate.Parent != null && curImage.img != null) {
                tb_RotateCenterX.Text = (curImage.img.Width / 2).ToString();
                tb_RotateCenterY.Text = (curImage.img.Height / 2).ToString();
            }
            else if (tabPage_Rotate.Parent == null && curImage.img != null) {
                //DisplayFromMemory(picBox, inputImage[1]);
                UpdateCurImage(1, cb_BackUp.SelectedIndex);
            }
        }

        // 边缘检测参数输入生成
        private void cb_EdgeDetect_SelectedIndexChanged(object sender, int index)
        {
            gb_Sobel.Visible = index == 0;
            gb_Laplacian.Visible = index == 1;
            gb_CannyPara.Visible = index == 2;
        }
        // 霍夫检测参数输入生成
        private void cb_HoughDetect_SelectedIndexChanged(object sender, int index)
        {
            gb_HoughLineP.Visible = index == 0;
        }

        // 找轮廓选项
        private void cbx_ConMinRect_CheckedChanged(object sender, EventArgs e)
        {
            cbx_ConMinPRect.Checked = !cbx_ConMinRect.Checked;
        }
        private void cbx_ConMinPRect_CheckedChanged(object sender, EventArgs e)
        {
            cbx_ConMinRect.Checked = !cbx_ConMinPRect.Checked;
        }

        // 图像作差载入减数图片
        private void btn_SubImage_Click(object sender, EventArgs e)
        {
            string file = FuncDef.OpenFile();
            if (file == "")
                error.Print(ErrorInfo.IMAGE_PATH_ERROR);
            else {
                DisplayFromFile(pb_Substract, file);
                SavePicImageInMemory(pb_Substract, file, inputImage, 2);
            }
        }
        private void pb_Substract_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            DisplayFromFile(pb_Substract, fileName);

            SavePicImageInMemory(pb_Substract, fileName, inputImage, 2);
        }
        private void pb_Substract_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        // 图像求和载入加数图片
        private void btn_AddImage_Click(object sender, EventArgs e)
        {
            string file = FuncDef.OpenFile();
            if (file == "")
                error.Print(ErrorInfo.IMAGE_PATH_ERROR);
            else
            {
                DisplayFromFile(pb_AddImage, file);
                SavePicImageInMemory(pb_AddImage, file, inputImage, 2);
            }
        }
        private void pb_AddImage_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            DisplayFromFile(pb_AddImage, fileName);

            SavePicImageInMemory(pb_AddImage, fileName, inputImage, 2);
        }
        private void pb_AddImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        // 导出HSV参数
        private void btn_ExportHSV_Click(object sender, EventArgs e)
        {
            string dir = sourcePath.Remove(sourcePath.LastIndexOf("\\") + 1);
            float LowH = (float)nud_LowH.Value;
            float HighH = (float)nud_HighH.Value;
            float LowS = (float)nud_LowS.Value;
            float HighS = (float)nud_HighS.Value;
            float LowV = (float)nud_LowV.Value;
            float HighV = (float)nud_HighV.Value;

            FileStream file = new FileStream(dir + "HSV.txt", FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + "    " + sourcePath);
            sw.WriteLine("--H: " + LowH + " - " + HighH);
            sw.WriteLine("--S: " + LowS + " - " + HighS);
            sw.WriteLine("--V: " + LowV + " - " + HighV + "\n");
            sw.Close();
            file.Close();
        }

        // 剪切图片修改数据更新框
        private void nud_CutX_ValueChanged(object sender, EventArgs e)
        {
            UpdateCutRect();
        }
        private void nud_CutY_ValueChanged(object sender, EventArgs e)
        {
            UpdateCutRect();
        }
        private void nud_CutW_ValueChanged(object sender, EventArgs e)
        {
            UpdateCutRect();
        }
        private void nud_CutH_ValueChanged(object sender, EventArgs e)
        {
            UpdateCutRect();
        }
        private void UpdateCutRect()
        {
            Graphics pb = picBox.CreateGraphics();
            Point start = PixelToWidgetPoint((int)nud_CutX.Value, (int)nud_CutY.Value);
            Point end = PixelToWidgetPoint((int)nud_CutX.Value + (int)nud_CutW.Value,
                                            (int)nud_CutY.Value + (int)nud_CutH.Value);

            line.DrawClear(pb);
            picBox.Refresh();
            line.DrawCut(pb, start, end);
        }

        // Resize纵横比锁定
        private void tb_ResizeW_TextChanged(object sender, EventArgs e)
        {
            if (ckb_Resize.Checked && curImage.img != null) {
                if (isChangedH) {
                    isChangedH = false;
                }
                else {
                    isChangedW = true;
                    int c = int.Parse(tb_ResizeW.Text);
                    int nc = (int)(c * 1.0 / curImage.img.Width * curImage.img.Height);
                    tb_ResizeH.Text = nc.ToString();
                }
            }
        }
        private void tb_ResizeH_TextChanged(object sender, EventArgs e)
        {
            if (ckb_Resize.Checked && curImage.img != null) {
                if (isChangedW) {
                    isChangedW = false;
                }
                else {
                    isChangedH = true;
                    int c = int.Parse(tb_ResizeH.Text);
                    int nc = (int)(c * 1.0 / curImage.img.Height * curImage.img.Width);
                    tb_ResizeW.Text = nc.ToString();
                }
            }
        }
        private void tb_ResizeWScale_TextChanged(object sender, EventArgs e)
        {
            if (ckb_Resize.Checked) tb_ResizeHScale.Text = tb_ResizeWScale.Text;
        }
        private void tb_ResizeHScale_TextChanged(object sender, EventArgs e)
        {
            if (ckb_Resize.Checked) tb_ResizeWScale.Text = tb_ResizeHScale.Text;
        }

        #endregion


        #endregion


        #region 图像部分的事件


        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (picBox.Image != null && startDrawFlag) {
                if (startLineFlag)
                    line.DrawLine(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startCircleFlag)
                    line.DrawCircle(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startCutFlag)
                    line.DrawCut(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startPRectFlag)
                    line.DrawPRect(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startRectFlag > 0) {
                    for (int i = 1; i < startRectFlag; i++) {
                        line.DrawLine(e.Graphics, rectPoints[i - 1], rectPoints[i]);
                    }
                    if (startRectFlag < 4) line.DrawLine(e.Graphics, lineStartPoint, lineEndPoint);
                    else line.DrawLine(e.Graphics, rectPoints[3], rectPoints[0]);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (picBox.Image != null)
            {
                Point start = WidgetToPixelPoint(lineStartPoint);
                Point end = WidgetToPixelPoint(lineEndPoint);
                Graphics g = Graphics.FromImage(picBox.Image);
                //Graphics g = picBox.CreateGraphics();

                if (dragFlag)
                {
                    dragFlag = false;
                }
                else if (startCutFlag)
                {
                    startCutFlag = false;
                    // 剪切框只把截图位置信息更新到输入框中
                    nud_CutW.Value = (end.X - start.X) > 0 ? end.X - start.X : start.X - end.X;
                    nud_CutH.Value = (end.Y - start.Y) > 0 ? end.Y - start.Y : start.Y - end.Y;
                    nud_CutX.Value = (end.X - start.X) > 0 ? start.X : end.X;
                    nud_CutY.Value = (end.Y - start.Y) > 0 ? start.Y : end.Y;
                }
                else if (startPtsFlag)
                {
                    line.DrawPts(g, start);
                    //picBox.Invalidate();

                    if (String.IsNullOrEmpty(tb_CalibratePts.Text))
                        tb_CalibratePts.Text += start.X.ToString() + "," + start.Y.ToString();
                    else
                        tb_CalibratePts.Text += "," + start.X.ToString() + "," + start.Y.ToString();

                    tb_CalibratePts.Focus();
                    tb_CalibratePts.Select(tb_CalibratePts.TextLength, 0);
                    tb_CalibratePts.ScrollToCaret();
                    return;
                }
                else if (startLineFlag)
                {
                    startLineFlag = false;
                    graphNum++;

                    float[] pos = { start.X, start.Y, end.X, end.Y };
                    for (int i = 0; i < 4; i++)
                    {
                        Grid_Line.Rows[i / 2].Cells[i % 2].Value = pos[i];
                    }

                    line.DrawLine(g, start, end);
                }
                else if (startCircleFlag)
                {
                    startCircleFlag = false;
                    graphNum++;

                    int radius = (int)Math.Pow(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2), 0.5);
                    Grid_Circle.Rows[0].Cells[0].Value = start.X;
                    Grid_Circle.Rows[0].Cells[1].Value = start.Y;
                    Grid_Circle.Rows[0].Cells[2].Value = radius;

                    line.DrawCircle(g, start, radius);
                }
                else if (startPRectFlag)
                {
                    startPRectFlag = false;
                    graphNum++;

                    Grid_Rect.Rows[0].Cells[0].Value =
                        Grid_Rect.Rows[3].Cells[0].Value = start.X;
                    Grid_Rect.Rows[0].Cells[1].Value =
                        Grid_Rect.Rows[1].Cells[1].Value = start.Y;
                    Grid_Rect.Rows[1].Cells[0].Value =
                        Grid_Rect.Rows[2].Cells[0].Value = end.X;
                    Grid_Rect.Rows[2].Cells[1].Value =
                        Grid_Rect.Rows[3].Cells[1].Value = end.Y;

                    line.DrawPRect(g, start, end);
                }
                else if (startRectFlag != -1)
                {
                    lineStartPoint = lineEndPoint;
                    startRectFlag++;
                    graphNum++;

                    if (startRectFlag == 4)
                    {
                        picBox.Refresh();
                        startRectFlag = -1;

                        Point img = WidgetToPixelPoint(rectPoints[3]);
                        Grid_Rect.Rows[3].Cells[0].Value = img.X;
                        Grid_Rect.Rows[3].Cells[1].Value = img.Y;

                        line.DrawRect(g, rectPoints);
                    }
                    else
                    {
                        Point img = WidgetToPixelPoint(rectPoints[startRectFlag - 1]);
                        Grid_Rect.Rows[startRectFlag - 1].Cells[0].Value = img.X;
                        Grid_Rect.Rows[startRectFlag - 1].Cells[1].Value = img.Y;
                        return;
                    }
                }

                startDrawFlag = false;
                Cursor = Cursors.Default;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (picBox.Image != null) {
                if (startDrawFlag) {
                    lineEndPoint = e.Location;
                    picBox.Invalidate();
                }
                else if (dragFlag) {
                    picBox.Location = ImageLocControl(new Point(
                        picBox.Left + e.X - dragStart.X,
                        picBox.Top + e.Y - dragStart.Y));
                }

                // 更新右下角坐标、RGB数据和HSV数据
                Point mouse = WidgetToPixelPoint(e.Location);

                if (mouse.X < picBox.Image.Width && mouse.Y < picBox.Image.Height) {
                    lbl_MousePos.Text = "坐标:\n" + mouse.X + ", " + mouse.Y;

                    Color rgb = new Bitmap(picBox.Image).GetPixel(mouse.X, mouse.Y);
                    lbl_MouseRGB.Text = "RGB:\n" + rgb.R + ", " + rgb.G + ", " + rgb.B;

                    int h = 0; float s = 0, v = 0;
                    ValueHelper.RGB2HSV(rgb.R, rgb.G, rgb.B, ref h, ref s, ref v);
                    lbl_MouseHSV.Text = "HSV:\n" + h.ToString() + ", " +
                        String.Format("{0:f2}", s) + ", " + String.Format("{0:f2}", v);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (startPtsFlag || startLineFlag || startCutFlag || startCircleFlag || startPRectFlag) {
                    lineStartPoint = e.Location;
                    startDrawFlag = true;
                }
                else if (startRectFlag != -1) {
                    startDrawFlag = true;
                    rectPoints[startRectFlag] = e.Location;
                    lineEndPoint = rectPoints[startRectFlag];
                }
                else {
                    dragStart = e.Location;
                    dragFlag = true;
                    Cursor = Cursors.Hand;
                }
            }
        }

        // 坐标转换函数
        private Point WidgetToPixelPoint(int x, int y)
        {
            return new Point(
                    Convert.ToInt32(x / imageScale), Convert.ToInt32(y / imageScale));
        }
        private Point WidgetToPixelPoint(Point p)
        {
            return new Point(
                    Convert.ToInt32(p.X / imageScale), Convert.ToInt32(p.Y / imageScale));
        }
        private Point PixelToWidgetPoint(int x, int y)
        {
            return new Point(
                    Convert.ToInt32(x * imageScale), Convert.ToInt32(y * imageScale));
        }
        private Point PixelToWidgetPoint(Point p)
        {
            return new Point(
                    Convert.ToInt32(p.X * imageScale), Convert.ToInt32(p.Y * imageScale));
        }

        // 支持直接拖进图片加载
        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
        private void pictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string fileName = ((Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();

            loadImage(fileName);
        }

        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            CalImageInfo(picBox.Image);
        }

        // 图像控件的缩放
        private void ScaleImage(int mDelta, Point fixedP)
        {
            float curScale = imageScale + mDelta * smallStep;
            if (mDelta < 0) {
                if (curScale < minScale) {
                    AdaptImage();
                    return;
                }
            }
            else if (curScale > maxScale) curScale = maxScale;

            if (imageScale != curScale) {
                double tmp = curScale / imageScale;
                imageScale = curScale;
                picBox.Size = new Size(
                    Convert.ToInt32(picBox.Width * tmp),
                    Convert.ToInt32(picBox.Height * tmp));
                tmp -= 1;
                picBox.Location = ImageLocControl(new Point(
                    picBox.Left - Convert.ToInt32(fixedP.X * tmp),
                    picBox.Top - Convert.ToInt32(fixedP.Y * tmp)));
            }
        }

        // 图片移动限幅
        private Point ImageLocControl(Point p)
        {
            if (picBox.Location == p) return p;

            if (p.X < imageLocRange.Left) p.X = imageLocRange.Left;
            else if (p.X > imageLocRange.Right) p.X = imageLocRange.Right;

            if (p.Y < imageLocRange.Top) p.Y = imageLocRange.Top;
            else if (p.Y > imageLocRange.Bottom) p.Y = imageLocRange.Bottom;

            return p;
        }

        private void CalImageInfo(Image img)
        {
            displaySize = panel_Display.Size;
            double whScale = 1.0 * img.Height / img.Width;
            double whScaleDisplay = 1.0 * displaySize.Height / displaySize.Width;

            // 图像载入后显示的初始大小
            imageInitSize = whScale < whScaleDisplay ?
                new Size(displaySize.Width, Convert.ToInt32(displaySize.Width * whScale)) :
                new Size(Convert.ToInt32(displaySize.Height / whScale), displaySize.Height);

            // 图像移动的范围限制计算
            CalimageLocRange();

            imageInitLoc = new Point(
                (displaySize.Width - imageInitSize.Width) >> 1,
                (displaySize.Height - imageInitSize.Height) >> 1);
            minScale = 1.0f * imageInitSize.Width / img.Width;
        }

        private void CalimageLocRange()
        {
            imageLocRange.Width = picBox.Width - displaySize.Width;
            if (imageLocRange.Width < 0) {
                imageLocRange.X = (-imageLocRange.Width) >> 1;
                imageLocRange.Width = 0;
            }
            else imageLocRange.X = -imageLocRange.Width;

            imageLocRange.Height = picBox.Height - displaySize.Height;
            if (imageLocRange.Height < 0) {
                imageLocRange.Y = (-imageLocRange.Height) >> 1;
                imageLocRange.Height = 0;
            }
            else imageLocRange.Y = -imageLocRange.Height;
        }

        private void AdaptImage()
        {
            if (picBox.Image != null) {
                imageScale = minScale;
                picBox.Size = imageInitSize;
                picBox.Location = imageInitLoc;
            }
        }

        // 右键保存图片操作
        private void cmsItem_SaveAs_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog folder = new System.Windows.Forms.SaveFileDialog();
            folder.Filter = "BMP文件|*.bmp*|JPEG文件|*.jpg*|PNG文件|*.png*";
            folder.FileName = RenameFile();

            if (folder.ShowDialog() == DialogResult.OK) {
                string path = folder.FileName;
                string suffix = "";
                int idx = -1;
                if (folder.FilterIndex == 1) {
                    suffix = ".bmp";
                    idx = path.IndexOf(suffix);
                }
                else if (folder.FilterIndex == 2) {
                    suffix = ".jpg";
                    idx = path.IndexOf(suffix);
                }
                else if (folder.FilterIndex == 3) {
                    suffix = ".png";
                    idx = path.IndexOf(suffix);
                }
                path = idx == -1 ? path : path.Substring(0, idx);

                writeImage(path + suffix, ref curImage.img.Data[0],
                    curImage.img.Width, curImage.img.Height, curImage.img.Channel);

                error.Print(ErrorInfo.RUN, "另存为成功", 2000);
            }
        }
        private void cmsItem_Save_Click(object sender, EventArgs e)
        {
            foreach (var item in stepTab) {
                if (item != tabPage_ImageInfo)
                    imgName += "-" + item.Name.Replace("tabPage_", "");
            }
            writeImage(this.savePath + imgName + ".bmp", 
                    ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel);

            error.Print(ErrorInfo.RUN, "保存成功", 2000);
        }
        private string RenameFile()
        {
            List<TabPage> hdl = new List<TabPage> {
                tabPage_CutImage, tabPage_Binary, 
            };

            string name = "";
            int start = sourcePath.LastIndexOf("\\") + 1;
            int len = sourcePath.LastIndexOf(".") - start;
            name = sourcePath.Substring(start, len);
            for (int i = 1; i < cb_BackUp.SelectedIndex + 1; i++) {
                if (stepTab[i] == tabPage_CutImage) {
                    name += "-cut" + nud_CutX.Value + "_" + nud_CutY.Value;
                }
                else if (stepTab[i] == tabPage_Binary) {
                    name += "-th" + nud_BinaryThres.Value;
                }
                else if (stepTab[i] == tabPage_Median) {
                    name += "-m" + nud_Median.Value;
                }
                else if (stepTab[i] == tabPage_Gaussian)
                {
                    name += "-gs" + tb_gsKer.Text;
                }
                else if (stepTab[i] == tabPage_Erode) {
                    name += "-erode" + "x" + nud_ErodeKerX.Value + "y" + nud_ErodeKerY.Value;
                }
                else if (stepTab[i] == tabPage_Dilate) {
                    name += "-dilate" + "x" + nud_DilateKerX.Value + "y" + nud_DilateKerY.Value;
                }
                else if (stepTab[i] == tabPage_EdgeDetect) {
                    if (cb_EdgeDetect.SelectedIndex == 0) {
                        name += ("-sobel" + (int.Parse(tb_Sobeldx.Text) == 0 ? "" : "x")
                                 + (int.Parse(tb_Sobeldy.Text) == 0 ? "" : "y")
                                 + tb_SobelKsize.Text);
                    }
                    else if (cb_EdgeDetect.SelectedIndex == 1) {
                        name += "-lap" + tb_LapKsize.Text;
                    }
                    else if (cb_EdgeDetect.SelectedIndex == 2) {
                        name += ("-canny" + tb_GSKsize.Text
                                + "l" + tb_LowThres.Text
                                + "h" + tb_HighThres.Text);
                    }
                }
                else {
                        name += "-" + stepTab[i].Name.Replace("tabPage_", "");
                }
            }
            //}

            return name;
        }

        #endregion


        #region 自定义事件

        private void CurImageChanged(object sender, ImageData val)
        {
            if (val != null) {
                ImageForm.tabPageBanner(new int[3] {1, 3, 4}, val.Channel == 3);
            }
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (ModifierKeys == Keys.Control)
            if (picBox.Image != null) ScaleImage(e.Delta, e.Location);
        }

        private void Table_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control != true)
                return;
            switch (e.KeyCode) {
                case Keys.V:
                    DataGridViewPaste((DataGridView)sender);
                    break;
            }
        }

        public void DataGridViewPaste(DataGridView dgv)
        {
            try {
                string pasteText = Clipboard.GetText();
                if (string.IsNullOrEmpty(pasteText))
                    return;
                // 更新表格行数
                int cRowIndex = dgv.SelectedCells[0].RowIndex;
                int cColIndex = dgv.SelectedCells[0].ColumnIndex;

                if (pasteText.IndexOf(",") != -1) {
                    string[] temp = pasteText.Trim().Split(',');
                    UpdateInputTable(dgv, temp.Length);

                    for (int i = 0; i < temp.Length; i++) {
                        dgv.Rows[cRowIndex + i / 2].Cells[cColIndex + i % 2].Value = temp[i].Trim();
                    }
                }
                else if (pasteText.IndexOf("\n") != -1) {
                    string[] temp = pasteText.Trim().Split('\n');
                    UpdateInputTable(dgv, temp.Length);

                    for (int i = 0; i < temp.Length; i++) {
                        if (temp[i].IndexOf('\t') != -1) {
                            string[] words = temp[i].Trim().Split('\t');
                            for (int j = 0; j < words.Length; j++) {
                                dgv.Rows[cRowIndex + i].Cells[cColIndex + j].Value = words[j].Trim();
                            }
                        }
                        else
                            dgv.Rows[cRowIndex + i / 2].Cells[cColIndex + i % 2].Value = temp[i].Trim();
                    }
                }
                else if (pasteText.IndexOf("\t") != -1) {
                    string[] temp = pasteText.Trim().Split('\t');
                    UpdateInputTable(dgv, temp.Length);

                    for (int i = 0; i < temp.Length; i++) {
                        dgv.Rows[cRowIndex + i / 2].Cells[cColIndex + i % 2].Value = temp[i].Trim();
                    }
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.DATA_PASTE_ERROR);
            }
        }

        public static void UpdateInputTable(DataGridView dgv, int num)
        {
            int cRowIndex = dgv.SelectedCells[0].RowIndex;
            int usableRow = dgv.Rows.Count - cRowIndex;
            int length = num / dgv.ColumnCount + 1;

            if (length > usableRow) {
                for (int i = usableRow; i < length; i++)
                    dgv.Rows.Add(0, 0);
            }
        }


        #endregion


        #region 图像信息界面事件

        private void correctBrightAndContrast(float alpha, float beta)
        {
            try {
                if (inputImage.Count > 0) {
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

                    brightnessAndContrast(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, alpha, beta);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void correctHSL(int H, int S, int L)
        {
            try { 
                if (inputImage.Count > 0 && curImage.img.Channel == 3) {
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                    adjustHSL(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, H, S, L);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void correctThreshold(float thres)
        {
            try { 
                if (inputImage.Count > 0) {
                    int[] hist = new int[256];
                    getHistogram(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, hist);
                    ImageForm.receiveHistogram(hist);

                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                    RGB2Binary(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, thres, 255, 1);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void correctContrastImage()
        {
            try { 
                if (inputImage.Count > 0) {
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                    complementaryPixel(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }
        private void GetDirectPixNum(bool isX, int pixel)
        {
            try
            {
                if (inputImage.Count > 0)
                {
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                    getDirectPixNum(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, isX, pixel);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void correctChannelCommingler(float[] red, float[] green, float[] blue, float[] constant, bool single)
        {
            try { 
                if (inputImage.Count > 0 && curImage.img.Channel == 3) {
                    if (single) {
                        int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                        byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                        RGB2GrayDefined(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, red[0], green[0], blue[0], constant[0]);

                        UpdateInputImage(88, s1, a1, b1, c1);
                        DisplayFromMemory(picBox, inputImage[88]);
                    }
                    else {
                        int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                        byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                        channelCommingler(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, 0, red[0], green[0], blue[0], constant[0]);
                        channelCommingler(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1, 1, red[1], green[1], blue[1], constant[1]);
                        channelCommingler(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1, 2, red[2], green[2], blue[2], constant[2]);

                        UpdateInputImage(88, s1, a1, b1, c1);
                        DisplayFromMemory(picBox, inputImage[88]);
                    }
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void SetHSV_Click(float hl, float h, float sl, float s, float vl, float v)
        {
            nud_LowH.Value = (decimal)hl;
            nud_HighH.Value = (decimal)h;
            nud_LowS.Value = (decimal)sl;
            nud_HighS.Value = (decimal)s;
            nud_LowV.Value = (decimal)vl;
            nud_HighV.Value = (decimal)v;
        }

        // 滑块调整HSV
        private void correctHSV(float hl, float h, float sl, float s, float vl, float v)
        {
            try { 
                if (inputImage.Count > 0 && curImage.img.Channel == 3) {
                    int m = int.Parse(nud_DilateKerX.Value.ToString());
                    int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                    byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                    saveRGBinHSV(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, hl, h, sl, s, vl, v);

                    UpdateInputImage(88, s1, a1, b1, c1);
                    DisplayFromMemory(picBox, inputImage[88]);
                }
            }
            catch (Exception) {
                error.Print(ErrorInfo.IMAGE_HANDLE_ERROR, ImageForm.curTab.Text);
            }
        }

        private void saveToInput()
        {
            UpdateImageInput();
            UpdateInputImage(1, inputImage[88]);
            UpdateOutputImage(outputImage.Count, inputImage[88]);

            int index = outputImage.Count;
            if (index > 1 && index > cb_BackUp.Items.Count) {
                stepTab.Add(tabPage_ImageInfo);
                // 图像数据处理
                cb_BackUp.Items.Add(cb_BackUp.Items.Count.ToString() + "." + tabPage_ImageInfo.Text);
                cb_BackUp.SelectedIndex = cb_BackUp.Items.Count - 1;
            }
        }

        private void backToPrimary()
        {
            UpdateCurImage(1, cb_BackUp.SelectedIndex);
        }


        #endregion


        #region 系统事件


        // 自动添加至注册表
        private void AddToRegister()
        {
            RegistryKey shell = Registry.ClassesRoot.OpenSubKey("*", true).OpenSubKey("shell", true);
            if (shell == null)
            {
                shell = Registry.ClassesRoot.OpenSubKey("directory", true).CreateSubKey("shell");
            }
            RegistryKey custome = shell.CreateSubKey("ImageTool");
            custome.SetValue("icon", Application.ExecutablePath);
            RegistryKey cmd = custome.CreateSubKey("command");
            cmd.SetValue("", Application.ExecutablePath + " %1");
            cmd.Close();
            custome.Close();
            shell.Close();
        }
        private bool QueryRegister(string name)
        {
            RegistryKey shell = Registry.ClassesRoot.OpenSubKey("*", false).OpenSubKey("shell", false);
            if (shell == null) return false;

            if (shell.GetSubKeyNames().Any(x => x == name))
            {
                return true;
            }

            shell.Close();
            return false;
        }

        private void Image_Form_Load(object sender, EventArgs e)
        {
            // 启动时加载文件
            if (picBox.Image == null && !String.IsNullOrEmpty(sourcePath))
            {
                loadImage(sourcePath);
            }
        }
        private void tssb_AddRegister_ButtonClick(object sender, EventArgs e)
        {
            try
            {
                //OperatingSystem os = Environment.OSVersion;
                //Version ver = os.Version;
                if (!QueryRegister("ImageTool"))
                    AddToRegister();
            }
            catch (Exception)
            {
                error.Print(ErrorInfo.REGISTER_ADD_FAILED);
            }
        }

        private void tssl_Error_TextChanged(object sender, EventArgs e)
        {
            if (error.Code == 0)        tssl_Error.ForeColor = Color.Green;
            else if (error.Code < 256)  tssl_Error.ForeColor = Color.Red;
            else if (error.Code < 512)  tssl_Error.ForeColor = Color.Orange;
            else if (error.Code < 768)  tssl_Error.ForeColor = Color.Blue;
        }

        private void ps_Funcs_PageSignal(object sender, EventArgs e, int type)
        {
            if (type == 0) {            // 清空提示
                error.Tip(ErrorInfo.RUN);
            }
            else if (type == 1) {       // 切换至流水线
                error.Tip(ErrorInfo.ASML_HANDLE_TIPS);
            }
        }

        private void Image_Form_SizeChanged(object sender, EventArgs e)
        {
            if (picBox.Image != null) {
                CalImageInfo(picBox.Image);
                AdaptImage();
            }
        }

        #endregion
    }
}
