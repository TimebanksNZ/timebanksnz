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
            var dbContext = new timebanksEntities();

            EntityTranslator entityTranslator = new EntityTranslator();

            member poco = entityTranslator.Translate(entity);

            dbContext.members.Add(poco);
            dbContext.SaveChanges();
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
