using KAMM_FARM_SERVICES.DAL;
using KAMM_FARM_SERVICES.UI.LoanDetailsAnalysis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class LoanApplicationProfile : Form
    {

        dynamic LoanApplicationInfo = null;

        int current_collateral_index = 0;

        public LoanApplicationProfile(dynamic loanApplicationInfo)
        {
            InitializeComponent();
            LoanApplicationInfo = loanApplicationInfo;
        }

        private void panel1_Layout(object sender, LayoutEventArgs e)
        {
            //Creating the layout for the components 

            


        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void LoanApplicationProfile_Load(object sender, EventArgs e)
        {
            // Populating Data into the form 

            // The profile information
            Name.Text = Convert.ToString(LoanApplicationInfo.farmer.Name) + " " + Convert.ToString(LoanApplicationInfo.farmer.Given_name);
            phone.Text = Convert.ToString(LoanApplicationInfo.farmer.Phone_number);
            status.Text = Convert.ToString(LoanApplicationInfo.Status);
            Total_land.Text = Convert.ToString(LoanApplicationInfo.farmer.Total_land_acreage);
            coffee_acreage.Text = Convert.ToString(LoanApplicationInfo.farmer.Coffee_acreage);
            coffee_trees.Text = Convert.ToString(LoanApplicationInfo.farmer.No_of_trees);
            unproductive.Text = Convert.ToString(LoanApplicationInfo.farmer.Unproductive_trees);
            Coffee_prod.Text = Convert.ToString(LoanApplicationInfo.farmer.Ov_coffee_prod);


            Picture_bx.Image = await ImageProcesser.create_img(LoanApplicationInfo.Active_picture.ToString(), Picture_bx.Size);
            Signature_bx.Image = await ImageProcesser.create_img(LoanApplicationInfo.Signature.ToString(), Signature_bx.Size);

            //Loading Kin information
            NextOfKin kinform = new NextOfKin(LoanApplicationInfo.Next_of_kin[0]) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.kin_info.Controls.Clear();
            kinform.FormBorderStyle = FormBorderStyle.None;
            this.kin_info.Controls.Add(kinform);
            kinform.Show();


            //Loading Products
            DataTable products_dt= new DataTable();
            products_dt.Columns.Add("id");
            products_dt.Columns.Add("Name");
            products_dt.Columns.Add("Quantity");
            products_dt.Columns.Add("Rate");
            products_dt.Columns.Add("Total");

            foreach(dynamic dr in LoanApplicationInfo.Products)
            {
                products_dt.Rows.Add(
                    dr.id,
                    dr.product.name,
                    dr.quantity,
                    dr.rate,
                    dr.total

                );
            }
            label1.Text = "Total Amount : shs. " + LoanApplicationInfo.Total_cost.ToString("N0");
            products.DataSource = products_dt;

            // Loading Payments
            DataTable payments_dt = new DataTable();
            payments_dt.Columns.Add("id");
            payments_dt.Columns.Add("amount");
            payments_dt.Columns.Add("Info");
            payments_dt.Columns.Add("Date");

            foreach (dynamic dr in LoanApplicationInfo.Payments)
            {
                payments_dt.Rows.Add(
                    dr.id,
                    dr.amount,
                    dr.extra_info,
                    dr.date_added

                );
            }
            label3.Text = "Total Balance Due : shs. " + LoanApplicationInfo.Balance.ToString("N0");
            payments.DataSource = payments_dt;

            Collateral_bx.Image = await ImageProcesser.create_img(LoanApplicationInfo.Collateral[0].collateral_image.ToString(), Collateral_bx.Size);
            label9.Text = Convert.ToString(LoanApplicationInfo.Collateral[0].description);



        }

        private async void Am_lbl_Click(object sender, EventArgs e)
        {
            if ((current_collateral_index < LoanApplicationInfo.Collateral.Count) && !(current_collateral_index == (LoanApplicationInfo.Collateral.Count-1)))
            {
                current_collateral_index += 1;

                Collateral_bx.Image = await ImageProcesser.create_img(LoanApplicationInfo.Collateral[current_collateral_index].collateral_image.ToString(), Collateral_bx.Size);
                label9.Text = Convert.ToString(LoanApplicationInfo.Collateral[current_collateral_index].description);

            }
            else
            {
                current_collateral_index = 0;

                Collateral_bx.Image = await ImageProcesser.create_img(LoanApplicationInfo.Collateral[0].collateral_image.ToString(), Collateral_bx.Size);
                label9.Text = Convert.ToString(LoanApplicationInfo.Collateral[0].description);

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label74_Click(object sender, EventArgs e)
        {

        }

        private void Name_Click(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void phone_Click(object sender, EventArgs e)
        {

        }

        private void label60_Click(object sender, EventArgs e)
        {

        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            double latitude = LoanApplicationInfo.Collateral[current_collateral_index].latitude; 
            double longitude = LoanApplicationInfo.Collateral[current_collateral_index].longitude;

            string googleMapsUrl = $"https://www.google.com/maps?q={latitude},{longitude}";

            Process.Start(new ProcessStartInfo
            {
                FileName = googleMapsUrl,
                UseShellExecute = true
            });
        }
    }
}
