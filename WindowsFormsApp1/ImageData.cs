using System;
using System.Windows.Forms;

namespace ImageTool
{
    public class ImageInfo
    {
        public static ImageData NewData()
        {
            BaseImageData template = MyImageData.template;
            return template.NewData();
        }
    }

    public class ImageStorage
    {
        private ImageData image;
        public int IO { get; set; }
        public int index { get; set; }
        public ImageData img {
            get => image;
            set {
                if (value != image) WhenValueChanged();
                image = value;
            }
        }

        public delegate void ValueChanged(object sender, EventArgs e);
        public event ValueChanged OnValueChanged;
        private void WhenValueChanged()
        {
            OnValueChanged(this, null);
        }
    }

    public interface ImageData
    {
        byte[] Data { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Channel { get; set; }

        ImageData NewData();
        int WriteInMemory(byte[] d, int[] w, int[] h, int[] c);
        int UpdateInfo(Panel ctrl, int position);
        void EmptyData();
    }

    public abstract class BaseImageData : ImageData
    {
        public byte[] data;
        public int width;
        public int height;
        public int channel;

        public byte[] Data
        {
            get => data;
            set
            {
                data = value;
            }
        }
        public abstract int Width { get; set; }
        public abstract int Height { get; set; }
        public abstract int Channel { get; set; }

        // 构造器
        public BaseImageData()
        {
            
        }
        public abstract ImageData NewData();
        public abstract int WriteInMemory(byte[] d, int[] w, int[] h, int[] c);
        public abstract int UpdateInfo(Panel ctrl, int position);
        public abstract void EmptyData();
    }

    public class MyImageData : BaseImageData
    {
        public static readonly MyImageData template = new MyImageData();

        public override int Width
        {
            get => width;
            set => width = value;
        }

        public override int Height
        {
            get => height;
            set => height = value;
        }

        public override int Channel
        {
            get => channel;
            set => channel = value;
        }

        public override ImageData NewData()
        {
            return new MyImageData();
        }
        public override int WriteInMemory(byte[] d, int[] w, int[] h, int[] c)
        {
            data = d;
            width = w[0];
            height = h[0];
            channel = c[0];

            return 1;
        }

        public override int UpdateInfo(Panel ctrl, int position)
        {
            ((TextBox)ctrl.Controls.Find("textBox" + (position).ToString(), true)[0]).Text = Data.ToString();
            ((TextBox)ctrl.Controls.Find("textBox" + (position + 1).ToString(), true)[0]).Text = Width.ToString();
            ((TextBox)ctrl.Controls.Find("textBox" + (position + 2).ToString(), true)[0]).Text = Height.ToString();
            ((TextBox)ctrl.Controls.Find("textBox" + (position + 3).ToString(), true)[0]).Text = Channel.ToString();

            return 1;
        }

        public override void EmptyData()
        {
            
        }
    }
}
