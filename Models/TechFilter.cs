using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Itlize.Models
{
    public class TechFilter
    {
        public string SubCategory_ID { get; set; }
        public string Min_Value { get; set; }
        public string Max_Value { get; set; }
        public string Property_ID { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}