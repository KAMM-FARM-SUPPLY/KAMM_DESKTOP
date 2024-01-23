using KAMM_FARM_SERVICES.Components;
using KAMM_FARM_SERVICES.DAL;
using KAMM_FARM_SERVICES.Helpers;
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
    public partial class FarmersView : Form
    {

        DataTable FarmersDt = new DataTable();
        dynamic Locations = null;
        dynamic current_farmers = null;

        public FarmersView()
        {
            InitializeComponent();

            FarmersDt.Columns.Add("Active", typeof(bool));
            FarmersDt.Columns.Add("Name", typeof(String));
            FarmersDt.Columns.Add("Gender", typeof(String));
            FarmersDt.Columns.Add("Phone number", typeof(String));
            FarmersDt.Columns.Add("NIN", typeof(String));
            FarmersDt.Columns.Add("Total land acreage");
            FarmersDt.Columns.Add("Coffee acreage");
            FarmersDt.Columns.Add("No of trees");
            FarmersDt.Columns.Add("Unproductive trees");
            FarmersDt.Columns.Add("Coffee production");
        }


        public async void Regenerate(bool previous_page = false , bool next_page = false)
        {

            Cursor = Cursors.WaitCursor;

            string derived_uri = Env.live_url + "/GetFarmers/?lazy_load=False&" +
                    ((status_cb.Text.Trim() != "") ? ("status=" + status_cb.Text + "&") : ("")) +
                    ((district_cb.Text.Trim() != "") ? ("District=" + district_cb.Text + "&") : ("")) +
                    ((subcounty_cb.Text.Trim() != "") ? ("Subcounty=" + subcounty_cb.Text + "&") : ("")) +
                    ((village_cb.Text.Trim() != "") ? ("Village=" + village_cb.Text + "&") : ("")) +
                    ((label11.Text == "?") ? ("Start_date=" + dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "&") : ("")) +
                    ((label11.Text == "?") ? ("End_date=" + dateTimePicker2.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "&") : ("")) +

                    ((land_acreage.Text.Trim() != "") ? ("Total_land_symbol=" + land_acreage_symbol.Text + "&") : ("")) +
                    ((land_acreage.Text.Trim() != "") ? ("Total_land=" + land_acreage.Text + "&") : ("")) +

                    ((coffee_acreage.Text.Trim() != "") ? ("Coffee_acreage_symbol=" + coffee_acreage_symbol.Text + "&") : ("")) +
                    ((coffee_acreage.Text.Trim() != "") ? ("Coffee_acreage=" + coffee_acreage.Text + "&") : ("")) +


                    ((trees.Text.Trim() != "") ? ("No_of_trees_symbol=" + trees_cb.Text + "&") : ("")) +
                    ((trees.Text.Trim() != "") ? ("No_of_trees=" + trees.Text + "&") : ("")) +


                    ((unproductive.Text.Trim() != "") ? ("Unproductive_trees_symbol=" + unproductive_symbol.Text + "&") : ("")) +
                    ((unproductive.Text.Trim() != "") ? ("Unproductive_trees=" + unproductive.Text + "&") : ("")) +

                    ((coffee_production.Text.Trim() != "") ? ("Ov_coffee_prod_symbol=" + coffee_production_symbol.Text + "&") : ("")) +
                    ((coffee_production.Text.Trim() != "") ? ("Ov_coffee_prod=" + coffee_production.Text + "&") : ("")) +


                    ((next_page && (current_farmers["pagination"].next != null)) ? ("page=" + current_farmers["pagination"].next + "&") : ("")) +
                    ((previous_page && (current_farmers["pagination"].previous != null)) ? ("page=" + current_farmers["pagination"].previous + "&") : (""))
                    ;

            dynamic results = await Handlers.Fetch(derived_uri);

            if (results != null)
            {
                PopulateDGV(results);
            }

            Cursor = Cursors.Default;

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

        private void FarmersView_Paint(object sender, PaintEventArgs e)
        {
            panel1.Width = Convert.ToInt32(0.3 * this.Width);

            panel5.Height = panel6.Height = panel7.Height = panel8.Height = panel9.Height = panel10.Height = panel11.Height = panel12.Height = panel13.Height = panel1.Height / 9;

            panel2.Height = Convert.ToInt32(0.25 * this.Height);

            panel14.Width = Convert.ToInt32(0.35 * panel2.Width);

            panel15.Height = panel16.Height = panel14.Height / 2;

            panel17.Width = Convert.ToInt32(0.35 * panel2.Width);

            panel18.Height = panel19.Height = panel17.Height / 2;

            panel3.Height = Convert.ToInt32(0.7 * this.Height);

            panel4.Height = this.Height - (panel2.Height + panel3.Height);

        }

        private void FarmersView_Click(object sender, EventArgs e)
        {

        }


        public void PopulateDGV(dynamic farmers_hold)
        {

            current_farmers = farmers_hold;

            FarmersDt.Rows.Clear();
            for (int i = 0; i < farmers_hold["items"].Count; i++)
            {
                FarmersDt.Rows.Add(
                    //true,
                    farmers_hold["items"][i].Active,
                    //await ImageProcesser.create_img(farmers_hold[i].Profile_picture.ToString(), new Size(70, 70)),
                    farmers_hold["items"][i].Name,
                    farmers_hold["items"][i].Gender,
                    farmers_hold["items"][i].Phone_number,
                    farmers_hold["items"][i].NIN_no,
                    farmers_hold["items"][i].Total_land_acreage,
                    farmers_hold["items"][i].Coffee_acreage,
                    farmers_hold["items"][i].No_of_trees,
                    farmers_hold["items"][i].Unproductive_trees,
                    farmers_hold["items"][i].Ov_coffee_prod
                    //await ImageProcesser.create_img(farmers_hold[i].Signature.ToString(), new Size(70, 70))
                    );
            }
            
            FarmersDGV.DataSource = FarmersDt;


            total.Text = "PROFILES : " + farmers_hold["meta_data"].query_total_farmers + " / " + farmers_hold["meta_data"].total_farmers;

            previous_page.Text = ((farmers_hold["pagination"].previous != null) ? ("<") : (""));
            next_page.Text = ((farmers_hold["pagination"].next != null) ? (">") : (""));

            page.Text = farmers_hold["pagination"].page + " of " + farmers_hold["pagination"].pages + " " + "(" + farmers_hold["pagination"].count + ")";

        }

        private async void FarmersView_Load(object sender, EventArgs e)
        {
            current_farmers = await Handlers.Fetch(Env.live_url + "/GetFarmers/");

            if (current_farmers != null)
            {
                PopulateDGV(current_farmers);
            }


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

        private void village_cb_SelectedIndexChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void land_acreage_symbol_Click(object sender, EventArgs e)
        {
            land_acreage_symbol.Text = Shift_symbols(land_acreage_symbol.Text);
            if (land_acreage.Text.Trim() != "")
            {
                Regenerate();
            }
        }

        private void coffee_acreage_symbol_Click(object sender, EventArgs e)
        {
            coffee_acreage_symbol.Text = Shift_symbols(coffee_acreage_symbol.Text);
            if (coffee_acreage.Text.Trim() != "")
            {
                Regenerate();
            }
        }

        private void trees_cb_Click(object sender, EventArgs e)
        {
            trees_cb.Text = Shift_symbols(trees_cb.Text);
            if (trees.Text.Trim() != "")
            {
                Regenerate();
            }
        }

        private void unproductive_symbol_Click(object sender, EventArgs e)
        {
            unproductive_symbol.Text = Shift_symbols(unproductive_symbol.Text);
            if (unproductive.Text.Trim() != "")
            {
                Regenerate();
            }
        }

        private void coffee_production_symbol_Click(object sender, EventArgs e)
        {
            coffee_production_symbol.Text = Shift_symbols(coffee_production_symbol.Text);
            if (coffee_production.Text.Trim() != "")
            {
                Regenerate();
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

        private void land_acreage_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void next_page_Click(object sender, EventArgs e)
        {
            Regenerate(false, true);
        }

        private void previous_page_Click(object sender, EventArgs e)
        {
            Regenerate(true, false);
        }
    }
}
