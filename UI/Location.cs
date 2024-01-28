using KAMM_FARM_SERVICES.DAL;
using KAMM_FARM_SERVICES.Helpers;
using KAMM_FARM_SERVICES.Schema.ExpendituresSchema;
using KAMM_FARM_SERVICES.Schema.LocationSchema;
using Newtonsoft.Json;
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
    public partial class Location : Form
    {
        public Location()
        {
            InitializeComponent();
        }

        //Districts
        public DataTable Districts;
        public int active_district_id = 0;
        public int active_county_id = 0;
        public int active_village_id = 0;


        public DataTable Subcounties;
        public DataTable Villages;

        public void Organise_dts()
        {
            //Populating columns for District DataTable
            Districts = new DataTable();
            Districts.Columns.Add("id", typeof(String));
            Districts.Columns.Add("name", typeof(String));
            Districts.Columns.Add("more_info", typeof(String));
            Districts.Columns.Add("Subcouties", typeof(String));

            //Populating columns for Subcounties
            Subcounties = new DataTable();
            Subcounties.Columns.Add("id");
            Subcounties.Columns.Add("name");
            Subcounties.Columns.Add("more_info");
            Subcounties.Columns.Add("Villages");

            //Populating columns for Villages
            Villages = new DataTable();
            Villages.Columns.Add("id");
            Villages.Columns.Add("name");
            Villages.Columns.Add("more_info");


        }

        private bool District_checker(string name)
        {
            bool exists = false;
            foreach(DataRow row in Districts.Rows)
            {
                if (row[1].ToString() == name)
                {
                    return true;
                }
            }
            return exists;
        }



        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void Location_Load(object sender, EventArgs e)
        {
            Organise_dts();
            LocationsDAL location = new LocationsDAL();
            dynamic District_results = await Handlers.Fetch(Env.live_url + "/Locations/" , false);


            ////Loading Districts
            if (District_results != null)
            {
                List<DistrictX> districts_info = JsonConvert.DeserializeObject<List<DistrictX>>(District_results);

                foreach (DistrictX item in districts_info)
                {
                    Districts.Rows.Add(item.id, item.name, item.more_info, item.subcounties.Count);

                }
                dgv1.DataSource = Districts;
            }
            



        }

        private async void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < Districts.Rows.Count)
            {
                Subcounties.Clear();
                Villages.Clear();
                Sub.Text = "SUBCOUNTY";

                Vill.Text = "VILLAGE";
                village_name.Text = "";
                village_info.Text = "";
                materialButton9.Enabled = false;
                materialButton8.Enabled = false;
                materialButton7.Enabled = false;
                active_village_id = 0;

                sub_name.Text = "";
                sub_info.Text = "";
                County_update.Enabled = false;
                County_delete.Enabled = false;
                active_county_id= 0;
                

                dgv1.Rows[row].Selected = true;
                Sub.Text = "Subcounties for " + Districts.Rows[row][1].ToString();
                district_name.Text = Districts.Rows[row][1].ToString();
                district_info.Text = Districts.Rows[row][2].ToString();
                int district_id = active_district_id = Convert.ToInt32(Districts.Rows[row][0].ToString());
                //Fetching Subcounties
                LocationsDAL location = new LocationsDAL();

                string derived_uri = Env.live_url + "/Subcounty/";

                if (district_id != 0)
                {
                    derived_uri = Env.live_url + "/Subcounty?district_id=" + district_id;
                }

                var county_results = await Handlers.Fetch(derived_uri, false);

                List<SubcountyX> subcounty_info = JsonConvert.DeserializeObject<List<SubcountyX>>(county_results);

                //dynamic county_results = await location.Fetch_subcounties(district_id);
                //MessageBox.Show(county_results.ToString());

                //Populating the subcounties
                foreach (SubcountyX item in subcounty_info)
                {
                    Subcounties.Rows.Add(item.id, item.name, item.more_info, item.villages.Count);
                }
                dgv2.DataSource = Subcounties;
                District_add.Enabled = false;
                District_update.Enabled = true;
                District_delete.Enabled = true;

            }
        }

        private async void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = e.RowIndex;
            if (e.RowIndex >= 0 && e.RowIndex < Subcounties.Rows.Count)
            {
                Villages.Clear();
                Vill.Text = "VILLAGE";
               

                //dgv1.Rows[row].Selected = true;
                Vill.Text = "Villages for " + Subcounties.Rows[row][1].ToString();
                
                sub_name.Text = Subcounties.Rows[row][1].ToString();
                sub_info.Text = Subcounties.Rows[row][2].ToString();
                int county_id = active_county_id = Convert.ToInt32(Subcounties.Rows[row][0].ToString());
                //Fetching Subcounties
                LocationsDAL location = new LocationsDAL();
                //dynamic village_results = await location.Fetch_villages(county_id);
                //MessageBox.Show(county_results.ToString());

                string derived_uri = Env.live_url + "/Villages";

                if (county_id != 0)
                {
                    derived_uri = Env.live_url + "/Villages?County_id=" + county_id;
                }

                var villages_results = await Handlers.Fetch(derived_uri, false);

                List<VillageX> village_info = JsonConvert.DeserializeObject<List<VillageX>>(villages_results);


                //Populating the subcounties
                foreach (VillageX item in village_info)
                {
                    Villages.Rows.Add(item.id, item.name, item.more_info);
                }
                dgv3.DataSource = Villages;
                County_update.Enabled = true;
                County_delete.Enabled = true;
                County_add.Enabled = false;
            }

        }

        private void district_name_TextChanged(object sender, EventArgs e)
        {
            string name = district_name.Text;
            if (!string.IsNullOrEmpty(name) && active_district_id == 0)
            {
                District_add.Enabled = true;
            }else
            {
                District_add.Enabled = false;
            }




        }

        private void CF_districts_Click(object sender, EventArgs e)
        {
            district_name.Text = "";
            district_info.Text = "";
            District_add.Enabled = false;
            District_update.Enabled = false;
            District_delete.Enabled = false;
            active_district_id = 0;

            // Turning off subcounties
            sub_name.Text = "";
            sub_info.Text = "";
            Sub.Text = "SUBCOUNTY";
            County_add.Enabled = false;
            County_update.Enabled = false;
            County_delete.Enabled = false;
            Subcounties.Clear();
            active_county_id = 0;

            //Turning off villages
            village_name.Text = "";
            Vill.Text = "VILLAGE";
            village_info.Text = "";
            materialButton9.Enabled = false;
            materialButton8.Enabled = false;
            materialButton7.Enabled = false;
            Villages.Clear();
            active_village_id = 0;


        }

        

        private async void District_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(district_name.Text))
            {
                LocationsDAL location = new LocationsDAL();
                bool created = await location.Create_District(district_name.Text, district_info.Text);
                if (created)
                {
                    MessageBox.Show("District created successfully");
                    Districts.Clear();
                    dynamic District_results = await location.Fetch();
                    //MessageBox.Show(District_results.ToString());
                    ////Loading Districts
                    foreach (dynamic item in District_results)
                    {
                        Districts.Rows.Add(item.id, item.name, item.more_info, item.subcounties.Count);

                    }
                    dgv1.DataSource = Districts;

                    district_name.Text = "";
                    district_info.Text = "";
                    District_add.Enabled = false;
                    District_update.Enabled = false;
                    District_delete.Enabled = false;
                }
                else
                {
                    MessageBox.Show("An error occured. Double check the name and try again");
                }
            }else
            {
                MessageBox.Show("No district name entered");
            }
            
        }

        private async void County_add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(sub_name.Text))
            {
                LocationsDAL location = new LocationsDAL();
                bool created = await location.Create_SubCounty(sub_name.Text,active_district_id, sub_info.Text);
                if (created)
                {
                    MessageBox.Show("SubCounty created successfully");
                    dynamic County_results = await location.Fetch_subcounties(active_district_id);
                    //MessageBox.Show(District_results.ToString());
                    ////Loading Districts
                    Subcounties.Clear();
                    foreach (dynamic item in County_results)
                    {
                        Subcounties.Rows.Add(item.id, item.name, item.more_info, item.villages.Count);

                    }
                    dgv2.DataSource = Subcounties;
                    sub_name.Text = "";
                    sub_info.Text = "";
                    County_add.Enabled = false;
                    County_update.Enabled = false;
                    County_delete.Enabled = false;
                    active_county_id = 0;
                }
                else
                {
                    MessageBox.Show("An error occured. Double check the name and try again");
                }
            }

        }

        private void sub_name_TextChanged(object sender, EventArgs e)
        {
            string name = sub_name.Text;
            if (!string.IsNullOrEmpty(name) && active_county_id == 0)
            {
                County_add.Enabled = true;
            }
            else
            {
                County_add.Enabled = false;
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {
            sub_name.Text = "";
            sub_info.Text = "";
            County_add.Enabled = false;
            County_update.Enabled = false;
            County_delete.Enabled = false;
            active_county_id = 0;

            //Turning off villages
            village_name.Text = "";
            Vill.Text = "VILLAGE";
            village_info.Text = "";
            materialButton9.Enabled = false;
            materialButton8.Enabled = false;
            materialButton7.Enabled = false;
            Villages.Clear();
            active_village_id = 0;
        }

        private async void District_update_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Update_District(district_name.Text , active_district_id , district_info.Text);
            if (success)
            {
                MessageBox.Show("District updated successfully");
                ////Loading Districts
                dynamic District_results = await location.Fetch();
                Districts.Clear();
                foreach (dynamic item in District_results)
                {
                    Districts.Rows.Add(item.id, item.name, item.more_info, item.subcounties.Count);

                }
                dgv1.DataSource = Districts;

                Subcounties.Clear();
                Sub.Text = "SUBCOUNTY";
                sub_name.Text = "";
                sub_info.Text = "";
                County_add.Enabled = false;
                County_update.Enabled = false;
                County_delete.Enabled = false;

                Villages.Clear();
                village_name.Text = "";
                village_info.Text = "";
                materialButton7.Enabled = false;
                materialButton8.Enabled = false;
                materialButton9.Enabled = false;
                Vill.Text = "VILLAGE";

                district_name.Text = "";
                district_info.Text = "";
                District_add.Enabled = false;
                District_update.Enabled = false;
                District_delete.Enabled = false;
            }
            else
            {
                MessageBox.Show("Failed to update district");
            }
        }

        private async void County_update_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Update_County(sub_name.Text, active_county_id, sub_info.Text);
            if (success)
            {
                MessageBox.Show("Subcounty updated successfully");
                dynamic County_results = await location.Fetch_subcounties(active_district_id);
                //MessageBox.Show(District_results.ToString());
                ////Loading Districts
                Subcounties.Clear();
                foreach (dynamic item in County_results)
                {
                    Subcounties.Rows.Add(item.id, item.name, item.more_info, item.villages.Count);

                }
                dgv2.DataSource = Subcounties;
                sub_name.Text = "";
                sub_info.Text = "";
                County_add.Enabled = false;
                County_update.Enabled = false;
                County_delete.Enabled = false;

                Villages.Clear();
                village_name.Text = "";
                village_info.Text = "";
                materialButton7.Enabled = false;
                materialButton8.Enabled = false;
                materialButton9.Enabled = false;
                Vill.Text = "VILLAGE";
            }
            else
            {
                MessageBox.Show("Failed to update subcounty");
            }
        }

        private async void materialButton8_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Update_Village(village_name.Text, active_village_id, village_info.Text);
            if (success)
            {
                MessageBox.Show("Village updated successfully");
                dynamic village_results = await location.Fetch_villages(active_county_id);
                //MessageBox.Show(county_results.ToString());

                //Populating the subcounties
                Villages.Clear();
                foreach (dynamic item in village_results)
                {
                    Villages.Rows.Add(item.id, item.name, item.more_info);
                }
                dgv3.DataSource = Villages;

                village_name.Text = "";
                village_info.Text = "";
                materialButton9.Enabled = false;
                materialButton8.Enabled = false;
                materialButton7.Enabled = false;
                active_village_id = 0;
            }
            else
            {
                MessageBox.Show("Failed to update village");
            }
        }

        private async void materialButton9_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Create_Village(village_name.Text, active_county_id, village_info.Text);
            if (success)
            {
                MessageBox.Show("Village added successfully");
                dynamic village_results = await location.Fetch_villages(active_county_id);
                //MessageBox.Show(county_results.ToString());

                //Populating the subcounties
                Villages.Clear();
                foreach (dynamic item in village_results)
                {
                    Villages.Rows.Add(item.id, item.name, item.more_info);
                }
                dgv3.DataSource = Villages;

                village_name.Text = "";
                village_info.Text = "";
                materialButton9.Enabled = false;
                materialButton8.Enabled = false;
                materialButton7.Enabled = false;
                active_village_id = 0;
            }
            else
            {
                MessageBox.Show("Failed to add village");
            }
        }

        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < Villages.Rows.Count)
            {
                village_name.Text = Villages.Rows[e.RowIndex][1].ToString();
                village_info.Text = Villages.Rows[e.RowIndex][2].ToString();
                active_village_id = Convert.ToInt32(Villages.Rows[e.RowIndex][0]);

                materialButton8.Enabled = true;
                materialButton7.Enabled = true;
                materialButton9.Enabled = false;
            }
        }

        private void village_name_TextChanged(object sender, EventArgs e)
        {
            string name = village_name.Text;
            if (!string.IsNullOrEmpty(name) && active_village_id == 0)
            {
                materialButton9.Enabled = true;
            }else 
            {
                materialButton9.Enabled = false;
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            village_name.Text = "";
            village_info.Text = "";
            materialButton9.Enabled = false;
            materialButton8.Enabled = false;
            materialButton7.Enabled = false;
            active_village_id = 0;
        }

        private async void District_delete_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Delete_District(active_district_id);
            if (success)
            {
                MessageBox.Show("District successfully deleted");
                CF_districts_Click(sender, e);
                Districts.Clear();
                dynamic District_results = await location.Fetch();
                //MessageBox.Show(District_results.ToString());
                ////Loading Districts
                foreach (dynamic item in District_results)
                {
                    Districts.Rows.Add(item.id, item.name, item.more_info, item.subcounties.Count);

                }
                dgv1.DataSource = Districts;

            }
            else
            {
                MessageBox.Show("An error occured");
            }
        }

        private async void County_delete_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Delete_Subcounty(active_county_id);
            if (success)
            {
                MessageBox.Show("Subcounty deleted successfully");
                label3_Click(sender, e);
                dynamic County_results = await location.Fetch_subcounties(active_district_id);
                //MessageBox.Show(District_results.ToString());
                ////Loading Districts
                Subcounties.Clear();
                foreach (dynamic item in County_results)
                {
                    Subcounties.Rows.Add(item.id, item.name, item.more_info, item.villages.Count);

                }
                dgv2.DataSource = Subcounties;

            }
            else
            {
                MessageBox.Show("An error occured");
            }
        }

        private async void materialButton7_Click(object sender, EventArgs e)
        {
            LocationsDAL location = new LocationsDAL();
            bool success = await location.Delete_Village(active_village_id);
            if (success)
            {
                MessageBox.Show("Village deleted successfully");
                label10_Click(sender, e);
                dynamic village_results = await location.Fetch_villages(active_county_id);
                //MessageBox.Show(county_results.ToString());

                //Populating the subcounties
                Villages.Clear();
                foreach (dynamic item in village_results)
                {
                    Villages.Rows.Add(item.id, item.name, item.more_info);
                }
                dgv3.DataSource = Villages;

            }
            else
            {
                MessageBox.Show("An error occured");
            }
        }
    }
}
