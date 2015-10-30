using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrintPage
{
    public partial class Form1 : Form
    {
        bool isdown;//鼠标左键是否按下
        Point mousepos;//鼠标位置
        private string[] fontFamilyNames;

        int y = 0;
        int x = 0;
        int index = 1;

        //Label lab = new Label();

        private string InfoPath;
        private string ModelPath;

        private string[,] Prm;

        public string id = null;

        public Form1()
        {
            InitializeComponent();
            GetFontFamilies();
            ts_addItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            //窗体自身支持接受拖拽来的控件
        }

        private void GetFontFamilies()
        {
            Graphics g = CreateGraphics();
            FontFamily[] ffs = FontFamily.Families;
            fontFamilyNames = new string[ffs.Length];
            for (int i = 0; i < ffs.Length; i++)
            {
                fontFamilyNames[i] = ffs[i].Name;
                //tSComboBoxFont.Items.Add(fontFamilyNames[i]);  // 逐个添加字体
            }
            tf.Items.AddRange(fontFamilyNames);      //一次性添加所有字体
        }

        private void ts_addItems()
        {
            for (int i = 0; i <= 50; i++)
            {
                ts.Items.Add(i.ToString());
            }
        }

        private void AddLabel(string labName)
        {
            Label lab = new Label();
            lab.AutoSize = true;
            //lab.Height = 30;
            //lab.Dock = DockStyle.Top;
            lab.Name = labName;
            lab.Text = labName;
            lab.Click += Label_Click;
            panel1.Controls.Add(lab);
        }

        private string[,] GetModelExcel()                                              //读入Excel内容
        {
            string[,] Prm;
            DataSet myDataSet;
            ModelPath = Properties.Settings.Default.ModelPathSetting;
            string path = ModelPath + "/";
            string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + path + "Model.xls;Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";    //创建一个数据链接
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$] ";
            try
            {
                myConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);                  //打开数据链接，得到一个数据集
                myDataSet = new DataSet();                                                          //创建一个 DataSet对象
                myCommand.Fill(myDataSet, "[Sheet1$]");                                             //得到自己的DataSet对象
                myConn.Close();                                                                     //关闭此数据链接

                Prm = new string[myDataSet.Tables[0].Rows.Count, 5];

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)                            //读取Sheet1里的配置信息
                {
                    Prm[i, 0] = myDataSet.Tables[0].Rows[i].ItemArray[0].ToString();            //配置物料的名称
                    Prm[i, 1] = myDataSet.Tables[0].Rows[i].ItemArray[1].ToString();            //配置物料的ID号
                    Prm[i, 2] = myDataSet.Tables[0].Rows[i].ItemArray[2].ToString();            //配置物料第一命令地址
                    Prm[i, 3] = myDataSet.Tables[0].Rows[i].ItemArray[3].ToString();            //配置物料第二命令地址
                    Prm[i, 4] = myDataSet.Tables[0].Rows[i].ItemArray[4].ToString();            //配置物料第三命令地址
                }
                return Prm;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private string[] GetAreaExcel(string target)                                              //读入Excel内容
        {
            DataSet myDataSet;
            int index = 0;
            int findit = 0;
            string[] Prm;
            InfoPath = Properties.Settings.Default.InfoPathSetting;
            string path = InfoPath + "/";
            string strCon = " Provider = Microsoft.Jet.OLEDB.4.0 ; Data Source = " + path + "AREA.xls; Extended Properties='Excel 8.0;HDR=NO;IMEX=1;'";    //创建一个数据链接
            OleDbConnection myConn = new OleDbConnection(strCon);
            string strCom = " SELECT * FROM [Sheet1$] ";
            try
            {
                myConn.Open();
                OleDbDataAdapter myCommand = new OleDbDataAdapter(strCom, myConn);                  //打开数据链接，得到一个数据集
                myDataSet = new DataSet();                                                          //创建一个 DataSet对象
                myCommand.Fill(myDataSet, "[Sheet1$]");                                             //得到自己的DataSet对象
                myConn.Close();                                                                     //关闭此数据链接

                Prm = new string[myDataSet.Tables[0].Columns.Count];

                for (int i = 0; i < myDataSet.Tables[0].Rows.Count; i++)
                {
                    if (target == myDataSet.Tables[0].Rows[i].ItemArray[1].ToString())              //获取要打印的ID号所在的行号
                    {
                        index = i;
                        findit = 1;
                        break;
                    }
                }

                if (findit != 0)
                {
                    for (int i = 0; i < myDataSet.Tables[0].Columns.Count; i++)                         //获取ID对应的所有需要打印的信息
                    {
                        Prm[i] = myDataSet.Tables[0].Rows[index].ItemArray[i].ToString();
                    }
                    return Prm;
                }
                else
                {
                    MessageBox.Show("未找到对应ID的标签！！");
                    return null;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }

        private void Label_Click(object sender, EventArgs e)
        {
            var label = (Label)sender;
            foreach (Label lb in panel1.Controls) lb.BackColor = lb == label ? Color.Green : Color.White;
            tf.Tag = label;
            ts.Tag = label;
            label.MouseDown += label_MouseDown;
            label.MouseMove += label_MouseMove;
            label.MouseUp += label_MouseUp;
        }

        private void button1_Click(object sender, EventArgs e)  //输入ID
        {
            //AddLabel("area"+index);
            //index++;
            string[] Prm1;

            IDlogin ID = new IDlogin();
            ID.GetForm(this);
            ID.ShowDialog();
            Prm1 = GetAreaExcel(id);
            if (Prm1 != null)
            {
                Prm = GetModelExcel();

                for (int i = 0; i < Prm.Length / 5; i++)
                {
                    string a=Prm[i, 0].Trim().Substring(4);
                    int.Parse(a);
                    Prm[i, 0] = Prm[i, 0].Replace(Prm[i, 0],Prm1[int.Parse(Prm[i, 0].Trim().Substring(4))-1]);
                }

                Image im = new Bitmap(panel1.Width, this.panel1.Height);
                Graphics g = Graphics.FromImage(im);

                for (int i = 0; i < Prm.Length / 5; i++)
                {
                    Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Bold);
                    g.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 3) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
                }

                Barcode bar = new Barcode();
                g.ScaleTransform(1, 0.54f);
                g.DrawImage(RotateImg(bar.GetBarCode(Prm1[2]), 90), 275.0F, 220.0F);

                //g.ScaleTransform(1, 1.9f);

                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.BackgroundImage = im;
            }
            else MessageBox.Show("id号输入不正确！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //panel1.Controls.Remove(lab);
        }

        private void label_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isdown = true;//鼠标按下
            }
        }

        private void label_MouseMove(object sender, MouseEventArgs e)
        {
            if (tf.Tag == null) return;
            var label = (Label)tf.Tag;
            if (isdown)
            {
                mousepos.Offset(e.X, e.Y);
                label.Location = mousepos;//label控件的位置
            }
        }

        private void label_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                isdown = false;//释放鼠标左键
        }

        private void tf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tf.Tag == null) return;
            var label = (Label)tf.Tag;
            var font = new Font(tf.SelectedItem.ToString(), label.Font.Size);
            label.Font = font;
        }

        private void ts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ts.Tag == null) return;
            var label = (Label)ts.Tag;
            var font = new Font(label.Font.FontFamily, float.Parse(ts.SelectedItem.ToString()));
            label.Font = font;
        }

        private void 模板路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择标签内容表格所在路径";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                ModelPath = folderBrowserDialog.SelectedPath;
            }
            Properties.Settings.Default.ModelPathSetting = ModelPath;
            Properties.Settings.Default.Save();
        }

        private void 标签内容表格路径设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "请选择标签内容表格所在路径";
            DialogResult result = folderBrowserDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                InfoPath = folderBrowserDialog.SelectedPath;
            }
            Properties.Settings.Default.InfoPathSetting = InfoPath;
            Properties.Settings.Default.Save();
        }

        private void 打开OToolStripButton1_Click(object sender, EventArgs e)
        {
            //string[,] Prm;
            //openFileDialog1.Title = "打开文件...";
            //openFileDialog1.Filter = "富格式文件(*.rtf)|*.rtf|文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            //openFileDialog1.FilterIndex = 1;
            //openFileDialog1.InitialDirectory = "桌面";
            //openFileDialog1.ShowReadOnly = true;
            //openFileDialog1.ReadOnlyChecked = false;
            //openFileDialog1.FileName = "";

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    int i = 0;
            //    Text = openFileDialog1.FileName;
            //}
            //openFileDialog1.FileName = "";

            Prm = GetModelExcel();
            Image im = new Bitmap(this.panel1.Width, this.panel1.Height);
            Graphics g = Graphics.FromImage(im);

            for (int i = 0; i < Prm.Length/5; i++)
            {
                Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Bold);
                g.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 3) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
            }
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.BackgroundImage = im;
        }

        private void 打印PToolStripButton1_Click(object sender, EventArgs e)
        {
            printDocument1.DefaultPageSettings.PaperSize = new PaperSize("Custum", 315, 236);
            printDocument1.PrintPage += new PrintPageEventHandler(MyPrintDocument_PrintPage);

            printDialog1.AllowPrintToFile = true;
            printDialog1.Document = printDocument1;
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void MyPrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string[] Prm1;
            //string[,] Prm;
            //Prm = GetModelExcel();
            Prm1 = GetAreaExcel(id);

            for (int i = 0; i < Prm.Length / 5; i++)
            {
                Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Bold);
                e.Graphics.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 4) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
            }

            Barcode bar = new Barcode();
            //e.Graphics.ScaleTransform(1f, 1f);
            e.Graphics.DrawImage(RotateImg(bar.GetBarCode(Prm1[2]), 90), 0, 30);//270.0F, 220.0F);
            //e.Graphics.DrawImage(bar.GetBarCode(Prm1[2]), 0, 30);
            //e.Graphics.ScaleTransform(1f, 1.9f);

            //e.Graphics.ScaleTransform(0.5f, 1.9f);
            //Code39 _Code39 = new Code39();
            //_Code39.Height = 120;
            //_Code39.Magnify = 1;
            //_Code39.ViewFont = new Font("宋体", 20);
            ////e.Graphics.DrawImage(RotateImg(bar.GetBarCode(Prm1[2]), 90), 270.0F, 220.0F);
            //e.Graphics.DrawImage(_Code39.GetCodeImage(Prm1[2], Code39.Code39Model.Code39Normal, true), 100.0F, 220.0F);
        }

        public Image RotateImg(Image b, int angle)
        {
            angle = angle % 360;
            //弧度转换
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高
            int w = b.Width;
            int h = b.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图
            Bitmap dsImage = new Bitmap(W, H);
            Graphics g = Graphics.FromImage(dsImage);
            g.InterpolationMode = InterpolationMode.Bilinear;
            g.SmoothingMode = SmoothingMode.HighQuality;
            //计算偏移量
            Point Offset = new Point((W - w) / 2, (H - h) / 2);
            //构造图像显示区域：让图像的中心与窗口的中心点一致
            Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
            Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
            g.TranslateTransform(center.X, center.Y);
            g.RotateTransform(360 - angle);
            //恢复图像在水平和垂直方向的平移
            g.TranslateTransform(-center.X, -center.Y);
            g.DrawImage(b, rect);
            //重至绘图的所有变换
            g.ResetTransform();
            g.Save();
            g.Dispose();
            //保存旋转后的图片
            b.Dispose();
            //dsImage.Save("FocusPoint.jpg", ImageFormat.Jpeg);
            return dsImage;
        }
    }
}


