using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using FluentAssertions;
using TimebanksNZ.Controllers;
using TimebanksNZ.DAL.MySqlDb.Repositories;

namespace TimebanksNZ.Tests.IntegrationTests.Repositories
{
    [TestFixture]
    public class OfferNeedRepositoryTests
    {

        internal OfferNeedRepository CreateTestTarget()
        {
            var target = new OfferNeedRepository();
            return target;
        }

        [TestFixtureSetUp]
        public void SetupFixture()
        {
        }

        [TestFixtureTearDown]
        public void TearDownFixture()
        {
        }

        [SetUp]
        public void SetupTest()
        {
        }

        [TearDown]
        public void TearDownTest()
        {
        }

        [Test]
        public void Test1()
        {
            var target = CreateTestTarget();

            OfferNeed offerNeed = new OfferNeed();

            target.Insert(offerNeed);

            var offerNeeds = target.GetAll();

        }

    }
}
