using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Schema.ExpendituresSchema
{
    public class ExpenditureCategory
    {
        private int ID;
        private string? name;
        private string? overall_category;
        private string? description;
        private DateTime date_added;
        private List<Expenditure>? Expenditures;

        public int id { get { return ID; } set { ID = value; } }
        public string? Name { get { return name; } set { name = value; } }
        public string? Overall_category { get { return overall_category; } set { overall_category = value; } }
        public string? Description { get { return description; } set { description = value; } }
        public DateTime Date_added { get { return date_added; } set { date_added = value; } }
        public List<Expenditure>? expenditures { get { return Expenditures; } set { Expenditures = value; } }
            
    }

    public class ExpenditureCategoryXMetaData
    {
        public int? total_categories;
        public int? query_total_categories;
    }

    public class ExpenditureCategoryX
    {
        public ExpenditureCategoryXMetaData? meta_data;
        public Pagination? pagination;
        public List<ExpenditureCategory>? items;
    }

    


}
