using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library_system.Models
{
    public class SubCategoryModel
    {
        public int id { get; set; }
        public Nullable<int> main_category_id { get; set; }
        public string sub_category_name { get; set; }
    }
}