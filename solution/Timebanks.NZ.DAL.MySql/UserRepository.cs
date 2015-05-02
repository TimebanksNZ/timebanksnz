using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timebanks.NZ.DAL.MySql.EntityFramework;
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
            EntityTranslator entityTranslator = new EntityTranslator();

            member poco = entityTranslator.Translate(entity);

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

    public class EntityTranslator
    {
        public member Translate(User entity)
        {
            member member = new member();

            member.first_name = entity.FirstName;
            member.last_name = entity.LastName;
            member.approved = entity.Approved;

            return member;
        }
    }
}
