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
    public partial class Form1 : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {

            /*string name = txtname.Text;
            string password = txtpassword.Text;

            userTable uT = db.userTables.Where(s => s.name == name && s.password == password).FirstOrDefault();
            if(uT != null)
            {*/
                HomePage hp = new HomePage();
                hp.Show();
                this.Hide();
            /*}
            else
            {
                MessageBox.Show("Invalid Input");
            }*/
            
        }
    }
}
