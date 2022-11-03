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
    public partial class editPurchase : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public editPurchase()
        {
            InitializeComponent();
        }

        private void btneditsale_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblID.Text.ToString());
            mobile mb = db.mobiles.Where(s => s.id == id).FirstOrDefault();
            mb.id = int.Parse(lblID.Text.ToString());
            mb.code = int.Parse(txtcode.Text.ToString());
            mb.price = float.Parse(txtprice.Text);
            mb.quantity = int.Parse(txtquantity.Text.ToString());
            mb.company = txtcompany.Text.ToString();

            db.SaveChanges();
            MessageBox.Show("Edited Successfully");
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string name = txtname.Text;
            //txtname.Enabled = false;

            mobile mb = db.mobiles.Where(s => s.name == name).FirstOrDefault();

            lblID.Text = mb.id.ToString();
            txtcode.Text = mb.code.ToString();
            txtprice.Text = mb.price.ToString();
            txtquantity.Text = mb.quantity.ToString();
            txtcompany.Text = mb.company.ToString();
        }
    }
}
