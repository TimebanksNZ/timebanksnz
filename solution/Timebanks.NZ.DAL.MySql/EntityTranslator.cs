using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography.Xml;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL.Entities;

namespace Timebanks.NZ.DAL.MySql
{
    public class EntityTranslator
    {
        public member Translate(User entity)
        {
            member member = new member();

            member.first_name = entity.FirstName;
            member.last_name = entity.LastName;
            member.approved = entity.Approved;
            member.id_member = entity.IdMember;
            member.street_address_1 = entity.StreetAddress1;
            member.street_address_2 = entity.StreetAddress2;
            member.suburb = entity.Suburb;
            member.city = entity.City;
            member.postcode = entity.Postcode;
            member.mobile_phone = entity.MobilePhone;
            member.home_phone = entity.HomePhone;
            member.work_phone = entity.WorkPhone;
            member.created = entity.Created;
            member.geo_lat = entity.GeoLat;
            member.geo_long = entity.GeoLong;
            member.email_address = entity.EmailAddress;
            member.is_email_validated = entity.IsEmailValidated;
            member.is_email_public = entity.IsEmailPublic;
            member.is_address_public = entity.IsAddressPublic;
            member.is_deleted = entity.IsDeleted;
            member.is_phone_public = entity.IsPhonePublic;
            
            return member;
        }

        public timebank Translate(Timebank source)
        {
            var tb = new timebank()
            {
                id_timebank = source.IdTimebank,
                name = source.Name,
                url = source.Url,
                geo_lat = source.GeoLat,
                geo_long = source.GeoLong,
                suburb = source.Suburb,
                city = source.City,
                is_member_timebanknz = source.IsMemberTimebankNZ,
                id_country = source.IdCountry,
                id_theme = source.IdTheme,
                address_1 = source.Address1,
                address_2 = source.Address2,
                postcode = source.Postcode
            };

            return tb;
        }

        public List<Timebank> Translate(DbSet<timebank> timebanks)
        {
            List<Timebank> translatedTimebanks = new List<Timebank>();
            foreach (var timebank in timebanks)
            {
                translatedTimebanks.Add(Translate(timebank));
            }
            return translatedTimebanks;
        }

        public Timebank Translate(timebank timebanks)
        {
            return null;
        }
    }
}