using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPProjectDesign
{
    public partial class NewPurchase : Form
    {
        static string dbpath = @"Data Source=LAPTOP-64P7I224;Initial Catalog=VPSemProject;Integrated Security=True";
        SqlConnection con = new SqlConnection(dbpath);

        VPSemProjectEntities db = new VPSemProjectEntities();
        public NewPurchase()
        {
            InitializeComponent();
        }

        private void NewPurchase_Load(object sender, EventArgs e)
        {
            /*populatedataGridView();*/
            populateComboBox();
            giveSuggestion();
            /*styleDatagridView();*/
        }

        /*void populatedataGridView()
        {
            dgvnewpurchase.Rows.Add(1, "Oppo", "12000", 27);
            dgvnewpurchase.Rows.Add(2, "Techno", "24000", 22);
            dgvnewpurchase.Rows.Add(3, "Iphone", "42000", 19);
            dgvnewpurchase.Rows.Add(4, "Mi", "52000", 12);
        }*/

        void giveSuggestion()
        {
            int []quanArr = { 0, 0 , 0};
            string[] CompanyArr = { "Redmi", "Xiomi", "Nokia"};
            var v = db.mobiles.Select(s => s);

            for(int i = 0; i < 3; i++)
            {
                foreach (var item in v)
                {
                    if (item.company == CompanyArr[i])
                    {
                        quanArr[i] += int.Parse(item.quantity.ToString());
                    }
                }
            }

            int max = quanArr[0];
            string company = CompanyArr[0];

            for(int i = 0; i<3; i++)
            {
                if (max < quanArr[i])
                {
                    max = quanArr[i];
                    company = CompanyArr[i];
                }
            }

            lblsuggested.Text = company;

        }
        void populateComboBox()
        {
            con.Open();

            string query = "Select * from company";

            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader sdr = cmd.ExecuteReader();
            

            while (sdr.Read())
            {
                cmbxCompany.Items.Add(sdr[1]);
            }
            con.Close();
        }
        
        void styleDatagridView()
        {
            /*dgvnewpurchase.BorderStyle = BorderStyle.None;
            dgvnewpurchase.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(0, 70, 97, 1);
            dgvnewpurchase.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvnewpurchase.DefaultCellStyle.SelectionBackColor = Color.SeaGreen;
            dgvnewpurchase.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgvnewpurchase.BackgroundColor = Color.FromArgb(30, 30, 30);
            dgvnewpurchase.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvnewpurchase.EnableHeadersVisualStyles = false;
            dgvnewpurchase.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvnewpurchase.ColumnHeadersDefaultCellStyle.Font = new Font("MS Reference Sans Serif", 10);
            dgvnewpurchase.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(37, 37, 38);
            dgvnewpurchase.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToShortDateString();

            string compani = cmbxCompany.SelectedItem.ToString();
            
            

            dgvnewpurchase.Rows.Add(txtcode.Text, txtname.Text, txtprice.Text, txtquantity.Text, compani, date);
        }

        private void dgvnewpurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            mobile mb = new mobile();



            foreach(DataGridViewRow row in dgvnewpurchase.SelectedRows)
            { 

                mb.code = int.Parse(row.Cells[0].Value.ToString());
                mb.name = row.Cells[1].Value.ToString();
                mb.price = float.Parse(row.Cells[2].Value.ToString());
                mb.quantity = int.Parse(row.Cells[3].Value.ToString());
                mb.company = row.Cells[4].Value.ToString();
                mb.Date = row.Cells[5].Value.ToString();


                db.mobiles.Add(mb);
                db.SaveChanges();
            }
            MessageBox.Show("Inserted Successfully");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
