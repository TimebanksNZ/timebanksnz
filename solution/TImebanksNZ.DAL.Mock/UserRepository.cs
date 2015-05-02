using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace TImebanksNZ.DAL.Mock
{
    public class UserRepository<T>: IRepository<User>
    {
        public void Update(User entity)
        {           
        }

        public void Insert(User entity)
        {
        }

        public User Get(User entity)
        {
            return new User();
        }

        public void Delete(User entity)
        {
        }
    }
}
