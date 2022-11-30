using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length == 1)
            {
                using (Image_Form img = new Image_Form())
                {
                    img.sourcePath = args[0];
                    Application.Run(img);
                }
            }
            else
            {
                Application.Run(new Image_Form());
            }
        }
    }
}
