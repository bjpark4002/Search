//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Itlize.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblProduct
    {
        public string Product_ID { get; set; }
        public string Manufacturer_ID { get; set; }
        public string SubCategory_ID { get; set; }
        public string Product_Name { get; set; }
        public string Product_Image { get; set; }
        public string Series { get; set; }
        public string Model { get; set; }
        public string Model_Year { get; set; }
        public string Series_Info { get; set; }
        public string Featured { get; set; }
    
        public virtual tblManufacturer tblManufacturer { get; set; }
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}