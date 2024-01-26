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

            panel3.Height = panel5.Height = (this.Height - (panel1.Height + panel2.Height))/2;


            //panel1 
            panel6.Width = panel7.Width = panel8.Width = this.Width / 3;

            panel17.Height = panel18.Height = panel19.Height = panel20.Height = Convert.ToInt32(0.15 * panel9.Height);


            //Panel3
            panel9.Width = panel10.Width = panel11.Width = panel15.Width = this.Width / 3;
            panel12.Height = panel13.Height = panel14.Height = panel16.Height = Convert.ToInt32(panel3.Height * 0.1);
            flowLayoutPanel1.Width = (panel5.Width - panel15.Width);

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
        
        public async void Regenerate()
        {
            dynamic results = await Handlers.Fetch(Env.live_url + "/GetExpenditureCategories");

            if (results != null)
            {

                dt1.Rows.Clear(); comboBox1.Items.Clear(); comboBox1.Items.Add("All");
                dt2.Rows.Clear(); comboBox2.Items.Clear(); comboBox2.Items.Add("All");
                dt3.Rows.Clear(); comboBox3.Items.Clear(); comboBox3.Items.Add("All");
                dt4.Rows.Clear(); comboBox4.Items.Clear(); comboBox4.Items.Add("All");


                foreach (dynamic result in results["items"])
                {
                    string overall_category = result.Overall_category;

                    //Filling in the expenditure category in the combobox
                    string dynamicComboBoxName = "comboBox" + overall_category; // Assuming value is a string variable
                    ComboBox dynamicComboBox = Controls.Find(dynamicComboBoxName, true).FirstOrDefault() as ComboBox;
                    
                    if (dynamicComboBox != null)
                    {
                        dynamicComboBox.Items.Add(result.Name);
                    }

                    //Filling in expenditures in the datagrid view
                    
                    foreach(dynamic expenditure in result["expenditures"])
                    {
                        getDataTable(overall_category).Rows.Add(
                            result.Name,
                            "shs. " + expenditure.Amount.ToString("N0"),
                            expenditure.Description,
                            expenditure.Date_added
                        );
                    }



                }

                dgv1.DataSource = dt1;
                dgv2.DataSource = dt2;
                dgv3.DataSource = dt3;
                dgv4.DataSource = dt4;

                dynamic meta_data = await Handlers.Fetch(Env.live_url + "/GetExpenditures");

                if (meta_data != null)
                {
                    Total.Text = "TOTAL " + "shs." + (meta_data["meta_data"].query_total_expenditure).ToString("N0") + " / shs. " + (meta_data["meta_data"].total_expenditure).ToString("N0");
                }



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
    }
}
