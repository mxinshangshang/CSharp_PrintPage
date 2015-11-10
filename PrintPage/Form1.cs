using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PrintPage
{
    public partial class Form1 : Form
    {
        //Label lab = new Label();

        private string InfoPath;
        private string ModelPath;
        private string CEImagePath = null;

        private string[,] Prm;
        private string[] Prm1;

        public string id = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.AllowDrop = true;
            //窗体自身支持接受拖拽来的控件
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

        private void button1_Click(object sender, EventArgs e)  //输入ID
        {
            //AddLabel("area"+index);
            //index++;

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

                Image im = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(im);

                for (int i = 0; i < Prm.Length / 5; i++)
                {
                    Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Bold);
                    g.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 3) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
                }

                Barcode bar = new Barcode();
                g.ScaleTransform(1, 0.54f);
                g.DrawImage(bar.GetBarCode(Prm1[2]), 300, 250);

                //g.ScaleTransform(1, 1.9f);

                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.BackgroundImage = im;
            }
            else MessageBox.Show("id号输入不正确！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Prm1 != null)
            {
                Prm = GetModelExcel();

                for (int i = 0; i < Prm.Length / 5; i++)
                {
                    string a = Prm[i, 0].Trim().Substring(4);
                    int.Parse(a);
                    Prm[i, 0] = Prm[i, 0].Replace(Prm[i, 0], Prm1[int.Parse(Prm[i, 0].Trim().Substring(4)) - 1]);
                }

                Image im = new Bitmap(panel1.Width, panel1.Height);
                Graphics g = Graphics.FromImage(im);

                for (int i = 0; i < Prm.Length / 5; i++)
                {
                    Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Bold);
                    g.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 3) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
                }
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Title = "Insert picture";
                    dlg.DefaultExt = "jpg";
                    dlg.Filter = "Bitmap Files|*.bmp|JPEG Files|*.jpg|GIF Files|*.gif|All files|*.*";
                    dlg.FilterIndex = 1;
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            CEImagePath = dlg.FileName;
                            Image img = Image.FromFile(CEImagePath);
                            g.DrawImage(img, new Rectangle(4, 200, 30, 30));
                            //g.DrawImage(img, 300, 250);
                            //Clipboard.SetDataObject(img);
                            //DataFormats.Format df = DataFormats.GetFormat(DataFormats.Bitmap);
                        }
                        catch
                        {
                            MessageBox.Show("Unable to insert image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                Barcode bar = new Barcode();
                g.ScaleTransform(1, 0.54f);
                g.DrawImage(bar.GetBarCode(Prm1[2]), 300, 250);
                //g.ScaleTransform(1, 1.9f);

                panel1.BackgroundImageLayout = ImageLayout.Stretch;
                panel1.BackgroundImage = im;
            }

            //panel1.Controls.Remove(lab);
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
            Prm = GetModelExcel();
            Image im = new Bitmap(this.panel1.Width, this.panel1.Height);
            Graphics g = Graphics.FromImage(im);

            for (int i = 0; i < Prm.Length/5; i++)
            {
                Font font = new Font(Prm[i, 4], int.Parse(Prm[i, 3]), FontStyle.Regular);
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
                e.Graphics.DrawString(Prm[i, 0], font, Brushes.Black, (float.Parse(Prm[i, 1]) - 0) * 3F, (60 - float.Parse(Prm[i, 2]) - 5) * 4F);
            }
            if (CEImagePath != null)
            {
                Image img = Image.FromFile(CEImagePath);
                e.Graphics.DrawImage(img, new Rectangle(18, 175, 40, 40));
            }

            Barcode bar = new Barcode();
            e.Graphics.ScaleTransform(1f, 0.51f);
            e.Graphics.DrawImage(bar.GetBarCode(Prm1[2]), 300, 250);//270.0F, 220.0F);
            //e.Graphics.DrawImage(bar.GetBarCode(Prm1[2]), 0, 30);
            //e.Graphics.ScaleTransform(1f, 1.9f);

            //e.Graphics.ScaleTransform(0.5f, 1.9f);
            //Code39 _Code39 = new Code39();
            //_Code39.Height = 120;
            //_Code39.Magnify = 1;
            //_Code39.ViewFont = new Font("宋体", 20);
            //e.Graphics.ScaleTransform(1f, 0.35f);
            //e.Graphics.DrawImage(RotateImg(_Code39.GetCodeImage(Prm1[2], Code39.Code39Model.Code39Normal, true), 90), 200.0F, 150.0F);

            //CSharpCode39 code = new CSharpCode39();
            //e.Graphics.DrawImage(code.getBitmapImage(12), 200.0F, 150.0F);
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

#region code39_1
public class Barcode
{
    //对应码表
    private Hashtable Decode;
    private Hashtable CheckCode;
    //每个字符间的间隔符
    private string SPARATOR = "0";
    //float WidthUNIT= 0.25f;//宽度单位 mm
    private int WidthCU = 3;  //粗线和宽间隙宽度
    private int WidthXI = 1;  //细线和窄间隙宽度
    private int xCoordinate = 0;//75;  //条码起始坐标
    private int LineHeight = 30;
    private int Height = 0;
    private int Width = 0;

    #region 加载对应码表
    public Barcode()
    {
        //Decode = new Hashtable();
        //Decode.Add("0", "1010011011010");
        //Decode.Add("1", "1101001010110");
        //Decode.Add("2", "1011001010110");
        //Decode.Add("3", "1101100101010");
        //Decode.Add("4", "1010011010110");
        //Decode.Add("5", "1101001101010");
        //Decode.Add("6", "1011001101010");
        //Decode.Add("7", "1010010110110");
        //Decode.Add("8", "1101001011010");
        //Decode.Add("9", "1011001011010");
        //Decode.Add("+", "1001010010010");
        //Decode.Add("-", "1001010110110");
        //Decode.Add("*", "1001011011010");


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

        //int height = LineHeight;//定义图片高度      
        //int width = xCoordinate;
        int height = xCoordinate;
        int width = LineHeight;//定义图片高度 
        for (int i = 0; i < Code39.Length; i++)
        {
            if ("0".Equals(Code39.Substring(i, 1)))
            {
                height += WidthXI;
            }
            else
            {
                height += WidthCU;
            }
        }
        //this.Width = width + xCoordinate;
        //this.Height = height;
        this.Width = height;
        this.Height = width + xCoordinate;

        return Code39;
    }
    #endregion

    #region 绘制图像
    private void DrawBarCode39(string Code39, string Title, Graphics g)
    {
        int UseTitle = 0;  //条码上端显示标题
                           //int UseTTF = 1;  //使用TTF字体，方便显示中文，需要$UseTitle=1时才能生效
        if (Title.Trim().Equals(""))
        {
            UseTitle = 0;
        }
        Pen pWhite = new Pen(Color.White, 1);
        Pen pBlack = new Pen(Color.Black, 1);
        SolidBrush brush = new SolidBrush(Color.Black);
        int position = xCoordinate;
        //显示标题
        if (UseTitle == 1)
        {
            Font TitleFont = new Font("宋体", 10, FontStyle.Bold);
            SizeF sf = g.MeasureString(Title, TitleFont);
            g.DrawString(Title, TitleFont, brush, (Width - sf.Width) / 2, Height - sf.Height);
        }
        for (int i = 0; i < Code39.Length; i++)
        {
            //绘制条线
            if ("0".Equals(Code39.Substring(i, 1)))
            {
                for (int j = 0; j < WidthXI; j++)
                {
                    //g.DrawLine(pBlack, position + j, 12, position + j, 12 + LineHeight);
                    g.DrawLine(pBlack, 0, position + j, 0 + LineHeight, position + j);
                }
                position += WidthXI;
            }
            else
            {
                for (int j = 0; j < WidthCU; j++)
                {
                    //g.DrawLine(pBlack, position + j, 12, position + j, 12 + LineHeight);
                    g.DrawLine(pBlack, 0, position + j, 0 + LineHeight, position + j);
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
        //Bitmap barCode = new Bitmap(this.Width, this.Height);
        Bitmap barCode = new Bitmap(this.Height, this.Width);
        Graphics g = Graphics.FromImage(barCode);
        //g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
        g.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Height, this.Width);
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

    private int m_Height = 20;
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

#region code39_3
public class CSharpCode39
{
    #region 数据码
    private byte[,] c39_bp = new byte[,] {
        { 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x31, 0x30, 0x30 }, { 0x31, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31 }, { 0x32, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31 }, { 0x33, 0x31, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30 }, { 0x34, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x31 }, { 0x35, 0x31, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30 }, { 0x36, 0x30, 0x30, 0x31, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30 }, { 0x37, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x31 }, { 0x38, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30 }, { 0x39, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30 }, { 0x41, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31 }, { 0x42, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31 }, { 0x43, 0x31, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30 }, { 0x44, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x31 }, { 0x45, 0x31, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30 }, { 70, 0x30, 0x30, 0x31, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30 },
        { 0x47, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x31 }, { 0x48, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30 }, { 0x49, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x31, 0x30, 0x30 }, { 0x4a, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x31, 0x30, 0x30 }, { 0x4b, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31 }, { 0x4c, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31 }, { 0x4d, 0x31, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30 }, { 0x4e, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x31 }, { 0x4f, 0x31, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30 }, { 80, 0x30, 0x30, 0x31, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30 }, { 0x51, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x31 }, { 0x52, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30 }, { 0x53, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30, 0x31, 0x31, 0x30 }, { 0x54, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x31, 0x30 }, { 0x55, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31 }, { 0x56, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x31 },
        { 0x57, 0x31, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x30, 0x30 }, { 0x58, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30, 0x31 }, { 0x59, 0x31, 0x31, 0x30, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30 }, { 90, 0x30, 0x31, 0x31, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30 }, { 0x2d, 0x30, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31 }, { 0x2e, 0x31, 0x31, 0x30, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30 }, { 0x20, 0x30, 0x31, 0x31, 0x30, 0x30, 0x30, 0x31, 0x30, 0x30 }, { 0x2a, 0x30, 0x31, 0x30, 0x30, 0x31, 0x30, 0x31, 0x30, 0x30 }, { 0x24, 0x30, 0x31, 0x30, 0x31, 0x30, 0x31, 0x30, 0x30, 0x30 }, { 0x2f, 0x30, 0x31, 0x30, 0x31, 0x30, 0x30, 0x30, 0x31, 0x30 }, { 0x2b, 0x30, 0x31, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x30 }, { 0x25, 0x30, 0x30, 0x30, 0x31, 0x30, 0x31, 0x30, 0x31, 0x30 }
     };
    //code39合法字符集 [0-9A-Z+-*/%. ] 共43个
    private byte[] c39_cw = new byte[] {
        0x30, 0x31, 50, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x41, 0x42, 0x43, 0x44, 0x45, 70,
        0x47, 0x48, 0x49, 0x4a, 0x4b, 0x4c, 0x4d, 0x4e, 0x4f, 80, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56,
        0x57, 0x58, 0x59, 90, 0x2d, 0x2e, 0x20, 0x24, 0x2f, 0x2b, 0x25
     };
    private byte[,] c39_ex = new byte[,] {
        { 1, 0x24, 0x41 }, { 2, 0x24, 0x42 }, { 3, 0x24, 0x43 }, { 4, 0x24, 0x44 }, { 5, 0x24, 0x45 }, { 6, 0x24, 70 }, { 7, 0x24, 0x47 }, { 8, 0x24, 0x48 }, { 9, 0x24, 0x49 }, { 10, 0x24, 0x4a }, { 11, 0x24, 0x4b }, { 12, 0x24, 0x4c }, { 13, 0x24, 0x4d }, { 14, 0x24, 0x4e }, { 15, 0x24, 0x4f }, { 0x10, 0x24, 80 },
        { 0x11, 0x24, 0x51 }, { 0x12, 0x24, 0x52 }, { 0x13, 0x24, 0x53 }, { 20, 0x24, 0x54 }, { 0x15, 0x24, 0x55 }, { 0x16, 0x24, 0x56 }, { 0x17, 0x24, 0x57 }, { 0x18, 0x24, 0x58 }, { 0x19, 0x24, 0x59 }, { 0x1a, 0x24, 90 }, { 0x1b, 0x25, 0x41 }, { 0x1c, 0x25, 0x42 }, { 0x1d, 0x25, 0x43 }, { 30, 0x25, 0x44 }, { 0x1f, 0x25, 0x45 }, { 0x3b, 0x25, 70 },
        { 60, 0x25, 0x47 }, { 0x3d, 0x25, 0x48 }, { 0x3e, 0x25, 0x49 }, { 0x3f, 0x25, 0x4a }, { 0x5b, 0x25, 0x4b }, { 0x5c, 0x25, 0x4c }, { 0x5d, 0x25, 0x4d }, { 0x5e, 0x25, 0x4e }, { 0x5f, 0x25, 0x4f }, { 0x7b, 0x25, 80 }, { 0x7c, 0x25, 0x51 }, { 0x7d, 0x25, 0x52 }, { 0x7e, 0x25, 0x53 }, { 0x7f, 0x25, 0x54 }, { 0, 0x25, 0x55 }, { 0x40, 0x25, 0x56 },
        { 0x60, 0x25, 0x57 }, { 0x21, 0x2f, 0x41 }, { 0x22, 0x2f, 0x42 }, { 0x23, 0x2f, 0x43 }, { 0x26, 0x2f, 70 }, { 0x27, 0x2f, 0x47 }, { 40, 0x2f, 0x48 }, { 0x29, 0x2f, 0x49 }, { 0x2a, 0x2f, 0x4a }, { 0x2c, 0x2f, 0x4c }, { 0x3a, 0x2f, 90 }, { 0x61, 0x2b, 0x41 }, { 0x62, 0x2b, 0x42 }, { 0x63, 0x2b, 0x43 }, { 100, 0x2b, 0x44 }, { 0x65, 0x2b, 0x45 },
        { 0x66, 0x2b, 70 }, { 0x67, 0x2b, 0x47 }, { 0x68, 0x2b, 0x48 }, { 0x69, 0x2b, 0x49 }, { 0x6a, 0x2b, 0x4a }, { 0x6b, 0x2b, 0x4b }, { 0x6c, 0x2b, 0x4c }, { 0x6d, 0x2b, 0x4d }, { 110, 0x2b, 0x4e }, { 0x6f, 0x2b, 0x4f }, { 0x70, 0x2b, 80 }, { 0x71, 0x2b, 0x51 }, { 0x72, 0x2b, 0x52 }, { 0x73, 0x2b, 0x53 }, { 0x74, 0x2b, 0x54 }, { 0x75, 0x2b, 0x55 },
        { 0x76, 0x2b, 0x56 }, { 0x77, 0x2b, 0x57 }, { 120, 0x2b, 0x58 }, { 0x79, 0x2b, 0x59 }, { 0x7a, 0x2b, 90 }
     };
    #endregion
    #region 字段和属性
    private bool _checksum;
    private string _dataToEncode;
    private bool _humanReadable;
    private string _humanReadableFont;
    private float _humanReadableSize;
    private float _marginX;
    private float _marginY;
    private float _moduleHeight;
    private float _moduleWidth;
    private float _ratio;
    private float _reduction;
    private Color _codeBarColor = Color.Black;
    private bool _isDisplayCheckCode;
    private string _checkData;
    private bool _isDisplayStartStopSign;
    /// <summary>
    /// 是否检查效验
    /// </summary>
    public bool Checksum
    {
        get
        {
            return _checksum;
        }
        set
        {
            _checksum = value;
        }
    }
    /// <summary>
    /// 要进行编码的数据
    /// </summary>
    public string DataToEncode
    {
        get
        {
            return _dataToEncode;
        }
        set
        {
            _dataToEncode = value;
        }
    }
    /// <summary>
    /// 是否显示文本内容
    /// </summary>
    public bool HumanReadable
    {
        get
        {
            return _humanReadable;
        }
        set
        {
            _humanReadable = value;
        }
    }
    /// <summary>
    /// 用于显示文本内容的字体
    /// </summary>
    public string HumanReadableFont
    {
        get
        {
            return _humanReadableFont;
        }
        set
        {
            _humanReadableFont = value;
        }
    }
    /// <summary>
    /// 用于显示文本内容文字的代大小 
    /// </summary>
    public float HumanReadableSize
    {
        get
        {
            return _humanReadableSize;
        }
        set
        {
            _humanReadableSize = value;
        }
    }
    /// <summary>
    /// 水平方向边距
    /// 水平方向建议尽量留白
    /// 如果没有留白同时模块宽度较小可能会造成无法识别
    /// </summary>
    public float MarginX
    {
        get
        {
            return _marginX;
        }
        set
        {
            _marginX = value;
        }
    }
    /// <summary>
    /// 垂直方向边距
    /// </summary>
    public float MarginY
    {
        get
        {
            return _marginY;
        }
        set
        {
            _marginY = value;
        }
    }
    /// <summary>
    /// 模块高度(mm)
    /// </summary>
    public float ModuleHeight
    {
        get
        {
            return _moduleHeight;
        }
        set
        {
            _moduleHeight = value;
        }
    }
    /// <summary>
    /// 模块宽度(mm)
    /// 模块宽度不应低于0.2646f
    /// 模块宽度过低会造成数据丢失因而读不出数据或者会误读
    /// </summary>
    public float ModuleWidth
    {
        get
        {
            return _moduleWidth;
        }
        set
        {
            _moduleWidth = value;
        }
    }
    /// <summary>
    /// 放大比率 
    /// </summary>
    public float Ratio
    {
        get
        {
            return _ratio;
        }
        set
        {
            _ratio = value;
        }
    }
    /// <summary>
    /// 缩小
    /// </summary>
    public float Reduction
    {
        get
        {
            return _reduction;
        }
        set
        {
            _reduction = value;
        }
    }
    /// <summary>
    /// 设置条形码的颜色
    /// </summary>
    public Color CodeBarColor
    {
        get
        {
            return _codeBarColor;
        }
        set
        {
            _codeBarColor = value;
        }
    }
    /// <summary>
    /// 是否显示效验码
    /// 此属性要在Checksum属性为true的情况下有用
    /// </summary>
    public bool IsDisplayCheckCode
    {
        get { return this._isDisplayCheckCode; }
        set { this._isDisplayCheckCode = value; }
    }
    /// <summary>
    /// 供人识别是否显示起止符
    /// </summary>
    public bool IsDisplayStartStopSign
    {
        get { return this._isDisplayStartStopSign; }
        set { this._isDisplayStartStopSign = value; }
    }
    #endregion
    /// <summary>
    /// 默认构造函数
    /// 初始化
    /// </summary>
    public CSharpCode39()
    {
        this.initData();

    }
    public CSharpCode39(string dataToEncode)
    {
        this.initData();
        this._dataToEncode = dataToEncode;
    }
    /// <summary>
    /// 默认构造函数
    /// 初始化数据
    /// </summary>
    private void initData()
    {
        this._humanReadableFont = "Arial";
        this._humanReadableSize = 10f;
        this._codeBarColor = Color.Black;
        this._moduleHeight = 15f;//模块高度毫米
        this._moduleWidth = 0.35f;//模块宽度毫米
        this._ratio = 3f;
        this._marginX = 2;
        this._marginY = 2;
        this._checksum = true;
        this._isDisplayCheckCode = false;
        this._isDisplayStartStopSign = false;
    }
    private char[] _bitpattern_c39(string rawdata, ref int finalLength)
    {
        //0x27  39  
        //0x50  80
        if ((rawdata.Length == 0) || (rawdata.Length > 0x50)) /*0x27*/
        {
            return null;
        }
        for (int i = 0; i < rawdata.Length; i++)
        {
            if ((rawdata[i] == '\0') || (rawdata[i] > '\x007f'))
            {
                return null;
            }
        }
        byte[] data = processTilde(rawdata);
        if (data.Length == 0)
        {
            return null;
        }
        byte[] buffer2 = this.processExtended(data);
        if ((buffer2.Length == 0) || (buffer2.Length > /*40*/80))
        {
            return null;
        }
        finalLength = this._checksum ? ((buffer2.Length + 2) + 1) : (buffer2.Length + 2);
        return this.getPattern_c39(buffer2);
    }
    /// <summary>
    /// 计算效验值
    /// </summary>
    /// <param name="data"></param>
    /// <param name="len"></param>
    /// <returns></returns>
    private byte _checksum_c39(byte[] data, int len)
    {
        //0x2b 43
        //字符值的总和除以合法字符集的个数43 取余数   余数在合法字符数组中对应的数值就是效验值
        int num2 = 0;
        for (int i = 1; i < len; i++)
        {
            num2 += this.valueFromCharacter(data[i]);
        }
        return this.c39_cw[num2 % 0x2b];
    }
    private char[] Code39_bitpattern(string dataToEncode)
    {
        int finalLength = 0;
        return this._bitpattern_c39(dataToEncode, ref finalLength);
    }
    /// <summary>
    /// 获得Code39条码图片
    /// </summary>
    /// <param name="resolution">DPI</param>
    /// <returns></returns>
    public Bitmap getBitmapImage(float resolution)
    {
        return Code39_createCode(resolution);
    }

    private Bitmap Code39_createCode(float resolution)
    {
        int num6;
        int finalLength = 0;
        char[] chArray = this._bitpattern_c39(DataToEncode, ref finalLength);
        if (chArray == null)
        {
            return null;
        }
        float fontsize = this._humanReadable ? (0.3527778f * this._humanReadableSize) : 0f;
        // float num3 = (7f * ModuleWidth) + ((3f * Ratio) * ModuleWidth);
        float num3 = (7f * this._moduleWidth) + ((3f * this._ratio) * this._moduleWidth);
        float width = (finalLength * num3) + (2f * this._marginX);
        float height = (this._moduleHeight + (2f * this._marginY)) + fontsize;
        width *= resolution / 25.4f;
        height *= resolution / 25.4f;
        Bitmap image = new Bitmap((int)width, (int)height, PixelFormat.Format32bppPArgb);
        image.SetResolution(resolution, resolution);
        //image.SetResolution(300, 300);
        Graphics g = Graphics.FromImage(image);
        g.Clear(Color.White);
        g.PageUnit = GraphicsUnit.Millimeter; //以毫米为度量单位
        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, /*(int)width*/image.Width, /*(int)height*/image.Height));
        //new Pen(Color.Black, 2f);
        //new SolidBrush(Color.White);
        SolidBrush brush = new SolidBrush(Color.Black);
        if (resolution < 300f)
        {
            //g.TextRenderingHint = TextRenderingHint.AntiAlias;
            //g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighQuality;
            //g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        }
        float num7 = 0f;
        for (num6 = 0; num6 < chArray.Length; num6++)
        {
            if (chArray[num6] == '0')
            {
                if ((num6 & 1) != 1)
                {
                    RectangleF rect = new RectangleF(MarginX + num7, MarginY, ModuleWidth, ModuleHeight);
                    MakeBar(g, rect, Reduction);
                }
                num7 += 1f * ModuleWidth;
            }
            else
            {
                if ((num6 & 1) != 1)
                {
                    RectangleF ef2 = new RectangleF(MarginX + num7, MarginY, Ratio * ModuleWidth, ModuleHeight);
                    MakeBar(g, ef2, Reduction);
                }
                num7 += Ratio * ModuleWidth;
            }
        }
        #region  供人识别内容
        if (this._humanReadable)
        {
            #region 保留
            /*byte[] buffer2 = processTilde(this._dataToEncode);
            int index = 0;
            List<byte> arr = new List<byte>();
            for (num6 = 0; num6 < buffer2.Length; num6++)
            {
                //0x20 32      0x7e  126
                if ((buffer2[num6] >= 0x20) && (buffer2[num6] <= 0x7e))
                {
                    arr.Add(buffer2[num6]);
                }
            }
            byte[] bytes = new byte[arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                bytes[i] = arr[i];
            }
            index = arr.Count;
             
            //string text = new ASCIIEncoding().GetString(bytes, 0, index);
             */
            #endregion
            string text = this._dataToEncode;
            if (this._isDisplayCheckCode && !string.IsNullOrEmpty(this._checkData))
            {
                text += this._checkData;
            }
            if (this._isDisplayStartStopSign)
            {
                text = "*" + text + "*";
            }
            Font font = new Font(this._humanReadableFont, this._humanReadableSize);
            //g.DrawString(text, font, brush, new PointF(MarginX, MarginY + ModuleHeight));
            //新增字符串格式
            var drawFormat = new StringFormat { Alignment = StringAlignment.Center };
            float inpix = image.Width / resolution;//根据DPi求出 英寸数
            float widthmm = inpix * 25.4f;   //有每英寸像素求出毫米
            //g.DrawString(text, font, Brushes.Black, width / 2, height - 14, drawFormat);
            g.DrawString(text, font, /*Brushes.Black*/brush, new PointF(/*MarginX*/(int)(widthmm / 2), MarginY + ModuleHeight + 1), drawFormat);
        }
        #endregion
        return image;
    }
    /// <summary>
    /// 进行图形填充
    /// </summary>
    /// <param name="g"></param>
    /// <param name="rect"></param>
    /// <param name="reduction"></param>
    private void MakeBar(Graphics g, RectangleF rect, float reduction)
    {
        MakeBar(g, rect, reduction, this._codeBarColor);
    }
    /// <summary>
    /// 进行图形填充
    /// </summary>
    /// <param name="g"></param>
    /// <param name="rect"></param>
    /// <param name="reduction"></param>
    /// <param name="brushColor"></param>
    private void MakeBar(Graphics g, RectangleF rect, float reduction, Color brushColor)
    {
        float num = rect.Width * (reduction / 200f);
        float num2 = rect.Width - (rect.Width * (reduction / 200f));
        RectangleF ef = new RectangleF
        {
            X = rect.X + num,
            Y = rect.Y,
            Width = num2,
            Height = rect.Height
        };
        SolidBrush brush = new SolidBrush(brushColor);
        g.FillRectangle(brush, ef);
    }
    private char[] getPattern_c39(byte[] data)
    {   //0x2a  42为*
        //int num = 0x27;
        int num = 80;
        byte[] buffer = new byte[num + 1];
        buffer[0] = 0x2a;
        int index = 1;
        for (int i = 0; i < data.Length; i++)
        {
            buffer[index] = data[i];
            index++;
        }
        if (Checksum)
        {
            buffer[index] = this._checksum_c39(buffer, index);
            if (_isDisplayCheckCode)
            {
                this._checkData = ((char)buffer[index]).ToString();
            }
            index++;
        }
        buffer[index] = 0x2a;
        index++;
        char[] chArray = new char[index * 10];
        int num5 = 0;
        for (int j = 0; j < index; j++)
        {
            byte c = buffer[j];
            int num9 = this.indexFromCharacter(c);
            for (int k = 0; k < 9; k++)
            {
                chArray[num5] = (char)this.c39_bp[num9, k + 1];
                num5++;
            }
            chArray[num5] = '0';
            num5++;
        }
        return chArray;
    }
    private int indexFromCharacter(byte c)
    {
        //0x2c==44
        for (int i = 0; i < 0x2c; i++)
        {
            if (this.c39_bp[i, 0] == c)
            {
                return i;
            }
        }
        return -1;
    }
    private byte[] processExtended(byte[] data)
    {
        //0x25  38
        //0x4F  79 0x4E 78
        //int num = 0x4F;
        int num = data.Length - 1;
        byte[] sourceArray = new byte[num + 1];
        int index = 0;
        for (int i = 0; i < data.Length; i++)
        {
            byte c = data[i];
            if (this.valueFromCharacter(c) != -1)
            {
                sourceArray[index] = c;
                index++;
            }
            else
            {
                byte num5 = 0;
                byte num6 = 0;
                if (this.valuesFromExtended(c, ref num5, ref num6))
                {
                    sourceArray[index] = num5;
                    sourceArray[index + 1] = num6;
                    index += 2;
                }
            }
        }
        byte[] destinationArray = new byte[index];
        Array.Copy(sourceArray, destinationArray, index);
        return destinationArray;
    }
    /// <summary>
    /// 返回指定字符在code39合法字符数组中对应的索引
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    private int valueFromCharacter(byte c)
    {
        //c39_cw为数组，保存的为合法的字符集信息[0-9A-Z+-*/%. ] 共43个
        //如果存在这个字符就返回c39_cw对应的索引
        for (int i = 0; i < /*0x2b*/this.c39_cw.Length; i++)
        {
            if (this.c39_cw[i] == c)
            {
                return i;
            }
        }
        return -1;
    }
    /// <summary>
    /// 判断字符集是否存在Extended
    /// </summary>
    /// <param name="c"></param>
    /// <param name="v1"></param>
    /// <param name="v2"></param>
    /// <returns></returns>
    private bool valuesFromExtended(byte c, ref byte v1, ref byte v2)
    {
        //0x55  85
        for (int i = 0; i < 0x55; i++)
        {
            if (this.c39_ex[i, 0] == c)
            {
                v1 = this.c39_ex[i, 1];
                v2 = this.c39_ex[i, 2];
                return true;
            }
        }
        return false;
    }
    private byte[] processTilde(string rawdata)
    {
        byte[] sourceArray = new byte[rawdata.Length];
        int index = 0;
        for (int i = 0; i < rawdata.Length; i++)
        {
            if (rawdata[i] != '~')
            {
                sourceArray[index] = (byte)rawdata[i];
                index++;
            }
            else if ((i + 3) < rawdata.Length)
            {
                string str = new string(new char[] { rawdata[i + 1], rawdata[i + 2], rawdata[i + 3] });
                int num3 = Convert.ToInt32(str, 10);
                if ((num3 > 0) && (num3 <= 0xff))
                {
                    sourceArray[index] = (byte)num3;
                    index++;
                }
                if (num3 == 0x3e7)
                {
                    sourceArray[index] = 0x86;
                    index++;
                }
                i += 3;
            }
            else
            {
                sourceArray[index] = (byte)rawdata[i];
                index++;
            }
        }
        byte[] destinationArray = new byte[index];
        Array.Copy(sourceArray, destinationArray, index);
        return destinationArray;
    }
}
#endregion