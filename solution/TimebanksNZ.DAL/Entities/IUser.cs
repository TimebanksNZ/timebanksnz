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
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
        string City { get; set; }
        string Suburb { get; set; }
        string PostCode { get; set; }
        string Address { get; set; }
        string Community { get; set; }
    }
}
