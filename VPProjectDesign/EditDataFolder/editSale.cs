using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectDesign.EditDataFolder
{
    public partial class editSale : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public editSale()
        {
            InitializeComponent();
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text.ToString());
            //txtname.Enabled = false;

            sell mb = db.sells.Where(s => s.id == id).FirstOrDefault();

            lblID.Text = mb.id.ToString();
            txtcode.Text = mb.code.ToString();
            txtname.Text = mb.name.ToString();
            txtprice.Text = mb.price.ToString();
            txtquantity.Text = mb.quantity.ToString();
            txtcompany.Text = mb.company.ToString();
        }

        private void btneditsale_Click(object sender, EventArgs e)
        {
            int id  = int.Parse(lblID.Text.ToString());
            sell sl = db.sells.Where(s => s.id == id).FirstOrDefault();
            sl.id = int.Parse(lblID.Text.ToString());
            sl.code = int.Parse(txtcode.Text.ToString());
            sl.name = txtname.Text.ToString();
            sl.price =  int.Parse(txtprice.Text);
            sl.quantity = int.Parse(txtquantity.Text.ToString());
            sl.company = txtcompany.Text.ToString();

            db.SaveChanges();
            MessageBox.Show("Edited Successfully");
        }
    }
}
