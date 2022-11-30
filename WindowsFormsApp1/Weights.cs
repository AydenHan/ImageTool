using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections.Generic;

namespace ImageTool
{
    public partial class MoveButton : Button
    {
        private Button BTN;
        private Button UP;
        private Button DOWN;
        private Button DEL;

        public override string Text
        {
            get => BTN.Text;
            set
            {
                BTN.Text = value;
            }
        }

        public MoveButton(Point loc, Size size, double btn, double up, double down, double del)
        {
            Size = size;
            Location = loc;

            BTN = new Button();
            UP = new Button();
            DOWN = new Button();
            DEL = new Button();

            BTN.Size = new Size((int)(Size.Width * btn), Size.Height);
            UP.Size = new Size((int)(Size.Width * up), Size.Height);
            DOWN.Size = new Size((int)(Size.Width * down), Size.Height);
            DEL.Size = new Size((int)(Size.Width * del), Size.Height);

            BTN.Location = new Point(0, 0);
            UP.Location = new Point(BTN.Width, 0);
            DOWN.Location = new Point(UP.Location.X + UP.Width, 0);
            DEL.Location = new Point(DOWN.Location.X + DOWN.Width, 0);

            UP.Text = "↑";
            DOWN.Text = "↓";
            DEL.Text = "X";

            Controls.Add(BTN);
            Controls.Add(UP);
            Controls.Add(DOWN);
            Controls.Add(DEL);
        }
        public MoveButton(Point loc, Size size, double btn, double func)
        {
            Size = size;
            Location = loc;

            BTN = new Button();
            UP = new Button();
            DOWN = new Button();
            DEL = new Button();

            BTN.Size = new Size((int)(Size.Width * btn), Size.Height);
            UP.Size = new Size((int)(Size.Width * func), Size.Height);
            DOWN.Size = new Size((int)(Size.Width * func), Size.Height);
            DEL.Size = new Size((int)(Size.Width * func), Size.Height);

            BTN.Location = new Point(0, 0);
            UP.Location = new Point(BTN.Width, 0);
            DOWN.Location = new Point(UP.Location.X + UP.Width, 0);
            DEL.Location = new Point(DOWN.Location.X + DOWN.Width, 0);

            UP.Text = "↑";
            DOWN.Text = "↓";
            DEL.Text = "X";

            Controls.Add(BTN);
            Controls.Add(UP);
            Controls.Add(DOWN);
            Controls.Add(DEL);
        }

        public void EventBindings(EventHandler btn, EventHandler up, EventHandler down, EventHandler del)
        {
            BTN.Click += btn;
            UP.Click += up;
            DOWN.Click += down;
            DEL.Click += del;
        }
    }
}