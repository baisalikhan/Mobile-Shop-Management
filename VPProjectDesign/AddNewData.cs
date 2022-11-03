using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectDesign
{
    public partial class AddNewData : Form
    {
        public AddNewData()
        {
            InitializeComponent();
        }

        private void addnew_Click(object sender, EventArgs e)
        {
            NewPurchase np = new NewPurchase();
            np.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditData ns = new EditData();
            ns.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            EditData ns = new EditData();
            ns.Show();
        }

        private void NewPurchase_Click(object sender, EventArgs e)
        {
            NewPurchase np = new NewPurchase();
            np.Show();
        }

        private void editdata_Click(object sender, EventArgs e)
        {
            NewCompany nc = new NewCompany();
            nc.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();

            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();

            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            NewCompany nc = new NewCompany();
            nc.Show();
        }

        private void AddNewData_Load(object sender, EventArgs e)
        {

        }
    }
}