//public class Barcode
//{
//    //对应码表
//    private Hashtable Decode;
//    private Hashtable CheckCode;
//    //每个字符间的间隔符
//    private string SPARATOR = "0";
//    //float WidthUNIT= 0.25f;//宽度单位 mm
//    private int WidthCU = 3;  //粗线和宽间隙宽度
//    private int WidthXI = 1;  //细线和窄间隙宽度
//    private int xCoordinate = 25;//75;  //条码起始坐标
//    private int LineHeight = 60;
//    private int Height = 0;
//    private int Width = 0;

//    #region 加载对应码表
//    public Barcode()
//    {
//        Decode = new Hashtable();
//        Decode.Add("0", "000110100");
//        Decode.Add("1", "100100001");
//        Decode.Add("2", "001100001");
//        Decode.Add("3", "101100000");
//        Decode.Add("4", "000110001");
//        Decode.Add("5", "100110000");
//        Decode.Add("6", "001110000");
//        Decode.Add("7", "000100101");
//        Decode.Add("8", "100100100");
//        Decode.Add("9", "001100100");
//        Decode.Add("A", "100001001");
//        Decode.Add("B", "001001001");
//        Decode.Add("C", "101001000");
//        Decode.Add("D", "000011001");
//        Decode.Add("E", "100011000");
//        Decode.Add("F", "001011000");
//        Decode.Add("G", "000001101");
//        Decode.Add("H", "100001100");
//        Decode.Add("I", "001001101");
//        Decode.Add("J", "000011100");
//        Decode.Add("K", "100000011");
//        Decode.Add("L", "001000011");
//        Decode.Add("M", "101000010");
//        Decode.Add("N", "000010011");
//        Decode.Add("O", "100010010");
//        Decode.Add("P", "001010010");
//        Decode.Add("Q", "000000111");
//        Decode.Add("R", "100000110");
//        Decode.Add("S", "001000110");
//        Decode.Add("T", "000010110");
//        Decode.Add("U", "110000001");
//        Decode.Add("V", "011000001");
//        Decode.Add("W", "111000000");
//        Decode.Add("X", "010010001");
//        Decode.Add("Y", "110010000");
//        Decode.Add("Z", "011010000");
//        Decode.Add("-", "010000101");
//        Decode.Add("%", "000101010");
//        Decode.Add("$", "010101000");
//        Decode.Add("*", "010010100");

