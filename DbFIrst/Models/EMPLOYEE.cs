//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DbFIrst.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPLOYEE
    {
        public int ID { get; set; }
        public string FIRSTNAME { get; set; }
        public string LASTNAME { get; set; }
        public Nullable<byte> DEPTID { get; set; }
    
        public virtual Deaprtment Deaprtment { get; set; }
    }
}
