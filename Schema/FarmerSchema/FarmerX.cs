using KAMM_FARM_SERVICES.Schema.ExpendituresSchema;
using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KAMM_FARM_SERVICES.Schema.FarmerSchema
{
    public class Farmer
    {
        public int id;
        public UserX user;
        public string Name;
        public string Given_name;
        public string District;
        public string Subcounty;
        public string Village;
        public string NIN_no;
        public string Gender;
        public string Year_of_birth;
        public string Marital_status;
        public string Phone_number;
        public DateTime Date_added;
        public UserX? Added_by;
        public Decimal Total_land_acreage;
        public Decimal Coffee_acreage;
        public Decimal No_of_trees;
        public Decimal Unproductive_trees;
        public Decimal Ov_coffee_prod;
        public Uri Front_side_id;
        public Uri Hind_side_id;
        public Uri Signature;
        public Uri Profile_picture;
        public bool Active;
    }

    public class UserX
    {
        public int id;
        public string? password;
        public string? last_login;
        public bool is_superuser;
        public string username;
        public string? first_name;
        public string? last_name;
        public string? email;
        public bool is_staff;
        public bool is_active;
        public DateTime date_joined;

    }

    public class FarmerXMetaData
    {
        public int total_farmers;
        public int query_total_farmers;
    }

    public class FarmerX
    {
        public Pagination? pagination;
        public FarmerXMetaData meta_data;
        public List<Farmer> items;
    }
}
