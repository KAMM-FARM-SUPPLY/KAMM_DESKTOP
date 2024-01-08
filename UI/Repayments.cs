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
//using KAMM_FARM_SERVICES.UI.Repayments;

namespace KAMM_FARM_SERVICES.UI
{
    public partial class Repayments : Form
    {
        public Repayments()
        {
            InitializeComponent();
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

            panel19.Height = Convert.ToInt32(0.64 * this.Height);

            panel20.Height = this.Height - (panel19.Height + panel8.Height);

        }

        private void create_rep_Click(object sender, EventArgs e)
        {
            CreatePayment form = new CreatePayment();
            form.Show();
            
        }
    }
}
