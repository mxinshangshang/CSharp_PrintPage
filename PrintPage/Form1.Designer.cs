namespace PrintPage
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panel1 = new System.Windows.Forms.Panel();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.新建NToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.打开OToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.保存SToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.另存为AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.打印预览VToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.打印PToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.退出XToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.标签内容表格路径设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.模板路径设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑EToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.清空内容ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.撤消UToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.恢复RToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切TToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.复制CToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴PToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.全选AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.查找oolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.替换ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.关闭ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.打开OToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.剪切UToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.复制CToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.粘贴PToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.tf = new System.Windows.Forms.ToolStripComboBox();
            this.ts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBtnBold = new System.Windows.Forms.ToolStripButton();
            this.tSBtnItalic = new System.Windows.Forms.ToolStripButton();
            this.tSBtnUnderline = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.tSBtnLeft = new System.Windows.Forms.ToolStripButton();
            this.tSBtnCenter = new System.Windows.Forms.ToolStripButton();
            this.tSBtnRight = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ID输入";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(174, 67);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Location = new System.Drawing.Point(12, 96);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(589, 308);
            this.panel1.TabIndex = 3;
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem1,
            this.设置ToolStripMenuItem,
            this.编辑EToolStripMenuItem1,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(618, 29);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "菜单栏";
            // 
            // 文件FToolStripMenuItem1
            // 
            this.文件FToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripMenuItem1,
            this.打开OToolStripMenuItem1,
            this.toolStripSeparator9,
            this.保存SToolStripMenuItem1,
            this.另存为AToolStripMenuItem1,
            this.toolStripSeparator10,
            this.打印预览VToolStripMenuItem1,
            this.打印PToolStripMenuItem1,
            this.toolStripSeparator11,
            this.退出XToolStripMenuItem1});
            this.文件FToolStripMenuItem1.Name = "文件FToolStripMenuItem1";
            this.文件FToolStripMenuItem1.Size = new System.Drawing.Size(58, 21);
            this.文件FToolStripMenuItem1.Text = "文件(&F)";
            // 
            // 新建NToolStripMenuItem1
            // 
            this.新建NToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripMenuItem1.Image")));
            this.新建NToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripMenuItem1.Name = "新建NToolStripMenuItem1";
            this.新建NToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.新建NToolStripMenuItem1.Text = "新建(&N)";
            // 
            // 打开OToolStripMenuItem1
            // 
            this.打开OToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripMenuItem1.Image")));
            this.打开OToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripMenuItem1.Name = "打开OToolStripMenuItem1";
            this.打开OToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.打开OToolStripMenuItem1.Text = "打开(&O)";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(137, 6);
            // 
            // 保存SToolStripMenuItem1
            // 
            this.保存SToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripMenuItem1.Image")));
            this.保存SToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripMenuItem1.Name = "保存SToolStripMenuItem1";
            this.保存SToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.保存SToolStripMenuItem1.Text = "保存(&S)";
            // 
            // 另存为AToolStripMenuItem1
            // 
            this.另存为AToolStripMenuItem1.Name = "另存为AToolStripMenuItem1";
            this.另存为AToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.另存为AToolStripMenuItem1.Text = "另存为(&A)";
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(137, 6);
            // 
            // 打印预览VToolStripMenuItem1
            // 
            this.打印预览VToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("打印预览VToolStripMenuItem1.Image")));
            this.打印预览VToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印预览VToolStripMenuItem1.Name = "打印预览VToolStripMenuItem1";
            this.打印预览VToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.打印预览VToolStripMenuItem1.Text = "页面设置(&V)";
            // 
            // 打印PToolStripMenuItem1
            // 
            this.打印PToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripMenuItem1.Image")));
            this.打印PToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripMenuItem1.Name = "打印PToolStripMenuItem1";
            this.打印PToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.打印PToolStripMenuItem1.Text = "打印(&P)";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(137, 6);
            // 
            // 退出XToolStripMenuItem1
            // 
            this.退出XToolStripMenuItem1.Name = "退出XToolStripMenuItem1";
            this.退出XToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            this.退出XToolStripMenuItem1.Text = "退出(&X)";
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.标签内容表格路径设置ToolStripMenuItem,
            this.模板路径设置ToolStripMenuItem});
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.设置ToolStripMenuItem.Text = "设置(&S)";
            // 
            // 标签内容表格路径设置ToolStripMenuItem
            // 
            this.标签内容表格路径设置ToolStripMenuItem.Name = "标签内容表格路径设置ToolStripMenuItem";
            this.标签内容表格路径设置ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.标签内容表格路径设置ToolStripMenuItem.Text = "标签内容表格路径设置";
            this.标签内容表格路径设置ToolStripMenuItem.Click += new System.EventHandler(this.标签内容表格路径设置ToolStripMenuItem_Click);
            // 
            // 模板路径设置ToolStripMenuItem
            // 
            this.模板路径设置ToolStripMenuItem.Name = "模板路径设置ToolStripMenuItem";
            this.模板路径设置ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.模板路径设置ToolStripMenuItem.Text = "模板路径设置";
            this.模板路径设置ToolStripMenuItem.Click += new System.EventHandler(this.模板路径设置ToolStripMenuItem_Click);
            // 
            // 编辑EToolStripMenuItem1
            // 
            this.编辑EToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清空内容ToolStripMenuItem,
            this.toolStripSeparator20,
            this.撤消UToolStripMenuItem1,
            this.恢复RToolStripMenuItem1,
            this.toolStripSeparator12,
            this.剪切TToolStripMenuItem1,
            this.复制CToolStripMenuItem1,
            this.粘贴PToolStripMenuItem1,
            this.toolStripSeparator13,
            this.全选AToolStripMenuItem1,
            this.查找oolStripMenuItem,
            this.替换ToolStripMenuItem1,
            this.toolStripSeparator19,
            this.关闭ToolStripMenuItem2});
            this.编辑EToolStripMenuItem1.Name = "编辑EToolStripMenuItem1";
            this.编辑EToolStripMenuItem1.Size = new System.Drawing.Size(59, 21);
            this.编辑EToolStripMenuItem1.Text = "编辑(&E)";
            // 
            // 清空内容ToolStripMenuItem
            // 
            this.清空内容ToolStripMenuItem.Name = "清空内容ToolStripMenuItem";
            this.清空内容ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.清空内容ToolStripMenuItem.Text = "清空内容";
            // 
            // toolStripSeparator20
            // 
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            this.toolStripSeparator20.Size = new System.Drawing.Size(121, 6);
            // 
            // 撤消UToolStripMenuItem1
            // 
            this.撤消UToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("撤消UToolStripMenuItem1.Image")));
            this.撤消UToolStripMenuItem1.Name = "撤消UToolStripMenuItem1";
            this.撤消UToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.撤消UToolStripMenuItem1.Text = "撤消(&U)";
            // 
            // 恢复RToolStripMenuItem1
            // 
            this.恢复RToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("恢复RToolStripMenuItem1.Image")));
            this.恢复RToolStripMenuItem1.Name = "恢复RToolStripMenuItem1";
            this.恢复RToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.恢复RToolStripMenuItem1.Text = "恢复(&R)";
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(121, 6);
            // 
            // 剪切TToolStripMenuItem1
            // 
            this.剪切TToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("剪切TToolStripMenuItem1.Image")));
            this.剪切TToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切TToolStripMenuItem1.Name = "剪切TToolStripMenuItem1";
            this.剪切TToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.剪切TToolStripMenuItem1.Text = "剪切(&T)";
            // 
            // 复制CToolStripMenuItem1
            // 
            this.复制CToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("复制CToolStripMenuItem1.Image")));
            this.复制CToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripMenuItem1.Name = "复制CToolStripMenuItem1";
            this.复制CToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.复制CToolStripMenuItem1.Text = "复制(&C)";
            // 
            // 粘贴PToolStripMenuItem1
            // 
            this.粘贴PToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("粘贴PToolStripMenuItem1.Image")));
            this.粘贴PToolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripMenuItem1.Name = "粘贴PToolStripMenuItem1";
            this.粘贴PToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.粘贴PToolStripMenuItem1.Text = "粘贴(&P)";
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(121, 6);
            // 
            // 全选AToolStripMenuItem1
            // 
            this.全选AToolStripMenuItem1.Name = "全选AToolStripMenuItem1";
            this.全选AToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.全选AToolStripMenuItem1.Text = "全选(&A)";
            // 
            // 查找oolStripMenuItem
            // 
            this.查找oolStripMenuItem.Name = "查找oolStripMenuItem";
            this.查找oolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.查找oolStripMenuItem.Text = "查找";
            // 
            // 替换ToolStripMenuItem1
            // 
            this.替换ToolStripMenuItem1.Name = "替换ToolStripMenuItem1";
            this.替换ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.替换ToolStripMenuItem1.Text = "替换";
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            this.toolStripSeparator19.Size = new System.Drawing.Size(121, 6);
            // 
            // 关闭ToolStripMenuItem2
            // 
            this.关闭ToolStripMenuItem2.Name = "关闭ToolStripMenuItem2";
            this.关闭ToolStripMenuItem2.Size = new System.Drawing.Size(124, 22);
            this.关闭ToolStripMenuItem2.Text = "关闭";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助HToolStripMenuItem1,
            this.关于本程序ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于ToolStripMenuItem.Text = "关于(&A)";
            // 
            // 帮助HToolStripMenuItem1
            // 
            this.帮助HToolStripMenuItem1.Name = "帮助HToolStripMenuItem1";
            this.帮助HToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.帮助HToolStripMenuItem1.Text = "帮助(&H)";
            // 
            // 关于本程序ToolStripMenuItem
            // 
            this.关于本程序ToolStripMenuItem.Name = "关于本程序ToolStripMenuItem";
            this.关于本程序ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.关于本程序ToolStripMenuItem.Text = "关于本程序(&A)";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开OToolStripButton1,
            this.保存SToolStripButton1,
            this.打印PToolStripButton1,
            this.toolStripSeparator15,
            this.剪切UToolStripButton1,
            this.复制CToolStripButton1,
            this.粘贴PToolStripButton1,
            this.toolStripSeparator16,
            this.tf,
            this.ts,
            this.toolStripSeparator14,
            this.tSBtnBold,
            this.tSBtnItalic,
            this.tSBtnUnderline,
            this.toolStripSeparator17,
            this.tSBtnLeft,
            this.tSBtnCenter,
            this.tSBtnRight});
            this.toolStrip1.Location = new System.Drawing.Point(0, 29);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "工具栏";
            // 
            // 打开OToolStripButton1
            // 
            this.打开OToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打开OToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripButton1.Image")));
            this.打开OToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripButton1.Name = "打开OToolStripButton1";
            this.打开OToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.打开OToolStripButton1.Text = "打开(&O)";
            this.打开OToolStripButton1.Click += new System.EventHandler(this.打开OToolStripButton1_Click);
            // 
            // 保存SToolStripButton1
            // 
            this.保存SToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.保存SToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton1.Image")));
            this.保存SToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton1.Name = "保存SToolStripButton1";
            this.保存SToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.保存SToolStripButton1.Text = "保存(&S)";
            // 
            // 打印PToolStripButton1
            // 
            this.打印PToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.打印PToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton1.Image")));
            this.打印PToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton1.Name = "打印PToolStripButton1";
            this.打印PToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.打印PToolStripButton1.Text = "打印(&P)";
            this.打印PToolStripButton1.Click += new System.EventHandler(this.打印PToolStripButton1_Click);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            this.toolStripSeparator15.Size = new System.Drawing.Size(6, 25);
            // 
            // 剪切UToolStripButton1
            // 
            this.剪切UToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.剪切UToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("剪切UToolStripButton1.Image")));
            this.剪切UToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切UToolStripButton1.Name = "剪切UToolStripButton1";
            this.剪切UToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.剪切UToolStripButton1.Text = "剪切(&U)";
            // 
            // 复制CToolStripButton1
            // 
            this.复制CToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.复制CToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("复制CToolStripButton1.Image")));
            this.复制CToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripButton1.Name = "复制CToolStripButton1";
            this.复制CToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.复制CToolStripButton1.Text = "复制(&C)";
            // 
            // 粘贴PToolStripButton1
            // 
            this.粘贴PToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.粘贴PToolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("粘贴PToolStripButton1.Image")));
            this.粘贴PToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripButton1.Name = "粘贴PToolStripButton1";
            this.粘贴PToolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.粘贴PToolStripButton1.Text = "粘贴(&P)";
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(6, 25);
            // 
            // tf
            // 
            this.tf.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.tf.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tf.Name = "tf";
            this.tf.Size = new System.Drawing.Size(140, 25);
            this.tf.SelectedIndexChanged += new System.EventHandler(this.tf_SelectedIndexChanged);
            // 
            // ts
            // 
            this.ts.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.ts.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ts.Name = "ts";
            this.ts.Size = new System.Drawing.Size(140, 25);
            this.ts.SelectedIndexChanged += new System.EventHandler(this.ts_SelectedIndexChanged);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(6, 25);
            // 
            // tSBtnBold
            // 
            this.tSBtnBold.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnBold.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnBold.Image")));
            this.tSBtnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnBold.Name = "tSBtnBold";
            this.tSBtnBold.Size = new System.Drawing.Size(23, 22);
            this.tSBtnBold.Text = "加粗";
            // 
            // tSBtnItalic
            // 
            this.tSBtnItalic.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnItalic.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnItalic.Image")));
            this.tSBtnItalic.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnItalic.Name = "tSBtnItalic";
            this.tSBtnItalic.Size = new System.Drawing.Size(23, 22);
            this.tSBtnItalic.Text = "倾斜";
            // 
            // tSBtnUnderline
            // 
            this.tSBtnUnderline.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnUnderline.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnUnderline.Image")));
            this.tSBtnUnderline.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnUnderline.Name = "tSBtnUnderline";
            this.tSBtnUnderline.Size = new System.Drawing.Size(23, 22);
            this.tSBtnUnderline.Text = "下划线";
            // 
            // toolStripSeparator17
            // 
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            this.toolStripSeparator17.Size = new System.Drawing.Size(6, 25);
            // 
            // tSBtnLeft
            // 
            this.tSBtnLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnLeft.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnLeft.Image")));
            this.tSBtnLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnLeft.Name = "tSBtnLeft";
            this.tSBtnLeft.Size = new System.Drawing.Size(23, 22);
            this.tSBtnLeft.Text = "左对齐";
            // 
            // tSBtnCenter
            // 
            this.tSBtnCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnCenter.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnCenter.Image")));
            this.tSBtnCenter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnCenter.Name = "tSBtnCenter";
            this.tSBtnCenter.Size = new System.Drawing.Size(23, 22);
            this.tSBtnCenter.Text = "居中";
            // 
            // tSBtnRight
            // 
            this.tSBtnRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSBtnRight.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnRight.Image")));
            this.tSBtnRight.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnRight.Name = "tSBtnRight";
            this.tSBtnRight.Size = new System.Drawing.Size(23, 22);
            this.tSBtnRight.Text = "右对齐";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 416);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.PrintDialog printDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 新建NToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打开OToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem 保存SToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 另存为AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.ToolStripMenuItem 打印预览VToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 打印PToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 标签内容表格路径设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑EToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 清空内容ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator20;
        private System.Windows.Forms.ToolStripMenuItem 撤消UToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 恢复RToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator12;
        private System.Windows.Forms.ToolStripMenuItem 剪切TToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 复制CToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 粘贴PToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator13;
        private System.Windows.Forms.ToolStripMenuItem 全选AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 查找oolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 替换ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator19;
        private System.Windows.Forms.ToolStripMenuItem 关闭ToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于本程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton1;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton1;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator15;
        private System.Windows.Forms.ToolStripButton 剪切UToolStripButton1;
        private System.Windows.Forms.ToolStripButton 复制CToolStripButton1;
        private System.Windows.Forms.ToolStripButton 粘贴PToolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator16;
        private System.Windows.Forms.ToolStripComboBox tf;
        private System.Windows.Forms.ToolStripComboBox ts;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator14;
        private System.Windows.Forms.ToolStripButton tSBtnBold;
        private System.Windows.Forms.ToolStripButton tSBtnItalic;
        private System.Windows.Forms.ToolStripButton tSBtnUnderline;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator17;
        private System.Windows.Forms.ToolStripButton tSBtnLeft;
        private System.Windows.Forms.ToolStripButton tSBtnCenter;
        private System.Windows.Forms.ToolStripButton tSBtnRight;
        private System.Windows.Forms.ToolStripMenuItem 模板路径设置ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

