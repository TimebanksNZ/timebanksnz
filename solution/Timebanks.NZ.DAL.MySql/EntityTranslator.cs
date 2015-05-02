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
            member.street_address_1 = entity.Address;
            member.suburb = entity.Suburb;
            member.city = entity.City;
            member.postcode = entity.PostCode;
            member.mobile_phone = entity.MobilePhone;
            member.home_phone = entity.HomePhone;
            member.work_phone = entity.WorkPhone;
            member.created = entity.Created;
            member.geo_lat = entity.GeoLat;
            member.geo_long = entity.GeoLong;
            member.email_address = entity.Email;
            member.timebank = Translate(entity.TimeBank);
            
            return member;
        }

        private timebank Translate(Timebank timeBank)
        {
            // TODO NJ: Translate this
            return new timebank();
        }
    }
}