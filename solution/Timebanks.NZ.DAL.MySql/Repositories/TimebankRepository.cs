using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;
using TimebanksNZ;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.DAL.MySqlDb.Repositories
{
    public class TimebankRepository : ITimebankRepository
    {
        public void Update(Timebank updatedEntity)
        {
            var dbContext = new timebanksEntities();
            dbContext.Entry(Mapper.Map<timebank>(updatedEntity)).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void Insert(Timebank entity)
        {
            var dbContext = new timebanksEntities();
            timebank poco = Mapper.Map<timebank>(entity);

            dbContext.timebanks.Add(poco);
            dbContext.SaveChanges();

            // Update entity with PK
            entity.IdTimebank = poco.id_timebank;
        }

        public Timebank Get(Timebank entity)
        {
            throw new NotImplementedException();
        }
 
        public List<Timebank> GetAll()
        {
            var dbContext = new timebanksEntities();
            var results = dbContext.timebanks;
            List<Timebank> timebanks = new List<Timebank>();

            foreach (var timebank in results)
            {
                timebanks.Add(Mapper.Map<Timebank>(timebank));
            }

            return timebanks;
        }

        public Timebank GetByName(string community)
        {
            var dbContext = new timebanksEntities();
            var timebank = dbContext.timebanks.FirstOrDefault(tb => tb.name == community);

            return Mapper.Map<Timebank>(timebank);
        }

        public void Delete(Timebank entity)
        {
            var dbContext = new timebanksEntities();
            var tb = Mapper.Map<timebank>(entity);
            dbContext.timebanks.Attach(tb);
            dbContext.timebanks.Remove(tb);
            dbContext.SaveChanges();
        }

        public IQueryable<Timebank> All
        {
            get
            {
                return new Timebank[0].AsQueryable();
            }
        }
    }
}