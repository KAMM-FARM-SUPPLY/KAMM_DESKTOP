using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Schema.ExpendituresSchema
{
    public class Expenditure
    {
        //Fields
        private int ID;
        private string? description;
        private int amount;
        private DateTime date_added;
        private ExpenditureCategory? category;


        //Properties
        public int id { get { return ID; } set { ID = value;} }
        public string? Description { get { return description; } set { description = value; } }
        public int Amount { get { return amount;} set { amount = value; } }
        public DateTime Date_added { get { return date_added; } set { date_added = value;} }
        public ExpenditureCategory? Category { get { return category; } set { category = value; } }

    }

    public class ExpenditureXMetaData
    {
        public int? total_expenditure_count;
        public Int64? total_expenditure;
        public Int64? query_total_expenditure;
        public int? query_total_count;
    }

    public class ExpenditureX
    {
        public Pagination? pagination;
        public ExpenditureXMetaData meta_data;
        public List<Expenditure> items;
    }
}
