#include"DLL.h"
#include<stdio.h>
#include<math.h>
#include<stdlib.h>
#include<stdint.h>
#include<vector>
#include<iostream>
#include<algorithm>
#include<string>
#include<float.h>
#include <opencv2/opencv.hpp>  
#include <opencv2/core/core.hpp>  
#include <opencv2/highgui/highgui_c.h>
#include <opencv2/video/tracking.hpp>
#include <opencv2/imgproc/imgproc_c.h>
using namespace cv;
using namespace std;
#define IMG_PI 3.1415926

//start
//

void orbTest(){
	ORB::create();
}

void readImage(char* file, int mode, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	Mat img = imread(file, mode);
	memcpy(outImage, img.data, img.cols*img.rows*img.elemSize());
	*outWidth = img.cols;
	*outHeight = img.rows;
	*outChannel = img.channels();;
}

void writeImage(char* file, unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel){
	Mat src;
	if(srcChannel == 1){
		src.create(srcHeight, srcWidth, CV_8UC1);
	}else if(srcChannel == 3){
		src.create(srcHeight, srcWidth, CV_8UC3);
	}else if(srcChannel == 4){
		src.create(srcHeight, srcWidth, CV_8UC4);
	}
	memcpy(src.data,srcImage,srcWidth*srcHeight*srcChannel);
	imwrite(file, src);
}

/***************************** source code *************************************/
/***************************** source code *************************************/
/***************************** source code *************************************/

int cutImage(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* pos, int* size) {
		
	int x = pos[0];
	int y = pos[1];
	int row_ = size[1];
	int col_ = size[0];

	if (x<0 || x>srcWidth || y<0 || y>srcHeight || (col_ + x) > srcWidth || (row_ + y) > srcHeight) {
		return 0;
	}

	unsigned char* dstData = (unsigned char*)malloc(row_*col_*srcChannel);
	for (int i = 0; i < row_; i++) {
		for (int j = 0; j < col_; j++) {
			for (int c = 0; c < srcChannel; c++) {
				dstData[i*  col_*   srcChannel + j*  srcChannel + c] = srcImage[(i + y)*  srcWidth*  srcChannel + (j + x)*  srcChannel + c];
			}
		}
	}
	memcpy(outImage, dstData, row_*col_*srcChannel);

	*outChannel = srcChannel;
	*outHeight = row_;
	*outWidth = col_;

	return 1;
}

int lineCross(float* LinePoint1, float* LinePoint2, float* Point2D) {
	float x1, y1, x2, y2, x3, y3, x4, y4;
	x1 = LinePoint1[0];
	y1 = LinePoint1[1];
	x2 = LinePoint1[2];
	y2 = LinePoint1[3];

	x3 = LinePoint2[0];
	y3 = LinePoint2[1];
	x4 = LinePoint2[2];
	y4 = LinePoint2[3];
	float a1, a2;
	if (fabs(x1 - x2) < 0.001) {
		if (fabs(x3 - x4) < 0.0001) {
			return 0;
		}
		else {
			a2 = (y4 - y3) / (x4 - x3);
			Point2D[0] = (float)x1;
			Point2D[1] = (float)(a2*   (x1 - x3) + y3);
		}
	}
	else {
		if (fabs(x3 - x4) < 0.0001) {
			if (fabs(x1 - x2) < 0.0001) {
				return 0;
			}
			else {
				a1 = (y2 - y1) / (x2 - x1);
				Point2D[0] = (float)x3;
				Point2D[1] = (float)(a1*   (x3 - x1) + y1);
			}
		}
		else {
			a1 = (y2 - y1) / (x2 - x1);
			a2 = (y4 - y3) / (x4 - x3);
			if (fabs(a1 - a2) < 0.0001) {
				return 0;
			}
			else {
				Point2D[0] = (a1*  x1 - a2*  x3 + y3 - y1) / (a1 - a2);
				Point2D[1] = a1*  (Point2D[0] - x1) + y1;
			}
		}
	}
	return 1;
}

int regioningCenter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int center_pixel){

	int row = srcHeight;
    int col = srcWidth;
    int sum = 0, sumx = 0, sumy = 0;
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col; ++j) {
	        sum += srcImage[i * col + j];		//1. 求出整张图片的像素总值
	        sumx += j * srcImage[i * col + j];	//2. 求出x乘上像素的总值
	        sumy += i * srcImage[i * col + j];	//3. 求出y乘上像素的总值
        }
    }

    ////2. 通过公式，得到区域重心的x，y坐标
    int center_x = sumx / sum + 0.5;
    int center_y = sumy / sum + 0.5;

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight);

    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col; ++j) {
        	dstData[i * col + j] = srcImage[i * col + j];
        }
    }

    ////3. 在这个坐标的3*3邻域填充上给定的像素值
    dstData[(center_y - 1) * col + (center_x - 1)] = center_pixel;
    dstData[(center_y - 1) * col + (center_x)] = center_pixel;
    dstData[(center_y - 1) * col + (center_x + 1)] = center_pixel;
    dstData[(center_y)* col + (center_x - 1)] = center_pixel;
    dstData[(center_y)* col + (center_x)] = center_pixel;
    dstData[(center_y)* col + (center_x + 1)] = center_pixel;
    dstData[(center_y + 1) * col + (center_x - 1)] = center_pixel;
    dstData[(center_y + 1) * col + (center_x)] = center_pixel;
    dstData[(center_y + 1) * col + (center_x + 1)] = center_pixel;

	memcpy(outImage, dstData, srcWidth*srcHeight);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(dstData);
    dstData = NULL;
	return 1;
}

int dilate(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int kernelX, int kernelY) {

	int m = kernelY;
	int n = kernelX;

	int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
		        int max = 0;
		        for (int ic = 0; ic < num; ++ic)
		        	if (max < a[ic])
		        		max = a[ic];

		        int value = max;
		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

int erode(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int kernelX, int kernelY) {

	int m = kernelY;
	int n = kernelX;

	int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
		        int min = 256;
		        for (int ic = 0; ic < num; ++ic)
		        	if (min > a[ic])
		        		min = a[ic];

		        int value = min;
		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

// Filter  27

int saltNoise(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int num){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			for(int c = 0; c < srcChannel; c ++){
				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
			}
		}
	}

	int x, y;
	for (int i = 0; i < num / 2; i++)
	{
		x = rand() % srcWidth;
		y = rand() % srcHeight;
		for(int c = 0; c < srcChannel; c ++){
			dstData[x * srcWidth * srcChannel + y * srcChannel + c] = 255;
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(dstData);
	dstData = NULL;
	return 1;
}

int pepperNoise(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int num){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			for(int c = 0; c < srcChannel; c ++){
				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
			}
		}
	}

	int x, y;
	for (int i = 0; i < num / 2; i++)
	{
		x = rand() % srcWidth;
		y = rand() % srcHeight;
		for(int c = 0; c < srcChannel; c ++){
			dstData[x * srcWidth * srcChannel + y * srcChannel + c] = 0;
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(dstData);
	dstData = NULL;
	return 1;
}

int blur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m, int n){

    double** kernel = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        kernel[i]=(double*)malloc(sizeof(double)*n);
    }

    for (int i = 0; i < m; i++) {
        for (int j = 0; j < n; ++j) {
        	kernel[i][j] = 1.0 / (m * n);
        }
    }

    double** temp = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        temp[i] = (double*)malloc(sizeof(double)*n);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temp[i][j] = kernel[m - i - 1][n - j - 1];
        }
    }

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    double** newData = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }

    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c=0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth *  srcChannel + (j - n / 2) * srcChannel + c];
			}
        	
        }
    }

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel; c++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += temp[k][l] * newData[k + i][(l + j) * srcChannel + c];
			        }
		        }
		        if (sum > 255) {
		        	dstData[num] = 255;
		        }
		        else if (sum < 0) {
		        	dstData[num] = 0;
		        }
		        else {
		        	dstData[num] = sum;
		        }
		        num++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    for (int i = 0; i < m; ++i) {
        free(temp[i]);
    }
    free(temp);
    temp = NULL; 
	free(dstData);
    dstData = NULL; 
	return 1;    
}

int medianBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m, int n) {

	int row = srcHeight + m / 2*  2;
	int col = srcWidth + n / 2*  2;

	int** newData = (int**)malloc(sizeof(int*)*row);
	for (int i = 0; i < row; i++)
		newData[i] = (int*)malloc(sizeof(int)*col*  srcChannel);

	for (int i = 0; i < row; ++i) {
		for (int j = 0; j < col*  srcChannel; ++j) {
			newData[i][j] = 0;
		}
	}

	for (int i = m / 2; i < row - m / 2; ++i) {
		for (int j = n / 2; j < col - n / 2; ++j) {
			for (int c = 0; c < srcChannel; c++) {
				newData[i][j*  srcChannel + c] = srcImage[(i - m / 2)*  srcWidth*  srcChannel + (j - n / 2)*  srcChannel + c];
			}

		}
	}

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	int flag = 0;

	int* a = (int*)malloc(m * n * sizeof(int));
	for (int i = 0; i < row - m + 1; ++i) {
		for (int j = 0; j < col - n + 1; ++j) {

			for (int c = 0; c < srcChannel; c++) {

				int num = 0;
				for (int k = i; k < m + i; ++k) {
					for (int l = j; l < n + j; ++l) {
						a[num] = newData[k][l*  srcChannel + c];
						num++;
					}
				}

				int nums = m*  n;
				for (int i = 0; i < nums; ++i) {
					for (int j = i + 1; j < nums; ++j) {
						if (a[i] > a[j]) {
							int temp = a[i];
							a[i] = a[j];
							a[j] = temp;
						}
					}
				}
				int value = a[nums / 2];

				if (value < 0) {
					value = 0;
				}
				else if (value > 255) {
					value = 255;
				}

				dstData[flag] = value;
				flag++;
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	if (a != NULL) {
		free(a);
		a = NULL;
	}
	if (dstData != NULL) {
		free(dstData);
		dstData = NULL;
	}
	for (int i = 0; i < row; ++i) {
		free(newData[i]);
	}
	free(newData);
	newData = NULL;
	return 1;
}

int gaussianBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n, float sigmaX,float sigmaY){
	
    if (sigmaX == 0) {
        sigmaX = 0.3 * ((m - 1) * 0.5 - 1) + 0.8;
    }
    if (sigmaY == 0) {
        sigmaY = sigmaX;
    }
    double** kernel = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        kernel[i] = (double*)malloc(sizeof(double)*n);
    }
    double sum = 0;

    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
	        int x = i - m / 2;
	        int y = j - n / 2;
			double g = exp((x*x + y*y) * -1.0 / (2 * sigmaX*sigmaY));
			sum += g;
        	kernel[i][j] = g;
        }
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
    		kernel[i][j] = kernel[i][j] * 1.0 / sum;
        }
    }

    double** temps = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        temps[i] = (double*)malloc(sizeof(double)*n);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temps[i][j] = kernel[m - i - 1][n - j - 1];
        }
    }

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;
    double** newData = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }

    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j =n / 2; j < col - n / 2; ++j) {
        	for(int c=0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        	
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c=0;c<srcChannel;c++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += temps[k][l] * newData[k + i][(l + j) * srcChannel + c];
			        }
		        }
		        if (sum > 255) {
		        	dstData[num] = 255;
		        }
		        else if (sum < 0) {
		        	dstData[num] = 0;
		        }
		        else {
		        	dstData[num] = sum;
		        }
		        num++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    for (int i = 0; i < m; ++i) {
        free(temps[i]);
    }
    free(temps);
    temps = NULL;
    for (int i = 0; i < m; ++i) {
        free(kernel[i]);
    }
    free(kernel);
    kernel = NULL;
    free(dstData);
    dstData = NULL;

	return 1;
}

int harmonicMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel,int m,int n){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    //将原始的数据填充进去
    for (int i =m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel;c ++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];//m*n范围中像素的和 
				        num_++;
			        }
		        }
		        int num = m * n;
		        double re = 0;
		        for (int ic = 0; ic < num; ++ic) {
		        	double temp = 1.0 / a[ic];
		        	re += temp;
		        }
		        int value = num / re;
		        if (value < 0) {
		        	value = 0;
		        }
		        else if (value > 255) {
		        	value = 255;
		        }
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(a);
    a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    free(dstData);
    dstData = NULL;
    return 1;
}

int contraHarmonicMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,float Q){

	int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel;c ++ ){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2)*srcChannel + c];
			}
        }
    }
    
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a=(int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c < srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int value = 0;
		        int num = m * n;
		        double re1 = 0;
		        double re2 = 0;
		        for (int ic = 0; ic < num; ++ic) {
			        double temp1 = pow(a[ic], Q);
			        double temp2 = temp1 * a[ic];
			        re1 += temp1;
			        re2 += temp2;
		        }
		        if (re1 == 0)
		        	value = a[num / 2];
		        else
		        	value = re2 / re1 + 0.5;

		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;

		        dstData[flag] = value;
		        flag++;
			} 
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(a);
    a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    free(dstData);
    dstData = NULL;
	return 1;
}

int maxBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
		        int max = 0;
		        for (int ic = 0; ic < num; ++ic)
		        	if (max < a[ic])
		        		max = a[ic];

		        int value = max;
		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

int minBlur(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
		        int min = 256;
		        for (int ic = 0; ic < num; ++ic)
		        	if (min > a[ic])
		        		min = a[ic];

		        int value = min;
		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

int midPointFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
				int max = 0;
		        for (int ic = 0; ic < num; ++ic)
		        	if (max < a[ic])
		        		max = a[ic];
		        int min = 256;
		        for (int ic = 0; ic < num; ++ic)
		        	if (min > a[ic])
		        		min = a[ic];

		        int value = (min + max) / 2;
		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

int amendedAlphaMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,int ksize){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0;c<srcChannel;c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel + c];
				        num_++;
			        }
		        }
		        int num = m * n;
				
				for (int ic = 0; ic < num; ++ic) {
			        for (int jc = ic + 1; jc < num; ++jc) {
				        if (a[ic] > a[jc]) {
					        int temp = a[ic];
					        a[ic] = a[jc];
					        a[jc] = temp;
				        }
			        }
		        }
		
		        for (int ic = 0; ic < ksize / 2; ++ic) {
		        	a[ic] = 0;
		        }
		        for (int ic = num - 1; ic > num - ksize / 2 - 1; --ic) {
		        	a[ic] = 0;
		        }
		        int re = 0;
		        for (int ic = 0; ic < num; ++ic) {
		        	re += a[ic];
		        }
		        int value = re / (num - ksize);

		        if (value < 0)
		        	value = 0;
		        else if (value > 255)
		        	value = 255;
		
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(a);
	a = NULL;
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData =  NULL;
    free(dstData);
	dstData =  NULL;
    return 1;
}

int roberts(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

    int m = 2, n = 2;
	double **kernel_x = (double**)malloc(sizeof(double*) * m);
    for (int i = 0; i < m; ++i) {
        kernel_x[i] = (double*)malloc(sizeof(double) * n);
    }
    kernel_x[0][0] = 1; kernel_x[0][1] = 0;
    kernel_x[1][0] = 0; kernel_x[1][1] = -1;

	double **kernel_y = (double**)malloc(sizeof(double*) * m);
    for (int i = 0; i < m; ++i) {
        kernel_y[i] = (double*)malloc(sizeof(double) * n);
    }
    kernel_y[0][0] = 0; kernel_y[0][1] = -1;
    kernel_y[1][0] = 1; kernel_y[1][1] = 0;

	int row = srcHeight + m/2;
    int col = srcWidth + n/2;

    //空间初始化
    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col*srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = 0; i < row - m/2; ++i) {
        for (int j = 0; j < col - n/2; ++j) {
        	for(int c = 0; c < srcChannel; c++)
				newData[i][j * srcChannel + c] = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
        }
    }
    
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    for (int i = 0; i < row - m/2; ++i) {
        for (int j = 0; j < col - n/2; ++j) {
			for(int c = 0; c < srcChannel; c++) {
				int sum_x = 0, sum_y = 0;
				for (int k = i; k < i + m; ++k) {
					for (int l = j; l < j + n; ++l) {
						sum_x += kernel_x[k - i][l - j] * newData[k][l * srcChannel + c];
						sum_y += kernel_y[k - i][l - j] * newData[k][l * srcChannel + c];
					}
				}
				dstData[flag] = sqrt(sum_x*sum_x + sum_y*sum_y);
				flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	for (int i = 0; i < m; ++i) {
        free(kernel_x[i]);
    }
    free(kernel_x);
	for (int i = 0; i < m; ++i) {
        free(kernel_y[i]);
    }
    free(kernel_y);
    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	free(dstData);
	return 1;
}
//-
int sobel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize){

	// ksize是否使用scharr卷积核
	bool use_scharr = ksize == -1;
	int _ksize = ksize == -1 ? 3 : ksize;
	// 是否使用全方向卷积
	bool use_allDirect = dx == dy;
	int _dx = dx == dy ? dx : dx;
	int _dy = dx == dy ? 0 : dy;

	int m = _ksize, n = _ksize;
    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

	float* kx = (float*)malloc(sizeof(float) * _ksize);
	float* ky = (float*)malloc(sizeof(float) * _ksize);
	float* kerI = (float*)malloc(sizeof(float) * (_ksize+1));

	float* temp = (float*)malloc(sizeof(float) * col * srcChannel);
	unsigned char* dstData = (unsigned char*)malloc(srcWidth * srcHeight * srcChannel);
	float* _temp = (float*)malloc(sizeof(float) * col * srcChannel);
	unsigned char* _dstData = (unsigned char*)malloc(srcWidth * srcHeight * srcChannel);

	// 计算行、列卷积核
	for( int k = 0; k < 2; k++ )  {
        float* kernel = k == 0 ? kx : ky;
        int order = k == 0 ? _dx : _dy;

        if( _ksize == 1 )
            kerI[0] = 1;
        else if( !use_scharr && _ksize == 3 ) {
            if( order == 0 )
                kerI[0] = 1, kerI[1] = 2, kerI[2] = 1;
            else if( order == 1 )
                kerI[0] = -1, kerI[1] = 0, kerI[2] = 1;
            else
                kerI[0] = 1, kerI[1] = -2, kerI[2] = 1;
        }
		else if (use_scharr) {
			if( order == 0 )
				kerI[0] = 3, kerI[1] = 10, kerI[2] = 3;
			else if( order == 1 )
				kerI[0] = -1, kerI[1] = 0, kerI[2] = 1;
		}
        else {
            int oldval, newval;
            kerI[0] = 1;
            for(int i = 0; i < _ksize; i++ )
                kerI[i+1] = 0;

            for(int i = 0; i < _ksize - order - 1; i++ ) {
                oldval = kerI[0];
                for(int j = 1; j <= _ksize; j++ ) {
                    newval = kerI[j] + kerI[j-1];
                    kerI[j-1] = oldval;
                    oldval = newval;
                }
            }
            for(int i = 0; i < order; i++ ) {
                oldval = -kerI[0];
                for(int j = 1; j <= _ksize; j++ ) {
                    newval = kerI[j-1] - kerI[j];
                    kerI[j-1] = oldval;
                    oldval = newval;
                }
            }
        }
		for (int i = 0; i < _ksize; i++) {
			kernel[i] = kerI[i];
		}
    }

    //空间初始化
    float** newData = (float**)malloc(sizeof(float*) * row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (float*)malloc(sizeof(float) * col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c ++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        }
    }
        
    // 卷积
    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
		for (int j = 0; j < col; ++j) {
	        for(int c = 0; c < srcChannel; c ++){
	        	temp[j * srcChannel + c] = 0;
		        for (int k = 0; k < n; ++k) {
			        temp[j * srcChannel + c] += ky[k] * newData[k + i][j * srcChannel + c];
		        }
				if (use_allDirect) {
					_temp[j * srcChannel + c] = 0;
					for (int k = 0; k < n; ++k) {
						_temp[j * srcChannel + c] += kx[k] * newData[k + i][j * srcChannel + c];
					}
				}
			}
        }
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel; c ++){
	        	float sum = 0;
		        for (int k = 0; k < m; ++k) {
			        sum += kx[k] * temp[(k + j) * srcChannel + c];
		        }
		        //边缘处理
		        if (sum > 255) 
		        	dstData[num] = 255;
		        else if (sum < 0) 
		        	dstData[num] = 0;
		        else 
		        	dstData[num] = static_cast<unsigned char>(sum);

				if (use_allDirect) {
					sum = 0;
					for (int k = 0; k < m; ++k) {
						sum += ky[k] * _temp[(k + j) * srcChannel + c];
					}
					//边缘处理
					if (sum > 255) 
						_dstData[num] = 255;
					else if (sum < 0) 
						_dstData[num] = 0;
					else 
						_dstData[num] = static_cast<unsigned char>(sum);
				}
		        num++;
			}
        }
    }

	if (use_allDirect) {
		int row_ = srcHeight;
		int col_ = srcWidth * srcChannel;
		for (int i = 0; i < row_; ++i) {
			for (int j = 0; j < col_; j++) {
				if (dstData[i * col_ + j] + _dstData[i * col_ + j] > 255) {
					dstData[i * col_ + j] = 255;
				}
				else if (dstData[i * col_ + j] + _dstData[i * col_ + j] < 0) {
					dstData[i * col_ + j] = 0;
				}
				else {
					dstData[i * col_ + j] = dstData[i * col_ + j] + _dstData[i * col_ + j];
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    free(kx);
    free(ky);
    free(kerI);
    free(temp);
    free(dstData);
    free(_temp);
    free(_dstData);

	return 1;
}

int prewitt(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	
	double** kernel = (double**)malloc(sizeof(double*)*3);//3*3
    for (int i = 0; i < 3; ++i) {
        kernel[i] = (double*)malloc(sizeof(double) * 3);
    }
    kernel[0][0] = -1; kernel[0][1] = -1; kernel[0][2] = -1;	
    kernel[1][0] = 0; kernel[1][1] = 0; kernel[1][2] = 0;		
    kernel[2][0] = 1; kernel[2][1] = 1; kernel[2][2] = 1;		

    int m = 3, n = 3;
    double** temp = (double**)malloc(sizeof(double*) * 3);
    for (int i = 0; i < m; ++i) {
        temp[i] = (double*)malloc(sizeof(double) * 3);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temp[i][j] = kernel[m - i - 1][n - j - 1];
        }
    }

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    double** newData = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c ++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        }
    }
    
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
    
    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel; c ++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += temp[k][l] * newData[k + i][(l + j) * srcChannel + c];
			        }
		        }
		        //边缘处理
		        if (sum > 255) {
		        	dstData[num] = 255;
		        }
		        else if (sum < 0) {
		        	dstData[num] = 0;
		        }
		        else {
		        	dstData[num] = sum;
		        }
		        num++;
			}
        }
    }

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    for (int i = 0; i < m; ++i) {
        free(temp[i]);
    }
    free(temp);
    temp = NULL;
    for (int i = 0; i < m; ++i) {
        free(kernel[i]);
    }
    free(kernel);
    kernel = NULL;

    double** kernel_ = (double**)malloc(sizeof(double*) * 3);
    for (int i = 0; i < 3; ++i) {
        kernel_[i] = (double*)malloc(sizeof(double) * 3);
    }
    kernel_[0][0] = -1; kernel_[0][1] = 0; kernel_[0][2] = 1;
    kernel_[1][0] = -1; kernel_[1][1] = 0; kernel_[1][2] = 1;
    kernel_[2][0] = -1; kernel_[2][1] = 0; kernel_[2][2] = 1;

    double** temp_ = (double**)malloc(sizeof(double*) * 3);
    for (int i = 0; i < m; ++i) {
        temp_[i] = (double*)malloc(sizeof(double) * 3);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temp_[i][j] = kernel_[m - i - 1][n - j - 1];
        }
    }

    double** newData_ = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData_[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData_[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c ++){
        		newData_[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        	
        }
    }
    
	unsigned char* dstData_ = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel;c++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += temp_[k][l] * newData_[k + i][(l + j) * srcChannel + c];
			        }
		        }
		        //边缘处理
		        if (sum > 255) {
		        	dstData_[num] = 255;
		        }
		        else if (sum < 0) {
		        	dstData_[num] = 0;
		        }
		        else {
		        	dstData_[num] = sum;
		        }
		        num++;
			}
        }
    }
    for (int i = 0; i < row; ++i) {
        free(newData_[i]);
    }
    free(newData_);
    newData_ = NULL;
    for (int i = 0; i < m; ++i) {
        free(temp_[i]);
    }
    free(temp_);
    temp_ = NULL;
    for (int i = 0; i < m; ++i) {
        free(kernel_[i]);
    }
    free(kernel_);
    kernel_ = NULL;

    int row_ = srcHeight;
    int col_ = srcWidth * srcChannel;
    for (int i = 0; i < row_; ++i) {
        for (int j = 0; j < col_; j++) {
	        if (dstData[i * col_ + j] + dstData_[i * col_ + j] > 255) {
	        	dstData[i * col_ + j] = 255;
	        }
	        else if (dstData[i * col_ + j] + dstData_[i * col_ + j] < 0) {
	        	dstData[i * col_ + j] = 0;
	        }
	        else {
	        	dstData[i * col_ + j] = dstData[i * col_ + j] + dstData_[i * col_ + j];
	        }
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
    dstData = NULL;
	free(dstData_);
    dstData_ = NULL;
	return 1;
}
//?
int laplacian(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    //获取卷积核
	double K[2][9] = {
		{ 0, 1, 0, 1, -4, 1, 0, 1, 0 },
		{ 2, 0, 2, 0, -8, 0, 2, 0, 2 }
	};
    int m = 3, n = 3;
	double** temp = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        temp[i]=(double*)malloc(sizeof(double)*n);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temp[i][j] = K[ksize == 3][i * m + j];
        }
    }
	
    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;
    // 空间初始化
    double** newData = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel;c ++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        }
    }

    // 卷积
    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel;c++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
		        	for (int l = 0; l < n; ++l) {
		        		sum += temp[k][l] * newData[k + i][(l + j) * srcChannel + c];
		        	}
		        }
		        //边缘处理
		        if (sum > 255) {
		        	dstData[num] = 255;
		        }
		        else if (sum < 0) {
		        	dstData[num] = -sum;
		        }
		        else {
		        	dstData[num] = sum;
		        }
		        num++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
    for (int i = 0; i < m; ++i) {
        free(temp[i]);
    }
    free(temp);
    temp = NULL;
    free(dstData);
    dstData = NULL;
	return 1;
}

int kirsch(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	
	// kirsch的8个3x3模板
	int a0[9] = { +5,+5,+5 , -3,0,-3 , -3,-3,-3 };
    int a1[9] = { -3,+5,+5 , -3,0,+5 , -3,-3,-3 };
    int a2[9] = { -3,-3,+5 , -3,0,+5 , -3,-3,+5 };
    int a3[9] = { -3,-3,-3 , -3,0,+5 , -3,+5,+5 };
    int a4[9] = { -3,-3,-3 , -3,0,-3 , +5,+5,+5 };
    int a5[9] = { -3,-3,-3 , +5,0,-3 , +5,+5,-3 };
    int a6[9] = { +5,-3,-3 , +5,0,-3 , +5,-3,-3 };
    int a7[9] = { +5,+5,-3 , +5,0,-3 , -3,-3,-3 };
    int* a[8] = { a0,a1,a2,a3,a4,a5,a6,a7 };

    int row = srcHeight;
    int col = srcWidth;

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    for (int i = 0; i < 8; ++i) {
        int m = 3, n = 3;
        int** tempc = (int**)malloc(sizeof(int*)*m);
        for (int ic = 0; ic < m; ++ic) {
        	tempc[ic] = (int*)malloc(sizeof(int)*n);
        }
        for (int ic = 0; ic < m; ++ic) {
	        for (int jc = 0; jc < n; ++jc) {
	        	tempc[ic][jc] = a[i][(m - ic - 1) * n + n - jc - 1];
	        }
        }

        int rowd = srcHeight + m / 2 * 2;
        int cold = srcWidth + n / 2 * 2;
        //空间初始化
        int** newData = (int**)malloc(sizeof(int*)*rowd);
        for (int ic = 0; ic < rowd; ++ic) {
        	newData[ic] = (int*)malloc(sizeof(int)*cold);
        }
        for (int ic = 0; ic < rowd; ++ic) {
	        for (int jc = 0; jc < cold; ++jc) {
	        	newData[ic][jc] = 0;
	        }
        }
        //将原始的数据填充进去
        for (int ic = m / 2; ic < rowd - m / 2; ++ic) {
	        for (int jc = n / 2; jc < cold - n / 2; ++jc) {
	        	newData[ic][jc] = srcImage[(ic - m / 2) * srcWidth + (jc - n / 2)];
	        }
        }

        unsigned char* tempData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
        //正式进行卷积
        int num = 0;
        for (int ic = 0; ic < rowd - m + 1; ++ic) {
	        for (int jc = 0; jc < cold - n + 1; ++jc) {
		        int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += tempc[k][l] * newData[k + ic][l + jc];
			        }
		        }
		        //边缘处理
		        if (sum > 255) {
		        	tempData[num] = 255;
		        }
		        else if (sum < 0) {
		        	tempData[num] = 0;
		        }
		        else {
		        	tempData[num] = sum;
		        }
		        num++;
	        }
        }

        for (int ic = 0; ic < row; ++ic) {
	        for (int jc = 0; jc < col; ++jc) {
		        if (dstData[ic * col + jc] < tempData[ic * col + jc]) {
		        	dstData[ic * col + jc] = tempData[ic * col + jc];
		        }
	        }
        }

        for (int ic = 0; ic < rowd; ++ic) {
        	free(newData[ic]);
        }
        free(newData);
        free(tempData);
        for (int ic = 0; ic < m; ++ic) {
        	free(tempc[ic]);
        }
        free(tempc);
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	dstData =  NULL;
	return 1;
}

int nevitia(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

	// nevitia的6个5x5模板
	int a0[25] = { -100,-100,0,100,100 ,-100,-100,0,100,100 , -100,-100,0,100,100, -100,-100,0,100,100, -100,-100,0,100,100 };
    int a1[25] = { -100,32,100,100,100 ,-100,-78,92,100,100 , -100,-100,0,100,100, -100,-100,-92,78,100, -100,-100,-100,-32,100 };
    int a2[25] = { 100,100,100,100,100 ,-32,78,100,100,100 , -100,-92,0,92,100, -100,-100,-100,-78,32, -100,-100,-100,-100,-100 };
    int a3[25] = { 100,100,100,100,100 ,100,100,100,100,100 , 0,0,0,0,0, -100,-100,-100,-100,-100, -100,-100,-100,-100,-100 };
    int a4[25] = { 100,100,100,100,100 ,100,100,100,78,32 , 100,92,0,-92,-100, -32,-78,-100,-100,-100, -100,-100,-100,-100,-100 };
    int a5[25] = { 100,100,100,32,-100 ,100,100,92,-78,-100 , 100,100,0,-100,-100, 100,78,-92,-100,-100, 100,-32,-100,-100,-100 };
    int* a[6] = { a0,a1,a2,a3,a4,a5 };

    int row = srcHeight;
    int col = srcWidth;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    for (int i = 0; i < 6; ++i) {
        int m = 5, n = 5;
        int** tempc = (int**)malloc(sizeof(int*)*m);
        for (int ic = 0; ic < m; ++ic) {
        	tempc[ic] = (int*)malloc(sizeof(int)*n);
        }
        for (int ic = 0; ic < m; ++ic) {
	        for (int jc = 0; jc < n; ++jc) {
	        	tempc[ic][jc] = a[i][(m - ic - 1) * n + n - jc - 1];
	        }
        }

        int rowd = srcHeight + m / 2 * 2;
        int cold = srcWidth + n / 2 * 2;

        int** newData = (int**)malloc(sizeof(int*)*rowd);
        for (int ic = 0; ic < rowd; ++ic) {
	        newData[ic] = (int*)malloc(sizeof(int)*cold);
        }
        for (int ic = 0; ic < rowd; ++ic) {
	        for (int jc = 0; jc < cold; ++jc) {
	        	newData[ic][jc] = 0;
	        }
        }
        for (int ic = m / 2; ic < rowd - m / 2; ++ic) {
	        for (int jc = n / 2; jc < cold - n / 2; ++jc) {
	        	newData[ic][jc] = srcImage[(ic - m / 2) * srcWidth + (jc - n / 2)];
	        }
        }

        unsigned char* tempData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
        
		//正式进行卷积
        int num = 0;
        for (int ic = 0; ic < rowd - m + 1; ++ic) {
	        for (int jc = 0; jc < cold - n + 1; ++jc) {
		        int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += a[i][k*n+l] * newData[k + ic][l + jc];
			        }
		        }
		        //边缘处理
		        if (sum > 255) {
		        	tempData[num] = 255;
		        }
		        else if (sum < 0) {
		        	tempData[num] = 0;
		        }
		        else {
		        	tempData[num] = sum;
		        }
		        num++;
	        }
        }

        for (int ic = 0; ic < row; ++ic) {
	        for (int jc = 0; jc < col; ++jc) {
		        if (dstData[ic * col + jc] < tempData[ic * col + jc]) {
		        	dstData[ic * col + jc] = tempData[ic * col + jc];
		        }
	        }
        }

        for (int ic = 0; ic < rowd; ++ic) {
        	free(newData[ic]);
        }
        free(newData);
        free(tempData);
        for (int ic = 0; ic < m; ++ic) {
        	free(tempc[ic]);
        }
        free(tempc);
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	dstData =  NULL;
	return 1;
}

int scharr(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    double** kernel = (double**)malloc(sizeof(double*) * 3);
    for (int i = 0; i < 3; ++i) {
        kernel[i]=(double*)malloc(sizeof(double)*3);
    }
    kernel[0][0] = -3; kernel[0][1] = 0; kernel[0][2] = 3;
    kernel[1][0] = -10; kernel[1][1] = 0; kernel[1][2] = 10;
    kernel[2][0] = -3; kernel[2][1] = 0; kernel[2][2] = 3;

    int m = 3, n = 3;
    double** temp = (double**)malloc(sizeof(double*)*m);
    for (int i = 0; i < m; ++i) {
        temp[i] = (double*)malloc(sizeof(double)*n);
    }
    for (int i = 0; i < m; ++i) {
        for (int j = 0; j < n; ++j) {
        	temp[i][j] = kernel[m - i - 1][n - j - 1];
        }
    }

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    double** newData = (double**)malloc(sizeof(double*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (double*)malloc(sizeof(double)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c ++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel + c];
			}
        }
    }

    //正式进行卷积
    int num = 0;
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel;c++){
	        	int sum = 0;
		        for (int k = 0; k < m; ++k) {
			        for (int l = 0; l < n; ++l) {
			        	sum += temp[k][l] * newData[k + i][(l + j) * srcChannel + c];
			        }
		        }
				//边缘处理
				if (sum > 255) {
					dstData[num] = 255;
				}
				else if (sum < 0) {
					dstData[num] = 0;
				}
				else {
					dstData[num] = sum;
				}
				num++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    newData = NULL;
	free(dstData);
    dstData = NULL;
    for (int i = 0; i < m; ++i) {
        free(temp[i]);
    }
    free(temp);
	return 1;
}
//-
int canny(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int gaussianSize, int low_threshold, int high_threshold) {

	double PI = 3.1415926;

	//1. 对原图进行高斯模糊
	unsigned char* gsImage = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	int gsWidth, gsHeight, gsChannel;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*1);
	if (srcChannel == 3){
		RGB2Gray(srcImage, srcWidth, srcHeight, srcChannel, dstData, &gsWidth, &gsHeight, &gsChannel);
		gaussianBlur(dstData, gsWidth, gsHeight, gsChannel, gsImage, &gsWidth, &gsHeight, &gsChannel, gaussianSize,gaussianSize, 0.8,0.8);
	} else {
		gaussianBlur(srcImage, srcWidth, srcHeight, srcChannel, gsImage, &gsWidth, &gsHeight, &gsChannel, gaussianSize,gaussianSize, 0.8,0.8);
	}

	//2. 计算梯度幅度和梯度角度
	unsigned char* sobelxImage = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	int sobelxWidth, sobelxHeight, sobelxChannel;
	unsigned char* sobelyImage = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	int sobelyWidth, sobelyHeight, sobelyChannel;
	sobel(gsImage, gsWidth, gsHeight, gsChannel, sobelxImage, &sobelxWidth, &sobelxHeight, &sobelxChannel, 1, 0, gaussianSize);
	sobel(gsImage, gsWidth, gsHeight, gsChannel, sobelyImage, &sobelyWidth, &sobelyHeight, &sobelyChannel, 1, 0, gaussianSize);

	unsigned char* angle = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	unsigned char* size = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			angle[i * srcWidth + j] = atan2(sobelyImage[i * srcWidth + j], sobelxImage[i * srcWidth + j]);
			size[i * srcWidth + j] = abs(sobelyImage[i * srcWidth + j]) + abs(sobelxImage[i * srcWidth + j]);
		}
	}

	//3. 对梯度幅度图像应用非最大抑制
	//先确定这个角度属于哪一块,再和同方向上的数值比较大小，确定是否能保留下来,注意边界问题
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			int angle_now = angle[i * srcWidth + j];
			int size_now = size[i * srcWidth + j];
			if (angle_now > -1 * PI / 8 && angle_now <= PI / 8) {
				//代表这个角度是水平的，找左右水平的角度
				if (j == 0) {
					//考虑左边界
					if (size_now > size[i * srcWidth + j + 1] &&
						size_now > size[i * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (j == srcHeight - 1) {
					//考虑右边界
					if (size_now > size[i * srcWidth + j - 1] &&
						size_now > size[i * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[i * srcWidth + j - 1] &&
						size_now > size[i * srcWidth + j + 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else if (angle_now > PI / 8 && angle_now <= PI / 8 * 3) {
				//代表这个角度是+45°
				if (i == 0 || j == srcWidth - 1) {
					//这个位置是边界，要往左下找两个点
					if (size_now > size[(i + 1) * srcWidth + j - 1] &&
						size_now > size[(i + 2) * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (i == srcHeight - 1 || j == 0) {
					//这个位置是边界，要往右上找两个点
					if (size_now > size[(i - 1) * srcWidth + j + 1] &&
						size_now > size[(i - 2) * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i + 1) * srcWidth + j - 1] &&
						size_now > size[(i - 1) * srcWidth + j + 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else if (angle_now > -3 * PI / 8 && angle_now <= PI / -8) {
				//代表这个角度是-45°
				if (i == 0 || j == 0) {
					//这个位置是边界，要往右上找两个点
					if (size_now > size[(i + 1) * srcWidth + j + 1] &&
						size_now > size[(i + 2) * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (i == srcHeight - 1 || j == srcWidth - 1) {
					//这个位置是边界，要往左下找两个点
					if (size_now > size[(i - 1) * srcWidth + j - 1] &&
						size_now > size[(i - 2) * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i + 1) * srcWidth + j + 1] &&
						size_now > size[(i - 1) * srcWidth + j - 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else {
				//代表这个角度是竖直的，找上下竖直的角度
				if (i == 0) {
					//考虑上边界
					if (size_now > size[(i + 1) * srcWidth + j] &&
						size_now > size[(i + 2) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (j == srcHeight - 1) {
					//考虑下边界
					if (size_now > size[(i - 1) * srcWidth + j] &&
						size_now > size[(i - 2) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i - 1) * srcWidth + j] &&
						size_now > size[(i + 1) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
		}
	}

	//4. 用双阈值处理和连接分析来检测并连接边缘
	// 滤除低于低阈值的点，保留强边缘点，标记弱边缘点
	int* flag = (int*)malloc(sizeof(int)*srcHeight*srcWidth);
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			flag[i * srcWidth + j] = 0;
		}
	}
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			int size_now = size[i * srcWidth + j];
			if (size_now >= high_threshold) {
				continue;
			}
			else if (size_now < low_threshold) {
				size[i * srcWidth + j] = 0;
			}
			else {
				flag[i * srcWidth + j] = 1;
			}
		}
	}
	// 检测弱边缘点的八邻域中是否有强边缘点
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			if (flag[i * srcWidth + j] == 1) {
				//注意边界问题
				int start_i = i - 1, start_j = j - 1;
				int end_i = i + 1, end_j = i + 1;
				if (i == 0) {
					start_i++;
				}
				if (i == srcHeight - 1) {
					end_i--;
				}
				if (j == 0) {
					start_j++;
				}
				if (j == srcWidth - 1) {
					end_j--;
				}

				int index = 0;
				for (int m = start_i; m < end_i; m++) {
					for (int n = start_j; n < end_j; n++) {
						if (size[m * srcWidth + n] >= high_threshold) {
							index = 1;
							break;
						}
					}
				}
				if (index == 0) {
					size[i * srcWidth + j] = 0;
				}
			}
		}
	}
	// 二值化
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			if (size[i * srcWidth + j] > 0) {
				size[i * srcWidth + j] = 255;
			}
		}
	}

	memcpy(outImage, size, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(gsImage);
	free(sobelyImage);
	free(sobelxImage);
	free(angle);
	free(size);

	return 1;
}

int cannyFromSobel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* srcImage2, int srcWidth2, int srcHeight2, int srcChannel2, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int low_threshold, int high_threshold) {

	double PI = 3.1415926;

	unsigned char* angle = (unsigned char*)malloc(srcWidth*srcHeight);
	unsigned char* size = (unsigned char*)malloc(srcWidth*srcHeight);

	unsigned char* src1 = (unsigned char*)malloc(srcWidth*srcHeight);
	unsigned char* src2 = (unsigned char*)malloc(srcWidth*srcHeight);

	if (srcChannel == 3) {
		for (int i = 0; i < srcHeight; ++i) {
			for (int j = 0; j < srcWidth; ++j) {
				int s = 38 * srcImage[i * srcWidth * srcChannel + j * srcChannel] + 75 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] + 15 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
				src1[i * srcWidth + j] = s >> 7;
			}
		}
	}
	else if (srcChannel == 1) {
		for (int i = 0; i < srcHeight; ++i) {
			for (int j = 0; j < srcWidth; ++j) {
				src1[i * srcWidth + j] = srcImage[i * srcWidth + j];
			}
		}
	}

	if (srcChannel2 == 3) {
		for (int i = 0; i < srcHeight2; ++i) {
			for (int j = 0; j < srcWidth2; ++j) {
				int s = 38 * srcImage2[i * srcWidth2 * srcChannel2 + j * srcChannel2] + 75 * srcImage2[i * srcWidth2 * srcChannel2 + j * srcChannel2 + 1] + 15 * srcImage2[i * srcWidth2 * srcChannel2 + j * srcChannel2 + 2];
				src2[i * srcWidth2 + j] = s >> 7;
			}
		}
	}
	else if (srcChannel2 == 1) {
		for (int i = 0; i < srcHeight2; ++i) {
			for (int j = 0; j < srcWidth2; ++j) {
				src2[i * srcWidth2 + j] = srcImage2[i * srcWidth2 + j];
			}
		}
	}

	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			angle[i * srcWidth + j] = atan2(src2[i * srcWidth + j], src1[i * srcWidth + j]);
			size[i * srcWidth + j] = abs(src2[i * srcWidth + j]) + abs(src1[i * srcWidth + j]);
		}
	}

	//3. 对梯度幅度图像应用非最大抑制
	//先确定这个角度属于哪一块,再和同方向上的数值比较大小，确定是否能保留下来,注意边界问题
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			int angle_now = angle[i * srcWidth + j];
			int size_now = size[i * srcWidth + j];
			if (angle_now > -1 * PI / 8 && angle_now <= PI / 8) {
				//代表这个角度是水平的，找左右水平的角度
				if (j == 0) {
					//考虑左边界
					if (size_now > size[i * srcWidth + j + 1] &&
						size_now > size[i * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (j == srcHeight - 1) {
					//考虑右边界
					if (size_now > size[i * srcWidth + j - 1] &&
						size_now > size[i * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[i * srcWidth + j - 1] &&
						size_now > size[i * srcWidth + j + 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else if (angle_now > PI / 8 && angle_now <= PI / 8 * 3) {
				//代表这个角度是+45°
				if (i == 0 || j == srcWidth - 1) {
					//这个位置是边界，要往左下找两个点
					if (size_now > size[(i + 1) * srcWidth + j - 1] &&
						size_now > size[(i + 2) * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (i == srcHeight - 1 || j == 0) {
					//这个位置是边界，要往右上找两个点
					if (size_now > size[(i - 1) * srcWidth + j + 1] &&
						size_now > size[(i - 2) * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i + 1) * srcWidth + j - 1] &&
						size_now > size[(i - 1) * srcWidth + j + 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else if (angle_now > -3 * PI / 8 && angle_now <= PI / -8) {
				//代表这个角度是-45°
				if (i == 0 || j == 0) {
					//这个位置是边界，要往右上找两个点
					if (size_now > size[(i + 1) * srcWidth + j + 1] &&
						size_now > size[(i + 2) * srcWidth + j + 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (i == srcHeight - 1 || j == srcWidth - 1) {
					//这个位置是边界，要往左下找两个点
					if (size_now > size[(i - 1) * srcWidth + j - 1] &&
						size_now > size[(i - 2) * srcWidth + j - 2]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i + 1) * srcWidth + j + 1] &&
						size_now > size[(i - 1) * srcWidth + j - 1]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
			else {
				//代表这个角度是竖直的，找上下竖直的角度
				if (i == 0) {
					//考虑上边界
					if (size_now > size[(i + 1) * srcWidth + j] &&
						size_now > size[(i + 2) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else if (j == srcHeight - 1) {
					//考虑下边界
					if (size_now > size[(i - 1) * srcWidth + j] &&
						size_now > size[(i - 2) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
				else {
					if (size_now > size[(i - 1) * srcWidth + j] &&
						size_now > size[(i + 1) * srcWidth + j]) {
						continue;
					}
					else {
						size[i * srcWidth + j] = 0;
					}
				}
			}
		}
	}

	//4. 用双阈值处理和连接分析来检测并连接边缘

	int* flag = (int*)malloc(sizeof(int)*srcHeight*srcWidth);
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			flag[i * srcWidth + j] = 0;
		}
	}
	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			int size_now = size[i * srcWidth + j];
			if (size_now >= high_threshold) {
				continue;
			}
			else if (size_now < low_threshold) {
				size[i * srcWidth + j] = 0;
			}
			else {
				flag[i * srcWidth + j] = 1;
			}
		}
	}

	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			if (flag[i * srcWidth + j] == 1) {
				//注意边界问题
				int start_i = i - 1, start_j = j - 1;
				int end_i = i + 1, end_j = i + 1;
				if (i == 0) {
					start_i++;
				}
				if (i == srcHeight - 1) {
					end_i--;
				}
				if (j == 0) {
					start_j++;
				}
				if (j == srcWidth - 1) {
					end_j--;
				}

				int index = 0;
				for (int m = start_i; m < end_i; m++) {
					for (int n = start_j; n < end_j; n++) {
						if (size[m * srcWidth + n] >= high_threshold) {
							index = 1;
							break;
						}
					}
				}
				if (index == 0) {
					size[i * srcWidth + j] = 0;
				}
			}
		}
	}

	for (int i = 0; i < srcHeight; ++i) {
		for (int j = 0; j < srcWidth; ++j) {
			if (size[i * srcWidth + j] > 0) {
				size[i * srcWidth + j] = 255;
			}
		}
	}

	memcpy(outImage, size, srcWidth*srcHeight);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(src1);
	free(src2);
	free(angle);
	free(size);

	return 1;
}

int bilateralFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize,float sigma_color,float sigma_space){

	int row = srcHeight + ksize / 2 * 2;
    int col = srcWidth + ksize / 2 * 2;

    //空间初始化
    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col*srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = ksize / 2; i < row - ksize / 2; ++i) {
        for (int j = ksize / 2; j < col - ksize / 2; ++j) {
        	for(int c = 0; c < srcChannel; c++)
				newData[i][j * srcChannel + c] = srcImage[(i - ksize / 2) * srcWidth * srcChannel + (j - ksize / 2) * srcChannel + c];
        }
    }
    
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    for (int i = 0; i < row - ksize + 1; ++i) {
        for (int j = 0; j < col - ksize + 1; ++j) {
			for(int c = 0; c < srcChannel; c++){
				int M = i + ksize / 2;
				int N = j + ksize / 2;
				int pixel = newData[M][N * srcChannel + c];
				double sum = 0, normal = 0;
				for (int k = i; k < ksize + i; ++k) {
					for (int l = j; l < ksize + j; ++l) {
						double space = exp(-1.0 / 2 * pow(sqrt(pow(k - M, 2) + pow(l - N, 2)) / sigma_space, 2));
						double color = exp(-1.0 / 2 * pow(abs(newData[k][l * srcChannel + c] - pixel) / sigma_color, 2));
						sum += space * color * newData[k][l * srcChannel + c];
						normal += space * color;
					}
				}
				dstData[flag] = sum / normal;
				flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	free(dstData);
	return 1;
}

int geometricMeanFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n){

    int row = srcHeight + m / 2 * 2;
    int col = srcWidth + n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = m / 2; i < row - m / 2; ++i) {
        for (int j = n / 2; j < col - n / 2; ++j) {
        	for(int c = 0; c < srcChannel; c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - m / 2) * srcWidth * srcChannel + (j - n / 2) * srcChannel  + c];
			}
        }
    }

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    int* a = (int*)malloc(sizeof(int)*m*n);
    for (int i = 0; i < row - m + 1; ++i) {
        for (int j = 0; j < col - n + 1; ++j) {
	        for(int c = 0; c < srcChannel; c++){
		        int num_ = 0;
		        for (int k = i; k < m + i; ++k) {
			        for (int l = j; l < n + j; ++l) {
				        a[num_] = newData[k][l * srcChannel +c];
				        num_++;
			        }
		        }
		        int num = m * n;
		        double re = 1;
		        for (int ic = 0; ic < num; ++ic) {
			        re *= a[ic];
		        }
		        //开mn次方
		        int value = pow(re, 1.0 / num);
		        if (value < 0) {
		        	value = 0;
		        }
		        else if (value > 255) {
		        	value = 255;
		        }
		        dstData[flag] = value;
		        flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
	newData = NULL;
    free(dstData);
	dstData = NULL;
	free(a);
	a=NULL;
    return 1;
}

int adaptiveMedianFilter(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int m,int n,int max_m,int max_n){
	
    int row = srcHeight + max_m / 2 * 2;
    int col = srcWidth + max_n / 2 * 2;

    int** newData = (int**)malloc(sizeof(int*)*row);
    for (int i = 0; i < row; ++i) {
        newData[i] = (int*)malloc(sizeof(int)*col * srcChannel);
    }
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col * srcChannel; ++j) {
        	newData[i][j] = 0;
        }
    }
    for (int i = max_m / 2; i < row - max_m / 2; ++i) {
        for (int j = max_n / 2; j < col - max_n / 2; ++j) {
        	for(int c = 0;c<srcChannel;c++){
        		newData[i][j * srcChannel + c] = srcImage[(i - max_m / 2) * srcWidth * srcChannel + (j - max_n / 2) * srcChannel  + c];
			}
        }
    }

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int flag = 0;
    for (int i = 0; i < row - max_m + 1; ++i) {
        for (int j = 0; j < col - max_n + 1; ++j) {
			for(int c = 0; c < srcChannel; c++) {
				int value = -1; 
				int new_m = m - 2, new_n = n - 2;
				while (value == -1) {
					new_m += 2;
					new_n += 2;
					int* a = (int*)malloc(sizeof(int)*new_m * new_n);
					int num_ = 0;
					for (int k = (max_n - new_n) / 2 + i; k < (max_n + new_n) / 2 + i; ++k) {
						for (int l = (max_m - new_m) / 2 + j; l < (max_m + new_m) / 2 + j; ++l) {
							a[num_] = newData[k][l * srcChannel + c];
							num_++;
						}
					}
					int temp_value = 0;
					int allnum = new_m * new_n;
					int now = a[allnum / 2];

					int max = 0;
					for (int ic = 0; ic < allnum; ++ic) {
						if (max < a[ic]) {
							max = a[ic];
						}
					}
					int min = 256;
					for (int ic = 0; ic < allnum; ++ic) {
						if (min > a[ic]) {
							min = a[ic];
						}
					}
					for (int ic = 0; ic < allnum; ++ic) {
						for (int jc = ic + 1; jc < allnum; ++jc) {
							if (a[ic] > a[jc]) {
								int temp = a[ic];
								a[ic] = a[jc];
								a[jc] = temp;
							}
						}
					}
					int mid = (int)a[allnum / 2];
					int A1 = mid - min;
					int A2 = mid - max;
			
					if (A1 > 0 && A2 < 0) {
						int B1 = now - min;
						int B2 = now - max;
						if (B1 > 0 && B2 < 0) {
							temp_value = now;
						}
						else {
							temp_value = mid;
						}
					}
					else {
						if (new_m + 2 > max_m || new_n + 2 > max_n) {
							temp_value = mid;
						}
						else {
							temp_value = -1;
						}
					}
					value = temp_value;
					free(a);
				}
				if (value < 0) {
					value = 0;
				}
				else if (value > 255) {
					value = 255;
				}
				dstData[flag] = value;
				flag++;
			}
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    for (int i = 0; i < row; ++i) {
        free(newData[i]);
    }
    free(newData);
    free(dstData);
	return 1;   
}

int meanPooling(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int poolSize) {

	int r = poolSize;//池化范围  
	int step = poolSize;//步长 
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	if (srcWidth * 1.0 / r - srcWidth / r != 0 || srcHeight * 1.0 / r - srcHeight / r != 0) {
		// memcpy(outImage, srcImage, srcWidth*srcHeight*srcChannel);
		// *outChannel = srcChannel;
		// *outHeight = srcHeight;
		// *outWidth = srcWidth;
		free(dstData);
		return 0;
	}

	for (int y = 0; y < srcHeight; y += step) {
		for (int x = 0; x < srcWidth; x += step) {
			for (int c = 0; c < srcChannel; c++) {
				int val = 0;
				for (int dy = 0; dy < r; dy++) {
					for (int dx = 0; dx < r; ++dx) {
						val += srcImage[(y + dy) * srcWidth * srcChannel + (x + dx) * srcChannel + c];
					}
				}
				val = val / (r * r);
				for (int dy = 0; dy < r; dy++) {
					for (int dx = 0; dx < r; ++dx) {
						dstData[(y + dy) * srcWidth * srcChannel + (x + dx) * srcChannel + c] = val;
					}
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int maxPooling(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int poolSize) {

	int r = poolSize;//池化范围  
	int step = poolSize;//步长 
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	if (srcWidth * 1.0 / r - srcWidth / r != 0 || srcHeight * 1.0 / r - srcHeight / r != 0) {
		// memcpy(outImage, srcImage, srcWidth*srcHeight*srcChannel);
		// *outChannel = srcChannel;
		// *outHeight = srcHeight;
		// *outWidth = srcWidth;
		free(dstData);
		return 0;
	}

	for (int y = 0; y < srcHeight; y += step) {
		for (int x = 0; x < srcWidth; x += step) {
			for (int c = 0; c < srcChannel; c++) {
				int val = 0;
				int max = 0;
				for (int dy = 0; dy < r; dy++) {
					for (int dx = 0; dx < r; ++dx) {
						val = srcImage[(y + dy) * srcWidth * srcChannel + (x + dx) * srcChannel + c];
						if (max < val){
							max = val;
						}
					}
				}
				for (int dy = 0; dy < r; dy++) {
					for (int dx = 0; dx < r; ++dx) {
						dstData[(y + dy) * srcWidth * srcChannel + (x + dx) * srcChannel + c] = max;
					}
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

// color  16

int gammaTransform(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float gamma){
	
	float val;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = srcImage[i * srcWidth * srcChannel + j * srcChannel + c] / 255.0f;
				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = static_cast<unsigned char>(pow(val, gamma) * 255);
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int brightnessAndContrast(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float alpha, float beta){
	
	float val;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = 127 + (srcImage[i * srcWidth * srcChannel + j * srcChannel + c] - 127) * (1 + alpha) + beta;
				if (val > 255)	
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = 255;
				else if (val < 0)	
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = 0;
				else 
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = static_cast<unsigned char>(val);
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int channelCommingler(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorChn, float red, float green, float blue, float constant){
	
	float r, g, b;
	float val;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				if (c == (2 - colorChn)) {
					b = srcImage[i * srcWidth * srcChannel + j * srcChannel];
					g = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1];
					r = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
					val = r * red + g * green + b * blue + 255 * constant;
					if (val > 255)	
						dstData[i * srcWidth * srcChannel + j * srcChannel + c] = 255;
					else if (val < 0)	
						dstData[i * srcWidth * srcChannel + j * srcChannel + c] = 0;
					else 
						dstData[i * srcWidth * srcChannel + j * srcChannel + c] = static_cast<unsigned char>(val);
				}
				else{
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
				}
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int normalize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int low, int high){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	int start = 999, end = 0;
	int val = 0;

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
				if(start > val)
					start = val;
				if(end < val){
					end = val;
				}
			}
		}
	}

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
				if (val < low) {
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = low;
				}
				else if (val <= high) {
					int v = (int)((high - low) * 1.0 / (end - start) * (val - start) + low);
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = v;
				}
				else {
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = high;
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int equalize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel) {

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	int val;
	int S = srcHeight * srcWidth * srcChannel;
	int hist[256];
	int histSum = 0;

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
				hist[val]++;
			}
		}
	}
	
	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			for (int c = 0; c < srcChannel; c++) {
				val = srcImage[i * srcWidth * srcChannel + j * srcChannel + c];
				histSum = 0;
				//根据0-val的所有像素个数的构建sum
				for (int l = 0; l < val; l++) {
					histSum += hist[l];
				}
				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = (int)(histSum * 1.0 / S * 255);
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int RGB2Gray(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*1);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			int s = 15 * srcImage[i * srcWidth * srcChannel + j * srcChannel] + 75 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] + 38 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
			dstData[i * srcWidth + j] = s >> 7;
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int RGB2BGR(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			dstData[i * srcWidth * srcChannel + j * srcChannel] = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
			dstData[i * srcWidth * srcChannel + j * srcChannel + 1] = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1];
			dstData[i * srcWidth * srcChannel + j * srcChannel + 2] = srcImage[i * srcWidth * srcChannel + j * srcChannel];
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int RGB2YCrCb(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel) {
	
	float* YCbCr = (float*)malloc(srcWidth * srcHeight * srcChannel * sizeof(float));
	int height = srcHeight;
	int width = srcWidth;
	int channel = srcChannel;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for (int y = 0; y < height; y++) {
		for (int x = 0; x < width; x++) {
			YCbCr[y * width * channel + x * channel] = (int)((float)srcImage[y * width * channel + x * channel] * 0.114
															+ (float)srcImage[y * width * channel + x * channel + 1] * 0.5870
															+ (float)srcImage[y * width * channel + x * channel + 2] * 0.299);
			YCbCr[y * width * channel + x * channel + 1] = (int)((float)srcImage[y * width * channel + x * channel] * 0.5
																+ (float)srcImage[y * width * channel + x * channel + 1] * (-0.3323) 
																+ (float)srcImage[y * width * channel + x * channel + 2] * (-0.1687) + 128);
			YCbCr[y * width * channel + x * channel + 2] = (int)((float)srcImage[y * width * channel + x * channel] * (-0.0813) 
																+ (float)srcImage[y * width * channel + x * channel + 1] * (-0.4187) 
																+ (float)srcImage[y * width * channel + x * channel + 2] * 0.5 + 128);
		}
	}

	for (int y = 0; y < height; y++)
		for (int x = 0; x < width; x++)
			YCbCr[y * width * channel + x * channel] *= 0.7;

	for (int y = 0; y < height; y++) {
		for (int x = 0; x < width; x++) {
			// R
			int R = ((int)YCbCr[y * width * channel + x * channel] + ((int)YCbCr[y * width * channel + x * channel + 2] - 128) * 1.4102);
			if(R < 0) 	R = 0;
			if(R > 255) R = 255;
			dstData[y * srcWidth * channel + channel * x + 2] = R;
			// G
			int G = ((int)YCbCr[y * width * channel + x * channel] - ((int)YCbCr[y * width * channel + x * channel + 1] - 128) * 0.3441 - ((int)YCbCr[y * width * channel + x * channel + 2] - 128) * 0.7139);
			if(G < 0)	G = 0;
			if(G > 255)	G = 255;
			dstData[y * srcWidth * channel + channel * x + 1] = G;

			// B
			int B = ((int)YCbCr[y * width * channel + x * channel] + ((int)YCbCr[y * width * channel + x * channel + 1] - 128) * 1.7718);
			if(B < 0)	B = 0;
			if(B > 255)	B = 255;
			dstData[y * srcWidth * channel + channel * x] = B;
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
    free(YCbCr);
	return 1;
}

int RGB2HSL(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, float* H, float* S, float* L) {
	
	float r,g,b, max, min, delR, delG, delB, delMax, l;
	
	for(int i = 0; i < srcHeight; i++){
		for(int j = 0; j < srcWidth; j++){
			b = srcImage[i * srcWidth * srcChannel + j * srcChannel] / 255.0;
			g = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] / 255.0;
			r = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2] / 255.0;
			max = b; min = b;
			if(max < g)
				max = g;
			if(max < r)
				max = r;
			if(min > g)
				min = g;
			if(min > r)
				min = r;

			l = (max + min) / 2;
			delMax = max - min;

			if (max == min) {
				H[i * srcWidth + j] = 0;
				S[i * srcWidth + j] = 0;
			}
			else {
				if (l <= 0.5)
					S[i * srcWidth + j] = delMax / (max + min);
				else
					S[i * srcWidth + j] = delMax / (2 - max - min);

				delR = (((max - r) / 6.0) + delMax / 2.0) / delMax;
				delG = (((max - g) / 6.0) + delMax / 2.0) / delMax;
				delB = (((max - b) / 6.0) + delMax / 2.0) / delMax;

				if (r == max) 
					H[i * srcWidth + j] = delB - delG;
				else if (g == max)
					H[i * srcWidth + j] = 1 / 3.0 + delR - delB;
				else if (b == max)
					H[i * srcWidth + j] = 2 / 3.0 + delG - delR;

				if (H[i * srcWidth + j] < 0) H[i * srcWidth + j] += 1;
				if (H[i * srcWidth + j] > 1) H[i * srcWidth + j] -= 1;
			}

			L[i * srcWidth + j] = l;
		}
	}

	return 1;
}

int RGB2Binary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, float maxval, int region){

	int result;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*1);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			int s = 15 * srcImage[i * srcWidth * srcChannel + j * srcChannel] + 75 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] + 38 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
			result = s >> 7;
			if (result > thresh) {
	        	dstData[i * srcWidth + j] = region == 1 ? maxval : 0;
	        }
	        else {
	        	dstData[i * srcWidth + j] = region == 1 ? 0 : maxval;
	        }
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int HSV2Binary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int region, float lowH, float highH, float lowS, float highS, float lowV, float highV) {

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight);
	for (int i = 0; i < srcWidth; i++) {
		for (int j = 0; j < srcHeight; j++) {
			double B = srcImage[i*srcHeight*  srcChannel + j*  srcChannel]*  1.0 / 256;
			double G = srcImage[i*srcHeight*  srcChannel + j*  srcChannel + 1]*  1.0 / 256;
			double R = srcImage[i*srcHeight*  srcChannel + j*  srcChannel + 2]*  1.0 / 256;
			double max = B;
			double min = B;
			int maxindex = 0;
			if (max < G) {
				max = G;
				maxindex = 1;
			}
			if (max < R) {
				max = R;
				maxindex = 2;
			}
			if (min > G)
				min = G;
			if (min > R)
				min = R;
			double h, s, v;
			if (max == min) {
				h = 0;
			}
			else if (maxindex == 2 && G >= B) {
				h = 60*  (G - B) / (max - min);
			}
			else if (maxindex == 2 && G < B) {
				h = 60*  (G - B) / (max - min) + 360;
			}
			else if (maxindex == 1) {
				h = 60*  (B - R) / (max - min) + 120;
			}
			else if (maxindex == 0) {
				h = 60*  (R - G) / (max - min) + 240;
			}
			if (max == 0)
				s = 0;
			else
				s = 1 - (min / max);
			v = max;

			int fh;
			int fs;
			int fv;

			if (region == 0) {
				if (h >= lowH && h <= highH) {
					fh = 0;
				}
				else {
					fh = 255;
				}
				if (s >= lowS && s <= highS) {
					fs = 0;
				}
				else {
					fs = 255;
				}
				if (v >= lowV && v <= highV) {
					fv = 0;
				}
				else {
					fv = 255;
				}
				if (fh == 0 && fs == 0 && fv == 0) {
					dstData[i*srcHeight + j] = 0;
				}
				else {
					dstData[i*srcHeight + j] = 255;
				}
			}
			else {
				if (h >= lowH && h <= highH) {
					fh = 255;
				}
				else {
					fh = 0;
				}
				if (s >= lowS && s <= highS) {
					fs = 255;
				}
				else {
					fs = 0;
				}
				if (v >= lowV && v <= highV) {
					fv = 255;
				}
				else {
					fv = 0;
				}

				if (fh == 255 && fs == 255 && fv == 255) {
					dstData[i*srcHeight + j] = 255;
				}
				else {
					dstData[i*srcHeight + j] = 0;
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight);
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	*outChannel = 1;

	return 1;
}

int Gray2Pseudo(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorMapTypes){
	
	// autumn
	static const float r0[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	static const float g0[] = { 0, 0.01587301587301587f, 0.03174603174603174f, 0.04761904761904762f, 0.06349206349206349f, 0.07936507936507936f, 0.09523809523809523f, 0.1111111111111111f, 0.126984126984127f, 0.1428571428571428f, 0.1587301587301587f, 0.1746031746031746f, 0.1904761904761905f, 0.2063492063492063f, 0.2222222222222222f, 0.2380952380952381f, 0.253968253968254f, 0.2698412698412698f, 0.2857142857142857f, 0.3015873015873016f, 0.3174603174603174f, 0.3333333333333333f, 0.3492063492063492f, 0.3650793650793651f, 0.3809523809523809f, 0.3968253968253968f, 0.4126984126984127f, 0.4285714285714285f, 0.4444444444444444f, 0.4603174603174603f, 0.4761904761904762f, 0.492063492063492f, 0.5079365079365079f, 0.5238095238095238f, 0.5396825396825397f, 0.5555555555555556f, 0.5714285714285714f, 0.5873015873015873f, 0.6031746031746031f, 0.6190476190476191f, 0.6349206349206349f, 0.6507936507936508f, 0.6666666666666666f, 0.6825396825396826f, 0.6984126984126984f, 0.7142857142857143f, 0.7301587301587301f, 0.746031746031746f, 0.7619047619047619f, 0.7777777777777778f, 0.7936507936507936f, 0.8095238095238095f, 0.8253968253968254f, 0.8412698412698413f, 0.8571428571428571f, 0.873015873015873f, 0.8888888888888888f, 0.9047619047619048f, 0.9206349206349206f, 0.9365079365079365f, 0.9523809523809523f, 0.9682539682539683f, 0.9841269841269841f, 1};
	static const float b0[] = {  0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	// bone
	static const float r1[] = { 0, 0.01388888888888889f, 0.02777777777777778f, 0.04166666666666666f, 0.05555555555555555f, 0.06944444444444445f, 0.08333333333333333f, 0.09722222222222221f, 0.1111111111111111f, 0.125f, 0.1388888888888889f, 0.1527777777777778f, 0.1666666666666667f, 0.1805555555555556f, 0.1944444444444444f, 0.2083333333333333f, 0.2222222222222222f, 0.2361111111111111f, 0.25f, 0.2638888888888889f, 0.2777777777777778f, 0.2916666666666666f, 0.3055555555555555f, 0.3194444444444444f, 0.3333333333333333f, 0.3472222222222222f, 0.3611111111111111f, 0.375f, 0.3888888888888888f, 0.4027777777777777f, 0.4166666666666666f, 0.4305555555555555f, 0.4444444444444444f, 0.4583333333333333f, 0.4722222222222222f, 0.4861111111111112f, 0.5f, 0.5138888888888888f, 0.5277777777777778f, 0.5416666666666667f, 0.5555555555555556f, 0.5694444444444444f, 0.5833333333333333f, 0.5972222222222222f, 0.611111111111111f, 0.6249999999999999f, 0.6388888888888888f, 0.6527777777777778f, 0.6726190476190474f, 0.6944444444444442f, 0.7162698412698412f, 0.7380952380952381f, 0.7599206349206349f, 0.7817460317460316f, 0.8035714285714286f, 0.8253968253968254f, 0.8472222222222221f, 0.8690476190476188f, 0.8908730158730158f, 0.9126984126984128f, 0.9345238095238095f, 0.9563492063492063f, 0.978174603174603f, 1};
	static const float g1[] = { 0, 0.01388888888888889f, 0.02777777777777778f, 0.04166666666666666f, 0.05555555555555555f, 0.06944444444444445f, 0.08333333333333333f, 0.09722222222222221f, 0.1111111111111111f, 0.125f, 0.1388888888888889f, 0.1527777777777778f, 0.1666666666666667f, 0.1805555555555556f, 0.1944444444444444f, 0.2083333333333333f, 0.2222222222222222f, 0.2361111111111111f, 0.25f, 0.2638888888888889f, 0.2777777777777778f, 0.2916666666666666f, 0.3055555555555555f, 0.3194444444444444f, 0.3353174603174602f, 0.3544973544973544f, 0.3736772486772486f, 0.3928571428571428f, 0.412037037037037f, 0.4312169312169312f, 0.4503968253968254f, 0.4695767195767195f, 0.4887566137566137f, 0.5079365079365078f, 0.5271164021164021f, 0.5462962962962963f, 0.5654761904761904f, 0.5846560846560845f, 0.6038359788359787f, 0.623015873015873f, 0.6421957671957671f, 0.6613756613756612f, 0.6805555555555555f, 0.6997354497354497f, 0.7189153439153438f, 0.7380952380952379f, 0.7572751322751322f, 0.7764550264550264f, 0.7916666666666666f, 0.8055555555555555f, 0.8194444444444444f, 0.8333333333333334f, 0.8472222222222222f, 0.861111111111111f, 0.875f, 0.8888888888888888f, 0.9027777777777777f, 0.9166666666666665f, 0.9305555555555555f, 0.9444444444444444f, 0.9583333333333333f, 0.9722222222222221f, 0.986111111111111f, 1};
	static const float b1[] = { 0, 0.01917989417989418f, 0.03835978835978836f, 0.05753968253968253f, 0.07671957671957672f, 0.09589947089947089f, 0.1150793650793651f, 0.1342592592592592f, 0.1534391534391534f, 0.1726190476190476f, 0.1917989417989418f, 0.210978835978836f, 0.2301587301587301f, 0.2493386243386243f, 0.2685185185185185f, 0.2876984126984127f, 0.3068783068783069f, 0.326058201058201f, 0.3452380952380952f, 0.3644179894179894f, 0.3835978835978835f, 0.4027777777777777f, 0.4219576719576719f, 0.4411375661375661f, 0.4583333333333333f, 0.4722222222222222f, 0.4861111111111111f, 0.5f, 0.5138888888888888f, 0.5277777777777777f, 0.5416666666666666f, 0.5555555555555556f, 0.5694444444444444f, 0.5833333333333333f, 0.5972222222222222f, 0.6111111111111112f, 0.625f, 0.6388888888888888f, 0.6527777777777778f, 0.6666666666666667f, 0.6805555555555556f, 0.6944444444444444f, 0.7083333333333333f, 0.7222222222222222f, 0.736111111111111f, 0.7499999999999999f, 0.7638888888888888f, 0.7777777777777778f, 0.7916666666666666f, 0.8055555555555555f, 0.8194444444444444f, 0.8333333333333334f, 0.8472222222222222f, 0.861111111111111f, 0.875f, 0.8888888888888888f, 0.9027777777777777f, 0.9166666666666665f, 0.9305555555555555f, 0.9444444444444444f, 0.9583333333333333f, 0.9722222222222221f, 0.986111111111111f, 1};
	// jet
	static const float r2[] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0.00588235294117645f,0.02156862745098032f,0.03725490196078418f,0.05294117647058827f,0.06862745098039214f,0.084313725490196f,0.1000000000000001f,0.115686274509804f,0.1313725490196078f,0.1470588235294117f,0.1627450980392156f,0.1784313725490196f,0.1941176470588235f,0.2098039215686274f,0.2254901960784315f,0.2411764705882353f,0.2568627450980392f,0.2725490196078431f,0.2882352941176469f,0.303921568627451f,0.3196078431372549f,0.3352941176470587f,0.3509803921568628f,0.3666666666666667f,0.3823529411764706f,0.3980392156862744f,0.4137254901960783f,0.4294117647058824f,0.4450980392156862f,0.4607843137254901f,0.4764705882352942f,0.4921568627450981f,0.5078431372549019f,0.5235294117647058f,0.5392156862745097f,0.5549019607843135f,0.5705882352941174f,0.5862745098039217f,0.6019607843137256f,0.6176470588235294f,0.6333333333333333f,0.6490196078431372f,0.664705882352941f,0.6803921568627449f,0.6960784313725492f,0.7117647058823531f,0.7274509803921569f,0.7431372549019608f,0.7588235294117647f,0.7745098039215685f,0.7901960784313724f,0.8058823529411763f,0.8215686274509801f,0.8372549019607844f,0.8529411764705883f,0.8686274509803922f,0.884313725490196f,0.8999999999999999f,0.9156862745098038f,0.9313725490196076f,0.947058823529412f,0.9627450980392158f,0.9784313725490197f,0.9941176470588236f,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0.9862745098039216f,0.9705882352941178f,0.9549019607843139f,0.93921568627451f,0.9235294117647062f,0.9078431372549018f,0.892156862745098f,0.8764705882352941f,0.8607843137254902f,0.8450980392156864f,0.8294117647058825f,0.8137254901960786f,0.7980392156862743f,0.7823529411764705f,0.7666666666666666f,0.7509803921568627f,0.7352941176470589f,0.719607843137255f,0.7039215686274511f,0.6882352941176473f,0.6725490196078434f,0.6568627450980391f,0.6411764705882352f,0.6254901960784314f,0.6098039215686275f,0.5941176470588236f,0.5784313725490198f,0.5627450980392159f,0.5470588235294116f,0.5313725490196077f,0.5156862745098039f,0.5f};
	static const float g2[] = {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0.001960784313725483f,0.01764705882352935f,0.03333333333333333f,0.0490196078431373f,0.06470588235294117f,0.08039215686274503f,0.09607843137254901f,0.111764705882353f,0.1274509803921569f,0.1431372549019607f,0.1588235294117647f,0.1745098039215687f,0.1901960784313725f,0.2058823529411764f,0.2215686274509804f,0.2372549019607844f,0.2529411764705882f,0.2686274509803921f,0.2843137254901961f,0.3f,0.3156862745098039f,0.3313725490196078f,0.3470588235294118f,0.3627450980392157f,0.3784313725490196f,0.3941176470588235f,0.4098039215686274f,0.4254901960784314f,0.4411764705882353f,0.4568627450980391f,0.4725490196078431f,0.4882352941176471f,0.503921568627451f,0.5196078431372548f,0.5352941176470587f,0.5509803921568628f,0.5666666666666667f,0.5823529411764705f,0.5980392156862746f,0.6137254901960785f,0.6294117647058823f,0.6450980392156862f,0.6607843137254901f,0.6764705882352942f,0.692156862745098f,0.7078431372549019f,0.723529411764706f,0.7392156862745098f,0.7549019607843137f,0.7705882352941176f,0.7862745098039214f,0.8019607843137255f,0.8176470588235294f,0.8333333333333333f,0.8490196078431373f,0.8647058823529412f,0.8803921568627451f,0.8960784313725489f,0.9117647058823528f,0.9274509803921569f,0.9431372549019608f,0.9588235294117646f,0.9745098039215687f,0.9901960784313726f,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0.9901960784313726f,0.9745098039215687f,0.9588235294117649f,0.943137254901961f,0.9274509803921571f,0.9117647058823528f,0.8960784313725489f,0.8803921568627451f,0.8647058823529412f,0.8490196078431373f,0.8333333333333335f,0.8176470588235296f,0.8019607843137253f,0.7862745098039214f,0.7705882352941176f,0.7549019607843137f,0.7392156862745098f,0.723529411764706f,0.7078431372549021f,0.6921568627450982f,0.6764705882352944f,0.6607843137254901f,0.6450980392156862f,0.6294117647058823f,0.6137254901960785f,0.5980392156862746f,0.5823529411764707f,0.5666666666666669f,0.5509803921568626f,0.5352941176470587f,0.5196078431372548f,0.503921568627451f,0.4882352941176471f,0.4725490196078432f,0.4568627450980394f,0.4411764705882355f,0.4254901960784316f,0.4098039215686273f,0.3941176470588235f,0.3784313725490196f,0.3627450980392157f,0.3470588235294119f,0.331372549019608f,0.3156862745098041f,0.2999999999999998f,0.284313725490196f,0.2686274509803921f,0.2529411764705882f,0.2372549019607844f,0.2215686274509805f,0.2058823529411766f,0.1901960784313728f,0.1745098039215689f,0.1588235294117646f,0.1431372549019607f,0.1274509803921569f,0.111764705882353f,0.09607843137254912f,0.08039215686274526f,0.06470588235294139f,0.04901960784313708f,0.03333333333333321f,0.01764705882352935f,0.001960784313725483f,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	static const float b2[] = {0.5f,0.5156862745098039f,0.5313725490196078f,0.5470588235294118f,0.5627450980392157f,0.5784313725490196f,0.5941176470588235f,0.6098039215686275f,0.6254901960784314f,0.6411764705882352f,0.6568627450980392f,0.6725490196078432f,0.6882352941176471f,0.7039215686274509f,0.7196078431372549f,0.7352941176470589f,0.7509803921568627f,0.7666666666666666f,0.7823529411764706f,0.7980392156862746f,0.8137254901960784f,0.8294117647058823f,0.8450980392156863f,0.8607843137254902f,0.8764705882352941f,0.892156862745098f,0.907843137254902f,0.9235294117647059f,0.9392156862745098f,0.9549019607843137f,0.9705882352941176f,0.9862745098039216f,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0.9941176470588236f,0.9784313725490197f,0.9627450980392158f,0.9470588235294117f,0.9313725490196079f,0.915686274509804f,0.8999999999999999f,0.884313725490196f,0.8686274509803922f,0.8529411764705883f,0.8372549019607844f,0.8215686274509804f,0.8058823529411765f,0.7901960784313726f,0.7745098039215685f,0.7588235294117647f,0.7431372549019608f,0.7274509803921569f,0.7117647058823531f,0.696078431372549f,0.6803921568627451f,0.6647058823529413f,0.6490196078431372f,0.6333333333333333f,0.6176470588235294f,0.6019607843137256f,0.5862745098039217f,0.5705882352941176f,0.5549019607843138f,0.5392156862745099f,0.5235294117647058f,0.5078431372549019f,0.4921568627450981f,0.4764705882352942f,0.4607843137254903f,0.4450980392156865f,0.4294117647058826f,0.4137254901960783f,0.3980392156862744f,0.3823529411764706f,0.3666666666666667f,0.3509803921568628f,0.335294117647059f,0.3196078431372551f,0.3039215686274508f,0.2882352941176469f,0.2725490196078431f,0.2568627450980392f,0.2411764705882353f,0.2254901960784315f,0.2098039215686276f,0.1941176470588237f,0.1784313725490199f,0.1627450980392156f,0.1470588235294117f,0.1313725490196078f,0.115686274509804f,0.1000000000000001f,0.08431372549019622f,0.06862745098039236f,0.05294117647058805f,0.03725490196078418f,0.02156862745098032f,0.00588235294117645f,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
	// winter
	static const float r3[] = {0.0f, 0.0f,  0.0f, 0.0f,  0.0f, 0.0f,  0.0f, 0.0f,  0.0f, 0.0f,  0.0f};
	static const float g3[] = {0.0f, 0.1f,  0.2f, 0.3f,  0.4f, 0.5f,  0.6f, 0.7f,  0.8f, 0.9f,  1.0f,};
	static const float b3[] = {1.0, 0.95f, 0.9f, 0.85f, 0.8f, 0.75f, 0.7f, 0.65f, 0.6f, 0.55f, 0.5f};
	// rainbow
	static const float r4[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.9365079365079367f, 0.8571428571428572f, 0.7777777777777777f, 0.6984126984126986f, 0.6190476190476191f, 0.53968253968254f, 0.4603174603174605f, 0.3809523809523814f, 0.3015873015873018f, 0.2222222222222223f, 0.1428571428571432f, 0.06349206349206415f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.03174603174603208f, 0.08465608465608465f, 0.1375661375661377f, 0.1904761904761907f, 0.2433862433862437f, 0.2962962962962963f, 0.3492063492063493f, 0.4021164021164023f, 0.4550264550264553f, 0.5079365079365079f, 0.5608465608465609f, 0.6137566137566139f, 0.666666666666667f};
	static const float g4[] = { 0, 0.03968253968253968f, 0.07936507936507936f, 0.119047619047619f, 0.1587301587301587f, 0.1984126984126984f, 0.2380952380952381f, 0.2777777777777778f, 0.3174603174603174f, 0.3571428571428571f, 0.3968253968253968f, 0.4365079365079365f, 0.4761904761904762f, 0.5158730158730158f, 0.5555555555555556f, 0.5952380952380952f, 0.6349206349206349f, 0.6746031746031745f, 0.7142857142857142f, 0.753968253968254f, 0.7936507936507936f, 0.8333333333333333f, 0.873015873015873f, 0.9126984126984127f, 0.9523809523809523f, 0.992063492063492f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.9841269841269842f, 0.9047619047619047f, 0.8253968253968256f, 0.7460317460317465f, 0.666666666666667f, 0.587301587301587f, 0.5079365079365079f, 0.4285714285714288f, 0.3492063492063493f, 0.2698412698412698f, 0.1904761904761907f, 0.1111111111111116f, 0.03174603174603208f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	static const float b4[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.01587301587301582f, 0.09523809523809534f, 0.1746031746031744f, 0.2539682539682535f, 0.333333333333333f, 0.412698412698413f, 0.4920634920634921f, 0.5714285714285712f, 0.6507936507936507f, 0.7301587301587302f, 0.8095238095238093f, 0.8888888888888884f, 0.9682539682539679f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	// ocean
	static const float r5[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.04761904761904762f, 0.09523809523809523f, 0.1428571428571428f, 0.1904761904761905f, 0.2380952380952381f, 0.2857142857142857f, 0.3333333333333333f, 0.3809523809523809f, 0.4285714285714285f, 0.4761904761904762f, 0.5238095238095238f, 0.5714285714285714f, 0.6190476190476191f, 0.6666666666666666f, 0.7142857142857143f, 0.7619047619047619f, 0.8095238095238095f, 0.8571428571428571f, 0.9047619047619048f, 0.9523809523809523f, 1};
	static const float g5[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.02380952380952381f, 0.04761904761904762f, 0.07142857142857142f, 0.09523809523809523f, 0.119047619047619f, 0.1428571428571428f, 0.1666666666666667f, 0.1904761904761905f, 0.2142857142857143f, 0.2380952380952381f, 0.2619047619047619f, 0.2857142857142857f, 0.3095238095238095f, 0.3333333333333333f, 0.3571428571428572f, 0.3809523809523809f, 0.4047619047619048f, 0.4285714285714285f, 0.4523809523809524f, 0.4761904761904762f, 0.5f, 0.5238095238095238f, 0.5476190476190477f, 0.5714285714285714f, 0.5952380952380952f, 0.6190476190476191f, 0.6428571428571429f, 0.6666666666666666f, 0.6904761904761905f, 0.7142857142857143f, 0.7380952380952381f, 0.7619047619047619f, 0.7857142857142857f, 0.8095238095238095f, 0.8333333333333334f, 0.8571428571428571f, 0.8809523809523809f, 0.9047619047619048f, 0.9285714285714286f, 0.9523809523809523f, 0.9761904761904762f, 1};
    static const float b5[] = { 0, 0.01587301587301587f, 0.03174603174603174f, 0.04761904761904762f, 0.06349206349206349f, 0.07936507936507936f, 0.09523809523809523f, 0.1111111111111111f, 0.126984126984127f, 0.1428571428571428f, 0.1587301587301587f, 0.1746031746031746f, 0.1904761904761905f, 0.2063492063492063f, 0.2222222222222222f, 0.2380952380952381f, 0.253968253968254f, 0.2698412698412698f, 0.2857142857142857f, 0.3015873015873016f, 0.3174603174603174f, 0.3333333333333333f, 0.3492063492063492f, 0.3650793650793651f, 0.3809523809523809f, 0.3968253968253968f, 0.4126984126984127f, 0.4285714285714285f, 0.4444444444444444f, 0.4603174603174603f, 0.4761904761904762f, 0.492063492063492f, 0.5079365079365079f, 0.5238095238095238f, 0.5396825396825397f, 0.5555555555555556f, 0.5714285714285714f, 0.5873015873015873f, 0.6031746031746031f, 0.6190476190476191f, 0.6349206349206349f, 0.6507936507936508f, 0.6666666666666666f, 0.6825396825396826f, 0.6984126984126984f, 0.7142857142857143f, 0.7301587301587301f, 0.746031746031746f, 0.7619047619047619f, 0.7777777777777778f, 0.7936507936507936f, 0.8095238095238095f, 0.8253968253968254f, 0.8412698412698413f, 0.8571428571428571f, 0.873015873015873f, 0.8888888888888888f, 0.9047619047619048f, 0.9206349206349206f, 0.9365079365079365f, 0.9523809523809523f, 0.9682539682539683f, 0.9841269841269841f, 1};
	// summer
	static const float r6[] = { 0, 0.01587301587301587f, 0.03174603174603174f, 0.04761904761904762f, 0.06349206349206349f, 0.07936507936507936f, 0.09523809523809523f, 0.1111111111111111f, 0.126984126984127f, 0.1428571428571428f, 0.1587301587301587f, 0.1746031746031746f, 0.1904761904761905f, 0.2063492063492063f, 0.2222222222222222f, 0.2380952380952381f, 0.253968253968254f, 0.2698412698412698f, 0.2857142857142857f, 0.3015873015873016f, 0.3174603174603174f, 0.3333333333333333f, 0.3492063492063492f, 0.3650793650793651f, 0.3809523809523809f, 0.3968253968253968f, 0.4126984126984127f, 0.4285714285714285f, 0.4444444444444444f, 0.4603174603174603f, 0.4761904761904762f, 0.492063492063492f, 0.5079365079365079f, 0.5238095238095238f, 0.5396825396825397f, 0.5555555555555556f, 0.5714285714285714f, 0.5873015873015873f, 0.6031746031746031f, 0.6190476190476191f, 0.6349206349206349f, 0.6507936507936508f, 0.6666666666666666f, 0.6825396825396826f, 0.6984126984126984f, 0.7142857142857143f, 0.7301587301587301f, 0.746031746031746f, 0.7619047619047619f, 0.7777777777777778f, 0.7936507936507936f, 0.8095238095238095f, 0.8253968253968254f, 0.8412698412698413f, 0.8571428571428571f, 0.873015873015873f, 0.8888888888888888f, 0.9047619047619048f, 0.9206349206349206f, 0.9365079365079365f, 0.9523809523809523f, 0.9682539682539683f, 0.9841269841269841f, 1};
	static const float g6[] = { 0.5f, 0.5079365079365079f, 0.5158730158730158f, 0.5238095238095238f, 0.5317460317460317f, 0.5396825396825397f, 0.5476190476190477f, 0.5555555555555556f, 0.5634920634920635f, 0.5714285714285714f, 0.5793650793650793f, 0.5873015873015873f, 0.5952380952380952f, 0.6031746031746031f, 0.6111111111111112f, 0.6190476190476191f, 0.626984126984127f, 0.6349206349206349f, 0.6428571428571428f, 0.6507936507936508f, 0.6587301587301587f, 0.6666666666666666f, 0.6746031746031746f, 0.6825396825396826f, 0.6904761904761905f, 0.6984126984126984f, 0.7063492063492063f, 0.7142857142857143f, 0.7222222222222222f, 0.7301587301587301f, 0.7380952380952381f, 0.746031746031746f, 0.753968253968254f, 0.7619047619047619f, 0.7698412698412698f, 0.7777777777777778f, 0.7857142857142857f, 0.7936507936507937f, 0.8015873015873016f, 0.8095238095238095f, 0.8174603174603174f, 0.8253968253968254f, 0.8333333333333333f, 0.8412698412698413f, 0.8492063492063492f, 0.8571428571428572f, 0.8650793650793651f, 0.873015873015873f, 0.8809523809523809f, 0.8888888888888888f, 0.8968253968253967f, 0.9047619047619048f, 0.9126984126984127f, 0.9206349206349207f, 0.9285714285714286f, 0.9365079365079365f, 0.9444444444444444f, 0.9523809523809523f, 0.9603174603174602f, 0.9682539682539683f, 0.9761904761904762f, 0.9841269841269842f, 0.9920634920634921f, 1};
	static const float b6[] = { 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f, 0.4f};
	// spring
	static const float r7[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	static const float g7[] = { 0, 0.01587301587301587f, 0.03174603174603174f, 0.04761904761904762f, 0.06349206349206349f, 0.07936507936507936f, 0.09523809523809523f, 0.1111111111111111f, 0.126984126984127f, 0.1428571428571428f, 0.1587301587301587f, 0.1746031746031746f, 0.1904761904761905f, 0.2063492063492063f, 0.2222222222222222f, 0.2380952380952381f, 0.253968253968254f, 0.2698412698412698f, 0.2857142857142857f, 0.3015873015873016f, 0.3174603174603174f, 0.3333333333333333f, 0.3492063492063492f, 0.3650793650793651f, 0.3809523809523809f, 0.3968253968253968f, 0.4126984126984127f, 0.4285714285714285f, 0.4444444444444444f, 0.4603174603174603f, 0.4761904761904762f, 0.492063492063492f, 0.5079365079365079f, 0.5238095238095238f, 0.5396825396825397f, 0.5555555555555556f, 0.5714285714285714f, 0.5873015873015873f, 0.6031746031746031f, 0.6190476190476191f, 0.6349206349206349f, 0.6507936507936508f, 0.6666666666666666f, 0.6825396825396826f, 0.6984126984126984f, 0.7142857142857143f, 0.7301587301587301f, 0.746031746031746f, 0.7619047619047619f, 0.7777777777777778f, 0.7936507936507936f, 0.8095238095238095f, 0.8253968253968254f, 0.8412698412698413f, 0.8571428571428571f, 0.873015873015873f, 0.8888888888888888f, 0.9047619047619048f, 0.9206349206349206f, 0.9365079365079365f, 0.9523809523809523f, 0.9682539682539683f, 0.9841269841269841f, 1};
	static const float b7[] = { 1, 0.9841269841269842f, 0.9682539682539683f, 0.9523809523809523f, 0.9365079365079365f, 0.9206349206349207f, 0.9047619047619048f, 0.8888888888888888f, 0.873015873015873f, 0.8571428571428572f, 0.8412698412698413f, 0.8253968253968254f, 0.8095238095238095f, 0.7936507936507937f, 0.7777777777777778f, 0.7619047619047619f, 0.746031746031746f, 0.7301587301587302f, 0.7142857142857143f, 0.6984126984126984f, 0.6825396825396826f, 0.6666666666666667f, 0.6507936507936508f, 0.6349206349206349f, 0.6190476190476191f, 0.6031746031746033f, 0.5873015873015873f, 0.5714285714285714f, 0.5555555555555556f, 0.5396825396825398f, 0.5238095238095238f, 0.5079365079365079f, 0.4920634920634921f, 0.4761904761904762f, 0.4603174603174603f, 0.4444444444444444f, 0.4285714285714286f, 0.4126984126984127f, 0.3968253968253969f, 0.3809523809523809f, 0.3650793650793651f, 0.3492063492063492f, 0.3333333333333334f, 0.3174603174603174f, 0.3015873015873016f, 0.2857142857142857f, 0.2698412698412699f, 0.253968253968254f, 0.2380952380952381f, 0.2222222222222222f, 0.2063492063492064f, 0.1904761904761905f, 0.1746031746031746f, 0.1587301587301587f, 0.1428571428571429f, 0.126984126984127f, 0.1111111111111112f, 0.09523809523809523f, 0.07936507936507942f, 0.06349206349206349f, 0.04761904761904767f, 0.03174603174603174f, 0.01587301587301593f, 0};
	// cool
	static const float r8[] = { 0, 0.01587301587301587f, 0.03174603174603174f, 0.04761904761904762f, 0.06349206349206349f, 0.07936507936507936f, 0.09523809523809523f, 0.1111111111111111f, 0.126984126984127f, 0.1428571428571428f, 0.1587301587301587f, 0.1746031746031746f, 0.1904761904761905f, 0.2063492063492063f, 0.2222222222222222f, 0.2380952380952381f, 0.253968253968254f, 0.2698412698412698f, 0.2857142857142857f, 0.3015873015873016f, 0.3174603174603174f, 0.3333333333333333f, 0.3492063492063492f, 0.3650793650793651f, 0.3809523809523809f, 0.3968253968253968f, 0.4126984126984127f, 0.4285714285714285f, 0.4444444444444444f, 0.4603174603174603f, 0.4761904761904762f, 0.492063492063492f, 0.5079365079365079f, 0.5238095238095238f, 0.5396825396825397f, 0.5555555555555556f, 0.5714285714285714f, 0.5873015873015873f, 0.6031746031746031f, 0.6190476190476191f, 0.6349206349206349f, 0.6507936507936508f, 0.6666666666666666f, 0.6825396825396826f, 0.6984126984126984f, 0.7142857142857143f, 0.7301587301587301f, 0.746031746031746f, 0.7619047619047619f, 0.7777777777777778f, 0.7936507936507936f, 0.8095238095238095f, 0.8253968253968254f, 0.8412698412698413f, 0.8571428571428571f, 0.873015873015873f, 0.8888888888888888f, 0.9047619047619048f, 0.9206349206349206f, 0.9365079365079365f, 0.9523809523809523f, 0.9682539682539683f, 0.9841269841269841f, 1};
	static const float g8[] = { 1, 0.9841269841269842f, 0.9682539682539683f, 0.9523809523809523f, 0.9365079365079365f, 0.9206349206349207f, 0.9047619047619048f, 0.8888888888888888f, 0.873015873015873f, 0.8571428571428572f, 0.8412698412698413f, 0.8253968253968254f, 0.8095238095238095f, 0.7936507936507937f, 0.7777777777777778f, 0.7619047619047619f, 0.746031746031746f, 0.7301587301587302f, 0.7142857142857143f, 0.6984126984126984f, 0.6825396825396826f, 0.6666666666666667f, 0.6507936507936508f, 0.6349206349206349f, 0.6190476190476191f, 0.6031746031746033f, 0.5873015873015873f, 0.5714285714285714f, 0.5555555555555556f, 0.5396825396825398f, 0.5238095238095238f, 0.5079365079365079f, 0.4920634920634921f, 0.4761904761904762f, 0.4603174603174603f, 0.4444444444444444f, 0.4285714285714286f, 0.4126984126984127f, 0.3968253968253969f, 0.3809523809523809f, 0.3650793650793651f, 0.3492063492063492f, 0.3333333333333334f, 0.3174603174603174f, 0.3015873015873016f, 0.2857142857142857f, 0.2698412698412699f, 0.253968253968254f, 0.2380952380952381f, 0.2222222222222222f, 0.2063492063492064f, 0.1904761904761905f, 0.1746031746031746f, 0.1587301587301587f, 0.1428571428571429f, 0.126984126984127f, 0.1111111111111112f, 0.09523809523809523f, 0.07936507936507942f, 0.06349206349206349f, 0.04761904761904767f, 0.03174603174603174f, 0.01587301587301593f, 0};
	static const float b8[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	// hsv
	static const float r9[] = { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.9523809523809526f, 0.8571428571428568f, 0.7619047619047614f, 0.6666666666666665f, 0.5714285714285716f, 0.4761904761904763f, 0.3809523809523805f, 0.2857142857142856f, 0.1904761904761907f, 0.0952380952380949f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.09523809523809557f, 0.1904761904761905f, 0.2857142857142854f, 0.3809523809523809f, 0.4761904761904765f, 0.5714285714285714f, 0.6666666666666663f, 0.7619047619047619f, 0.8571428571428574f, 0.9523809523809523f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	static const float g9[] = { 0, 0.09523809523809523f, 0.1904761904761905f, 0.2857142857142857f, 0.3809523809523809f, 0.4761904761904762f, 0.5714285714285714f, 0.6666666666666666f, 0.7619047619047619f, 0.8571428571428571f, 0.9523809523809523f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.9523809523809526f, 0.8571428571428577f, 0.7619047619047619f, 0.6666666666666665f, 0.5714285714285716f, 0.4761904761904767f, 0.3809523809523814f, 0.2857142857142856f, 0.1904761904761907f, 0.09523809523809579f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0};
	static const float b9[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.09523809523809523f, 0.1904761904761905f, 0.2857142857142857f, 0.3809523809523809f, 0.4761904761904762f, 0.5714285714285714f, 0.6666666666666666f, 0.7619047619047619f, 0.8571428571428571f, 0.9523809523809523f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0.9523809523809526f, 0.8571428571428577f, 0.7619047619047614f, 0.6666666666666665f, 0.5714285714285716f, 0.4761904761904767f, 0.3809523809523805f, 0.2857142857142856f, 0.1904761904761907f, 0.09523809523809579f, 0};
	// pink
	static const float r10[] = { 0, 0.1571348402636772f, 0.2222222222222222f, 0.2721655269759087f, 0.3142696805273544f, 0.3513641844631533f, 0.3849001794597505f, 0.415739709641549f, 0.4444444444444444f, 0.4714045207910317f, 0.4969039949999532f, 0.5211573066470477f, 0.5443310539518174f, 0.5665577237325317f, 0.5879447357921312f, 0.6085806194501846f, 0.6285393610547089f, 0.6478835438717f, 0.6666666666666666f, 0.6849348892187751f, 0.7027283689263065f, 0.7200822998230956f, 0.7370277311900888f, 0.753592220347252f, 0.7663560447348133f, 0.7732293307186413f, 0.7800420555749596f, 0.7867957924694432f, 0.7934920476158722f, 0.8001322641986387f, 0.8067178260046388f, 0.8132500607904444f, 0.8197302434079591f, 0.8261595987094034f, 0.8325393042503717f, 0.8388704928078611f, 0.8451542547285166f, 0.8513916401208816f, 0.8575836609041332f, 0.8637312927246217f, 0.8698354767504924f, 0.8758971213537393f, 0.8819171036881968f, 0.8878962711712378f, 0.8938354428762595f, 0.8997354108424372f, 0.9055969413076769f, 0.9114207758701963f, 0.9172076325837248f, 0.9229582069908971f, 0.9286731730990523f, 0.9343531843023135f, 0.9399988742535192f, 0.9456108576893002f, 0.9511897312113418f, 0.9567360740266436f, 0.9622504486493763f, 0.9677334015667416f, 0.9731854638710686f, 0.9786071518602129f, 0.9839989676081821f, 0.9893613995077727f, 0.9946949227868761f, 1};
	static const float g10[] = { 0, 0.1028688999747279f, 0.1454785934906616f, 0.1781741612749496f, 0.2057377999494559f, 0.2300218531141181f, 0.2519763153394848f, 0.2721655269759087f, 0.2909571869813232f, 0.3086066999241838f, 0.3253000243161777f, 0.3411775438127727f, 0.3563483225498992f, 0.3708990935094579f, 0.3849001794597505f, 0.3984095364447979f, 0.4114755998989117f, 0.4241393401869012f, 0.4364357804719847f, 0.4483951394230328f, 0.4600437062282361f, 0.4714045207910317f, 0.4824979096371639f, 0.4933419132673033f, 0.5091750772173156f, 0.5328701692569688f, 0.5555555555555556f, 0.5773502691896257f, 0.5983516452371671f, 0.6186404847588913f, 0.6382847385042254f, 0.6573421981221795f, 0.6758625033664688f, 0.6938886664887108f, 0.7114582486036499f, 0.7286042804780002f, 0.7453559924999299f, 0.7617394000445604f, 0.7777777777777778f, 0.7934920476158723f, 0.8089010988089465f, 0.8240220541217402f, 0.8388704928078611f, 0.8534606386520677f, 0.8678055195451838f, 0.8819171036881968f, 0.8958064164776166f, 0.9094836413191612f, 0.9172076325837248f, 0.9229582069908971f, 0.9286731730990523f, 0.9343531843023135f, 0.9399988742535192f, 0.9456108576893002f, 0.9511897312113418f, 0.9567360740266436f, 0.9622504486493763f, 0.9677334015667416f, 0.9731854638710686f, 0.9786071518602129f, 0.9839989676081821f, 0.9893613995077727f, 0.9946949227868761f, 1};
	static const float b10[] = { 0, 0.1028688999747279f, 0.1454785934906616f, 0.1781741612749496f, 0.2057377999494559f, 0.2300218531141181f, 0.2519763153394848f, 0.2721655269759087f, 0.2909571869813232f, 0.3086066999241838f, 0.3253000243161777f, 0.3411775438127727f, 0.3563483225498992f, 0.3708990935094579f, 0.3849001794597505f, 0.3984095364447979f, 0.4114755998989117f, 0.4241393401869012f, 0.4364357804719847f, 0.4483951394230328f, 0.4600437062282361f, 0.4714045207910317f, 0.4824979096371639f, 0.4933419132673033f, 0.5039526306789697f, 0.5143444998736397f, 0.5245305283129621f, 0.5345224838248488f, 0.5443310539518174f, 0.5539659798925444f, 0.563436169819011f, 0.5727497953228163f, 0.5819143739626463f, 0.5909368402852788f, 0.5998236072282915f, 0.6085806194501846f, 0.6172133998483676f, 0.6257270902992705f, 0.6341264874742278f, 0.642416074439621f, 0.6506000486323554f, 0.6586823467062358f, 0.6666666666666666f, 0.6745564876468501f, 0.6823550876255453f, 0.6900655593423541f, 0.6976908246297114f, 0.7052336473499384f, 0.7237468644557459f, 0.7453559924999298f, 0.7663560447348133f, 0.7867957924694432f, 0.8067178260046388f, 0.8261595987094034f, 0.8451542547285166f, 0.8637312927246217f, 0.8819171036881968f, 0.8997354108424372f, 0.9172076325837248f, 0.9343531843023135f, 0.9511897312113418f, 0.9677334015667416f, 0.9839989676081821f, 1};
	// hot
	static const float r11[] = { 0, 0.03968253968253968f, 0.07936507936507936f, 0.119047619047619f, 0.1587301587301587f, 0.1984126984126984f, 0.2380952380952381f, 0.2777777777777778f, 0.3174603174603174f, 0.3571428571428571f, 0.3968253968253968f, 0.4365079365079365f, 0.4761904761904762f, 0.5158730158730158f, 0.5555555555555556f, 0.5952380952380952f, 0.6349206349206349f, 0.6746031746031745f, 0.7142857142857142f, 0.753968253968254f, 0.7936507936507936f, 0.8333333333333333f, 0.873015873015873f, 0.9126984126984127f, 0.9523809523809523f, 0.992063492063492f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	static const float g11[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.03174603174603163f, 0.0714285714285714f, 0.1111111111111112f, 0.1507936507936507f, 0.1904761904761905f, 0.23015873015873f, 0.2698412698412698f, 0.3095238095238093f, 0.3492063492063491f, 0.3888888888888888f, 0.4285714285714284f, 0.4682539682539679f, 0.5079365079365079f, 0.5476190476190477f, 0.5873015873015872f, 0.6269841269841268f, 0.6666666666666665f, 0.7063492063492065f, 0.746031746031746f, 0.7857142857142856f, 0.8253968253968254f, 0.8650793650793651f, 0.9047619047619047f, 0.9444444444444442f, 0.984126984126984f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
	static const float b11[] = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0.04761904761904745f, 0.1269841269841265f, 0.2063492063492056f, 0.2857142857142856f, 0.3650793650793656f, 0.4444444444444446f, 0.5238095238095237f, 0.6031746031746028f, 0.6825396825396828f, 0.7619047619047619f, 0.8412698412698409f, 0.92063492063492f, 1};
	// parula
	static const float r12[] = { 0.2078f, 0.0118f, 0.0784f, 0.0235f, 0.2196f, 0.5725f, 0.8510f, 0.9882f, 0.9765f };
	static const float g12[] = { 0.1647f, 0.3882f, 0.5216f, 0.6549f, 0.7255f, 0.7490f, 0.7294f, 0.8078f, 0.9843f };
	static const float b12[] = { 0.5294f, 0.8824f, 0.8314f, 0.7765f, 0.6196f, 0.4510f, 0.3373f, 0.1804f, 0.0549f };
	// magma
	static const float r13[] = { 0.001462f, 0.002258f, 0.003279f, 0.004512f, 0.005950f, 0.007588f, 0.009426f, 0.011465f, 0.013708f, 0.016156f, 0.018815f, 0.021692f, 0.024792f, 0.028123f, 0.031696f, 0.035520f, 0.039608f, 0.043830f, 0.048062f, 0.052320f, 0.056615f, 0.060949f, 0.065330f, 0.069764f, 0.074257f, 0.078815f, 0.083446f, 0.088155f, 0.092949f, 0.097833f, 0.102815f, 0.107899f, 0.113094f, 0.118405f, 0.123833f, 0.129380f, 0.135053f, 0.140858f, 0.146785f, 0.152839f, 0.159018f, 0.165308f, 0.171713f, 0.178212f, 0.184801f, 0.191460f, 0.198177f, 0.204935f, 0.211718f, 0.218512f, 0.225302f, 0.232077f, 0.238826f, 0.245543f, 0.252220f, 0.258857f, 0.265447f, 0.271994f, 0.278493f, 0.284951f, 0.291366f, 0.297740f, 0.304081f, 0.310382f, 0.316654f, 0.322899f, 0.329114f, 0.335308f, 0.341482f, 0.347636f, 0.353773f, 0.359898f, 0.366012f, 0.372116f, 0.378211f, 0.384299f, 0.390384f, 0.396467f, 0.402548f, 0.408629f, 0.414709f, 0.420791f, 0.426877f, 0.432967f, 0.439062f, 0.445163f, 0.451271f, 0.457386f, 0.463508f, 0.469640f, 0.475780f, 0.481929f, 0.488088f, 0.494258f, 0.500438f, 0.506629f, 0.512831f, 0.519045f, 0.525270f, 0.531507f, 0.537755f, 0.544015f, 0.550287f, 0.556571f, 0.562866f, 0.569172f, 0.575490f, 0.581819f, 0.588158f, 0.594508f, 0.600868f, 0.607238f, 0.613617f, 0.620005f, 0.626401f, 0.632805f, 0.639216f, 0.645633f, 0.652056f, 0.658483f, 0.664915f, 0.671349f, 0.677786f, 0.684224f, 0.690661f, 0.697098f, 0.703532f, 0.709962f, 0.716387f, 0.722805f, 0.729216f, 0.735616f, 0.742004f, 0.748378f, 0.754737f, 0.761077f, 0.767398f, 0.773695f, 0.779968f, 0.786212f, 0.792427f, 0.798608f, 0.804752f, 0.810855f, 0.816914f, 0.822926f, 0.828886f, 0.834791f, 0.840636f, 0.846416f, 0.852126f, 0.857763f, 0.863320f, 0.868793f, 0.874176f, 0.879464f, 0.884651f, 0.889731f, 0.894700f, 0.899552f, 0.904281f, 0.908884f, 0.913354f, 0.917689f, 0.921884f, 0.925937f, 0.929845f, 0.933606f, 0.937221f, 0.940687f, 0.944006f, 0.947180f, 0.950210f, 0.953099f, 0.955849f, 0.958464f, 0.960949f, 0.963310f, 0.965549f, 0.967671f, 0.969680f, 0.971582f, 0.973381f, 0.975082f, 0.976690f, 0.978210f, 0.979645f, 0.981000f, 0.982279f, 0.983485f, 0.984622f, 0.985693f, 0.986700f, 0.987646f, 0.988533f, 0.989363f, 0.990138f, 0.990871f, 0.991558f, 0.992196f, 0.992785f, 0.993326f, 0.993834f, 0.994309f, 0.994738f, 0.995122f, 0.995480f, 0.995810f, 0.996096f, 0.996341f, 0.996580f, 0.996775f, 0.996925f, 0.997077f, 0.997186f, 0.997254f, 0.997325f, 0.997351f, 0.997351f, 0.997341f, 0.997285f, 0.997228f, 0.997138f, 0.997019f, 0.996898f, 0.996727f, 0.996571f, 0.996369f, 0.996162f, 0.995932f, 0.995680f, 0.995424f, 0.995131f, 0.994851f, 0.994524f, 0.994222f, 0.993866f, 0.993545f, 0.993170f, 0.992831f, 0.992440f, 0.992089f, 0.991688f, 0.991332f, 0.990930f, 0.990570f, 0.990175f, 0.989815f, 0.989434f, 0.989077f, 0.988717f, 0.988367f, 0.988033f, 0.987691f, 0.987387f, 0.987053f };
	static const float g13[] = { 0.000466f, 0.001295f, 0.002305f, 0.003490f, 0.004843f, 0.006356f, 0.008022f, 0.009828f, 0.011771f, 0.013840f, 0.016026f, 0.018320f, 0.020715f, 0.023201f, 0.025765f, 0.028397f, 0.031090f, 0.033830f, 0.036607f, 0.039407f, 0.042160f, 0.044794f, 0.047318f, 0.049726f, 0.052017f, 0.054184f, 0.056225f, 0.058133f, 0.059904f, 0.061531f, 0.063010f, 0.064335f, 0.065492f, 0.066479f, 0.067295f, 0.067935f, 0.068391f, 0.068654f, 0.068738f, 0.068637f, 0.068354f, 0.067911f, 0.067305f, 0.066576f, 0.065732f, 0.064818f, 0.063862f, 0.062907f, 0.061992f, 0.061158f, 0.060445f, 0.059889f, 0.059517f, 0.059352f, 0.059415f, 0.059706f, 0.060237f, 0.060994f, 0.061978f, 0.063168f, 0.064553f, 0.066117f, 0.067835f, 0.069702f, 0.071690f, 0.073782f, 0.075972f, 0.078236f, 0.080564f, 0.082946f, 0.085373f, 0.087831f, 0.090314f, 0.092816f, 0.095332f, 0.097855f, 0.100379f, 0.102902f, 0.105420f, 0.107930f, 0.110431f, 0.112920f, 0.115395f, 0.117855f, 0.120298f, 0.122724f, 0.125132f, 0.127522f, 0.129893f, 0.132245f, 0.134577f, 0.136891f, 0.139186f, 0.141462f, 0.143719f, 0.145958f, 0.148179f, 0.150383f, 0.152569f, 0.154739f, 0.156894f, 0.159033f, 0.161158f, 0.163269f, 0.165368f, 0.167454f, 0.169530f, 0.171596f, 0.173652f, 0.175701f, 0.177743f, 0.179779f, 0.181811f, 0.183840f, 0.185867f, 0.187893f, 0.189921f, 0.191952f, 0.193986f, 0.196027f, 0.198075f, 0.200133f, 0.202203f, 0.204286f, 0.206384f, 0.208501f, 0.210638f, 0.212797f, 0.214982f, 0.217194f, 0.219437f, 0.221713f, 0.224025f, 0.226377f, 0.228772f, 0.231214f, 0.233705f, 0.236249f, 0.238851f, 0.241514f, 0.244242f, 0.247040f, 0.249911f, 0.252861f, 0.255895f, 0.259016f, 0.262229f, 0.265540f, 0.268953f, 0.272473f, 0.276106f, 0.279857f, 0.283729f, 0.287728f, 0.291859f, 0.296125f, 0.300530f, 0.305079f, 0.309773f, 0.314616f, 0.319610f, 0.324755f, 0.330052f, 0.335500f, 0.341098f, 0.346844f, 0.352734f, 0.358764f, 0.364929f, 0.371224f, 0.377643f, 0.384178f, 0.390820f, 0.397563f, 0.404400f, 0.411324f, 0.418323f, 0.425390f, 0.432519f, 0.439703f, 0.446936f, 0.454210f, 0.461520f, 0.468861f, 0.476226f, 0.483612f, 0.491014f, 0.498428f, 0.505851f, 0.513280f, 0.520713f, 0.528148f, 0.535582f, 0.543015f, 0.550446f, 0.557873f, 0.565296f, 0.572706f, 0.580107f, 0.587502f, 0.594891f, 0.602275f, 0.609644f, 0.616999f, 0.624350f, 0.631696f, 0.639027f, 0.646344f, 0.653659f, 0.660969f, 0.668256f, 0.675541f, 0.682828f, 0.690088f, 0.697349f, 0.704611f, 0.711848f, 0.719089f, 0.726324f, 0.733545f, 0.740772f, 0.747981f, 0.755190f, 0.762398f, 0.769591f, 0.776795f, 0.783977f, 0.791167f, 0.798348f, 0.805527f, 0.812706f, 0.819875f, 0.827052f, 0.834213f, 0.841387f, 0.848540f, 0.855711f, 0.862859f, 0.870024f, 0.877168f, 0.884330f, 0.891470f, 0.898627f, 0.905763f, 0.912915f, 0.920049f, 0.927196f, 0.934329f, 0.941470f, 0.948604f, 0.955742f, 0.962878f, 0.970012f, 0.977154f, 0.984288f, 0.991438f };
	static const float b13[] = { 0.013866f, 0.018331f, 0.023708f, 0.029965f, 0.037130f, 0.044973f, 0.052844f, 0.060750f, 0.068667f, 0.076603f, 0.084584f, 0.092610f, 0.100676f, 0.108787f, 0.116965f, 0.125209f, 0.133515f, 0.141886f, 0.150327f, 0.158841f, 0.167446f, 0.176129f, 0.184892f, 0.193735f, 0.202660f, 0.211667f, 0.220755f, 0.229922f, 0.239164f, 0.248477f, 0.257854f, 0.267289f, 0.276784f, 0.286321f, 0.295879f, 0.305443f, 0.315000f, 0.324538f, 0.334011f, 0.343404f, 0.352688f, 0.361816f, 0.370771f, 0.379497f, 0.387973f, 0.396152f, 0.404009f, 0.411514f, 0.418647f, 0.425392f, 0.431742f, 0.437695f, 0.443256f, 0.448436f, 0.453248f, 0.457710f, 0.461840f, 0.465660f, 0.469190f, 0.472451f, 0.475462f, 0.478243f, 0.480812f, 0.483186f, 0.485380f, 0.487408f, 0.489287f, 0.491024f, 0.492631f, 0.494121f, 0.495501f, 0.496778f, 0.497960f, 0.499053f, 0.500067f, 0.501002f, 0.501864f, 0.502658f, 0.503386f, 0.504052f, 0.504662f, 0.505215f, 0.505714f, 0.506160f, 0.506555f, 0.506901f, 0.507198f, 0.507448f, 0.507652f, 0.507809f, 0.507921f, 0.507989f, 0.508011f, 0.507988f, 0.507920f, 0.507806f, 0.507648f, 0.507443f, 0.507192f, 0.506895f, 0.506551f, 0.506159f, 0.505719f, 0.505230f, 0.504692f, 0.504105f, 0.503466f, 0.502777f, 0.502035f, 0.501241f, 0.500394f, 0.499492f, 0.498536f, 0.497524f, 0.496456f, 0.495332f, 0.494150f, 0.492910f, 0.491611f, 0.490253f, 0.488836f, 0.487358f, 0.485819f, 0.484219f, 0.482558f, 0.480835f, 0.479049f, 0.477201f, 0.475290f, 0.473316f, 0.471279f, 0.469180f, 0.467018f, 0.464794f, 0.462509f, 0.460162f, 0.457755f, 0.455289f, 0.452765f, 0.450184f, 0.447543f, 0.444848f, 0.442102f, 0.439305f, 0.436461f, 0.433573f, 0.430644f, 0.427671f, 0.424666f, 0.421631f, 0.418573f, 0.415496f, 0.412403f, 0.409303f, 0.406205f, 0.403118f, 0.400047f, 0.397002f, 0.393995f, 0.391037f, 0.388137f, 0.385308f, 0.382563f, 0.379915f, 0.377376f, 0.374959f, 0.372677f, 0.370541f, 0.368567f, 0.366762f, 0.365136f, 0.363701f, 0.362468f, 0.361438f, 0.360619f, 0.360014f, 0.359630f, 0.359469f, 0.359529f, 0.359810f, 0.360311f, 0.361030f, 0.361965f, 0.363111f, 0.364466f, 0.366025f, 0.367783f, 0.369734f, 0.371874f, 0.374198f, 0.376698f, 0.379371f, 0.382210f, 0.385210f, 0.388365f, 0.391671f, 0.395122f, 0.398714f, 0.402441f, 0.406299f, 0.410283f, 0.414390f, 0.418613f, 0.422950f, 0.427397f, 0.431951f, 0.436607f, 0.441361f, 0.446213f, 0.451160f, 0.456192f, 0.461314f, 0.466526f, 0.471811f, 0.477182f, 0.482635f, 0.488154f, 0.493755f, 0.499428f, 0.505167f, 0.510983f, 0.516859f, 0.522806f, 0.528821f, 0.534892f, 0.541039f, 0.547233f, 0.553499f, 0.559820f, 0.566202f, 0.572645f, 0.579140f, 0.585701f, 0.592307f, 0.598983f, 0.605696f, 0.612482f, 0.619299f, 0.626189f, 0.633109f, 0.640099f, 0.647116f, 0.654202f, 0.661309f, 0.668481f, 0.675675f, 0.682926f, 0.690198f, 0.697519f, 0.704863f, 0.712242f, 0.719649f, 0.727077f, 0.734536f, 0.742002f, 0.749504f };
	// inferno
	static const float r14[] = { 0.001462f, 0.002267f, 0.003299f, 0.004547f, 0.006006f, 0.007676f, 0.009561f, 0.011663f, 0.013995f, 0.016561f, 0.019373f, 0.022447f, 0.025793f, 0.029432f, 0.033385f, 0.037668f, 0.042253f, 0.046915f, 0.051644f, 0.056449f, 0.061340f, 0.066331f, 0.071429f, 0.076637f, 0.081962f, 0.087411f, 0.092990f, 0.098702f, 0.104551f, 0.110536f, 0.116656f, 0.122908f, 0.129285f, 0.135778f, 0.142378f, 0.149073f, 0.155850f, 0.162689f, 0.169575f, 0.176493f, 0.183429f, 0.190367f, 0.197297f, 0.204209f, 0.211095f, 0.217949f, 0.224763f, 0.231538f, 0.238273f, 0.244967f, 0.251620f, 0.258234f, 0.264810f, 0.271347f, 0.277850f, 0.284321f, 0.290763f, 0.297178f, 0.303568f, 0.309935f, 0.316282f, 0.322610f, 0.328921f, 0.335217f, 0.341500f, 0.347771f, 0.354032f, 0.360284f, 0.366529f, 0.372768f, 0.379001f, 0.385228f, 0.391453f, 0.397674f, 0.403894f, 0.410113f, 0.416331f, 0.422549f, 0.428768f, 0.434987f, 0.441207f, 0.447428f, 0.453651f, 0.459875f, 0.466100f, 0.472328f, 0.478558f, 0.484789f, 0.491022f, 0.497257f, 0.503493f, 0.509730f, 0.515967f, 0.522206f, 0.528444f, 0.534683f, 0.540920f, 0.547157f, 0.553392f, 0.559624f, 0.565854f, 0.572081f, 0.578304f, 0.584521f, 0.590734f, 0.596940f, 0.603139f, 0.609330f, 0.615513f, 0.621685f, 0.627847f, 0.633998f, 0.640135f, 0.646260f, 0.652369f, 0.658463f, 0.664540f, 0.670599f, 0.676638f, 0.682656f, 0.688653f, 0.694627f, 0.700576f, 0.706500f, 0.712396f, 0.718264f, 0.724103f, 0.729909f, 0.735683f, 0.741423f, 0.747127f, 0.752794f, 0.758422f, 0.764010f, 0.769556f, 0.775059f, 0.780517f, 0.785929f, 0.791293f, 0.796607f, 0.801871f, 0.807082f, 0.812239f, 0.817341f, 0.822386f, 0.827372f, 0.832299f, 0.837165f, 0.841969f, 0.846709f, 0.851384f, 0.855992f, 0.860533f, 0.865006f, 0.869409f, 0.873741f, 0.878001f, 0.882188f, 0.886302f, 0.890341f, 0.894305f, 0.898192f, 0.902003f, 0.905735f, 0.909390f, 0.912966f, 0.916462f, 0.919879f, 0.923215f, 0.926470f, 0.929644f, 0.932737f, 0.935747f, 0.938675f, 0.941521f, 0.944285f, 0.946965f, 0.949562f, 0.952075f, 0.954506f, 0.956852f, 0.959114f, 0.961293f, 0.963387f, 0.965397f, 0.967322f, 0.969163f, 0.970919f, 0.972590f, 0.974176f, 0.975677f, 0.977092f, 0.978422f, 0.979666f, 0.980824f, 0.981895f, 0.982881f, 0.983779f, 0.984591f, 0.985315f, 0.985952f, 0.986502f, 0.986964f, 0.987337f, 0.987622f, 0.987819f, 0.987926f, 0.987945f, 0.987874f, 0.987714f, 0.987464f, 0.987124f, 0.986694f, 0.986175f, 0.985566f, 0.984865f, 0.984075f, 0.983196f, 0.982228f, 0.981173f, 0.980032f, 0.978806f, 0.977497f, 0.976108f, 0.974638f, 0.973088f, 0.971468f, 0.969783f, 0.968041f, 0.966243f, 0.964394f, 0.962517f, 0.960626f, 0.958720f, 0.956834f, 0.954997f, 0.953215f, 0.951546f, 0.950018f, 0.948683f, 0.947594f, 0.946809f, 0.946392f, 0.946403f, 0.946903f, 0.947937f, 0.949545f, 0.951740f, 0.954529f, 0.957896f, 0.961812f, 0.966249f, 0.971162f, 0.976511f, 0.982257f, 0.988362f };
	static const float g14[] = { 0.000466f, 0.001270f, 0.002249f, 0.003392f, 0.004692f, 0.006136f, 0.007713f, 0.009417f, 0.011225f, 0.013136f, 0.015133f, 0.017199f, 0.019331f, 0.021503f, 0.023702f, 0.025921f, 0.028139f, 0.030324f, 0.032474f, 0.034569f, 0.036590f, 0.038504f, 0.040294f, 0.041905f, 0.043328f, 0.044556f, 0.045583f, 0.046402f, 0.047008f, 0.047399f, 0.047574f, 0.047536f, 0.047293f, 0.046856f, 0.046242f, 0.045468f, 0.044559f, 0.043554f, 0.042489f, 0.041402f, 0.040329f, 0.039309f, 0.038400f, 0.037632f, 0.037030f, 0.036615f, 0.036405f, 0.036405f, 0.036621f, 0.037055f, 0.037705f, 0.038571f, 0.039647f, 0.040922f, 0.042353f, 0.043933f, 0.045644f, 0.047470f, 0.049396f, 0.051407f, 0.053490f, 0.055634f, 0.057827f, 0.060060f, 0.062325f, 0.064616f, 0.066925f, 0.069247f, 0.071579f, 0.073915f, 0.076253f, 0.078591f, 0.080927f, 0.083257f, 0.085580f, 0.087896f, 0.090203f, 0.092501f, 0.094790f, 0.097069f, 0.099338f, 0.101597f, 0.103848f, 0.106089f, 0.108322f, 0.110547f, 0.112764f, 0.114974f, 0.117179f, 0.119379f, 0.121575f, 0.123769f, 0.125960f, 0.128150f, 0.130341f, 0.132534f, 0.134729f, 0.136929f, 0.139134f, 0.141346f, 0.143567f, 0.145797f, 0.148039f, 0.150294f, 0.152563f, 0.154848f, 0.157151f, 0.159474f, 0.161817f, 0.164184f, 0.166575f, 0.168992f, 0.171438f, 0.173914f, 0.176421f, 0.178962f, 0.181539f, 0.184153f, 0.186807f, 0.189501f, 0.192239f, 0.195021f, 0.197851f, 0.200728f, 0.203656f, 0.206636f, 0.209670f, 0.212759f, 0.215906f, 0.219112f, 0.222378f, 0.225706f, 0.229097f, 0.232554f, 0.236077f, 0.239667f, 0.243327f, 0.247056f, 0.250856f, 0.254728f, 0.258674f, 0.262692f, 0.266786f, 0.270954f, 0.275197f, 0.279517f, 0.283913f, 0.288385f, 0.292933f, 0.297559f, 0.302260f, 0.307038f, 0.311892f, 0.316822f, 0.321827f, 0.326906f, 0.332060f, 0.337287f, 0.342586f, 0.347957f, 0.353399f, 0.358911f, 0.364492f, 0.370140f, 0.375856f, 0.381636f, 0.387481f, 0.393389f, 0.399359f, 0.405389f, 0.411479f, 0.417627f, 0.423831f, 0.430091f, 0.436405f, 0.442772f, 0.449191f, 0.455660f, 0.462178f, 0.468744f, 0.475356f, 0.482014f, 0.488716f, 0.495462f, 0.502249f, 0.509078f, 0.515946f, 0.522853f, 0.529798f, 0.536780f, 0.543798f, 0.550850f, 0.557937f, 0.565057f, 0.572209f, 0.579392f, 0.586606f, 0.593849f, 0.601122f, 0.608422f, 0.615750f, 0.623105f, 0.630485f, 0.637890f, 0.645320f, 0.652773f, 0.660250f, 0.667748f, 0.675267f, 0.682807f, 0.690366f, 0.697944f, 0.705540f, 0.713153f, 0.720782f, 0.728427f, 0.736087f, 0.743758f, 0.751442f, 0.759135f, 0.766837f, 0.774545f, 0.782258f, 0.789974f, 0.797692f, 0.805409f, 0.813122f, 0.820825f, 0.828515f, 0.836191f, 0.843848f, 0.851476f, 0.859069f, 0.866624f, 0.874129f, 0.881569f, 0.888942f, 0.896226f, 0.903409f, 0.910473f, 0.917399f, 0.924168f, 0.930761f, 0.937159f, 0.943348f, 0.949318f, 0.955063f, 0.960587f, 0.965896f, 0.971003f, 0.975924f, 0.980678f, 0.985282f, 0.989753f, 0.994109f, 0.998364f };
	static const float b14[] = { 0.013866f, 0.018570f, 0.024239f, 0.030909f, 0.038558f, 0.046836f, 0.055143f, 0.063460f, 0.071862f, 0.080282f, 0.088767f, 0.097327f, 0.105930f, 0.114621f, 0.123397f, 0.132232f, 0.141141f, 0.150164f, 0.159254f, 0.168414f, 0.177642f, 0.186962f, 0.196354f, 0.205799f, 0.215289f, 0.224813f, 0.234358f, 0.243904f, 0.253430f, 0.262912f, 0.272321f, 0.281624f, 0.290788f, 0.299776f, 0.308553f, 0.317085f, 0.325338f, 0.333277f, 0.340874f, 0.348111f, 0.354971f, 0.361447f, 0.367535f, 0.373238f, 0.378563f, 0.383522f, 0.388129f, 0.392400f, 0.396353f, 0.400007f, 0.403378f, 0.406485f, 0.409345f, 0.411976f, 0.414392f, 0.416608f, 0.418637f, 0.420491f, 0.422182f, 0.423721f, 0.425116f, 0.426377f, 0.427511f, 0.428524f, 0.429425f, 0.430217f, 0.430906f, 0.431497f, 0.431994f, 0.432400f, 0.432719f, 0.432955f, 0.433109f, 0.433183f, 0.433179f, 0.433098f, 0.432943f, 0.432714f, 0.432412f, 0.432039f, 0.431594f, 0.431080f, 0.430498f, 0.429846f, 0.429125f, 0.428334f, 0.427475f, 0.426548f, 0.425552f, 0.424488f, 0.423356f, 0.422156f, 0.420887f, 0.419549f, 0.418142f, 0.416667f, 0.415123f, 0.413511f, 0.411829f, 0.410078f, 0.408258f, 0.406369f, 0.404411f, 0.402385f, 0.400290f, 0.398125f, 0.395891f, 0.393589f, 0.391219f, 0.388781f, 0.386276f, 0.383704f, 0.381065f, 0.378359f, 0.375586f, 0.372748f, 0.369846f, 0.366879f, 0.363849f, 0.360757f, 0.357603f, 0.354388f, 0.351113f, 0.347777f, 0.344383f, 0.340931f, 0.337424f, 0.333861f, 0.330245f, 0.326576f, 0.322856f, 0.319085f, 0.315266f, 0.311399f, 0.307485f, 0.303526f, 0.299523f, 0.295477f, 0.291390f, 0.287264f, 0.283099f, 0.278898f, 0.274661f, 0.270390f, 0.266085f, 0.261750f, 0.257383f, 0.252988f, 0.248564f, 0.244113f, 0.239636f, 0.235133f, 0.230606f, 0.226055f, 0.221482f, 0.216886f, 0.212268f, 0.207628f, 0.202968f, 0.198286f, 0.193584f, 0.188860f, 0.184116f, 0.179350f, 0.174563f, 0.169755f, 0.164924f, 0.160070f, 0.155193f, 0.150292f, 0.145367f, 0.140417f, 0.135440f, 0.130438f, 0.125409f, 0.120354f, 0.115272f, 0.110164f, 0.105031f, 0.099874f, 0.094695f, 0.089499f, 0.084289f, 0.079073f, 0.073859f, 0.068659f, 0.063488f, 0.058367f, 0.053324f, 0.048392f, 0.043618f, 0.039050f, 0.034931f, 0.031409f, 0.028508f, 0.026250f, 0.024661f, 0.023770f, 0.023606f, 0.024202f, 0.025592f, 0.027814f, 0.030908f, 0.034916f, 0.039886f, 0.045581f, 0.051750f, 0.058329f, 0.065257f, 0.072489f, 0.079990f, 0.087731f, 0.095694f, 0.103863f, 0.112229f, 0.120785f, 0.129527f, 0.138453f, 0.147565f, 0.156863f, 0.166353f, 0.176037f, 0.185923f, 0.196018f, 0.206332f, 0.216877f, 0.227658f, 0.238686f, 0.249972f, 0.261534f, 0.273391f, 0.285546f, 0.298010f, 0.310820f, 0.323974f, 0.337475f, 0.351369f, 0.365627f, 0.380271f, 0.395289f, 0.410665f, 0.426373f, 0.442367f, 0.458592f, 0.474970f, 0.491426f, 0.507860f, 0.524203f, 0.540361f, 0.556275f, 0.571925f, 0.587206f, 0.602154f, 0.616760f, 0.631017f, 0.644924f };
	// plasma
	static const float r15[] = { 0.050383f, 0.063536f, 0.075353f, 0.086222f, 0.096379f, 0.105980f, 0.115124f, 0.123903f, 0.132381f, 0.140603f, 0.148607f, 0.156421f, 0.164070f, 0.171574f, 0.178950f, 0.186213f, 0.193374f, 0.200445f, 0.207435f, 0.214350f, 0.221197f, 0.227983f, 0.234715f, 0.241396f, 0.248032f, 0.254627f, 0.261183f, 0.267703f, 0.274191f, 0.280648f, 0.287076f, 0.293478f, 0.299855f, 0.306210f, 0.312543f, 0.318856f, 0.325150f, 0.331426f, 0.337683f, 0.343925f, 0.350150f, 0.356359f, 0.362553f, 0.368733f, 0.374897f, 0.381047f, 0.387183f, 0.393304f, 0.399411f, 0.405503f, 0.411580f, 0.417642f, 0.423689f, 0.429719f, 0.435734f, 0.441732f, 0.447714f, 0.453677f, 0.459623f, 0.465550f, 0.471457f, 0.477344f, 0.483210f, 0.489055f, 0.494877f, 0.500678f, 0.506454f, 0.512206f, 0.517933f, 0.523633f, 0.529306f, 0.534952f, 0.540570f, 0.546157f, 0.551715f, 0.557243f, 0.562738f, 0.568201f, 0.573632f, 0.579029f, 0.584391f, 0.589719f, 0.595011f, 0.600266f, 0.605485f, 0.610667f, 0.615812f, 0.620919f, 0.625987f, 0.631017f, 0.636008f, 0.640959f, 0.645872f, 0.650746f, 0.655580f, 0.660374f, 0.665129f, 0.669845f, 0.674522f, 0.679160f, 0.683758f, 0.688318f, 0.692840f, 0.697324f, 0.701769f, 0.706178f, 0.710549f, 0.714883f, 0.719181f, 0.723444f, 0.727670f, 0.731862f, 0.736019f, 0.740143f, 0.744232f, 0.748289f, 0.752312f, 0.756304f, 0.760264f, 0.764193f, 0.768090f, 0.771958f, 0.775796f, 0.779604f, 0.783383f, 0.787133f, 0.790855f, 0.794549f, 0.798216f, 0.801855f, 0.805467f, 0.809052f, 0.812612f, 0.816144f, 0.819651f, 0.823132f, 0.826588f, 0.830018f, 0.833422f, 0.836801f, 0.840155f, 0.843484f, 0.846788f, 0.850066f, 0.853319f, 0.856547f, 0.859750f, 0.862927f, 0.866078f, 0.869203f, 0.872303f, 0.875376f, 0.878423f, 0.881443f, 0.884436f, 0.887402f, 0.890340f, 0.893250f, 0.896131f, 0.898984f, 0.901807f, 0.904601f, 0.907365f, 0.910098f, 0.912800f, 0.915471f, 0.918109f, 0.920714f, 0.923287f, 0.925825f, 0.928329f, 0.930798f, 0.933232f, 0.935630f, 0.937990f, 0.940313f, 0.942598f, 0.944844f, 0.947051f, 0.949217f, 0.951344f, 0.953428f, 0.955470f, 0.957469f, 0.959424f, 0.961336f, 0.963203f, 0.965024f, 0.966798f, 0.968526f, 0.970205f, 0.971835f, 0.973416f, 0.974947f, 0.976428f, 0.977856f, 0.979233f, 0.980556f, 0.981826f, 0.983041f, 0.984199f, 0.985301f, 0.986345f, 0.987332f, 0.988260f, 0.989128f, 0.989935f, 0.990681f, 0.991365f, 0.991985f, 0.992541f, 0.993032f, 0.993456f, 0.993814f, 0.994103f, 0.994324f, 0.994474f, 0.994553f, 0.994561f, 0.994495f, 0.994355f, 0.994141f, 0.993851f, 0.993482f, 0.993033f, 0.992505f, 0.991897f, 0.991209f, 0.990439f, 0.989587f, 0.988648f, 0.987621f, 0.986509f, 0.985314f, 0.984031f, 0.982653f, 0.981190f, 0.979644f, 0.977995f, 0.976265f, 0.974443f, 0.972530f, 0.970533f, 0.968443f, 0.966271f, 0.964021f, 0.961681f, 0.959276f, 0.956808f, 0.954287f, 0.951726f, 0.949151f, 0.946602f, 0.944152f, 0.941896f, 0.940015f };
	static const float g15[] = { 0.029803f, 0.028426f, 0.027206f, 0.026125f, 0.025165f, 0.024309f, 0.023556f, 0.022878f, 0.022258f, 0.021687f, 0.021154f, 0.020651f, 0.020171f, 0.019706f, 0.019252f, 0.018803f, 0.018354f, 0.017902f, 0.017442f, 0.016973f, 0.016497f, 0.016007f, 0.015502f, 0.014979f, 0.014439f, 0.013882f, 0.013308f, 0.012716f, 0.012109f, 0.011488f, 0.010855f, 0.010213f, 0.009561f, 0.008902f, 0.008239f, 0.007576f, 0.006915f, 0.006261f, 0.005618f, 0.004991f, 0.004382f, 0.003798f, 0.003243f, 0.002724f, 0.002245f, 0.001814f, 0.001434f, 0.001114f, 0.000859f, 0.000678f, 0.000577f, 0.000564f, 0.000646f, 0.000831f, 0.001127f, 0.001540f, 0.002080f, 0.002755f, 0.003574f, 0.004545f, 0.005678f, 0.006980f, 0.008460f, 0.010127f, 0.011990f, 0.014055f, 0.016333f, 0.018833f, 0.021563f, 0.024532f, 0.027747f, 0.031217f, 0.034950f, 0.038954f, 0.043136f, 0.047331f, 0.051545f, 0.055778f, 0.060028f, 0.064296f, 0.068579f, 0.072878f, 0.077190f, 0.081516f, 0.085854f, 0.090204f, 0.094564f, 0.098934f, 0.103312f, 0.107699f, 0.112092f, 0.116492f, 0.120898f, 0.125309f, 0.129725f, 0.134144f, 0.138566f, 0.142992f, 0.147419f, 0.151848f, 0.156278f, 0.160709f, 0.165141f, 0.169573f, 0.174005f, 0.178437f, 0.182868f, 0.187299f, 0.191729f, 0.196158f, 0.200586f, 0.205013f, 0.209439f, 0.213864f, 0.218288f, 0.222711f, 0.227133f, 0.231555f, 0.235976f, 0.240396f, 0.244817f, 0.249237f, 0.253658f, 0.258078f, 0.262500f, 0.266922f, 0.271345f, 0.275770f, 0.280197f, 0.284626f, 0.289057f, 0.293491f, 0.297928f, 0.302368f, 0.306812f, 0.311261f, 0.315714f, 0.320172f, 0.324635f, 0.329105f, 0.333580f, 0.338062f, 0.342551f, 0.347048f, 0.351553f, 0.356066f, 0.360588f, 0.365119f, 0.369660f, 0.374212f, 0.378774f, 0.383347f, 0.387932f, 0.392529f, 0.397139f, 0.401762f, 0.406398f, 0.411048f, 0.415712f, 0.420392f, 0.425087f, 0.429797f, 0.434524f, 0.439268f, 0.444029f, 0.448807f, 0.453603f, 0.458417f, 0.463251f, 0.468103f, 0.472975f, 0.477867f, 0.482780f, 0.487712f, 0.492667f, 0.497642f, 0.502639f, 0.507658f, 0.512699f, 0.517763f, 0.522850f, 0.527960f, 0.533093f, 0.538250f, 0.543431f, 0.548636f, 0.553865f, 0.559118f, 0.564396f, 0.569700f, 0.575028f, 0.580382f, 0.585761f, 0.591165f, 0.596595f, 0.602051f, 0.607532f, 0.613039f, 0.618572f, 0.624131f, 0.629718f, 0.635330f, 0.640969f, 0.646633f, 0.652325f, 0.658043f, 0.663787f, 0.669558f, 0.675355f, 0.681179f, 0.687030f, 0.692907f, 0.698810f, 0.704741f, 0.710698f, 0.716681f, 0.722691f, 0.728728f, 0.734791f, 0.740880f, 0.746995f, 0.753137f, 0.759304f, 0.765499f, 0.771720f, 0.777967f, 0.784239f, 0.790537f, 0.796859f, 0.803205f, 0.809579f, 0.815978f, 0.822401f, 0.828846f, 0.835315f, 0.841812f, 0.848329f, 0.854866f, 0.861432f, 0.868016f, 0.874622f, 0.881250f, 0.887896f, 0.894564f, 0.901249f, 0.907950f, 0.914672f, 0.921407f, 0.928152f, 0.934908f, 0.941671f, 0.948435f, 0.955190f, 0.961916f, 0.968590f, 0.975158f };
	static const float b15[] = { 0.527975f, 0.533124f, 0.538007f, 0.542658f, 0.547103f, 0.551368f, 0.555468f, 0.559423f, 0.563250f, 0.566959f, 0.570562f, 0.574065f, 0.577478f, 0.580806f, 0.584054f, 0.587228f, 0.590330f, 0.593364f, 0.596333f, 0.599239f, 0.602083f, 0.604867f, 0.607592f, 0.610259f, 0.612868f, 0.615419f, 0.617911f, 0.620346f, 0.622722f, 0.625038f, 0.627295f, 0.629490f, 0.631624f, 0.633694f, 0.635700f, 0.637640f, 0.639512f, 0.641316f, 0.643049f, 0.644710f, 0.646298f, 0.647810f, 0.649245f, 0.650601f, 0.651876f, 0.653068f, 0.654177f, 0.655199f, 0.656133f, 0.656977f, 0.657730f, 0.658390f, 0.658956f, 0.659425f, 0.659797f, 0.660069f, 0.660240f, 0.660310f, 0.660277f, 0.660139f, 0.659897f, 0.659549f, 0.659095f, 0.658534f, 0.657865f, 0.657088f, 0.656202f, 0.655209f, 0.654109f, 0.652901f, 0.651586f, 0.650165f, 0.648640f, 0.647010f, 0.645277f, 0.643443f, 0.641509f, 0.639477f, 0.637349f, 0.635126f, 0.632812f, 0.630408f, 0.627917f, 0.625342f, 0.622686f, 0.619951f, 0.617140f, 0.614257f, 0.611305f, 0.608287f, 0.605205f, 0.602065f, 0.598867f, 0.595617f, 0.592317f, 0.588971f, 0.585582f, 0.582154f, 0.578688f, 0.575189f, 0.571660f, 0.568103f, 0.564522f, 0.560919f, 0.557296f, 0.553657f, 0.550004f, 0.546338f, 0.542663f, 0.538981f, 0.535293f, 0.531601f, 0.527908f, 0.524216f, 0.520524f, 0.516834f, 0.513149f, 0.509468f, 0.505794f, 0.502126f, 0.498465f, 0.494813f, 0.491171f, 0.487539f, 0.483918f, 0.480307f, 0.476706f, 0.473117f, 0.469538f, 0.465971f, 0.462415f, 0.458870f, 0.455338f, 0.451816f, 0.448306f, 0.444806f, 0.441316f, 0.437836f, 0.434366f, 0.430905f, 0.427455f, 0.424013f, 0.420579f, 0.417153f, 0.413734f, 0.410322f, 0.406917f, 0.403519f, 0.400126f, 0.396738f, 0.393355f, 0.389976f, 0.386600f, 0.383229f, 0.379860f, 0.376494f, 0.373130f, 0.369768f, 0.366407f, 0.363047f, 0.359688f, 0.356329f, 0.352970f, 0.349610f, 0.346251f, 0.342890f, 0.339529f, 0.336166f, 0.332801f, 0.329435f, 0.326067f, 0.322697f, 0.319325f, 0.315952f, 0.312575f, 0.309197f, 0.305816f, 0.302433f, 0.299049f, 0.295662f, 0.292275f, 0.288883f, 0.285490f, 0.282096f, 0.278701f, 0.275305f, 0.271909f, 0.268513f, 0.265118f, 0.261721f, 0.258325f, 0.254931f, 0.251540f, 0.248151f, 0.244767f, 0.241387f, 0.238013f, 0.234646f, 0.231287f, 0.227937f, 0.224595f, 0.221265f, 0.217948f, 0.214648f, 0.211364f, 0.208100f, 0.204859f, 0.201642f, 0.198453f, 0.195295f, 0.192170f, 0.189084f, 0.186041f, 0.183043f, 0.180097f, 0.177208f, 0.174381f, 0.171622f, 0.168938f, 0.166335f, 0.163821f, 0.161404f, 0.159092f, 0.156891f, 0.154808f, 0.152855f, 0.151042f, 0.149377f, 0.147870f, 0.146529f, 0.145357f, 0.144363f, 0.143557f, 0.142945f, 0.142528f, 0.142303f, 0.142279f, 0.142453f, 0.142808f, 0.143351f, 0.144061f, 0.144923f, 0.145919f, 0.147014f, 0.148180f, 0.149370f, 0.150520f, 0.151566f, 0.152409f, 0.152921f, 0.152925f, 0.152178f, 0.150328f, 0.146861f, 0.140956f, 0.131326f };
	// viridis
	static const float r16[] = { 0.267004f, 0.268510f, 0.269944f, 0.271305f, 0.272594f, 0.273809f, 0.274952f, 0.276022f, 0.277018f, 0.277941f, 0.278791f, 0.279566f, 0.280267f, 0.280894f, 0.281446f, 0.281924f, 0.282327f, 0.282656f, 0.282910f, 0.283091f, 0.283197f, 0.283229f, 0.283187f, 0.283072f, 0.282884f, 0.282623f, 0.282290f, 0.281887f, 0.281412f, 0.280868f, 0.280255f, 0.279574f, 0.278826f, 0.278012f, 0.277134f, 0.276194f, 0.275191f, 0.274128f, 0.273006f, 0.271828f, 0.270595f, 0.269308f, 0.267968f, 0.266580f, 0.265145f, 0.263663f, 0.262138f, 0.260571f, 0.258965f, 0.257322f, 0.255645f, 0.253935f, 0.252194f, 0.250425f, 0.248629f, 0.246811f, 0.244972f, 0.243113f, 0.241237f, 0.239346f, 0.237441f, 0.235526f, 0.233603f, 0.231674f, 0.229739f, 0.227802f, 0.225863f, 0.223925f, 0.221989f, 0.220057f, 0.218130f, 0.216210f, 0.214298f, 0.212395f, 0.210503f, 0.208623f, 0.206756f, 0.204903f, 0.203063f, 0.201239f, 0.199430f, 0.197636f, 0.195860f, 0.194100f, 0.192357f, 0.190631f, 0.188923f, 0.187231f, 0.185556f, 0.183898f, 0.182256f, 0.180629f, 0.179019f, 0.177423f, 0.175841f, 0.174274f, 0.172719f, 0.171176f, 0.169646f, 0.168126f, 0.166617f, 0.165117f, 0.163625f, 0.162142f, 0.160665f, 0.159194f, 0.157729f, 0.156270f, 0.154815f, 0.153364f, 0.151918f, 0.150476f, 0.149039f, 0.147607f, 0.146180f, 0.144759f, 0.143343f, 0.141935f, 0.140536f, 0.139147f, 0.137770f, 0.136408f, 0.135066f, 0.133743f, 0.132444f, 0.131172f, 0.129933f, 0.128729f, 0.127568f, 0.126453f, 0.125394f, 0.124395f, 0.123463f, 0.122606f, 0.121831f, 0.121148f, 0.120565f, 0.120092f, 0.119738f, 0.119512f, 0.119423f, 0.119483f, 0.119699f, 0.120081f, 0.120638f, 0.121380f, 0.122312f, 0.123444f, 0.124780f, 0.126326f, 0.128087f, 0.130067f, 0.132268f, 0.134692f, 0.137339f, 0.140210f, 0.143303f, 0.146616f, 0.150148f, 0.153894f, 0.157851f, 0.162016f, 0.166383f, 0.170948f, 0.175707f, 0.180653f, 0.185783f, 0.191090f, 0.196571f, 0.202219f, 0.208030f, 0.214000f, 0.220124f, 0.226397f, 0.232815f, 0.239374f, 0.246070f, 0.252899f, 0.259857f, 0.266941f, 0.274149f, 0.281477f, 0.288921f, 0.296479f, 0.304148f, 0.311925f, 0.319809f, 0.327796f, 0.335885f, 0.344074f, 0.352360f, 0.360741f, 0.369214f, 0.377779f, 0.386433f, 0.395174f, 0.404001f, 0.412913f, 0.421908f, 0.430983f, 0.440137f, 0.449368f, 0.458674f, 0.468053f, 0.477504f, 0.487026f, 0.496615f, 0.506271f, 0.515992f, 0.525776f, 0.535621f, 0.545524f, 0.555484f, 0.565498f, 0.575563f, 0.585678f, 0.595839f, 0.606045f, 0.616293f, 0.626579f, 0.636902f, 0.647257f, 0.657642f, 0.668054f, 0.678489f, 0.688944f, 0.699415f, 0.709898f, 0.720391f, 0.730889f, 0.741388f, 0.751884f, 0.762373f, 0.772852f, 0.783315f, 0.793760f, 0.804182f, 0.814576f, 0.824940f, 0.835270f, 0.845561f, 0.855810f, 0.866013f, 0.876168f, 0.886271f, 0.896320f, 0.906311f, 0.916242f, 0.926106f, 0.935904f, 0.945636f, 0.955300f, 0.964894f, 0.974417f, 0.983868f, 0.993248f };
	static const float g16[] = { 0.004874f, 0.009605f, 0.014625f, 0.019942f, 0.025563f, 0.031497f, 0.037752f, 0.044167f, 0.050344f, 0.056324f, 0.062145f, 0.067836f, 0.073417f, 0.078907f, 0.084320f, 0.089666f, 0.094955f, 0.100196f, 0.105393f, 0.110553f, 0.115680f, 0.120777f, 0.125848f, 0.130895f, 0.135920f, 0.140926f, 0.145912f, 0.150881f, 0.155834f, 0.160771f, 0.165693f, 0.170599f, 0.175490f, 0.180367f, 0.185228f, 0.190074f, 0.194905f, 0.199721f, 0.204520f, 0.209303f, 0.214069f, 0.218818f, 0.223549f, 0.228262f, 0.232956f, 0.237631f, 0.242286f, 0.246922f, 0.251537f, 0.256130f, 0.260703f, 0.265254f, 0.269783f, 0.274290f, 0.278775f, 0.283237f, 0.287675f, 0.292092f, 0.296485f, 0.300855f, 0.305202f, 0.309527f, 0.313828f, 0.318106f, 0.322361f, 0.326594f, 0.330805f, 0.334994f, 0.339161f, 0.343307f, 0.347432f, 0.351535f, 0.355619f, 0.359683f, 0.363727f, 0.367752f, 0.371758f, 0.375746f, 0.379716f, 0.383670f, 0.387607f, 0.391528f, 0.395433f, 0.399323f, 0.403199f, 0.407061f, 0.410910f, 0.414746f, 0.418570f, 0.422383f, 0.426184f, 0.429975f, 0.433756f, 0.437527f, 0.441290f, 0.445044f, 0.448791f, 0.452530f, 0.456262f, 0.459988f, 0.463708f, 0.467423f, 0.471133f, 0.474838f, 0.478540f, 0.482237f, 0.485932f, 0.489624f, 0.493313f, 0.497000f, 0.500685f, 0.504369f, 0.508051f, 0.511733f, 0.515413f, 0.519093f, 0.522773f, 0.526453f, 0.530132f, 0.533812f, 0.537492f, 0.541173f, 0.544853f, 0.548535f, 0.552216f, 0.555899f, 0.559582f, 0.563265f, 0.566949f, 0.570633f, 0.574318f, 0.578002f, 0.581687f, 0.585371f, 0.589055f, 0.592739f, 0.596422f, 0.600104f, 0.603785f, 0.607464f, 0.611141f, 0.614817f, 0.618490f, 0.622161f, 0.625828f, 0.629492f, 0.633153f, 0.636809f, 0.640461f, 0.644107f, 0.647749f, 0.651384f, 0.655014f, 0.658636f, 0.662252f, 0.665859f, 0.669459f, 0.673050f, 0.676631f, 0.680203f, 0.683765f, 0.687316f, 0.690856f, 0.694384f, 0.697900f, 0.701402f, 0.704891f, 0.708366f, 0.711827f, 0.715272f, 0.718701f, 0.722114f, 0.725509f, 0.728888f, 0.732247f, 0.735588f, 0.738910f, 0.742211f, 0.745492f, 0.748751f, 0.751988f, 0.755203f, 0.758394f, 0.761561f, 0.764704f, 0.767822f, 0.770914f, 0.773980f, 0.777018f, 0.780029f, 0.783011f, 0.785964f, 0.788888f, 0.791781f, 0.794644f, 0.797475f, 0.800275f, 0.803041f, 0.805774f, 0.808473f, 0.811138f, 0.813768f, 0.816363f, 0.818921f, 0.821444f, 0.823929f, 0.826376f, 0.828786f, 0.831158f, 0.833491f, 0.835785f, 0.838039f, 0.840254f, 0.842430f, 0.844566f, 0.846661f, 0.848717f, 0.850733f, 0.852709f, 0.854645f, 0.856542f, 0.858400f, 0.860219f, 0.861999f, 0.863742f, 0.865448f, 0.867117f, 0.868751f, 0.870350f, 0.871916f, 0.873449f, 0.874951f, 0.876424f, 0.877868f, 0.879285f, 0.880678f, 0.882046f, 0.883393f, 0.884720f, 0.886029f, 0.887322f, 0.888601f, 0.889868f, 0.891125f, 0.892374f, 0.893616f, 0.894855f, 0.896091f, 0.897330f, 0.898570f, 0.899815f, 0.901065f, 0.902323f, 0.903590f, 0.904867f, 0.906157f };
	static const float b16[] = { 0.329415f, 0.335427f, 0.341379f, 0.347269f, 0.353093f, 0.358853f, 0.364543f, 0.370164f, 0.375715f, 0.381191f, 0.386592f, 0.391917f, 0.397163f, 0.402329f, 0.407414f, 0.412415f, 0.417331f, 0.422160f, 0.426902f, 0.431554f, 0.436115f, 0.440584f, 0.444960f, 0.449241f, 0.453427f, 0.457517f, 0.461510f, 0.465405f, 0.469201f, 0.472899f, 0.476498f, 0.479997f, 0.483397f, 0.486697f, 0.489898f, 0.493001f, 0.496005f, 0.498911f, 0.501721f, 0.504434f, 0.507052f, 0.509577f, 0.512008f, 0.514349f, 0.516599f, 0.518762f, 0.520837f, 0.522828f, 0.524736f, 0.526563f, 0.528312f, 0.529983f, 0.531579f, 0.533103f, 0.534556f, 0.535941f, 0.537260f, 0.538516f, 0.539709f, 0.540844f, 0.541921f, 0.542944f, 0.543914f, 0.544834f, 0.545706f, 0.546532f, 0.547314f, 0.548053f, 0.548752f, 0.549413f, 0.550038f, 0.550627f, 0.551184f, 0.551710f, 0.552206f, 0.552675f, 0.553117f, 0.553533f, 0.553925f, 0.554294f, 0.554642f, 0.554969f, 0.555276f, 0.555565f, 0.555836f, 0.556089f, 0.556326f, 0.556547f, 0.556753f, 0.556944f, 0.557120f, 0.557282f, 0.557430f, 0.557565f, 0.557685f, 0.557792f, 0.557885f, 0.557965f, 0.558030f, 0.558082f, 0.558119f, 0.558141f, 0.558148f, 0.558140f, 0.558115f, 0.558073f, 0.558013f, 0.557936f, 0.557840f, 0.557724f, 0.557587f, 0.557430f, 0.557250f, 0.557049f, 0.556823f, 0.556572f, 0.556295f, 0.555991f, 0.555659f, 0.555298f, 0.554906f, 0.554483f, 0.554029f, 0.553541f, 0.553018f, 0.552459f, 0.551864f, 0.551229f, 0.550556f, 0.549841f, 0.549086f, 0.548287f, 0.547445f, 0.546557f, 0.545623f, 0.544641f, 0.543611f, 0.542530f, 0.541400f, 0.540218f, 0.538982f, 0.537692f, 0.536347f, 0.534946f, 0.533488f, 0.531973f, 0.530398f, 0.528763f, 0.527068f, 0.525311f, 0.523491f, 0.521608f, 0.519661f, 0.517649f, 0.515571f, 0.513427f, 0.511215f, 0.508936f, 0.506589f, 0.504172f, 0.501686f, 0.499129f, 0.496502f, 0.493803f, 0.491033f, 0.488189f, 0.485273f, 0.482284f, 0.479221f, 0.476084f, 0.472873f, 0.469588f, 0.466226f, 0.462789f, 0.459277f, 0.455688f, 0.452024f, 0.448284f, 0.444467f, 0.440573f, 0.436601f, 0.432552f, 0.428426f, 0.424223f, 0.419943f, 0.415586f, 0.411152f, 0.406640f, 0.402049f, 0.397381f, 0.392636f, 0.387814f, 0.382914f, 0.377939f, 0.372886f, 0.367757f, 0.362552f, 0.357269f, 0.351910f, 0.346476f, 0.340967f, 0.335384f, 0.329727f, 0.323998f, 0.318195f, 0.312321f, 0.306377f, 0.300362f, 0.294279f, 0.288127f, 0.281908f, 0.275626f, 0.269281f, 0.262877f, 0.256415f, 0.249897f, 0.243329f, 0.236712f, 0.230052f, 0.223353f, 0.216620f, 0.209861f, 0.203082f, 0.196293f, 0.189503f, 0.182725f, 0.175971f, 0.169257f, 0.162603f, 0.156029f, 0.149561f, 0.143228f, 0.137064f, 0.131109f, 0.125405f, 0.120005f, 0.114965f, 0.110347f, 0.106217f, 0.102646f, 0.099702f, 0.097452f, 0.095953f, 0.095250f, 0.095374f, 0.096335f, 0.098125f, 0.100717f, 0.104071f, 0.108131f, 0.112838f, 0.118128f, 0.123941f, 0.130215f, 0.136897f, 0.143936f };
	// cividis
	static const float r17[] = { 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.000000f, 0.003602f, 0.017852f, 0.032110f, 0.046205f, 0.058378f, 0.068968f, 0.078624f, 0.087465f, 0.095645f, 0.103401f, 0.110658f, 0.117612f, 0.124291f, 0.130669f, 0.136830f, 0.142852f, 0.148638f, 0.154261f, 0.159733f, 0.165113f, 0.170362f, 0.175490f, 0.180503f, 0.185453f, 0.190303f, 0.195057f, 0.199764f, 0.204385f, 0.208926f, 0.213431f, 0.217863f, 0.222264f, 0.226598f, 0.230871f, 0.235120f, 0.239312f, 0.243485f, 0.247605f, 0.251675f, 0.255731f, 0.259740f, 0.263738f, 0.267693f, 0.271639f, 0.275513f, 0.279411f, 0.283240f, 0.287065f, 0.290884f, 0.294669f, 0.298421f, 0.302169f, 0.305886f, 0.309601f, 0.313287f, 0.316941f, 0.320595f, 0.324250f, 0.327875f, 0.331474f, 0.335073f, 0.338673f, 0.342246f, 0.345793f, 0.349341f, 0.352892f, 0.356418f, 0.359916f, 0.363446f, 0.366923f, 0.370430f, 0.373884f, 0.377371f, 0.380830f, 0.384268f, 0.387705f, 0.391151f, 0.394568f, 0.397991f, 0.401418f, 0.404820f, 0.408226f, 0.411607f, 0.414992f, 0.418383f, 0.421748f, 0.425120f, 0.428462f, 0.431817f, 0.435168f, 0.438504f, 0.441810f, 0.445148f, 0.448447f, 0.451759f, 0.455072f, 0.458366f, 0.461616f, 0.464947f, 0.468254f, 0.471501f, 0.474812f, 0.478186f, 0.481622f, 0.485141f, 0.488697f, 0.492278f, 0.495913f, 0.499552f, 0.503185f, 0.506866f, 0.510540f, 0.514226f, 0.517920f, 0.521643f, 0.525348f, 0.529086f, 0.532829f, 0.536553f, 0.540307f, 0.544069f, 0.547840f, 0.551612f, 0.555393f, 0.559181f, 0.562972f, 0.566802f, 0.570607f, 0.574417f, 0.578236f, 0.582087f, 0.585916f, 0.589753f, 0.593622f, 0.597469f, 0.601354f, 0.605211f, 0.609105f, 0.612977f, 0.616852f, 0.620765f, 0.624654f, 0.628576f, 0.632506f, 0.636412f, 0.640352f, 0.644270f, 0.648222f, 0.652178f, 0.656114f, 0.660082f, 0.664055f, 0.668008f, 0.671991f, 0.675981f, 0.679979f, 0.683950f, 0.687957f, 0.691971f, 0.695985f, 0.700008f, 0.704037f, 0.708067f, 0.712105f, 0.716177f, 0.720222f, 0.724274f, 0.728334f, 0.732422f, 0.736488f, 0.740589f, 0.744664f, 0.748772f, 0.752886f, 0.756975f, 0.761096f, 0.765223f, 0.769353f, 0.773486f, 0.777651f, 0.781795f, 0.785965f, 0.790116f, 0.794298f, 0.798480f, 0.802667f, 0.806859f, 0.811054f, 0.815274f, 0.819499f, 0.823729f, 0.827959f, 0.832192f, 0.836429f, 0.840693f, 0.844957f, 0.849223f, 0.853515f, 0.857809f, 0.862105f, 0.866421f, 0.870717f, 0.875057f, 0.879378f, 0.883720f, 0.888081f, 0.892440f, 0.896818f, 0.901195f, 0.905589f, 0.910000f, 0.914407f, 0.918828f, 0.923279f, 0.927724f, 0.932180f, 0.936660f, 0.941147f, 0.945654f, 0.950178f, 0.954725f, 0.959284f, 0.963872f, 0.968469f, 0.973114f, 0.977780f, 0.982497f, 0.987293f, 0.992218f, 0.994847f, 0.995249f, 0.995503f, 0.995737f };
	static const float g17[] = { 0.135112f, 0.138068f, 0.141013f, 0.143951f, 0.146877f, 0.149791f, 0.152673f, 0.155377f, 0.157932f, 0.160495f, 0.163058f, 0.165621f, 0.168204f, 0.170800f, 0.173420f, 0.176082f, 0.178802f, 0.181610f, 0.184550f, 0.186915f, 0.188769f, 0.190950f, 0.193366f, 0.195911f, 0.198528f, 0.201199f, 0.203903f, 0.206629f, 0.209372f, 0.212122f, 0.214879f, 0.217643f, 0.220406f, 0.223170f, 0.225935f, 0.228697f, 0.231458f, 0.234216f, 0.236972f, 0.239724f, 0.242475f, 0.245221f, 0.247965f, 0.250707f, 0.253444f, 0.256180f, 0.258914f, 0.261644f, 0.264372f, 0.267099f, 0.269823f, 0.272546f, 0.275266f, 0.277985f, 0.280702f, 0.283419f, 0.286134f, 0.288848f, 0.291562f, 0.294274f, 0.296986f, 0.299698f, 0.302409f, 0.305120f, 0.307831f, 0.310542f, 0.313253f, 0.315965f, 0.318677f, 0.321390f, 0.324103f, 0.326816f, 0.329531f, 0.332247f, 0.334963f, 0.337681f, 0.340399f, 0.343120f, 0.345842f, 0.348565f, 0.351289f, 0.354016f, 0.356744f, 0.359474f, 0.362206f, 0.364939f, 0.367676f, 0.370414f, 0.373153f, 0.375896f, 0.378641f, 0.381388f, 0.384139f, 0.386890f, 0.389646f, 0.392404f, 0.395164f, 0.397928f, 0.400694f, 0.403464f, 0.406236f, 0.409011f, 0.411790f, 0.414572f, 0.417357f, 0.420145f, 0.422937f, 0.425733f, 0.428531f, 0.431334f, 0.434140f, 0.436950f, 0.439763f, 0.442580f, 0.445402f, 0.448226f, 0.451053f, 0.453887f, 0.456718f, 0.459552f, 0.462405f, 0.465241f, 0.468083f, 0.470960f, 0.473832f, 0.476699f, 0.479573f, 0.482451f, 0.485318f, 0.488198f, 0.491076f, 0.493960f, 0.496851f, 0.499743f, 0.502643f, 0.505546f, 0.508454f, 0.511367f, 0.514285f, 0.517207f, 0.520135f, 0.523067f, 0.526005f, 0.528948f, 0.531895f, 0.534849f, 0.537807f, 0.540771f, 0.543741f, 0.546715f, 0.549695f, 0.552682f, 0.555673f, 0.558670f, 0.561674f, 0.564682f, 0.567697f, 0.570718f, 0.573743f, 0.576777f, 0.579816f, 0.582861f, 0.585913f, 0.588970f, 0.592034f, 0.595104f, 0.598180f, 0.601264f, 0.604354f, 0.607450f, 0.610553f, 0.613664f, 0.616780f, 0.619904f, 0.623034f, 0.626171f, 0.629316f, 0.632468f, 0.635626f, 0.638793f, 0.641966f, 0.645145f, 0.648334f, 0.651529f, 0.654731f, 0.657942f, 0.661160f, 0.664384f, 0.667618f, 0.670859f, 0.674107f, 0.677364f, 0.680629f, 0.683900f, 0.687181f, 0.690470f, 0.693766f, 0.697071f, 0.700384f, 0.703705f, 0.707035f, 0.710373f, 0.713719f, 0.717074f, 0.720438f, 0.723810f, 0.727190f, 0.730580f, 0.733978f, 0.737385f, 0.740801f, 0.744226f, 0.747659f, 0.751101f, 0.754553f, 0.758014f, 0.761483f, 0.764962f, 0.768450f, 0.771947f, 0.775454f, 0.778969f, 0.782494f, 0.786028f, 0.789572f, 0.793125f, 0.796687f, 0.800258f, 0.803839f, 0.807430f, 0.811030f, 0.814639f, 0.818257f, 0.821885f, 0.825522f, 0.829168f, 0.832822f, 0.836486f, 0.840159f, 0.843841f, 0.847530f, 0.851228f, 0.854933f, 0.858646f, 0.862365f, 0.866089f, 0.869819f, 0.873550f, 0.877281f, 0.881008f, 0.884718f, 0.888385f, 0.892954f, 0.898384f, 0.903866f, 0.909344f };
	static const float b17[] = { 0.304751f, 0.311105f, 0.317579f, 0.323982f, 0.330479f, 0.337065f, 0.343704f, 0.350500f, 0.357521f, 0.364534f, 0.371608f, 0.378769f, 0.385902f, 0.393100f, 0.400353f, 0.407577f, 0.414764f, 0.421859f, 0.428802f, 0.435532f, 0.439563f, 0.441085f, 0.441561f, 0.441564f, 0.441248f, 0.440785f, 0.440196f, 0.439531f, 0.438863f, 0.438105f, 0.437342f, 0.436593f, 0.435790f, 0.435067f, 0.434308f, 0.433547f, 0.432840f, 0.432148f, 0.431404f, 0.430752f, 0.430120f, 0.429528f, 0.428908f, 0.428325f, 0.427790f, 0.427299f, 0.426788f, 0.426329f, 0.425924f, 0.425497f, 0.425126f, 0.424809f, 0.424480f, 0.424206f, 0.423914f, 0.423678f, 0.423498f, 0.423304f, 0.423167f, 0.423014f, 0.422917f, 0.422873f, 0.422814f, 0.422810f, 0.422789f, 0.422821f, 0.422837f, 0.422979f, 0.423031f, 0.423211f, 0.423373f, 0.423517f, 0.423716f, 0.423973f, 0.424213f, 0.424512f, 0.424790f, 0.425120f, 0.425512f, 0.425889f, 0.426250f, 0.426670f, 0.427144f, 0.427605f, 0.428053f, 0.428559f, 0.429127f, 0.429685f, 0.430226f, 0.430823f, 0.431501f, 0.432075f, 0.432796f, 0.433428f, 0.434209f, 0.434890f, 0.435653f, 0.436475f, 0.437305f, 0.438096f, 0.438986f, 0.439848f, 0.440708f, 0.441642f, 0.442570f, 0.443577f, 0.444578f, 0.445560f, 0.446640f, 0.447692f, 0.448864f, 0.449982f, 0.451134f, 0.452341f, 0.453659f, 0.454885f, 0.456264f, 0.457582f, 0.458976f, 0.460457f, 0.461969f, 0.463395f, 0.464908f, 0.466357f, 0.467681f, 0.468845f, 0.469767f, 0.470384f, 0.471008f, 0.471453f, 0.471751f, 0.472032f, 0.472305f, 0.472432f, 0.472550f, 0.472640f, 0.472707f, 0.472639f, 0.472660f, 0.472543f, 0.472401f, 0.472352f, 0.472163f, 0.471947f, 0.471704f, 0.471439f, 0.471147f, 0.470829f, 0.470488f, 0.469988f, 0.469593f, 0.469172f, 0.468724f, 0.468118f, 0.467618f, 0.467090f, 0.466401f, 0.465821f, 0.465074f, 0.464441f, 0.463638f, 0.462950f, 0.462237f, 0.461351f, 0.460583f, 0.459641f, 0.458668f, 0.457818f, 0.456791f, 0.455886f, 0.454801f, 0.453689f, 0.452702f, 0.451534f, 0.450338f, 0.449270f, 0.448018f, 0.446736f, 0.445424f, 0.444251f, 0.442886f, 0.441491f, 0.440072f, 0.438624f, 0.437147f, 0.435647f, 0.434117f, 0.432386f, 0.430805f, 0.429194f, 0.427554f, 0.425717f, 0.424028f, 0.422131f, 0.420393f, 0.418448f, 0.416472f, 0.414659f, 0.412638f, 0.410587f, 0.408516f, 0.406422f, 0.404112f, 0.401966f, 0.399613f, 0.397423f, 0.395016f, 0.392597f, 0.390153f, 0.387684f, 0.385198f, 0.382504f, 0.379785f, 0.377043f, 0.374292f, 0.371529f, 0.368747f, 0.365746f, 0.362741f, 0.359729f, 0.356500f, 0.353259f, 0.350011f, 0.346571f, 0.343333f, 0.339685f, 0.336241f, 0.332599f, 0.328770f, 0.324968f, 0.320982f, 0.317021f, 0.312889f, 0.308594f, 0.304348f, 0.299960f, 0.295244f, 0.290611f, 0.285880f, 0.280876f, 0.275815f, 0.270532f, 0.265085f, 0.259365f, 0.253563f, 0.247445f, 0.241310f, 0.234677f, 0.227954f, 0.220878f, 0.213336f, 0.205468f, 0.203445f, 0.207561f, 0.212370f, 0.217772f };
	// twilight
	static const float r18[] = { 0.88575015840754434f, 0.88378520195539056f, 0.88172231059285788f, 0.8795410528270573f, 0.87724880858965482f, 0.87485347508575972f, 0.87233134085124076f, 0.86970474853509816f, 0.86696015505333579f, 0.86408985081463996f, 0.86110245436899846f, 0.85798259245670372f, 0.85472593189256985f, 0.85133714570857189f, 0.84780710702577922f, 0.8441261828674842f, 0.84030420805957784f, 0.83634031809191178f, 0.83222705712934408f, 0.82796894316013536f, 0.82357429680252847f, 0.81904654677937527f, 0.81438982121143089f, 0.8095999819094809f, 0.80469164429814577f, 0.79967075421267997f, 0.79454305089231114f, 0.78931445564608915f, 0.78399101042764918f, 0.77857892008227592f, 0.77308416590170936f, 0.76751108504417864f, 0.76186907937980286f, 0.75616443584381976f, 0.75040346765406696f, 0.74459247771890169f, 0.73873771700494939f, 0.73284543645523459f, 0.72692177512829703f, 0.72097280665536778f, 0.71500403076252128f, 0.70902078134539304f, 0.7030297722540817f, 0.6970365443886174f, 0.69104641009309098f, 0.68506446154395928f, 0.67909554499882152f, 0.67314422559426212f, 0.66721479803752815f, 0.6613112930078745f, 0.65543692326454717f, 0.64959573004253479f, 0.6437910831099849f, 0.63802586828545982f, 0.6323027138710603f, 0.62662402022604591f, 0.62099193064817548f, 0.61540846411770478f, 0.60987543176093062f, 0.60439434200274855f, 0.5989665814482068f, 0.59359335696837223f, 0.58827579780555495f, 0.58301487036932409f, 0.5778116438998202f, 0.5726668948158774f, 0.56758117853861967f, 0.56255515357219343f, 0.55758940419605174f, 0.55268450589347129f, 0.54784098153018634f, 0.54305932424018233f, 0.53834015575176275f, 0.53368389147728401f, 0.529090861832473f, 0.52456151470593582f, 0.52009627392235558f, 0.5156955988596057f, 0.51135992541601927f, 0.50708969576451657f, 0.5028853540415561f, 0.49874733661356069f, 0.4946761847863938f, 0.49067224938561221f, 0.4867359599430568f, 0.4828677867260272f, 0.47906816236197386f, 0.47533752394906287f, 0.47167629518877091f, 0.46808490970531597f, 0.46456376716303932f, 0.46111326647023881f, 0.45773377230160567f, 0.45442563977552913f, 0.45118918687617743f, 0.44802470933589172f, 0.44493246854215379f, 0.44191271766696399f, 0.43896563958048396f, 0.43609138958356369f, 0.43329008867358393f, 0.43056179073057571f, 0.42790652284925834f, 0.42532423665011354f, 0.42281485675772662f, 0.42037822361396326f, 0.41801414079233629f, 0.4157223260454232f, 0.41350245743314729f, 0.41135414697304568f, 0.4092768899914751f, 0.40727018694219069f, 0.40533343789303178f, 0.40346600333905397f, 0.40166714010896104f, 0.39993606933454834f, 0.3982719152586337f, 0.39667374905665609f, 0.39514058808207631f, 0.39367135736822567f, 0.39226494876209317f, 0.39092017571994903f, 0.38963580160340855f, 0.38841053300842432f, 0.38724301459330251f, 0.38613184178892102f, 0.38507556793651387f, 0.38407269378943537f, 0.38312168084402748f, 0.38222094988570376f, 0.38136887930454161f, 0.38056380696565623f, 0.37980403744848751f, 0.37908789283110761f, 0.378413635091359f, 0.37777949753513729f, 0.37718371844251231f, 0.37662448930806297f, 0.37610001286385814f, 0.37560846919442398f, 0.37514802505380473f, 0.37471686019302231f, 0.37431313199312338f, 0.37393499330475782f, 0.3735806215098284f, 0.37324816143326384f, 0.37293578646665032f, 0.37264166757849604f, 0.37236397858465387f, 0.37210089702443822f, 0.3718506155898596f, 0.37161133234400479f, 0.37138124223736607f, 0.37115856636209105f, 0.37094151551337329f, 0.37072833279422668f, 0.37051738634484427f, 0.37030682071842685f, 0.37009487130772695f, 0.36987980329025361f, 0.36965987626565955f, 0.36943334591276228f, 0.36919847837592484f, 0.36895355306596778f, 0.36869682231895268f, 0.36842655638020444f, 0.36814101479899719f, 0.36783843696531082f, 0.36751707094367697f, 0.36717513650699446f, 0.36681085540107988f, 0.36642243251550632f, 0.36600853966739794f, 0.36556698373538982f, 0.36509579845886808f, 0.36459308890125008f, 0.36405693022088509f, 0.36348537610385145f, 0.36287643560041027f, 0.36222809558295926f, 0.36153829010998356f, 0.36080493826624654f, 0.36002681809096376f, 0.35920088560930186f, 0.35832489966617809f, 0.35739663292915563f, 0.35641381143126327f, 0.35537415306906722f, 0.35427534960663759f, 0.35311574421123737f, 0.35189248608873791f, 0.35060304441931012f, 0.34924513554955644f, 0.34781653238777782f, 0.34631507175793091f, 0.34473901574536375f, 0.34308600291572294f, 0.34135411074506483f, 0.33954168752669694f, 0.33764732090671112f, 0.33566978565015315f, 0.33360804901486002f, 0.33146154891145124f, 0.32923005203231409f, 0.3269137124539796f, 0.32451307931207785f, 0.32202882276069322f, 0.31946262395497965f, 0.31681648089023501f, 0.31409278414755532f, 0.31129434479712365f, 0.30842444457210105f, 0.30548675819945936f, 0.30248536364574252f, 0.29942483960214772f, 0.29631000388905288f, 0.29314593096985248f, 0.28993792445176608f, 0.28669151388283165f, 0.28341239797185225f, 0.28010638576975472f, 0.27677939615815589f, 0.27343739342450812f, 0.27008637749114051f, 0.26673233211995284f, 0.26338121807151404f, 0.26003895187439957f, 0.25671191651083902f, 0.25340685873736807f, 0.25012845306199383f, 0.24688226237958999f, 0.24367372557466271f, 0.24050813332295939f, 0.23739062429054825f, 0.23433055727563878f, 0.23132955273021344f, 0.2283917709422868f, 0.22552164337737857f, 0.22272706739121817f, 0.22001251100779617f, 0.21737845072382705f, 0.21482843531473683f, 0.21237411048541005f, 0.21001214221188125f, 0.2077442377448806f, 0.20558051999470117f, 0.20352007949514977f, 0.20156133764129841f, 0.19971571438603364f, 0.19794834061899208f, 0.1960826032659409f, 0.19410351363791453f, 0.19199449184606268f, 0.18975853639094634f, 0.18739228342697645f, 0.18488035509396164f, 0.18774482037046955f, 0.19049578401722037f, 0.1931548636579131f, 0.19571853588267552f, 0.19819343656336558f, 0.20058760685133747f, 0.20290365333558247f, 0.20531725273301316f, 0.20785704662965598f, 0.21052882914958676f, 0.2133313859647627f, 0.21625279838647882f, 0.21930503925136402f, 0.22247308588973624f, 0.2257539681670791f, 0.22915620278592841f, 0.23266299920501882f, 0.23627495835774248f, 0.23999586188690308f, 0.24381149720247919f, 0.24772092990501099f, 0.25172899728289466f, 0.25582135547481771f, 0.25999463887892144f, 0.26425512207060942f, 0.26859095948172862f, 0.27299701518897301f, 0.27747150809142801f, 0.28201746297366942f, 0.28662309235899847f, 0.29128515387578635f, 0.2960004726065818f, 0.30077276812918691f, 0.30559226007249934f, 0.31045520848595526f, 0.31535870009205808f, 0.32029986557994061f, 0.32527888860401261f, 0.33029174471181438f, 0.33533353224455448f, 0.34040164359597463f, 0.34549355713871799f, 0.35060678246032478f, 0.35573889947341125f, 0.36088752387578377f, 0.36605031412464006f, 0.37122508431309342f, 0.3764103053221462f, 0.38160247377467543f, 0.38679939079544168f, 0.39199887556812907f, 0.39719876876325577f, 0.40239692379737496f, 0.40759120392688708f, 0.41277985630360303f, 0.41796105205173684f, 0.42313214269556043f, 0.42829101315789753f, 0.4334355841041439f, 0.43856378187931538f, 0.44367358645071275f, 0.44876299173174822f, 0.45383005086999889f, 0.45887288947308297f, 0.46389102840284874f, 0.46888111384598413f, 0.473841437035254f, 0.47877034239726296f, 0.48366628618847957f, 0.48852847371852987f, 0.49335504375145617f, 0.49814435462074153f, 0.50289524974970612f, 0.50760681181053691f, 0.51227835105321762f, 0.51690848800544464f, 0.52149652863229956f, 0.52604189625477482f, 0.53054420489856446f, 0.5350027976174474f, 0.53941736649199057f, 0.54378771313608565f, 0.54811370033467621f, 0.55239521572711914f, 0.55663229034969341f, 0.56082499039117173f, 0.56497343529017696f, 0.56907784784011428f, 0.57313845754107873f, 0.57715550812992045f, 0.58112932761586555f, 0.58506024396466882f, 0.58894861935544707f, 0.59279480536520257f, 0.59659918109122367f, 0.60036213010411577f, 0.60408401696732739f, 0.60776523994818654f, 0.6114062072731884f, 0.61500723236391375f, 0.61856865258877192f, 0.62209079821082613f, 0.62557416500434959f, 0.62901892016985872f, 0.63242534854210275f, 0.6357937104834237f, 0.6391243387840212f, 0.642417577481186f, 0.64567349382645434f, 0.64889230169458245f, 0.65207417290277303f, 0.65521932609327127f, 0.6583280801134499f, 0.66140037532601781f, 0.66443632469878844f, 0.66743603766369131f, 0.67039959547676198f, 0.67332725564817331f, 0.67621897924409746f, 0.67907474028157344f, 0.68189457150944521f, 0.68467850942494535f, 0.68742656435169625f, 0.6901389321505248f, 0.69281544846764931f, 0.69545608346891119f, 0.6980608153581771f, 0.70062962477242097f, 0.70316249458814151f, 0.70565951122610093f, 0.70812059568420482f, 0.7105456546582587f, 0.71293466839773467f, 0.71528760614847287f, 0.71760444908133847f, 0.71988521490549851f, 0.7221299918421461f, 0.72433865647781592f, 0.72651122900227549f, 0.72864773856716547f, 0.73074820754845171f, 0.73281270506268747f, 0.73484133598564938f, 0.73683422173585866f, 0.73879140024599266f, 0.74071301619506091f, 0.7425992159973317f, 0.74445018676570673f, 0.74626615789163442f, 0.74804739275559562f, 0.74979420547170472f, 0.75150685045891663f, 0.75318566369046569f, 0.75483105066959544f, 0.75644341577140706f, 0.75802325538455839f, 0.75957111105340058f, 0.7610876378057071f, 0.76257333554052609f, 0.76402885609288662f, 0.76545492593330511f, 0.76685228950643891f, 0.76822176599735303f, 0.7695642334401418f, 0.77088091962302474f, 0.77217257229605551f, 0.77344021829889886f, 0.77468494746063199f, 0.77590790730685699f, 0.7771103295521099f, 0.77829345807633121f, 0.77945862731506643f, 0.78060774749483774f, 0.78174180478981836f, 0.78286225264440912f, 0.78397060836414478f, 0.78506845019606841f, 0.78615737132332963f, 0.78723904108188347f, 0.78831514045623963f, 0.78938737766251943f, 0.79045776847727878f, 0.79152832843475607f, 0.79260034304237448f, 0.79367559698664958f, 0.79475585972654039f, 0.79584292379583765f, 0.79693854719951607f, 0.79804447815136637f, 0.7991624518501963f, 0.80029415389753977f, 0.80144124292560048f, 0.80260531146112946f, 0.80378792531077625f, 0.80499054790810298f, 0.80621460526927058f, 0.8074614045096935f, 0.80873219170089694f, 0.81002809466520687f, 0.81135014011763329f, 0.81269922039881493f, 0.81407611046993344f, 0.81548146627279483f, 0.81691575775055891f, 0.81837931164498223f, 0.81987230650455289f, 0.8213947205565636f, 0.82294635110428427f, 0.8245268129450285f, 0.82613549710580259f, 0.8277716072353446f, 0.82943407816481474f, 0.83112163529096306f, 0.83283277185777982f, 0.8345656905566583f, 0.83631898844737929f, 0.83809123476131964f, 0.83987839884120874f, 0.84167750766845151f, 0.84348529222933699f, 0.84529810731955113f, 0.84711195507965098f, 0.84892245563117641f, 0.85072697023178789f, 0.85251907207708444f, 0.85429219611470464f, 0.85604022314725403f, 0.85775662943504905f, 0.8594346370300241f, 0.86107117027565516f, 0.86265601051127572f, 0.86418343723941027f, 0.86564934325605325f, 0.86705314907048503f, 0.86839954695818633f, 0.86969131502613806f, 0.87093846717297507f, 0.87215331978454325f, 0.87335171360916275f, 0.87453793320260187f, 0.87571458709961403f, 0.87687848451614692f, 0.87802298436649007f, 0.87913244240792765f, 0.88019293315695812f, 0.88119169871341951f, 0.88211542489401606f, 0.88295168595448525f, 0.88369127145898041f, 0.88432713054113543f, 0.88485138159908572f, 0.88525897972630474f, 0.88554714811952384f, 0.88571155122845646f };
	static const float g18[] = { 0.85000924943067835f, 0.85072940540310626f, 0.85127594077653468f, 0.85165675407495722f, 0.85187028338870274f, 0.85191526123023187f, 0.85180165478080894f, 0.85152403004797894f, 0.8510896085314068f, 0.85050391167507788f, 0.84976754857001258f, 0.84888934810281835f, 0.84787488124672816f, 0.84672735796116472f, 0.8454546229209523f, 0.84406482711037389f, 0.8425605950855084f, 0.84094796518951942f, 0.83923490627754482f, 0.83742600751395202f, 0.83552487764795436f, 0.8335364929949034f, 0.83146558694197847f, 0.82931896673505456f, 0.82709838780560663f, 0.82480781812080928f, 0.82245116226304615f, 0.82003213188702007f, 0.81755426400533426f, 0.81502089378742548f, 0.81243524735466011f, 0.8098007598713145f, 0.80711949387647486f, 0.80439408733477935f, 0.80162699008965321f, 0.79882047719583249f, 0.79597665735031009f, 0.79309746468844067f, 0.7901846863592763f, 0.78723995923452639f, 0.78426487091581187f, 0.78126088716070907f, 0.77822904973358131f, 0.77517050008066057f, 0.77208629460678091f, 0.7689774029354699f, 0.76584472131395898f, 0.76268908733890484f, 0.7595112803730375f, 0.75631202708719025f, 0.75309208756768431f, 0.74985201221941766f, 0.7465923800833657f, 0.74331376714033193f, 0.74001672160131404f, 0.73670175403699445f, 0.73336934798923203f, 0.73001995232739691f, 0.72665398759758293f, 0.7232718614323369f, 0.71987394892246725f, 0.7164606049658685f, 0.71303214646458135f, 0.70958887676997473f, 0.70613106157153982f, 0.7026589535425779f, 0.69917279302646274f, 0.69567278381629649f, 0.69215911458254054f, 0.68863194515166382f, 0.68509142218509878f, 0.68153767253065878f, 0.67797081129095405f, 0.67439093705212727f, 0.67079812302806219f, 0.66719242996142225f, 0.66357391434030388f, 0.65994260812897998f, 0.65629853981831865f, 0.65264172403146448f, 0.64897216734095264f, 0.6452898684900934f, 0.64159484119504429f, 0.63788704858847078f, 0.63416646251100506f, 0.6304330455306234f, 0.62668676251860134f, 0.62292757283835809f, 0.61915543242884641f, 0.61537028695790286f, 0.61157208822864151f, 0.607760777169989f, 0.60393630046586455f, 0.60009859503858665f, 0.59624762051353541f, 0.59238331452146575f, 0.5885055998308617f, 0.58461441100175571f, 0.58070969241098491f, 0.57679137998186081f, 0.57285941625606673f, 0.56891374572457176f, 0.5649543060909209f, 0.56098104959950301f, 0.55699392126996583f, 0.55299287158108168f, 0.54897785421888889f, 0.54494882715350401f, 0.54090574771098476f, 0.53684857765005933f, 0.53277730177130322f, 0.52869188011057411f, 0.52459228174983119f, 0.52047847653840029f, 0.51635044969688759f, 0.51220818143218516f, 0.50805166539276136f, 0.50388089053847973f, 0.49969585326377758f, 0.49549655777451179f, 0.49128300332899261f, 0.48705520251223039f, 0.48281316715123496f, 0.47855691131792805f, 0.47428645933635388f, 0.4700018340988123f, 0.46570306719930193f, 0.46139018782416635f, 0.45706323581407199f, 0.45272225034283325f, 0.44836727669277859f, 0.44399837208633719f, 0.43961558821222629f, 0.43521897612544935f, 0.43080859411413064f, 0.4263845142616835f, 0.42194680223454828f, 0.41749553747893614f, 0.41303079952477062f, 0.40855267638072096f, 0.4040612609993941f, 0.3995566498711684f, 0.39503894828283309f, 0.39050827529375831f, 0.38596474386057539f, 0.38140848555753937f, 0.37683963835219841f, 0.37225835004836849f, 0.36766477862108266f, 0.36305909736982378f, 0.35844148285875221f, 0.3538121372967869f, 0.34917126878479027f, 0.34451911410230168f, 0.33985591488818123f, 0.33518193808489577f, 0.33049741244307851f, 0.32580269697872455f, 0.3210981375964933f, 0.31638410101153364f, 0.31166098762951971f, 0.30692923551862339f, 0.30218932176507068f, 0.29744175492366276f, 0.29268709856150099f, 0.28792596437778462f, 0.28315901221182987f, 0.27838697181297761f, 0.27361063317090978f, 0.26883085667326956f, 0.26404857724525643f, 0.25926481158628106f, 0.25448043878086224f, 0.24969683475296395f, 0.24491536803550484f, 0.24013747024823828f, 0.23536470386204195f, 0.23059876218396419f, 0.22584149293287031f, 0.22109488427338303f, 0.21636111429594002f, 0.21164251793458128f, 0.20694122817889948f, 0.20226037920758122f, 0.197602942459778f, 0.19297208197842461f, 0.18837119869242164f, 0.18380392577704466f, 0.17927413271618647f, 0.17478570377561287f, 0.17034320478524959f, 0.16595129984720861f, 0.16161477763045118f, 0.15733863511152979f, 0.15312802296627787f, 0.14898820589826409f, 0.14492465359918028f, 0.1409427920655632f, 0.13704801896718169f, 0.13324562282438077f, 0.12954074251271822f, 0.12593818301005921f, 0.12244245263391232f, 0.11905764321981127f, 0.1157873496841953f, 0.11263459791730848f, 0.10960114111258401f, 0.10668879882392659f, 0.10389861387653518f, 0.10123077676403242f, 0.098684771934052201f, 0.096259385340577736f, 0.093952764840823738f, 0.091761187397303601f, 0.089682253716750038f, 0.087713250960463951f, 0.085850656889620708f, 0.08409078829085731f, 0.082429873848480689f, 0.080864153365499375f, 0.079389994802261526f, 0.078003941033788216f, 0.076702800237496066f, 0.075483675584275545f, 0.074344018028546205f, 0.073281657939897077f, 0.072294781043362205f, 0.071380106242082242f, 0.070533582926851829f, 0.069758206429106989f, 0.069053639449204451f, 0.068419855150922693f, 0.067857103814855602f, 0.067365888050555517f, 0.066935599661639394f, 0.066576186939090592f, 0.06628997924139618f, 0.066078173119395595f, 0.065933790675651943f, 0.065857918918907604f, 0.065859661233562045f, 0.065940385613778491f, 0.066085024661758446f, 0.066308573918947178f, 0.06661453200418091f, 0.066990462397868739f, 0.067444179612424215f, 0.067983271026200248f, 0.068592710553704722f, 0.069314066071660657f, 0.070321227242423623f, 0.071608304856891569f, 0.073182830649273306f, 0.075019861862143766f, 0.077102096899588329f, 0.079425730279723883f, 0.077251588468039312f, 0.075311278416787641f, 0.073606819040117955f, 0.072157781039602742f, 0.070974625252738788f, 0.070064576149984209f, 0.069435248580458964f, 0.068919592266397572f, 0.068484398797025281f, 0.06812195249816172f, 0.067830148426026665f, 0.067616330270516389f, 0.067465786362940039f, 0.067388214053092838f, 0.067382132300147474f, 0.067434730871152565f, 0.067557104388479783f, 0.06774359820987802f, 0.067985029964779953f, 0.068289851529011875f, 0.068653337909486523f, 0.069064630826035506f, 0.06953231029187984f, 0.070053855603861875f, 0.070616595622995437f, 0.071226716277922458f, 0.071883555446163511f, 0.072582969899254779f, 0.073315693214040967f, 0.074088460826808866f, 0.074899049847466703f, 0.075745336000958424f, 0.076617824336164764f, 0.077521963107537312f, 0.078456871676182177f, 0.079420997315243186f, 0.080412994737554838f, 0.081428390076546092f, 0.08246763389003825f, 0.083532434119003962f, 0.084622236191702671f, 0.085736654965126335f, 0.08687555176033529f, 0.088038974350243354f, 0.089227194362745205f, 0.090440685427697898f, 0.091679997480262732f, 0.092945198093777909f, 0.094238731263712183f, 0.09556181960083443f, 0.09691583650296684f, 0.098302320968278623f, 0.099722930314950553f, 0.10117945586419633f, 0.1026734006932461f, 0.10420644885760968f, 0.10578120994917611f, 0.1073997763055258f, 0.1090642347484701f, 0.11077667828375456f, 0.11253912421257944f, 0.11435355574622549f, 0.11622183788331528f, 0.11814571137706886f, 0.12012561256850712f, 0.12216445576414045f, 0.12426354237989065f, 0.12642401401409453f, 0.12864679022013889f, 0.13093210934893723f, 0.13328091630401023f, 0.13569380302451714f, 0.13817086581280427f, 0.14071192654913128f, 0.14331656120063752f, 0.14598463068714407f, 0.14871544765633712f, 0.15150818660835483f, 0.15436183633886777f, 0.15727540775107324f, 0.16024769309971934f, 0.16327738551419116f, 0.1663630904279047f, 0.16950338809328983f, 0.17269677158182117f, 0.17594170887918095f, 0.17923664950367169f, 0.18258004462335425f, 0.18597036007065024f, 0.18940601489760422f, 0.19288548904692518f, 0.19640737049066315f, 0.19997020971775276f, 0.20357251410079796f, 0.207212956082026f, 0.21089030138947745f, 0.21460331490206347f, 0.21835070166659282f, 0.22213124697023234f, 0.22594402043981826f, 0.22978799249179921f, 0.2336621873300741f, 0.23756535071152696f, 0.24149689191922535f, 0.24545598775548677f, 0.24944185818822678f, 0.25345365461983138f, 0.257490519876798f, 0.26155203161615281f, 0.26563755336209077f, 0.26974650525236699f, 0.27387826652410152f, 0.27803210957665631f, 0.28220778870555907f, 0.28640483614256179f, 0.29062280081258873f, 0.29486126309253047f, 0.29911962764489264f, 0.30339762792450425f, 0.30769497879760166f, 0.31201133280550686f, 0.31634634821222207f, 0.32069970535138104f, 0.32507091815606004f, 0.32945984647042675f, 0.33386622163232865f, 0.33828976326048621f, 0.34273019305341756f, 0.34718723719597999f, 0.35166052978120937f, 0.35614985523380299f, 0.36065500290840113f, 0.36517570519856757f, 0.36971170225223449f, 0.37426272710686193f, 0.37882848839337313f, 0.38340864508963057f, 0.38800301593162145f, 0.3926113126792577f, 0.39723324476747235f, 0.401868526884681f, 0.4065168468778026f, 0.41117787004519513f, 0.41585125850290111f, 0.42053672992315327f, 0.4252339389526239f, 0.42994254036133867f, 0.43466217184617112f, 0.43939245044973502f, 0.44413297780351974f, 0.44888333481548809f, 0.45364314496866825f, 0.45841199172949604f, 0.46318942799460555f, 0.46797501437948458f, 0.4727682731566229f, 0.47756871222057079f, 0.48237579130289127f, 0.48718906673415824f, 0.49200802533379656f, 0.49683212909727231f, 0.5016608471009063f, 0.50649362371287909f, 0.5113298901696085f, 0.51616892643469103f, 0.5210102658711383f, 0.52585332093451564f, 0.53069749384776732f, 0.53554217882461186f, 0.54038674910561235f, 0.54523059488426595f, 0.55007308413977274f, 0.55491335744890613f, 0.55975098052594863f, 0.56458533111166875f, 0.56941578326710418f, 0.5742417003617839f, 0.5790624629815756f, 0.58387743744557208f, 0.58868600173562435f, 0.5934875421745599f, 0.59828134277062461f, 0.60306670593147205f, 0.60784322087037024f, 0.61261029334072192f, 0.61736734400220705f, 0.62211378808451145f, 0.62684905679296699f, 0.63157258225089552f, 0.63628379372029187f, 0.64098213306749863f, 0.64566703459218766f, 0.65033793748103852f, 0.65499426549472628f, 0.65963545027564163f, 0.66426089585282289f, 0.6688700095398864f, 0.67346216702194517f, 0.67803672673971815f, 0.68259301546243389f, 0.68713033714618876f, 0.69164794791482131f, 0.69614505508308089f, 0.70062083014783982f, 0.70507438189635097f, 0.70950474978787481f, 0.7139109141951604f, 0.71829177331290062f, 0.72264614312088882f, 0.72697275518238258f, 0.73127023324078089f, 0.7355371221572935f, 0.73977184647638616f, 0.74397271817459876f, 0.7481379479992134f, 0.75226548952875261f, 0.75635314860808633f, 0.76039907199779677f, 0.76440101200982946f, 0.76835660399870176f, 0.77226338601044719f, 0.77611880236047159f, 0.77992021407650147f, 0.78366457342383888f, 0.78734936133548439f, 0.79097196777091994f, 0.79452963601550608f, 0.79801963142713928f, 0.8014392309950078f, 0.80478517909812231f, 0.80805523804261525f, 0.81124644224653542f, 0.81435544067514909f, 0.81737804041911244f, 0.82030875512181523f, 0.82314158859569164f, 0.82586857889438514f, 0.82848052823709672f, 0.83096715251272624f, 0.83331972948645461f, 0.8355302318472394f, 0.83759238071186537f, 0.83950165618540074f, 0.84125554884475906f, 0.84285224824778615f, 0.84429066717717349f, 0.84557007254559347f, 0.84668970275699273f, 0.84764891761519268f, 0.84844741572055415f, 0.84908426422893801f, 0.84955892810989209f, 0.84987174283631584f, 0.85002186115856315f };
	static const float b18[] = { 0.8879736506427196f, 0.88723222096949894f, 0.88638056925514819f, 0.8854143767924102f, 0.88434120381311432f, 0.88316926967613829f, 0.88189704355001619f, 0.88053883390003362f, 0.87909766977173343f, 0.87757925784892632f, 0.87599242923439569f, 0.87434038553446281f, 0.8726282980930582f, 0.87086081657350445f, 0.86904036783694438f, 0.86716973322690072f, 0.865250882410458f, 0.86328528001070159f, 0.86127563500427884f, 0.85922399451306786f, 0.85713191328514948f, 0.85500206287010105f, 0.85283759062147024f, 0.85064441601050367f, 0.84842449296974021f, 0.84618210029578533f, 0.84392184786827984f, 0.8416486380471222f, 0.83936747464036732f, 0.8370834463093898f, 0.83480172950579679f, 0.83252816638059668f, 0.830266486168872f, 0.82802138994719998f, 0.82579737851082424f, 0.82359867586156521f, 0.82142922780433014f, 0.81929263384230377f, 0.81719217466726379f, 0.81513073920879264f, 0.81311116559949914f, 0.81113591855117928f, 0.80920618848056969f, 0.80732335380063447f, 0.80548841690679074f, 0.80370206267176914f, 0.8019646617300199f, 0.80027628545809526f, 0.79863674654537764f, 0.7970456043491897f, 0.79550271129031047f, 0.79400674021499107f, 0.79255653201306053f, 0.79115100459573173f, 0.78978892762640429f, 0.78846901316334561f, 0.78718994624696581f, 0.78595022706750484f, 0.78474835732694714f, 0.78358295593535587f, 0.78245259899346642f, 0.78135588237640097f, 0.78029141405636515f, 0.77925781820476592f, 0.77825345121025524f, 0.77727702680911992f, 0.77632748534275298f, 0.77540359142309845f, 0.7745041337932782f, 0.7736279426902245f, 0.77277386473440868f, 0.77194079697835083f, 0.77112734439057717f, 0.7703325054879735f, 0.76955552292313134f, 0.76879541714230948f, 0.76805119403344102f, 0.76732191489596169f, 0.76660663780645333f, 0.76590445660835849f, 0.76521446718174913f, 0.76453578734180083f, 0.76386719002130909f, 0.76320812763163837f, 0.76255780085924041f, 0.76191537149895305f, 0.76128000375662419f, 0.76065085571817748f, 0.76002709227883047f, 0.75940789891092741f, 0.75879242623025811f, 0.75817986436807139f, 0.75756936901859162f, 0.75696013660606487f, 0.75635120643246645f, 0.75574176474107924f, 0.7551311041857901f, 0.75451838884410671f, 0.75390276208285945f, 0.7532834105961016f, 0.75265946532566674f, 0.75203008099312696f, 0.75139443521914839f, 0.75075164989005116f, 0.75010086988227642f, 0.7494412559451894f, 0.74877193167001121f, 0.74809204459000522f, 0.74740073297543086f, 0.74669712855065784f, 0.74598030635707824f, 0.74524942637581271f, 0.74450365836708132f, 0.74374215223567086f, 0.7429640345324835f, 0.74216844571317986f, 0.74135450918099721f, 0.74052138580516735f, 0.73966820211715711f, 0.738794102296364f, 0.73789824784475078f, 0.73697977133881254f, 0.73603782546932739f, 0.73507157641157261f, 0.73408016787854391f, 0.7330627749243106f, 0.73201854033690505f, 0.73094665432902683f, 0.72984626791353258f, 0.72871656144003782f, 0.72755671317141346f, 0.72636587045135315f, 0.72514323778761092f, 0.72388798691323131f, 0.72259931993061044f, 0.72127639993530235f, 0.71991841524475775f, 0.71852454736176108f, 0.71709396919920232f, 0.71562585091587549f, 0.7141193695725726f, 0.71257368516500463f, 0.71098796522377461f, 0.70936134293478448f, 0.70769297607310577f, 0.70598200974806036f, 0.70422755780589941f, 0.7024287314570723f, 0.70058463496520773f, 0.69869434615073722f, 0.69675695810256544f, 0.69477149919380887f, 0.69273703471928827f, 0.69065253586464992f, 0.68851703379505125f, 0.68632948169606767f, 0.68408888788857214f, 0.68179411684486679f, 0.67944405399056851f, 0.67703755438090574f, 0.67457344743419545f, 0.67205052849120617f, 0.66946754331614522f, 0.66682322089824264f, 0.66411625298236909f, 0.66134526910944602f, 0.65850888806972308f, 0.65560566838453704f, 0.65263411711618635f, 0.64959272297892245f, 0.64647991652908243f, 0.64329409140765537f, 0.64003361803368586f, 0.63669675187488584f, 0.63328173520055586f, 0.62978680155026101f, 0.62621013451953023f, 0.62254988622392882f, 0.61880417410823019f, 0.61497112346096128f, 0.61104880679640927f, 0.60703532172064711f, 0.60292845431916875f, 0.5987265295935138f, 0.59442768517501066f, 0.59003011251063131f, 0.5855320765920552f, 0.58093191431832802f, 0.57622809660668717f, 0.57141871523555288f, 0.56650284911216653f, 0.56147964703993225f, 0.55634837474163779f, 0.55110853452703257f, 0.5457599924248665f, 0.54030245920406539f, 0.53473704282067103f, 0.52906500940336754f, 0.52328797535085236f, 0.51740807573979475f, 0.51142807215168951f, 0.50535164796654897f, 0.49918274588431072f, 0.49292595612342666f, 0.48658646495697461f, 0.48017007211645196f, 0.47368494725726878f, 0.46713728801395243f, 0.46053414662739794f, 0.45388335612058467f, 0.44719313715161618f, 0.44047194882050544f, 0.43372849999361113f, 0.42697404043749887f, 0.42021619665853854f, 0.41346259134143476f, 0.40672178082365834f, 0.40000214725256295f, 0.39331182532243375f, 0.38665868550105914f, 0.38005028528138707f, 0.37349382846504675f, 0.36699616136347685f, 0.36056376228111864f, 0.35420276066240958f, 0.34791888996380105f, 0.3417175669546984f, 0.33560648984600089f, 0.3295945757321303f, 0.32368100685760637f, 0.31786993834254956f, 0.31216524050888372f, 0.30657054493678321f, 0.30108922184065873f, 0.29574009929867601f, 0.29051361067988485f, 0.28541074411068496f, 0.28043398847505197f, 0.27559714652053702f, 0.27090279994325861f, 0.26634209349669508f, 0.26191675992376573f, 0.25765165093569542f, 0.2535289048041211f, 0.24954644291943817f, 0.24572497420147632f, 0.24205576625191821f, 0.23852974228695395f, 0.23517094067076993f, 0.23194647381302336f, 0.22874673279569585f, 0.22558727307410353f, 0.22243385243433622f, 0.2193005075652994f, 0.21618875376309582f, 0.21307651648984993f, 0.21387448578597812f, 0.2146562337112265f, 0.21542362939081539f, 0.21617499187076789f, 0.21690975060032436f, 0.21762721310371608f, 0.21833167885096033f, 0.21911516689288835f, 0.22000133917653536f, 0.22098759107715404f, 0.22207043213024291f, 0.22324568672294431f, 0.22451023616807558f, 0.22585960379408354f, 0.22728984778098055f, 0.22879681433956656f, 0.23037617493752832f, 0.23202360805926608f, 0.23373434258507808f, 0.23550427698321885f, 0.2373288009471749f, 0.23920260612763083f, 0.24112190491594204f, 0.24308218808684579f, 0.24507758869355967f, 0.24710443563450618f, 0.24915847093232929f, 0.25123493995942769f, 0.25332800295084507f, 0.25543478673717029f, 0.25755101595750435f, 0.25967245030364566f, 0.26179294097819672f, 0.26391006692119662f, 0.2660200572779356f, 0.26811904076941961f, 0.27020322893039511f, 0.27226772884656186f, 0.27430929404579435f, 0.27632534356790039f, 0.27831254595259397f, 0.28026769921081435f, 0.28218770540182386f, 0.2840695897279818f, 0.28591050458531014f, 0.2877077458811747f, 0.28945865397633169f, 0.29116024157313919f, 0.29281107506269488f, 0.29440901248173756f, 0.29595212005509081f, 0.29743856476285779f, 0.29886674369733968f, 0.30023519507728602f, 0.30154226437468967f, 0.30278652039631843f, 0.3039675809469457f, 0.30508479060294547f, 0.30613767928289148f, 0.30712600062348083f, 0.30804973095465449f, 0.30890905921943196f, 0.30970441249844921f, 0.31043636979038808f, 0.31110343446582983f, 0.31170911458932665f, 0.31225470169927194f, 0.31274172735821959f, 0.31317188565991266f, 0.31354553695453014f, 0.31386561956734976f, 0.314135190862664f, 0.31435662153833671f, 0.31453200120082569f, 0.3146630922831542f, 0.31475407592280041f, 0.31480767954534428f, 0.31482653406646727f, 0.31481299789187128f, 0.31477085207396532f, 0.31470295028655965f, 0.31461204226295625f, 0.31450102990914708f, 0.31437291554615371f, 0.31423043195101424f, 0.31407639883970623f, 0.3139136046337036f, 0.31374440956796529f, 0.31357126868520002f, 0.31339704333572083f, 0.31322399394183942f, 0.31305401163732732f, 0.31288922211590126f, 0.31273234839304942f, 0.31258523031121233f, 0.31244934410414688f, 0.31232652641170694f, 0.31221903291870201f, 0.31212881396435238f, 0.31205680685765741f, 0.31200463838728931f, 0.31197383273627388f, 0.31196698314912269f, 0.31198447195645718f, 0.31202765974624452f, 0.31209793953300591f, 0.31219689612063978f, 0.31232631707560987f, 0.31248673753935263f, 0.31267941819570189f, 0.31290560605819168f, 0.3131666792687211f, 0.3134643447952643f, 0.31379912926498488f, 0.31417223403606975f, 0.31458483752056837f, 0.31503813956872212f, 0.31553372323982209f, 0.3160724937230589f, 0.31665545668946665f, 0.31728380489244951f, 0.31795870784057567f, 0.31868137622277692f, 0.31945332332898302f, 0.3202754315314667f, 0.32114884306985791f, 0.32207478855218091f, 0.32305449047765694f, 0.32408913679491225f, 0.32518014084085567f, 0.32632861885644465f, 0.32753574162788762f, 0.3288027427038317f, 0.3301308728723546f, 0.33152138620958932f, 0.33297555200245399f, 0.33449469983585844f, 0.33607995965691828f, 0.3377325942005665f, 0.33945384341064017f, 0.3412449533046818f, 0.34310715173410822f, 0.34504169470809071f, 0.34704978520758401f, 0.34913260148542435f, 0.35129130890802607f, 0.35352709245374592f, 0.35584108091122535f, 0.35823439142300639f, 0.36070813602540136f, 0.36326337558360278f, 0.36590112443835765f, 0.36862236642234769f, 0.3714280448394211f, 0.37431909037543515f, 0.37729635531096678f, 0.380360657784311f, 0.38351275723852291f, 0.38675335037837993f, 0.39008308392311997f, 0.39350254000115381f, 0.39701221751773474f, 0.40061257089416885f, 0.40430398069682483f, 0.40808667584648967f, 0.41196089987122869f, 0.41592679539764366f, 0.41998440356963762f, 0.42413367909988375f, 0.42837450371258479f, 0.432706647838971f, 0.43712979856444761f, 0.44164332426364639f, 0.44624687186865436f, 0.45093985823706345f, 0.45572154742892063f, 0.46059116206904965f, 0.46554778281918402f, 0.47059039582133383f, 0.47571791879076081f, 0.48092913815357724f, 0.48622257801969754f, 0.49159667021646397f, 0.49705020621532009f, 0.50258161291269432f, 0.50818921213102985f, 0.51387124091909786f, 0.5196258425240281f, 0.52545108144834785f, 0.53134495942561433f, 0.53730535185141037f, 0.5433300863249918f, 0.54941691584603647f, 0.55556350867083815f, 0.56176745110546977f, 0.56802629178649788f, 0.57433746373459582f, 0.58069834805576737f, 0.58710626908082753f, 0.59355848909050757f, 0.60005214820435104f, 0.6065843782630862f, 0.61315221209322646f, 0.61975260637257923f, 0.62638245478933297f, 0.63303857040067113f, 0.63971766697672761f, 0.6464164243818421f, 0.65313137915422603f, 0.65985900156216504f, 0.66659570204682972f, 0.67333772009301907f, 0.68008125203631464f, 0.68682235874648545f, 0.69355697649863846f, 0.70027999028864962f, 0.70698561390212977f, 0.71367147811129228f, 0.72033299387284622f, 0.72696536998972039f, 0.73356368240541492f, 0.74012275762807056f, 0.74663719293664366f, 0.7530974636118285f, 0.7594994148789691f, 0.76583801477914104f, 0.77210610037674143f, 0.77829571667247499f, 0.78439788751383921f, 0.79039529663736285f, 0.796282666437655f, 0.80204612696863953f, 0.80766972324164554f, 0.81313419626911398f, 0.81841638963128993f, 0.82350476683173168f, 0.82838497261149613f, 0.8330486712880828f, 0.83748851001197089f, 0.84171925358069011f, 0.84575537519027078f, 0.84961373549150254f, 0.85330645352458923f, 0.85685572291039636f, 0.86027399927156634f, 0.86356595168669881f, 0.86673765046233331f, 0.86979617048190971f, 0.87274147101441557f, 0.87556785228242973f, 0.87828235285372469f, 0.88088414794024839f, 0.88336206121170946f, 0.88572538990087124f };
	// twilight shifted
	static const float r19[] = { 0.18739228342697645f, 0.18975853639094634f, 0.19199449184606268f, 0.19410351363791453f, 0.1960826032659409f, 0.19794834061899208f, 0.19971571438603364f, 0.20156133764129841f, 0.20352007949514977f, 0.20558051999470117f, 0.2077442377448806f, 0.21001214221188125f, 0.21237411048541005f, 0.21482843531473683f, 0.21737845072382705f, 0.22001251100779617f, 0.22272706739121817f, 0.22552164337737857f, 0.2283917709422868f, 0.23132955273021344f, 0.23433055727563878f, 0.23739062429054825f, 0.24050813332295939f, 0.24367372557466271f, 0.24688226237958999f, 0.25012845306199383f, 0.25340685873736807f, 0.25671191651083902f, 0.26003895187439957f, 0.26338121807151404f, 0.26673233211995284f, 0.27008637749114051f, 0.27343739342450812f, 0.27677939615815589f, 0.28010638576975472f, 0.28341239797185225f, 0.28669151388283165f, 0.28993792445176608f, 0.29314593096985248f, 0.29631000388905288f, 0.29942483960214772f, 0.30248536364574252f, 0.30548675819945936f, 0.30842444457210105f, 0.31129434479712365f, 0.31409278414755532f, 0.31681648089023501f, 0.31946262395497965f, 0.32202882276069322f, 0.32451307931207785f, 0.3269137124539796f, 0.32923005203231409f, 0.33146154891145124f, 0.33360804901486002f, 0.33566978565015315f, 0.33764732090671112f, 0.33954168752669694f, 0.34135411074506483f, 0.34308600291572294f, 0.34473901574536375f, 0.34631507175793091f, 0.34781653238777782f, 0.34924513554955644f, 0.35060304441931012f, 0.35189248608873791f, 0.35311574421123737f, 0.35427534960663759f, 0.35537415306906722f, 0.35641381143126327f, 0.35739663292915563f, 0.35832489966617809f, 0.35920088560930186f, 0.36002681809096376f, 0.36080493826624654f, 0.36153829010998356f, 0.36222809558295926f, 0.36287643560041027f, 0.36348537610385145f, 0.36405693022088509f, 0.36459308890125008f, 0.36509579845886808f, 0.36556698373538982f, 0.36600853966739794f, 0.36642243251550632f, 0.36681085540107988f, 0.36717513650699446f, 0.36751707094367697f, 0.36783843696531082f, 0.36814101479899719f, 0.36842655638020444f, 0.36869682231895268f, 0.36895355306596778f, 0.36919847837592484f, 0.36943334591276228f, 0.36965987626565955f, 0.36987980329025361f, 0.37009487130772695f, 0.37030682071842685f, 0.37051738634484427f, 0.37072833279422668f, 0.37094151551337329f, 0.37115856636209105f, 0.37138124223736607f, 0.37161133234400479f, 0.3718506155898596f, 0.37210089702443822f, 0.37236397858465387f, 0.37264166757849604f, 0.37293578646665032f, 0.37324816143326384f, 0.3735806215098284f, 0.37393499330475782f, 0.37431313199312338f, 0.37471686019302231f, 0.37514802505380473f, 0.37560846919442398f, 0.37610001286385814f, 0.37662448930806297f, 0.37718371844251231f, 0.37777949753513729f, 0.378413635091359f, 0.37908789283110761f, 0.37980403744848751f, 0.38056380696565623f, 0.38136887930454161f, 0.38222094988570376f, 0.38312168084402748f, 0.38407269378943537f, 0.38507556793651387f, 0.38613184178892102f, 0.38724301459330251f, 0.38841053300842432f, 0.38963580160340855f, 0.39092017571994903f, 0.39226494876209317f, 0.39367135736822567f, 0.39514058808207631f, 0.39667374905665609f, 0.3982719152586337f, 0.39993606933454834f, 0.40166714010896104f, 0.40346600333905397f, 0.40533343789303178f, 0.40727018694219069f, 0.4092768899914751f, 0.41135414697304568f, 0.41350245743314729f, 0.4157223260454232f, 0.41801414079233629f, 0.42037822361396326f, 0.42281485675772662f, 0.42532423665011354f, 0.42790652284925834f, 0.43056179073057571f, 0.43329008867358393f, 0.43609138958356369f, 0.43896563958048396f, 0.44191271766696399f, 0.44493246854215379f, 0.44802470933589172f, 0.45118918687617743f, 0.45442563977552913f, 0.45773377230160567f, 0.46111326647023881f, 0.46456376716303932f, 0.46808490970531597f, 0.47167629518877091f, 0.47533752394906287f, 0.47906816236197386f, 0.4828677867260272f, 0.4867359599430568f, 0.49067224938561221f, 0.4946761847863938f, 0.49874733661356069f, 0.5028853540415561f, 0.50708969576451657f, 0.51135992541601927f, 0.5156955988596057f, 0.52009627392235558f, 0.52456151470593582f, 0.529090861832473f, 0.53368389147728401f, 0.53834015575176275f, 0.54305932424018233f, 0.54784098153018634f, 0.55268450589347129f, 0.55758940419605174f, 0.56255515357219343f, 0.56758117853861967f, 0.5726668948158774f, 0.5778116438998202f, 0.58301487036932409f, 0.58827579780555495f, 0.59359335696837223f, 0.5989665814482068f, 0.60439434200274855f, 0.60987543176093062f, 0.61540846411770478f, 0.62099193064817548f, 0.62662402022604591f, 0.6323027138710603f, 0.63802586828545982f, 0.6437910831099849f, 0.64959573004253479f, 0.65543692326454717f, 0.6613112930078745f, 0.66721479803752815f, 0.67314422559426212f, 0.67909554499882152f, 0.68506446154395928f, 0.69104641009309098f, 0.6970365443886174f, 0.7030297722540817f, 0.70902078134539304f, 0.71500403076252128f, 0.72097280665536778f, 0.72692177512829703f, 0.73284543645523459f, 0.73873771700494939f, 0.74459247771890169f, 0.75040346765406696f, 0.75616443584381976f, 0.76186907937980286f, 0.76751108504417864f, 0.77308416590170936f, 0.77857892008227592f, 0.78399101042764918f, 0.78931445564608915f, 0.79454305089231114f, 0.79967075421267997f, 0.80469164429814577f, 0.8095999819094809f, 0.81438982121143089f, 0.81904654677937527f, 0.82357429680252847f, 0.82796894316013536f, 0.83222705712934408f, 0.83634031809191178f, 0.84030420805957784f, 0.8441261828674842f, 0.84780710702577922f, 0.85133714570857189f, 0.85472593189256985f, 0.85798259245670372f, 0.86110245436899846f, 0.86408985081463996f, 0.86696015505333579f, 0.86970474853509816f, 0.87233134085124076f, 0.87485347508575972f, 0.87724880858965482f, 0.8795410528270573f, 0.88172231059285788f, 0.88378520195539056f, 0.88575015840754434f, 0.88571155122845646f, 0.88554714811952384f, 0.88525897972630474f, 0.88485138159908572f, 0.88432713054113543f, 0.88369127145898041f, 0.88295168595448525f, 0.88211542489401606f, 0.88119169871341951f, 0.88019293315695812f, 0.87913244240792765f, 0.87802298436649007f, 0.87687848451614692f, 0.87571458709961403f, 0.87453793320260187f, 0.87335171360916275f, 0.87215331978454325f, 0.87093846717297507f, 0.86969131502613806f, 0.86839954695818633f, 0.86705314907048503f, 0.86564934325605325f, 0.86418343723941027f, 0.86265601051127572f, 0.86107117027565516f, 0.8594346370300241f, 0.85775662943504905f, 0.85604022314725403f, 0.85429219611470464f, 0.85251907207708444f, 0.85072697023178789f, 0.84892245563117641f, 0.84711195507965098f, 0.84529810731955113f, 0.84348529222933699f, 0.84167750766845151f, 0.83987839884120874f, 0.83809123476131964f, 0.83631898844737929f, 0.8345656905566583f, 0.83283277185777982f, 0.83112163529096306f, 0.82943407816481474f, 0.8277716072353446f, 0.82613549710580259f, 0.8245268129450285f, 0.82294635110428427f, 0.8213947205565636f, 0.81987230650455289f, 0.81837931164498223f, 0.81691575775055891f, 0.81548146627279483f, 0.81407611046993344f, 0.81269922039881493f, 0.81135014011763329f, 0.81002809466520687f, 0.80873219170089694f, 0.8074614045096935f, 0.80621460526927058f, 0.80499054790810298f, 0.80378792531077625f, 0.80260531146112946f, 0.80144124292560048f, 0.80029415389753977f, 0.7991624518501963f, 0.79804447815136637f, 0.79693854719951607f, 0.79584292379583765f, 0.79475585972654039f, 0.79367559698664958f, 0.79260034304237448f, 0.79152832843475607f, 0.79045776847727878f, 0.78938737766251943f, 0.78831514045623963f, 0.78723904108188347f, 0.78615737132332963f, 0.78506845019606841f, 0.78397060836414478f, 0.78286225264440912f, 0.78174180478981836f, 0.78060774749483774f, 0.77945862731506643f, 0.77829345807633121f, 0.7771103295521099f, 0.77590790730685699f, 0.77468494746063199f, 0.77344021829889886f, 0.77217257229605551f, 0.77088091962302474f, 0.7695642334401418f, 0.76822176599735303f, 0.76685228950643891f, 0.76545492593330511f, 0.76402885609288662f, 0.76257333554052609f, 0.7610876378057071f, 0.75957111105340058f, 0.75802325538455839f, 0.75644341577140706f, 0.75483105066959544f, 0.75318566369046569f, 0.75150685045891663f, 0.74979420547170472f, 0.74804739275559562f, 0.74626615789163442f, 0.74445018676570673f, 0.7425992159973317f, 0.74071301619506091f, 0.73879140024599266f, 0.73683422173585866f, 0.73484133598564938f, 0.73281270506268747f, 0.73074820754845171f, 0.72864773856716547f, 0.72651122900227549f, 0.72433865647781592f, 0.7221299918421461f, 0.71988521490549851f, 0.71760444908133847f, 0.71528760614847287f, 0.71293466839773467f, 0.7105456546582587f, 0.70812059568420482f, 0.70565951122610093f, 0.70316249458814151f, 0.70062962477242097f, 0.6980608153581771f, 0.69545608346891119f, 0.69281544846764931f, 0.6901389321505248f, 0.68742656435169625f, 0.68467850942494535f, 0.68189457150944521f, 0.67907474028157344f, 0.67621897924409746f, 0.67332725564817331f, 0.67039959547676198f, 0.66743603766369131f, 0.66443632469878844f, 0.66140037532601781f, 0.6583280801134499f, 0.65521932609327127f, 0.65207417290277303f, 0.64889230169458245f, 0.64567349382645434f, 0.642417577481186f, 0.6391243387840212f, 0.6357937104834237f, 0.63242534854210275f, 0.62901892016985872f, 0.62557416500434959f, 0.62209079821082613f, 0.61856865258877192f, 0.61500723236391375f, 0.6114062072731884f, 0.60776523994818654f, 0.60408401696732739f, 0.60036213010411577f, 0.59659918109122367f, 0.59279480536520257f, 0.58894861935544707f, 0.58506024396466882f, 0.58112932761586555f, 0.57715550812992045f, 0.57313845754107873f, 0.56907784784011428f, 0.56497343529017696f, 0.56082499039117173f, 0.55663229034969341f, 0.55239521572711914f, 0.54811370033467621f, 0.54378771313608565f, 0.53941736649199057f, 0.5350027976174474f, 0.53054420489856446f, 0.52604189625477482f, 0.52149652863229956f, 0.51690848800544464f, 0.51227835105321762f, 0.50760681181053691f, 0.50289524974970612f, 0.49814435462074153f, 0.49335504375145617f, 0.48852847371852987f, 0.48366628618847957f, 0.47877034239726296f, 0.473841437035254f, 0.46888111384598413f, 0.46389102840284874f, 0.45887288947308297f, 0.45383005086999889f, 0.44876299173174822f, 0.44367358645071275f, 0.43856378187931538f, 0.4334355841041439f, 0.42829101315789753f, 0.42313214269556043f, 0.41796105205173684f, 0.41277985630360303f, 0.40759120392688708f, 0.40239692379737496f, 0.39719876876325577f, 0.39199887556812907f, 0.38679939079544168f, 0.38160247377467543f, 0.3764103053221462f, 0.37122508431309342f, 0.36605031412464006f, 0.36088752387578377f, 0.35573889947341125f, 0.35060678246032478f, 0.34549355713871799f, 0.34040164359597463f, 0.33533353224455448f, 0.33029174471181438f, 0.32527888860401261f, 0.32029986557994061f, 0.31535870009205808f, 0.31045520848595526f, 0.30559226007249934f, 0.30077276812918691f, 0.2960004726065818f, 0.29128515387578635f, 0.28662309235899847f, 0.28201746297366942f, 0.27747150809142801f, 0.27299701518897301f, 0.26859095948172862f, 0.26425512207060942f, 0.25999463887892144f, 0.25582135547481771f, 0.25172899728289466f, 0.24772092990501099f, 0.24381149720247919f, 0.23999586188690308f, 0.23627495835774248f, 0.23266299920501882f, 0.22915620278592841f, 0.2257539681670791f, 0.22247308588973624f, 0.21930503925136402f, 0.21625279838647882f, 0.2133313859647627f, 0.21052882914958676f, 0.20785704662965598f, 0.20531725273301316f, 0.20290365333558247f, 0.20058760685133747f, 0.19819343656336558f, 0.19571853588267552f, 0.1931548636579131f, 0.19049578401722037f, 0.18774482037046955f, 0.18488035509396164f };
	static const float g19[] = { 0.077102096899588329f, 0.075019861862143766f, 0.073182830649273306f, 0.071608304856891569f, 0.070321227242423623f, 0.069314066071660657f, 0.068592710553704722f, 0.067983271026200248f, 0.067444179612424215f, 0.066990462397868739f, 0.06661453200418091f, 0.066308573918947178f, 0.066085024661758446f, 0.065940385613778491f, 0.065859661233562045f, 0.065857918918907604f, 0.065933790675651943f, 0.066078173119395595f, 0.06628997924139618f, 0.066576186939090592f, 0.066935599661639394f, 0.067365888050555517f, 0.067857103814855602f, 0.068419855150922693f, 0.069053639449204451f, 0.069758206429106989f, 0.070533582926851829f, 0.071380106242082242f, 0.072294781043362205f, 0.073281657939897077f, 0.074344018028546205f, 0.075483675584275545f, 0.076702800237496066f, 0.078003941033788216f, 0.079389994802261526f, 0.080864153365499375f, 0.082429873848480689f, 0.08409078829085731f, 0.085850656889620708f, 0.087713250960463951f, 0.089682253716750038f, 0.091761187397303601f, 0.093952764840823738f, 0.096259385340577736f, 0.098684771934052201f, 0.10123077676403242f, 0.10389861387653518f, 0.10668879882392659f, 0.10960114111258401f, 0.11263459791730848f, 0.1157873496841953f, 0.11905764321981127f, 0.12244245263391232f, 0.12593818301005921f, 0.12954074251271822f, 0.13324562282438077f, 0.13704801896718169f, 0.1409427920655632f, 0.14492465359918028f, 0.14898820589826409f, 0.15312802296627787f, 0.15733863511152979f, 0.16161477763045118f, 0.16595129984720861f, 0.17034320478524959f, 0.17478570377561287f, 0.17927413271618647f, 0.18380392577704466f, 0.18837119869242164f, 0.19297208197842461f, 0.197602942459778f, 0.20226037920758122f, 0.20694122817889948f, 0.21164251793458128f, 0.21636111429594002f, 0.22109488427338303f, 0.22584149293287031f, 0.23059876218396419f, 0.23536470386204195f, 0.24013747024823828f, 0.24491536803550484f, 0.24969683475296395f, 0.25448043878086224f, 0.25926481158628106f, 0.26404857724525643f, 0.26883085667326956f, 0.27361063317090978f, 0.27838697181297761f, 0.28315901221182987f, 0.28792596437778462f, 0.29268709856150099f, 0.29744175492366276f, 0.30218932176507068f, 0.30692923551862339f, 0.31166098762951971f, 0.31638410101153364f, 0.3210981375964933f, 0.32580269697872455f, 0.33049741244307851f, 0.33518193808489577f, 0.33985591488818123f, 0.34451911410230168f, 0.34917126878479027f, 0.3538121372967869f, 0.35844148285875221f, 0.36305909736982378f, 0.36766477862108266f, 0.37225835004836849f, 0.37683963835219841f, 0.38140848555753937f, 0.38596474386057539f, 0.39050827529375831f, 0.39503894828283309f, 0.3995566498711684f, 0.4040612609993941f, 0.40855267638072096f, 0.41303079952477062f, 0.41749553747893614f, 0.42194680223454828f, 0.4263845142616835f, 0.43080859411413064f, 0.43521897612544935f, 0.43961558821222629f, 0.44399837208633719f, 0.44836727669277859f, 0.45272225034283325f, 0.45706323581407199f, 0.46139018782416635f, 0.46570306719930193f, 0.4700018340988123f, 0.47428645933635388f, 0.47855691131792805f, 0.48281316715123496f, 0.48705520251223039f, 0.49128300332899261f, 0.49549655777451179f, 0.49969585326377758f, 0.50388089053847973f, 0.50805166539276136f, 0.51220818143218516f, 0.51635044969688759f, 0.52047847653840029f, 0.52459228174983119f, 0.52869188011057411f, 0.53277730177130322f, 0.53684857765005933f, 0.54090574771098476f, 0.54494882715350401f, 0.54897785421888889f, 0.55299287158108168f, 0.55699392126996583f, 0.56098104959950301f, 0.5649543060909209f, 0.56891374572457176f, 0.57285941625606673f, 0.57679137998186081f, 0.58070969241098491f, 0.58461441100175571f, 0.5885055998308617f, 0.59238331452146575f, 0.59624762051353541f, 0.60009859503858665f, 0.60393630046586455f, 0.607760777169989f, 0.61157208822864151f, 0.61537028695790286f, 0.61915543242884641f, 0.62292757283835809f, 0.62668676251860134f, 0.6304330455306234f, 0.63416646251100506f, 0.63788704858847078f, 0.64159484119504429f, 0.6452898684900934f, 0.64897216734095264f, 0.65264172403146448f, 0.65629853981831865f, 0.65994260812897998f, 0.66357391434030388f, 0.66719242996142225f, 0.67079812302806219f, 0.67439093705212727f, 0.67797081129095405f, 0.68153767253065878f, 0.68509142218509878f, 0.68863194515166382f, 0.69215911458254054f, 0.69567278381629649f, 0.69917279302646274f, 0.7026589535425779f, 0.70613106157153982f, 0.70958887676997473f, 0.71303214646458135f, 0.7164606049658685f, 0.71987394892246725f, 0.7232718614323369f, 0.72665398759758293f, 0.73001995232739691f, 0.73336934798923203f, 0.73670175403699445f, 0.74001672160131404f, 0.74331376714033193f, 0.7465923800833657f, 0.74985201221941766f, 0.75309208756768431f, 0.75631202708719025f, 0.7595112803730375f, 0.76268908733890484f, 0.76584472131395898f, 0.7689774029354699f, 0.77208629460678091f, 0.77517050008066057f, 0.77822904973358131f, 0.78126088716070907f, 0.78426487091581187f, 0.78723995923452639f, 0.7901846863592763f, 0.79309746468844067f, 0.79597665735031009f, 0.79882047719583249f, 0.80162699008965321f, 0.80439408733477935f, 0.80711949387647486f, 0.8098007598713145f, 0.81243524735466011f, 0.81502089378742548f, 0.81755426400533426f, 0.82003213188702007f, 0.82245116226304615f, 0.82480781812080928f, 0.82709838780560663f, 0.82931896673505456f, 0.83146558694197847f, 0.8335364929949034f, 0.83552487764795436f, 0.83742600751395202f, 0.83923490627754482f, 0.84094796518951942f, 0.8425605950855084f, 0.84406482711037389f, 0.8454546229209523f, 0.84672735796116472f, 0.84787488124672816f, 0.84888934810281835f, 0.84976754857001258f, 0.85050391167507788f, 0.8510896085314068f, 0.85152403004797894f, 0.85180165478080894f, 0.85191526123023187f, 0.85187028338870274f, 0.85165675407495722f, 0.85127594077653468f, 0.85072940540310626f, 0.85000924943067835f, 0.85002186115856315f, 0.84987174283631584f, 0.84955892810989209f, 0.84908426422893801f, 0.84844741572055415f, 0.84764891761519268f, 0.84668970275699273f, 0.84557007254559347f, 0.84429066717717349f, 0.84285224824778615f, 0.84125554884475906f, 0.83950165618540074f, 0.83759238071186537f, 0.8355302318472394f, 0.83331972948645461f, 0.83096715251272624f, 0.82848052823709672f, 0.82586857889438514f, 0.82314158859569164f, 0.82030875512181523f, 0.81737804041911244f, 0.81435544067514909f, 0.81124644224653542f, 0.80805523804261525f, 0.80478517909812231f, 0.8014392309950078f, 0.79801963142713928f, 0.79452963601550608f, 0.79097196777091994f, 0.78734936133548439f, 0.78366457342383888f, 0.77992021407650147f, 0.77611880236047159f, 0.77226338601044719f, 0.76835660399870176f, 0.76440101200982946f, 0.76039907199779677f, 0.75635314860808633f, 0.75226548952875261f, 0.7481379479992134f, 0.74397271817459876f, 0.73977184647638616f, 0.7355371221572935f, 0.73127023324078089f, 0.72697275518238258f, 0.72264614312088882f, 0.71829177331290062f, 0.7139109141951604f, 0.70950474978787481f, 0.70507438189635097f, 0.70062083014783982f, 0.69614505508308089f, 0.69164794791482131f, 0.68713033714618876f, 0.68259301546243389f, 0.67803672673971815f, 0.67346216702194517f, 0.6688700095398864f, 0.66426089585282289f, 0.65963545027564163f, 0.65499426549472628f, 0.65033793748103852f, 0.64566703459218766f, 0.64098213306749863f, 0.63628379372029187f, 0.63157258225089552f, 0.62684905679296699f, 0.62211378808451145f, 0.61736734400220705f, 0.61261029334072192f, 0.60784322087037024f, 0.60306670593147205f, 0.59828134277062461f, 0.5934875421745599f, 0.58868600173562435f, 0.58387743744557208f, 0.5790624629815756f, 0.5742417003617839f, 0.56941578326710418f, 0.56458533111166875f, 0.55975098052594863f, 0.55491335744890613f, 0.55007308413977274f, 0.54523059488426595f, 0.54038674910561235f, 0.53554217882461186f, 0.53069749384776732f, 0.52585332093451564f, 0.5210102658711383f, 0.51616892643469103f, 0.5113298901696085f, 0.50649362371287909f, 0.5016608471009063f, 0.49683212909727231f, 0.49200802533379656f, 0.48718906673415824f, 0.48237579130289127f, 0.47756871222057079f, 0.4727682731566229f, 0.46797501437948458f, 0.46318942799460555f, 0.45841199172949604f, 0.45364314496866825f, 0.44888333481548809f, 0.44413297780351974f, 0.43939245044973502f, 0.43466217184617112f, 0.42994254036133867f, 0.4252339389526239f, 0.42053672992315327f, 0.41585125850290111f, 0.41117787004519513f, 0.4065168468778026f, 0.401868526884681f, 0.39723324476747235f, 0.3926113126792577f, 0.38800301593162145f, 0.38340864508963057f, 0.37882848839337313f, 0.37426272710686193f, 0.36971170225223449f, 0.36517570519856757f, 0.36065500290840113f, 0.35614985523380299f, 0.35166052978120937f, 0.34718723719597999f, 0.34273019305341756f, 0.33828976326048621f, 0.33386622163232865f, 0.32945984647042675f, 0.32507091815606004f, 0.32069970535138104f, 0.31634634821222207f, 0.31201133280550686f, 0.30769497879760166f, 0.30339762792450425f, 0.29911962764489264f, 0.29486126309253047f, 0.29062280081258873f, 0.28640483614256179f, 0.28220778870555907f, 0.27803210957665631f, 0.27387826652410152f, 0.26974650525236699f, 0.26563755336209077f, 0.26155203161615281f, 0.257490519876798f, 0.25345365461983138f, 0.24944185818822678f, 0.24545598775548677f, 0.24149689191922535f, 0.23756535071152696f, 0.2336621873300741f, 0.22978799249179921f, 0.22594402043981826f, 0.22213124697023234f, 0.21835070166659282f, 0.21460331490206347f, 0.21089030138947745f, 0.207212956082026f, 0.20357251410079796f, 0.19997020971775276f, 0.19640737049066315f, 0.19288548904692518f, 0.18940601489760422f, 0.18597036007065024f, 0.18258004462335425f, 0.17923664950367169f, 0.17594170887918095f, 0.17269677158182117f, 0.16950338809328983f, 0.1663630904279047f, 0.16327738551419116f, 0.16024769309971934f, 0.15727540775107324f, 0.15436183633886777f, 0.15150818660835483f, 0.14871544765633712f, 0.14598463068714407f, 0.14331656120063752f, 0.14071192654913128f, 0.13817086581280427f, 0.13569380302451714f, 0.13328091630401023f, 0.13093210934893723f, 0.12864679022013889f, 0.12642401401409453f, 0.12426354237989065f, 0.12216445576414045f, 0.12012561256850712f, 0.11814571137706886f, 0.11622183788331528f, 0.11435355574622549f, 0.11253912421257944f, 0.11077667828375456f, 0.1090642347484701f, 0.1073997763055258f, 0.10578120994917611f, 0.10420644885760968f, 0.1026734006932461f, 0.10117945586419633f, 0.099722930314950553f, 0.098302320968278623f, 0.09691583650296684f, 0.09556181960083443f, 0.094238731263712183f, 0.092945198093777909f, 0.091679997480262732f, 0.090440685427697898f, 0.089227194362745205f, 0.088038974350243354f, 0.08687555176033529f, 0.085736654965126335f, 0.084622236191702671f, 0.083532434119003962f, 0.08246763389003825f, 0.081428390076546092f, 0.080412994737554838f, 0.079420997315243186f, 0.078456871676182177f, 0.077521963107537312f, 0.076617824336164764f, 0.075745336000958424f, 0.074899049847466703f, 0.074088460826808866f, 0.073315693214040967f, 0.072582969899254779f, 0.071883555446163511f, 0.071226716277922458f, 0.070616595622995437f, 0.070053855603861875f, 0.06953231029187984f, 0.069064630826035506f, 0.068653337909486523f, 0.068289851529011875f, 0.067985029964779953f, 0.06774359820987802f, 0.067557104388479783f, 0.067434730871152565f, 0.067382132300147474f, 0.067388214053092838f, 0.067465786362940039f, 0.067616330270516389f, 0.067830148426026665f, 0.06812195249816172f, 0.068484398797025281f, 0.068919592266397572f, 0.069435248580458964f, 0.070064576149984209f, 0.070974625252738788f, 0.072157781039602742f, 0.073606819040117955f, 0.075311278416787641f, 0.077251588468039312f, 0.079425730279723883f };
	static const float b19[] = { 0.21618875376309582f, 0.2193005075652994f, 0.22243385243433622f, 0.22558727307410353f, 0.22874673279569585f, 0.23194647381302336f, 0.23517094067076993f, 0.23852974228695395f, 0.24205576625191821f, 0.24572497420147632f, 0.24954644291943817f, 0.2535289048041211f, 0.25765165093569542f, 0.26191675992376573f, 0.26634209349669508f, 0.27090279994325861f, 0.27559714652053702f, 0.28043398847505197f, 0.28541074411068496f, 0.29051361067988485f, 0.29574009929867601f, 0.30108922184065873f, 0.30657054493678321f, 0.31216524050888372f, 0.31786993834254956f, 0.32368100685760637f, 0.3295945757321303f, 0.33560648984600089f, 0.3417175669546984f, 0.34791888996380105f, 0.35420276066240958f, 0.36056376228111864f, 0.36699616136347685f, 0.37349382846504675f, 0.38005028528138707f, 0.38665868550105914f, 0.39331182532243375f, 0.40000214725256295f, 0.40672178082365834f, 0.41346259134143476f, 0.42021619665853854f, 0.42697404043749887f, 0.43372849999361113f, 0.44047194882050544f, 0.44719313715161618f, 0.45388335612058467f, 0.46053414662739794f, 0.46713728801395243f, 0.47368494725726878f, 0.48017007211645196f, 0.48658646495697461f, 0.49292595612342666f, 0.49918274588431072f, 0.50535164796654897f, 0.51142807215168951f, 0.51740807573979475f, 0.52328797535085236f, 0.52906500940336754f, 0.53473704282067103f, 0.54030245920406539f, 0.5457599924248665f, 0.55110853452703257f, 0.55634837474163779f, 0.56147964703993225f, 0.56650284911216653f, 0.57141871523555288f, 0.57622809660668717f, 0.58093191431832802f, 0.5855320765920552f, 0.59003011251063131f, 0.59442768517501066f, 0.5987265295935138f, 0.60292845431916875f, 0.60703532172064711f, 0.61104880679640927f, 0.61497112346096128f, 0.61880417410823019f, 0.62254988622392882f, 0.62621013451953023f, 0.62978680155026101f, 0.63328173520055586f, 0.63669675187488584f, 0.64003361803368586f, 0.64329409140765537f, 0.64647991652908243f, 0.64959272297892245f, 0.65263411711618635f, 0.65560566838453704f, 0.65850888806972308f, 0.66134526910944602f, 0.66411625298236909f, 0.66682322089824264f, 0.66946754331614522f, 0.67205052849120617f, 0.67457344743419545f, 0.67703755438090574f, 0.67944405399056851f, 0.68179411684486679f, 0.68408888788857214f, 0.68632948169606767f, 0.68851703379505125f, 0.69065253586464992f, 0.69273703471928827f, 0.69477149919380887f, 0.69675695810256544f, 0.69869434615073722f, 0.70058463496520773f, 0.7024287314570723f, 0.70422755780589941f, 0.70598200974806036f, 0.70769297607310577f, 0.70936134293478448f, 0.71098796522377461f, 0.71257368516500463f, 0.7141193695725726f, 0.71562585091587549f, 0.71709396919920232f, 0.71852454736176108f, 0.71991841524475775f, 0.72127639993530235f, 0.72259931993061044f, 0.72388798691323131f, 0.72514323778761092f, 0.72636587045135315f, 0.72755671317141346f, 0.72871656144003782f, 0.72984626791353258f, 0.73094665432902683f, 0.73201854033690505f, 0.7330627749243106f, 0.73408016787854391f, 0.73507157641157261f, 0.73603782546932739f, 0.73697977133881254f, 0.73789824784475078f, 0.738794102296364f, 0.73966820211715711f, 0.74052138580516735f, 0.74135450918099721f, 0.74216844571317986f, 0.7429640345324835f, 0.74374215223567086f, 0.74450365836708132f, 0.74524942637581271f, 0.74598030635707824f, 0.74669712855065784f, 0.74740073297543086f, 0.74809204459000522f, 0.74877193167001121f, 0.7494412559451894f, 0.75010086988227642f, 0.75075164989005116f, 0.75139443521914839f, 0.75203008099312696f, 0.75265946532566674f, 0.7532834105961016f, 0.75390276208285945f, 0.75451838884410671f, 0.7551311041857901f, 0.75574176474107924f, 0.75635120643246645f, 0.75696013660606487f, 0.75756936901859162f, 0.75817986436807139f, 0.75879242623025811f, 0.75940789891092741f, 0.76002709227883047f, 0.76065085571817748f, 0.76128000375662419f, 0.76191537149895305f, 0.76255780085924041f, 0.76320812763163837f, 0.76386719002130909f, 0.76453578734180083f, 0.76521446718174913f, 0.76590445660835849f, 0.76660663780645333f, 0.76732191489596169f, 0.76805119403344102f, 0.76879541714230948f, 0.76955552292313134f, 0.7703325054879735f, 0.77112734439057717f, 0.77194079697835083f, 0.77277386473440868f, 0.7736279426902245f, 0.7745041337932782f, 0.77540359142309845f, 0.77632748534275298f, 0.77727702680911992f, 0.77825345121025524f, 0.77925781820476592f, 0.78029141405636515f, 0.78135588237640097f, 0.78245259899346642f, 0.78358295593535587f, 0.78474835732694714f, 0.78595022706750484f, 0.78718994624696581f, 0.78846901316334561f, 0.78978892762640429f, 0.79115100459573173f, 0.79255653201306053f, 0.79400674021499107f, 0.79550271129031047f, 0.7970456043491897f, 0.79863674654537764f, 0.80027628545809526f, 0.8019646617300199f, 0.80370206267176914f, 0.80548841690679074f, 0.80732335380063447f, 0.80920618848056969f, 0.81113591855117928f, 0.81311116559949914f, 0.81513073920879264f, 0.81719217466726379f, 0.81929263384230377f, 0.82142922780433014f, 0.82359867586156521f, 0.82579737851082424f, 0.82802138994719998f, 0.830266486168872f, 0.83252816638059668f, 0.83480172950579679f, 0.8370834463093898f, 0.83936747464036732f, 0.8416486380471222f, 0.84392184786827984f, 0.84618210029578533f, 0.84842449296974021f, 0.85064441601050367f, 0.85283759062147024f, 0.85500206287010105f, 0.85713191328514948f, 0.85922399451306786f, 0.86127563500427884f, 0.86328528001070159f, 0.865250882410458f, 0.86716973322690072f, 0.86904036783694438f, 0.87086081657350445f, 0.8726282980930582f, 0.87434038553446281f, 0.87599242923439569f, 0.87757925784892632f, 0.87909766977173343f, 0.88053883390003362f, 0.88189704355001619f, 0.88316926967613829f, 0.88434120381311432f, 0.8854143767924102f, 0.88638056925514819f, 0.88723222096949894f, 0.8879736506427196f, 0.88572538990087124f, 0.88336206121170946f, 0.88088414794024839f, 0.87828235285372469f, 0.87556785228242973f, 0.87274147101441557f, 0.86979617048190971f, 0.86673765046233331f, 0.86356595168669881f, 0.86027399927156634f, 0.85685572291039636f, 0.85330645352458923f, 0.84961373549150254f, 0.84575537519027078f, 0.84171925358069011f, 0.83748851001197089f, 0.8330486712880828f, 0.82838497261149613f, 0.82350476683173168f, 0.81841638963128993f, 0.81313419626911398f, 0.80766972324164554f, 0.80204612696863953f, 0.796282666437655f, 0.79039529663736285f, 0.78439788751383921f, 0.77829571667247499f, 0.77210610037674143f, 0.76583801477914104f, 0.7594994148789691f, 0.7530974636118285f, 0.74663719293664366f, 0.74012275762807056f, 0.73356368240541492f, 0.72696536998972039f, 0.72033299387284622f, 0.71367147811129228f, 0.70698561390212977f, 0.70027999028864962f, 0.69355697649863846f, 0.68682235874648545f, 0.68008125203631464f, 0.67333772009301907f, 0.66659570204682972f, 0.65985900156216504f, 0.65313137915422603f, 0.6464164243818421f, 0.63971766697672761f, 0.63303857040067113f, 0.62638245478933297f, 0.61975260637257923f, 0.61315221209322646f, 0.6065843782630862f, 0.60005214820435104f, 0.59355848909050757f, 0.58710626908082753f, 0.58069834805576737f, 0.57433746373459582f, 0.56802629178649788f, 0.56176745110546977f, 0.55556350867083815f, 0.54941691584603647f, 0.5433300863249918f, 0.53730535185141037f, 0.53134495942561433f, 0.52545108144834785f, 0.5196258425240281f, 0.51387124091909786f, 0.50818921213102985f, 0.50258161291269432f, 0.49705020621532009f, 0.49159667021646397f, 0.48622257801969754f, 0.48092913815357724f, 0.47571791879076081f, 0.47059039582133383f, 0.46554778281918402f, 0.46059116206904965f, 0.45572154742892063f, 0.45093985823706345f, 0.44624687186865436f, 0.44164332426364639f, 0.43712979856444761f, 0.432706647838971f, 0.42837450371258479f, 0.42413367909988375f, 0.41998440356963762f, 0.41592679539764366f, 0.41196089987122869f, 0.40808667584648967f, 0.40430398069682483f, 0.40061257089416885f, 0.39701221751773474f, 0.39350254000115381f, 0.39008308392311997f, 0.38675335037837993f, 0.38351275723852291f, 0.380360657784311f, 0.37729635531096678f, 0.37431909037543515f, 0.3714280448394211f, 0.36862236642234769f, 0.36590112443835765f, 0.36326337558360278f, 0.36070813602540136f, 0.35823439142300639f, 0.35584108091122535f, 0.35352709245374592f, 0.35129130890802607f, 0.34913260148542435f, 0.34704978520758401f, 0.34504169470809071f, 0.34310715173410822f, 0.3412449533046818f, 0.33945384341064017f, 0.3377325942005665f, 0.33607995965691828f, 0.33449469983585844f, 0.33297555200245399f, 0.33152138620958932f, 0.3301308728723546f, 0.3288027427038317f, 0.32753574162788762f, 0.32632861885644465f, 0.32518014084085567f, 0.32408913679491225f, 0.32305449047765694f, 0.32207478855218091f, 0.32114884306985791f, 0.3202754315314667f, 0.31945332332898302f, 0.31868137622277692f, 0.31795870784057567f, 0.31728380489244951f, 0.31665545668946665f, 0.3160724937230589f, 0.31553372323982209f, 0.31503813956872212f, 0.31458483752056837f, 0.31417223403606975f, 0.31379912926498488f, 0.3134643447952643f, 0.3131666792687211f, 0.31290560605819168f, 0.31267941819570189f, 0.31248673753935263f, 0.31232631707560987f, 0.31219689612063978f, 0.31209793953300591f, 0.31202765974624452f, 0.31198447195645718f, 0.31196698314912269f, 0.31197383273627388f, 0.31200463838728931f, 0.31205680685765741f, 0.31212881396435238f, 0.31221903291870201f, 0.31232652641170694f, 0.31244934410414688f, 0.31258523031121233f, 0.31273234839304942f, 0.31288922211590126f, 0.31305401163732732f, 0.31322399394183942f, 0.31339704333572083f, 0.31357126868520002f, 0.31374440956796529f, 0.3139136046337036f, 0.31407639883970623f, 0.31423043195101424f, 0.31437291554615371f, 0.31450102990914708f, 0.31461204226295625f, 0.31470295028655965f, 0.31477085207396532f, 0.31481299789187128f, 0.31482653406646727f, 0.31480767954534428f, 0.31475407592280041f, 0.3146630922831542f, 0.31453200120082569f, 0.31435662153833671f, 0.314135190862664f, 0.31386561956734976f, 0.31354553695453014f, 0.31317188565991266f, 0.31274172735821959f, 0.31225470169927194f, 0.31170911458932665f, 0.31110343446582983f, 0.31043636979038808f, 0.30970441249844921f, 0.30890905921943196f, 0.30804973095465449f, 0.30712600062348083f, 0.30613767928289148f, 0.30508479060294547f, 0.3039675809469457f, 0.30278652039631843f, 0.30154226437468967f, 0.30023519507728602f, 0.29886674369733968f, 0.29743856476285779f, 0.29595212005509081f, 0.29440901248173756f, 0.29281107506269488f, 0.29116024157313919f, 0.28945865397633169f, 0.2877077458811747f, 0.28591050458531014f, 0.2840695897279818f, 0.28218770540182386f, 0.28026769921081435f, 0.27831254595259397f, 0.27632534356790039f, 0.27430929404579435f, 0.27226772884656186f, 0.27020322893039511f, 0.26811904076941961f, 0.2660200572779356f, 0.26391006692119662f, 0.26179294097819672f, 0.25967245030364566f, 0.25755101595750435f, 0.25543478673717029f, 0.25332800295084507f, 0.25123493995942769f, 0.24915847093232929f, 0.24710443563450618f, 0.24507758869355967f, 0.24308218808684579f, 0.24112190491594204f, 0.23920260612763083f, 0.2373288009471749f, 0.23550427698321885f, 0.23373434258507808f, 0.23202360805926608f, 0.23037617493752832f, 0.22879681433956656f, 0.22728984778098055f, 0.22585960379408354f, 0.22451023616807558f, 0.22324568672294431f, 0.22207043213024291f, 0.22098759107715404f, 0.22000133917653536f, 0.21911516689288835f, 0.21833167885096033f, 0.21762721310371608f, 0.21690975060032436f, 0.21617499187076789f, 0.21542362939081539f, 0.2146562337112265f, 0.21387448578597812f, 0.21307651648984993f };
	// turbo
	static const float r20[] = { 0.18995f,0.19483f,0.19956f,0.20415f,0.20860f,0.21291f,0.21708f,0.22111f,0.22500f,0.22875f,0.23236f,0.23582f,0.23915f,0.24234f,0.24539f,0.24830f,0.25107f,0.25369f,0.25618f,0.25853f,0.26074f,0.26280f,0.26473f,0.26652f,0.26816f,0.26967f,0.27103f,0.27226f,0.27334f,0.27429f,0.27509f,0.27576f,0.27628f,0.27667f,0.27691f,0.27701f,0.27698f,0.27680f,0.27648f,0.27603f,0.27543f,0.27469f,0.27381f,0.27273f,0.27106f,0.26878f,0.26592f,0.26252f,0.25862f,0.25425f,0.24946f,0.24427f,0.23874f,0.23288f,0.22676f,0.22039f,0.21382f,0.20708f,0.20021f,0.19326f,0.18625f,0.17923f,0.17223f,0.16529f,0.15844f,0.15173f,0.14519f,0.13886f,0.13278f,0.12698f,0.12151f,0.11639f,0.11167f,0.10738f,0.10357f,0.10026f,0.09750f,0.09532f,0.09377f,0.09287f,0.09267f,0.09320f,0.09451f,0.09662f,0.09958f,0.10342f,0.10815f,0.11374f,0.12014f,0.12733f,0.13526f,0.14391f,0.15323f,0.16319f,0.17377f,0.18491f,0.19659f,0.20877f,0.22142f,0.23449f,0.24797f,0.26180f,0.27597f,0.29042f,0.30513f,0.32006f,0.33517f,0.35043f,0.36581f,0.38127f,0.39678f,0.41229f,0.42778f,0.44321f,0.45854f,0.47375f,0.48879f,0.50362f,0.51822f,0.53255f,0.54658f,0.56026f,0.57357f,0.58646f,0.59891f,0.61088f,0.62233f,0.63323f,0.64362f,0.65394f,0.66428f,0.67462f,0.68494f,0.69525f,0.70553f,0.71577f,0.72596f,0.73610f,0.74617f,0.75617f,0.76608f,0.77591f,0.78563f,0.79524f,0.80473f,0.81410f,0.82333f,0.83241f,0.84133f,0.85010f,0.85868f,0.86709f,0.87530f,0.88331f,0.89112f,0.89870f,0.90605f,0.91317f,0.92004f,0.92666f,0.93301f,0.93909f,0.94489f,0.95039f,0.95560f,0.96049f,0.96507f,0.96931f,0.97323f,0.97679f,0.98000f,0.98289f,0.98549f,0.98781f,0.98986f,0.99163f,0.99314f,0.99438f,0.99535f,0.99607f,0.99654f,0.99675f,0.99672f,0.99644f,0.99593f,0.99517f,0.99419f,0.99297f,0.99153f,0.98987f,0.98799f,0.98590f,0.98360f,0.98108f,0.97837f,0.97545f,0.97234f,0.96904f,0.96555f,0.96187f,0.95801f,0.95398f,0.94977f,0.94538f,0.94084f,0.93612f,0.93125f,0.92623f,0.92105f,0.91572f,0.91024f,0.90463f,0.89888f,0.89298f,0.88691f,0.88066f,0.87422f,0.86760f,0.86079f,0.85380f,0.84662f,0.83926f,0.83172f,0.82399f,0.81608f,0.80799f,0.79971f,0.79125f,0.78260f,0.77377f,0.76476f,0.75556f,0.74617f,0.73661f,0.72686f,0.71692f,0.70680f,0.69650f,0.68602f,0.67535f,0.66449f,0.65345f,0.64223f,0.63082f,0.61923f,0.60746f,0.59550f,0.58336f,0.57103f,0.55852f,0.54583f,0.53295f,0.51989f,0.50664f,0.49321f,0.47960f };
	static const float g20[] = { 0.07176f,0.08339f,0.09498f,0.10652f,0.11802f,0.12947f,0.14087f,0.15223f,0.16354f,0.17481f,0.18603f,0.19720f,0.20833f,0.21941f,0.23044f,0.24143f,0.25237f,0.26327f,0.27412f,0.28492f,0.29568f,0.30639f,0.31706f,0.32768f,0.33825f,0.34878f,0.35926f,0.36970f,0.38008f,0.39043f,0.40072f,0.41097f,0.42118f,0.43134f,0.44145f,0.45152f,0.46153f,0.47151f,0.48144f,0.49132f,0.50115f,0.51094f,0.52069f,0.53040f,0.54015f,0.54995f,0.55979f,0.56967f,0.57958f,0.58950f,0.59943f,0.60937f,0.61931f,0.62923f,0.63913f,0.64901f,0.65886f,0.66866f,0.67842f,0.68812f,0.69775f,0.70732f,0.71680f,0.72620f,0.73551f,0.74472f,0.75381f,0.76279f,0.77165f,0.78037f,0.78896f,0.79740f,0.80569f,0.81381f,0.82177f,0.82955f,0.83714f,0.84455f,0.85175f,0.85875f,0.86554f,0.87211f,0.87844f,0.88454f,0.89040f,0.89600f,0.90142f,0.90673f,0.91193f,0.91701f,0.92197f,0.92680f,0.93151f,0.93609f,0.94053f,0.94484f,0.94901f,0.95304f,0.95692f,0.96065f,0.96423f,0.96765f,0.97092f,0.97403f,0.97697f,0.97974f,0.98234f,0.98477f,0.98702f,0.98909f,0.99098f,0.99268f,0.99419f,0.99551f,0.99663f,0.99755f,0.99828f,0.99879f,0.99910f,0.99919f,0.99907f,0.99873f,0.99817f,0.99739f,0.99638f,0.99514f,0.99366f,0.99195f,0.98999f,0.98775f,0.98524f,0.98246f,0.97941f,0.97610f,0.97255f,0.96875f,0.96470f,0.96043f,0.95593f,0.95121f,0.94627f,0.94113f,0.93579f,0.93025f,0.92452f,0.91861f,0.91253f,0.90627f,0.89986f,0.89328f,0.88655f,0.87968f,0.87267f,0.86553f,0.85826f,0.85087f,0.84337f,0.83576f,0.82806f,0.82025f,0.81236f,0.80439f,0.79634f,0.78823f,0.78005f,0.77181f,0.76352f,0.75519f,0.74682f,0.73842f,0.73000f,0.72140f,0.71250f,0.70330f,0.69382f,0.68408f,0.67408f,0.66386f,0.65341f,0.64277f,0.63193f,0.62093f,0.60977f,0.59846f,0.58703f,0.57549f,0.56386f,0.55214f,0.54036f,0.52854f,0.51667f,0.50479f,0.49291f,0.48104f,0.46920f,0.45740f,0.44565f,0.43399f,0.42241f,0.41093f,0.39958f,0.38836f,0.37729f,0.36638f,0.35566f,0.34513f,0.33482f,0.32473f,0.31489f,0.30530f,0.29599f,0.28696f,0.27824f,0.26981f,0.26152f,0.25334f,0.24526f,0.23730f,0.22945f,0.22170f,0.21407f,0.20654f,0.19912f,0.19182f,0.18462f,0.17753f,0.17055f,0.16368f,0.15693f,0.15028f,0.14374f,0.13731f,0.13098f,0.12477f,0.11867f,0.11268f,0.10680f,0.10102f,0.09536f,0.08980f,0.08436f,0.07902f,0.07380f,0.06868f,0.06367f,0.05878f,0.05399f,0.04931f,0.04474f,0.04028f,0.03593f,0.03169f,0.02756f,0.02354f,0.01963f,0.01583f };
	static const float b20[] = { 0.23217f,0.26149f,0.29024f,0.31844f,0.34607f,0.37314f,0.39964f,0.42558f,0.45096f,0.47578f,0.50004f,0.52373f,0.54686f,0.56942f,0.59142f,0.61286f,0.63374f,0.65406f,0.67381f,0.69300f,0.71162f,0.72968f,0.74718f,0.76412f,0.78050f,0.79631f,0.81156f,0.82624f,0.84037f,0.85393f,0.86692f,0.87936f,0.89123f,0.90254f,0.91328f,0.92347f,0.93309f,0.94214f,0.95064f,0.95857f,0.96594f,0.97275f,0.97899f,0.98461f,0.98930f,0.99303f,0.99583f,0.99773f,0.99876f,0.99896f,0.99835f,0.99697f,0.99485f,0.99202f,0.98851f,0.98436f,0.97959f,0.97423f,0.96833f,0.96190f,0.95498f,0.94761f,0.93981f,0.93161f,0.92305f,0.91416f,0.90496f,0.89550f,0.88580f,0.87590f,0.86581f,0.85559f,0.84525f,0.83484f,0.82437f,0.81389f,0.80342f,0.79299f,0.78264f,0.77240f,0.76230f,0.75237f,0.74265f,0.73316f,0.72393f,0.71500f,0.70599f,0.69651f,0.68660f,0.67627f,0.66556f,0.65448f,0.64308f,0.63137f,0.61938f,0.60713f,0.59466f,0.58199f,0.56914f,0.55614f,0.54303f,0.52981f,0.51653f,0.50321f,0.48987f,0.47654f,0.46325f,0.45002f,0.43688f,0.42386f,0.41098f,0.39826f,0.38575f,0.37345f,0.36140f,0.34963f,0.33816f,0.32701f,0.31622f,0.30581f,0.29581f,0.28623f,0.27712f,0.26849f,0.26038f,0.25280f,0.24579f,0.23937f,0.23356f,0.22835f,0.22370f,0.21960f,0.21602f,0.21294f,0.21032f,0.20815f,0.20640f,0.20504f,0.20406f,0.20343f,0.20311f,0.20310f,0.20336f,0.20386f,0.20459f,0.20552f,0.20663f,0.20788f,0.20926f,0.21074f,0.21230f,0.21391f,0.21555f,0.21719f,0.21880f,0.22038f,0.22188f,0.22328f,0.22456f,0.22570f,0.22667f,0.22744f,0.22800f,0.22831f,0.22836f,0.22811f,0.22754f,0.22663f,0.22536f,0.22369f,0.22161f,0.21918f,0.21650f,0.21358f,0.21043f,0.20706f,0.20348f,0.19971f,0.19577f,0.19165f,0.18738f,0.18297f,0.17842f,0.17376f,0.16899f,0.16412f,0.15918f,0.15417f,0.14910f,0.14398f,0.13883f,0.13367f,0.12849f,0.12332f,0.11817f,0.11305f,0.10797f,0.10294f,0.09798f,0.09310f,0.08831f,0.08362f,0.07905f,0.07461f,0.07031f,0.06616f,0.06218f,0.05837f,0.05475f,0.05134f,0.04814f,0.04516f,0.04243f,0.03993f,0.03753f,0.03521f,0.03297f,0.03082f,0.02875f,0.02677f,0.02487f,0.02305f,0.02131f,0.01966f,0.01809f,0.01660f,0.01520f,0.01387f,0.01264f,0.01148f,0.01041f,0.00942f,0.00851f,0.00769f,0.00695f,0.00629f,0.00571f,0.00522f,0.00481f,0.00449f,0.00424f,0.00408f,0.00401f,0.00401f,0.00410f,0.00427f,0.00453f,0.00486f,0.00529f,0.00579f,0.00638f,0.00705f,0.00780f,0.00863f,0.00955f,0.01055f };

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*3);
	unsigned char tmp = 0;

	if (colorMapTypes == 0) {
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b0[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g0[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r0[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 1){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b1[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g1[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r1[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 2){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b2[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g2[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r2[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 3){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b3[tmp / (256 / 11)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g3[tmp / (256 / 11)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r3[tmp / (256 / 11)] * 255;
			}
		}
	}
	else if (colorMapTypes == 4){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b4[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g4[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r4[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 5){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b5[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g5[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r5[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 6){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b6[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g6[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r6[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 7){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b7[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g7[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r7[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 8){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b8[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g8[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r8[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 9){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b9[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g9[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r9[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 10){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b10[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g10[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r10[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 11){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b11[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g11[tmp / (256 / 64)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r11[tmp / (256 / 64)] * 255;
			}
		}
	}
	else if (colorMapTypes == 12){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b12[tmp / (256 / 9)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g12[tmp / (256 / 9)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r12[tmp / (256 / 9)] * 255;
			}
		}
	}
	else if (colorMapTypes == 13){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b13[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g13[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r13[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 14){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b14[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g14[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r14[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 15){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b15[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g15[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r15[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 16){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b16[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g16[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r16[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 17){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b17[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g17[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r17[tmp / (256 / 256)] * 255;
			}
		}
	}
	else if (colorMapTypes == 18){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = (b18[tmp * 2 - 2] + b18[tmp * 2 - 1]) / 2 * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = (g18[tmp * 2 - 2] + g18[tmp * 2 - 1]) / 2 * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = (r18[tmp * 2 - 2] + r18[tmp * 2 - 1]) / 2 * 255;
			}
		}
	}
	else if (colorMapTypes == 19){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = (b19[tmp * 2 - 2] + b19[tmp * 2 - 1]) / 2 * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = (g19[tmp * 2 - 2] + g19[tmp * 2 - 1]) / 2 * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = (r19[tmp * 2 - 2] + r19[tmp * 2 - 1]) / 2 * 255;
			}
		}
	}
	else if (colorMapTypes == 20){
		for (int i = 0; i < srcHeight; i++) {
			for (int j = 0; j < srcWidth; j++) {
				tmp = srcImage[i * srcWidth +j];
				dstData[i * srcWidth * 3 + j * 3] = b20[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = g20[tmp / (256 / 256)] * 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = r20[tmp / (256 / 256)] * 255;
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*3);
	*outChannel = 3;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;

	return 1;
}

int Gray2Rainbow(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*3);
	
	unsigned char tmp = 0;
	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			tmp = srcImage[i * srcWidth +j];
			if(tmp <= 51) {
				dstData[i * srcWidth * 3 + j * 3] = 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = tmp * 5;
				dstData[i * srcWidth * 3 + j * 3 + 2] = 0;
			}
			else if(tmp <= 102) {
				tmp -= 51;
				dstData[i * srcWidth * 3 + j * 3] = 255 - tmp * 5;
				dstData[i * srcWidth * 3 + j * 3 + 1] = 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = 0;
			}
			else if(tmp <= 153) {
				tmp -= 102;
				dstData[i * srcWidth * 3 + j * 3] = 0;
				dstData[i * srcWidth * 3 + j * 3 + 1] = 255;
				dstData[i * srcWidth * 3 + j * 3 + 2] = tmp * 5;
			}
			else if(tmp <= 204) {
				tmp -= 153;
				dstData[i * srcWidth * 3 + j * 3] = 0;
				dstData[i * srcWidth * 3 + j * 3 + 1] = 255 - static_cast<unsigned char>(tmp * 128.0 / 51 + 0.5);
				dstData[i * srcWidth * 3 + j * 3 + 2] = 255;
			}
			else {
				tmp -= 204;
				dstData[i * srcWidth * 3 + j * 3] = 0;
				dstData[i * srcWidth * 3 + j * 3 + 1] = 127 - static_cast<unsigned char>(tmp * 128.0 / 51 + 0.5);
				dstData[i * srcWidth * 3 + j * 3 + 2] = 255;
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*3);
	*outChannel = 3;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int Gray2Metal(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*3);
	
	double tmp = 0;
	int flag;
	double extent = 256 / 8;
	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			double tmp = srcImage[i * srcWidth + j] * 1.0 / 256;
			int pix = srcImage[i * srcWidth + j];
			flag = srcImage[i * srcWidth + j] / extent;
			switch(flag){
				case 0:
				case 1:
					dstData[i * srcWidth * 3 + j * 3] = 0;
					dstData[i * srcWidth * 3 + j * 3 + 1] = 0;
					dstData[i * srcWidth * 3 + j * 3 + 2] = 4 * pix;
					break;
				case 2:
					dstData[i * srcWidth * 3 + j * 3] = 4 * pix - 255;
					dstData[i * srcWidth * 3 + j * 3 + 1] = 0;
					dstData[i * srcWidth * 3 + j * 3 + 2] = 255;
					break;
				case 3:
					dstData[i * srcWidth * 3 + j * 3] = 4 * pix - 255;
					dstData[i * srcWidth * 3 + j * 3 + 1] = 0;
					dstData[i * srcWidth * 3 + j * 3 + 2] = -8 * pix + 4 * 255;
					break;
				case 4:
				case 5:
					dstData[i * srcWidth * 3 + j * 3] = 255;
					dstData[i * srcWidth * 3 + j * 3 + 1] = 4 * pix - 2 * 255;
					dstData[i * srcWidth * 3 + j * 3 + 2] = 0;
					break;
				case 6:
				case 7:
					dstData[i * srcWidth * 3 + j * 3] = 255;
					dstData[i * srcWidth * 3 + j * 3 + 1] = 255;
					dstData[i * srcWidth * 3 + j * 3 + 2] = 4 * pix - 3 * 255;
					break;
				default:
					break;
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*3);
	*outChannel = 3;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int GrayFromRGB(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int colorChn){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*1);

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			dstData[i * srcWidth + j] = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2 - colorChn];
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int complementaryPixel(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int row = srcHeight;
    int col = srcWidth;
    for (int i = 0; i < row; ++i) {
        for (int j = 0; j < col; ++j) {
			for(int c = 0; c < srcChannel; c++){
        		dstData[i * col * srcChannel + j * srcChannel + c] = 255 - srcImage[i * col * srcChannel + j * srcChannel + c];
			}
	    }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int minMaxLoc(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* minPixel, int* maxPixel){
	
	int max = 0, min = 255;
	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			int pixel = srcImage[i * srcWidth + j];
			if (max < pixel) {
				max = pixel;
			}
			if (min > pixel) {
				min = pixel;
			}
		}
	}
	*minPixel = min;
	*maxPixel = max;

	return 1;
}

int findAreaColor(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int x,int y, int width,int height){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	int b_min = 255, b_max = 0, g_min = 255, g_max = 0, r_min = 255, r_max = 0;
	for (int i = y; i < y + height; i++) {
		for (int j = x; j < x + width; j++) {
			int b = srcImage[i * srcChannel * srcWidth + j * srcChannel ];
			int g = srcImage[i * srcChannel * srcWidth + j * srcChannel + 1];
			int r = srcImage[i * srcChannel * srcWidth + j * srcChannel + 2];
			if (b_min > b)	b_min = b;
			if (b_max < b)	b_max = b;
			if (g_min > g)	g_min = g;
			if (g_max < g)	g_max = g;
			if (r_min > r)	r_min = r;
			if (r_max < r)	r_max = r;
		}
	}
	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			int b = srcImage[i * srcChannel * srcWidth + j * srcChannel ];
			int g = srcImage[i * srcChannel * srcWidth + j * srcChannel + 1];
			int r = srcImage[i * srcChannel * srcWidth + j * srcChannel + 2];
			if (b <= b_max && b >= b_min && g <= g_max && g >= g_min && r <= r_max && r >= r_min) {
				dstData[i * srcChannel * srcWidth + j * srcChannel ] = b;
				dstData[i * srcChannel * srcWidth + j * srcChannel +1] = g;
				dstData[i * srcChannel * srcWidth + j * srcChannel +2] = r;
			}else{
				dstData[i * srcChannel * srcWidth + j * srcChannel ] = 255;
				dstData[i * srcChannel * srcWidth + j * srcChannel +1] = 255;
				dstData[i * srcChannel * srcWidth + j * srcChannel +2] = 255;
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}
// for special usage
int RGB2HSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* H, float* S, float* V) {

	for(int i = 0; i < srcHeight; i++){
		for(int j = 0; j < srcWidth; j++){
			double B = srcImage[i * srcWidth * srcChannel + j * srcChannel] * 1.0 / 255;
			double G = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] * 1.0 / 255;
			double R = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2] * 1.0 / 255;
			double max = B;
			double min = B;
			int maxindex = 0;
			if(max < G){
				max = G;
				maxindex = 1;
			}	
			if(max < R){
				max = R;
				maxindex = 2;
			}		
			if(min > G)
				min = G;
			if(min > R)
				min = R;
			if (max == min) {
				H[i * srcWidth + j] = 0;
			}
			else if (maxindex == 2 && G >= B) {
				H[i * srcWidth + j] = static_cast<int>(60 * (G - B) / (max - min));
			}
			else if (maxindex == 2 && G < B) {
				H[i * srcWidth + j] = static_cast<int>(60 * (G - B) / (max - min) + 360);
			}
			else if (maxindex == 1) {
				H[i * srcWidth + j] = static_cast<int>(60 * (B - R) / (max - min) + 120);
			}
			else if (maxindex == 0) {
				H[i * srcWidth + j] = static_cast<int>(60 * (R - G) / (max - min) + 240);
			}

			if(max == 0)
				S[i * srcWidth + j] = 0;
			else
				S[i * srcWidth + j] = 1 - (min  / max);

			V[i * srcWidth + j] = max;
		}
	}

	return 1;
}

int RGB2GrayDefined(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float red, float green, float blue, float constant){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*1);
	unsigned char val = 0;

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			int s = blue * 128 * srcImage[i * srcWidth * srcChannel + j * srcChannel] 
					+ green * 128 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] 
					+ red * 128 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
			val = s >> 7 + (int)(constant * 255);
			if (val > 255) val =255;
			else if (val < 0) val = 0;
			dstData[i * srcWidth + j] = val;
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

int singleRGB2HSV(unsigned char R, unsigned char G, unsigned char B, int* H, float* S, float* V) {

	double max = B;
	double min = B;
	int maxindex = 0;
	if(max < G){
		max = G;
		maxindex = 1;
	}	
	if(max < R){
		max = R;
		maxindex = 2;
	}		
	if(min > G)
		min = G;
	if(min > R)
		min = R;
	if (max == min) {
		*H = 0;
	}
	else if (maxindex == 2 && G >= B) {
		*H = static_cast<int>(60 * (G - B) / (max - min));
	}
	else if (maxindex == 2 && G < B) {
		*H = static_cast<int>(60 * (G - B) / (max - min) + 360);
	}
	else if (maxindex == 1) {
		*H = static_cast<int>(60 * (B - R) / (max - min) + 120);
	}
	else if (maxindex == 0) {
		*H = static_cast<int>(60 * (R - G) / (max - min) + 240);
	}

	if(max == 0)
		*S = 0;
	else
		*S = 1 - (min  / max);

	*V = max;

	return 1;
}

int HSL2RGB(unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* H, float* S, float* L, int width, int height, int changeH, int changeS, int changeL) {
	
	float var1, var2;
	unsigned char* dstData = (unsigned char*)malloc(width*height*3);

	for(int i = 0; i < height; i++){
		for(int j = 0; j < width; j++){
			float Hchange = H[i * width + j] + changeH / 360.0;
			float Schange = S[i * width + j] * (changeS + 100) / 100.0;
			float Lchange = L[i * width + j] * (changeL + 100) / 100.0;

			Schange = Schange > 1 ? 1 : Schange;
			Schange = Lchange > 1 ? 1 : Lchange;

			if (Schange == 0) {
				dstData[i * width * 3 + j * 3 + 2] = Lchange * 255;
				dstData[i * width * 3 + j * 3 + 1] = Lchange * 255;
				dstData[i * width * 3 + j * 3] = Lchange * 255;
			}
			else {
				if (Lchange < 0.5)
					var2 = Lchange * (1 + Schange);
				else
					var2 = Lchange + Schange - Lchange * Schange;

				var1 = 2.0 * Lchange - var2;

				for (int k = 0; k < 3; k++) {
					float vH = Hchange + (1 / 3.0) * (k - 1);
					float data;
					if (vH < 0) vH += 1;	
					if (vH > 1) vH -= 1;	
					if (6.0 * vH < 1)	
						data = (var1 + (var2 - var1) * 6.0 * vH);
					else if (2.0 * vH < 1)	
						data = var2;
					else if (3.0 * vH < 2)	
						data = (var1 + (var2 - var1) * 6.0 * (2 / 3.0 - vH));
					else 
						data = var1;

					if (data > 1)	data = 1;
					else if(data < 0)	data = 0;
					dstData[i * width * 3 + j * 3 + k] = static_cast<unsigned char>(data * 255);
				}
			}
		}
	}

	memcpy(outImage, dstData, width*height*3);
	*outChannel = 3;
	*outHeight = height;
	*outWidth = width;

    free(dstData);

	return 1;
}

int adjustHSL(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int changeH, int changeS, int changeL) {
	
	float r,g,b, max, min, delR, delG, delB, delMax;
	float H, S, L;
	float var1, var2;
	unsigned char* dstData = (unsigned char*)malloc(srcWidth * srcHeight * srcChannel);
	
	for(int i = 0; i < srcHeight; i++){
		for(int j = 0; j < srcWidth; j++){
			b = srcImage[i * srcWidth * srcChannel + j * srcChannel] / 255.0;
			g = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] / 255.0;
			r = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2] / 255.0;
			max = b; min = b;
			if(max < g)
				max = g;
			if(max < r)
				max = r;
			if(min > g)
				min = g;
			if(min > r)
				min = r;

			L = (max + min) / 2;
			delMax = max - min;

			if (max == min) {
				H = 0;
				S = 0;
			}
			else {
				if (L <= 0.5)
					S = delMax / (max + min);
				else
					S = delMax / (2 - max - min);

				delR = (((max - r) / 6.0) + delMax / 2.0) / delMax;
				delG = (((max - g) / 6.0) + delMax / 2.0) / delMax;
				delB = (((max - b) / 6.0) + delMax / 2.0) / delMax;

				if (r == max) 
					H = delB - delG;
				else if (g == max)
					H = 1 / 3.0 + delR - delB;
				else if (b == max)
					H = 2 / 3.0 + delG - delR;

				if (H < 0) H += 1;
				if (H > 1) H -= 1;
			}

			float Hchange = H + changeH / 360.0;
			float Schange = S + changeS / 100.0;
			float Lchange = L + changeL / 100.0;
			//float Lchange = L * (changeL + 100) / 100.0;

			if (Schange > 1)	Schange = 1;	
			else if (Schange < 0)	Schange = 0;	
			if (Lchange > 1)	Lchange = 1;	
			else if (Lchange < 0)	Lchange = 0;	

			if (Schange == 0) {
				dstData[i * srcWidth * 3 + j * 3 + 2] = Lchange * 255;
				dstData[i * srcWidth * 3 + j * 3 + 1] = Lchange * 255;
				dstData[i * srcWidth * 3 + j * 3] = Lchange * 255;
			}
			else {
				if (Lchange < 0.5)
					var2 = Lchange * (1 + Schange);
				else
					var2 = Lchange + Schange - Lchange * Schange;

				var1 = 2.0 * Lchange - var2;

				for (int k = 0; k < 3; k++) {
					float vH = Hchange + (1 / 3.0) * (k - 1);
					float data;
					if (vH < 0) vH += 1;	
					if (vH > 1) vH -= 1;	
					if (vH < 1 / 6.0)	
						data = (var1 + (var2 - var1) * 6.0 * vH);
					else if (vH < 1 / 2.0)	
						data = var2;
					else if (vH < 2 / 3.0)	
						data = (var1 + (var2 - var1) * 6.0 * (2 / 3.0 - vH));
					else 
						data = var1;
						
					if (data > 1)	data = 1;
					else if(data < 0)	data = 0;
					dstData[i * srcWidth * 3 + j * 3 + k] = static_cast<unsigned char>(data * 255);
				}
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);

	return 1;
}

int saveRGBinHSV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float lowH, float highH, float lowS, float highS, float lowV, float highV) {
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	float H,S,V;
	for(int i = 0; i < srcHeight; i++){
		for(int j = 0; j < srcWidth; j++){
			double B = srcImage[i * srcWidth * srcChannel + j * srcChannel] * 1.0 / 255;
			double G = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] * 1.0 / 255;
			double R = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2] * 1.0 / 255;
			double max = B;
			double min = B;
			int maxindex = 0;
			if(max < G){
				max = G;
				maxindex = 1;
			}	
			if(max < R){
				max = R;
				maxindex = 2;
			}		
			if(min > G)
				min = G;
			if(min > R)
				min = R;
			if (max == min) {
				H = 0;
			}
			else if (maxindex == 2 && G >= B) {
				H = 60 * (G - B) / (max - min);
			}
			else if (maxindex == 2 && G < B) {
				H = 60 * (G - B) / (max - min) + 360;
			}
			else if (maxindex == 1) {
				H = 60 * (B - R) / (max - min) + 120;
			}
			else if (maxindex == 0) {
				H = 60 * (R - G) / (max - min) + 240;
			}

			if(max == 0)
				S = 0;
			else
				S = 1 - (min  / max);

			V = max;

			if (H >= lowH && H <= highH && S >= lowS && S <= highS && V >= lowV && V <= highV) {
				dstData[i * srcWidth * srcChannel + j * srcChannel] = srcImage[i * srcWidth * srcChannel + j * srcChannel];
				dstData[i * srcWidth * srcChannel + j * srcChannel + 1] = srcImage[i * srcWidth * srcChannel + j * srcChannel + 1];
				dstData[i * srcWidth * srcChannel + j * srcChannel + 2] = srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
			}
			else {
				dstData[i * srcWidth * srcChannel + j * srcChannel] = 0;
				dstData[i * srcWidth * srcChannel + j * srcChannel + 1] = 0;
				dstData[i * srcWidth * srcChannel + j * srcChannel + 2] = 0;
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);
	return 1;
}

// threshold  7

int stripBackground(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* bkImage, int bkWidth, int bkHeight, int bkChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float contraThresh, int mode){
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for(int i=0;i<srcHeight;i++)
	{
		for(int j=0;j<srcWidth;j++)
		{
			int pixel1, pixel2;
			if(srcChannel==1)
			{
				pixel1 = srcImage[i*srcWidth+j];
				pixel2 = bkImage[i*srcWidth+j];
			}
			else
			{
				int pixel_loc = i*srcWidth*3+j*3;
				pixel1 = (299*srcImage[pixel_loc]+578*srcImage[pixel_loc+1]+114*srcImage[pixel_loc+2]+500)/1000;
				pixel2 = (299*bkImage[pixel_loc]+578*bkImage[pixel_loc+1]+114*bkImage[pixel_loc+2]+500)/1000;
			}
			float delta = (float)abs(pixel1-pixel2);
			if(delta>contraThresh)
			{
				dstData[i*srcWidth+j] = mode == 1 ? pixel1 : 255;
			}
			else
			{
				dstData[i*srcWidth+j] = 0;
			}

		}
	}
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outWidth = srcWidth;
	*outHeight = srcHeight;
	*outChannel = 1;

	free(dstData);
	return 1;
}

int thresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, float maxval, int region){

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight);

    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++)
        {
	        if (srcImage[i * srcWidth + j] > thresh) {
	        	dstData[i * srcWidth + j] = region == 1 ? maxval : 0;
	        }
	        else {
	        	dstData[i * srcWidth + j] = region == 1 ? 0 : maxval;
	        }
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight);
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	*outChannel = 1;

	free(dstData);
	return 1;
}

int thresholdBinaryTrunc(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh){

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight);

    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++)
        {
	        if (srcImage[i * srcWidth + j] > thresh) {
	        	dstData[i * srcWidth + j] = thresh;
	        }
	        else {
	        	dstData[i * srcWidth + j] = srcImage[i * srcWidth + j];
	        }
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight);
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	*outChannel = 1;

	free(dstData);
	return 1;
}

int thresholdBinaryToZero(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float thresh, int region){

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight);

    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++)
        {
	        if (srcImage[i * srcWidth + j] > thresh) {
	        	dstData[i * srcWidth + j] = region == 1 ? srcImage[i * srcWidth + j] : 0;
	        }
	        else {
	        	dstData[i * srcWidth + j] = region == 1 ? 0 : srcImage[i * srcWidth + j];
	        }
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight);
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	*outChannel = 1;

	free(dstData);
	return 1;
}

int doubleThresholdBinary(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel){
	
	const int kLENGTH = 256;
    //先获取直方图
    const int length = 256;
    double *pdf = (double*)malloc(sizeof(double)*length);
    //初始化pdf
    for (int i = 0; i < length; i++) {
        pdf[i] = 0;
    }
    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++) {
        	pdf[srcImage[i * srcWidth + j]]++;
        }
    }
    for (int i = 0; i < length; ++i) {
        pdf[i] /= srcWidth * srcHeight;
    }

    //循环这两个阈值参数，直到找到最大的类间方差
    int k1, k2;
    int t1, t2;
    double max = 0;
    for (k1 = 1; k1 < kLENGTH; ++k1) {
        for (k2 = 1; k2 < kLENGTH; ++k2) {
	        //求出每个类的占比和均值
	        double p1 = 0, p2 = 0, p3 = 0;
	        double m1 = 0, m2 = 0, m3 = 0;
	        double mg = 0;

	        for (int i = 0; i < k1; ++i) {
		        p1 += pdf[i];
		        m1 += i * pdf[i];
	        }
	        for (int i = k1; i < k2; ++i) {
		        p2 += pdf[i];
		        m2 += i * pdf[i];
	        }
	        for (int i = k2; i < kLENGTH; ++i) {
		        p3 += pdf[i];
		        m3 += i * pdf[i];
	        }
	
	        mg = m1 + m2 + m3;
	        m1 /= p1;
	        m2 /= p2;
	        m3 /= p3;
	        //求类间方差
	        double goal = p1 * pow(m1 - mg, 2) + p2 * pow(m2 - mg, 2) + p3 * pow(m3 - mg, 2);
	        if (max < goal) {
		        max = goal;
		        t1 = k1;
		        t2 = k2;
	        }
        }
    }

    unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);
	
    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; ++j) {
	        if (srcImage[i * srcWidth + j] < t1) {
	        	dstData[i * srcWidth + j] = 0;
	        }
	        else if (srcImage[i * srcWidth + j] < t2) {
	        	dstData[i * srcWidth + j] = 128;
	        }
	        else {
	        	dstData[i * srcWidth + j] = 255;
	        }
        }
    }

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(pdf);
    free(dstData);
	return 1;
}

int thresholdBinaryOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int maxval, int region){

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    int best_thresh = 0;
    const int kLENGTH = 256;

    const int length = 256;
    double *pdf = (double*)malloc(sizeof(double)*length);
    for (int i = 0; i < length; i++) {
        pdf[i] = 0;
    }
    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++) {
        	pdf[srcImage[i * srcWidth + j]]++;
        }
    }
    for (int i = 0; i < length; ++i) {
        pdf[i] /= srcWidth * srcHeight;
    }

    double max = 0;
    ///遍历去找最优的阈值
    for (int i = 0; i < kLENGTH; i++)
    {
        double w0, w1, u0, u1;//前景所占比例	前景的平均灰度	背景所占比例	背景的平均灰度
        w0 = w1 = u1 = u0 = 0;

        for (int j = 0; j < i; j++)
        {
	        w0 += pdf[j];
	        u0 += pdf[j] * j;
        }
        u0 /= w0;
        for (int j = i; j < kLENGTH; j++)
        {
	        w1 += pdf[j];
	        u1 += pdf[j] * j;
        }
        u1 /= w1;
        //本来应该是g = w0 * (u0-u)^2 + w1 * (u1-u)^2 但是计算量大，简化使用以下公式计算方差
        double g = w0 * w1 * (u0 - u1) * (u0 - u1);
        //寻找最大方差的阈值
        if (g > max) {
	        max = g;
	        best_thresh = i;
        }
    }

    for (int i = 0; i < srcHeight; ++i) {
	    for (int j = 0; j < srcWidth; j++)
	    {
			if (srcImage[i * srcWidth + j] > best_thresh) {
				dstData[i * srcWidth + j] = region == 1 ? maxval : 0;
			}
			else {
				dstData[i * srcWidth + j] = region == 1 ? 0 : maxval;;
			}
	    }
    }
    
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(pdf);
    free(dstData);
	return 1;
}

int getThresholdOTSU(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, float* thres){

    int best_thresh = 0;
    const int kLENGTH = 256;

    const int length = 256;
    double *pdf = (double*)malloc(sizeof(double)*length);
    for (int i = 0; i < length; i++) {
        pdf[i] = 0;
    }
    for (int i = 0; i < srcHeight; ++i) {
        for (int j = 0; j < srcWidth; j++) {
        	pdf[srcImage[i * srcWidth + j]]++;
        }
    }
    for (int i = 0; i < length; ++i) {
        pdf[i] /= srcWidth * srcHeight;
    }

    double max = 0;
    ///遍历去找最优的阈值
    for (int i = 0; i < kLENGTH; i++)
    {
        double w0, w1, u0, u1;//前景所占比例	前景的平均灰度	背景所占比例	背景的平均灰度
        w0 = w1 = u1 = u0 = 0;

        for (int j = 0; j < i; j++)
        {
	        w0 += pdf[j];
	        u0 += pdf[j] * j;
        }
        u0 /= w0;
        for (int j = i; j < kLENGTH; j++)
        {
	        w1 += pdf[j];
	        u1 += pdf[j] * j;
        }
        u1 /= w1;
        //本来应该是g = w0 * (u0-u)^2 + w1 * (u1-u)^2 但是计算量大，简化使用以下公式计算方差
        double g = w0 * w1 * (u0 - u1) * (u0 - u1);
        //寻找最大方差的阈值
        if (g > max) {
	        max = g;
	        best_thresh = i;
        }
    }
    *thres = best_thresh;

    free(pdf);
	return 1;
}

// geometric transform  4

int flip(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int XY){
	
	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

    if (XY == 0) {
    	for(int i = 0, h = srcHeight - 1; i < srcHeight; ++i, --h){
    		for(int j = 0; j < srcWidth; ++j){
				for(int c = 0; c < srcChannel; c++){
    				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[h * srcWidth * srcChannel + j * srcChannel + c];
				}
			}
		}
	}
	else if (XY == 1) {
		for(int i = 0; i < srcHeight; ++i){
	    	for(int j = 0, w = srcWidth - 1; j < srcWidth, w >= 0; ++j, --w){
	    		for(int c = 0; c < srcChannel; c++){
    				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[i * srcWidth * srcChannel + w * srcChannel + c];
				}
			}
		}
	}
	else if (XY == -1) {
		for(int i = 0; i < srcHeight; ++i){
	    	for(int j = 0; j < srcWidth; ++j){
				for(int c = 0; c < srcChannel; c++){
    				dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[(srcHeight - i - 1) * srcWidth * srcChannel + (srcWidth - j - 1) * srcChannel + c];
				}
			}
		}
	}
	
	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

    free(dstData);        
	return 1;
}

int resize(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int newWidth,int newHeight, float scaleX,float scaleY, int interpolation){
	
	float xScale = newWidth == 0 ? scaleX : newWidth * 1.0 / srcWidth;
	float yScale = newHeight == 0 ? scaleY : newHeight * 1.0 / srcHeight;

	int scaling_width = static_cast<int>(srcWidth * xScale + 0.5f);
    int scaling_height = static_cast<int>(srcHeight * yScale + 0.5f);

    unsigned char* dstData = (unsigned char*)malloc(scaling_width * scaling_height * srcChannel);
    for (int h = 0; h < scaling_height; ++h) {
        for (int w = 0; w < scaling_width * srcChannel; ++w) {
        	dstData[h * scaling_width * srcChannel + w] = 0;
    	}
    }

	if (interpolation == 1) {	// 双线性插值法
		int xi,yi;
		float xf,yf;
		for(int h = 0; h < scaling_height; h++){
			yf = h / yScale;
			yi = static_cast<int>(yf + 0.5f);
			yf -= yi;
			if (yi < 0){
				yf = 0; yi = 0;
			}
			if (yi >= srcWidth - 1){
				yf = 0; yi = srcWidth - 2;
			}
			int bufy[2];
			bufy[0] = static_cast<int>((1.f - yf) * 2048);
			bufy[1] = 2048 - bufy[0];

			for(int w = 0; w < scaling_width; w++){
				xf = w / xScale;
				xi = static_cast<int>(xf + 0.5f);
				xf -= xi;
				if (xi < 0){
					xf = 0; xi = 0;
				}
				if (xi >= srcWidth - 1){
					xf = 0; xi = srcWidth - 2;
				}
				int bufx[2];
				bufx[0] = static_cast<int>((1.f - xf) * 2048);
				bufx[1] = 2048 - bufx[0];

				for(int c = 0; c < srcChannel; c++){
					dstData[h * scaling_width * srcChannel + w * srcChannel + c] = 
						srcImage[yi * srcWidth * srcChannel + xi * srcChannel + c] * bufx[0] * bufy[0]
						+ srcImage[yi * srcWidth * srcChannel + (xi+1) * srcChannel + c] * bufx[1] * bufy[0]
						+ srcImage[(yi+1) * srcWidth * srcChannel + xi * srcChannel + c] * bufx[0] * bufy[1]
						+ srcImage[(yi+1) * srcWidth * srcChannel + (xi+1) * srcChannel + c] * bufx[1] * bufy[1] >> 22;
				}
			}
		}
	}
	else {		// 最邻近插值法
		int x_pos = 0, y_pos = 0;
		for(int h = 0; h < scaling_height; h++){
			y_pos = static_cast<int>((h+1) / yScale + 0.5f) - 1;
			for(int w = 0; w < scaling_width; w++){
				x_pos = static_cast<int>((w+1) / xScale + 0.5f) - 1;
				for(int c = 0; c < srcChannel; c++){
					dstData[h * scaling_width * srcChannel + w * srcChannel + c] = srcImage[y_pos * srcWidth * srcChannel + x_pos * srcChannel + c];
				}
			}
		}
	}

	memcpy(outImage, dstData, scaling_width * scaling_height * srcChannel);
	*outChannel = srcChannel;
	*outHeight = scaling_height;
	*outWidth = scaling_width;

    free(dstData);
	return 1;
}

int rotate(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int clockwiseAngle){

	double PI = 3.1415926;
	double cosa = cos(clockwiseAngle * PI / 180);
	double sina = sin(clockwiseAngle * PI / 180);

	unsigned char* dstData = (unsigned char*)malloc(srcWidth*srcHeight*srcChannel);

	for(int i = 0; i < srcHeight; ++i){
		for(int j = 0; j < srcWidth; ++j){
			int x = static_cast<int>(cosa * (j - srcWidth/2) - sina * (-i + srcHeight/2) + srcWidth/2 + 0.5);
			int y = static_cast<int>(-sina * (j - srcWidth/2) - cosa * (-i + srcHeight/2) + srcHeight/2 + 0.5);
			for(int c = 0; c < srcChannel; c++){
				if (x < 0 || y < 0 || x > srcWidth-1 || y > srcHeight-1)
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = 0;
				else
					dstData[i * srcWidth * srcChannel + j * srcChannel + c] = srcImage[y * srcWidth * srcChannel + x * srcChannel + c];
			}
		}
	}

	memcpy(outImage, dstData, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	free(dstData);
	return 1;
}

int fitLine(float* pos, int num, float* lineVector){

	float sumX=0, sumY=0, mean_x=0, mean_y=0;

	for (int i = 0; i < num * 2; i++)
	{
		sumX += pos[i++];
		sumY += pos[i];
	}
	mean_x = sumX / num;
	mean_y = sumY / num;

	sumX = sumY = 0;
	for (int i = 0; i < num * 2; i++,i++)
	{
		sumX += (pos[i] - mean_x) * (pos[i+1] - mean_y);
		sumY += (pos[i] - mean_x) * (pos[i] - mean_x);
	}
	float k = sumX / sumY;
	float b = mean_y - k * mean_x;

	// 直线方向向量
	lineVector[0] = 1 / sqrt(k * k + 1);
	lineVector[1] = k / sqrt(k * k + 1);
	// 直线上一点坐标
	lineVector[2] = pos[0];
	lineVector[3] = k * pos[0] + b;

	return 1;
}

// Histogram

int getHistogram(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* outHistogram) {

	int val;

	//int hist[256];

	for (int i = 0; i < srcHeight; i++) {
		for (int j = 0; j < srcWidth; j++) {
			if (srcChannel == 1) {
				outHistogram[srcImage[i * srcWidth + j]]++;
			}
			else {
				int s = 15 * srcImage[i * srcWidth * srcChannel + j * srcChannel] + 75 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 1] + 38 * srcImage[i * srcWidth * srcChannel + j * srcChannel + 2];
				val = s >> 7;
				outHistogram[val]++;
			}
		}
	}
	//memcpy(outHistogram, hist, srcWidth*srcHeight*srcChannel);

	return 1;
}

// feature



/***************************** opencv code *************************************/


/***************************** opencv code *************************************/
/***************************** opencv code *************************************/

int matchTemplateCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* templateImage, int templateWidth, int templateLength, int templateChannel, float* rect, float* similarity) {
	Mat src, ttemp, binary;
	double PI = 3.1415926;
	if(srcChannel == 1)
		Mat src(srcLength, srcWidth, CV_8UC1, srcImage);
	else {
		Mat temp(srcLength, srcWidth, CV_8UC3, srcImage);
		cvtColor(temp, src, CV_BGR2GRAY);
	}
	if (templateChannel == 1)
		Mat ttemp(templateLength, templateWidth, CV_8UC1, templateImage);
	else {
		Mat temp2(templateLength, templateWidth, CV_8UC3, templateImage);
		cvtColor(temp2, ttemp, CV_BGR2GRAY);
	}

	Mat dest, matrix, affineTemp, cutTemp;
	dest.create(src.rows - ttemp.rows + 1, src.cols - ttemp.cols + 1, CV_32FC1);
	Point ptVal, minPoint, maxPoint;
	double scale, minVal, min = 1;

	for (int i = 0; i < 360; i+=3) {
		scale = cos((i%90) * PI / 180) + sin((i%90) * PI / 180);
		Mat resizeTemp(Size((int)(ttemp.cols * scale), (int)(ttemp.rows * scale)), CV_8UC1);
		matrix = getRotationMatrix2D(Point(resizeTemp.cols/2, resizeTemp.rows/2), i, 1);
		
		resize(ttemp, resizeTemp, resizeTemp.size());
		warpAffine(resizeTemp, affineTemp, matrix, resizeTemp.size());
		
		Rect rect((int)((scale-1)*ttemp.cols/2), (int)((scale-1)*ttemp.rows/2), ttemp.cols, ttemp.rows);
		cutTemp = affineTemp(rect);
		matchTemplate(src, cutTemp, dest, CV_TM_SQDIFF_NORMED);
		minMaxLoc(dest, &minVal, NULL, &ptVal, NULL);

		if (min > minVal) {
			min = minVal;
			minPoint = ptVal;
		}
	}
	maxPoint.x = minPoint.x + ttemp.cols;
	maxPoint.y = minPoint.y + ttemp.rows;

	vector<vector<Point> > contours;
	vector<Vec4i > hierarchy;
	threshold(src, binary, 124, 255, 0);
	findContours(binary, contours, hierarchy, RETR_LIST, CHAIN_APPROX_NONE);

	for (int i = 0; i < contours.size() - 1; i++) {
		for (int j = 0; j < contours.size() - i - 1; j++) {
			if(contourArea(contours[j]) < contourArea(contours[j+1])){
				vector<Point> temp = contours[j];
				contours[j] = contours[j+1];
				contours[j+1] = temp;
			}
		}
	}

	vector<Point> corner;
	Point touch1, touch2;
	bool hasTouch1 = false, hasTouch2 = false;
	for (int i = 0; i < contours[0].size(); i++) {
		if (contours[0][i].x >= minPoint.x - 2 && contours[0][i].x <= maxPoint.x + 2 && contours[0][i].y >= minPoint.y - 2 && contours[0][i].y <= maxPoint.y + 2) {
			corner.push_back(contours[0][i]);
			if ( (!hasTouch1 || !hasTouch2) && (contours[0][i].x == minPoint.x - 1 || contours[0][i].x == minPoint.x || contours[0][i].x == minPoint.x + 1) ) {
				if (hasTouch1) {
					hasTouch2 = true;
					touch2 = contours[0][i];
				}
				else {
					hasTouch1 = true;
					touch1 = contours[0][i];
				}
			}
			if ( (!hasTouch1 || !hasTouch2) && (contours[0][i].x == maxPoint.x - 1 || contours[0][i].x == maxPoint.x || contours[0][i].x == maxPoint.x + 1) ) {
				if (hasTouch1) {
					hasTouch2 = true;
					touch2 = contours[0][i];
				}
				else {
					hasTouch1 = true;
					touch1 = contours[0][i];
				}
			}
			if ( (!hasTouch1 || !hasTouch2) && (contours[0][i].y == minPoint.y - 1 || contours[0][i].y == minPoint.y || contours[0][i].y == minPoint.y + 1) ) {
				if (hasTouch1) {
					hasTouch2 = true;
					touch2 = contours[0][i];
				}
				else {
					hasTouch1 = true;
					touch1 = contours[0][i];
				}
			}
			if ( (!hasTouch1 || !hasTouch2) && (contours[0][i].y == maxPoint.y - 1 || contours[0][i].y == maxPoint.y || contours[0][i].y == maxPoint.y + 1) ) {
				if (hasTouch1) {
					hasTouch2 = true;
					touch2 = contours[0][i];
				}
				else {
					hasTouch1 = true;
					touch1 = contours[0][i];
				}
			}
		}
	}

	// Mat dest, matrix, affineTemp, affineTemp2, cutTemp, cutTemp2;
	// dest.create(src.rows - ttemp.rows + 1, src.cols - ttemp.cols + 1, CV_32FC1);
	// Point ptVal, minPoint;
	// double scale, minVal, min = 1;
	
	// for (int i = 0; i < 360; i+=180) {
	// 	scale = cos((i%90) * PI / 180) + sin((i%90) * PI / 180);
	// 	Mat resizeTemp(Size((int)(ttemp.cols * scale), (int)(ttemp.rows * scale)), CV_8UC1);
	// 	Mat resizeTemp2(Size((int)(ttemp.cols * scale), (int)(ttemp.rows * scale)), CV_8UC1);
	// 	matrix = getRotationMatrix2D(Point(resizeTemp.cols/2, resizeTemp.rows/2), i, 1);
		
	// 	resize(ttemp, resizeTemp, resizeTemp.size());
	// 	warpAffine(resizeTemp, affineTemp, matrix, resizeTemp.size());
	// 	Rect rect((int)((scale-1)*ttemp.cols/2), (int)((scale-1)*ttemp.rows/2), ttemp.cols, ttemp.rows);
	// 	cutTemp = affineTemp(rect);
		
	// 	resize(mask, resizeTemp2, resizeTemp2.size());
	// 	warpAffine(resizeTemp2, affineTemp2, matrix, resizeTemp2.size());
	// 	Rect rect2((int)((scale-1)*ttemp.cols/2), (int)((scale-1)*ttemp.rows/2), ttemp.cols, ttemp.rows);
	// 	cutTemp2 = affineTemp2(rect2);

	// 	matchTemplate(src, cutTemp, dest, CV_TM_SQDIFF, cutTemp2);
	// 	normalize(dest, dest, 1, 0, NORM_MINMAX);
	// 	minMaxLoc(dest, &minVal, NULL, &ptVal, NULL);
	// 	if (min > minVal) {
	// 		min = minVal;
	// 		minPoint = ptVal;

	// 	}
	// }
	
	// cout << min << minPoint << endl;
	// rectangle(src, minPoint, Point(minPoint.x + ttemp.cols, minPoint.y + ttemp.rows), Scalar(255, 0, 0));
	// imshow("s", src);
	// imshow("t", ttemp);
	// imshow("m", mask);
	// waitKey(0);

	return 1;
}

int matchShapesCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* tImage, int tWidth, int tLength, int tChannel, float* similarity) {
	
	Mat src, ttemp;
	Mat temp1, temp2, temp3, temp4;
	if(srcChannel == 1) {
		Mat temp1(srcLength, srcWidth, CV_8UC1, srcImage);
		threshold(temp1, src, 120, 255, THRESH_BINARY);
	}
	else {
		Mat temp1(srcLength, srcWidth, CV_8UC3, srcImage);
		cvtColor(temp1, temp2, CV_BGR2GRAY);
		threshold(temp2, src, 120, 255, THRESH_BINARY);
	}
	if (tChannel == 1) {
		Mat temp3(tLength, tWidth, CV_8UC1, tImage);
		threshold(temp3, ttemp, 120, 255, THRESH_BINARY);
	}
	else {
		Mat temp3(tLength, tWidth, CV_8UC3, tImage);
		cvtColor(temp3, temp4, CV_BGR2GRAY);
		threshold(temp4, ttemp, 120, 255, THRESH_BINARY);
	}

	vector<vector<Point>> contours, tcontours;
	vector<Vec4i> hierarchy, thierarchy;
	findContours(src, contours, hierarchy, RETR_LIST, CHAIN_APPROX_NONE);
	findContours(ttemp, tcontours, thierarchy, RETR_LIST, CHAIN_APPROX_NONE);

	*similarity = (float)matchShapes(contours[0], tcontours[0], CONTOURS_MATCH_I2, 0);

	return 1;
}

int sobelCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize){
	Mat img, dst;
	if (srcChannel == 1){
		img = Mat(srcHeight, srcWidth, CV_8UC1, srcImage);
	} else {
		img = Mat(srcHeight, srcWidth, CV_8UC3, srcImage);
		//cvtColor(tmp, img, CV_BGR2GRAY);
	}

	Sobel(img, dst, -1, dx, dy, ksize);

	memcpy(outImage, dst.data, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	
	return 1;
}

int sobelXYCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int dx, int dy, int ksize){
	Mat img, dst1, dst2, dst;
	if (srcChannel == 1){
		img = Mat(srcHeight, srcWidth, CV_8UC1, srcImage);
		dst = img.clone();

		Sobel(img, dst1, -1, dx, 0, ksize);
		Sobel(img, dst2, -1, 0, dy, ksize);

		for (size_t i = 0; i < img.rows; i++) {
			for (size_t j = 0; j < img.cols; j++) {
				dst.at<unsigned char>(i, j) = static_cast<unsigned char>(dst1.at<unsigned char>(i, j) + dst2.at<unsigned char>(i, j));
			}
		}
	} else {
		img = Mat(srcHeight, srcWidth, CV_8UC3, srcImage);
		dst = img.clone();

		Sobel(img, dst1, -1, dx, 0, ksize);
		Sobel(img, dst2, -1, 0, dy, ksize);

		for (size_t i = 0; i < img.rows; i++) {
			for (size_t j = 0; j < img.cols; j++) {
				for (int k = 0; k < img.channels(); k++) {
					dst.at<Vec3b>(i, j)[k] = static_cast<unsigned char>(dst1.at<Vec3b>(i, j)[k] + dst2.at<Vec3b>(i, j)[k]);
				}
			}
		}
	}

	memcpy(outImage, dst.data, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	
	return 1;
}

int laplacianCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int ksize){
	Mat img, dst;
	if (srcChannel == 1){
		img = Mat(srcHeight, srcWidth, CV_8UC1, srcImage);
	} else {
		img = Mat(srcHeight, srcWidth, CV_8UC3, srcImage);
		//cvtColor(tmp, img, CV_BGR2GRAY);
	}

	Laplacian(img, dst, -1, ksize);

	memcpy(outImage, dst.data, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	
	return 1;
}

int cannyCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int gaussianSize, int low_threshold, int high_threshold){
	Mat img, dst;
	if (srcChannel == 1){
		img = Mat(srcHeight, srcWidth, CV_8UC1, srcImage);
	} else {
		img = Mat(srcHeight, srcWidth, CV_8UC3, srcImage);
		//cvtColor(tmp, img, CV_BGR2GRAY);
	}

	Canny(img, dst, low_threshold, high_threshold, gaussianSize);

	memcpy(outImage, dst.data, srcWidth*srcHeight*1);
	*outChannel = 1;
	*outHeight = srcHeight;
	*outWidth = srcWidth;
	
	return 1;
}

int houghLinesPCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, int* lines, float rho, float theta, int threshold, float minLineLen, float maxLineGap) {
	Mat img = Mat(srcHeight, srcWidth, CV_8UC1, srcImage);
	vector<Vec4i> line;
	HoughLinesP(img, line, rho, theta, threshold, minLineLen, maxLineGap);
	lines[0] = line.size();
	for (size_t i = 0; i < line.size(); i++){
		lines[i * 4 + 1] = line[i][0];
		lines[i * 4 + 2] = line[i][1];
		lines[i * 4 + 3] = line[i][2];
		lines[i * 4 + 4] = line[i][3];
	}

	return 1;
}

int drawHoughLinesCV(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* lines) {
	Mat src;
	if(srcChannel == 1){
		src.create(srcHeight, srcWidth, CV_8UC1);
	}else if(srcChannel == 3){
		src.create(srcHeight, srcWidth, CV_8UC3);
	}

	for (size_t i = 0; i < lines[0]; i++){
		line(src, Point(lines[i*4+1],lines[i*4+2]), Point(lines[i*4+3],lines[i*4+4]), Scalar(255,0,255), 2, 8);
	}

	memcpy(outImage, src.data, srcWidth*srcHeight*srcChannel);
	*outChannel = srcChannel;
	*outHeight = srcHeight;
	*outWidth = srcWidth;

	return 1;
}

// old

int cvtColorCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel) {
	Mat img, dst;
	int colorCode = 0;
	if (srcChannel == 1) {
		img = Mat(srcLength, srcWidth, CV_8UC1, srcImage);
		colorCode = COLOR_BGR2GRAY;
	}
	else if (srcChannel == 3) {
		img = Mat(srcLength, srcWidth, CV_8UC3, srcImage);
		colorCode = COLOR_BGR2GRAY;
	}
	else if (srcChannel == 4) {
		img = Mat(srcLength, srcWidth, CV_8UC4, srcImage);
		colorCode = COLOR_BGRA2GRAY;
	}

	cvtColor(img, dst, colorCode);
	memcpy(outImage, dst.data, dst.cols*  dst.rows);
	*outChannel = dst.channels();
	*outHeight = dst.rows;
	*outWidth = dst.cols;

	return 1;
}

int findAllContoursCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int selectSize, float* centerPoint, float* rectPoint) {
	Mat img;
	if (srcChannel == 1) {
		img = Mat(srcLength, srcWidth, CV_8UC1, srcImage);
		// Mat img2 = Mat(srcLength, srcWidth, CV_8UC1, srcImage);
		// Mat tmp1;
		// bilateralFilter(img2, tmp1, 10, 20, 10);
		// adaptiveThreshold(tmp1, img, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 25, 10);
	}
	else if (srcChannel == 3) {
		Mat img2(srcLength, srcWidth, CV_8UC3, srcImage);
		Mat tmp, tmp1;
		cvtColor(img2, tmp, CV_BGR2GRAY);
		bilateralFilter(tmp, tmp1, 10, 20, 10);
		adaptiveThreshold(tmp1, img, 255, ADAPTIVE_THRESH_MEAN_C, THRESH_BINARY, 25, 10);
	}

	vector<vector<Point> > contours;
	vector<Vec4i > hierarchy;
	findContours(img, contours, hierarchy, RETR_LIST, CHAIN_APPROX_NONE);
	
	for (int i = 0; i < contours.size() - 1; i++) {
		for (int j = 0; j < contours.size() - i - 1; j++) {
			if(contourArea(contours[j]) > contourArea(contours[j+1])){
				vector<Point> temp = contours[j];
				contours[j] = contours[j+1];
				contours[j+1] = temp;
			}
		}
	}
	RotatedRect rect;
	Point2f vertices[4];
	if(selectSize > 0){
		//rect = boundingRect(contours[contours.size() - selectSize - 1]);
		rect = minAreaRect(contours[contours.size() - selectSize]);
		rect.points(vertices);
		centerPoint[0] = 1;
		centerPoint[1] = rect.center.x;
		centerPoint[2] = rect.center.y;
		rectPoint[0] = 11;
		rectPoint[1] = vertices[0].x;
		rectPoint[2] = vertices[0].y;
		rectPoint[3] = vertices[1].x;
		rectPoint[4] = vertices[1].y;
		rectPoint[5] = vertices[2].x;
		rectPoint[6] = vertices[2].y;
		rectPoint[7] = vertices[3].x;
		rectPoint[8] = vertices[3].y;
	}
	Mat imgCon = Mat::zeros(img.size(), CV_8UC1);
	for (int i = 0; i < hierarchy.size(); i++) {
		drawContours(imgCon, contours, i, Scalar(255,255,255), 0, 8, hierarchy);
		if(selectSize > 0){
			line(imgCon, vertices[0], vertices[1], Scalar(255,255,255), 1);
			line(imgCon, vertices[1], vertices[2], Scalar(255,255,255), 1);
			line(imgCon, vertices[2], vertices[3], Scalar(255,255,255), 1);
			line(imgCon, vertices[3], vertices[0], Scalar(255,255,255), 1);
		}
	}
	memcpy(outImage, imgCon.data, imgCon.cols*imgCon.rows);
	*outChannel = 1;
	*outHeight = imgCon.rows;
	*outWidth = imgCon.cols;

	return 1;
}

int drawLineCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* LinePoint) {
	if (srcChannel == 1) {
		Mat img(srcLength, srcWidth, CV_8UC1);
		memcpy(img.data, srcImage, srcLength*  srcWidth);
		Scalar CVcolor = Scalar(color[0]);
		line(img, Point((int)LinePoint[1], (int)LinePoint[2]), Point((int)LinePoint[3], (int)LinePoint[4]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength);
		img.release();
	}
	else if (srcChannel == 3) {
		Mat img(srcLength, srcWidth, CV_8UC3);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  3);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		line(img, Point((int)LinePoint[1], (int)LinePoint[2]), Point((int)LinePoint[3], (int)LinePoint[4]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  3);
		img.release();
	}
	else if (srcChannel == 4) {
		Mat img(srcLength, srcWidth, CV_8UC4);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  4);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		line(img, Point((int)LinePoint[1], (int)LinePoint[2]), Point((int)LinePoint[3], (int)LinePoint[4]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  4);
		img.release();
	}

	*outChannel = srcChannel;
	*outHeight = srcLength;
	*outWidth = srcWidth;

	return 1;
}

int drawRectCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* RectPoint) {
	if (srcChannel == 1) {
		Mat img(srcLength, srcWidth, CV_8UC1);
		memcpy(img.data, srcImage, srcLength*  srcWidth);
		Scalar CVcolor = Scalar(color[0]);
		//rectangle(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[3], (int)RectPoint[4]), Point((int)RectPoint[5], (int)RectPoint[6]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[5], (int)RectPoint[6]), Point((int)RectPoint[7], (int)RectPoint[8]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[7], (int)RectPoint[8]), Point((int)RectPoint[1], (int)RectPoint[2]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength);
		img.release();
	}
	else if (srcChannel == 3) {
		Mat img(srcLength, srcWidth, CV_8UC3);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  3);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		//rectangle(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[3], (int)RectPoint[4]), Point((int)RectPoint[5], (int)RectPoint[6]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[5], (int)RectPoint[6]), Point((int)RectPoint[7], (int)RectPoint[8]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[7], (int)RectPoint[8]), Point((int)RectPoint[1], (int)RectPoint[2]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  3);
		img.release();
	}
	else if (srcChannel == 4) {
		Mat img(srcLength, srcWidth, CV_8UC4);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  4);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		//rectangle(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[1], (int)RectPoint[2]), Point((int)RectPoint[3], (int)RectPoint[4]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[3], (int)RectPoint[4]), Point((int)RectPoint[5], (int)RectPoint[6]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[5], (int)RectPoint[6]), Point((int)RectPoint[7], (int)RectPoint[8]), CVcolor, thickness, 8);
		line(img, Point((int)RectPoint[7], (int)RectPoint[8]), Point((int)RectPoint[1], (int)RectPoint[2]), CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  4);
		img.release();
	}

	*outChannel = srcChannel;
	*outHeight = srcLength;
	*outWidth = srcWidth;

	return 1;
}

int drawCircleCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, int* color, int thickness, float* CirclePoint, int radius) {
	if (srcChannel == 1) {
		Mat img(srcLength, srcWidth, CV_8UC1);
		memcpy(img.data, srcImage, srcLength*  srcWidth);
		Scalar CVcolor = Scalar(color[0]);
		circle(img, Point((int)CirclePoint[1], (int)CirclePoint[2]), radius, CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength);
		img.release();
	}
	else if (srcChannel == 3) {
		Mat img(srcLength, srcWidth, CV_8UC3);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  3);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		circle(img, Point((int)CirclePoint[1], (int)CirclePoint[2]), radius, CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  3);
		img.release();
	}
	else if (srcChannel == 4) {
		Mat img(srcLength, srcWidth, CV_8UC4);
		memcpy(img.data, srcImage, srcLength*  srcWidth*  4);
		Scalar CVcolor = Scalar((double)color[0], (double)color[1], (double)color[2]);
		circle(img, Point((int)CirclePoint[1], (int)CirclePoint[2]), radius, CVcolor, thickness, 8);
		memcpy(outImage, img.data, srcWidth*  srcLength*  4);
		img.release();
	}

	*outChannel = srcChannel;
	*outHeight = srcLength;
	*outWidth = srcWidth;
	return 1;
}

int iiiot_matchTemplateCV(unsigned char* srcImage, int srcWidth, int srcLength, int srcChannel, unsigned char* templateImage, int templateWidth, int templateLength, int templateChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* src_corners, float* dst_corners, float dstWidth, float dstHeight) {
	Mat src, dest_template;
	if(srcChannel == 1)
		Mat src(srcLength, srcWidth, CV_8UC1, srcImage);
	else {
		Mat temp(srcLength, srcWidth, CV_8UC3, srcImage);
		cvtColor(temp, src, CV_BGR2GRAY);
	}
	if (templateChannel == 1)
		Mat dest_template(templateLength, templateWidth, CV_8UC1, templateImage);
	else {
		Mat temp2(templateLength, templateWidth, CV_8UC3, templateImage);
		cvtColor(temp2, dest_template, CV_BGR2GRAY);
	}

	vector<Point2f> srcCorners;
	vector<Point2f> dstCorners;
	for (int i = 1; i < src_corners[1]*  2; i++, i++)
	{
		srcCorners.push_back(Point(src_corners[i + 1], src_corners[i + 2]));
	}
	for (int i = 1; i < dst_corners[1]*  2; i++, i++)
	{
		dstCorners.push_back(Point(dst_corners[i + 1], dst_corners[i + 2]));
	}
	Mat warpmatrix = getPerspectiveTransform(srcCorners, dstCorners);
	Mat unwarpmatrix = getPerspectiveTransform(dstCorners, srcCorners);

	Mat transfrom_image;
	//float col = dst_corners[4] > dst_corners[8] ? dst_corners[4] : dst_corners[8];
	//2,4,1557,1395,1831,761,2251,1751,2601,869
	//float row = dst_corners[7] > dst_corners[9] ? dst_corners[7] : dst_corners[9];
	//2,4,41,25,453,18,20,537,458,556
	//1.356304,-2.887533,2154.304,4.587518,2.058537,-9869.328,0.00179938,0.001435315,1
	//-0.07015166,-0.1203346,283.2593,-0.1274778,-0.05312559,276.3532,-0.0004043608,-0.0001577127,1
	transfrom_image.create(dstHeight, dstWidth, CV_8UC1);
	warpPerspective(src, transfrom_image, warpmatrix, transfrom_image.size());

	//match the template
	Mat dest;
	dest.create(transfrom_image.rows - dest_template.rows + 1, transfrom_image.cols - dest_template.cols + 1, CV_32FC1);
	matchTemplate(transfrom_image, dest_template, dest, CV_TM_SQDIFF);

	Point minPoint;
	minMaxLoc(dest, NULL, NULL, &minPoint, NULL);
	rectangle(transfrom_image, minPoint, Point(minPoint.x + dest_template.cols, minPoint.y + dest_template.rows), Scalar(255), 2, 8);
	
	memcpy(outImage, transfrom_image.data, transfrom_image.cols*  transfrom_image.rows);
	*outChannel = 1;
	*outHeight = transfrom_image.rows;
	*outWidth = transfrom_image.cols;

	return 1;
}

int SolvePseudoInverse(float* ImgaePointSet, float* SpacePointSet, int num, float* Trans, float* ReverseTrans)
{
	int img_rows = num;//标定点的行数
	int img_cols = 4;//标定点的组数
	int space_rows = num;//标定点的行数
	int space_cols = 3;//标定点的组数
	//图像点矩阵
	Mat matrixImage;
	matrixImage.create(img_rows, img_cols, CV_32FC1);
	memcpy(matrixImage.data, ImgaePointSet, sizeof(float) * img_rows * img_cols);
	//空间点矩阵
	Mat matrixSpace;
	matrixSpace.create(space_rows, space_cols, CV_32FC1);
	memcpy(matrixSpace.data, SpacePointSet, sizeof(float) * space_rows * space_cols);
	//图像点矩阵伪逆
	Mat inverseImage;
	invert(matrixImage, inverseImage, 1);
	//图像转空间转移矩阵
	Mat trans;
	gemm(inverseImage, matrixSpace, 1, NULL, 0, trans);
	//图像转空间转移矩阵伪逆
	Mat inversetrans;
	invert(trans, inversetrans, 1);
	memcpy(Trans, trans.data, sizeof(float) * 4 * 3);
	memcpy(ReverseTrans, inversetrans.data, sizeof(float) * 4 * 3);

	return 1;
}

int IMG_CvPreCornerDetect(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int ksize)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}

	preCornerDetect( srcImage, dstImage, ksize);
	memcpy(dstData,dstImage.data,width*height);
	*outWidth = width;
	*outHeight = height;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_CornerEigenValsAndVecs(unsigned char* imgData, int width, int height, int channel,float* dstData, int block_size, int ksize)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	dstImage.create(height, width, CV_32FC(6));
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	cornerEigenValsAndVecs(srcImage, dstImage,block_size,ksize);
	dstData[0] = dstImage.at<Vec6f>(100, 100)[0];
	dstData[1] = dstImage.at<Vec6f>(100, 100)[1];
	dstData[2] = dstImage.at<Vec6f>(100, 100)[2];
	dstData[3] = dstImage.at<Vec6f>(100, 100)[3];
	dstData[4] = dstImage.at<Vec6f>(100, 100)[4];
	dstData[5] = dstImage.at<Vec6f>(100, 100)[5];
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_CornerMinEigenVal(unsigned char* imgData, int width, int height, int channel,float* dstData, int block_size, int ksize)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	cornerMinEigenVal(srcImage, dstImage, block_size, ksize, BORDER_DEFAULT);
	dstData[0] = dstImage.at<float>(100, 100);
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_FindCornerSubPix(unsigned char* imgData, int width, int height, int channel, float* inData, float* dstData, int* halfWinSize, int* zone,float* criteria)
{
	Mat srcImage, dstImage,maskImage;
	CvPoint2D32f* corners = new CvPoint2D32f[ (int)inData[1]];
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}

	int index = 0;
	for (int i = 2; i <=(int)inData[1]*2; i=i+2)
	{
		corners[index].x =  inData[i];
		corners[index].y =  inData[i+1];
		index++;
	}
	IplImage tmp1=IplImage(srcImage);
	cvFindCornerSubPix(&tmp1,corners,(int)inData[1],
			cvSize( halfWinSize[0],halfWinSize[1]),
			cvSize(zone[0],zone[1]),
			cvTermCriteria((int)criteria[0],(int)criteria[1],criteria[2]));
	index=1;
	dstData[0] = inData[0];
	dstData[1] = inData[1];
	for (int i = 0; i <=(int)dstData[1]; i++)
	{
		index++;
		dstData[index] = corners[i].x;
		index++;
		dstData[index] = corners[i].y;
	}
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_GoodFeaturesToTrack(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, float* dstData, int  max_corners,float quality_level,float min_distance, int block_size, int use_harris)
{
	Mat srcImage, dstImage,maskImage;
	vector<Point2f> corners;
	if(channel1 == 1){
		srcImage.create(height1, width1, CV_8UC1);
		dstImage.create(height1, width1, CV_8UC1);
	}else if(channel1 == 3){
		srcImage.create(height1, width1, CV_8UC3);
		dstImage.create(height1, width1, CV_8UC3);
	}
	memcpy(srcImage.data, imgData1,height1*width1);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	if (imgData2!=NULL)
	{
		if(channel2 == 1){
			maskImage.create(height2, width2, CV_8UC1);
		}else if(channel2 == 3){
			maskImage.create(height2, width2, CV_8UC3);
		}
		memcpy(maskImage.data, imgData2,height2*width2);
	}
	bool harris;
	if(use_harris == 0)
		harris = false;
	else
		harris = true;
	goodFeaturesToTrack(srcImage, corners, max_corners, quality_level, min_distance, maskImage, block_size, harris, 0.04);
	dstData[0] = 2;
	dstData[1] = corners.size();
	int index=1;
	for (int i = 0; i < corners.size(); i++)
	{
		index++;
		dstData[index] = corners[i].x;
		index++;
		dstData[index] = corners[i].y;
	}
	srcImage.release();
	dstImage.release();
	maskImage.release();
	return 1;
}

int IMG_SampleLine(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel,float* pointList, int connectivity)
{
	Mat srcMat;
	Mat srcImage, dstImage;
	if(channel == 1){
		srcMat.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcMat.create(height, width, CV_8UC3);
	}
	memcpy(srcMat.data, imgData,height*width*srcMat.elemSize());
	if (srcMat.empty())
	{
		cout << "read error" << endl;
		return -1;
	}
	Point pt1,pt2;
	pt1.x = pointList[0];
	pt1.y = pointList[1];
	pt2.x = pointList[2];
	pt2.y = pointList[3];
	IplImage tmp1=IplImage(srcMat);
	int result = cvSampleLine(&tmp1,pt1,pt2,dstData,connectivity);
	*outWidth = width;
	*outHeight = height;
	*outChannel = channel;
	srcMat.release();	
	return 1;
}

// getRectSubPix()
//(height,width)ΪҪ��ȡͼ��ĸߺͿ���Ҳ����columns��rows���мǲ�ҪŪ���к�����(x,y)ΪҪ��ȡ���ε�����
//rect[rectHeight, rectWidth] nums[x,y]
int IMG_GetRectSubPixt(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int* rect, int* nums)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	getRectSubPix(srcImage, Size(rect[0], rect[1]), Point(nums[0], nums[1]), dstImage, -1);
	memcpy(dstData,dstImage.data,dstImage.rows*dstImage.cols);
	*outHeight = dstImage.rows;
	*outWidth = dstImage.cols;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

//��ȡ�����ı��Σ�ʹ�������ؾ���
int IMG_GetQuadrangleSubPix(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int* map)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	CvMat matrix;
	cvInitMatHeader(&matrix, 2, 3, CV_8UC1,map);
	IplImage tmp1=IplImage(srcImage);
	IplImage tmp2=IplImage(dstImage);
	cvGetQuadrangleSubPix(&tmp1, &tmp2, &matrix);
	Mat temp = cv::cvarrToMat(&tmp2);
	memcpy(dstData,temp.data,temp.rows*temp.cols);
	*outHeight = temp.cols;
	*outWidth = temp.rows;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_AffineByMat(unsigned char* srcImage, int srcWidth, int srcHeight, int srcChannel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel, float* transMat)
{
	Mat src,dstImage;
	if(srcChannel == 1){
		src.create(srcHeight, srcWidth, CV_8UC1);
		dstImage.create(srcHeight, srcWidth, CV_8UC1);
	}else if(srcChannel == 3){
		src.create(srcHeight, srcWidth, CV_8UC3);
		dstImage.create(srcHeight, srcWidth, CV_8UC3);
	}
	memcpy(src.data,srcImage,srcHeight*srcWidth*src.elemSize());
	if (src.empty())
	{	
		cout << "image file read error" << endl;
		return -1;
	}
	Mat trans(2, 3, CV_64FC1);
	for(int m=0;m<2;m++)
	{
		for(int n=0;n<3;n++)
		{
			int offset=m*3+n;
			trans.at<double>(m,n)=transMat[offset];
		}
	}
	warpAffine(src,dstImage,trans,Size(srcWidth,srcHeight));
	memcpy(outImage,dstImage.data,dstImage.rows*dstImage.cols*dstImage.elemSize());
	*outHeight = dstImage.rows;
	*outWidth = dstImage.cols;
	*outChannel = dstImage.channels();
	return 1;
}

int IMG_GetRectRoatationMatrix(float* center,float angle,float scale, float* mat)
{
	Point2f cen(center[1],center[2]);
	Mat rot_mat=getRotationMatrix2D(cen,angle,scale);
	for(int m=0;m<2;m++)
	{
		for(int n=0;n<3;n++)
		{
			mat[m*3+n]=rot_mat.at<double>(m,n);
		}
	}
	return 1;
}

int IMG_PerspectiveByMat(unsigned char*  imgData, int width, int height, int channel, unsigned char* outImage, int* outWidth, int* outHeight, int* outChannel,float*  homo)
{
	Mat srcImage,dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}else if(channel == 4){
		srcImage.create(height, width, CV_8UC4);
		dstImage.create(height, width, CV_8UC4);
	}
	memcpy(srcImage.data, imgData,height*width*srcImage.elemSize());
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	Mat trans(3, 3, CV_64FC1);
	for(int m=0;m<3;m++)
	{
		for(int n=0;n<3;n++)
		{
			int offset=m*3+n;
			trans.at<double>(m,n)=homo[offset];
		}
	}
	warpPerspective(srcImage,dstImage,trans,Size(width,height));
	memcpy(outImage,dstImage.data,dstImage.rows*dstImage.cols*dstImage.elemSize());
	*outWidth = width;
	*outHeight = height;
	*outChannel = channel;
	return 1;
}

int IMG_PerspectiveTrans(float* RectPoints1,float* RectPoints2,float* TransRect)
{
	int perspectivePointsNum=4;
	CvPoint2D32f PerspectivePoints0[4];
	CvPoint2D32f PerspectivePoints1[4];
	for(int i=0;i<perspectivePointsNum;i++)
	{
		PerspectivePoints0[i].x=(float)RectPoints1[2*i];
		PerspectivePoints0[i].y=(float)RectPoints1[2*i+1];
		PerspectivePoints1[i].x=(float)RectPoints2[2*i];
		PerspectivePoints1[i].y=(float)RectPoints2[2*i+1];
	}
	CvMat * matT=cvCreateMat(3,3,CV_32FC1);;
	cvGetPerspectiveTransform(PerspectivePoints0,PerspectivePoints1,matT);
	for(int m=0;m<3;m++)
	{
		for(int n=0;n<3;n++)
		{
			int offset=m*3+n;
			TransRect[offset]=CV_MAT_ELEM(*matT,float,m,n);
		}
	}
	return 1;
}

// int IMG_Erode(unsigned char*  imgData, int width, int height, unsigned char*  dstData, int kerSize1, int kerSize2)
// {
// 	Mat srcImage, dstImage;
// 	srcImage.create(height, width, CV_8UC1);
// 	memcpy(srcImage.data, imgData,height*width);
// 	if (srcImage.empty())
// 	{
// 		cout << "image file read error" << endl;
// 		return -1;
// 	}
// 	Mat kernel = getStructuringElement(MORPH_RECT, Size(kerSize1,kerSize2));
// 	erode(srcImage,dstImage,kernel);
// 	memcpy(dstData,dstImage.data,width*height);
// 	srcImage.release();
// 	dstImage.release();
// 	return 1;
// }

// int IMG_Dilate(unsigned char*  imgData, int width, int height, unsigned char*  dstData, int kerSize1, int kerSize2)
// {
// 	Mat srcImage, dstImage;
// 	srcImage.create(height, width, CV_8UC1);
// 	memcpy(srcImage.data, imgData,height*width);
// 	if (srcImage.empty())
// 	{
// 		cout << "image file read error" << endl;
// 		return -1;
// 	}
// 	Mat kernel = getStructuringElement(MORPH_RECT, Size(kerSize1,kerSize2));
// 	dilate(srcImage,dstImage,kernel);
// 	memcpy(dstData,dstImage.data,width*height);
// 	srcImage.release();
// 	dstImage.release();
// 	return 1;
// }

int IMG_MorphologyOpen(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int kerSize1, int kerSize2)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);  
	} 
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	Mat kernel = getStructuringElement(MORPH_RECT, Size(kerSize1,kerSize2));
	morphologyEx( srcImage, dstImage, MORPH_OPEN, kernel);
	memcpy(dstData,dstImage.data,width*height);
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}
// int size1=3, int size2=0, float sigma1=0,float sigma2=0 
int IMG_Smooth(unsigned char*  imgData, int width, int height, int channel,	unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int smoothType, int size1, int size2, float sigma1,float sigma2)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width*srcImage.elemSize());
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	IplImage temp = IplImage(srcImage);
	IplImage temp2 = IplImage(dstImage);

	cvSmooth(&temp,&temp2, smoothType, size1,size2, sigma1,sigma2);

	Mat m = cvarrToMat(&temp2);
	memcpy(dstData,m.data,width*height*srcImage.elemSize());
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_Filter2D(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int kernel_size1, int kernel_size2,float* kernelList)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	int index = 0;
	Mat kernel = (Mat_<float>(kernel_size1, kernel_size2));
	for (int i = 0; i < kernel_size1; i++)
	{
		for (int j = 0; j < kernel_size2; j++)
		{
			kernel.ptr<float>(i)[j] = kernelList[index];
			index++;
		}
	}

	filter2D(srcImage, dstImage, srcImage.depth(), kernel);
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	memcpy(dstData,dstImage.data,width*height);
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_Integral(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel, int deepth)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	integral(srcImage, dstImage,deepth);
	memcpy(dstData,dstImage.data,width*height);
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}
//x=width=cols;y=height=rows;
int IMG_PyrDown(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	pyrDown(srcImage, dstImage, Size(srcImage.cols / 2, srcImage.rows / 2));
	memcpy(dstData,dstImage.data,dstImage.rows*dstImage.cols);
	*outWidth = width/2;
	*outHeight=height/2;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_PyrUp(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	pyrUp(srcImage, dstImage, Size(srcImage.cols*  2, srcImage.rows*  2));
	memcpy(dstData,dstImage.data,dstImage.rows*dstImage.cols);
	*outWidth = width*2;
	*outHeight=height*2;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_PyrMeanShiftFiltering(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel,  float sp,float sr, int maxLevel)
{
	Mat srcImage, dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	memcpy(srcImage.data, imgData,height*width*srcImage.elemSize());
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	pyrMeanShiftFiltering(srcImage,dstImage, sp, sr, maxLevel);
	memcpy(dstData,dstImage.data,width*height*srcImage.elemSize());
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

int IMG_FloodFill(unsigned char*  imgData, int width, int height, int channel, unsigned char*  dstData, int* outWidth, int* outHeight, int* outChannel, int*  seed, int*  newBGR, int*  rect, int*  loBGR, int*  upBGR, int flags)
{
	Mat srcImage, maskImage;
	Rect rec;
	if(rect){
		rec = Rect(rect[0],rect[1],rect[2],rect[3]);
	}
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
	}
	maskImage.create(height+2, width+2, CV_8UC1);
	memcpy(srcImage.data, imgData,height*width*srcImage.elemSize());
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}

	floodFill(srcImage,maskImage, Point(seed[0],seed[1]), Scalar(newBGR[0],newBGR[1],newBGR[2]), &rec, Scalar(loBGR[0],loBGR[1],loBGR[2]), Scalar(upBGR[0], upBGR[1], upBGR[2]), flags);

	memcpy(dstData,srcImage.data,width*height*srcImage.elemSize());
	*outWidth=width;
	*outHeight=height;
	*outChannel = channel;
	srcImage.release();
	maskImage.release();
	return 1;
}
//m00,m10,m01,m20,m11,m02,m30,m21,m12,m03
int  IMG_SpatialMoments(float*  imgData,float* spaMome)
{
	vector<vector<Point2f> > contours;
	int index=0;
	for(int i=0;i<imgData[0];i++)
	{
		vector<Point2f> conSingle;
		index++;
		int conIndex=imgData[index];
		for(int j=0;j<conIndex;j++)
		{
			index++;
			float x=imgData[index];
			index++;
			float y=imgData[index];
			Point2f conPt(x,y);
			conSingle.push_back(conPt);
		}
		contours.push_back(conSingle);
	}
	vector<vector<Point2f> >::iterator it;
	it=contours.begin();
	int conSize=0;
	while(it!=contours.end())
	{

		Moments mo=moments(Mat(*it++));

		spaMome[conSize*10+0]=mo.m00;
		spaMome[conSize*10+1]=mo.m10;
		spaMome[conSize*10+2]=mo.m01;
		spaMome[conSize*10+3]=mo.m20;
		spaMome[conSize*10+4]=mo.m11;
		spaMome[conSize*10+5]=mo.m02;
		spaMome[conSize*10+6]=mo.m30;
		spaMome[conSize*10+7]=mo.m21;
		spaMome[conSize*10+8]=mo.m12;
		spaMome[conSize*10+9]=mo.m03;
		conSize++;
	}
	return 1;
}

	//mu20,mu11,mu02,mu30,mu21,mu12,mu03
int IMG_CentralMoments(float* imgData,float*  cenMome)
{
	vector<vector<Point2f> > contours;
	int index=0;
	for(int i=0;i<imgData[0];i++)
	{
		vector<Point2f> conSingle;
		index++;
		int conIndex=imgData[index];
		for(int j=0;j<conIndex;j++)
		{
			index++;
			float x=imgData[index];
			index++;
			float y=imgData[index];
			Point2f conPt(x,y);
			conSingle.push_back(conPt);
		}
		contours.push_back(conSingle);
	}
	vector<vector<Point2f> >::iterator it;
	it=contours.begin();
	int conSize=0;
	while(it!=contours.end())
	{

		Moments mo=moments(Mat(*it++));
		cenMome[conSize*7+0]=mo.mu20;
		cenMome[conSize*7+1]=mo.mu11;
		cenMome[conSize*7+2]=mo.mu02;
		cenMome[conSize*7+3]=mo.mu30;
		cenMome[conSize*7+4]=mo.mu21;
		cenMome[conSize*7+5]=mo.mu12;
		cenMome[conSize*7+6]=mo.mu03;
		conSize++;
	}
	return 1;
}

int IMG_MatchTemplate(unsigned char*  imgData1, int wid1, int hei1, int channel1, unsigned char*  imgData2, int wid2, int hei2, int channel2,float* result, int method)
{
	Mat  bina1,bina2;
	if(channel1 == 1){
		bina1.create(hei1,wid1, CV_8UC1);
			bina2.create(hei2,wid2,CV_8UC1);
	}else if(channel1 == 3){
		bina1.create(hei1,wid1, CV_8UC3);
			bina2.create(hei2,wid2,CV_8UC3);
	}
	//srcImage
	memcpy(bina1.data, imgData1,hei1*wid1);
	//template
	memcpy(bina2.data, imgData2,hei2*wid2);

	if (bina1.empty()||bina2.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	Mat resu;
	matchTemplate(bina1,bina2,resu,method);
	for(int i=0;i<resu.rows;i++)
	{
		for(int j=0;j<resu.cols;j++)
		{
			int offset=i*resu.cols+j;
			result[offset]=resu.at<float>(i,j);
		}
	}
	return 1;
}

int IMG_MatchShapes(int*  inputData1, int*  inputData2, int method, float* dstData)
	{
	vector<Point>contours1;
	vector<Point>contours2;
	int contours1Size = inputData1[0];//��1������������
	int contours2Size = inputData2[0];//��2������������

	vector<Point> conPt;
	for(int k=1;k<=(inputData1[contours1Size]*2);k=k+2)
	{
		Point pt;
		pt.x=inputData1[k];
		pt.y=inputData1[k+1];
		contours1.push_back(pt);
	}
		
	vector<Point> conPt1;
	for(int k=1;k<=(inputData2[contours2Size]*2);k=k+2)
	{
		Point pt;
		pt.x=inputData2[k];
		pt.y=inputData2[k+1];
		contours2.push_back(pt);
	}
	
	double result = matchShapes(contours1,contours2,method,0);
	dstData[0] = (float)result;
	return 1;
	}
	
	//The signatures must be 32fC1 in function 'cvCalcEMD2'
int IMG_CalcEMD2(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, int distanceType,float* dstData)
{
	Mat srcMat1,srcMat2;
	if(channel1 == 1){
		srcMat1.create(height1, width1, CV_32FC1);
		srcMat2.create(height2, width2, CV_32FC1);
	}else if(channel1 == 3){
		srcMat1.create(height1, width1, CV_32FC3);
		srcMat2.create(height2, width2, CV_32FC3);
	}
	memcpy(srcMat1.data, imgData1,height1*width1*srcMat1.elemSize());
	memcpy(srcMat2.data, imgData2,height2*width2*srcMat2.elemSize());
	if (srcMat1.empty() || srcMat2.empty())
	{
		cout << "read error" << endl;
		return -1;
	}
	IplImage tmp1=IplImage(srcMat1);
	IplImage tmp2=IplImage(srcMat2);
	float result = cvCalcEMD2(&tmp1,&tmp2,distanceType);
	dstData[0] = result;
	srcMat1.release();
	srcMat2.release();
	return 1;
}

int IMG_ApproxPolyDp(float*  pts,float*  ptPoly)
{
	vector<Point2f> ptArray;
	int num0=pts[1];
	for(int k=2;k<2*num0+2;k++,k++)
	{
		Point2f point(pts[k],pts[k+1]);
		ptArray.push_back(point);
	}
	vector<Point2f> approxPloy;
	approxPolyDP(ptArray,approxPloy,1,true);
	int index=1;
	ptPoly[0]=2;
	ptPoly[1]=approxPloy.size();
	for(int k=0;k<approxPloy.size();k++)
	{
		index++;
		ptPoly[index]=approxPloy[k].x;
		index++;
		ptPoly[index]=approxPloy[k].y;
	}
	return 1;
}

float IMG_ContourArea(float*  imgData)
{
	int index=1;
	vector<Point2f> conSingle;
	int ptSize=imgData[1];
	for(int j=0;j<ptSize;j++)
	{
		index++;
		float x=imgData[index];
		index++;
		float y=imgData[index];
		Point conPt(x,y);
		conSingle.push_back(conPt);
	}
	float area=contourArea(conSingle);
	return area;
}

float IMG_ContourLength(float*  imgData,bool isColsed)
{
	int index=1;
	vector<Point2f> conSingle;
	int ptSize=imgData[1];
	for(int j=0;j<ptSize;j++)
	{
		index++;
		float x=(float)imgData[index];
			index++;
		float y=(float)imgData[index];
		Point conPt(x,y);
		conSingle.push_back(conPt);
	}
	float area=arcLength(conSingle, isColsed);
	return area;
}

int IMG_MergeRect(float* rect1,float* rect2,float* rect3)
{
	float stan=0.01;
	float difx0=rect1[2]-rect1[0];
	float dify0=((rect1[7]-rect1[1]));

	float difx1=((rect2[2]-rect2[0]));
	float dify1=((rect2[7]-rect2[1]));

	const CvRect rectang1(rect1[0],rect1[1],difx0,dify0);
	const CvRect rectang2(rect2[0],rect2[1],difx1,dify1);
	Rect merRect=cvMaxRect(&rectang1,&rectang2);

	rect3[0]=merRect.x;
	rect3[1]=merRect.y;
	rect3[2]=merRect.x+merRect.width;
	rect3[3]=merRect.y;

	rect3[6]=merRect.x;
	rect3[7]=merRect.y+merRect.height;
	rect3[4]=merRect.x+merRect.width;
	rect3[5]=merRect.y+merRect.height;
	return 1;
}
int IMG_BoxPoints(float* box2d,float* boxpt)
{
	if(!box2d)
		return -1;
	CvPoint2D32f center(box2d[0],box2d[1]);
	CvSize2D32f  sizeBox(box2d[2],box2d[3]);
	float angle=box2d[4];
	CvBox2D box;
	CvPoint2D32f pt[4];
	cvBoxPoints(box,pt);
	boxpt[0]=pt[0].x;
	boxpt[0]=pt[0].y;
	boxpt[1]=pt[1].x;
	boxpt[1]=pt[1].y;
	boxpt[2]=pt[2].x;
	boxpt[2]=pt[2].y;
	boxpt[3]=pt[3].x;
	boxpt[3]=pt[3].y;
	return 1;
}

int IMG_CvFitEllipse(float*  pts,float* ellip)
{
	int index=0;
	vector<Point2f> ptArray;
	int num0=pts[1];
	for(int k=2;k<2*num0+2;k++,k++)
	{
		Point2f point(pts[k],pts[k+1]);
		ptArray.push_back(point);
	}
	
	RotatedRect box2D=fitEllipse(ptArray);
	ellip[0]=box2D.center.x;
	ellip[1]=box2D.center.y;
	ellip[2]=box2D.size.width;
	ellip[3]=box2D.size.height;
	ellip[4]=box2D.angle;
	return 1;
}

//11,8,48,58,105,98,155,160,212,220,248,260,320,300,350,360,412,400	
// 48	58
// 105	98
// 155	160
// 212	220
// 248	260
// 320	300
// 350	360
// 412	400

int IMG_CvFitLine(float*  pts,float* line)
{
	int index=0;
	vector<Point2f> ptArray;
	int num0=pts[1];
	for(int k=2;k<2*num0+2;k++,k++)
	{
		Point2f point(pts[k],pts[k+1]);
		ptArray.push_back(point);
	}
	vector<float> ss;
	fitLine(ptArray,ss,DIST_L1,1,0.001,0.001);
	for(int i = 0; i < 4; i++)
	{
		line[i] = ss[i];
	}
	return 1;
}

int IMG_ConvexHull2(float* inputData, float* res) 
{
	//����㼯
	vector<Point2f> input;
	for (int i = 0; i < inputData[1]; i++) {
		input.push_back(Point2f(inputData[i*2+2], inputData[i*  2 + 3]));
	}
	//������
	vector<Point2f> hull(input.size());
	convexHull(input, hull);
	//�����������
	//res = (int*)malloc(sizeof(int)*  hull.size()*2 + 1);
	res[0] = 2;
	res[1] = hull.size();
	//�����ֵ
	for (int i = 0; i < hull.size(); i++) {
		res[2*  i + 2] = hull[i].x;
		res[2*  i + 3] = hull[i].y;
	}
	return 1;
}

bool IMG_CheckContourConvexity(float* inputData)
{
	//����㼯
	vector<Point2f> input;
	for (int i = 0; i < inputData[1]; i++) {
		input.push_back(Point2f(inputData[i*  2 + 2], inputData[i*  2 + 3]));
	}
	return isContourConvex(input);
}

void IMG_ConvexityDefects(float* inputData, float* res) 
{
	//����㼯
	vector<Point2f> input;
	for (int i = 0; i < inputData[1]; i++) {
		input.push_back(Point2f(inputData[i*  2 + 2], inputData[i*  2 + 3]));
	}
	//������
	vector<Point2f> hull(input.size());
	vector<int> hullsI(input.size());
	convexHull(input, hull,false);
	convexHull(input, hullsI, false);
	//���
	vector<Vec4i> defects;
	convexityDefects(input, hullsI, defects);
	//�����������
	//res = (float*)malloc(sizeof(float)*  defects.size()*  4 + 1);
	res[0] = defects.size();
	//�����ֵ
	for (int i = 0; i < defects.size(); i++) {
		res[4*  i + 1] = defects[i][0];
		res[4*  i + 2] = defects[i][1];
		res[4*  i + 3] = defects[i][2];
		res[4*  i + 4] = defects[i][3];
	}
}

int IMG_GetMinRectPrams(float*  imgData,float* rect)
{
	int index=1;
	vector<Point2i> conSingle;
	int ptSize=imgData[1];
	for(int j=0;j<ptSize;j++)
	{
		index++;
		float x=imgData[index];
		index++;
		float y=imgData[index];
		Point2f conPt(x,y);
		conSingle.push_back(conPt);
	}
	RotatedRect minRect=minAreaRect(conSingle);
	//rect=(float*)malloc(sizeof(float)*5);
	rect[0]=minRect.center.x;
	rect[1]=minRect.center.y;
	rect[2]=minRect.size.width;
	rect[3]=minRect.size.height;
	rect[4]=minRect.angle;
	return 1;
}

int IMG_minEnclosingCircle(float* inputData, float* res)
{
	//����㼯
	vector<Point2f> input;
	for (int i = 0; i < inputData[1]; i++) {
		input.push_back(Point2f(inputData[i*  2 + 2], inputData[i*  2 + 3]));
	}
	Point2f point;
	float radius;
	minEnclosingCircle(input,point,radius);
	//�����������
	//res = (float*)malloc(sizeof(float)*  3);
	res[0] = point.x;
	res[1] = point.y;
	res[2] = radius;
	return 1;
}

//�ۻ�ͼ��
int IMG_CvAcc(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel)
{
	Mat srcImage,dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_32FC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_32FC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	IplImage tmp1=IplImage(srcImage);
	IplImage tmp2=IplImage(dstImage);
	cvAcc(&tmp1,&tmp2);
	Mat temp = cv::cvarrToMat(&tmp2);
	memcpy(dstData,temp.data,temp.rows*temp.cols);
	*outWidth=temp.cols;
	*outHeight=temp.rows;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

//��������ͼ���ƽ�����ۻ�����
int IMG_CvSquareAcc(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel)
{
	Mat srcImage,dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_32FC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_32FC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	IplImage tmp1=IplImage(srcImage);
	IplImage tmp2=IplImage(dstImage);
	cvSquareAcc(&tmp1,&tmp2);
	Mat temp = cv::cvarrToMat(&tmp2);
	memcpy(dstData,temp.data,temp.rows*temp.cols);
	*outWidth=temp.cols;
	*outHeight=temp.rows;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}

//����������ͼ��ĳ˻����ӵ��ۻ�����
int IMG_CvMultiplyAcc(unsigned char* imgData1, int width1, int height1, int channel1, unsigned char* imgData2, int width2, int height2, int channel2, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel)
{
	Mat srcImage1,srcImage2,dstImage;
	if(channel1 == 1){
		srcImage1.create(height1, width1, CV_8UC1);
		srcImage2.create(height2, width2, CV_8UC1);
		dstImage.create(height1, width1, CV_32FC1);
	}else if(channel1 == 3){
		srcImage1.create(height1, width1, CV_8UC3);
		srcImage2.create(height2, width2, CV_8UC3);
		dstImage.create(height1, width1, CV_32FC3);
	}
	memcpy(srcImage1.data, imgData1,height1*width1);
	memcpy(srcImage2.data, imgData2,height2*width2);
	if (srcImage1.empty() || srcImage2.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	IplImage tmp1=IplImage(srcImage1);
	IplImage tmp2=IplImage(srcImage2);
	IplImage tmp3=IplImage(dstImage);
	cvMultiplyAcc(&tmp1,&tmp2,&tmp3);
	Mat temp = cv::cvarrToMat(&tmp3);
	memcpy(dstData,temp.data,temp.rows*temp.cols);
	*outWidth=temp.cols;
	*outHeight=temp.rows;
	*outChannel = channel1;
	srcImage1.release();
	srcImage2.release();
	dstImage.release();
	return 1;
}

int IMG_CvRunningAvg(unsigned char* imgData, int width, int height, int channel, unsigned char* dstData, int* outWidth, int* outHeight, int* outChannel,float alpha)
{
	Mat srcImage,dstImage;
	if(channel == 1){
		srcImage.create(height, width, CV_8UC1);
		dstImage.create(height, width, CV_32FC1);
	}else if(channel == 3){
		srcImage.create(height, width, CV_8UC3);
		dstImage.create(height, width, CV_32FC3);
	}
	memcpy(srcImage.data, imgData,height*width);
	if (srcImage.empty())
	{
		cout << "image file read error" << endl;
		return -1;
	}
	IplImage tmp1=IplImage(srcImage);
	IplImage tmp2=IplImage(dstImage);
	cvRunningAvg(&tmp1,&tmp2,alpha);
	Mat temp = cv::cvarrToMat(&tmp2);
	memcpy(dstData,temp.data,temp.rows*temp.cols);
	*outWidth=temp.cols;
	*outHeight=temp.rows;
	*outChannel = channel;
	srcImage.release();
	dstImage.release();
	return 1;
}


