using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;
using TImebanksNZ.DAL.Mock;

namespace TimebanksNZ
{
    public class RepositoryFactory : IRepositoryFactory 
    {
        public IRepository<User> CreateUserRepository()
        {            
            return new UserRepository<User>();
        }
    }
}