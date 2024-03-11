using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Components
{
    public class Reports : ReportViewer
    {
        public Reports()
        {
            this.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DoubleBuffered = true;

        }

    }
}
