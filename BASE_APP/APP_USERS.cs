//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BASE_APP
{
    using System;
    using System.Collections.Generic;
    
    public partial class APP_USERS
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserDescription { get; set; }
        public string Password { get; set; }
        public int ProfileID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public string Activated { get; set; }
    }
}