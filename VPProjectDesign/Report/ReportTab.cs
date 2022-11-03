using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectDesign.Report
{
    public partial class ReportTab : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public ReportTab()
        {
            InitializeComponent();
        }

        private void btneditsale_Click(object sender, EventArgs e)
        {
            int quan = 0;
            var v = db.sells.Select(s => s);

            foreach (var item in v)
            {
                quan += int.Parse(item.quantity.ToString());
            }
            MessageBox.Show("Total Mobiles Sold are: " + quan);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int quan = 0;
            var v = db.mobiles.Select(s => s);

            foreach (var item in v)
            {
                quan += int.Parse(item.quantity.ToString());
            }
            MessageBox.Show("Total Mobiles Purchased are: " + quan);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int tot = 0;
            var v = db.mobiles.Select(s => s);

            foreach (var item in v)
            {
                tot += (int.Parse(item.price.ToString()) / 100)*10;
            }
            MessageBox.Show("Total Earning are: " + tot);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            HomePage hp = new HomePage();
            hp.Show();

            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int tot = 0;
            var v = db.mobiles.Select(s => s);
            foreach (var item in v)
            {
                if(item.Date != null)
                {
                    int month = int.Parse(item.Date.Split('/')[1]);

                    if (month == 1)
                    {
                        tot += int.Parse(item.quantity.ToString());
                    }
                }
            }
            MessageBox.Show("Total Quantity Sold: " + tot);
        }
    }
}
