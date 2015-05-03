using System;

namespace TimebanksNZ.DAL.MySqlDb.Repositories
{
    public class OfferNeed
    {
        public int IdOfferNeed { get; set; }
        public Guid IdUser { get; set; }
        public int IdTimebank { get; set; }
        public bool IsOffer { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}