//        CheckCode = new Hashtable();
//        CheckCode.Add("0", "0");
//        CheckCode.Add("1", "1");
//        CheckCode.Add("2", "2");
//        CheckCode.Add("3", "3");
//        CheckCode.Add("4", "4");
//        CheckCode.Add("5", "5");
//        CheckCode.Add("6", "6");
//        CheckCode.Add("7", "7");
//        CheckCode.Add("8", "8");
//        CheckCode.Add("9", "9");
//        CheckCode.Add("A", "10");
//        CheckCode.Add("B", "11");
//        CheckCode.Add("C", "12");
//        CheckCode.Add("D", "13");
//        CheckCode.Add("E", "14");
//        CheckCode.Add("F", "15");
//        CheckCode.Add("G", "16");
//        CheckCode.Add("H", "17");
//        CheckCode.Add("I", "18");
//        CheckCode.Add("J", "19");
//        CheckCode.Add("K", "20");
//        CheckCode.Add("L", "21");
//        CheckCode.Add("M", "22");
//        CheckCode.Add("N", "23");
//        CheckCode.Add("O", "24");
//        CheckCode.Add("P", "25");
//        CheckCode.Add("Q", "26");
//        CheckCode.Add("R", "27");
//        CheckCode.Add("S", "28");
//        CheckCode.Add("T", "29");
//        CheckCode.Add("U", "30");
//        CheckCode.Add("V", "31");
//        CheckCode.Add("W", "32");
//        CheckCode.Add("X", "33");
//        CheckCode.Add("Y", "34");
//        CheckCode.Add("Z", "35");
//        CheckCode.Add("-", "36");
//        CheckCode.Add(".", "37");
//        CheckCode.Add(",", "38");
//        CheckCode.Add("$", "39");
//        CheckCode.Add("/", "40");
//        CheckCode.Add("+", "41");
//        CheckCode.Add("%", "42");
//    }
//    #endregion

