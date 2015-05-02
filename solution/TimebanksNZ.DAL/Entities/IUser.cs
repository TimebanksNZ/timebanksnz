using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimebanksNZ.DAL.Entities
{
    public interface IUser
    {
        Guid Id { get; set; }
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Community { get; set; }
        string City { get; set; }
        string Suburb { get; set; }
        string PostalCode { get; set; }
        string Address1 { get; set; }
        string Address2 { get; set; }
        string MobilePhone { get; set; }
        string HomePhone { get; set; }
        string WorkPhone { get; set; }
        bool IsPhonePublic { get; set; }
        bool IsAddressPublic { get; set; }
        bool IsEmailPublic { get; set; }
    }
}
