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

namespace KAMM_FARM_SERVICES.UI.ExpenditureForms
{
    public partial class AddExpenditureCategory : Form
    {
        private int ov_category;

        DataTable dt = new DataTable();


        public AddExpenditureCategory(int overall_category)
        {
            InitializeComponent();

            ov_category = overall_category;

            dt.Columns.Add("Name");
            dt.Columns.Add("Description");
            dt.Columns.Add("Date Added");
            dt.Columns.Add("Count");
        }

        private void AddExpenditureCategory_Load(object sender, EventArgs e)
        {
            Regenerate();
        }

        public async void Regenerate()
        {
            dynamic results = await Handlers.Fetch(
                Env.live_url + "/GetExpenditureCategories?Overall_category=" + ov_category
            );

            if ( results != null )
            {
                dt.Rows.Clear();

                foreach(dynamic category in results.items)
                {
                    dt.Rows.Add(
                        category.Name,
                        category.Description,
                        category.Date_added,
                        0
                        );
                }

                dgv1.DataSource = dt;
            }
        }

        private async void add_Click(object sender, EventArgs e)
        {
            string Name = name.Text.Trim();
            string Description = this.Description.Text.Trim();
            int Overall_category = ov_category;
            bool created = await Handlers.Post(Env.live_url + "/Create_expenditure_category/", new { Name, Description, Overall_category });
            
            if (created)
            {
                MessageBox.Show("The category has been created successfully");
                Regenerate();
            }
            else
            {
                MessageBox.Show("An error occured while creating the category");
            }
        }
    }
}
