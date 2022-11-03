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
    public partial class EditData : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public EditData()
        {
            InitializeComponent();
        }

        private void NewSale_Load(object sender, EventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string nam = txtname.Text.ToString();

            mobile mb = db.mobiles.Where(m => m.name == nam).FirstOrDefault();
            try
            {
                if(mb != null)
                {
                    /*dgvnewpurchase.Rows.Add(mb.code, mb.name, mb.price, mb.quantity, mb.company);*/
                    lblID.Text = mb.id.ToString();
                    txtcode.Text = mb.code.ToString();
                    txtcode.Enabled = false;
                    txtprice.Text = mb.price.ToString();
                    txtquantity.Text = mb.quantity.ToString();
                    txtcompany.Text = mb.company.ToString();
                }
                else
                {
                    MessageBox.Show("Mobile not found");
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            int mobId = int.Parse(lblID.Text.ToString());
            int mobQuan = int.Parse(txtquantity.Text);

            mobile mb = db.mobiles.Where(s => s.id == mobId).FirstOrDefault();
            mb.quantity = mb.quantity - mobQuan;
            db.SaveChanges();

            sell sl = new sell();

            sl.name = txtname.Text;
            sl.code = int.Parse(txtcode.Text.ToString());
            sl.price = int.Parse(txtprice.Text.ToString());
            sl.quantity = mobQuan;
            sl.company = txtcompany.Text;
            sl.mid = mobId;

            if (int.Parse(txtquantity.Text) > mobQuan)
            {
                MessageBox.Show("Only " + mobQuan + " mobiles are available");
            }
            else
            {
                db.sells.Add(sl);
                db.SaveChanges();
                MessageBox.Show("Inserted Successfully");
            }
        }
    }
}
