using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.UI;
using KAMM_FARM_SERVICES.UI.Payment;
using KAMM_FARM_SERVICES.Helpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using KAMM_FARM_SERVICES.DAL;
//using KAMM_FARM_SERVICES.UI.Repayments;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class Repayments : Form
    {

        DataTable payments_dt = new DataTable();
        dynamic current_payments = null;
        dynamic Locations = null;
        dynamic farmers = null;


        public Repayments()
        {
            InitializeComponent();


            payments_dt.Columns.Add("Select", typeof(bool));
            payments_dt.Columns.Add("Application id");
            payments_dt.Columns.Add("Name");
            payments_dt.Columns.Add("Phone");
            payments_dt.Columns.Add("Extra info");
            payments_dt.Columns.Add("Amount");
            payments_dt.Columns.Add("Total");
            payments_dt.Columns.Add("Balance due");
            payments_dt.Columns.Add("Date_added");
        }

        


        private void panel1_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(0.3 * this.Width);

            panel2.Height = panel3.Height = panel4.Height = panel5.Height = panel6.Height = panel7.Height = panel9.Height = Convert.ToInt32(panel1.Height / 7);

            panel8.Height = Convert.ToInt32(0.25 * this.Height);

            panel10.Width = Convert.ToInt32(0.35 * panel8.Width);

            panel13.Width = Convert.ToInt32(0.35 * panel8.Width);

            panel16.Width = (panel8.Width - (panel10.Width + panel13.Width)) + Convert.ToInt32(0.08 * panel8.Width);

            panel11.Height = panel12.Height = Convert.ToInt32(panel8.Height / 2);

            panel14.Height = panel15.Height = panel17.Height = panel18.Height = Convert.ToInt32(0.3 * panel13.Height);

            panel19.Height = Convert.ToInt32(0.7 * this.Height);

            panel20.Height = this.Height - (panel19.Height + panel8.Height);

        }

        private void populateDGV(dynamic payments)
        {
            current_payments = payments;

            payments_dt.Rows.Clear();
            if (payments != null)
            {
                foreach (dynamic payment in payments["items"])
                {
                    payments_dt.Rows.Add(
                        false,
                        payment.application_id.id,
                        payment.application_id.farmer.Name + " "  + payment.application_id.farmer.Given_name,
                        payment.application_id.farmer.Phone_number,
                        payment.extra_info,
                        payment.amount,
                        payment.application_id.Total_cost,
                        payment.application_id.Balance,
                        payment.date_added

                   );
                }
                Rep_DGV.DataSource = payments_dt;

                //Rep_DGV.Columns[10].Visible = false;


            }
        }

        private void create_rep_Click(object sender, EventArgs e)
        {
            CreatePayment form = new CreatePayment(this);
            form.Show();
            
        }

        public int convert_to_id(string name)
        {
            foreach (dynamic farmer in farmers)
            {
                var Name = Convert.ToString(farmer.Name) + " " + Convert.ToString(farmer.Given_name);

                if (Name == name)
                {
                    return Convert.ToInt32(farmer.id);
                }
            }

            return 0;
        }

        public async void Regenerate()
        {
            string derived_uri = Env.live_url + "/Get_payments?lazy_load=False&" +
                    ((farmer_cb.Text.Trim() != "") ? ("farmer=" + convert_to_id(farmer_cb.Text) + "&") : ("")) +
                    ((status_cb.Text.Trim() != "") ? ("status=" + status_cb.Text + "&") : ("")) +
                    ((district_cb.Text.Trim() != "") ? ("District=" + district_cb.Text + "&") : ("")) +
                    ((subcounty_cb.Text.Trim() != "") ? ("Subcounty=" + subcounty_cb.Text + "&") : ("")) +
                    ((village_cb.Text.Trim() != "") ? ("Village=" + village_cb.Text + "&") : ("")) +
                    ((label7.Text == "?") ? ("Start_date=" + dateTimePicker1.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "&") : ("")) +
                    ((label7.Text == "?") ? ("End_date=" + dateTimePicker2.Value.AddDays(-1).ToString("yyyy-MM-dd HH:mm:ss") + "&") : ("")) +
                    ((amount.Text.Trim() != "") ? ("amount_symbol=" + amount_symbol.Text + "&") : ("")) +
                    ((amount.Text.Trim() != "") ? ("amount=" + amount.Text + "&") : ("")) +
                    ((application_id.Text.Trim() != "") ? ("application_id=" + application_id.Text + "&") : (""))

                    ;

            dynamic payments = await Handlers.Fetch(derived_uri);

            populateDGV(payments);


        }

        private async void Repayments_Load(object sender, EventArgs e)
        {

            dynamic payments = await Handlers.Fetch(Env.live_url + "/Get_payments?lazy_load=False");

            populateDGV(payments);

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

            //Load Farmers
            FarmersDAL Farmer = new FarmersDAL();
            farmers = await Farmer.Fetch();

            foreach (dynamic farmer in farmers)
            {
                
                var Name = Convert.ToString(farmer.Name) + " " + Convert.ToString(farmer.Given_name);

                farmer_cb.Items.Add(Name);
            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (label7.Text == "X")
            {
                label7.Text = "?";
                Regenerate();
            }
            else
            {
                label7.Text = "X";
                Regenerate();
            }
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

        private void amount_symbol_Click(object sender, EventArgs e)
        {
            amount_symbol.Text = Shift_symbols(amount_symbol.Text);

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

        private void district_cb_TextChanged(object sender, EventArgs e)
        {
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

        private void application_id_TextChanged(object sender, EventArgs e)
        {
                Regenerate();

        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            Regenerate();
        }
    }
}
