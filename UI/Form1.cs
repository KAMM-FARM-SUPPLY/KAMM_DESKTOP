using KAMM_FARM_SERVICES.UI;
using MaterialSkin;
using System.Runtime.InteropServices;

namespace KAMM_FARM_SERVICES
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
          (
               int nLeftRect,
               int nTopRect,
               int nRightRect,
               int nBottomRect,
               int nWidthEllipse,
              int nHeightEllipse

           );

        public static System.Drawing.Size PnlContainer;

        public static Farmers FarmersScreen = null;

        public Form1()
        {
            InitializeComponent();


            System.Drawing.Rectangle workingRectangle =
                Screen.PrimaryScreen.WorkingArea;

            // Set the size of the form slightly less than size of 
            // working rectangle.


        // Creating overall size to be used for the major form.
            System.Drawing.Size working_size = new System.Drawing.Size(
            workingRectangle.Width - 10, workingRectangle.Height - 10);


            this.Size = working_size;

            PnlContainer = panel3.Size;

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //btnOverview.BackColor = Color.FromArgb(46, 51, 73);
            //panel4.Height = btnOverview.Height;
            //panel4.Top = btnOverview.Top;
            //panel4.Left = btnOverview.Left;

            //this.panel3.Controls.Clear();
            ////registrationForm FrmDashboard_Vrb = new registrationForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //Overview form = new Overview() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            //form.FormBorderStyle = FormBorderStyle.None;
            //this.panel3.Controls.Add(form);
            //form.Show();
            //btnOverview.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnFarmers_Click(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = btnFarmers.Height;
            panel4.Top = btnFarmers.Top;
            panel4.Left = btnFarmers.Left;

            this.panel3.Controls.Clear();
            //registrationForm FrmDashboard_Vrb = new registrationForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            Farmers form = new Farmers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            btnFarmers.BackColor = Color.FromArgb(24, 30, 54);


            FarmersScreen = form;

        }

        private void btnCA_Click(object sender, EventArgs e)
        {
            //btnCA.BackColor = Color.FromArgb(46, 51, 73);
            //panel4.Height = btnCA.Height;
            //panel4.Top = btnCA.Top;
            //panel4.Left = btnCA.Left;
            //btnCA.BackColor = Color.FromArgb(24, 30, 54);


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button1.Height;
            panel4.Top = button1.Top;
            panel4.Left = button1.Left;

            this.panel3.Controls.Clear();
            Products form = new Products() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button1.BackColor = Color.FromArgb(24, 30, 54);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button2.BackColor = Color.FromArgb(46, 51, 73);
            //panel4.Height = button2.Height;
            //panel4.Top = button2.Top;
            //panel4.Left = button2.Left;
            //button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
            panel4.Left = button3.Left;
            button3.BackColor = Color.FromArgb(24, 30, 54);

            this.panel3.Controls.Clear();
            Location form = new Location() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button4.BackColor = Color.FromArgb(46, 51, 73);
            //panel4.Height = button4.Height;
            //panel4.Top = button4.Top;
            //panel4.Left = button4.Left;
            //button4.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button3.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button3.Height;
            panel4.Top = button3.Top;
            panel4.Left = button3.Left;
            button3.BackColor = Color.FromArgb(24, 30, 54);

            this.panel3.Controls.Clear();
            Location form = new Location() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button1.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            button2.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button2.Height;
            panel4.Top = button2.Top;
            panel4.Left = button2.Left;

            this.panel3.Controls.Clear();
            LoanApplications form = new LoanApplications() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button2.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button4.Height;
            panel4.Top = button4.Top;
            panel4.Left = button4.Left;

            this.panel3.Controls.Clear();
            Repayments form = new Repayments() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(46, 51, 73);
            panel4.Height = button5.Height;
            panel4.Top = button5.Top;
            panel4.Left = button5.Left;

            this.panel3.Controls.Clear();
            Visits form = new Visits() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            form.FormBorderStyle = FormBorderStyle.None;
            this.panel3.Controls.Add(form);
            form.Show();
            button4.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}