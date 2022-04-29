[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static void readImage(string file, int mode, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static void writeImage(string file, ref byte srcImage, int srcWidth, int srcHeight, int srcChannel);
//start
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int cutImage(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] pos, int[] size);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int lineCross(float[] LinePoint1, float[] LinePoint2, float[] Point2D);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int regioningCenter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int center_pixel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int dilate(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelSize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int erode(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int kernelSize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int saltNoise(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int num);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int pepperNoise(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int num);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int blur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m, int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int medianBlur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m, int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int gaussianBlur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n, float sigmaX,float sigmaY);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int harmonicMeanFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel,int m,int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int contraHarmonicMeanFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n,float Q);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int maxBlur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int minBlur(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int midPointFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int amendedAlphaMeanFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n,int ksize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int roberts(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int sobel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int sobelx(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int sobely(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int prewitt(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int laplacian(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int kirsch(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int nevitia(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int scharr(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int cannyFull(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int gaussianSize, int low_threshold, int high_threshold);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int canny(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte srcImage2, int srcWidth2, int srcHeight2, int srcChannel2, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int low_threshold, int high_threshold);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int bilateralFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int ksize,float sigma_color,float sigma_space);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int geometricMeanFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int adaptiveMedianFilter(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int m,int n,int max_m,int max_n);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int meanPooling(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int poolSize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int maxPooling(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int poolSize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int gammaTransform(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float gamma);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int brightnessAndContrast(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float alpha, float beta);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int channelCommingler(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorChn, float red, float green, float blue, float constant);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int normalize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int low, int high);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int equalize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2Gray(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2BGR(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2YCrCb(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2HSL(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, float[] H, float[] S, float[] L);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2Binary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, float maxval, int region);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int HSV2Binary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int region, float lowH, float highH, float lowS, float highS, float lowV, float highV);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int Gray2Pseudo(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorMapTypes);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int Gray2Rainbow(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int Gray2Metal(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int GrayFromRGB(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int colorChn);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int complementaryPixel(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int minMaxLoc(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] minPixel, int[] maxPixel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int findAreaColor(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int x,int y, int width,int height);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2HSV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] H, float[] S, float[] V);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int RGB2GrayDefined(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float red, float green, float blue, float constant);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int singleRGB2HSV(byte R, byte G, byte B, int[] H, float[] S, float[] V);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int HSL2RGB(ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float[] H, float[] S, float[] L, int width, int height, int changeH, int changeS, int changeL);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int adjustHSL(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int changeH, int changeS, int changeL);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int saveRGBinHSV(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float lowH, float highH, float lowS, float highS, float lowV, float highV);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int stripBackground(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte bkImage, int bkWidth, int bkHeight, int bkChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float contraThresh, int mode);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int thresholdBinary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, float maxval, int region);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int thresholdBinaryTrunc(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int thresholdBinaryToZero(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float thresh, int region);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int doubleThresholdBinary(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int thresholdBinaryOTSU(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int maxval, int region);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int getThresholdOTSU(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, float[] thres);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int flip(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int XY);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int resize(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int newWidth,int newHeight, float scaleX,float scaleY, int interpolation);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int rotate(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int clockwiseAngle);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int fitLine(float[] pos, int num, float[] lineVector);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int getHistogram(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, int[] outHistogram);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int matchTemplateCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte templateImage, int templateWidth, int templateLength, int templateChannel, float[] rect, float[] similarity);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int matchShapesCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte tImage, int tWidth, int tLength, int tChannel, float[] similarity);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int cvtColorCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int findAllContoursCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int selectSize, float[] centerPoint, float[] rectPoint);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int drawLineCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] LinePoint);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int drawRectCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] RectPoint);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int drawCircleCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, int[] color, int thickness, float[] CirclePoint, int radius);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int iiiot_matchTemplateCV(ref byte srcImage, int srcWidth, int srcLength, int srcChannel, ref byte templateImage, int templateWidth, int templateLength, int templateChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float[] src_corners, float[] dst_corners, float dstWidth, float dstHeight);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int SolvePseudoInverse(float[] ImgaePointSet, float[] SpacePointSet, int num, float[] Trans, float[] ReverseTrans);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvPreCornerDetect(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel, int ksize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CornerEigenValsAndVecs(ref byte imgData, int width, int height, int channel,float[] dstData, int block_size, int ksize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CornerMinEigenVal(ref byte imgData, int width, int height, int channel,float[] dstData, int block_size, int ksize);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_FindCornerSubPix(ref byte imgData, int width, int height, int channel, float[] inData, float[] dstData, int[] halfWinSize, int[] zone,float[] criteria);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_GoodFeaturesToTrack(ref byte imgData1, int width1, int height1, int channel1, ref byte imgData2, int width2, int height2, int channel2, float[] dstData, int  max_corners,float quality_level,float min_distance, int block_size, int use_harris);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_SampleLine(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel,float[] pointList, int connectivity);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_GetRectSubPixt(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel, int[] rect, int[] nums);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_GetQuadrangleSubPix(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel, int[] map);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_AffineByMat(ref byte srcImage, int srcWidth, int srcHeight, int srcChannel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel, float[] transMat);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_GetRectRoatationMatrix(float[] center,float angle,float scale, float[] mat);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_PerspectiveByMat(ref byte  imgData, int width, int height, int channel, ref byte outImage, int[] outWidth, int[] outHeight, int[] outChannel,float[]  homo);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_PerspectiveTrans(float[] RectPoints1,float[] RectPoints2,float[] TransRect);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_MorphologyOpen(ref byte  imgData, int width, int height, int channel, ref byte  dstData, int[] outWidth, int[] outHeight, int[] outChannel, int kerSize1, int kerSize2);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_Smooth(ref byte  imgData, int width, int height, int channel,	ref byte  dstData, int[] outWidth, int[] outHeight, int[] outChannel, int smoothType, int size1, int size2, float sigma1,float sigma2);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_Filter2D(ref byte  imgData, int width, int height, int channel, ref byte  dstData, int[] outWidth, int[] outHeight, int[] outChannel, int kernel_size1, int kernel_size2,float[] kernelList);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_Integral(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel, int deepth);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_PyrDown(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_PyrUp(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_PyrMeanShiftFiltering(ref byte  imgData, int width, int height, int channel, ref byte  dstData, int[] outWidth, int[] outHeight, int[] outChannel,  float sp,float sr, int maxLevel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_FloodFill(ref byte  imgData, int width, int height, int channel, ref byte  dstData, int[] outWidth, int[] outHeight, int[] outChannel, int[]  seed, int[]  newBGR, int[]  rect, int[]  loBGR, int[]  upBGR, int flags);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int  IMG_SpatialMoments(float[]  imgData,float[] spaMome);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CentralMoments(float[] imgData,float[]  cenMome);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_MatchTemplate(ref byte  imgData1, int wid1, int hei1, int channel1, ref byte  imgData2, int wid2, int hei2, int channel2,float[] result, int method);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_MatchShapes(int[]  inputData1, int[]  inputData2, int method, float[] dstData);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CalcEMD2(ref byte imgData1, int width1, int height1, int channel1, ref byte imgData2, int width2, int height2, int channel2, int distanceType,float[] dstData);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_ApproxPolyDp(float[]  pts,float[]  ptPoly);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static float IMG_ContourArea(float[]  imgData);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static float IMG_ContourLength(float[]  imgData,bool isColsed);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_MergeRect(float[] rect1,float[] rect2,float[] rect3);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_BoxPoints(float[] box2d,float[] boxpt);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvFitEllipse(float[]  pts,float[] ellip);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvFitLine(float[]  pts,float[] line);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_ConvexHull2(float[] inputData, float[] res);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static bool IMG_CheckContourConvexity(float[] inputData);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static void IMG_ConvexityDefects(float[] inputData, float[] res);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_GetMinRectPrams(float[]  imgData,float[] rect);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_minEnclosingCircle(float[] inputData, float[] res);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvAcc(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvSquareAcc(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvMultiplyAcc(ref byte imgData1, int width1, int height1, int channel1, ref byte imgData2, int width2, int height2, int channel2, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel);
[DllImport("DLL.dll", CallingConvention = CallingConvention.Cdecl)]
extern static int IMG_CvRunningAvg(ref byte imgData, int width, int height, int channel, ref byte dstData, int[] outWidth, int[] outHeight, int[] outChannel,float alpha);
else if (label_func.Text == "cutImage")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new int[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = int.Parse(src2[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		cutImage(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "lineCross")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		lineCross(para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "regioningCenter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		regioningCenter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "dilate")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		dilate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "erode")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		erode(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "saltNoise")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		saltNoise(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "pepperNoise")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		pepperNoise(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "blur")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		blur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "medianBlur")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		medianBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "gaussianBlur")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		gaussianBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "harmonicMeanFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		harmonicMeanFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "contraHarmonicMeanFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		contraHarmonicMeanFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "maxBlur")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		maxBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "minBlur")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		minBlur(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "midPointFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		midPointFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "amendedAlphaMeanFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		amendedAlphaMeanFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "roberts")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		roberts(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "sobel")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		sobel(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "sobelx")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		sobelx(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "sobely")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		sobely(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "prewitt")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		prewitt(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "laplacian")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		laplacian(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "kirsch")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		kirsch(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "nevitia")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		nevitia(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "scharr")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		scharr(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "cannyFull")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		cannyFull(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "canny")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		canny(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "bilateralFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		bilateralFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "geometricMeanFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		geometricMeanFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "adaptiveMedianFilter")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int para4 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		adaptiveMedianFilter(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "meanPooling")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		meanPooling(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "maxPooling")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		maxPooling(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "gammaTransform")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		gammaTransform(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "brightnessAndContrast")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		brightnessAndContrast(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "channelCommingler")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		float para5 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		channelCommingler(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "normalize")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		normalize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "equalize")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		equalize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2Gray")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		RGB2Gray(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2BGR")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		RGB2BGR(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2YCrCb")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		RGB2YCrCb(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2HSL")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		RGB2HSL(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2Binary")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		RGB2Binary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "HSV2Binary")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		float para5 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		float para6 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());
		float para7 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 15).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		HSV2Binary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5, para6, para7);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "Gray2Pseudo")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		Gray2Pseudo(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "Gray2Rainbow")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		Gray2Rainbow(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "Gray2Metal")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		Gray2Metal(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "GrayFromRGB")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		GrayFromRGB(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "complementaryPixel")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		complementaryPixel(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "minMaxLoc")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new int[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = int.Parse(src2[j].Trim());


		minMaxLoc(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "findAreaColor")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int para4 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		findAreaColor(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2HSV")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		RGB2HSV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "RGB2GrayDefined")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		RGB2GrayDefined(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "singleRGB2HSV")
{
	try {
		byte para1 = byte.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text.Trim());
		byte para2 = byte.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text.Trim());
		byte para3 = byte.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text.Trim());
		int[] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new int[length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = int.Parse(src4[j].Trim());

		float[] para5;
		int length5 = 0;
		string text5 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length5 = Regex.Matches(text5, ",", RegexOptions.Compiled).Count + 1;
		if (length5 == 1)
			length5 = int.Parse(text5);
		para5 = new float[length5];
		string[] src5 = text5.Split(new char[] { ',' });
		for (int j = 0; j < src5.Length; j++)
			para5[j] = float.Parse(src5[j].Trim());

		float[] para6;
		int length6 = 0;
		string text6 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length6 = Regex.Matches(text6, ",", RegexOptions.Compiled).Count + 1;
		if (length6 == 1)
			length6 = int.Parse(text6);
		para6 = new float[length6];
		string[] src6 = text6.Split(new char[] { ',' });
		for (int j = 0; j < src6.Length; j++)
			para6[j] = float.Parse(src6[j].Trim());


		singleRGB2HSV(para1, para2, para3, para4, para5, para6);

		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text = paraOut4.Substring(0, paraOut4.Length - 1);
		string paraOut5 = "";
		for (int j = 0; j < para5.Length; j++)
			paraOut5 += para5[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut5.Substring(0, paraOut5.Length - 1);
		string paraOut6 = "";
		for (int j = 0; j < para6.Length; j++)
			paraOut6 += para6[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut6.Substring(0, paraOut6.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "HSL2RGB")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int para4 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 8).Text.Trim());
		int para5 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para6 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para7 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int para8 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		HSL2RGB(ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5, para6, para7, para8);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "adjustHSL")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		adjustHSL(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "saveRGBinHSV")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		float para5 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		float para6 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		saveRGBinHSV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5, para6);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "stripBackground")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		stripBackground(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "thresholdBinary")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		thresholdBinary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "thresholdBinaryTrunc")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		thresholdBinaryTrunc(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "thresholdBinaryToZero")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		thresholdBinaryToZero(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "doubleThresholdBinary")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		doubleThresholdBinary(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "thresholdBinaryOTSU")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		thresholdBinaryOTSU(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "getThresholdOTSU")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());


		getThresholdOTSU(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "flip")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		flip(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "resize")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int para5 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		resize(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "rotate")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		rotate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "fitLine")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text.Trim());
		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		fitLine(para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "getHistogram")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());


		getHistogram(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "matchTemplateCV")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		matchTemplateCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "matchShapesCV")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());


		matchShapesCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, para1);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "cvtColorCV")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		cvtColorCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "findAllContoursCV")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		findAllContoursCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "drawLineCV")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		drawLineCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "drawRectCV")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		drawRectCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "drawCircleCV")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int para4 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		drawCircleCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "iiiot_matchTemplateCV")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 15).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 16).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		iiiot_matchTemplateCV(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "SolvePseudoInverse")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text.Trim());
		float[] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new float[length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = float.Parse(src4[j].Trim());

		float[] para5;
		int length5 = 0;
		string text5 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length5 = Regex.Matches(text5, ",", RegexOptions.Compiled).Count + 1;
		if (length5 == 1)
			length5 = int.Parse(text5);
		para5 = new float[length5];
		string[] src5 = text5.Split(new char[] { ',' });
		for (int j = 0; j < src5.Length; j++)
			para5[j] = float.Parse(src5[j].Trim());


		SolvePseudoInverse(para1, para2, para3, para4, para5);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text = paraOut4.Substring(0, paraOut4.Length - 1);
		string paraOut5 = "";
		for (int j = 0; j < para5.Length; j++)
			paraOut5 += para5[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut5.Substring(0, paraOut5.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvPreCornerDetect")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_CvPreCornerDetect(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CornerEigenValsAndVecs")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text.Trim());

		IMG_CornerEigenValsAndVecs(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CornerMinEigenVal")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text.Trim());

		IMG_CornerMinEigenVal(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_FindCornerSubPix")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		int[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new int[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = int.Parse(src3[j].Trim());

		int[] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 8).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new int[length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = int.Parse(src4[j].Trim());

		float[] para5;
		int length5 = 0;
		string text5 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length5 = Regex.Matches(text5, ",", RegexOptions.Compiled).Count + 1;
		if (length5 == 1)
			length5 = int.Parse(text5);
		para5 = new float[length5];
		string[] src5 = text5.Split(new char[] { ',' });
		for (int j = 0; j < src5.Length; j++)
			para5[j] = float.Parse(src5[j].Trim());


		IMG_FindCornerSubPix(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel, para1, para2, para3, para4, para5);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 5).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 6).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 7).Text = paraOut3.Substring(0, paraOut3.Length - 1);
		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 8).Text = paraOut4.Substring(0, paraOut4.Length - 1);
		string paraOut5 = "";
		for (int j = 0; j < para5.Length; j++)
			paraOut5 += para5[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut5.Substring(0, paraOut5.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_GoodFeaturesToTrack")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int  para2 = int .Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		int para5 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int para6 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());

		IMG_GoodFeaturesToTrack(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, para1, para2, para3, para4, para5, para6);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_SampleLine")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_SampleLine(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_GetRectSubPixt")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new int[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = int.Parse(src2[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_GetRectSubPixt(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_GetQuadrangleSubPix")
{
	try {
		int[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int.Parse(src1[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_GetQuadrangleSubPix(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_AffineByMat")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_AffineByMat(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_GetRectRoatationMatrix")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text.Trim());
		float para3 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text.Trim());
		float[] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new float[length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = float.Parse(src4[j].Trim());


		IMG_GetRectRoatationMatrix(para1, para2, para3, para4);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text = paraOut4.Substring(0, paraOut4.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_PerspectiveByMat")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_PerspectiveByMat(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_PerspectiveTrans")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		IMG_PerspectiveTrans(para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_MorphologyOpen")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_MorphologyOpen(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_Smooth")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		float para4 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text.Trim());
		float para5 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_Smooth(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_Filter2D")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());

		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_Filter2D(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_Integral")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_Integral(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_PyrDown")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_PyrDown(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_PyrUp")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_PyrUp(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_PyrMeanShiftFiltering")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float para2 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());
		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_PyrMeanShiftFiltering(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_FloodFill")
{
	try {
		int [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int .Parse(src1[j].Trim());

		int [] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new int [length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = int .Parse(src2[j].Trim());

		int [] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new int [length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = int .Parse(src3[j].Trim());

		int [] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new int [length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = int .Parse(src4[j].Trim());

		int [] para5;
		int length5 = 0;
		string text5 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text;
		length5 = Regex.Matches(text5, ",", RegexOptions.Compiled).Count + 1;
		if (length5 == 1)
			length5 = int.Parse(text5);
		para5 = new int [length5];
		string[] src5 = text5.Split(new char[] { ',' });
		for (int j = 0; j < src5.Length; j++)
			para5[j] = int .Parse(src5[j].Trim());

		int para6 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 14).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_FloodFill(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1, para2, para3, para4, para5, para6);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 11).Text = paraOut3.Substring(0, paraOut3.Length - 1);
		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 12).Text = paraOut4.Substring(0, paraOut4.Length - 1);
		string paraOut5 = "";
		for (int j = 0; j < para5.Length; j++)
			paraOut5 += para5[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 13).Text = paraOut5.Substring(0, paraOut5.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == " IMG_SpatialMoments")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		 IMG_SpatialMoments(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CentralMoments")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float [] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float [length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float .Parse(src2[j].Trim());


		IMG_CentralMoments(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_MatchTemplate")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		int para2 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text.Trim());

		IMG_MatchTemplate(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_MatchShapes")
{
	try {
		int [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new int [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = int .Parse(src1[j].Trim());

		int [] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new int [length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = int .Parse(src2[j].Trim());

		int para3 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text.Trim());
		float[] para4;
		int length4 = 0;
		string text4 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text;
		length4 = Regex.Matches(text4, ",", RegexOptions.Compiled).Count + 1;
		if (length4 == 1)
			length4 = int.Parse(text4);
		para4 = new float[length4];
		string[] src4 = text4.Split(new char[] { ',' });
		for (int j = 0; j < src4.Length; j++)
			para4[j] = float.Parse(src4[j].Trim());


		IMG_MatchShapes(para1, para2, para3, para4);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut4 = "";
		for (int j = 0; j < para4.Length; j++)
			paraOut4 += para4[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 4).Text = paraOut4.Substring(0, paraOut4.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CalcEMD2")
{
	try {
		int para1 = int.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_CalcEMD2(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel, para1, para2);

		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 10).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_ApproxPolyDp")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		float [] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float [length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float .Parse(src2[j].Trim());


		IMG_ApproxPolyDp(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_ContourArea")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());


		IMG_ContourArea(para1);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_ContourLength")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		bool para2 = bool.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text.Trim());

		IMG_ContourLength(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_MergeRect")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());

		float[] para3;
		int length3 = 0;
		string text3 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text;
		length3 = Regex.Matches(text3, ",", RegexOptions.Compiled).Count + 1;
		if (length3 == 1)
			length3 = int.Parse(text3);
		para3 = new float[length3];
		string[] src3 = text3.Split(new char[] { ',' });
		for (int j = 0; j < src3.Length; j++)
			para3[j] = float.Parse(src3[j].Trim());


		IMG_MergeRect(para1, para2, para3);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
		string paraOut3 = "";
		for (int j = 0; j < para3.Length; j++)
			paraOut3 += para3[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 3).Text = paraOut3.Substring(0, paraOut3.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_BoxPoints")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_BoxPoints(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvFitEllipse")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_CvFitEllipse(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvFitLine")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_CvFitLine(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_ConvexHull2")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_ConvexHull2(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CheckContourConvexity")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());


		IMG_CheckContourConvexity(para1);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_ConvexityDefects")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_ConvexityDefects(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_GetMinRectPrams")
{
	try {
		float [] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float [length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float .Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_GetMinRectPrams(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_minEnclosingCircle")
{
	try {
		float[] para1;
		int length1 = 0;
		string text1 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text;
		length1 = Regex.Matches(text1, ",", RegexOptions.Compiled).Count + 1;
		if (length1 == 1)
			length1 = int.Parse(text1);
		para1 = new float[length1];
		string[] src1 = text1.Split(new char[] { ',' });
		for (int j = 0; j < src1.Length; j++)
			para1[j] = float.Parse(src1[j].Trim());

		float[] para2;
		int length2 = 0;
		string text2 = ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text;
		length2 = Regex.Matches(text2, ",", RegexOptions.Compiled).Count + 1;
		if (length2 == 1)
			length2 = int.Parse(text2);
		para2 = new float[length2];
		string[] src2 = text2.Split(new char[] { ',' });
		for (int j = 0; j < src2.Length; j++)
			para2[j] = float.Parse(src2[j].Trim());


		IMG_minEnclosingCircle(para1, para2);

		string paraOut1 = "";
		for (int j = 0; j < para1.Length; j++)
			paraOut1 += para1[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 1).Text = paraOut1.Substring(0, paraOut1.Length - 1);
		string paraOut2 = "";
		for (int j = 0; j < para2.Length; j++)
			paraOut2 += para2[j].ToString() + ",";
		ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 2).Text = paraOut2.Substring(0, paraOut2.Length - 1);
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvAcc")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_CvAcc(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvSquareAcc")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_CvSquareAcc(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvMultiplyAcc")
{
	try {
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_CvMultiplyAcc(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref inputImage[2].Data[0], inputImage[2].Width, inputImage[2].Height, inputImage[2].Channel,ref s1[0], a1, b1, c1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
else if (label_func.Text == "IMG_CvRunningAvg")
{
	try {
		float para1 = float.Parse(ControlHelper.GetSpecifiedTextBox(tabPage_Auto, 9).Text.Trim());
		int[] a1 = new int[1]; int[] b1 = new int[1]; int[] c1 = new int[1];
		byte[] s1 = new byte[4*inputImage[1].Width * inputImage[1].Height * inputImage[1].Channel];

		IMG_CvRunningAvg(ref inputImage[1].Data[0], inputImage[1].Width, inputImage[1].Height, inputImage[1].Channel,ref s1[0], a1, b1, c1, para1);

		outputImage.Add(outputImage.Count, ImageInfo.NewData());
		outputImage[outputImage.Count - 1].WriteInMemory(s1, a1, b1, c1);
		// Update UI Info
		for (int j = 0; j < 10; j++) {
			Label lbl = ControlHelper.GetSpecifiedLabel(tabPage_Auto, j + 1);
			if (lbl.Text.IndexOf("ref") == 0 && (lbl.Text.IndexOf("out") != -1 || lbl.Text.IndexOf("dst") != -1))
				outputImage[outputImage.Count - 1].UpdateInfo(tabPage_Auto, j + 1);
		}
	}
	catch (Exception ex) {
		MessageBox.Show(ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
	}
}
