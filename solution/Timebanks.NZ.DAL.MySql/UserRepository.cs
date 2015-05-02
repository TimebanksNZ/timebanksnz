using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql
{
    public class UserRepository<T> : IRepository<User>
    {        
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            throw new NotImplementedException();
        }

        public User Get(User entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
