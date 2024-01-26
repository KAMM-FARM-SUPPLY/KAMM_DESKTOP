using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KAMM_FARM_SERVICES.Helpers;
using Newtonsoft.Json;

namespace KAMM_FARM_SERVICES.UI.ExpenditureForms
{
    public partial class AddExpenditure : Form
    {
        private int ov_category;
        private dynamic items;

        public frmExpenditure exp;
        public AddExpenditure(int overall_category , frmExpenditure exp)
        {
            InitializeComponent();

            ov_category = overall_category;
            this.exp = exp;
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public async void Regenerate()
        {
            dynamic results = await Handlers.Fetch(
                Env.live_url + "/GetExpenditureCategories?Overall_category=" + ov_category
            );

            if (results != null)
            {

                materialComboBox1.Items.Clear();

                items = results["items"];

                foreach (dynamic result in results["items"])
                {
                    materialComboBox1.Items.Add(result.Name);
                }

            }
        }

        private async void AddExpenditure_Load(object sender, EventArgs e)
        {
            Regenerate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddExpenditureCategory form = new AddExpenditureCategory(ov_category ,exp , this);
            form.Show();
        }

        private int get_id(string name)
        {
            foreach(dynamic item in items)
            {
                if (item["Name"].ToString() == name)
                {
                    return Convert.ToInt32(item["id"]);
                }
            }
            return 0;
        }

        private async void add_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            string Description = description.Text.Trim();
            string Amount = amount.Text.Trim();
            if (!string.IsNullOrEmpty( Amount ) )
            {
                bool created = await Handlers.Post(Env.live_url + "/Create_expenditure/" + get_id(materialComboBox1.Text).ToString() + "/", new { Description, Amount });

                if (created)
                {
                    MessageBox.Show("Expenditure created successfully");

                    Cursor = Cursors.Default;

                    exp.Regenerate();

                    this.Close();
                }
                else
                {
                    MessageBox.Show("An error occured during the saving of the expenditure");
                }
            }
            else
            {
                MessageBox.Show("Enter the amount .");
            }
            
            Cursor = Cursors.Default;


        }
    }
}
