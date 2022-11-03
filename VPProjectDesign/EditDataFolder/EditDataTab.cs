using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using VPProjectDesign.EditDataFolder;

namespace VPProjectDesign
{
    public partial class EditDataTab : Form
    {
        public EditDataTab()
        {
            InitializeComponent();
        }

        private void EditDataTab_Load(object sender, EventArgs e)
        {

        }

        private void editsale_Click(object sender, EventArgs e)
        {
            editSale es = new editSale();
            es.Show();
        }

        private void editcompany_Click(object sender, EventArgs e)
        {
            
        }

        private void editpurchase_Click(object sender, EventArgs e)
        {
            editPurchase eP = new editPurchase();
            eP.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            HomePage edt = new HomePage();
            edt.Show();

            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage edt = new HomePage();
            edt.Show();

            this.Close();
        }
    }
}
