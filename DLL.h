#pragma once
#include <stdio.h>
#include <math.h>
#include <stdlib.h>
#include <stdint.h>
#include <vector>
#include <iostream>
#include <algorithm>
#include <string>
#include <float.h>
#include <opencv2/opencv.hpp>  
#include <opencv2/core/core.hpp>  
#include <opencv2/highgui/highgui_c.h>
#include <opencv2/video/tracking.hpp>
#include <opencv2/imgproc/imgproc_c.h>
using namespace cv;
using namespace std;
#define IMG_PI 3.1415926

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
extern "C" _declspec(dllexport) int meanBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m, int n);
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
extern "C" _declspec(dllexport) int substract(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* subImage, int subWidth, int subHeight, int subChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int scale, bool use_abs);
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
extern "C" _declspec(dllexport) int meanPixel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* meanPixel);
extern "C" _declspec(dllexport) int findAreaColor(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int x,int y, int width,int height);
extern "C" _declspec(dllexport) int RGB2HSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* H, float* S, float* V);
extern "C" _declspec(dllexport) int RGB2GrayDefined(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float red, float green, float blue, float constant);
extern "C" _declspec(dllexport) int singleRGB2HSV(unsigned char R, unsigned char G, unsigned char B, int* H, float* S, float* V);
extern "C" _declspec(dllexport) int HSL2RGB(unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* H, float* S, float* L, int width, int height, int changeH, int changeS, int changeL);
extern "C" _declspec(dllexport) int adjustHSL(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int changeH, int changeS, int changeL);
extern "C" _declspec(dllexport) int saveRGBinHSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float lowH, float highH, float lowS, float highS, float lowV, float highV);
extern "C" _declspec(dllexport) int getDirectPixNum(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, bool isX, int pixel);
extern "C" _declspec(dllexport) int stripBackground(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* bkImage, int bkWidth, int bkHeight, int bkChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float contraThresh, int mode);
extern "C" _declspec(dllexport) int thresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, float maxval, int region);
extern "C" _declspec(dllexport) int thresholdBinaryTrunc(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh);
extern "C" _declspec(dllexport) int thresholdBinaryToZero(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, int region);
extern "C" _declspec(dllexport) int doubleThresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int thresholdBinaryOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float maxval, int region, float* thresh);
extern "C" _declspec(dllexport) int thresholdBinaryAdaptive(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float maxval, int region, int type, int ksize, int delta);
extern "C" _declspec(dllexport) int getThresholdOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, float* thres);
extern "C" _declspec(dllexport) int flip(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int XY);
extern "C" _declspec(dllexport) int resize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int newWidth,int newHeight, float scaleX,float scaleY, int interpolation);
extern "C" _declspec(dllexport) int rotate(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float clockwiseAngle, float* center);
extern "C" _declspec(dllexport) int fitLine(float* pos, int num, float* lineVector);
extern "C" _declspec(dllexport) int getHistogram(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* outHistogram);
extern "C" _declspec(dllexport) int connectedComponent(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int index, int conNums, int minConArea, int* area, int* center, int* rect);
extern "C" _declspec(dllexport) int matchTemplateCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* templateImage, int templateWidth, int templateLength, int templateChannel, float* rect, float* similarity);
extern "C" _declspec(dllexport) int matchShapesCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* tImage, int tWidth, int tLength, int tChannel, float* similarity);
extern "C" _declspec(dllexport) int sobelCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize);
extern "C" _declspec(dllexport) int sobelXYCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize);
extern "C" _declspec(dllexport) int laplacianCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize);
extern "C" _declspec(dllexport) int cannyCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int gaussianSize, int low_threshold, int high_threshold);
extern "C" _declspec(dllexport) int houghLinesPCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* lines, float rho, float theta, int threshold, float minLineLen, float maxLineGap);
extern "C" _declspec(dllexport) int drawHoughLinesCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* lines);
extern "C" _declspec(dllexport) int warpPerspectiveCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* srcPt, float *dstPt, int* size);
extern "C" _declspec(dllexport) int cvtColorCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel);
extern "C" _declspec(dllexport) int findAllContoursCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int selectSize, bool isRotated, float* centerPoint, float* rectPoint, int* conArea, int* conPointNum, int* conNum);
extern "C" _declspec(dllexport) int drawLineCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* LinePoint);
extern "C" _declspec(dllexport) int drawRectCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* RectPoint);
extern "C" _declspec(dllexport) int drawCircleCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* CirclePoint, int radius);
