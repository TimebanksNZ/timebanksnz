using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql
{
    public class UserRepository : IRepository<User>
    {        
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(User entity)
        {
            var dbContext = new timebanksEntities();
            var poco = Mapper.Map<member>(entity);
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

    public class TimebankRepository : IRepository<Timebank>
    {
        public void Update(Timebank entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(Timebank entity)
        {
            throw new NotImplementedException();
        }

        public Timebank Get(Timebank entity)
        {
            throw new NotImplementedException();
        }

        public List<Timebank> GetAll()
        {
            var dbContext = new timebanksEntities();

            EntityTranslator entityTranslator = new EntityTranslator();

            List<Timebank> timebanks = entityTranslator.Translate(dbContext.timebanks);

            return timebanks;
        }
        public void Delete(Timebank entity)
        {
            throw new NotImplementedException();
        }
    }
}
