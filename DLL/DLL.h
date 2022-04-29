#pragma once
#include<stdio.h>
#include<math.h>
#include<stdlib.h>
#include<stdint.h>
#include<vector>
#include<iostream>
#include<algorithm>
using namespace std;

#pragma once
struct Image
{
unsigned char* data;
int row;
int col;
int type_;
int channels_;
};

typedef struct
{
unsigned int bfSize;
unsigned short bfReserved1;
unsigned short bfReserved2;
unsigned int bfOffBits;
}BITMAPFILEHEADER2;

typedef struct
{
unsigned int biSize;
unsigned int biWidth;
unsigned int biHeight;
unsigned short biPlanes;
unsigned short biBitCount;
unsigned int biCompression;
unsigned int biSizeImage;
unsigned int biXPelsPerMeter;
unsigned int biYPelsPerMeter;
unsigned int biClrUsed;
unsigned int biClrImportant;
}BITMAPINFOHEADER2;

typedef struct
{
unsigned char rgbBlue;
unsigned char rgbGreen;
unsigned char rgbRed;
unsigned char rgbReserved;
}RGBQUAD2;
typedef struct {
Image src_;
Image dst_;
int flag_;
int m_;
int n_;
}Filter;


extern "C" _declspec(dllexport) void orbTest();
extern "C" _declspec(dllexport) void readImage(char* file, int mode, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) void writeImage(char* file, unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel);
extern "C" _declspec(dllexport) int cutImage(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* pos, int* size);
extern "C" _declspec(dllexport) int lineCross(float* LinePoint1, float* LinePoint2, float* Point2D);
extern "C" _declspec(dllexport) int regioningCenter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int center_pixel);
extern "C" _declspec(dllexport) int dilate(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int kernelX, int kernelY);
extern "C" _declspec(dllexport) int erode(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int kernelX, int kernelY);
extern "C" _declspec(dllexport) int saltNoise(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int num);
extern "C" _declspec(dllexport) int pepperNoise(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int num);
extern "C" _declspec(dllexport) int blur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m, int n);
extern "C" _declspec(dllexport) int medianBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m, int n);
extern "C" _declspec(dllexport) int gaussianBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n, float sigmaX,float sigmaY);
extern "C" _declspec(dllexport) int harmonicMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel,int m,int n);
extern "C" _declspec(dllexport) int contraHarmonicMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,float Q);
extern "C" _declspec(dllexport) int maxBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n);
extern "C" _declspec(dllexport) int minBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n);
extern "C" _declspec(dllexport) int midPointFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n);
extern "C" _declspec(dllexport) int amendedAlphaMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,int ksize);
extern "C" _declspec(dllexport) int roberts(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int sobel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize);
extern "C" _declspec(dllexport) int prewitt(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int laplacian(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize);
extern "C" _declspec(dllexport) int kirsch(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int nevitia(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int scharr(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int canny(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int gaussianSize, int low_threshold, int high_threshold);
extern "C" _declspec(dllexport) int cannyFromSobel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* srcImage2, int srcWidth2, int srcHeight2, int srcChannel2, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int low_threshold, int high_threshold);
extern "C" _declspec(dllexport) int bilateralFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize,float sigma_color,float sigma_space);
extern "C" _declspec(dllexport) int geometricMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n);
extern "C" _declspec(dllexport) int adaptiveMedianFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,int max_m,int max_n);
extern "C" _declspec(dllexport) int meanPooling(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int poolSize);
extern "C" _declspec(dllexport) int maxPooling(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int poolSize);
extern "C" _declspec(dllexport) int gammaTransform(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float gamma);
extern "C" _declspec(dllexport) int brightnessAndContrast(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float alpha, float beta);
extern "C" _declspec(dllexport) int channelCommingler(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorChn, float red, float green, float blue, float constant);
extern "C" _declspec(dllexport) int normalize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int low, int high);
extern "C" _declspec(dllexport) int equalize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int RGB2Gray(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int RGB2BGR(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int RGB2YCrCb(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int RGB2HSL(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, float* H, float* S, float* L);
extern "C" _declspec(dllexport) int RGB2Binary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, float maxval, int region);
extern "C" _declspec(dllexport) int HSV2Binary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int region, float lowH, float highH, float lowS, float highS, float lowV, float highV);
extern "C" _declspec(dllexport) int Gray2Pseudo(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorMapTypes);
extern "C" _declspec(dllexport) int Gray2Rainbow(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int Gray2Metal(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int GrayFromRGB(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorChn);
extern "C" _declspec(dllexport) int complementaryPixel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int minMaxLoc(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* minPixel, int* maxPixel);
extern "C" _declspec(dllexport) int findAreaColor(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int x,int y, int width,int height);
extern "C" _declspec(dllexport) int RGB2HSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* H, float* S, float* V);
extern "C" _declspec(dllexport) int RGB2GrayDefined(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float red, float green, float blue, float constant);
extern "C" _declspec(dllexport) int singleRGB2HSV(unsigned char R, unsigned char G, unsigned char B, int* H, float* S, float* V);
extern "C" _declspec(dllexport) int HSL2RGB(unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* H, float* S, float* L, int width, int height, int changeH, int changeS, int changeL);
extern "C" _declspec(dllexport) int adjustHSL(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int changeH, int changeS, int changeL);
extern "C" _declspec(dllexport) int saveRGBinHSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float lowH, float highH, float lowS, float highS, float lowV, float highV);
extern "C" _declspec(dllexport) int stripBackground(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* bkImage, int bkWidth, int bkHeight, int bkChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float contraThresh, int mode);
extern "C" _declspec(dllexport) int thresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, float maxval, int region);
extern "C" _declspec(dllexport) int thresholdBinaryTrunc(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh);
extern "C" _declspec(dllexport) int thresholdBinaryToZero(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, int region);
extern "C" _declspec(dllexport) int doubleThresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int thresholdBinaryOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int maxval, int region);
extern "C" _declspec(dllexport) int getThresholdOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, float* thres);
extern "C" _declspec(dllexport) int flip(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int XY);
extern "C" _declspec(dllexport) int resize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int newWidth,int newHeight, float scaleX,float scaleY, int interpolation);
extern "C" _declspec(dllexport) int rotate(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int clockwiseAngle);
extern "C" _declspec(dllexport) int fitLine(float* pos, int num, float* lineVector);
extern "C" _declspec(dllexport) int getHistogram(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* outHistogram);
extern "C" _declspec(dllexport) int matchTemplateCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* templateImage, int templateWidth, int templateLength, int templateChannel, float* rect, float* similarity);
extern "C" _declspec(dllexport) int matchShapesCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* tImage, int tWidth, int tLength, int tChannel, float* similarity);
extern "C" _declspec(dllexport) int sobelCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize);
extern "C" _declspec(dllexport) int sobelXYCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize);
extern "C" _declspec(dllexport) int laplacianCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize);
extern "C" _declspec(dllexport) int cannyCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int gaussianSize, int low_threshold, int high_threshold);
extern "C" _declspec(dllexport) int houghLinesPCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* lines, float rho, float theta, int threshold, float minLineLen, float maxLineGap);
extern "C" _declspec(dllexport) int drawHoughLinesCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* lines);
extern "C" _declspec(dllexport) int cvtColorCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int findAllContoursCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int selectSize, float* centerPoint, float* rectPoint);
extern "C" _declspec(dllexport) int drawLineCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* LinePoint);
extern "C" _declspec(dllexport) int drawRectCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* RectPoint);
extern "C" _declspec(dllexport) int drawCircleCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* CirclePoint, int radius);
extern "C" _declspec(dllexport) int iiiot_matchTemplateCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* templateImage, int templateWidth, int templateLength, int templateChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* src_corners, float* dst_corners, float dstWidth, float dstHeight);
extern "C" _declspec(dllexport) int SolvePseudoInverse(float* ImgaePointSet, float* SpacePointSet, int num, float* Trans, float* ReverseTrans);
extern "C" _declspec(dllexport) int IMG_CvPreCornerDetect(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int ksize);
extern "C" _declspec(dllexport) int IMG_CornerEigenValsAndVecs(unsigned char* imgData, int width, int height, int channel,float* dstData, int block_size, int ksize);
extern "C" _declspec(dllexport) int IMG_CornerMinEigenVal(unsigned char* imgData, int width, int height, int channel,float* dstData, int block_size, int ksize);
extern "C" _declspec(dllexport) int IMG_FindCornerSubPix(unsigned char* imgData, int width, int height, int channel, float* inData, float* dstData, int* halfWinSize, int* zone,float* criteria);
extern "C" _declspec(dllexport) int IMG_GoodFeaturesToTrack(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, float* dstData, int  max_corners,float quality_level,float min_distance, int block_size, int use_harris);
extern "C" _declspec(dllexport) int IMG_SampleLine(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel,float* pointList, int connectivity);
extern "C" _declspec(dllexport) int IMG_GetRectSubPixt(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int* rect, int* nums);
extern "C" _declspec(dllexport) int IMG_GetQuadrangleSubPix(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int* map);
extern "C" _declspec(dllexport) int IMG_AffineByMat(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* transMat);
extern "C" _declspec(dllexport) int IMG_GetRectRoatationMatrix(float* center,float angle,float scale, float* mat);
extern "C" _declspec(dllexport) int IMG_PerspectiveByMat(unsigned char*  imgData, int width, int height, int channel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel,float*  homo);
extern "C" _declspec(dllexport) int IMG_PerspectiveTrans(float* RectPoints1,float* RectPoints2,float* TransRect);
extern "C" _declspec(dllexport) int IMG_MorphologyOpen(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int kerSize1, int kerSize2);
extern "C" _declspec(dllexport) int IMG_Smooth(unsigned char*  imgData, int width, int height, int channel,	unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int smoothType, int size1, int size2, float sigma1,float sigma2);
extern "C" _declspec(dllexport) int IMG_Filter2D(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int kernel_size1, int kernel_size2,float* kernelList);
extern "C" _declspec(dllexport) int IMG_Integral(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int deepth);
extern "C" _declspec(dllexport) int IMG_PyrDown(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int IMG_PyrUp(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int IMG_PyrMeanShiftFiltering(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel,  float sp,float sr, int maxLevel);
extern "C" _declspec(dllexport) int IMG_FloodFill(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int*  seed, int*  newBGR, int*  rect, int*  loBGR, int*  upBGR, int flags);
extern "C" _declspec(dllexport) int  IMG_SpatialMoments(float*  imgData,float* spaMome);
extern "C" _declspec(dllexport) int IMG_CentralMoments(float* imgData,float*  cenMome);
extern "C" _declspec(dllexport) int IMG_MatchTemplate(unsigned char*  imgData1, int wid1, int hei1, int channel1, unsigned char*  imgData2, int wid2, int hei2, int channel2,float* result, int method);
extern "C" _declspec(dllexport) int IMG_MatchShapes(int*  inputData1, int*  inputData2, int method, float* dstData);
extern "C" _declspec(dllexport) int IMG_CalcEMD2(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, int distanceType,float* dstData);
extern "C" _declspec(dllexport) int IMG_ApproxPolyDp(float*  pts,float*  ptPoly);
extern "C" _declspec(dllexport) float IMG_ContourArea(float*  imgData);
extern "C" _declspec(dllexport) float IMG_ContourLength(float*  imgData,bool isColsed);
extern "C" _declspec(dllexport) int IMG_MergeRect(float* rect1,float* rect2,float* rect3);
extern "C" _declspec(dllexport) int IMG_BoxPoints(float* box2d,float* boxpt);
extern "C" _declspec(dllexport) int IMG_CvFitEllipse(float*  pts,float* ellip);
extern "C" _declspec(dllexport) int IMG_CvFitLine(float*  pts,float* line);
extern "C" _declspec(dllexport) int IMG_ConvexHull2(float* inputData, float* res);
extern "C" _declspec(dllexport) bool IMG_CheckContourConvexity(float* inputData);
extern "C" _declspec(dllexport) void IMG_ConvexityDefects(float* inputData, float* res);
extern "C" _declspec(dllexport) int IMG_GetMinRectPrams(float*  imgData,float* rect);
extern "C" _declspec(dllexport) int IMG_minEnclosingCircle(float* inputData, float* res);
extern "C" _declspec(dllexport) int IMG_CvAcc(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int IMG_CvSquareAcc(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int IMG_CvMultiplyAcc(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int IMG_CvRunningAvg(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel,float alpha);
