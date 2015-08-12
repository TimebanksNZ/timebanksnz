//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimebanksNZ.DAL.MySqlDb.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public user()
        {
            this.Claims = new HashSet<userclaim>();
            this.userlogins = new HashSet<userlogin>();
            this.Roles = new HashSet<role>();
        }
    
        public string Id { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public Nullable<System.DateTime> LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
    
        public virtual ICollection<userclaim> Claims { get; set; }
        public virtual ICollection<userlogin> userlogins { get; set; }
        public virtual ICollection<role> Roles { get; set; }
    }
}
