using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql
{
    /// <summary>
    /// Profile for auto mapping rules of poco objects from the database to the business entities
    /// </summary>
    public class MySqlPocoToBEProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<member, User>()
                .ForMember(x => x.IdMember, opt => opt.ResolveUsing(member => member.id_member))
                .ForMember(x => x.IdTimebank, opt => opt.ResolveUsing(member => member.id_timebank));

            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();
           
        }
    }

    /// <summary>
    /// Profile for auto mapping of business entities to poco objects
    /// </summary>
    public class MySqlBEToPocoProfile : Profile
    {
        protected override void Configure()
        {          
            // Ignore navigation properties
            Mapper.CreateMap<User, member>()
                .ForMember(x => x.offer_need, opt => opt.Ignore())
                .ForMember(x => x.timebank, opt => opt.Ignore())
                .ForMember(x => x.tags, opt => opt.Ignore())
                .ForMember(x => x.member_permission, opt => opt.Ignore())
                .ForMember(x => x.trades, opt => opt.Ignore())
                .ForMember(x => x.trades1, opt => opt.Ignore());
                
            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
        }
    }
}
