using System;
using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using Timebanks.NZ.DAL.MySql;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.Tests
{
    [TestFixture]
    public class EntityTranslatorTests
    {
        
        [Test]
        public void Translate_user_should_return_correctly_populated_member()
        {
            User user = new User()
            {
                FirstName = "John",
                LastName = "Doe",
                Approved = true,
                Address1 = "1 Street",
                Suburb = "Suburb",
                City = "City",
                PostalCode = "7601",
                MobilePhone = "11111",
                HomePhone = "22222",
                WorkPhone = "33333",
                Created = DateTime.Parse("1-Jan-2000"),
                GeoLat = 50.5,
                GeoLong = 60.5,
                Email = "test@test.com",
                TimeBank = new Timebank(),
                IdMember = new Guid("66288CB4-ED40-4AFC-963B-E1F130CA437D")
            };

            // Act
            var returnMember = new EntityTranslator().Translate(user);

            // Assert
            returnMember.first_name.Should().Be(user.FirstName);
            returnMember.last_name.Should().Be(user.LastName);
            returnMember.approved.Should().Be(user.Approved);
            returnMember.id_member.Should().Be(user.IdMember);
            returnMember.street_address_1.Should().Be(user.Address1);
            returnMember.suburb.Should().Be(user.Suburb);
            returnMember.city.Should().Be(user.City);
            returnMember.postcode.Should().Be(user.PostalCode);
            returnMember.mobile_phone.Should().Be(user.MobilePhone);
            returnMember.home_phone.Should().Be(user.HomePhone);
            returnMember.work_phone.Should().Be(user.WorkPhone);
            returnMember.created.Should().Be(user.Created);
            returnMember.geo_lat.Should().Be(user.GeoLat);
            returnMember.geo_long.Should().Be(user.GeoLong);
            returnMember.email_address.Should().Be(user.Email);
            
            // TODO NJ: Need a timebank entity here
            returnMember.timebank.Should().Be(user.TimeBank);




        }

    }
}
