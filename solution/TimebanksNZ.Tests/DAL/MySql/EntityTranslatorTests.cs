using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using AutoMapper;
using FluentAssertions;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using Timebanks.NZ.DAL.MySql;
using Timebanks.NZ.DAL.MySql.EntityFramework;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.Tests.DAL.MySql
{
    [TestFixture]
    public class EntityTranslatorTests
    {
        
        [Test]
        public void Translate_business_entity_user_should_return_correctly_populated_member()
        {
            User user = new User()
            {
                FirstName = "John",
                LastName = "Doe",
                Approved = true,
                StreetAddress1 = "1 Street",
                Suburb = "Suburb",
                City = "City",
                Postcode = "7601",
                MobilePhone = "11111",
                HomePhone = "22222",
                WorkPhone = "33333",
                Created = DateTime.Parse("1-Jan-2000"),
                GeoLat = 50.5,
                GeoLong = 60.5,
                EmailAddress = "test@test.com",
                IdMember = new Guid("66288CB4-ED40-4AFC-963B-E1F130CA437D")
            };

            // Act
            var returnMember = new EntityTranslator().Translate(user);

            // Assert
            returnMember.first_name.Should().Be(user.FirstName);
            returnMember.last_name.Should().Be(user.LastName);
            returnMember.approved.Should().Be(user.Approved);
            returnMember.id_member.Should().Be(user.IdMember);
            returnMember.street_address_1.Should().Be(user.StreetAddress1);
            returnMember.suburb.Should().Be(user.Suburb);
            returnMember.city.Should().Be(user.City);
            returnMember.postcode.Should().Be(user.Postcode);
            returnMember.mobile_phone.Should().Be(user.MobilePhone);
            returnMember.home_phone.Should().Be(user.HomePhone);
            returnMember.work_phone.Should().Be(user.WorkPhone);
            returnMember.created.Should().Be(user.Created);
            returnMember.geo_lat.Should().Be(user.GeoLat);
            returnMember.geo_long.Should().Be(user.GeoLong);
            returnMember.email_address.Should().Be(user.EmailAddress);            
        }

        [Test]
        [TestCaseSource("TranslateUserBooleanTestCases")]
        public void Translate_business_entity_user_when_boolean_should_return_correctly_populated_member(User user, string pocoPropertyName)
        {
            // Act
            member returnMember = new EntityTranslator().Translate(user);

            // Assert
            returnMember.GetPropertyValue<bool>(pocoPropertyName).Should().BeTrue();
        }

        private IEnumerable TranslateUserBooleanTestCases()
        {
            yield return CreateTestCaseTranslateUserBoolean("Approved", "approved");
            yield return CreateTestCaseTranslateUserBoolean("IsAddressPublic", "is_address_public");
            yield return CreateTestCaseTranslateUserBoolean("IsEmailValidated", "is_email_validated");
            yield return CreateTestCaseTranslateUserBoolean("IsEmailPublic", "is_email_public");
            yield return CreateTestCaseTranslateUserBoolean("IsDeleted", "is_deleted");
            yield return CreateTestCaseTranslateUserBoolean("IsPhonePublic", "is_phone_public");
        }

        private TestCaseData CreateTestCaseTranslateUserBoolean(string entityPropertyName, string pocoPropertyName)
        {
            User user = new User();
            PropertyInfo propertyInfo = typeof (User).GetProperty(entityPropertyName);
            if (propertyInfo == null)
                throw new NoNullAllowedException(String.Format("property {0} does not exist on User", entityPropertyName));
            propertyInfo.SetValue(user, true);
            string testName =
                String.Format("Translate_user_boolean_property_{0}_is_true_should_populate_member_property",
                    entityPropertyName);
            return new TestCaseData(new object[] {user, pocoPropertyName})
                .SetName(testName);
        }

        [Test]
        public void Translate_business_entity_timebank_should_return_correctly_populated_timebank()
        {
            Timebank tb = new Timebank()
            {
                IdTimebank = 10,
                Name = "TestTimebank",
                Url = "SomeUrl",
                GeoLat = 10,
                GeoLong = 10.5,
                Suburb = "Subby",
                City = "SomeCity",
                IsMemberTimebankNZ = true,
                IdCountry = 20,
                IdTheme = 30,
                Address1 = "SomeAddress1",
                Address2 = "SomeAddress2",
                Postcode = "7765"
            };

            // Act
            var returnTimebank = new EntityTranslator().Translate(tb);

            // Assert
            returnTimebank.id_timebank.Should().Be(tb.IdTimebank);
            returnTimebank.name.Should().Be(tb.Name);
            returnTimebank.url.Should().Be(tb.Url);
            returnTimebank.geo_lat.Should().Be(tb.GeoLat);
            returnTimebank.geo_long.Should().Be(tb.GeoLong);
            returnTimebank.suburb.Should().Be(tb.Suburb);
            returnTimebank.city.Should().Be(tb.City);
            returnTimebank.is_member_timebanknz.Should().Be(tb.IsMemberTimebankNZ);
            returnTimebank.id_country.Should().Be(tb.IdCountry);
            returnTimebank.id_theme.Should().Be(tb.IdTheme);
            returnTimebank.address_1.Should().Be(tb.Address1);
            returnTimebank.address_2.Should().Be(tb.Address2);
            returnTimebank.postcode.Should().Be(tb.Postcode);
        }

        [Test]
        public void MySqlBEToPocoProfile_should_be_valid()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MySqlBEToPocoProfile>();
            });

            Mapper.AssertConfigurationIsValid();

            member dto = Mapper.Map<member>(new User());
        }

        [Test]
        public void MySqlPocoToBEProfile_should_be_valid()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MySqlPocoToBEProfile>());
            Mapper.AssertConfigurationIsValid();

            User dto = Mapper.Map<User>(new member());
        }
    }

    internal static class memberExtensions
    {
        public static T GetPropertyValue<T>(this member instance, string propertyName)
        {
            PropertyInfo propertyInfo = typeof(member).GetProperty(propertyName);
            return (T) propertyInfo.GetValue(instance);
        }
    }
}
