using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace ImageTool
{
    public partial class UserControl : System.Windows.Forms.UserControl
    {
        #region 函数声明
        // ---------------- 函数导入 -----------------------
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void readImage(string file, int mode, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void writeImage(string file, ref byte srcImage, int srcWidth, int srcHeight, int srcChannel);
        //start
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cutImage(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] pos, int[] size);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int HSV2Binary(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int region, float lowH, float highH, float lowS, float highS, float lowV, float highV);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void thresholdBinary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, float maxval, int region);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static void stripBackground(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte bkImage, int bkWidth, int bkHeight, int bkChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float contraThresh, int mode);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int medianBlur(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m, int n);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int dilate(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelSize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int erode(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelSize);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int lineCross(float[] LinePoint1, float[] LinePoint2, float[] Point2D);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int cvtColorCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int GrayFromRGB(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorChn);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int findAllContoursCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int selectSize, float[] centerPoint, float[] rectPoint);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawLineCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] LinePoint);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawRectCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] RectPoint);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int drawCircleCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] CirclePoint, int radius);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int matchTemplateCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte templateImage, int templateWidth, int templateLength, int templateChannel, float[] rect, float[] similarity);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int matchShapesCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte tImage, int tWidth, int tLength, int tChannel, float[] similarity);
        [DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        extern static int IMG_CvFitLine(float[] pts, float[] line);
        // 图像信息函数
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

        #endregion

        #region 全局变量
        
        public string savePath = "";
        string sourcePath = "";

        // 显示相关
        ImageStorage curImage = new ImageStorage();
        ImageStorage perCurImage = new ImageStorage();

        TabPage curTab;
        List<TabPage> stepTab = new List<TabPage>();

        // 图像信息处理界面实例化
        private ImageInfoHandle ImageForm = new ImageInfoHandle();

        // 图像数据变量
        Dictionary<int, ImageData> inputImage = new Dictionary<int, ImageData> { };
        Dictionary<int, ImageData> outputImage = new Dictionary<int, ImageData> {
            {0, ImageInfo.NewData()}
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
        ImageLine line = new ImageLine(Color.White, 1.0f);
        private Point lineStartPoint;
        private Point lineEndPoint;

        private bool startDrawFlag = false;
        private bool startLineFlag = false;
        private bool startCutFlag = false;
        private bool startCircleFlag = false;
        private int startRectFlag = -1;
        private Point[] rectPoints = new Point[4];

        #endregion

        public UserControl()
        {
            InitializeComponent();

            InitTP();

            EventBinding();
        }

        // 初始化tabControl
        private void InitTP()
        {
            stepTab.Add(tabPage_ImageInfo);

            int cnt = tabControl_Image.TabCount - 1;
            for (int i = cnt; i > 0; i--) {
                tabControl_Image.TabPages[i].Parent = null;
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
            ImageForm.correctChannelCommingler += correctChannelCommingler;
            ImageForm.updateHSVInfo += updateHSVInfo;
            ImageForm.correctHSV += correctHSV;
            ImageForm.SetHSV_Click += SetHSV_Click;
            
            ImageForm.saveToInput += saveToInput;
            ImageForm.backToPrimary += backToPrimary;
        }


        #region 数据处理

        private void EmptyInputImage()
        {
            inputImage.Clear();
            textBox_MatchTemplate.Text = "";
        }

        private void UpdateInputImage(int index, ImageData data)
        {
            inputImage[index] = data;
        }

        private void UpdateInputImage(int index, byte[] s, int[] a, int[] b, int[] c)
        {
            inputImage[index] = ImageInfo.NewData();
            inputImage[index].WriteInMemory(s, a, b, c);
        }

        private void UpdateOutputImage(int index, ImageData data)
        {
            outputImage[index] = data;
        }

        private void UpdateOutputImage(int index, byte[] s, int[] a, int[] b, int[] c)
        {
            outputImage[index] = ImageInfo.NewData();
            outputImage[index].WriteInMemory(s, a, b, c);
        }
        
        private void UpdateCurImage(int IO, int index)
        {
            perCurImage = curImage;
            curImage.IO = IO;
            curImage.index = index;
            curImage.img = IO == 0 ? inputImage[index] : outputImage[index];

            DisplayFromMemory(picBox, curImage.img);

            label_Size.Text = "宽高通道:\n" + curImage.img.Width + ", " + curImage.img.Height + ", " + curImage.img.Channel;
        }

        private void SavePicImageInMemory(PictureBox pic, string path, Dictionary<int, ImageData> image, int index)
        {
            int[] a = new int[1]; int[] b = new int[1]; int[] c = new int[1];
            int readMode = 1;
            if (Image.GetPixelFormatSize(pic.Image.PixelFormat) == 8)
                readMode = 0;
            else if (Image.GetPixelFormatSize(pic.Image.PixelFormat) == 32)
                readMode = -1;
            else
                readMode = 1;
            byte[] s = new byte[pic.Image.Width * pic.Image.Height * (readMode < 0 ? 4 : (int)Math.Pow(3, readMode))];
            readImage(path, readMode, ref s[0], a, b, c);

            image[index] = ImageInfo.NewData();
            image[index].WriteInMemory(s, a, b, c);
        }

        #endregion


        #region 图像显示处理
        
        private void loadImage(string fileName)
        {
            try {
                DisplayFromFile(picBox, fileName);

                // Save into the memory
                inputImage.Remove(1);
                SavePicImageInMemory(picBox, fileName, inputImage, 1);
                outputImage[0] = inputImage[1];
                
                // Display
                CalImageInfo(picBox.Image);
                AdaptImage();
                UpdateCurImage(0, 1);

                // Update UI Info
                if (!comboBox_BackUp.Items.Contains("原图")) {
                    comboBox_BackUp.Items.Add("原图");
                }
                comboBox_BackUp.SelectedIndex = 0;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayFromFile(PictureBox pic, string path)
        {
            FileStream pFileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            pic.Image = Image.FromStream(pFileStream);
            pFileStream.Close();
            pFileStream.Dispose();
        }

        private void DisplayFromMemory(PictureBox pic, ImageData data)
        {
            Bitmap bmp = ValueHelper.ToBitmap(data.Data, data.Width, data.Height, data.Channel);
            pic.Image = bmp;
            CalImageInfo(bmp);
            AdaptImage();
        }

        private void TabPageDisplay(TabPage tab)
        {
            if (curTab != null && curTab != tabPage_ImageInfo) curTab.Parent = null;
            curTab = tab;
            curTab.Parent = tabControl_Image;
            tabControl_Image.SelectedTab = curTab;
        }

        #endregion


        #region 功能块部分的控件事件

        private void rbImage_CheckedChanged(object sender, EventArgs e)
        {
            if (rbImage.Checked) {
                panel_Image.BringToFront();
                rbGraph.Checked = false;
            }
        }

        private void rbGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (rbGraph.Checked) {
                panel_Graph.BringToFront();
                rbImage.Checked = false;
            }
        }

        private void cutImage_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_CutImage);
            this.label_func.Text = "剪切图片";
        }

        private void button_FilterColor_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_HSV2Binary);
            this.label_func.Text = "过滤颜色";
        }

        private void Filter_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_Median);
            this.label_func.Text = "中值滤波";
        }

        private void button_FindContours_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_FindContours);
            this.label_func.Text = "找轮廓";
        }

        private void Dilate_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_Dilate);
            this.label_func.Text = "膨胀";
        }

        private void Erode_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_Erode);
            this.label_func.Text = "腐蚀";
        }


        private void button_DrawLine_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_DrawLine);
            this.label_func.Text = "画线";

            if (Grid_Line.RowCount < 2) {
                Grid_Line.Rows.Clear();
                Grid_Line.Rows.Add(0, 0);
                Grid_Line.Rows[0].HeaderCell.Value = (1).ToString();
                Grid_Line.Rows.Add(0, 0);
                Grid_Line.Rows[1].HeaderCell.Value = (2).ToString();
            }
        }
        private void button_DrawRect_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_DrawRect);
            this.label_func.Text = "画矩形";

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
        }

        private void button_DrawCircle_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_DrawCircle);
            this.label_func.Text = "画圆";

            if (Grid_Circle.RowCount < 1) {
                Grid_Circle.Rows.Clear();
                Grid_Circle.Rows.Add(100, 100, 88);
                Grid_Circle.Rows[0].HeaderCell.Value = "1";
            }
        }

        private void LineCross_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_LineCross);
            this.label_func.Text = "两条直线交点";

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
        }
        private void button_MatchTemp_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_MatchTemp);
            this.label_func.Text = "模板匹配";

            cbxMatch.SelectedIndex = 0;
        }

        private void button_FitLine_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_fitLine);
            label_func.Text = "直线拟合";

            if (dataGridView_FitLine.RowCount == 0) {
                dataGridView_FitLine.Rows.Clear();
                dataGridView_FitLine.Rows.Add(0, 0);
                dataGridView_FitLine.Rows[0].HeaderCell.Value = (1).ToString();
            }
        }
        
        private void button_Gray_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_Gray);
            label_func.Text = "转灰度";

            cb_GrayChannel.SelectedIndex = 0;
        }

        private void button_Binary_Click(object sender, EventArgs e)
        {
            TabPageDisplay(tabPage_Binary);
            label_func.Text = "二值化";
        }

        // 特殊功能块函数封装（绘制功能）
        private void DrawLine_Complex(float[] pos)
        {
            int[] color = new int[3];
            color[0] = int.Parse(nud_LineR.Value.ToString());
            color[1] = int.Parse(nud_LineG.Value.ToString());
            color[2] = int.Parse(nud_LineB.Value.ToString());
            int thickness = int.Parse(nud_LineThick.Value.ToString());

            int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
            byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

            drawLineCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos);

            UpdateOutputImage(outputImage.Count, s1, a1, b1, c1);
        }

        private void DrawCircle_Complex(float[] pos, int radius)
        {
            int[] color = new int[3];
            color[0] = int.Parse(nud_CircleR.Value.ToString());
            color[1] = int.Parse(nud_CircleG.Value.ToString());
            color[2] = int.Parse(nud_CircleB.Value.ToString());
            int thickness = int.Parse(nud_CircleThick.Value.ToString());

            int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
            byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

            drawCircleCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos, radius);

            UpdateOutputImage(outputImage.Count, s1, a1, b1, c1);
        }

        private void DrawRect_Complex(float[] pos)
        {
            int[] color = new int[3];
            color[0] = int.Parse(nud_RectR.Value.ToString());
            color[1] = int.Parse(nud_RectG.Value.ToString());
            color[2] = int.Parse(nud_RectB.Value.ToString());
            int thickness = int.Parse(nud_RectThick.Value.ToString());
            int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
            byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

            drawRectCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, color, thickness, pos);

            UpdateOutputImage(outputImage.Count, s1, a1, b1, c1);
        }


        #endregion


        #region 操作部分的控件事件

        // 加载图片
        private void LoadImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            sourcePath = file.FileName;
            loadImage(file.FileName);
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            try {
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
                    int Region = (int)nud_ColorSel.Value;
                    float LowH = (float)nud_LowH.Value;
                    float HighH = (float)nud_HighH.Value;
                    float LowS = (float)nud_LowS.Value;
                    float HighS = (float)nud_HighS.Value;
                    float LowV = (float)nud_LowV.Value;
                    float HighV = (float)nud_HighV.Value;

                    HSV2Binary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Region, LowH, HighH, LowS, HighS, LowV, HighV);
                }
                else if (curTab == tabPage_Median) {
                    int M = (int)nud_Median.Value;
                    int N = (int)nud_Median.Value;
                    
                    medianBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, M, N);
                }
                else if (curTab == tabPage_FindContours) {
                    //findAllContours
                    int Size = int.Parse(nud_selectSize.Value.ToString());
                    float[] Center = new float[3];
                    float[] Rect = new float[9];

                    findAllContoursCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Size, Center, Rect);

                    textBox_centerPoint.Text = string.Join(",", Center);
                    textBox_rectPoint.Text = string.Join(",", Rect);
                }
                else if (curTab == tabPage_Gray) {
                    int method = cb_GrayChannel.SelectedIndex;

                    if (method == 0)
                        cvtColorCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1);
                    else
                        GrayFromRGB(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, method - 1);
                }
                else if (curTab == tabPage_Binary) {
                    float Threshold = float.Parse(nud_BinaryThres.Value.ToString());
                    float MaxVal = float.Parse(nud_MaxPixelVal.Value.ToString());
                    int Region = int.Parse(nud_BinarySel.Value.ToString());

                    thresholdBinary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, Threshold, MaxVal, Region);
                }
                else if (curTab == tabPage_Dilate) {
                    int kSize = int.Parse(nud_DilateKernel.Value.ToString());
                    
                    dilate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, kSize);
                }
                else if (curTab == tabPage_Erode) {
                    int kSize = int.Parse(nud_ErodeKernel.Value.ToString());
                    
                    erode(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, kSize);
                }
                else if (curTab == tabPage_DrawLine) {
                    float[] pos = new float[5];//drawLine
                    for (int i = 0; i < 4; i++) {
                        pos[i + 1] = float.Parse(Grid_Line.Rows[i / 2].Cells[i % 2].Value.ToString());
                    }
                    DrawLine_Complex(pos);
                }
                else if (curTab == tabPage_DrawRect) {
                    float[] pos = new float[9];//drawRect
                    for (int i = 0; i < 8; i++) {
                        pos[i + 1] = float.Parse(Grid_Rect.Rows[i / 2].Cells[i % 2].Value.ToString());
                    }
                    DrawRect_Complex(pos);
                }
                else if (curTab == tabPage_DrawCircle) {
                    float[] pos = new float[3];//drawCircle
                    for (int i = 0; i < 2; i++) {
                        pos[i + 1] = float.Parse(Grid_Circle.Rows[i / 2].Cells[i % 2].Value.ToString());
                    }
                    int radius = int.Parse(Grid_Circle.Rows[0].Cells[2].Value.ToString());
                    DrawCircle_Complex(pos, radius);
                }
                else if (curTab == tabPage_MatchTemp) {
                    float[] similarity = new float[3];

                    if (cbxMatch.SelectedIndex == 0) {
                        float[] rect = new float[12];
                        matchTemplateCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, rect, similarity);
                        drawRectCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref s1[0], a1, b1, c1, 
                                    new int[3] {0,0,255}, 2, new float[9] {0, rect[0], rect[1], rect[2], rect[1], rect[2], rect[3], rect[0], rect[3]});
                        drawRectCV(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1, 
                                    new int[3] {0,255,0}, 2, new float[9] {0, rect[4], rect[5], rect[6], rect[5], rect[6], rect[7], rect[4], rect[7]});
                        drawRectCV(ref s1[0], a1[0], b1[0], c1[0], ref s1[0], a1, b1, c1,
                                    new int[3] {255,0,0}, 2, new float[9] {0, rect[8], rect[9], rect[10], rect[9], rect[10], rect[11], rect[8], rect[11]});
                        lbSimilarity.Text = String.Format("{0:f6}, {1:f6}, {2:f6}", similarity[0], similarity[1], similarity[2]);
                    }
                    else {
                        matchShapesCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, similarity);
                        MessageBox.Show(similarity[0].ToString());
                    }
                }
                
                UpdateOutputImage(outputImage.Count, s1, a1, b1, c1);
                UpdateImageOutput();

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateImageInput()
        {
            // 清除内存中多余的输出存储，更新输入
            if (comboBox_BackUp.Items.Count > 0) {
                int curIndex = comboBox_BackUp.SelectedIndex;
                for (int i = outputImage.Count - 1; i > curIndex; i--) {
                    outputImage.Remove(i);
                    comboBox_BackUp.Items.RemoveAt(i);
                }
                stepTab.RemoveRange(curIndex+1, stepTab.Count - curIndex-1);
                UpdateInputImage(1, outputImage[curIndex]);
            }
        }

        private void UpdateImageOutput()
        {
            int index = outputImage.Count;

            if (index > 1 && index > comboBox_BackUp.Items.Count) {
                stepTab.Add(curTab);
                // 图像数据处理
                comboBox_BackUp.Items.Add(comboBox_BackUp.Items.Count.ToString() + "." + curTab.Text);
                comboBox_BackUp.SelectedIndex = comboBox_BackUp.Items.Count - 1;
            }
        }

        // 显示图像回退至选择位置
        private void comboBox_BackUp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_BackUp.Items.Count > 1) {
                int index = comboBox_BackUp.SelectedIndex;
                UpdateCurImage(1, index);
                TabPageDisplay(stepTab[index]);
            }
        }

        // 显示图像回退一次
        private void button_backOnce_Click(object sender, EventArgs e)
        {
            if (comboBox_BackUp.SelectedIndex > 0) {
                comboBox_BackUp.SelectedIndex = curImage.index - 1;
            }
        }

        #endregion


        #region 输入参数部分的事件

        // 打开图像信息处理窗口
        private void button_ImgaeHandleForm_Click(object sender, EventArgs e)
        {
            if (inputImage.Count > 0) {
                ImageForm.Show();
                ImageForm.Location = PointToScreen(new Point(Location.X + 896, Location.Y));
            }
        }

        // 手动画矩形启动
        private void DrawRect_Click(object sender, EventArgs e)
        {
            // 初始化画笔
            line.PenSize = float.Parse(nud_RectThick.Value.ToString());
            int b = int.Parse(nud_RectB.Value.ToString());
            int g = int.Parse(nud_RectG.Value.ToString());
            int r = int.Parse(nud_RectR.Value.ToString());
            line.PenColor = Color.FromArgb(b, g, r);

            // 启动标志置位
            Cursor = Cursors.Cross;
            startRectFlag = 0;
            dragFlag = false;
        }

        // 手动截取启动
        private void DrawCutRect_Click(object sender, EventArgs e)
        {
            // 初始化画笔
            line.PenSize = 1;
            line.PenColor = Color.White;

            // 启动标志置位
            Cursor = Cursors.Cross;
            startCutFlag = true;
            dragFlag = false;
        }

        // 手动画圆启动
        private void DrawEllipse_Click(object sender, EventArgs e)
        {
            // 初始化画笔
            line.PenSize = float.Parse(nud_CircleThick.Value.ToString());
            int b = int.Parse(nud_CircleB.Value.ToString());
            int g = int.Parse(nud_CircleG.Value.ToString());
            int r = int.Parse(nud_CircleR.Value.ToString());
            line.PenColor = Color.FromArgb(b, g, r);

            // 启动标志置位
            Cursor = Cursors.Cross;
            startCircleFlag = true;
            dragFlag = false;
        }

        // 手动画线启动
        private void DrawLine_Click(object sender, EventArgs e)
        {
            // 初始化画笔
            line.PenSize = float.Parse(nud_LineThick.Value.ToString());
            int b = int.Parse(nud_LineB.Value.ToString());
            int g = int.Parse(nud_LineG.Value.ToString());
            int r = int.Parse(nud_LineR.Value.ToString());
            line.PenColor = Color.FromArgb(b, g, r);

            // 启动标志置位
            Cursor = Cursors.Cross;
            startLineFlag = true;
            dragFlag = false;
        }
        
        // 模板匹配载入模板图片
        private void button_MatchTemplate_Click(object sender, EventArgs e)
        {
            // Choose Image
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            try {
                // Display
                textBox_MatchTemplate.Text = file.FileName;
                DisplayFromFile(pbTemplate, textBox_MatchTemplate.Text);

                // Save into the memory
                SavePicImageInMemory(picBox, file.FileName, inputImage, 2);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 导出HSV参数
        private void button_export_Click(object sender, EventArgs e)
        {
            string dir = sourcePath.Remove(sourcePath.LastIndexOf("\\") + 1);
            int Region = (int)nud_ColorSel.Value;
            float LowH = (float)nud_LowH.Value;
            float HighH = (float)nud_HighH.Value;
            float LowS = (float)nud_LowS.Value;
            float HighS = (float)nud_HighS.Value;
            float LowV = (float)nud_LowV.Value;
            float HighV = (float)nud_HighV.Value;

            FileStream file = new FileStream(dir + "HSV.txt", FileMode.OpenOrCreate | FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ffff") +"    "+ sourcePath);
            sw.WriteLine("--fillColor: " + (Region == 1 ? "1-white" : "0-black"));
            sw.WriteLine("--H: " + LowH + " - " + HighH);
            sw.WriteLine("--S: " + LowS + " - " + HighS);
            sw.WriteLine("--V: " + LowV + " - " + HighV + "\n");
            sw.Close();
            file.Close();
        }
        
        #endregion


        #region 图像部分的事件
        
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
        
        private void pictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (picBox.Image != null && startDrawFlag) {
                if (startLineFlag)
                    line.DrawLine(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startCircleFlag)
                    line.DrawCircle(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startCutFlag)
                    line.DrawCut(e.Graphics, lineStartPoint, lineEndPoint);

                else if (startRectFlag > 0 && startRectFlag < 4) {
                    for (int i = 1; i < startRectFlag; i++) {
                        line.DrawLine(e.Graphics, rectPoints[i - 1], rectPoints[i]);
                    }
                    line.DrawLine(e.Graphics, lineStartPoint, lineEndPoint);
                }
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            Point start = WidgetToPixelPoint(lineStartPoint);
            Point end = WidgetToPixelPoint(lineEndPoint);

            if (dragFlag) {
                dragFlag = false;
            }
            else if (startLineFlag) {
                startLineFlag = false;
                UpdateImageInput();

                float[] pos = { 0, start.X, start.Y, end.X, end.Y };
                DrawLine_Complex(pos);

                for (int i = 0; i < 4; i++) {
                    Grid_Line.Rows[i / 2].Cells[i % 2].Value = pos[i + 1];
                }
                line.DrawClear(picBox.CreateGraphics());
                UpdateImageOutput();
            }
            else if (startCircleFlag) {
                startCircleFlag = false;
                UpdateImageInput();

                float[] pos = { 0, start.X, start.Y };
                int radius = (int)Math.Pow(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2), 0.5);
                DrawCircle_Complex(pos, radius);

                Grid_Circle.Rows[0].Cells[0].Value = pos[1];
                Grid_Circle.Rows[0].Cells[1].Value = pos[2];
                Grid_Circle.Rows[0].Cells[2].Value = radius;
                line.DrawClear(picBox.CreateGraphics());
                UpdateImageOutput();
            }
            else if (startCutFlag) {
                startCutFlag = false;
                // 剪切框只把截图位置信息更新到输入框中
                nud_CutW.Value = (end.X - start.X) > 0 ? end.X - start.X : start.X - end.X;
                nud_CutH.Value = (end.Y - start.Y) > 0 ? end.Y - start.Y : start.Y - end.Y;
                nud_CutX.Value = (end.X - start.X) > 0 ? start.X : end.X;
                nud_CutY.Value = (end.Y - start.Y) > 0 ? start.Y : end.Y;
            }
            else if (startRectFlag != -1) {
                lineStartPoint = lineEndPoint;
                startRectFlag++;
                if (startRectFlag == 4) {
                    startRectFlag = -1;
                    UpdateImageInput();

                    float[] pos = new float[9];
                    for (int i = 0; i < 4; i++) {
                        Point img = WidgetToPixelPoint(rectPoints[i]);
                        pos[i*2+1] = img.X;
                        pos[i*2+2] = img.Y;
                    }
                    DrawRect_Complex(pos);

                    Grid_Rect.Rows[3].Cells[0].Value = pos[7];
                    Grid_Rect.Rows[3].Cells[1].Value = pos[8];
                    line.DrawClear(picBox.CreateGraphics());
                    UpdateImageOutput();
                }
                else {
                    Point img = WidgetToPixelPoint(rectPoints[startRectFlag - 1]);
                    Grid_Rect.Rows[startRectFlag - 1].Cells[0].Value = img.X;
                    Grid_Rect.Rows[startRectFlag - 1].Cells[1].Value = img.Y;
                    return;
                }
            }

            startDrawFlag = false;
            Cursor = Cursors.Default;
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(picBox.Image != null) {
                if (startDrawFlag) {
                    lineEndPoint = e.Location;
                    picBox.Invalidate();
                }
                else if (dragFlag) {
                    picBox.Location = ImageLocControl( new Point (
                        picBox.Left + e.X - dragStart.X,
                        picBox.Top + e.Y - dragStart.Y ));
                }

                // 更新右下角坐标、RGB数据和HSV数据
                Point mouse = WidgetToPixelPoint(e.Location);

                if (mouse.X < picBox.Image.Width && mouse.Y < picBox.Image.Height) {
                    label_MousePos.Text = "坐标:\n" + mouse.X + ", " + mouse.Y;

                    Color rgb = new Bitmap(picBox.Image).GetPixel(mouse.X, mouse.Y);
                    label_MouseRGB.Text = "RGB:\n" + rgb.R + ", " + rgb.G + ", " + rgb.B;

                    int h = 0; float s = 0, v = 0;
                    ValueHelper.RGB2HSV(rgb.R, rgb.G, rgb.B, ref h, ref s, ref v);
                    label_MouseHSV.Text = "HSV:\n" + h.ToString() + ", " +
                        String.Format("{0:f2}", s) + ", " + String.Format("{0:f2}", v);
                }
            }
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                if (startLineFlag || startCutFlag || startCircleFlag) {
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
        
        private void pictureBox_SizeChanged(object sender, EventArgs e)
        {
            CalImageInfo(picBox.Image);
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
        private Point PixelToWidgetPoint(Point p)
        {
            return new Point(
                    Convert.ToInt32(p.X * imageScale), Convert.ToInt32(p.Y * imageScale));
        }
        
        // 切换功能块图像复原
        private void tabControl_Image_SelectedIndexChanged(object sender, EventArgs e)
        {
            //AdaptImage();
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
                    Convert.ToInt32(picBox.Height * tmp) );
                tmp -= 1;
                picBox.Location = ImageLocControl( new Point(
                    picBox.Left - Convert.ToInt32(fixedP.X * tmp),
                    picBox.Top - Convert.ToInt32(fixedP.Y * tmp) ));
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
            SaveFileDialog folder = new SaveFileDialog();
            folder.Filter = "BMP文件|*.bmp*|JPEG文件|*.jpg*|PNG文件|*.png*";
            if (folder.ShowDialog() == DialogResult.OK) {
                ImageFormat format = null;
                string suffix = "";
                if (folder.FilterIndex == 1) {
                    format = ImageFormat.Bmp;
                    suffix = ".bmp";
                }
                else if (folder.FilterIndex == 2) {
                    format = ImageFormat.Jpeg;
                    suffix = ".jpg";
                }
                else if (folder.FilterIndex == 3) {
                    format = ImageFormat.Png;
                    suffix = ".png";
                }
                writeImage(folder.FileName + suffix, ref curImage.img.Data[0],
                    curImage.img.Width, curImage.img.Height, curImage.img.Channel);
                //Bitmap bmp = new Bitmap(this.picBox.Image);
                //bmp.Save(folder.FileName + suffix, format);

                string temp = this.label_func.Text;
                label_func.Text = "保存成功";
                SmallFunction.Delay(1000);
                label_func.Text = temp;
            }
        }
        private void cmsItem_Save_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(this.picBox.Image);
            DirectoryInfo dir = new DirectoryInfo(savePath);
            int cnt = dir.GetFiles().Length;
            writeImage(this.savePath + "/temp" + cnt.ToString() + ".bmp", ref curImage.img.Data[0],
                    curImage.img.Width, curImage.img.Height, curImage.img.Channel);
            //bmp.Save(this.savePath + "/temp" + cnt.ToString() + ".bmp", ImageFormat.Bmp);

            string temp = this.label_func.Text;
            this.label_func.Text = "保存成功";
            SmallFunction.Delay(1000);
            this.label_func.Text = temp;
        }

        #endregion


        #region 自定义事件

        private void CurImageChanged(object sender, EventArgs e)
        {
            //CalImageInfo(picBox.Image);
        }

        private void pictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            //if (ModifierKeys == Keys.Control)
            if (picBox.Image != null)   ScaleImage(e.Delta, e.Location);    
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

        public static void DataGridViewPaste(DataGridView dgv)
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
                        if(temp[i].IndexOf('\t') != -1) {
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
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
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
            if (inputImage.Count > 0) {
                int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                byte[] s1 = new byte[inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

                brightnessAndContrast(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, alpha, beta);

                UpdateInputImage(88, s1, a1, b1, c1);
                DisplayFromMemory(picBox, inputImage[88]);
            }
        }

        private void correctHSL(int H, int S, int L)
        {
            if (inputImage.Count > 0) {
                int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                adjustHSL(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, H, S, L);

                UpdateInputImage(88, s1, a1, b1, c1);
                DisplayFromMemory(picBox, inputImage[88]);
            }
        }

        private void correctThreshold(float thres)
        {
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

        private void correctContrastImage()
        {
            if (inputImage.Count > 0) {
                int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                complementaryPixel(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1);

                UpdateInputImage(88, s1, a1, b1, c1);
                DisplayFromMemory(picBox, inputImage[88]);
            }
        }

        private void correctChannelCommingler(float[] red, float[] green, float[] blue, float[] constant, bool single)
        {
            if (inputImage.Count > 0) {
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

        // 更新HSV信息
        private void updateHSVInfo(float lowH, float highH, float lowS, float highS, float lowV, float highV)
        {
            label_RangeHSV.Text = "H: " + (int)(lowH / 360 * 255) + " - " + (int)(highH / 360 * 255)
                                + "   " + (int)(lowH) + " - " + (int)(highH)
                                + "\nS: " + (int)(lowS * 255) + " - " + (int)(highS * 255)
                                + "   " + String.Format("{0:f2}", lowS) + " - " + String.Format("{0:f2}", highS)
                                + "\nV: " + (int)(lowV * 255) + " - " + (int)(highV * 255)
                                + "   " + String.Format("{0:f2}", lowV) + " - " + String.Format("{0:f2}", highV);
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
            if (inputImage.Count > 0) {
                int m = int.Parse(nud_DilateKernel.Value.ToString());
                int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
                byte[] s1 = new byte[curImage.img.Width * curImage.img.Height * curImage.img.Channel];

                saveRGBinHSV(ref curImage.img.Data[0], curImage.img.Width, curImage.img.Height, curImage.img.Channel, ref s1[0], a1, b1, c1, hl, h, sl, s, vl, v);

                UpdateInputImage(88, s1, a1, b1, c1);
                DisplayFromMemory(picBox, inputImage[88]);
            }
        }

        private void saveToInput()
        {
            UpdateImageInput();
            UpdateInputImage(1, inputImage[88]);
            UpdateOutputImage(outputImage.Count, inputImage[88]);

            int index = outputImage.Count;
            if (index > 1 && index > comboBox_BackUp.Items.Count) {
                stepTab.Add(tabPage_ImageInfo);
                // 图像数据处理
                comboBox_BackUp.Items.Add(comboBox_BackUp.Items.Count.ToString() +"."+ tabPage_ImageInfo.Text);
                comboBox_BackUp.SelectedIndex = comboBox_BackUp.Items.Count - 1;
            }
        }

        private void backToPrimary()
        {
            UpdateCurImage(1, comboBox_BackUp.SelectedIndex);
        }


        #endregion

    }
}
