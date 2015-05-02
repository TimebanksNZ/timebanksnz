using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimebanksNZ.DAL.Entities;

namespace TImebanksNZ.DAL.Mock
{
    public class User : IUser
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Suburb { get; set; }
        public string PostalCode { get; set; }
        public string Address { get; set; }
        public string Community { get; set; }
    }
}
