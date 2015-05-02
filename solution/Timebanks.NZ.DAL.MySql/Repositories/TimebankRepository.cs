using System;
using System.Collections.Generic;
using AutoMapper;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql.Repositories
{
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

            var allTimebanks = new List<Timebank>();
            foreach (var timebank in dbContext.timebanks)
            {
                Timebank tb = Mapper.Map<Timebank>(timebank);
                allTimebanks.Add(tb);
            }            

            return allTimebanks;
        }
        public void Delete(Timebank entity)
        {
            throw new NotImplementedException();
        }
    }
}