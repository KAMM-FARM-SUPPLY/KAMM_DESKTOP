using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using KAMM_FARM_SERVICES.DAL;

namespace KAMM_FARM_SERVICES.UI.LoanVisitsForms
{
    public partial class VisitProfile : Form
    {
        

        dynamic profile = null;

        public VisitProfile(dynamic profile)
        {
            InitializeComponent();

            this.profile = profile;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void VisitProfile_Load(object sender, EventArgs e)
        {
            Name.Text = profile.Farmer_id.Name.ToString();
            name_2.Text = profile.Farmer_id.Given_name.ToString();
            district.Text = profile.Farmer_id.District.ToString();
            subcounty.Text = profile.Farmer_id.Subcounty.ToString();
            village.Text = profile.Farmer_id.Village.ToString();
            Land_acreage.Text = profile.Farmer_id.Total_land_acreage.ToString();
            NIN_no.Text = profile.Farmer_id.NIN_no.ToString();
            phone.Text = profile.Farmer_id.Phone_number.ToString();
            gender.Text = profile.Farmer_id.Gender.ToString();
            gender_2.Text = profile.Farmer_id.Gender.ToString();
            date.Text = profile.Farmer_id.Year_of_birth.ToString();
            date_joined.Text = profile.Farmer_id.Date_added.ToString();
            coffee.Text = profile.Farmer_id.Coffee_acreage.ToString();
            unproductive.Text = profile.Farmer_id.Unproductive_trees.ToString();
            trees.Text = profile.Farmer_id.No_of_trees.ToString();
            coffee_prod.Text = profile.Farmer_id.Ov_coffee_prod.ToString();

            pictureBox1.Image = await ImageProcesser.create_img(profile.Farmer_id.Profile_picture.ToString(), new Size(214, 163));
            Signature_1.Image = await ImageProcesser.create_img(profile.Farmer_id.Signature.ToString(), new Size(70, 70));

            // Filling the pre approved form with information

            name_3.Text = profile.Farmer_profile_snapshot.Name.ToString();
            other_name.Text = profile.Farmer_profile_snapshot.Given_name.ToString();
            district_2.Text = profile.Farmer_profile_snapshot.District.ToString();
            county_2.Text = profile.Farmer_profile_snapshot.Subcounty.ToString();
            village_2.Text = profile.Farmer_profile_snapshot.Village.ToString();
            acreage_2.Text = profile.Farmer_profile_snapshot.Total_land_acreage.ToString();
            nin_2.Text = profile.Farmer_profile_snapshot.NIN_no.ToString();
            phone_2.Text = profile.Farmer_profile_snapshot.Phone_number.ToString();
            gender_pre.Text = profile.Farmer_profile_snapshot.Gender.ToString();
            gender_pre_2.Text = profile.Farmer_profile_snapshot.Gender.ToString();
            DOB.Text = profile.Farmer_profile_snapshot.Year_of_birth.ToString();
            date_joined_2.Text = profile.Farmer_profile_snapshot.Date_added.ToString();
            Coffee_acreage_2.Text = profile.Farmer_profile_snapshot.Coffee_acreage.ToString();
            unproductive_trees_2.Text = profile.Farmer_profile_snapshot.Unproductive_trees.ToString();
            trees.Text = profile.Farmer_profile_snapshot.No_of_trees.ToString();
            coffee_production_2.Text = profile.Farmer_profile_snapshot.Ov_coffee_prod.ToString();

            pictureBox4.Image = await ImageProcesser.create_img(profile.Farmer_profile_snapshot.Profile_picture.ToString(), new Size(214, 163));
            pictureBox3.Image = await ImageProcesser.create_img(profile.Farmer_profile_snapshot.Signature.ToString(), new Size(70, 70));



            //Creating an editable Datagrid View
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Given Name");
            dt.Columns.Add("District");
            dt.Columns.Add("Subcounty");
            dt.Columns.Add("Village");
            dt.Columns.Add("NIN");
            dt.Columns.Add("Gender");
            dt.Columns.Add("Year of birth");
            dt.Columns.Add("Marital Status");
            dt.Columns.Add("Phone");
            dt.Columns.Add("Total Land");
            dt.Columns.Add("Coffee acreage");
            dt.Columns.Add("Trees");
            dt.Columns.Add("Unproductive");
            dt.Columns.Add("Coffee prod");

            dt.Rows.Add(
                profile.Farmer_profile_snapshot.Name.ToString(),
                profile.Farmer_profile_snapshot.Given_name.ToString(),
                profile.Farmer_profile_snapshot.District.ToString(),
                profile.Farmer_profile_snapshot.Subcounty.ToString(),
                profile.Farmer_profile_snapshot.Village.ToString(),
                profile.Farmer_profile_snapshot.NIN_no.ToString(),
                profile.Farmer_profile_snapshot.Gender.ToString(),
                profile.Farmer_profile_snapshot.Year_of_birth.ToString(),
                profile.Farmer_profile_snapshot.Marital_status.ToString(),
                profile.Farmer_profile_snapshot.Phone_number.ToString(),
                profile.Farmer_profile_snapshot.Total_land_acreage.ToString(),
                profile.Farmer_profile_snapshot.Coffee_acreage.ToString(),
                profile.Farmer_profile_snapshot.No_of_trees.ToString(),
                profile.Farmer_profile_snapshot.Unproductive_trees.ToString(),
                profile.Farmer_profile_snapshot.Ov_coffee_prod.ToString()

                );

            ProfileDGV.DataSource = dt;

        }
    }
}
