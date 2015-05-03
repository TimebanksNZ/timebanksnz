using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using FluentAssertions;
using Timebanks.NZ.DAL.MySql.AutoMapper;
using Timebanks.NZ.DAL.MySql.Repositories;
using TimebanksNZ.DAL.Entities;

namespace TimebanksNZ.Tests.IntegrationTests.Repositories
{
	[TestFixture]
	public class TimebankRepositoryTests
	{		
		internal TimebankRepository CreateTestTarget()
		{
			var target = new TimebankRepository();
			return target;
		}

		[TestFixtureSetUp]
		public void SetupFixture()
		{
			AutomapperMySqlConfiguration.Configure();

		}

	    [SetUp]
	    public void Setup()
	    {
            var tb = new TimebankRepository().GetByName(DEFAULT_TIMEBANK_NAME_1);
            if (tb != null) new TimebankRepository().Delete(tb);

            tb = new TimebankRepository().GetByName(DEFAULT_TIMEBANK_NAME_2);
            if (tb != null) new TimebankRepository().Delete(tb);
	    }



	    private const string DEFAULT_TIMEBANK_NAME_1 = "TestTimebank1";
        private const string DEFAULT_TIMEBANK_NAME_2 = "TestTimebank2";

		[Test]
		public void Update_should_update_database_record()
		{
			var target = CreateTestTarget();

			Timebank entity = new Timebank()
			{
                Name = DEFAULT_TIMEBANK_NAME_1,
				Address1 = "Address1",
				Address2 = "Address2",
				City = "City",
				GeoLat = 10.5,
				GeoLong = 20,
				IdCountry = 3,
				IdTheme = 5,
                IsMemberTimebankNZ = true,
                Postcode = "123456",
                Suburb = "Sub",
                Url = "http://blahxx.com"
			};

			target.Insert(entity);
            entity.Name = DEFAULT_TIMEBANK_NAME_2;

			// Act
			target.Update(entity);

            // Assert
		    var updatedRecord = target.GetByName(DEFAULT_TIMEBANK_NAME_2);
		    updatedRecord.IdTimebank.Should().Be(entity.IdTimebank);

		}

	}
}
