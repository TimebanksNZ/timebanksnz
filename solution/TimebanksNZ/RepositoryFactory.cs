using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;


namespace TimebanksNZ
{
    public class RepositoryFactory : IRepositoryFactory 
    {
        public IRepository<User> CreateUserRepository()
        {
            return new Timebanks.NZ.DAL.MySql.UserRepository();
        }
    }
}