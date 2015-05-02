using Timebanks.NZ.DAL.MySql.Repositories;
using TimebanksNZ.DAL;
using TimebanksNZ.DAL.Entities;


namespace TimebanksNZ
{
    public class RepositoryFactory : IRepositoryFactory 
    {
        public IRepository<User> CreateUserRepository()
        {
            return new UserRepository();
        }
    }
}