//    #region 保存文件

//    public Boolean saveFile(string Code, string Title, int UseCheck)
//    {
//        string code39 = Encode39(Code, UseCheck);
//        if (code39 != null)
//        {
//            Bitmap saved = new Bitmap(this.Width, this.Height);
//            Graphics g = Graphics.FromImage(saved);
//            g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
//            this.DrawBarCode39(code39, Title, g);
//            string path = @"c:\";
//            string filename = path + Code + ".jpg";
//            saved.Save(filename, ImageFormat.Jpeg);
//            saved.Dispose();
//            return true;
//        }
//        return false;
//    }
//    #endregion

//    #region 转换编码
//    /***
//    * Code:未经编码的字符串
//    * 
//    * **/
//    private string Encode39(string Code, int UseCheck)
//    {
//        int UseStand = 1;  //检查输入待编码字符是否为标准格式（是否以*开始结束）

//        //保存备份数据
//        string originalCode = Code;

//        //为空不进行编码
//        if (null == Code || Code.Trim().Equals(""))
//        {
//            return null;
//        }
//        //检查错误字符
//        Code = Code.ToUpper();  //转为大写
//        Regex rule = new Regex(@"[^0-9A-Z%$\-*]");
//        if (rule.IsMatch(Code))
//        {
//            //MessageBox.Show("编码中包含非法字符，目前仅支持字母,数字及%$-*符号!!");
//            return null;
//        }
//        //计算检查码
//        if (UseCheck == 1)
//        {
//            int Check = 0;
//            //累计求和
//            for (int i = 0; i < Code.Length; i++)
//            {
//                Check += int.Parse((string)CheckCode[Code.Substring(i, 1)]);
//            }
//            //取模
//            Check = Check % 43;
//            //附加检测码
//            foreach (DictionaryEntry de in CheckCode)
//            {
//                if ((string)de.Value == Check.ToString())
//                {
//                    Code = Code + (string)de.Key;
//                    break;
//                }
//            }
//        }
//        //标准化输入字符，增加起始标记
//        if (UseStand == 1)
//        {
//            if (Code.Substring(0, 1) != "*")
//            {
//                Code = "*" + Code;
//            }
//            if (Code.Substring(Code.Length - 1, 1) != "*")
//            {
//                Code = Code + "*";
//            }
//        }
//        //转换成39编码
//        string Code39 = "";
//        for (int i = 0; i < Code.Length; i++)
//        {
//            Code39 = Code39 + (string)Decode[Code.Substring(i, 1)] + SPARATOR;
//        }

//        int height = 30 + LineHeight;//定义图片高度      
//        int width = xCoordinate;
//        for (int i = 0; i < Code39.Length; i++)
//        {
//            if ("0".Equals(Code39.Substring(i, 1)))
//            {
//                width += WidthXI;
//            }
//            else
//            {
//                width += WidthCU;
//            }
//        }
//        this.Width = width + xCoordinate;
//        this.Height = height;

