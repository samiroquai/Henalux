using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;
namespace Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (CompanyContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        private static CompanyContext GetContext()
        {
            return new CompanyContext();
        }

        [TestMethod]
        public void CanGetCustomers()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(2, context.Customers.ToList().Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecteLesEditionsConcurrentes()
        {
            using (CompanyContext contexteDeJohn = GetContext())
            {
                using (CompanyContext contexteDeSarah = GetContext())
                {
                    var clientDeJohn = contexteDeJohn.Customers.First();
                    var clientDeSarah = contexteDeSarah.Customers.First();

                    clientDeJohn.Remark = "Hey";
                    contexteDeJohn.SaveChanges();

                    clientDeSarah.Remark = "Ho";

                    contexteDeSarah.SaveChanges();


                }
            }
        }


    }
}
