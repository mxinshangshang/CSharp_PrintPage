using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrintPage
{
    public partial class IDlogin : Form
    {
        public string id = null;
        public Form1 form = null;

        public IDlogin()
        {
            InitializeComponent();
        }

        public void GetForm(Form1 theform)
        {
            form = theform;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.id = textBox1.Text;
            //form.id = "59401210";
            this.Close();
        }
    }
}
