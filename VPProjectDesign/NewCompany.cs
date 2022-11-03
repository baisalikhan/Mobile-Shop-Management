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
    public partial class NewCompany : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public NewCompany()
        {
            InitializeComponent();
        }

        private void btnaddcompany_Click(object sender, EventArgs e)
        {
            company comp = new company();
            comp.Company1 = txtname.Text;

            db.companies.Add(comp);
            db.SaveChanges();
            MessageBox.Show("Inserted Successfully");
            //txtname.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            string newName = txtMname.Text;
            company comp = db.companies.Where(s => s.id == id).FirstOrDefault();
            comp.Company1 = newName;
            db.SaveChanges();
            MessageBox.Show("Updated Successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);

            company comp = db.companies.Where(c => c.id == id).FirstOrDefault();
            db.companies.Remove(comp);
            db.SaveChanges();

            MessageBox.Show("Deleted Successfully");
        }

        private void btnsearchbyID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            txtid.Enabled = false;

            company comp = db.companies.Where(s => s.id == id).FirstOrDefault();

            txtMname.Text = comp.Company1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string name = txtMname.Text;
            txtid.Enabled = false;

            company comp = db.companies.Where(s => s.Company1 == name).FirstOrDefault();

            txtid.Text = comp.id.ToString();
        }
    }
}
