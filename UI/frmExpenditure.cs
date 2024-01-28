using KAMM_FARM_SERVICES.UI.ExpenditureForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.Helpers;
using KAMM_FARM_SERVICES.Schema.ExpendituresSchema;
using Newtonsoft.Json;
using KAMM_FARM_SERVICES.Schema;
using System.Globalization;
using KAMM_FARM_SERVICES.Components;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class frmExpenditure : Form
    {

        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();

        public frmExpenditure()
        {
            InitializeComponent();

            dt1.Columns.Add("Name");
            dt1.Columns.Add("Amount");
            dt1.Columns.Add("Description");
            dt1.Columns.Add("Date");

            dt2.Columns.Add("Name");
            dt2.Columns.Add("Amount");
            dt2.Columns.Add("Description");
            dt2.Columns.Add("Date");

            dt3.Columns.Add("Name");
            dt3.Columns.Add("Amount");
            dt3.Columns.Add("Description");
            dt3.Columns.Add("Date");

            dt4.Columns.Add("Name");
            dt4.Columns.Add("Amount");
            dt4.Columns.Add("Description");
            dt4.Columns.Add("Date");

            //dt1 = dt2 = dt3 = dt4 = dt.Clone();

        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmExpenditure_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Height = Convert.ToInt32(0.1 * this.Height);
            panel2.Height = panel4.Height = Convert.ToInt32(0.1 * this.Height) / 2;

            panel3.Height = panel5.Height = ((this.Height - (panel1.Height + panel2.Height))/2) - Convert.ToInt32(0.03 * this.Height);


            //panel1 
            panel6.Width = panel7.Width = panel8.Width = this.Width / 3;

            panel17.Height = panel18.Height = panel19.Height = panel20.Height = Convert.ToInt32(0.15 * panel9.Height);


            //Panel3
            panel9.Width = panel10.Width = panel11.Width = panel15.Width = this.Width / 3;
            panel12.Height = panel13.Height = panel14.Height = panel16.Height = Convert.ToInt32(panel3.Height * 0.1);
            
            flowLayoutPanel1.Width = (this.Width - panel15.Width);
            panel28.Height = panel31.Height = panel34.Height = panel37.Height = Convert.ToInt32(panel5.Height * 0.85);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(1 , this);
            form.Show();
        }

        private DataTable getDataTable(string cat)
        {
            switch (cat)
            {
                case "1":
                    return dt1;

                case "2":
                    return dt2;

                case "3":
                    return dt3;

                default:
                    return dt4;

            }
        }

        private async Task<ExpenditureX> populateExpenditures(int overall_category , int category)
        {
            var expenditures_content = await Handlers.Fetch(
                Env.live_url + "/GetExpenditures?overall_category=" + overall_category
                + ((category != 0)?("&category=" + category):(""))

                , false
            );

            ExpenditureX expenditures_info = JsonConvert.DeserializeObject<ExpenditureX>(expenditures_content);

            getDataTable(overall_category.ToString()).Rows.Clear();

            foreach (Expenditure expenditure in expenditures_info.items)
            {
                getDataTable(overall_category.ToString()).Rows.Add(
                    expenditure.Category.Name,
                    "shs. " + expenditure.Amount.ToString("N0"),
                    expenditure.Description,
                    expenditure.Date_added
                );
            }

            string exp = "exp_" + overall_category; // Assuming value is a string variable
            Label? exp_o = Controls.Find(exp, true).FirstOrDefault() as Label;

            string prev = "prev_" + overall_category; // Assuming value is a string variable
            Label? prev_o = Controls.Find(prev, true).FirstOrDefault() as Label;

            string next = "next_" + overall_category; // Assuming value is a string variable
            Label? next_o = Controls.Find(next, true).FirstOrDefault() as Label;

            string pag = "pag_" + overall_category; // Assuming value is a string variable
            Label? pag_o = Controls.Find(pag, true).FirstOrDefault() as Label;

            string dgv = "dgv" + overall_category;
            DGV? dgv_o = Controls.Find(dgv, true).FirstOrDefault() as DGV;


            dgv_o.DataSource = getDataTable(overall_category.ToString());

            exp_o.Text = "shs. " + expenditures_info.meta_data.query_total_expenditure?.ToString("N0") + " / " + "shs. " + expenditures_info.meta_data.total_expenditure?.ToString("N0") ?? "N/A";
            prev_o.Text = (expenditures_info.pagination.previous == null) ? ("") : ("<");
            next_o.Text = (expenditures_info.pagination.next == null) ? ("") : (">");
            pag_o.Text = expenditures_info.pagination.page.ToString() + " of " + expenditures_info.pagination.pages.ToString();






            return expenditures_info;
        }
        
        public async void Regenerate()
        {
            var content = await Handlers.Fetch(Env.live_url + "/GetExpenditureCategories" , false);


            if (content != null)
            {

                ExpenditureCategoryX results = JsonConvert.DeserializeObject<ExpenditureCategoryX>(content);


                comboBox1.DataSource = null; List<ExpenditureCategory> cat_1 = new List<ExpenditureCategory> { }; 
                comboBox2.DataSource = null; comboBox2.Items.Add("All"); List<ExpenditureCategory> cat_2 = new List<ExpenditureCategory> { };
                comboBox3.DataSource = null; comboBox3.Items.Add("All"); List<ExpenditureCategory> cat_3 = new List<ExpenditureCategory> { };
                comboBox4.DataSource = null; comboBox4.Items.Add("All"); List<ExpenditureCategory> cat_4 = new List<ExpenditureCategory> { };

                //Filling in the All option in the combo box
                ExpenditureCategory all_option = new ExpenditureCategory();
                all_option.Name = "All";
                all_option.id = 0;

                cat_1.Add(all_option);
                cat_2.Add(all_option);
                cat_3.Add(all_option);
                cat_4.Add(all_option);

                foreach (ExpenditureCategory result in results.items)
                {
                    string? overall_category = result.Overall_category;

                    //Filling in the expenditure category in the combobox
                    //string dynamicComboBoxName = "comboBox" + overall_category; // Assuming value is a string variable
                    //ComboBox dynamicComboBox = Controls.Find(dynamicComboBoxName, true).FirstOrDefault() as ComboBox;

                    //if (dynamicComboBox != null)
                    //{
                    //    //dynamicComboBox.Items.Add(result.Name);


                    //}

                    if (result.Overall_category == "1")
                    {
                        cat_1.Add(result);


                    }
                    else if (result.Overall_category == "2")
                    {
                        cat_2.Add(result);

                    }else if (result.Overall_category == "3")
                    {
                        cat_3.Add(result);
                    }
                    else
                    {
                        cat_4.Add(result);
                    }



                    



                }

                int total_expenditure = 0;

                //MessageBox.Show(cat_1[0].Name.ToString());
                

                //ExpenditureX  x_1 = await populateExpenditures(1 , 0);
                //exp_1.Text = 
                //dgv1.DataSource = dt1;
              
                comboBox1.DisplayMember = "Name";
                comboBox1.ValueMember = "id";
                comboBox1.DataSource = cat_1;




                //ExpenditureX x_2 = await populateExpenditures(2 , 0);
                //dgv2.DataSource = dt2;
                comboBox2.DisplayMember = "Name";
                comboBox2.ValueMember = "id";
                comboBox2.DataSource = cat_2;


                //ExpenditureX x_3 = await populateExpenditures(3 , 0);
                //dgv3.DataSource = dt3;
                comboBox3.DisplayMember = "Name";
                comboBox3.ValueMember = "id";
                comboBox3.DataSource = cat_3;


                //ExpenditureX x_4 = await populateExpenditures(4 , 0);
                //dgv4.DataSource = dt4;
                comboBox4.DisplayMember = "Name";
                comboBox4.ValueMember = "id";
                comboBox4.DataSource = cat_4;




                //Int64? f = x_1.meta_data.total_expenditure;
                //Total.Text = "TOTAL " + "shs." + x_1.meta_data.total_expenditure?.ToString("N0") ?? "N/A";
                
                

            }
        }

        private void frmExpenditure_Load(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(2 , this);
            form.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(3, this);
            form.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(4, this);
            form.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgv2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ExpenditureX exp = await populateExpenditures(1, Convert.ToInt32(comboBox1.SelectedValue));

        }

        private async void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            ExpenditureX exp = await populateExpenditures(2, Convert.ToInt32(comboBox2.SelectedValue));

        }

        private async void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExpenditureX exp = await populateExpenditures(3, Convert.ToInt32(comboBox3.SelectedValue));

        }

        private async void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            ExpenditureX exp = await populateExpenditures(4, Convert.ToInt32(comboBox4.SelectedValue));

        }
    }
}
