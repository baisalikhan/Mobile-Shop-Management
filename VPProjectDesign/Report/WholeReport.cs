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
    public partial class WholeReport : Form
    {
        VPSemProjectEntities db = new VPSemProjectEntities();
        int min = 0;
        int minyear = 0;
        int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        string[] arr2 = { "Jan", "Feb", "March", "April", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
        public WholeReport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int []arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            string []arr2 = { "Jan", "Feb", "March", "April", "May", "Jun", "July", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int[] yearArr = { 2019, 2020, 2021, 2022 };

            int[] yearprofit = { 0, 0, 0, 0};

            for(int j=0; j<4; j++)
            {
                for (int i = 0; i < 12; i++)
                {
                    int totsold = 0, totprofit = 0;
                    var v = db.mobiles.Select(s => s);
                    foreach (var item in v)
                    {
                        if (item.Date != null)
                        {
                            int month = int.Parse(item.Date.Split('/')[1]);
                            int year = int.Parse(item.Date.Split('/')[2]);

                            if(year == yearArr[j])
                            {
                                if (month == arr1[i])
                                {
                                    totsold += int.Parse(item.quantity.ToString());
                                    totprofit += ((int.Parse(item.price.ToString()) / 100) * 10);
                                }
                                
                            }
                        }
                    }
                    yearprofit[j] += totprofit;
                    dataGridView1.Rows.Add(yearArr[j], arr1[i] + " " + arr2[i], totsold, totprofit);
                }
            }

            min = yearprofit[0];

            for (int k = 0; k < 4; k++)
            {
                if (min > yearprofit[k])
                {
                    min = yearprofit[k];
                    minyear = yearArr[k];
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 12; i++)
            {
                int totsold = 0, totprofit = 0;
                var v = db.mobiles.Select(s => s);
                foreach (var item in v)
                {
                    if (item.Date != null)
                    {
                        int month = int.Parse(item.Date.Split('/')[1]);
                        int year = int.Parse(item.Date.Split('/')[2]);

                        if (year == minyear)
                        {
                            if (month == arr1[i])
                            {
                                totsold += int.Parse(item.quantity.ToString());
                                totprofit += ((int.Parse(item.price.ToString()) / 100) * 10);
                            }
                        }
                    }
                }
                dataGridView2.Rows.Add(minyear, arr1[i] + " " + arr2[i], totsold, totprofit);


            }
        }
    }
}
