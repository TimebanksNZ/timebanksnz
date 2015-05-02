using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimebanksNZ.DAL.Entities
{
    public interface IUser
    {
        Guid IdMember { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Community { get; set; }
        string City { get; set; }
        string Suburb { get; set; }
        string Postcode { get; set; }
        string StreetAddress1 { get; set; }
        string StreetAddress2 { get; set; }
        string MobilePhone { get; set; }
        string HomePhone { get; set; }
        string WorkPhone { get; set; }
        bool IsPhonePublic { get; set; }
        bool IsAddressPublic { get; set; }
        bool IsEmailPublic { get; set; }
        bool Approved { get; set; }
    }
}
