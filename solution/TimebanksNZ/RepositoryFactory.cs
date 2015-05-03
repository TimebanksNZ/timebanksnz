using Timebanks.NZ.DAL.MySqlDb.Repositories;
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

        public ITimebankRepository CreateTimebankRepository()
        {
            return new TimebankRepository();
        }
    }
}