using TimebanksNZ.DAL;
using TImebanksNZ.DAL.Mock;

namespace TimebanksNZ
{
    public interface IRepositoryFactory
    {
        IRepository<User> CreateUserRepository();
    }
}