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
using TimebanksNZ.DAL.MySqlDb;
using TimebanksNZ.DAL.MySqlDb.AutoMapper.Profiles;
using TimebanksNZ.DAL.MySqlDb.EntityFramework;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.Tests.DAL.MySql
{
    [TestFixture]
    public class AutomapperTests
    {       
        [Test]
        public void MySqlBEToPocoProfile_should_be_valid()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MySqlBEToPocoProfile>());

            Mapper.AssertConfigurationIsValid();
        }

        [Test]
        public void MySqlPocoToBEProfile_should_be_valid()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<MySqlPocoToBEProfile>());
            Mapper.AssertConfigurationIsValid();
        }
    }

    internal static class MemberExtensions
    {
        public static T GetPropertyValue<T>(this member instance, string propertyName)
        {
            PropertyInfo propertyInfo = typeof(member).GetProperty(propertyName);
            return (T) propertyInfo.GetValue(instance);
        }
    }
}
