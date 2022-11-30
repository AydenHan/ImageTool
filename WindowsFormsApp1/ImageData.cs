using System;
using System.Windows.Forms;

namespace ImageTool
{
    public class ImageStorage
    {
        private ImageData image = null;
        public int IO { get; set; }
        public int index { get; set; }
        public ImageData img {
            get => image;
            set {
                if (value != image) WhenValueChanged(value);
                image = value;
            }
        }

        public delegate void ValueChanged(object sender, ImageData val);
        public event ValueChanged OnValueChanged;
        private void WhenValueChanged(ImageData val)
        {
            OnValueChanged(this, val);
        }
    }

    public class ImageData
    {
        public byte[] Data { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Channel { get; set; }

        public ImageData() { }
        public ImageData(byte[] d, int[] w, int[] h, int[] c)
        {
            Data = d;
            Width = w[0];
            Height = h[0];
            Channel = c[0];
        }
        public ImageData(int w, int h, int c, int r = 255, int g = 255, int b = 255)
        {
            Width = w;
            Height = h;
            Channel = c;
            int length = w * h * c;
            Data = new byte[length];
            if (c == 1) {
                for (int i = 0; i < length; ++i)
                    Data[i] = (byte)r;
            }
            else {
                for (int i = 0; i < length; ++i) {
                    Data[i] = (byte)r;
                    Data[++i] = (byte)g;
                    Data[++i] = (byte)b;
                }
            }
        }

        public void WriteInMemory(byte[] d, int[] w, int[] h, int[] c)
        {
            Data = d;
            Width = w[0];
            Height = h[0];
            Channel = c[0];
        }
    }
}
