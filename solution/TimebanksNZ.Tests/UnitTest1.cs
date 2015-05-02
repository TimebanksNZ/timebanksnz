using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Timebanks.NZ.DAL.MySql.EntityFramework;

namespace TimebanksNZ.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var t = new Timebanks.NZ.DAL.MySql.EntityFramework.TimebanksNZ();

            member m = new member()
            {
                first_name = "asdas",
                last_name = "asdasd",
                primary_email = "asdas@asda.com",
                geo_lat = 0.00,
                geo_long = 1.0,
                address_privacy = false,
                phone_privacy = false,
            };
    
            t.members.Add(m);
            t.SaveChanges();
        }
    }
}
