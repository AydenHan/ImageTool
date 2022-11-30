using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ImageTool
{
    public class FuncDef
    {
        public static void Delay(int milliSecond)
        {
            int start = Environment.TickCount;
            while(Math.Abs(Environment.TickCount - start) < milliSecond) {
                Application.DoEvents();
            }
        }

        public static bool Collide(Point first, Point second, Size sec)
        {
            if (first.X > second.X && first.X < second.X + sec.Width && first.Y > second.Y && first.Y < second.Y + sec.Height)
                return true;
            return false;
        }
        public static bool Collide(Point pt, Rectangle rect)
        {
            if (pt.X > rect.Left && pt.X < rect.Right && pt.Y > rect.Top && pt.Y < rect.Bottom)
                return true;
            return false;
        }
        public static bool Collide(Point pt, Rectangle rect, Point shift)
        {
            if (pt.X > rect.Left + shift.X && pt.X < rect.Right + shift.X 
                    && pt.Y > rect.Top + shift.Y && pt.Y < rect.Bottom + shift.Y)
                return true;
            return false;
        }

        public static string GetFolderPath()
        {
            try {
                string folder = Path.Combine(Application.StartupPath, "Image/");
                Console.WriteLine(Application.StartupPath);
                if (!Directory.Exists(folder))
                    Directory.CreateDirectory(folder);
                return folder;
            }
            catch (Exception) { throw; }
        }

        public static string OpenFile()
        {
            OpenFileDialog file = new OpenFileDialog();
            DialogResult rst = file.ShowDialog();
            if ((int)rst != 1) return "";

            return file.FileName;
        }
    }

    public class ControlHelper
    {
        public static void SwapLocation(Control c1, Control c2)
        {
            Point tmp = c1.Location;
            c1.Location = c2.Location;
            c2.Location = tmp;
        }

        public static void SupplementLocation(Control.ControlCollection set, int del_idx)
        {
            int i = 0;
            int shift = (set[set.Count - 1].Location.Y - set[0].Location.Y) / set.Count;
            foreach (Control c in set) {
                if (i >= del_idx) {
                    c.Location = new Point(c.Location.X, c.Location.Y - shift);
                }
                i++;
            }
        }

        public static Label GetSpecifiedLabel(Panel parent, int Positon)
        {
            return ((Label)parent.Controls.Find("label" + Positon.ToString(), true)[0]);
        }

        public static TextBox GetSpecifiedTextBox(Panel parent, int Positon)
        {
            return ((TextBox)parent.Controls.Find("textBox" + Positon.ToString(), true)[0]);
        }

        public static Button GetSpecifiedButton(Panel parent, int Positon)
        {
            return ((Button)parent.Controls.Find("button" + Positon.ToString(), true)[0]);
        }
    }

    public class ValueHelper
    {
        private static ColorPalette grayPalette;

        static ValueHelper()
        {
            using (Bitmap bmp = new Bitmap(1, 1, PixelFormat.Format8bppIndexed))
            {
                grayPalette = bmp.Palette;
            }
            for (int i = 0; i < 256; i++)
            {
                grayPalette.Entries[i] = Color.FromArgb(i, i, i);
            }
        }

        private static Byte[] Reserve(Byte[] data)
        {
            for (int i = 1; i < data.Length; i = i + 2)
            {
                byte temp = data[i];
                data[i] = data[i - 1];
                data[i - 1] = temp;
            }
            return data;
        }

        public static void MoveList<T>(ref List<T> list, int index, int target)
        {
            var tmp = list[index];
            list.RemoveAt(index);
            list.Insert(target, tmp);
        }

        public static void SwapList<T>(ref List<T> list, int index1, int index2)
        {
            var tmp = list[index1];
            list[index1] = list[index2];
            list[index2] = tmp;
        }

        public static Byte[] GetBytes(short value)
        {
            return Reserve(BitConverter.GetBytes(value));
        }

        public static Byte[] GetBytes(int value)
        {
            return Reserve(BitConverter.GetBytes(value));
        }

        public static Byte[] GetBytes(uint value)
        {
            return Reserve(BitConverter.GetBytes(value));
        }

        public static Byte[] GetBytes(float value)
        {
            //return Reserve(BitConverter.GetBytes(value));
            return BitConverter.GetBytes(value);
        }

        public static Byte[] GetBytes(float[] values)
        {
            return values.SelectMany(x => GetBytes(x)).ToArray();
        }

        public static Byte[] GetBytes(int[] values)
        {
            return values.SelectMany(x => GetBytes(x)).ToArray();
        }

        public static short GetShort(byte[] data)
        {
            return BitConverter.ToInt16(Reserve(data), 0);
        }

        public static int GetInt(byte[] data)
        {
            return BitConverter.ToInt32(Reserve(data), 0);
        }

        public static float GetFloat(byte[] data)
        {
            return BitConverter.ToSingle(Reserve(data), 0);
        }

        public static float[] GetFloatArray(byte[] data, bool IsLittleEndian = false)
        {
            float[] res = new float[data.Length / 4];

            ////第一种方法，字节数组转换类转换，最容易想到和处理
            //// cass协议，小端
            if (IsLittleEndian)
            {
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = BitConverter.ToSingle(data, i * 4);
                }
            }

            ////第二种方法，缓存复制--最为简洁
            //Buffer.BlockCopy(data, 0, res, 0, data.Length);
            //第三种方法，字节转换处理方法，速度最快
            else
            {
                //unsafe
                //{
                //    for (int i = 0; i < res.Length; i++)
                //    {
                //        int tmp = data[i * 4 + 1] | data[i * 4] << 8 | data[i * 4 + 3] << 16 | data[i * 4 + 2] << 24;
                //        res[i] = *(float*)&tmp;
                //    }
                //}
            }
            return res;
        }

        public static float[] GetFloatArray(string str)
        {
            string[] values = str.Split(',');
            float[] res = new float[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                res[i] = float.Parse(values[i]);
            }
            return res;
        }

        public static bool[] GetBoolArray(string str)
        {
            string[] values = str.Split(',');
            bool[] res = new bool[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                res[i] = bool.Parse(values[i]);
            }
            return res;
        }

        public static int[] GetIntArray(string str)
        {
            string[] values = str.Split(',');
            int[] res = new int[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                res[i] = int.Parse(values[i]);
            }
            return res;
        }

        /// <summary>  
        /// 将一个字节数组转换为位图  
        /// </summary>  
        /// <param name="rawValues">显示字节数组</param>  
        /// <param name="width">图像宽度</param>  
        /// <param name="height">图像高度</param>
        /// <param name="channel">图像通道数</param>
        /// <returns>位图</returns>  
        public static Bitmap ToBitmap(byte[] rawValues, int width, int height, int channel)
        {
            Bitmap myBmp = null;
            if (channel == 1)
            {
                /*
                myBmp = new Bitmap(width, height, PixelFormat.Format8bppIndexed);
                BitmapData bmpdata = myBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, myBmp.PixelFormat);
                IntPtr ptr = bmpdata.Scan0;
                int offset = bmpdata.Stride - bmpdata.Width;
                int scanBytes = bmpdata.Stride * bmpdata.Height;
                byte[] gray = new byte[scanBytes];

                int posSrc = 0, posScan = 0;
                for (int i = 0; i < height; i++)
                {
                    Array.Copy(rawValues, posSrc, gray, posScan, width);
                    posSrc += width;
                    posScan += width + offset;
                }

                System.Runtime.InteropServices.Marshal.Copy(gray, 0, ptr, gray.Count());
                myBmp.UnlockBits(bmpdata);

                myBmp.Palette = grayPalette; 
                */
                myBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData bmpdata = myBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, myBmp.PixelFormat);

                int stride = bmpdata.Stride;
                int offset = stride - width * 3;
                IntPtr ptr = bmpdata.Scan0;
                int scanBytes = stride * height;
                int posScan = 0, posReal = 0;
                byte[] pixelVaues = new byte[scanBytes];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        pixelVaues[posScan + 0] = rawValues[posReal];
                        pixelVaues[posScan + 1] = rawValues[posReal];
                        pixelVaues[posScan + 2] = rawValues[posReal++];
                        posScan += 3;
                    }
                    posScan += offset;
                }
                System.Runtime.InteropServices.Marshal.Copy(pixelVaues, 0, ptr, scanBytes);
                myBmp.UnlockBits(bmpdata);
            }
            else if (channel == 3)
            {
                myBmp = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                BitmapData bmpdata = myBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, myBmp.PixelFormat);

                int stride = bmpdata.Stride;
                int offset = stride - width * 3;
                IntPtr ptr = bmpdata.Scan0;
                int scanBytes = stride * height;
                int posScan = 0, posReal = 0;
                byte[] pixelVaues = new byte[scanBytes];
                for(int i = 0; i < height; i++) {
                    for (int j = 0; j < width; j++) {
                        pixelVaues[posScan+0] = rawValues[posReal++];
                        pixelVaues[posScan+1] = rawValues[posReal++];
                        pixelVaues[posScan+2] = rawValues[posReal++];
                        posScan += 3;
                    }
                    posScan += offset;
                }
                System.Runtime.InteropServices.Marshal.Copy(pixelVaues, 0, ptr, scanBytes);
                myBmp.UnlockBits(bmpdata);
                /**/
                /*
                IntPtr ptr = bmpdata.Scan0;
                System.Runtime.InteropServices.Marshal.Copy(rawValues.ToArray(), 0, ptr, height * width * channel);
                myBmp.UnlockBits(bmpdata);
                /**/
            }
            else if (channel == 4) {
                myBmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
                BitmapData bmpdata = myBmp.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, myBmp.PixelFormat);
                IntPtr ptr = bmpdata.Scan0;
                int offset = bmpdata.Stride - bmpdata.Width;
                int scanBytes = bmpdata.Stride * bmpdata.Height;
                byte[] gray = new byte[scanBytes];

                int posSrc = 0, posScan = 0;
                for (int i = 0; i < height; i++) {
                    Array.Copy(rawValues, posSrc, gray, posScan, width);
                    posSrc += width;
                    posScan += width + offset;
                }
                System.Runtime.InteropServices.Marshal.Copy(rawValues.ToArray(), 0, ptr, height * width * channel);
                myBmp.UnlockBits(bmpdata);
            }
            return myBmp;
        }

        public static void RGB2HSV(byte r, byte g, byte b, ref int h, ref float s, ref float v)
        {
            float B = b * 1.0f / 255;
            float G = g * 1.0f / 255;
            float R = r * 1.0f / 255;
            float max = B;
            float min = B;
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
            if (max == min) {
                h = 0;
            }
            else if (maxindex == 2 && G >= B) {
                h = (int)(60 * (G - B) / (max - min));
            }
            else if (maxindex == 2 && G < B) {
                h = (int)(60 * (G - B) / (max - min) + 360);
            }
            else if (maxindex == 1) {
                h = (int)(60 * (B - R) / (max - min) + 120);
            }
            else if (maxindex == 0) {
                h = (int)(60 * (R - G) / (max - min) + 240);
            }

            if (max == 0)
                s = 0;
            else
                s = 1 - (min / max);

            v = max;
        }

        public static string ToString(float[] arr)
        {
            if (arr.Length == 0) return "";

            string res = arr[0].ToString();
            for (int i = 1; i < arr.Length; i++) res += "," + arr[i];
            return res;
        }

        public static string ToString(bool[] arr)
        {
            if (arr.Length == 0) return "";

            string res = arr[0].ToString();
            for (int i = 1; i < arr.Length; i++) res += "," + arr[i].ToString();
            return res;
        }
    }

}
