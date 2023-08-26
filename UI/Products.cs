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
using KAMM_FARM_SERVICES.DAL.DAL_Properties;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private dynamic ov_prods = null;

        private async void materialButton1_Click(object sender, EventArgs e)
        {
            ProductsProps product_info = new ProductsProps();
            product_info.name = name.Text;
            product_info.selling_rate = selling_rate.Text;
            product_info.cost_rate = cost_rate.Text;
            product_info.category = id_compute(categoryCBB.Text);

            ProductsDAL product = new ProductsDAL(product_info);
            bool success = await product.Create_product();
            if (success)
            {
                Clear();
                MessageBox.Show("Product created successfully");
                await Refresh();
            }
            else
            {
                MessageBox.Show("An error occured. Please try again later");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            frmCategories form = new frmCategories();
            form.Show();
        }

        private int id_compute(string category)
        {
            int id = 0;
            foreach(dynamic item in ov_prods)
            {
                if (item["name"] == category)
                {
                    return item.id;
                }
            }
            return id;
        }
        private void Clear()
        {
            id.Text = "";
            name.Text = "";
            cost_rate.Text = "";
            selling_rate.Text = "";
            categoryCBB.Text = "";
            quantity.Text = "";

            materialButton1.Enabled = false;
            materialButton2.Enabled = false;
            materialButton3.Enabled = false;
        }

        private async Task Refresh()
        {
            dynamic results = await ProductsDAL.Fetch_categories();
            if (results != null)
            {
                ov_prods = results;
                DataTable dt = new DataTable();
                dt.Columns.Add("Active", typeof(bool));
                dt.Columns.Add("id");
                dt.Columns.Add("name");
                dt.Columns.Add("quantity");
                dt.Columns.Add("Category");
                dt.Columns.Add("cost_rate");
                dt.Columns.Add("selling_rate");
                dt.Columns.Add("Date_added");

                //var category_items = new object() { };

                foreach (dynamic item in results)
                {
                    string category = item.name;
                    categoryCBB.Items.Add(category);
                    foreach (dynamic product in item["products"])
                    {
                        dt.Rows.Add(
                            true,
                            product.id,
                            product.name,
                            product.quantity,
                            category,
                            product.cost_rate,
                            product.selling_rate,
                            product.Date_added

                        );
                    }

                }
                dgv1.DataSource = dt;
            } else
            {
                MessageBox.Show("An error occured");
            }
            
        }

        private async void Products_Load(object sender, EventArgs e)
        {
            await Refresh();
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (name.Text.Length > 0)
            {
                materialButton1.Enabled = true;
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                id.Text = dgv1.Rows[e.RowIndex].Cells[1].Value.ToString();
                name.Text = dgv1.Rows[e.RowIndex].Cells[2].Value.ToString();
                quantity.Text = dgv1.Rows[e.RowIndex].Cells[3].Value.ToString();
                categoryCBB.Text = dgv1.Rows[e.RowIndex].Cells[4].Value.ToString();
                cost_rate.Text = dgv1.Rows[e.RowIndex].Cells[5].Value.ToString();
                selling_rate.Text = dgv1.Rows[e.RowIndex].Cells[6].Value.ToString();

                materialButton2.Enabled = true;
                materialButton3.Enabled = true;
                materialButton1.Enabled = false;
            }
        }
    }
}
