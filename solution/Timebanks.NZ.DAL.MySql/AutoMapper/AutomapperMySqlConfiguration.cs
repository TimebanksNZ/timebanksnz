using AutoMapper;
using Timebanks.NZ.DAL.MySql.AutoMapper.Profiles;

namespace Timebanks.NZ.DAL.MySql.AutoMapper
{
    public static class AutomapperMySqlConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MySqlBEToPocoProfile>();
                cfg.AddProfile<MySqlPocoToBEProfile>();
            });
        }
    }
}
