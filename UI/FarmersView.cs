using KAMM_FARM_SERVICES.Components;
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
            for (int i = 0; i < farmers_hold.Count; i++)
            {
                FarmersDt.Rows.Add(
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
            
            FarmersDGV.DataSource = FarmersDt;
        }

        private async void FarmersView_Load(object sender, EventArgs e)
        {
            current_farmers = await Handlers.Fetch(Env.live_url + "/GetFarmers/");

            if (current_farmers != null)
            {
                PopulateDGV(current_farmers["items"]);
            }
        }
    }
}
