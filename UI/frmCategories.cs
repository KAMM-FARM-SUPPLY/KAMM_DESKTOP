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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

        private async Task Refresh()
        {
            CategoriesDAL category = new CategoriesDAL();
            dynamic categories = await category.Fetch_categories();
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("Name");
            dt.Columns.Add("Products");
            dt.Columns.Add("Description");
            dt.Columns.Add("Date_added");
            if (categories != null)
            {
                foreach (dynamic item in categories)
                {
                    dt.Rows.Add(
                        item["id"],
                        item["name"],
                        item["products"].Count,
                        item["description"],
                        item["date_added"]
                    );

                }
                dgv1.DataSource = dt;
            }
            else
            {
                MessageBox.Show("An error occured");
            }

        }

        private void Clear()
        {
            id.Text = "";
            Nametxt.Text = "";
            descriptiontxt.Text = "";
            materialButton1.Enabled = false;
            materialButton2.Enabled = false;
            materialButton3.Enabled = false;
        }

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            CategoriesDAL category = new CategoriesDAL();
            bool created = await category.Create_category(Nametxt.Text, descriptiontxt.Text);
            if (created)
            {
                Clear();
                MessageBox.Show("Category created successfully");
                await Refresh();
            }else
            {
                MessageBox.Show("An error occured. Try again later");
            }

        }

        private async void frmCategories_Load(object sender, EventArgs e)
        {
            await Refresh();
           
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if(row >= 0)
            {
                id.Text = dgv1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Nametxt.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                descriptiontxt.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();

                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
                materialButton1.Enabled = false;
            }
            
        }

        private async void materialButton2_Click(object sender, EventArgs e)
        {
            CategoriesDAL category = new CategoriesDAL();
            bool success = await category.Update_category(Nametxt.Text, descriptiontxt.Text, Convert.ToInt32(id.Text));
            if (success)
            {
                Clear();
                MessageBox.Show("Category successfully updated");
                await Refresh();
            }else
            {
                MessageBox.Show("An error occured. Please try again later");
            }
        }

        private async void materialButton3_Click(object sender, EventArgs e)
        {
            CategoriesDAL category = new CategoriesDAL();
            bool success = await category.Delete_category(Convert.ToInt32(id.Text));
            if (success)
            {
                Clear();
                MessageBox.Show("Category successfully deleted");
                await Refresh();
            }
            else
            {
                MessageBox.Show("An error occured. Please try again later");
            }

        }

        private void Nametxt_TextChanged(object sender, EventArgs e)
        {
            if (Nametxt.Text.Length > 0)
            {
                materialButton1.Enabled = true;
            }
        }
    }
}