//        return Code39;
//    }
//    #endregion

//    #region 绘制图像
//    private void DrawBarCode39(string Code39, string Title, Graphics g)
//    {
//        //int UseTitle = 0;  //条码上端显示标题
//        //int UseTTF = 1;  //使用TTF字体，方便显示中文，需要$UseTitle=1时才能生效
//        //if (Title.Trim().Equals(""))
//        //{
//        //    UseTitle = 0;
//        //}
//        Pen pWhite = new Pen(Color.White, 1);
//        Pen pBlack = new Pen(Color.Black, 1);
//        SolidBrush brush = new SolidBrush(Color.Black);
//        int position = xCoordinate;
//        //显示标题
//        //if (UseTitle == 1)
//        //{
//        //    Font TitleFont = new Font("宋体", 10, FontStyle.Bold);
//        //    SizeF sf = g.MeasureString(Title, TitleFont);
//        //    g.DrawString(Title, TitleFont, brush, (Width - sf.Width) / 2, Height - sf.Height);
//        //}
//        for (int i = 0; i < Code39.Length; i++)
//        {
//            //绘制条线
//            if ("0".Equals(Code39.Substring(i, 1)))
//            {
//                for (int j = 0; j < WidthXI; j++)
//                {
//                    g.DrawLine(pBlack, position + j, 12, position + j, 12 + LineHeight);
//                }
//                position += WidthXI;
//            }
//            else
//            {
//                for (int j = 0; j < WidthCU; j++)
//                {
//                    g.DrawLine(pBlack, position + j, 12, position + j, 12 + LineHeight);
//                }
//                position += WidthCU;
//            }
//            i++;
//            //绘制间隔线
//            if ("0".Equals(Code39.Substring(i, 1)))
//            {
//                position += WidthXI;
//            }
//            else
//            {
//                position += WidthCU;
//            }
//        }
//        return;
//    }
//    #endregion

//    #region 获得生成后条码图像
//    /// <summary>
//    /// 获得生成后条码图像
//    /// </summary>
//    /// <param name="Code">条码值</param>
//    /// <returns>Image对象</returns>
//    public Bitmap GetBarCode(string Code)
//    {
//        string Code39 = Encode39(Code, 0);
//        Bitmap barCode = new Bitmap(this.Width, this.Height);
//        Graphics g = Graphics.FromImage(barCode);
//        g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
//        this.DrawBarCode39(Code39, Code, g);
//        return barCode;
//    }
//    #endregion
//}


#region code39_1
public class Barcode
{
    //对应码表
    private Hashtable Decode;
    private Hashtable CheckCode;
    //每个字符间的间隔符
    private string SPARATOR = "0";
    //float WidthUNIT= 0.25f;//宽度单位 mm
    private float WidthCU = 1.5f;  //粗线和宽间隙宽度
    private float WidthXI = 0.5f;  //细线和窄间隙宽度
    private int xCoordinate = 0;//75;  //条码起始坐标
    private int LineHeight = 20;
    private float Height = 0;
    private float Width = 0;

