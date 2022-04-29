using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageTool
{
    public partial class ImageInfoHandle : Form
    {
        #region 变量

        Regex isNumber = new Regex("^[-]?[\\d]+$");//^[0-9]*$
        Regex isPositiveNumber = new Regex("^[\\d]+$");

        private float[] Red = { 1, 0, 0};
        private float[] Green = { 0, 1, 0 };
        private float[] Blue = { 0, 0, 1 };
        private float[] Constant = { 0, 0, 0 };
        private bool isChnSwitch = false;

        #endregion

        public ImageInfoHandle()
        {
            InitializeComponent();

            InitUI();
        }

        private void InitUI()
        {
            comboBox_OutputChannel.SelectedIndex = 0;
        }

        private void tabControl_ImageInfoHandle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_ImageInfoHandle.SelectedIndex == 2) {
                correctThreshold?.Invoke(127);
            } else {
                backToPrimary?.Invoke();
            }
        }

        #region 调整亮度/对比度
        public event BrightAndContrastHandler correctBrightAndContrast;
        public delegate void BrightAndContrastHandler(float alpha, float beta);

        private void trackBar_Bright_Scroll(object sender, EventArgs e)
        {
            int beta = trackBar_Bright.Value - 100;
            textBox_Bright.Text = beta.ToString();
        }

        private void trackBar_Contrast_Scroll(object sender, EventArgs e)
        {
            int alpha = trackBar_Contrast.Value - 100;
            textBox_Contrast.Text = alpha.ToString();
        }

        private void textBox_Bright_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Bright.Text) && !string.IsNullOrEmpty(textBox_Bright.Text)) {
                float alpha = float.Parse(textBox_Contrast.Text) / 100;
                float beta = float.Parse(textBox_Bright.Text);
                if (beta < -100)
                    beta = -100.0f;
                else if (beta > 100)
                    beta = 100.0f;

                trackBar_Bright.Value = (int)beta + 100;

                correctBrightAndContrast?.Invoke(alpha, beta);
            }
        }

        private void textBox_Contrast_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Contrast.Text) && !string.IsNullOrEmpty(textBox_Contrast.Text)) {
                float alpha = float.Parse(textBox_Contrast.Text) / 100;
                float beta = float.Parse(textBox_Bright.Text);
                if (alpha < -1)
                    alpha = -1.0f;
                else if (alpha > 1)
                    alpha = 1.0f;

                trackBar_Contrast.Value = (int)(alpha * 100) + 100;

                correctBrightAndContrast?.Invoke(alpha, beta);
            }
        }

        #endregion

        #region 色相/饱和度
        public event HSLHandler correctHSL;
        public delegate void HSLHandler(int h, int s, int l);
        private void trackBar_Hue_Scroll(object sender, EventArgs e)
        {
            int h = trackBar_Hue.Value - 180;
            textBox_Hue.Text = h.ToString();
        }

        private void trackBar_Saturation_Scroll(object sender, EventArgs e)
        {
            int s = trackBar_Saturation.Value - 100;
            textBox_Saturation.Text = s.ToString();
        }

        private void trackBar_Lightness_Scroll(object sender, EventArgs e)
        {
            int l = trackBar_Lightness.Value - 100;
            textBox_Lightness.Text = l.ToString();
        }

        private void textBox_Hue_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Hue.Text) && !string.IsNullOrEmpty(textBox_Hue.Text)) {
                int h = int.Parse(textBox_Hue.Text);
                int s = int.Parse(textBox_Saturation.Text);
                int l = int.Parse(textBox_Lightness.Text);
                if (h < -180)
                    h = -180;
                else if (h > 180)
                    h = 180;

                trackBar_Hue.Value = h + 180;

                correctHSL?.Invoke(h, s, l);
            }
        }

        private void textBox_Saturation_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Saturation.Text) && !string.IsNullOrEmpty(textBox_Saturation.Text)) {
                int h = int.Parse(textBox_Hue.Text);
                int s = int.Parse(textBox_Saturation.Text);
                int l = int.Parse(textBox_Lightness.Text);
                if (s < -100)
                    s = -100;
                else if (s > 100)
                    s = 100;

                trackBar_Saturation.Value = s + 100;

                correctHSL?.Invoke(h, s, l);
            }
        }

        private void textBox_Lightness_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Lightness.Text) && !string.IsNullOrEmpty(textBox_Lightness.Text)) {
                int h = int.Parse(textBox_Hue.Text);
                int s = int.Parse(textBox_Saturation.Text);
                int l = int.Parse(textBox_Lightness.Text);
                if (l < -100)
                    l = -100;
                else if (l > 100)
                    l = 100;

                trackBar_Lightness.Value = l + 100;

                correctHSL?.Invoke(h, s, l);
            }
        }

        #endregion

        #region 调整阈值
        public event ThresholdHandler correctThreshold;
        public delegate void ThresholdHandler(float thres);

        private void trackBar_Threshold_Scroll(object sender, EventArgs e)
        {
            int thres = trackBar_Threshold.Value;
            textBox_Threshold.Text = (thres + 1).ToString();
        }

        private void textBox_Threshold_TextChanged(object sender, EventArgs e)
        {
            if (isPositiveNumber.IsMatch(textBox_Threshold.Text) && !string.IsNullOrEmpty(textBox_Threshold.Text)) {
                int thres = int.Parse(textBox_Threshold.Text);
                if (thres < 1)
                    thres = 1;
                else if (thres > 255)
                    thres = 255;

                trackBar_Threshold.Value = thres-1;

                correctThreshold?.Invoke(thres-1);
            }
        }

        public void receiveHistogram(int[] hist)
        {
            List<int> x = new List<int> { };
            List<int> y = new List<int> { };
            for (int i = 0; i < 256; i++) {
                x.Add(i);
                y.Add(hist[i]);
            }
            chart_Threshold.Series[0].Points.DataBindXY(x, y);
        }

        #endregion

        #region 反相
        public event ContrastImageHandler correctContrastImage;
        public delegate void ContrastImageHandler();
        private void button_ContrastImage_Click(object sender, EventArgs e)
        {
            correctContrastImage?.Invoke();
        }

        #endregion

        #region 通道混合器
        public event ChannelComminglerHandler correctChannelCommingler;
        public delegate void ChannelComminglerHandler(float[] red, float[] green, float[] blue, float[] constant, bool single);

        private void checkBox_SingleColor_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SingleColor.Checked) {
                comboBox_OutputChannel.Items.Clear();
                comboBox_OutputChannel.Items.Add("灰色");
                comboBox_OutputChannel.SelectedIndex = 0;
                correctChannelCommingler?.Invoke(Red, Green, Blue, Constant, true);
            }
            else {
                comboBox_OutputChannel.Items.Clear();
                comboBox_OutputChannel.Items.Add("红");
                comboBox_OutputChannel.Items.Add("绿");
                comboBox_OutputChannel.Items.Add("蓝");
                comboBox_OutputChannel.SelectedIndex = 0;
            }
        }

        private void comboBox_OutputChannel_SelectedValueChanged(object sender, EventArgs e)
        {
            isChnSwitch = true;
            int index = comboBox_OutputChannel.SelectedIndex;
            textBox_Red.Text = ((int)(Red[index]*100)).ToString();
            textBox_Green.Text = ((int)(Green[index] * 100)).ToString();
            textBox_Blue.Text = ((int)(Blue[index] * 100)).ToString();
            textBox_Const.Text = ((int)(Constant[index] * 100)).ToString();
            trackBar_Red.Value = (int)(Red[index] * 100) + 200;
            trackBar_Green.Value = (int)(Green[index] * 100) + 200;
            trackBar_Blue.Value = (int)(Blue[index] * 100) + 200;
            trackBar_Const.Value = (int)(Constant[index] * 100) + 200;
            isChnSwitch = false;
        }

        private void trackBar_Red_Scroll(object sender, EventArgs e)
        {
            textBox_Red.Text = (trackBar_Red.Value - 200).ToString();
        }

        private void trackBar_Green_Scroll(object sender, EventArgs e)
        {
            textBox_Green.Text = (trackBar_Green.Value - 200).ToString();
        }

        private void trackBar_Blue_Scroll(object sender, EventArgs e)
        {
            textBox_Blue.Text = (trackBar_Blue.Value - 200).ToString();
        }

        private void trackBar_Const_Scroll(object sender, EventArgs e)
        {
            textBox_Const.Text = (trackBar_Const.Value - 200).ToString();
        }

        private void textBox_Red_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Red.Text) && !string.IsNullOrEmpty(textBox_Red.Text)
                    && !isChnSwitch) {
                int red = int.Parse(textBox_Red.Text);
                int blue = int.Parse(textBox_Blue.Text);
                int green = int.Parse(textBox_Green.Text);
                int constNum = int.Parse(textBox_Const.Text);
                if (red < -200)
                    red = -200;
                else if (red > 200)
                    red = 200;
                trackBar_Red.Value = red + 200;

                if (comboBox_OutputChannel.SelectedIndex == 0) {
                    Red[0] = red / 100.0f;
                    Green[0] = green / 100.0f;
                    Blue[0] = blue / 100.0f;
                    Constant[0] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 1) {
                    Red[1] = red / 100.0f;
                    Green[1] = green / 100.0f;
                    Blue[1] = blue / 100.0f;
                    Constant[1] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 2) {
                    Red[2] = red / 100.0f;
                    Green[2] = green / 100.0f;
                    Blue[2] = blue / 100.0f;
                    Constant[2] = constNum / 100.0f;
                }

                correctChannelCommingler?.Invoke(Red, Green, Blue, Constant, checkBox_SingleColor.Checked);
            }
        }

        private void textBox_Green_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Green.Text) && !string.IsNullOrEmpty(textBox_Green.Text)
                    && !isChnSwitch) {
                int red = int.Parse(textBox_Red.Text);
                int blue = int.Parse(textBox_Blue.Text);
                int green = int.Parse(textBox_Green.Text);
                int constNum = int.Parse(textBox_Const.Text);
                if (green < -200)
                    green = -200;
                else if (green > 200)
                    green = 200;

                trackBar_Green.Value = green + 200;

                if (comboBox_OutputChannel.SelectedIndex == 0) {
                    Red[0] = red / 100.0f;
                    Green[0] = green / 100.0f;
                    Blue[0] = blue / 100.0f;
                    Constant[0] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 1) {
                    Red[1] = red / 100.0f;
                    Green[1] = green / 100.0f;
                    Blue[1] = blue / 100.0f;
                    Constant[1] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 2) {
                    Red[2] = red / 100.0f;
                    Green[2] = green / 100.0f;
                    Blue[2] = blue / 100.0f;
                    Constant[2] = constNum / 100.0f;
                }

                correctChannelCommingler?.Invoke(Red, Green, Blue, Constant, checkBox_SingleColor.Checked);
            }
        }

        private void textBox_Blue_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Blue.Text) && !string.IsNullOrEmpty(textBox_Blue.Text)
                    && !isChnSwitch) {
                int red = int.Parse(textBox_Red.Text);
                int blue = int.Parse(textBox_Blue.Text);
                int green = int.Parse(textBox_Green.Text);
                int constNum = int.Parse(textBox_Const.Text);
                if (blue < -200)
                    blue = -200;
                else if (blue > 200)
                    blue = 200;

                trackBar_Blue.Value = blue + 200;

                if (comboBox_OutputChannel.SelectedIndex == 0) {
                    Red[0] = red / 100.0f;
                    Green[0] = green / 100.0f;
                    Blue[0] = blue / 100.0f;
                    Constant[0] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 1) {
                    Red[1] = red / 100.0f;
                    Green[1] = green / 100.0f;
                    Blue[1] = blue / 100.0f;
                    Constant[1] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 2) {
                    Red[2] = red / 100.0f;
                    Green[2] = green / 100.0f;
                    Blue[2] = blue / 100.0f;
                    Constant[2] = constNum / 100.0f;
                }

                correctChannelCommingler?.Invoke(Red, Green, Blue, Constant, checkBox_SingleColor.Checked);
            }
        }

        private void textBox_Const_TextChanged(object sender, EventArgs e)
        {
            if (isNumber.IsMatch(textBox_Const.Text) && !string.IsNullOrEmpty(textBox_Const.Text)) {
                int red = int.Parse(textBox_Red.Text);
                int blue = int.Parse(textBox_Blue.Text);
                int green = int.Parse(textBox_Green.Text);
                int constNum = int.Parse(textBox_Const.Text);
                if (constNum < -200)
                    constNum = -200;
                else if (constNum > 200)
                    constNum = 200;

                trackBar_Const.Value = constNum + 200;

                if (comboBox_OutputChannel.SelectedIndex == 0) {
                    Red[0] = red / 100.0f;
                    Green[0] = green / 100.0f;
                    Blue[0] = blue / 100.0f;
                    Constant[0] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 1) {
                    Red[1] = red / 100.0f;
                    Green[1] = green / 100.0f;
                    Blue[1] = blue / 100.0f;
                    Constant[1] = constNum / 100.0f;
                }
                else if (comboBox_OutputChannel.SelectedIndex == 2) {
                    Red[2] = red / 100.0f;
                    Green[2] = green / 100.0f;
                    Blue[2] = blue / 100.0f;
                    Constant[2] = constNum / 100.0f;
                }

                correctChannelCommingler?.Invoke(Red, Green, Blue, Constant, checkBox_SingleColor.Checked);
            }
        }

        #endregion

        #region HSV过滤
        public event UpdateHSVHandler updateHSVInfo;
        public delegate void UpdateHSVHandler(float lowH, float highH, float lowS, float highS, float lowV, float highV);
        public event HSVFilterHandler correctHSV;
        public delegate void HSVFilterHandler(float hl, float h, float sl, float s, float vl, float v);
        public event BtnSetHSVHandler SetHSV_Click;
        public delegate void BtnSetHSVHandler(float hl, float h, float sl, float s, float vl, float v);
        private void trackBar_Hl_Scroll(object sender, EventArgs e)
        {
            if (trackBar_Hl.Value > trackBar_H.Value)
                trackBar_Hl.Value = trackBar_H.Value - 1;
        }
        private void trackBar_H_Scroll(object sender, EventArgs e)
        {
            if (trackBar_H.Value < trackBar_Hl.Value)
                trackBar_H.Value = trackBar_Hl.Value + 1;
        }
        private void trackBar_Sl_Scroll(object sender, EventArgs e)
        {
            if (trackBar_Sl.Value > trackBar_S.Value)
                trackBar_Sl.Value = trackBar_S.Value - 1;
        }
        private void trackBar_S_Scroll(object sender, EventArgs e)
        {
            if (trackBar_S.Value < trackBar_Sl.Value)
                trackBar_S.Value = trackBar_Sl.Value + 1;
        }

        private void trackBar_Vl_Scroll(object sender, EventArgs e)
        {
            if (trackBar_Vl.Value > trackBar_V.Value)
                trackBar_Vl.Value = trackBar_V.Value - 1;
        }
        private void trackBar_V_Scroll(object sender, EventArgs e)
        {
            if (trackBar_V.Value < trackBar_Vl.Value)
                trackBar_V.Value = trackBar_Vl.Value + 1;
        }

        private void trackBar_Hl_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }
        private void trackBar_H_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }
        private void trackBar_Sl_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }
        private void trackBar_S_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }
        private void trackBar_Vl_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }
        private void trackBar_V_ValueChanged(object sender, EventArgs e)
        {
            float h = trackBar_H.Value / 1000.0f * 360;
            float s = trackBar_S.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            updateHSVInfo?.Invoke(hl, h, sl, s, vl, v);
            correctHSV?.Invoke(hl, h, sl, s, vl, v);
        }

        private void button_ResetHSV_Click(object sender, EventArgs e)
        {
            trackBar_Hl.Value = 0;
            trackBar_H.Value = 1000;
            trackBar_Sl.Value = 0;
            trackBar_S.Value = 1000;
            trackBar_Vl.Value = 0;
            trackBar_V.Value = 1000;
        }

        private void button_SetHSV_Click(object sender, EventArgs e)
        {
            float hl = trackBar_Hl.Value / 1000.0f * 360;
            float h = trackBar_H.Value / 1000.0f * 360;
            float sl = trackBar_Sl.Value / 1000.0f;
            float s = trackBar_S.Value / 1000.0f;
            float vl = trackBar_Vl.Value / 1000.0f;
            float v = trackBar_V.Value / 1000.0f;
            SetHSV_Click?.Invoke(hl, h, sl, s, vl, v);
        }

        #endregion

        // 保存操作后的图片至内存
        public event SaveHandler saveToInput;
        public delegate void SaveHandler();
        private void button_Save_Click(object sender, EventArgs e)
        {
            saveToInput?.Invoke();
        }

        // 重写关闭事件，防止窗体对象被释放
        public event PrimaryHandler backToPrimary;
        public delegate void PrimaryHandler();
        private void ImageInfoHandle_FormClosing(object sender, FormClosingEventArgs e)
        {
            textBox_Bright.Text = 0.ToString();
            textBox_Contrast.Text = 0.ToString();

            textBox_Hue.Text = 0.ToString();
            textBox_Saturation.Text = 0.ToString();
            textBox_Lightness.Text = 0.ToString();

            textBox_Threshold.Text = 128.ToString();

            Red[0] = 1; Red[1] = 0; Red[2] = 0;
            Green[0] = 0; Green[1] = 1; Green[2] = 0;
            Blue[0] = 0; Blue[1] = 0; Blue[2] = 1;
            Constant[0] = 0; Constant[1] = 0; Constant[2] = 0;
            checkBox_SingleColor.Checked = false;

            Invoke(new Action(()=>{ button_ResetHSV_Click(sender, e); }));

            backToPrimary?.Invoke();

            e.Cancel = true;
            Hide();
        }


    }
}
