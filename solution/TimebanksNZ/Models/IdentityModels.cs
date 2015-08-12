using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimebanksNZ.DAL.MySqlDb.Repositories;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;

namespace TimebanksNZ.Model
{
    public class ApplicationDbContext : IdentityDbContext<user>
    {
        public ApplicationDbContext()
            : base("timebanksEntities", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}