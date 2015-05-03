using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;
using TImebanksNZ.DAL.Mock;
using TimebanksNZ.DAL.MySqlDb.Repositories;

namespace TimebanksNZ
{
    public interface IRepositoryFactory
    {
        IRepository<User> CreateUserRepository();
        ITimebankRepository CreateTimebankRepository();
        IOfferNeedRepository CreateOfferNeedRepository();
    }
}