using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Timebanks.NZ.DAL.MySql
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
