using AutoMapper;
using Timebanks.NZ.DAL.MySqlDb.AutoMapper.Profiles;

namespace Timebanks.NZ.DAL.MySqlDb.AutoMapper
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
