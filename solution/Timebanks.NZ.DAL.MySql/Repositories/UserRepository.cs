using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Text;
using AutoMapper;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;
using TimebanksNZ;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;
using System.Linq;
using System.Collections.Generic;

namespace TimebanksNZ.DAL.MySqlDb.Repositories
{
   
    public class UserRepository : IRepository<User>
    {
        private ITimebankRepository _timebankRepository;
        public ITimebankRepository TimebankRepository
        {
            get
            {
                // Lazy instantiation of default class
                if (_timebankRepository == null)
                {
                    _timebankRepository = new TimebankRepository();
                }
                return _timebankRepository;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                _timebankRepository = value;
            }
        }

        public void Update(User updatedEntity)
        {
            using (var dbContext = new timebanksEntities())
            {
                dbContext.Entry(Mapper.Map<member>(updatedEntity)).State = EntityState.Modified;
                dbContext.SaveChanges();
            }
        }

        public void Insert(User entity)
        {
            using (var dbContext = new timebanksEntities())
            {

                TimebankRepository.GetByName(entity.Community);

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

                // Update PK
                entity.IdMember = poco.id_member;
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

        public List<User> GetAll()
        {
            using (var dbContext = new timebanksEntities())
            {
                return Mapper.Map<List<User>>(dbContext.members.AsEnumerable<member>().ToList());
            }
        }
    }
}
