using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimebanksNZ.DAL.Entities
{
    public class User : IUser
    {
        public Guid IdMember { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
        public string Community { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public bool IsPhonePublic { get; set; }
        public bool IsAddressPublic { get; set; }
        public bool IsEmailPublic { get; set; }
        public bool AcceptedTerms { get; set; }
        public bool Approved { get; set; }
        public DateTime Created { get; set; }
        public double GeoLat { get; set; }
        public double GeoLong { get; set; }
        public Timebank TimeBank { get; set; }
        public bool IsEmailValidated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
