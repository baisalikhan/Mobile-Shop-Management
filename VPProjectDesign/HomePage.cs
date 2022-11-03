using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using VPProjectDesign.Report;

namespace VPProjectDesign
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EditDataTab eD = new EditDataTab();
            eD.Show();

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewData aNd = new AddNewData();
            aNd.Show();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReportTab et = new ReportTab();
            et.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            WholeReport wr = new WholeReport();
            wr.Show();
        }
    }
}
