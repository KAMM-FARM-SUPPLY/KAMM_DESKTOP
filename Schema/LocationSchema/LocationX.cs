using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Schema.LocationSchema
{
    public class DistrictX
    {
        public int id;
        public string name;
        public string more_info;
        public DateTime date_added;
        public List<SubcountyX> subcounties;

    }

    public class SubcountyX
    {
        public int id;
        public string name;
        public string more_info;
        public DateTime date_added;
        public List<VillageX> villages;
    }

    public class VillageX
    {
        public int id;
        public string name;
        public string more_info;
        public DateTime date_added;
    }
}
