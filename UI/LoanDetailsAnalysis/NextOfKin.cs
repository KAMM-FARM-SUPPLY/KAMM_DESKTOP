using KAMM_FARM_SERVICES.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAMM_FARM_SERVICES.UI.LoanDetailsAnalysis
{
    public partial class NextOfKin : Form
    {
        dynamic kin_info;
        public NextOfKin(dynamic kin)
        {
            InitializeComponent();
            kin_info = kin;
        }

        private async void NextOfKin_Load(object sender, EventArgs e)
        {
            // Load Information
            surname.Text= kin_info.surname;
            given_name.Text = kin_info.given_name;
            phone.Text = kin_info.telephone_number;
            NIN.Text = kin_info.nin_number;
            Signature.Image = await ImageProcesser.create_img(kin_info.signature.ToString(), new Size(200, 55));
            //Front.Image = await ImageProcesser.create_img(kin_info.front_side_id.ToString(), Front.Size);
            pictureBox1.Image = await ImageProcesser.create_img(kin_info.image.ToString(), pictureBox1.Size);
        }

        private void phone_Click(object sender, EventArgs e)
        {

        }

        private void given_name_Click(object sender, EventArgs e)
        {

        }
    }
}
