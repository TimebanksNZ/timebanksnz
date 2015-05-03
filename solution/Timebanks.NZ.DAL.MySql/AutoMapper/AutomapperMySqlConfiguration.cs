using AutoMapper;
using TimebanksNZ.DAL.MySqlDb.AutoMapper.Profiles;

namespace TimebanksNZ.DAL.MySqlDb.AutoMapper
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
