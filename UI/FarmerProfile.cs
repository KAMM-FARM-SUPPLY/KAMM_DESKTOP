using MaterialSkin.Controls;
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
using KAMM_FARM_SERVICES.UI.LoanDetailsAnalysis;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class FarmerProfile : Form
    {

        public dynamic profile = null;
        public FarmerProfile(dynamic profile_info)
        {
            InitializeComponent();
            profile = profile_info;

            if (Convert.ToBoolean(profile.Active))
            {
                btnfarmer_id.Enabled = true;
                btnvalidate.Enabled = true;
                btnvalidate.Text = "Deactivate account";
            }

            FetchVisits(Convert.ToInt32(profile.id));



        }


        public void Load_Kin_info(dynamic kin_info)
        {
            NextOfKin kinform = new NextOfKin(kin_info) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.AnalysisPanel.Controls.Clear();
            kinform.FormBorderStyle = FormBorderStyle.None;
            this.AnalysisPanel.Controls.Add(kinform);
            kinform.Show();
        }

        public async void FetchLoanApplications()
        {
            LoanApplicationsDAL app = new LoanApplicationsDAL();
            dynamic applications = await app.FetchFarmerLoans(Convert.ToInt32(profile.id));


            DataTable dt = new DataTable();

            DataTable dts = new DataTable();


            dt.Columns.Add("Active", typeof(bool));
            dt.Columns.Add("Name");
            dt.Columns.Add("Total_cost");
            dt.Columns.Add("Products_odered");
            dt.Columns.Add("Collaterals");
            dt.Columns.Add("Application_date");

            dts = dt.Clone();

            if (applications.Count > 0)
            {
                int Overall_count = applications.Count;

                if (Overall_count > 0)
                {
                    dts.Rows.Add(
                        applications[Overall_count - 1].Active,
                        applications[Overall_count - 1].Name,
                        applications[Overall_count - 1].Total_cost,
                        applications[Overall_count - 1].Products.Count,
                        applications[Overall_count - 1].Collateral.Count,
                        applications[Overall_count - 1].Date_added
                    );

                    Load_Kin_info(applications[Overall_count - 1].Next_of_kin[0]);
                }



                for (int i = 0; i < applications.Count; i++)
                {
                    dt.Rows.Add(
                        applications[i].Active,
                        applications[i].Name,
                        applications[i].Total_cost,
                        applications[i].Products.Count,
                        applications[i].Collateral.Count,
                        applications[i].Date_added

                    );
                }
            }
            else
            {
                MessageBox.Show("No records were found.");
            }

            

            active_loans.DataSource = dts;
            LoanApplications.DataSource = dt;
            
        }


        public async void FetchVisits(int id)
        {
            try
            {
                FarmersDAL farmer = new FarmersDAL();
                dynamic details = await farmer.FetchVisits(id);

                //Ploting the data into the graph
                for(int i = 0; i<details.Count; i++)
                {
                    dynamic snap = details[i].Farmer_profile_snapshot;
                    string dateTimeString = Convert.ToString(snap.Date_added);
                    DateTime dateTime = DateTime.Parse(dateTimeString);
                    int month = dateTime.Month; // This will be 12 for December

                    chart1.Series["Coffee acreage"].Points.AddXY(month.ToString(), Convert.ToInt32(snap.Coffee_acreage));
                    chart1.Series["Number of trees"].Points.AddXY(month.ToString(), Convert.ToInt32(snap.No_of_trees));
                    chart1.Series["Unproductive trees"].Points.AddXY(month.ToString(), Convert.ToInt32(snap.Unproductive_trees));
                    chart1.Series["Coffee Production"].Points.AddXY(month.ToString(), Convert.ToInt32(snap.Ov_coffee_prod));


                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label39_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void FarmerProfile_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(profile.ToString());
            Name.Text = profile.Name.ToString();
            name_2.Text = profile.Given_name.ToString();
            district.Text = profile.District.ToString();
            subcounty.Text = profile.Subcounty.ToString();
            village.Text = profile.Village.ToString();
            Land_acreage.Text = profile.Total_land_acreage.ToString();
            NIN_no.Text = profile.NIN_no.ToString();
            phone.Text = profile.Phone_number.ToString();
            gender.Text = profile.Gender.ToString();
            gender_2.Text = profile.Gender.ToString();
            date.Text = profile.Year_of_birth.ToString();
            date_joined.Text = profile.Date_added.ToString();
            coffee.Text = profile.Coffee_acreage.ToString();
            unproductive.Text = profile.Unproductive_trees.ToString();
            trees.Text = profile.No_of_trees.ToString();

            pictureBox2.Image = await ImageProcesser.create_img(profile.Profile_picture.ToString() , new Size(214, 163));
            signature.Image = await ImageProcesser.create_img(profile.Signature.ToString() , new Size(70,70));


            FetchLoanApplications();


        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void active_loans_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label75_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void F_name_Click(object sender, EventArgs e)
        {

        }

        private void district_Click(object sender, EventArgs e)
        {

        }

        private void materialButton5_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void signature_Click(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void materialButton6_Click(object sender, EventArgs e)
        {

        }

        private void unproductive_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void label66_Click(object sender, EventArgs e)
        {

        }

        private void label70_Click(object sender, EventArgs e)
        {

        }

        private void Land_acreage_Click(object sender, EventArgs e)
        {

        }

        private void materialButton3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label67_Click(object sender, EventArgs e)
        {

        }

        private void gender_2_Click(object sender, EventArgs e)
        {

        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void coffee_prod_Click(object sender, EventArgs e)
        {

        }

        private void materialButton4_Click(object sender, EventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void label72_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void village_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label37_Click(object sender, EventArgs e)
        {

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void LoanApplications_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void trees_Click(object sender, EventArgs e)
        {

        }

        private void label73_Click(object sender, EventArgs e)
        {

        }

        private void label77_Click(object sender, EventArgs e)
        {

        }

        private void marital_status_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void phone_Click(object sender, EventArgs e)
        {

        }

        private void name_2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void subcounty_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void gender_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void disbursment_Click(object sender, EventArgs e)
        {

        }

        private void materialButton2_Click(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void NIN_no_Click(object sender, EventArgs e)
        {

        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click_1(object sender, EventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void coffee_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void date_joined_Click(object sender, EventArgs e)
        {

        }

        private void label71_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label69_Click(object sender, EventArgs e)
        {

        }

        private void label55_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private async void btnvalidate_Click(object sender, EventArgs e)
        {
            bool status = Convert.ToBoolean(profile.Active);
            if (MessageBox.Show("Would you like to " + (status ? "deactivate" : "activate") + " this profile ?", "Farmers Management", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (status)
                {
                    FarmersDAL farmer = new FarmersDAL();
                    dynamic result = await farmer.change_status(profile.id.ToString(), false);
                    btnvalidate.Text = "Activate account";

                    //Requery farmers
                    Form1.FarmersScreen.QueryFarmers();

                }
                else
                {
                    FarmersDAL farmer = new FarmersDAL();
                    dynamic result = await farmer.change_status(profile.id.ToString(), true);
                    btnvalidate.Text = "Deactivate account";
                    //MessageBox.Show(result.ToString());

                    Form1.FarmersScreen.QueryFarmers();

                }



            }
            else
            {
                // user clicked no

            }
        }

        private void unproductive_Click_1(object sender, EventArgs e)
        {

        }
    }
}
