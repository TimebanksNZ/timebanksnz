//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Timebanks.NZ.DAL.MySql.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class member
    {
        public member()
        {
            this.offer_need = new HashSet<offer_need>();
            this.tags = new HashSet<tag>();
            this.member_permission = new HashSet<member_permission>();
            this.trades = new HashSet<trade>();
            this.trades1 = new HashSet<trade>();
        }
    
        public System.Guid id_member { get; set; }
        public int id_timebank { get; set; }
        public bool approved { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string street_address_1 { get; set; }
        public string street_address_2 { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string mobile_phone { get; set; }
        public string home_phone { get; set; }
        public string work_phone { get; set; }
        public System.DateTime created { get; set; }
        public double geo_lat { get; set; }
        public double geo_long { get; set; }
        public string email_address { get; set; }
        public bool is_address_public { get; set; }
        public bool is_email_validated { get; set; }
        public bool is_email_public { get; set; }
        public bool is_deleted { get; set; }
        public bool is_phone_public { get; set; }
    
        public virtual timebank timebank { get; set; }
        public virtual ICollection<offer_need> offer_need { get; set; }
        public virtual ICollection<tag> tags { get; set; }
        public virtual ICollection<member_permission> member_permission { get; set; }
        public virtual ICollection<trade> trades { get; set; }
        public virtual ICollection<trade> trades1 { get; set; }
    }
}
