using AutoMapper;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;
using TimebanksNZ.DAL.Entities;
using TimebanksNZ.DAL.MySqlDb.Repositories;

namespace TimebanksNZ.DAL.MySqlDb.AutoMapper.Profiles
{
    /// <summary>
    /// Profile for auto mapping rules of poco objects from the database to the business entities
    /// </summary>
    public class MySqlPocoToBEProfile : Profile
    {
        protected override void Configure()
        {
            // TODO NJ: Get automapper working in the reverse direction
            // For some reason automapper does not map lower underscored named properties back the other way but it should...
            Mapper.CreateMap<member, User>()
                .ForMember(x => x.IdMember, opt => opt.ResolveUsing(member => member.id_member))
                .ForMember(x => x.IdTimebank, opt => opt.ResolveUsing(member => member.id_timebank))
                .ForMember(x => x.EmailAddress, opt => opt.ResolveUsing(member => member.email_address))
                .ForMember(x => x.FirstName, opt => opt.ResolveUsing(member => member.first_name))
                .ForMember(x => x.LastName, opt => opt.ResolveUsing(member => member.last_name))
                .ForMember(x => x.StreetAddress1, opt => opt.ResolveUsing(member => member.street_address_1))
                .ForMember(x => x.StreetAddress2, opt => opt.ResolveUsing(member => member.street_address_2))
                .ForMember(x => x.MobilePhone, opt => opt.ResolveUsing(member => member.mobile_phone))
                .ForMember(x => x.HomePhone, opt => opt.ResolveUsing(member => member.home_phone))
                .ForMember(x => x.WorkPhone, opt => opt.ResolveUsing(member => member.work_phone))
                .ForMember(x => x.IsPhonePublic, opt => opt.ResolveUsing(member => member.is_phone_public))
                .ForMember(x => x.IsAddressPublic, opt => opt.ResolveUsing(member => member.is_address_public))
                .ForMember(x => x.IsEmailPublic, opt => opt.ResolveUsing(member => member.is_email_public))
                .ForMember(x => x.GeoLat, opt => opt.ResolveUsing(member => member.geo_lat))
                .ForMember(x => x.GeoLong, opt => opt.ResolveUsing(member => member.geo_long))
                .ForMember(x => x.IsEmailValidated, opt => opt.ResolveUsing(member => member.is_email_validated))
                .ForMember(x => x.IsDeleted, opt => opt.ResolveUsing(member => member.is_deleted))
                // Ignore these properties
                .ForMember(x => x.Community, opt => opt.Ignore())
                // TODO NJ: This should be in the database
                .ForMember(x => x.AcceptedTerms, opt => opt.Ignore())
                ;
            
            Mapper.CreateMap<timebank, Timebank>()
                .ForMember(x => x.IdTimebank, opt => opt.ResolveUsing(timebank => timebank.id_timebank))
                .ForMember(x => x.GeoLat, opt => opt.ResolveUsing(timebank => timebank.geo_lat))
                .ForMember(x => x.GeoLong, opt => opt.ResolveUsing(timebank => timebank.geo_long))
                .ForMember(x => x.IsMemberTimebankNZ, opt => opt.ResolveUsing(timebank => timebank.is_member_timebanknz))
                .ForMember(x => x.IdCountry, opt => opt.ResolveUsing(timebank => timebank.id_country))
                .ForMember(x => x.IdTheme, opt => opt.ResolveUsing(timebank => timebank.id_theme))
                .ForMember(x => x.Address1, opt => opt.ResolveUsing(timebank => timebank.address_1))
                .ForMember(x => x.Address2, opt => opt.ResolveUsing(timebank => timebank.address_2))
                ;

            Mapper.CreateMap<offer_need, OfferNeed>()
                .ForMember(x => x.IsOffer, opt => opt.ResolveUsing(o => o.is_offer))
                .ForMember(x => x.IdUser, opt => opt.ResolveUsing(o => o.id_user))
                .ForMember(x => x.IdTimebank, opt => opt.ResolveUsing(o => o.id_timebank))
                .ForMember(x => x.IdOfferNeed, opt => opt.ResolveUsing(o => o.id_offer_need))
                .ForMember(x => x.StartDate, opt => opt.ResolveUsing(o => o.start_date))
                .ForMember(x => x.ExpiryDate, opt => opt.ResolveUsing(o => o.expiry_date))
                ;

            Mapper.CreateMap<user, user>()
                .ForMember(x => x.Email, opt => opt.ResolveUsing(o => o.Email))
                .ForMember(x => x.Id, opt => opt.ResolveUsing(o => o.Id))
                .ForMember(x => x.EmailConfirmed, opt => opt.ResolveUsing(o => o.EmailConfirmed))
                .ForMember(x => x.PasswordHash, opt => opt.ResolveUsing(o => o.PasswordHash))
                .ForMember(x => x.SecurityStamp, opt => opt.ResolveUsing(o => o.SecurityStamp))
                .ForMember(x => x.PhoneNumber, opt => opt.ResolveUsing(o => o.PhoneNumber))
                .ForMember(x => x.PhoneNumberConfirmed, opt => opt.ResolveUsing(o => o.PhoneNumberConfirmed))
                .ForMember(x => x.TwoFactorEnabled, opt => opt.ResolveUsing(o => o.TwoFactorEnabled))
                .ForMember(x => x.LockoutEndDateUtc, opt => opt.ResolveUsing(o => o.LockoutEndDateUtc))
                .ForMember(x => x.LockoutEnabled, opt => opt.ResolveUsing(o => o.LockoutEnabled))
                .ForMember(x => x.AccessFailedCount, opt => opt.ResolveUsing(o => o.AccessFailedCount))
                .ForMember(x => x.UserName, opt => opt.ResolveUsing(o => o.UserName))
                ;
            // Why is this not working???
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

            Mapper.CreateMap<OfferNeed, offer_need>()
                .ForMember(x => x.member, opt => opt.Ignore())
                .ForMember(x => x.timebank, opt => opt.Ignore())
                .ForMember(x => x.tags, opt => opt.Ignore())
                ;

            Mapper.CreateMap<user, user>()
                .ForMember(x => x.Email, opt => opt.ResolveUsing(o => o.Email))
                .ForMember(x => x.Id, opt => opt.ResolveUsing(o => o.Id))
                .ForMember(x => x.EmailConfirmed, opt => opt.ResolveUsing(o => o.EmailConfirmed))
                .ForMember(x => x.PasswordHash, opt => opt.ResolveUsing(o => o.PasswordHash))
                .ForMember(x => x.SecurityStamp, opt => opt.ResolveUsing(o => o.SecurityStamp))
                .ForMember(x => x.PhoneNumber, opt => opt.ResolveUsing(o => o.PhoneNumber))
                .ForMember(x => x.PhoneNumberConfirmed, opt => opt.ResolveUsing(o => o.PhoneNumberConfirmed))
                .ForMember(x => x.TwoFactorEnabled, opt => opt.ResolveUsing(o => o.TwoFactorEnabled))
                .ForMember(x => x.LockoutEndDateUtc, opt => opt.ResolveUsing(o => o.LockoutEndDateUtc))
                .ForMember(x => x.LockoutEnabled, opt => opt.ResolveUsing(o => o.LockoutEnabled))
                .ForMember(x => x.AccessFailedCount, opt => opt.ResolveUsing(o => o.AccessFailedCount))
                .ForMember(x => x.UserName, opt => opt.ResolveUsing(o => o.UserName))
                ;

            SourceMemberNamingConvention = new PascalCaseNamingConvention();
            DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
        }
    }
}
