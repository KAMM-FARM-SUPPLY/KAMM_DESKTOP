using KAMM_FARM_SERVICES.Components;
using KAMM_FARM_SERVICES.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.DAL;
using MaterialSkin.Controls;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace KAMM_FARM_SERVICES.UI
{
    public partial class Farmers : Form
    {
        public Farmers()
        {
            InitializeComponent();

            
        }

        public static dynamic Locations = null;

        dynamic farmers_hold = null;
        dynamic location_hold = null;
        string active_counties = null;
        DataTable ov_dt = new DataTable();

        private dynamic GetSubcouties(string district)
        {
            foreach(dynamic item in location_hold)
            {
                if (item.name == district)
                {
                    return item.subcounties;
                }
            }
            return null;
        }

        private dynamic GetVillages(string County)
        {
            foreach (dynamic item in active_counties)
            {
                if (item.name == County)
                {
                    return item.villages;
                }
            }
            return null;
        }

        public void QueryFarmers()
        {
            string status;
            if (materialComboBox1.Text == "Validated")
            {
                status = "true";
            }
            else if (materialComboBox1.Text == "Pending")
            {
                status = "false";
            }
            else
            {
                status = null;
                //LoadVillageFarmers(Village.Text);
                //return;
            }
            //LoadVillageFarmers(Village.Text, status.ToString());
            //MessageBox.Show(Village.Text);
            if (Village.Text == "All" || Village.Text == "")
            {
                //MessageBox.Show("This");
                LoadVillageFarmers(null, status);

            }
            else
            {
                LoadVillageFarmers(Village.Text, status);

            }
        }

        private async void LoadVillageFarmers(string Village=null , string status_type = null)
        {
            FarmersDAL farmers = new FarmersDAL();
            //MessageBox.Show(location_results.ToString());
            dynamic results;
            if (Village == null && status_type == null) {
                results = await farmers.Fetch();
            }
            else
            {
                results = await farmers.Fetch(Village, status_type);
            }
            if (results != null)
            {
                farmers_hold = results;


                //Creating a dataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("Active", typeof(bool));
                //dt.Columns.Add("Picture", typeof(Image));
                dt.Columns.Add("Name", typeof(String));
                dt.Columns.Add("Gender", typeof(String));
                dt.Columns.Add("Phone number", typeof(String));
                dt.Columns.Add("NIN", typeof(String));

                dt.Columns.Add("Total land acreage", typeof(Int32));
                dt.Columns.Add("Coffee acreage", typeof(Int32));
                dt.Columns.Add("No of trees", typeof(Int32));
                dt.Columns.Add("Unproductive trees", typeof(Int32));
                dt.Columns.Add("Coffee production", typeof(Int32));
                //dt.Columns.Add("Signature", typeof(Image));

                Image temp_image ;

                for (int i = 0; i < farmers_hold.Count; i++)
                {
                    dt.Rows.Add(
                        //true,
                        farmers_hold[i].Active,
                        //await ImageProcesser.create_img(farmers_hold[i].Profile_picture.ToString(), new Size(70, 70)),
                        farmers_hold[i].Name,
                        farmers_hold[i].Gender,
                        farmers_hold[i].Phone_number,
                        farmers_hold[i].NIN_no,
                        farmers_hold[i].Total_land_acreage,
                        farmers_hold[i].Coffee_acreage,
                        farmers_hold[i].No_of_trees,
                        farmers_hold[i].Unproductive_trees,
                        farmers_hold[i].Ov_coffee_prod
                        //await ImageProcesser.create_img(farmers_hold[i].Signature.ToString(), new Size(70, 70))
                        );
                }
                ov_dt = dt;
                dgv1.RowTemplate.Height = 80;
                dgv1.DataSource = dt;

                


            }
        }



        private async void getFarmers()
        {
            //// Fetching the locations
            //LocationsDAL location = new LocationsDAL();
            //dynamic location_results = await location.Fetch();

            ////MessageBox.Show(location_results);


            //if (location_results != null && location_results.Count >0 )
            //{
            //    Locations = location_results;
            //    location_hold = location_results;

            //    //Applying to the drop downs

            //    //Applying districts
            //    //District.Text = location_results[0].name;
            //    District.SelectedValue = location_results[0].name;
            //    foreach(dynamic item in location_results)
            //    {
            //        District.Items.Add(item.name);
            //    }


            //    //Applying to subcounties
            //    Subcounty.Text = location_results[0].subcounties[0].name;
            //    foreach(dynamic item in location_results[0].subcounties)
            //    {
            //        Subcounty.Items.Add(item.name);
            //    }

            //    //Applying to villages
            //    Village.Text = location_results[0].subcounties[0].villages[0].name;

            //    foreach (dynamic item in location_results[0].subcounties[0].villages)
            //    {
            //        Village.Items.Add(item.name);
            //    }


            //this.materialComboBox2.Items.AddRange();

            //    LoadVillageFarmers(location_results[0].subcounties[0].villages[0].name.ToString());


            //} else
            //{


            LocationsDAL location = new LocationsDAL();
            dynamic Village_results = await location.Fetch_villages();
            if (Village_results != null)
            {
                foreach (dynamic item in Village_results)
                {
                    Village.Items.Add(item.name);
                }
                LoadVillageFarmers(Village_results[0].name.ToString(), "None");
            }else
            {
                MessageBox.Show("An error occured . Try again");
            }
            

            //}


        }


        private async void Farmers_Load(object sender, EventArgs e)
        {

            //getFarmers();
            LoadVillageFarmers();

            //Loading all the villages
            LocationsDAL location = new LocationsDAL();
            dynamic Village_results = await location.Fetch_villages();
            if (Village_results != null)
            {
                Village.Items.Add("All");
                foreach (dynamic item in Village_results)
                {
                    Village.Items.Add(item.name);
                }
            }
            else
            {
                MessageBox.Show("An error occured . Try again");
            }


        }


      

        private void dgv1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
               

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private async void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && !(e.ColumnIndex == 0))
            {
                FarmerProfile profile = new FarmerProfile(farmers_hold[e.RowIndex]);
                profile.Show();
                return;
            }
            else if (e.ColumnIndex == 0)
            {
                //MessageBox.Show(ov_dt.Rows[e.RowIndex][e.ColumnIndex].ToString());
                bool status = Convert.ToBoolean(ov_dt.Rows[e.RowIndex][e.ColumnIndex]);
                //MessageBox.Show(status.ToString());
                if (MessageBox.Show("Would you like to " + (status ? "deactivate" : "activate") +" this profile ?" , "Farmers Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (status)
                    {
                        FarmersDAL farmer = new FarmersDAL();
                        dynamic result = await farmer.change_status(farmers_hold[e.RowIndex].id.ToString(), false);
                    } else
                    {
                        FarmersDAL farmer = new FarmersDAL();
                        dynamic result = await farmer.change_status(farmers_hold[e.RowIndex].id.ToString(), true);
                        //MessageBox.Show(result.ToString());
                    }

                    bool status_cb;
                    if (materialComboBox1.Text == "Validated")
                    {
                        status_cb = true;
                    }
                    else if (materialComboBox1.Text == "Pending")
                    {
                        status_cb = false;
                    }
                    else
                    {
                        QueryFarmers();
                        return;
                    }
                    QueryFarmers();
                    //LoadVillageFarmers(Village.Text, status_cb.ToString());


                }
                else
                {
                    // user clicked no
                    
                }

            }

        }

        private void District_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selected_district = District.Text;
            //active_counties = GetSubcouties(selected_district);
            //foreach (dynamic item in GetSubcouties(selected_district))
            //{
            //    Subcounty.Items.Add(item.name);
            //}
        }

        private void Subcounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string selected_county = Subcounty.Text;
            //foreach (dynamic item in GetVillages(selected_county))
            //{
            //    Village.Items.Add(item.name);
            //}
        }

        private void Village_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryFarmers();
        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            QueryFarmers();
        }

        private void Farmers_Layout(object sender, LayoutEventArgs e)
        {
            panel2.Height = Convert.ToInt32(0.15 * Form1.PnlContainer.Height);

            panel3.Width = panel4.Width = panel5.Width = Convert.ToInt32(0.7 * Form1.PnlContainer.Width) / 3;

            panel6.Width = Form1.PnlContainer.Width - (panel3.Width * 3);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
