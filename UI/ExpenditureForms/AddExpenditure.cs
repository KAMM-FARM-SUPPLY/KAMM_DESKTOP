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
    public partial class AddExpenditure : Form
    {
        private int ov_category;
        public AddExpenditure(int overall_category)
        {
            InitializeComponent();

            ov_category= overall_category;
        }

        private void materialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddExpenditure_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddExpenditureCategory form = new AddExpenditureCategory(ov_category);
            form.Show();
        }
    }
}
