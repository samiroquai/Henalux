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
        [TestMethod]
        public async Task InsertionFonctionnelle()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CompanyContext>());
            CompanyContext context = new CompanyContext();
            Customer customer = new Customer()
            {
                Name = "Albert Dupont",
                AddressLine1 = "Rue des cerisiers, 16",
                City = "Arlon",
                Country = "Belgique",
                EMail = "info@me.com",
                Id = 3,
                Remark = "Ne pas avoir peur des chiens pour aller chez ce client",
                PostCode = "6700"
            };
            context.Customers.Add(customer);
            context.SaveChanges();
            await AssertCustomerExists();
        }

        public async Task AssertCustomerExists()
        {
            var context = new CompanyContext();
            var numberOfCustomers = await context.Customers.CountAsync();
            Assert.IsTrue(numberOfCustomers > 0);

        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecteLesEditionsConcurrentes()
        {
            var contexteDeJohn = new CompanyContext();
            var clientDeJohn = contexteDeJohn.Customers.First();

            var contexteDeSarah = new CompanyContext();
            var clientDeSarah = contexteDeSarah.Customers.First();

            clientDeJohn.AccountBalance += 1000;
            contexteDeJohn.SaveChanges();

            clientDeSarah.AccountBalance += 2000;
            contexteDeSarah.SaveChanges();

        }

    }
}
