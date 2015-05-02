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
            var t = new Timebanks.NZ.DAL.MySql.EntityFramework.timebanksEntities();

            timebank tb = new timebank()
            {
                name = "",
            };


            t.timebanks.Add(tb);
            t.SaveChanges();
        }
    }
}
