//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace fortune_teller_mvc.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string Lastname { get; set; }
        public int NumOfSibs { get; set; }
        public int BirthMonth { get; set; }
        public string FavColor { get; set; }
        public int Age { get; set; }
        public int FortuneID { get; set; }
    
        public virtual Fortune Fortune { get; set; }
    }
}
