using KAMM_FARM_SERVICES.UI.ExpenditureForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class frmExpenditure : Form
    {
        public frmExpenditure()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmExpenditure_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Height = Convert.ToInt32(0.1 * this.Height);
            panel2.Height = panel4.Height = Convert.ToInt32(0.1 * this.Height) / 2;

            panel3.Height = panel5.Height = (this.Height - (panel1.Height + panel2.Height))/2;


            //panel1 
            panel6.Width = panel7.Width = panel8.Width = this.Width / 3;


            //Panel3
            panel9.Width = panel10.Width = panel11.Width = panel15.Width = this.Width / 3;
            panel12.Height = panel13.Height = panel14.Height = panel16.Height = Convert.ToInt32(panel3.Height * 0.1);
            flowLayoutPanel1.Width = (panel5.Width - panel15.Width);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AddExpenditure form = new AddExpenditure(1);
            form.Show();
        }
    }
}
