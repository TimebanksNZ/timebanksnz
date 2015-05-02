using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

            // HACK NJ: Bloody foreign keys
            entity.IdTimebank = 1;

            entity.IdMember = Guid.NewGuid();
            var poco = Mapper.Map<member>(entity);
            dbContext.members.Add(poco);
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
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