    #region 加载对应码表
    public Barcode()
    {
        Decode = new Hashtable();
        Decode.Add("0", "000110100");
        Decode.Add("1", "100100001");
        Decode.Add("2", "001100001");
        Decode.Add("3", "101100000");
        Decode.Add("4", "000110001");
        Decode.Add("5", "100110000");
        Decode.Add("6", "001110000");
        Decode.Add("7", "000100101");
        Decode.Add("8", "100100100");
        Decode.Add("9", "001100100");
        Decode.Add("A", "100001001");
        Decode.Add("B", "001001001");
        Decode.Add("C", "101001000");
        Decode.Add("D", "000011001");
        Decode.Add("E", "100011000");
        Decode.Add("F", "001011000");
        Decode.Add("G", "000001101");
        Decode.Add("H", "100001100");
        Decode.Add("I", "001001101");
        Decode.Add("J", "000011100");
        Decode.Add("K", "100000011");
        Decode.Add("L", "001000011");
        Decode.Add("M", "101000010");
        Decode.Add("N", "000010011");
        Decode.Add("O", "100010010");
        Decode.Add("P", "001010010");
        Decode.Add("Q", "000000111");
        Decode.Add("R", "100000110");
        Decode.Add("S", "001000110");
        Decode.Add("T", "000010110");
        Decode.Add("U", "110000001");
        Decode.Add("V", "011000001");
        Decode.Add("W", "111000000");
        Decode.Add("X", "010010001");
        Decode.Add("Y", "110010000");
        Decode.Add("Z", "011010000");
        Decode.Add("-", "010000101");
        Decode.Add("%", "000101010");
        Decode.Add("$", "010101000");
        Decode.Add("*", "010010100");

        CheckCode = new Hashtable();
        CheckCode.Add("0", "0");
        CheckCode.Add("1", "1");
        CheckCode.Add("2", "2");
        CheckCode.Add("3", "3");
        CheckCode.Add("4", "4");
        CheckCode.Add("5", "5");
        CheckCode.Add("6", "6");
        CheckCode.Add("7", "7");
        CheckCode.Add("8", "8");
        CheckCode.Add("9", "9");
        CheckCode.Add("A", "10");
        CheckCode.Add("B", "11");
        CheckCode.Add("C", "12");
        CheckCode.Add("D", "13");
        CheckCode.Add("E", "14");
        CheckCode.Add("F", "15");
        CheckCode.Add("G", "16");
        CheckCode.Add("H", "17");
        CheckCode.Add("I", "18");
        CheckCode.Add("J", "19");
        CheckCode.Add("K", "20");
        CheckCode.Add("L", "21");
        CheckCode.Add("M", "22");
        CheckCode.Add("N", "23");
        CheckCode.Add("O", "24");
        CheckCode.Add("P", "25");
        CheckCode.Add("Q", "26");
        CheckCode.Add("R", "27");
        CheckCode.Add("S", "28");
        CheckCode.Add("T", "29");
        CheckCode.Add("U", "30");
        CheckCode.Add("V", "31");
        CheckCode.Add("W", "32");
        CheckCode.Add("X", "33");
        CheckCode.Add("Y", "34");
        CheckCode.Add("Z", "35");
        CheckCode.Add("-", "36");
        CheckCode.Add(".", "37");
        CheckCode.Add(",", "38");
        CheckCode.Add("$", "39");
        CheckCode.Add("/", "40");
        CheckCode.Add("+", "41");
        CheckCode.Add("%", "42");
    }
    #endregion

    #region 保存文件

    public Boolean saveFile(string Code, string Title, int UseCheck)
    {
        string code39 = Encode39(Code, UseCheck);
        if (code39 != null)
        {
            Bitmap saved = new Bitmap((int)Width, (int)Height);
            Graphics g = Graphics.FromImage(saved);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
            this.DrawBarCode39(code39, Title, g);
            string path = @"c:\";
            string filename = path + Code + ".jpg";
            saved.Save(filename, ImageFormat.Jpeg);
            saved.Dispose();
            return true;
        }
        return false;
    }
    #endregion

    #region 转换编码
    /***
    * Code:未经编码的字符串
    * 
    * **/
    private string Encode39(string Code, int UseCheck)
    {
        int UseStand = 1;  //检查输入待编码字符是否为标准格式（是否以*开始结束）

        //保存备份数据
        string originalCode = Code;

        //为空不进行编码
        if (null == Code || Code.Trim().Equals(""))
        {
            return null;
        }
        //检查错误字符
        Code = Code.ToUpper();  //转为大写
        Regex rule = new Regex(@"[^0-9A-Z%$\-*]");
        if (rule.IsMatch(Code))
        {
            //MessageBox.Show("编码中包含非法字符，目前仅支持字母,数字及%$-*符号!!");
            return null;
        }
        //计算检查码
        if (UseCheck == 1)
        {
            int Check = 0;
            //累计求和
            for (int i = 0; i < Code.Length; i++)
            {
                Check += int.Parse((string)CheckCode[Code.Substring(i, 1)]);
            }
            //取模
            Check = Check % 43;
            //附加检测码
            foreach (DictionaryEntry de in CheckCode)
            {
                if ((string)de.Value == Check.ToString())
                {
                    Code = Code + (string)de.Key;
                    break;
                }
            }
        }
        //标准化输入字符，增加起始标记
        if (UseStand == 1)
        {
            if (Code.Substring(0, 1) != "*")
            {
                Code = "*" + Code;
            }
            if (Code.Substring(Code.Length - 1, 1) != "*")
            {
                Code = Code + "*";
            }
        }
        //转换成39编码
        string Code39 = "";
        for (int i = 0; i < Code.Length; i++)
        {
            Code39 = Code39 + (string)Decode[Code.Substring(i, 1)] + SPARATOR;
        }

        int height = 30 + LineHeight;//定义图片高度      
        float width = xCoordinate;
        for (int i = 0; i < Code39.Length; i++)
        {
            if ("0".Equals(Code39.Substring(i, 1)))
            {
                width += WidthXI;
            }
            else
            {
                width += WidthCU;
            }
        }
        Width = width + xCoordinate;
        Height = height;

        return Code39;
    }
    #endregion

