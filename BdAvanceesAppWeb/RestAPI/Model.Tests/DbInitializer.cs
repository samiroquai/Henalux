using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    class DbInitializer : DropCreateDatabaseAlways<CompanyContext>
    {

        protected override void Seed(CompanyContext context)
        {
            Customer customer = new Customer()
            {
                Name = "Albert Dupont",
                AddressLine1 = "Rue des cerisiers, 16",
                City = "Arlon",
                Country = "Belgique",
                EMail = "info@me.com",
                Id = 3,
                Remark = "Ne pas avoir peur des chiens pour aller chez ce client",
                PostCode = "6700",
                Accounts = new List<Account>()
                 {
                     new Account()
                     {
                          Balance=10,
                           IBAN=    "ABCD",

                     },
                        new Account()
                     {
                          Balance=15,
                           IBAN=    "EFGH",

                     }
                 }
            };
            context.Customers.Add(customer);
            Customer customer2 = new Customer()
            {
                Name = "John Doe",
                AddressLine1 = "Rue Sonetty, 98",
                City = "Arlon",
                Country = "Belgique",
                EMail = "info@me.com",
                Id = 3,
                Remark = "A de grosses difficultés financières",
                PostCode = "6700",
                Accounts = new List<Account>()
                 {
                     new Account()
                     {
                          Balance=18,
                           IBAN=    "IJKL",

                     },
                        new Account()
                     {
                          Balance=9,
                           IBAN=    "MNOP",

                     }
                 }
            };
            context.Customers.Add(customer2);
            context.SaveChanges();
        }
    }
}
