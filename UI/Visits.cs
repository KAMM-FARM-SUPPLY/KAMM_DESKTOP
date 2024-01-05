using KAMM_FARM_SERVICES.DAL;
using KAMM_FARM_SERVICES.Helpers;
using KAMM_FARM_SERVICES.UI.LoanVisitsForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class Visits : Form
    {

        DataTable VisitsDT = new DataTable();
        dynamic currnt_visits = null;
        dynamic Locations = null;
        dynamic farmers = null;

        public Visits()
        {
            InitializeComponent();


            VisitsDT.Columns.Add("Select", typeof(bool));
            VisitsDT.Columns.Add("Farmer", typeof(string));
            VisitsDT.Columns.Add("Field Officer", typeof(string));
            VisitsDT.Columns.Add("Status", typeof(string));
            VisitsDT.Columns.Add("Validity", typeof(string));
            VisitsDT.Columns.Add("Scheduled Date", typeof(string));
            VisitsDT.Columns.Add("Date created", typeof(string));
            VisitsDT.Columns.Add("District", typeof(string));
            VisitsDT.Columns.Add("Subcounty", typeof(string));
            VisitsDT.Columns.Add("Village", typeof(string));
            VisitsDT.Columns.Add("Visit ID", typeof(string));



        }

        private void populateDGV(dynamic Visits)
        {
            currnt_visits = Visits;

            VisitsDT.Rows.Clear();
            if (Visits != null)
            {
                foreach(dynamic visit in Visits)
                {
                    VisitsDT.Rows.Add(
                        false,
                        visit.Farmer_id.Name + " " + visit.Farmer_id.Given_name,
                        visit.Employee.username,
                        visit.Status,
                        visit.Validity,
                        visit.scheduled_date,
                        visit.Date_added,
                        visit.Farmer_id.District,
                        visit.Farmer_id.Subcounty,
                        visit.Farmer_id.Village,
                        visit.visit_id
                   );
                }
                FarmerVisits.DataSource = VisitsDT;

                FarmerVisits.Columns[10].Visible = false;
               

            }
        }

        public int convert_to_id(string name)
        {
            foreach (dynamic farmer in farmers)
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

            VisitsDAL visit = new VisitsDAL();
            dynamic results = await visit.QueryVisits(
                    false,
                    convert_to_id(farmer_cb.Text.Trim()),
                    status_cb.Text.Trim(),
                    district_cb.Text.Trim(),
                    subcounty_cb.Text.Trim(),
                    village_cb.Text.Trim(),
                    ((label11.Text == "?") ? (dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss")) : ("")),
                    ((label11.Text == "?") ? (dateTimePicker2.Value.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss")) : (""))

                );

            populateDGV(results);

        }



        private void Visits_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(0.3 * this.Width);

            panel9.Height = Convert.ToInt32(0.25 * this.Height);

            panel2.Height = panel3.Height = panel4.Height = panel5.Height = panel6.Height = panel7.Height = panel8.Height = Convert.ToInt32(this.Height / 7);


            panel10.Width = Convert.ToInt32(0.35 * panel9.Width);
            panel11.Height = panel12.Height = Convert.ToInt32(0.5 * panel10.Height);

            panel14.Width = Convert.ToInt32(0.35 * panel9.Width);

            panel15.Height = panel16.Height = Convert.ToInt32(panel14.Height * 0.6)/2;

            panel17.Width = (panel9.Width - (panel10.Width + panel14.Width)) + Convert.ToInt32(0.08 * panel9.Width);

            panel18.Height = panel19.Height = panel15.Height;

        }

        private async void Visits_Load(object sender, EventArgs e)
        {
            VisitsDAL visitsDAL = new VisitsDAL();
            dynamic visits = await visitsDAL.Fetch_Visits();
            populateDGV(visits);


            


            //Loading all respective Locations
            LocationsDAL location = new LocationsDAL();
            Locations = await location.Fetch();
            foreach (dynamic district in Locations)
            {
                district_cb.Items.Add(district);

                //Populating the subcounties too
                foreach (dynamic county in district.subcounties)
                {
                    subcounty_cb.Items.Add(county);

                    //Populating the villages too
                    foreach (dynamic village in county.villages)
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

            foreach (dynamic farmer in farmers)
            {
                var Name = Convert.ToString(farmer.Name) + " " + Convert.ToString(farmer.Given_name);

                farmer_cb.Items.Add(Name);
            }
            //farmer_cb.DisplayMember = "Name";
            //farmer_cb.ValueMember = "id";


        }



        private void FarmerVisits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                if (Convert.ToBoolean(FarmerVisits.Rows[e.RowIndex].Cells[3].Value))
                {
                    VisitProfile profile = new VisitProfile(currnt_visits[e.RowIndex]);
                    profile.Show();
                }
                else
                {
                    MessageBox.Show("This Visit has not yet been filled");
                }
                
            }
        }

        private void district_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Populating the Sub counties
            dynamic obj = district_cb.Items[district_cb.SelectedIndex];
            if (obj != null)
            {

                subcounty_cb.Items.Clear();
                foreach (dynamic sub in obj.subcounties)
                {
                    subcounty_cb.Items.Add(sub);
                }
                subcounty_cb.Text = " ";
                subcounty_cb.DisplayMember = "name";
                subcounty_cb.ValueMember = "id";
            }

            //Populate the Villages
            village_cb.Items.Clear();
            foreach (dynamic subcounty in obj.subcounties)
            {
                foreach (dynamic village in subcounty.villages)
                {
                    village_cb.Items.Add(village);
                }
            }
            village_cb.Text = " ";
            village_cb.DisplayMember = "name";
            village_cb.ValueMember = "id";
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
        }

        private void label11_Click(object sender, EventArgs e)
        {
            if (label11.Text == "X")
            {
                label11.Text = "?";
                Regenerate();
            }
            else
            {
                label11.Text = "X";
                Regenerate();
            }
        }

        private void materialButton2_Click(object sender, EventArgs e)
        {
            CreateVisit visit = new CreateVisit(this);
            visit.Show();
        }

        private void district_cb_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void farmer_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private async void delete_btn_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = new List<DataGridViewRow>();

            //Getting all the selected visits
            foreach(DataGridViewRow dr in FarmerVisits.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    selected_rows.Add(dr);
                }
            }


            if (selected_rows.Count > 0)
            {
                foreach (DataGridViewRow row in selected_rows)
                {
                    bool deleted = await Handlers.Delete(Env.live_url + "/Delete_visit/" + row.Cells[10].Value.ToString() + "/");
                    if (!deleted)
                    {
                        MessageBox.Show("An error occured during deletion");
                    }
                    
                }

                MessageBox.Show("All selected visit(s) deleted sucessfully");
                Regenerate();
            }
            else
            {
                MessageBox.Show("No rows were selected");
            }
            Cursor = Cursors.Default;
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        { 
            Cursor = Cursors.WaitCursor;
            List<DataGridViewRow> selected_rows = new List<DataGridViewRow>();

            //Getting all the selected visits
            foreach (DataGridViewRow dr in FarmerVisits.Rows)
            {
                if (Convert.ToBoolean(dr.Cells[0].Value))
                {
                    if (Convert.ToBoolean(dr.Cells[3].Value))
                    {
                        if (dr.Cells[4].Value.ToString() != "Approved")
                        {
                            selected_rows.Add(dr);
                        }
                        else
                        {
                            MessageBox.Show("The visit under " + dr.Cells[1].Value.ToString() + " was already approved and there is nothing more to approve of the visit.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The visit under " + dr.Cells[1].Value.ToString() + " has not yet been filled . Hence there is nothing to merge");
                    }
                }
            }


            if (selected_rows.Count > 0)
            {
                foreach (DataGridViewRow row in selected_rows)
                {
                    bool approved = await Handlers.Update(Env.live_url + "/Approve_visit/" + row.Cells[10].Value.ToString() + "/" , new { });
                    if (!approved)
                    {
                        MessageBox.Show("An error occured during the approval of the visit");
                    }

                }

                MessageBox.Show("All selected visit(s) approved sucessfully");
                Regenerate();
            }
            else
            {
                MessageBox.Show("No rows were selected");
            }

            Cursor = Cursors.Default;


        }
    }
}
