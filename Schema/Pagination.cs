using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Schema
{
    public class Pagination
    {
        public int? count;
        public int? previous;
        public int? next;
        public int? pages;
        public int? per_page;
        public int? page;
    }
}
