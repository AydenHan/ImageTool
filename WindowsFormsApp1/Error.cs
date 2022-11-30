using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace ImageTool
{
    public enum ErrorInfo
    {
        RUN                         = 0x0000,       // 正常

        // 0x00 启动问题
        REGISTER_ADD_FAILED         = 0x0001,       // 注册表添加失败
        DLL_LOAD_FAILED             = 0x0002,       // DLL加载失败
        IMAGE_OPEN_FAILED           = 0x0003,       // 图片打开失败
        //IMAGE_SAVE_MEMORY_FAILED    = 0x0004,       // 图片写入内存失败

        // 0x01 操作问题
        IMAGE_PATH_ERROR            = 0x0101,       // 图片打开路径错误
        IMAGE_HANDLE_ERROR          = 0x0102,       // 图像处理错误
        DATA_PASTE_ERROR            = 0x0103,       // 剪切板粘贴错误
        IMAGE_NOEXIST_ERROR         = 0x0104,       // 图片未打开
        PTS_DATA_ERROR              = 0x0105,       // 画点点集格式错误
        CANVAS_DATA_ERROR           = 0x0106,       // 绘制画布参数错误

        // 0x02 提示
        ASML_HANDLE_TIPS = 0x0201,       // 流水线操作提示
    }

    public class Error
    {
        public ToolStripLabel PrintCtrl;

        private int MilliSecond = 3000;
        private Dictionary<int, string> ErrorMessage = new Dictionary<int, string> { };
        public int Code;

        public Error() { }
        public Error(int ms) {
            MilliSecond = ms;
        }

        public void Init()
        {
            ErrorMessage.Add((int)ErrorInfo.RUN, "");
            ErrorMessage.Add((int)ErrorInfo.REGISTER_ADD_FAILED, 
                                "注册表添加失败，请以管理员身份重新启动");
            ErrorMessage.Add((int)ErrorInfo.DLL_LOAD_FAILED,
                                "DLL加载失败，请确认是否正确下载相关依赖");
            ErrorMessage.Add((int)ErrorInfo.IMAGE_OPEN_FAILED,
                                "图片打开失败，请确认图片文件是否损坏");
            //ErrorMessage.Add((int)ErrorInfo.IMAGE_SAVE_MEMORY_FAILED,
            //                    "图片写入内存失败，请确认图片文件是否损坏。");

            ErrorMessage.Add((int)ErrorInfo.IMAGE_PATH_ERROR,
                                "图片路径错误，路径不能为空");
            ErrorMessage.Add((int)ErrorInfo.IMAGE_HANDLE_ERROR,
                                "图像处理错误，请自行排查问题");
            ErrorMessage.Add((int)ErrorInfo.DATA_PASTE_ERROR,
                                "剪切板粘贴错误，请检查剪切板数据格式");
            ErrorMessage.Add((int)ErrorInfo.IMAGE_NOEXIST_ERROR,
                                "图片不存在，请先打开图片");
            ErrorMessage.Add((int)ErrorInfo.PTS_DATA_ERROR,
                                "点集格式错误，请检查输入项");
            ErrorMessage.Add((int)ErrorInfo.CANVAS_DATA_ERROR,
                                "绘制画布参数错误，请检查输入项");

            ErrorMessage.Add((int)ErrorInfo.ASML_HANDLE_TIPS,
                                "拖动按钮调整流水线顺序，向左拖出一定距离删除。");
        }

        public void Print(ErrorInfo errorCode, string text = "", int time = -1)
        {
            string temp = PrintCtrl.Text;
            Code = (int)errorCode;
            time = time == -1 ? MilliSecond : time;

            PrintCtrl.Text = ErrorMessage[Code]
                        + (String.IsNullOrEmpty(text) ? "" : "(" + text + ")");

            int start = Environment.TickCount;
            while (Math.Abs(Environment.TickCount - start) < time)
            {
                Application.DoEvents();
            }
            PrintCtrl.Text = temp;
        }

        public void Tip(ErrorInfo errorCode, string text = "")
        {
            Code = (int)errorCode;

            PrintCtrl.Text = "Tips: " + ErrorMessage[Code]
                        + (String.IsNullOrEmpty(text) ? "" : "(" + text + ")");
        }

        public void MsgBox(ErrorInfo errorCode, string text = "")
        {
            Code = (int)errorCode;

            MessageBox.Show(ErrorMessage[Code]
                        + (String.IsNullOrEmpty(text) ? "" : " ( " + text + " )"));
        }
    }
}
