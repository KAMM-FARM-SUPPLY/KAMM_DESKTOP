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

namespace KAMM_FARM_SERVICES.UI
{
    public partial class FarmerProfile : Form
    {

        public dynamic profile = null;
        public FarmerProfile(dynamic profile_info)
        {
            InitializeComponent();
            profile = profile_info;
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
            name_2.Text = profile.Name.ToString();
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


        }
    }
}