    #region 绘制图像
    private void DrawBarCode39(string Code39, string Title, Graphics g)
    {
        //int UseTitle = 0;  //条码上端显示标题
        //int UseTTF = 1;  //使用TTF字体，方便显示中文，需要$UseTitle=1时才能生效
        //if (Title.Trim().Equals(""))
        //{
        //    UseTitle = 0;
        //}
        Pen pWhite = new Pen(Color.White, 0.2f);
        Pen pBlack = new Pen(Color.Black, 0.2f);
        SolidBrush brush = new SolidBrush(Color.Black);
        float position = xCoordinate;
        //显示标题
        //if (UseTitle == 1)
        //{
        //    Font TitleFont = new Font("宋体", 10, FontStyle.Bold);
        //    SizeF sf = g.MeasureString(Title, TitleFont);
        //    g.DrawString(Title, TitleFont, brush, (Width - sf.Width) / 2, Height - sf.Height);
        //}
        for (int i = 0; i < Code39.Length; i++)
        {
            //绘制条线
            if ("0".Equals(Code39.Substring(i, 1)))
            {
                for (int j = 0; j < WidthXI; j++)
                {
                    g.DrawLine(pBlack, position + (float)(j / 2), 12, position + (float)(j / 2), 12 + LineHeight);
                }
                position += WidthXI;
            }
            else
            {
                for (int j = 0; j < WidthCU; j++)
                {
                    g.DrawLine(pBlack, position + (float)(j / 2), 12, position + (float)(j / 2), 12 + LineHeight);
                }
                position += WidthCU;
            }
            i++;
            //绘制间隔线
            if ("0".Equals(Code39.Substring(i, 1)))
            {
                position += WidthXI;
            }
            else
            {
                position += WidthCU;
            }
        }
        return;
    }
    #endregion

    #region 获得生成后条码图像
    /// <summary>
    /// 获得生成后条码图像
    /// </summary>
    /// <param name="Code">条码值</param>
    /// <returns>Image对象</returns>
    public Bitmap GetBarCode(string Code)
    {
        string Code39 = Encode39(Code, 0);
        Bitmap barCode = new Bitmap((int)Width, (int)Height);
        Graphics g = Graphics.FromImage(barCode);
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
        this.DrawBarCode39(Code39, Code, g);
        return barCode;
    }
    #endregion
}
#endregion


#region code39_2
public class Code39
{
    private Hashtable m_Code39 = new Hashtable();
    private byte m_Magnify = 0;
    /// <summary>
    /// 放大倍数
    /// </summary>
    public byte Magnify { get { return m_Magnify; } set { m_Magnify = value; } }

    private int m_Height = 40;
    /// <summary>
    /// 图形高
    /// </summary>
    public int Height { get { return m_Height; } set { m_Height = value; } }

    private Font m_ViewFont = null;
    /// <summary>
    /// 字体大小
    /// </summary>
    public Font ViewFont { get { return m_ViewFont; } set { m_ViewFont = value; } }

    public Code39()
    {

        m_Code39.Add("A", "1101010010110");
        m_Code39.Add("B", "1011010010110");
        m_Code39.Add("C", "1101101001010");
        m_Code39.Add("D", "1010110010110");
        m_Code39.Add("E", "1101011001010");
        m_Code39.Add("F", "1011011001010");
        m_Code39.Add("G", "1010100110110");
        m_Code39.Add("H", "1101010011010");
        m_Code39.Add("I", "1011010011010");
        m_Code39.Add("J", "1010110011010");
        m_Code39.Add("K", "1101010100110");
        m_Code39.Add("L", "1011010100110");
        m_Code39.Add("M", "1101101010010");
        m_Code39.Add("N", "1010110100110");
        m_Code39.Add("O", "1101011010010");
        m_Code39.Add("P", "1011011010010");
        m_Code39.Add("Q", "1010101100110");
        m_Code39.Add("R", "1101010110010");
        m_Code39.Add("S", "1011010110010");
        m_Code39.Add("T", "1010110110010");
        m_Code39.Add("U", "1100101010110");
        m_Code39.Add("V", "1001101010110");
        m_Code39.Add("W", "1100110101010");
        m_Code39.Add("X", "1001011010110");
        m_Code39.Add("Y", "1100101101010");
        m_Code39.Add("Z", "1001101101010");
        m_Code39.Add("0", "1010011011010");
        m_Code39.Add("1", "1101001010110");
        m_Code39.Add("2", "1011001010110");
        m_Code39.Add("3", "1101100101010");
        m_Code39.Add("4", "1010011010110");
        m_Code39.Add("5", "1101001101010");
        m_Code39.Add("6", "1011001101010");
        m_Code39.Add("7", "1010010110110");
        m_Code39.Add("8", "1101001011010");
        m_Code39.Add("9", "1011001011010");
        m_Code39.Add("+", "1001010010010");
        m_Code39.Add("-", "1001010110110");
        m_Code39.Add("*", "1001011011010");
        m_Code39.Add("/", "1001001010010");
        m_Code39.Add("%", "1010010010010");
        m_Code39.Add("$", "1001001001010");
        m_Code39.Add(".", "1100101011010");
        m_Code39.Add(" ", "1001101011010");
    }

