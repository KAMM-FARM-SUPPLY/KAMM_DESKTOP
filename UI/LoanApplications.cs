using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.DAL;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class LoanApplications : Form
    {

        DataTable LoanDT = new DataTable();

        dynamic Locations = null;
        dynamic farmers = null;
        dynamic current_Loan_applications = null;

        public LoanApplications()
        {
            InitializeComponent();

            LoanDT.Columns.Add("Select" , typeof(bool));
            LoanDT.Columns.Add("Status", typeof(Image));
            LoanDT.Columns.Add("Names");
            LoanDT.Columns.Add("Phone");
            LoanDT.Columns.Add("Total Amount");
            LoanDT.Columns.Add("Balance Due");
            LoanDT.Columns.Add("Products Count");
            LoanDT.Columns.Add("Collateral Count");
            LoanDT.Columns.Add("Date Created");
        }


        private void populate_LoanDT(dynamic LoanApplications)
        {
            current_Loan_applications = LoanApplications;

            LoanDT.Rows.Clear();
            if (LoanApplications != null)
            {
                foreach (dynamic dt in LoanApplications)
                {
                    LoanDT.Rows.Add(
                        false,
                        bool.Parse(Convert.ToString(dt.Active)) ?
                        (Properties.Resources.tasks) :
                        (Properties.Resources.hour_glass),

                        dt.Name + " " + dt.Given_name,
                        dt.farmer.Phone_number,
                        dt.Total_cost,
                        dt.Balance,
                        dt.Products.Count,
                        dt.Collateral.Count,
                        dt.Date_added
                        );

                }

                LoanApps.DataSource = LoanDT;
            }
            
        }

        public int convert_to_id(string name)
        {
            foreach(dynamic farmer in farmers)
            {
                var Name = Convert.ToString(farmer.Name) + " " + Convert.ToString(farmer.Given_name);

                if (Name == name)
                {
                    return Convert.ToInt32(farmer.id);
                }
            }

            return 0;
        }


        public async void Regenerate()
        {

            LoanApplicationsDAL app = new LoanApplicationsDAL();
            dynamic results = await app.QueryFarmerLoans(
                    false,
                    convert_to_id(farmer_cb.Text),
                    status_cb.Text.Trim(),
                    district_cb.Text.Trim(),
                    subcounty_cb.Text.Trim(),
                    village_cb.Text.Trim(),
                    ((label10.Text == "?") ? (dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")) : ("")),
                    ((label10.Text == "?") ? (dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")) : ("")),
                    ((Amount.Text.Trim() == "")?(""):(Am_lbl.Text)),
                    Amount.Text.Trim(),
                    ((Balance.Text.Trim()=="")?(""):(BL.Text)),
                    Balance.Text.Trim()

                );

            populate_LoanDT(results);

        }



        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LoanApplications_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(0.3 * this.Width);
            panel2.Height = Convert.ToInt32(0.25 * this.Height);

            panel3.Height = panel4.Height = panel5.Height = panel6.Height = panel7.Height = panel8.Height = Convert.ToInt32(this.Height / 6);

            panel10.Width = Convert.ToInt32(0.4 * panel2.Width);

            panel11.Height = panel12.Height = Convert.ToInt32(0.5 * panel2.Height);


            panel13.Width = Convert.ToInt32(0.85 * panel10.Width);

            panel14.Height = panel15.Height = panel11.Height;

            panel16.Width = panel2.Width - (panel10.Width + panel13.Width);

            panel17.Height = panel18.Height = panel19.Height = Convert.ToInt32(0.85 * panel16.Height)/3;

        }

        private async void LoanApplications_Load(object sender, EventArgs e)
        {

            LoanApplicationsDAL LA = new LoanApplicationsDAL();
            dynamic results = await LA.FetchFarmerLoans(0 , false);
            if (results != null)
            {
                populate_LoanDT(results);
            }


            //Loading all respective Locations
            LocationsDAL location = new LocationsDAL();
            Locations = await location.Fetch();
            foreach(dynamic district in Locations)
            {
                district_cb.Items.Add(district);

                //Populating the subcounties too
                foreach(dynamic county in district.subcounties)
                {
                    subcounty_cb.Items.Add(county);

                    //Populating the villages too
                    foreach(dynamic village in county.villages)
                    {
                        village_cb.Items.Add(village);
                    }
                }
            }

            district_cb.DisplayMember = "name";
            district_cb.ValueMember = "id";

            subcounty_cb.DisplayMember = "name";
            subcounty_cb.ValueMember = "id";

            village_cb.DisplayMember = "name";
            village_cb.ValueMember = "id";

            //Load Farmers
            FarmersDAL Farmer = new FarmersDAL();
            farmers = await Farmer.Fetch();

            foreach(dynamic farmer in farmers)
            {
                var Name = Convert.ToString(farmer.Name) + " " + Convert.ToString(farmer.Given_name);

                farmer_cb.Items.Add(Name);
            }
            //farmer_cb.DisplayMember = "Name";
            //farmer_cb.ValueMember = "id";


        }

        public string Shift_symbols(string symbol)
        {
            if (symbol == "=")
            {
                return "<";
            }

            if (symbol == "<")
            {
                return ">";
            }

            if (symbol == ">")
            {
                return "<=";
            }

            if (symbol == "<=")
            {
                return ">=";
            }

            if (symbol == ">=")
            {
                return "=";
            }

            return "=";
        }

        private void Am_lbl_Click(object sender, EventArgs e)
        {
            Am_lbl.Text = Shift_symbols(Am_lbl.Text);
            Regenerate();
        }

        private void BL_Click(object sender, EventArgs e)
        {
            BL.Text = Shift_symbols(BL.Text);
            Regenerate();
        }

        private void district_cb_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Populating the Sub counties
            dynamic obj = district_cb.Items[district_cb.SelectedIndex];
            if (obj != null)
            {

                subcounty_cb.Items.Clear();
                foreach(dynamic sub in obj.subcounties)
                {
                    subcounty_cb.Items.Add(sub);
                }
                subcounty_cb.Text = " ";
                subcounty_cb.DisplayMember = "name";
                subcounty_cb.ValueMember = "id";
            }

            //Populate the Villages
            village_cb.Items.Clear();
            foreach(dynamic subcounty in obj.subcounties)
            {
                foreach(dynamic village in subcounty.villages)
                {
                    village_cb.Items.Add(village);
                }
            }
            village_cb.Text = " ";
            village_cb.DisplayMember = "name";
            village_cb.ValueMember = "id";

            Regenerate();
        }

        private void subcounty_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populating the Sub counties
            dynamic obj = subcounty_cb.Items[subcounty_cb.SelectedIndex];
            if (obj != null)
            {
                village_cb.Items.Clear();
                foreach (dynamic sub in obj.villages)
                {
                    village_cb.Items.Add(sub);
                }
                village_cb.Text = " ";
                village_cb.DisplayMember = "name";
                village_cb.ValueMember = "id";
            }

            Regenerate();
        }

        private void status_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void village_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void farmer_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void field_officer_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (label10.Text == "X")
            {
                label10.Text = "?";
                Regenerate();
            }
            else
            {
                label10.Text = "X";
                Regenerate();
            }
        }

        private void district_cb_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void district_cb_TextUpdate(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void subcounty_cb_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void subcounty_cb_TextUpdate(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void Amount_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (label10.Text == "?")
            {
                Regenerate();
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            if (label10.Text == "?")
            {
                Regenerate();
            }
        }

        private void LoanApps_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && !(e.RowIndex == current_Loan_applications.Count))
            {
                LoanApplicationProfile profile = new LoanApplicationProfile(current_Loan_applications[e.RowIndex]);
                profile.Show(); 

            }


            
        }
    }
}
