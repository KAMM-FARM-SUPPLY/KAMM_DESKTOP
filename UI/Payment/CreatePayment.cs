using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.DAL;
using KAMM_FARM_SERVICES.Helpers;

namespace KAMM_FARM_SERVICES.UI.Payment
{
    public partial class CreatePayment : Form
    {
        Repayments repayment;
        public CreatePayment(Repayments repayments)
        {
            InitializeComponent();
            this.repayment = repayments;
        }

        bool valid_application_id = false;

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void farmer_id_TextChanged(object sender, EventArgs e)
        {
            string Loanapplication_id = farmer_id.Text.Trim();
            if (Loanapplication_id != "")
            {
                dynamic profile = await Handlers.Fetch(Env.live_url + "/Queryapplications?lazy_load=False&id=" + Loanapplication_id);

                if (profile != null && (profile["items"].Count > 0))
                {
                    Name.Text = profile["items"][0].farmer.Name + " " + profile["items"][0].farmer.Given_name;

                    phone.Text = profile["items"][0].farmer.Phone_number.ToString();

                    total.Text = "shs." + profile["items"][0].Total_cost.ToString("N0");
                    balance.Text = "shs." + profile["items"][0].Balance.ToString("N0");

                    profile_pic.Image = await ImageProcesser.create_img(profile["items"][0].Active_picture.ToString(), profile_pic.Size);

                    signature.Image = await ImageProcesser.create_img(profile["items"][0].Signature.ToString(), signature.Size);

                    valid_application_id = true;
                        
                }

            }
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string application_id = ((farmer_id.Text.Trim() != "") && valid_application_id) ? farmer_id.Text : "";

            string extra_info = materialTextBox1.Text;

            int amount;

            bool is_amount  = int.TryParse(materialTextBox2.Text, out amount);

            if (is_amount && (application_id != null))
            {
                bool result = await Handlers.Post(Env.live_url + "/Create_payment/", new { application_id, extra_info, amount });

                if (result)
                {
                    MessageBox.Show("Balance payment added successfully");
                    this.repayment.Regenerate();
                }
                else
                {

                }
            }
            else
            {
                MessageBox.Show("There is a problem with either the amount entered or application id");
            }
            Cursor = Cursors.Default;



        }
    }
}