    public enum Code39Model
    {
        /// <summary>
        /// 基本类别 1234567890ABC
        /// </summary>
        Code39Normal,
        /// <summary>
        /// 全ASCII方式 +A+B 来表示小写
        /// </summary>
        Code39FullAscII
    }
    /// <summary>
    /// 获得条码图形
    /// </summary>
    /// <param name="p_Text">文字信息</param>
    /// <param name="p_Model">类别</param>
    /// <param name="p_StarChar">是否增加前后*号</param>
    /// <returns>图形</returns>
    public Bitmap GetCodeImage(string p_Text, Code39Model p_Model, bool p_StarChar)
    {
        string _ValueText = "";
        string _CodeText = "";
        char[] _ValueChar = null;
        switch (p_Model)
        {
            case Code39Model.Code39Normal:
                _ValueText = p_Text.ToUpper();
                break;
            default:
                _ValueChar = p_Text.ToCharArray();
                for (int i = 0; i != _ValueChar.Length; i++)
                {
                    if ((int)_ValueChar[i] >= 97 && (int)_ValueChar[i] <= 122)
                    {
                        _ValueText += "+" + _ValueChar[i].ToString().ToUpper();

                    }
                    else
                    {
                        _ValueText += _ValueChar[i].ToString();
                    }
                }
                break;
        }
        _ValueChar = _ValueText.ToCharArray();
        if (p_StarChar == true) _CodeText += m_Code39["*"];
        for (int i = 0; i != _ValueChar.Length; i++)
        {
            if (p_StarChar == true && _ValueChar[i] == '*') throw new Exception("带有起始符号不能出现*");
            object _CharCode = m_Code39[_ValueChar[i].ToString()];
            if (_CharCode == null) throw new Exception("不可用的字符" + _ValueChar[i].ToString());
            _CodeText += _CharCode.ToString();
        }
        if (p_StarChar == true) _CodeText += m_Code39["*"];

        Bitmap _CodeBmp = GetImage(_CodeText);
        GetViewImage(_CodeBmp, p_Text);
        return _CodeBmp;
    }

    /// <summary>
    /// 绘制编码图形
    /// </summary>
    /// <param name="p_Text">编码</param>
    /// <returns>图形</returns>
    private Bitmap GetImage(string p_Text)
    {
        char[] _Value = p_Text.ToCharArray();

        //宽 == 需要绘制的数量*放大倍数 + 两个字的宽   
        Bitmap _CodeImage = new Bitmap(_Value.Length * ((int)m_Magnify + 1), (int)m_Height);
        Graphics _Garphics = Graphics.FromImage(_CodeImage);
        _Garphics.FillRectangle(Brushes.White, new Rectangle(0, 0, _CodeImage.Width, _CodeImage.Height));

        int _LenEx = 0;
        for (int i = 0; i != _Value.Length; i++)
        {
            int _DrawWidth = m_Magnify + 1;
            if (_Value[i] == '1')
            {
                _Garphics.FillRectangle(Brushes.Black, new Rectangle(_LenEx, 0, _DrawWidth, m_Height));
            }
            else
            {
                _Garphics.FillRectangle(Brushes.White, new Rectangle(_LenEx, 0, _DrawWidth, m_Height));
            }
            _LenEx += _DrawWidth;
        }

        _Garphics.Dispose();
        return _CodeImage;
    }
    /// <summary>
    /// 绘制文字
    /// </summary>
    /// <param name="p_CodeImage">图形</param>
    /// <param name="p_Text">文字</param>
    private void GetViewImage(Bitmap p_CodeImage, string p_Text)
    {
        if (m_ViewFont == null) return;
        Graphics _Graphics = Graphics.FromImage(p_CodeImage);
        SizeF _FontSize = _Graphics.MeasureString(p_Text, m_ViewFont);
        if (_FontSize.Width > p_CodeImage.Width || _FontSize.Height > p_CodeImage.Height - 20)
        {
            _Graphics.Dispose();
            return;
        }
        int _StarHeight = p_CodeImage.Height - (int)_FontSize.Height;
        _Graphics.FillRectangle(Brushes.White, new Rectangle(0, _StarHeight, p_CodeImage.Width, (int)_FontSize.Height));
        int _StarWidth = (p_CodeImage.Width - (int)_FontSize.Width) / 2;
        _Graphics.DrawString(p_Text, m_ViewFont, Brushes.Black, _StarWidth, _StarHeight);
        _Graphics.Dispose();
    }
}
#endregion