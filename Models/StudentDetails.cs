using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GroupApiInMVC.Models
{
    public class StudentDetails
    {
        public int Roll_no { get; set; }
        public string Std_name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}