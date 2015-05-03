using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
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