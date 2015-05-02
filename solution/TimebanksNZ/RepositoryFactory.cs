using TimebanksNZ.DAL;
using TImebanksNZ.DAL.Mock;

namespace TimebanksNZ
{
    public class RepositoryFactory : IRepositoryFactory 
    {
        public IRepository<User> CreateUserRepository()
        {            
            return new MockRepository<User>();
        }
    }
}