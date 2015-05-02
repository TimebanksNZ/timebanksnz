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
            member.street_address_1 = entity.Address1;
            member.street_address_2 = entity.Address2;
            member.suburb = entity.Suburb;
            member.city = entity.City;
            member.postcode = entity.PostalCode;
            member.mobile_phone = entity.MobilePhone;
            member.home_phone = entity.HomePhone;
            member.work_phone = entity.WorkPhone;
            member.created = entity.Created;
            member.geo_lat = entity.GeoLat;
            member.geo_long = entity.GeoLong;
            member.timebank = Translate(entity.TimeBank);
            member.email_address = entity.Email;
            
            return member;
        }

        private timebank Translate(Timebank timeBank)
        {
            // TODO NJ: Translate this
            return new timebank();
        }
    }
}