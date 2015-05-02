using AutoMapper;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql.AutoMapper.Profiles
{
    /// <summary>
    /// Profile for auto mapping rules of poco objects from the database to the business entities
    /// </summary>
    public class MySqlPocoToBEProfile : Profile
    {
        protected override void Configure()
        {
            // For some reason automapper does not map properties back the other way but it should...
            Mapper.CreateMap<member, User>()
                .ForMember(x => x.IdMember, opt => opt.ResolveUsing(member => member.id_member))
                .ForMember(x => x.IdTimebank, opt => opt.ResolveUsing(member => member.id_timebank));

            Mapper.CreateMap<timebank, Timebank>();

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
            // Ignore EF navigation properties
            Mapper.CreateMap<User, member>()
                .ForMember(x => x.offer_need, opt => opt.Ignore())
                .ForMember(x => x.timebank, opt => opt.Ignore())
                .ForMember(x => x.tags, opt => opt.Ignore())
                .ForMember(x => x.member_permission, opt => opt.Ignore())
                .ForMember(x => x.trades, opt => opt.Ignore())
                .ForMember(x => x.trades1, opt => opt.Ignore());

            Mapper.CreateMap<Timebank, timebank>()
                .ForMember(x => x.offer_need, opt => opt.Ignore())
                .ForMember(x => x.members, opt => opt.Ignore());

            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
        }
    }
}
