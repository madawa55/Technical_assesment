using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace library_system.Models
{
    public class Main_Book_Details
    {
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string Category { get; set; }
        public string SubCategory { get;set; }
        public string Author { get; set; }
    }
}