using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;
using TImebanksNZ.DAL.Mock;

namespace TimebanksNZ
{
    public interface IRepositoryFactory
    {
        IRepository<User> CreateUserRepository();
        ITimebankRepository CreateTimebankRepository();
    }
}