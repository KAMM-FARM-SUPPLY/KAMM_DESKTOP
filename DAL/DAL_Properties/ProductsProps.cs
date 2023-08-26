using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.DAL.DAL_Properties
{
    public class ProductsProps
    {
        //fields
        private int Id = 0;
        private string Name;
        private string Cost_rate;
        private string Selling_rate;
        private Decimal Quantity;
        private int Category;
        private DateTime Date_added = DateTime.Now;

        //Properties
        public int id { get { return Id; } set { Id = value; } }
        public string name { get { return Name; } set { Name = value; } }
        public string cost_rate { get { return Cost_rate; } set { Cost_rate = value; } }
        public string selling_rate { get { return Selling_rate; } set { Selling_rate = value; } }
        public Decimal quantity { get { return Quantity; } set { Quantity = value; } }
        public int category { get { return Category; } set { Category = value; } }
        public DateTime date_added { get { return Date_added; } set { Date_added = value; } }

    }
}