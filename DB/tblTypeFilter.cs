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
    
    public partial class tblTypeFilter
    {
        public string SubCategory_ID { get; set; }
        public string Type_Name { get; set; }
        public string Type_Options { get; set; }
    
        public virtual tblSubCategory tblSubCategory { get; set; }
    }
}
