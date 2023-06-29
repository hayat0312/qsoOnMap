using System;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace qsoOnMap
{
    public partial class Form2 : Form
    {
        Form1 fm1;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(Form1 fm)
        {
            InitializeComponent();
            fm1 = fm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            fm1.tableLayoutPanel2.Enabled = true;
            this.Close();
        }
    }
}
