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
using KAMM_FARM_SERVICES.Helpers;

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
            LoanDT.Columns.Add("Application id");
            LoanDT.Columns.Add("Status");
            LoanDT.Columns.Add("Names");
            LoanDT.Columns.Add("Phone");
            LoanDT.Columns.Add("Total Amount");
            LoanDT.Columns.Add("Balance Due");
            LoanDT.Columns.Add("Products Count");
            LoanDT.Columns.Add("Collateral Count");
            LoanDT.Columns.Add("Date Created");
        }


        public List<DataGridViewRow> Get_selectected_rows()
        {
            List<DataGridViewRow> selected_rows = new List<DataGridViewRow>();

            //Getting all the selected visits
            foreach (DataGridViewRow dr in LoanApps.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    selected_rows.Add(dr);
                }
            }

            return selected_rows;

        }

        private string check_selection_integrity()
        {
            List<DataGridViewRow> selected_rows = Get_selectected_rows();

            string current_selection = selected_rows[0].Cells[2].Value.ToString();

            foreach(DataGridViewRow dr in selected_rows)
            {
                if (current_selection == dr.Cells[2].Value.ToString())
                {
                    current_selection = dr.Cells[2].Value.ToString();
                }
                else
                {
                    return null;
                }
            }

            

            return current_selection;
        }


        private void populate_LoanDT(dynamic LoanApplications)
        {
            current_Loan_applications = LoanApplications;

            LoanDT.Rows.Clear();
            if (LoanApplications != null)
            {
                foreach (dynamic dt in LoanApplications["items"])
                {
                    LoanDT.Rows.Add(
                        false,
                        dt.id,
                        dt.Status,
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

                //Populating pagination
                total.Text = "Amount : shs. " + current_Loan_applications["meta_data"].query_total_amount.ToString("N0") + " / " + current_Loan_applications["meta_data"].Total_amount.ToString("N0");
                bala.Text = "Balance : shs. " + current_Loan_applications["meta_data"].query_total_balance.ToString("N0") + " / " + current_Loan_applications["meta_data"].Total_balance.ToString("N0");

                previous_page.Text = ((current_Loan_applications["pagination"].previous != null) ? ("<") : (""));
                next_page.Text = ((current_Loan_applications["pagination"].next != null) ? (">") : (""));

                page.Text = current_Loan_applications["pagination"].page + " of " + current_Loan_applications["pagination"].pages + " " + "(" + current_Loan_applications["pagination"].count + ")";

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


        public async void Regenerate(bool previous_page = false , bool next_page = false)
        {
            Cursor = Cursors.WaitCursor;
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
                    Balance.Text.Trim(),
                    (previous_page || next_page),
                    
                    ((previous_page|| next_page) ? ((previous_page) ? (Convert.ToInt32(current_Loan_applications["pagination"].previous)) : (Convert.ToInt32(current_Loan_applications["pagination"].next))) : (0))
                );

            populate_LoanDT(results);

            Cursor = Cursors.Default;


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


            panel13.Width = Convert.ToInt32(0.78 * panel10.Width);

            panel14.Height = panel15.Height = panel11.Height;

            panel16.Width = (panel2.Width - (panel10.Width + panel13.Width)) + Convert.ToInt32(0.04 * panel2.Width);

            panel17.Height = panel18.Height = panel19.Height = Convert.ToInt32(0.85 * panel16.Height)/3;


            panel9.Height = Convert.ToInt32(0.68 * this.Height);

            panel20.Height = this.Height - (panel9.Height + panel2.Height);


            panel26.Width = panel27.Width = panel28.Width = (panel18.Width / 3);
        }

        private async void LoanApplications_Load(object sender, EventArgs e)
        {

            LoanApplicationsDAL LA = new LoanApplicationsDAL();
            dynamic results = await Handlers.Fetch(Env.live_url + "/Queryapplications?lazy_load=False");
            //dynamic results = await LA.FetchFarmerLoans(0 , false);
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
            if (e.RowIndex >= 0 && !(e.RowIndex == current_Loan_applications.Count) && !(e.ColumnIndex == 0))
            {
                LoanApplicationProfile profile = new LoanApplicationProfile(current_Loan_applications["items"][e.RowIndex]);
                profile.Show(); 

            }
            

            
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = Get_selectected_rows();

            

            Cursor = Cursors.Default;
        }

        private void previous_page_Click(object sender, EventArgs e)
        {
            Regenerate(true, false);

        }

        private void next_page_Click(object sender, EventArgs e)
        {
            Regenerate(false, true);
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private async void materialButton2_Click_1(object sender, EventArgs e)
        {


            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = Get_selectected_rows();

            string selection_integrity = check_selection_integrity();

            if ((selected_rows.Count > 0) && (selection_integrity == "Pending"))
            {
                foreach (DataGridViewRow row in selected_rows)
                {
                    int application_id = Convert.ToInt32(row.Cells[1].Value);
                    string Status = "Approved";

                    bool result = await Handlers.Update(Env.live_url + "/Change_status", new { application_id, Status });


                }

                MessageBox.Show("Approved successfully");
                Regenerate();

            }
            else
            {
                MessageBox.Show("No rows selected match the specified criteria . ");
            }




            Cursor = Cursors.Default;

        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = Get_selectected_rows();

            string selection_integrity = check_selection_integrity();

            if ((selected_rows.Count > 0) && (selection_integrity == "Approved"))
            {
                foreach (DataGridViewRow row in selected_rows)
                {
                    int application_id = Convert.ToInt32(row.Cells[1].Value);
                    string Status = "Disbursed";

                    bool result = await Handlers.Update(Env.live_url + "/Change_status", new { application_id, Status });


                }

                MessageBox.Show("Disbursed successfully");
                Regenerate();

            }
            else
            {
                MessageBox.Show("No rows selected match the specified criteria . ");
            }




            Cursor = Cursors.Default;
        }

        private async void materialButton5_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = Get_selectected_rows();

            string selection_integrity = check_selection_integrity();

            if ((selected_rows.Count > 0) && ((selection_integrity == "Approved") || (selection_integrity == "Disbursed")))
            {
                foreach (DataGridViewRow row in selected_rows)
                {
                    int application_id = Convert.ToInt32(row.Cells[1].Value);
                    string Status = "Pending";

                    bool result = await Handlers.Update(Env.live_url + "/Change_status", new { application_id, Status });


                }

                MessageBox.Show("Staled successfully");
                Regenerate();

            }
            else
            {
                MessageBox.Show("No rows selected match the specified criteria . ");
            }




            Cursor = Cursors.Default;
        }
    }
}
