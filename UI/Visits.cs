using KAMM_FARM_SERVICES.DAL;
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
    public partial class Visits : Form
    {

        DataTable VisitsDT = new DataTable();
        dynamic currnt_visits = null;

        public Visits()
        {
            InitializeComponent();


            VisitsDT.Columns.Add("Select", typeof(bool));
            VisitsDT.Columns.Add("Farmer", typeof(string));
            VisitsDT.Columns.Add("Field Officer", typeof(string));
            VisitsDT.Columns.Add("Status", typeof(string));
            VisitsDT.Columns.Add("Validity", typeof(string));
            VisitsDT.Columns.Add("Scheduled Date", typeof(string));
            VisitsDT.Columns.Add("Date created", typeof(string));
            VisitsDT.Columns.Add("District", typeof(string));
            VisitsDT.Columns.Add("Subcounty", typeof(string));
            VisitsDT.Columns.Add("Village", typeof(string));

        }

        private void populateDGV(dynamic Visits)
        {
            currnt_visits = Visits;

            VisitsDT.Rows.Clear();
            if (Visits != null)
            {
                foreach(dynamic visit in Visits)
                {
                    VisitsDT.Rows.Add(
                        false,
                        visit.Farmer_id.Name + " " + visit.Farmer_id.Given_name,
                        visit.Employee.username,
                        visit.Status,
                        visit.Validity,
                        visit.scheduled_date,
                        visit.Date_added,
                        visit.Farmer_id.District,
                        visit.Farmer_id.Subcounty,
                        visit.Farmer_id.Village
                   );
                }
                FarmerVisits.DataSource = VisitsDT;
               

            }
        }



        private void Visits_Layout(object sender, LayoutEventArgs e)
        {
            panel1.Width = Convert.ToInt32(0.3 * this.Width);

            panel9.Height = Convert.ToInt32(0.25 * this.Height);

            panel2.Height = panel3.Height = panel4.Height = panel5.Height = panel6.Height = panel7.Height = panel8.Height = Convert.ToInt32(this.Height / 7);


            panel10.Width = Convert.ToInt32(0.35 * panel9.Width);
            panel11.Height = panel12.Height = Convert.ToInt32(0.5 * panel10.Height);

            panel14.Width = Convert.ToInt32(0.35 * panel9.Width);

            panel15.Height = panel16.Height = Convert.ToInt32(panel14.Height * 0.6)/2;

            panel17.Width = (panel9.Width - (panel10.Width + panel14.Width)) + Convert.ToInt32(0.08 * panel9.Width);

            panel18.Height = panel19.Height = panel15.Height;

        }

        private async void Visits_Load(object sender, EventArgs e)
        {
            VisitsDAL visitsDAL = new VisitsDAL();
            dynamic visits = await visitsDAL.Fetch_Visits();
            populateDGV(visits);

        }

        

        private void FarmerVisits_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
