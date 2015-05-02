using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql.Repositories
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

        public void Delete(Timebank entity)
        {
            throw new NotImplementedException();
        }
    }
}