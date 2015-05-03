using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;

namespace TimebanksNZ.DAL.MySqlDb.Repositories
{
    public class OfferNeedRepository : IOfferNeedRepository
    {
        public void Update(OfferNeed entity)
        {
            throw new NotImplementedException();
        }

        public void Insert(OfferNeed entity)
        {
            var dbContext = new timebanksEntities();
            var poco = Mapper.Map<offer_need>(entity);

            dbContext.offer_need.Add(poco);
            dbContext.SaveChanges();

            // Update entity with PK
            entity.IdOfferNeed = poco.id_offer_need;
        }

        public OfferNeed Get(OfferNeed entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(OfferNeed entity)
        {
            throw new NotImplementedException();
        }

        public List<OfferNeed> GetAll()
        {
            var dbContext = new timebanksEntities();
            var results = dbContext.offer_need;
            List<OfferNeed> offerNeeds = new List<OfferNeed>();

            foreach (var offerNeed in results)
            {
                offerNeeds.Add(Mapper.Map<OfferNeed>(offerNeed));
            }

            return offerNeeds;
        }

        public IQueryable<OfferNeed> All { get; private set; }
    }
}