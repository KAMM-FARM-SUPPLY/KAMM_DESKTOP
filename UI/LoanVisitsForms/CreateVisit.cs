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

namespace KAMM_FARM_SERVICES.UI.LoanVisitsForms
{
    public partial class CreateVisit : Form
    {
        Visits visitprofile = new Visits();
        public CreateVisit(Visits visitprofile)
        {
            InitializeComponent();
            this.visitprofile = visitprofile;
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private async void farmer_id_TextChanged(object sender, EventArgs e)
        {
            
            if ((farmer_id.Text).Trim() != "")
            {
                dynamic profile = await Handlers.Fetch(Env.live_url + "/Farmer-detail/" + Convert.ToInt32(farmer_id.Text) + "/");

                if (profile != null)
                {

                    pictureBox2.Image = await ImageProcesser.create_img(profile.Profile_picture.ToString(), pictureBox2.Size);
                    Name.Text = profile.Name + " " + profile.Given_name;
                    label11.Text = profile.Phone_number;
                    label12.Text = profile.District;


                }
            }

            
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (((farmer_id.Text).Trim() != "") && ((Employee_id.Text).Trim() != ""))
            {
                string employee_id = Employee_id.Text;
                string Farmer_id = farmer_id.Text;
                string scheduled_date = dateTimePicker1.Value.ToString("yyyy-MM-ddTHH:mm:ss");
                dynamic create_visit = await Handlers.Post(Env.live_url + "/Create_visit/", new { employee_id, scheduled_date, Farmer_id });

                if (create_visit != null)
                {
                    MessageBox.Show("Visit created suceessfully");
                    visitprofile.Regenerate();
                    this.Close();
                }else
                {
                    MessageBox.Show("An error occured");
                }
            }
            Cursor = Cursors.Default;
        }
    }
}
