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
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助HToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于本程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.打开OToolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton1 = new System.Windows.Forms.ToolStripButton();
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
            this.button2.Text = "插入CE";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.打印PToolStripButton1});
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
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助HToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 关于本程序ToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton1;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton1;
        private System.Windows.Forms.ToolStripMenuItem 模板路径设置ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

