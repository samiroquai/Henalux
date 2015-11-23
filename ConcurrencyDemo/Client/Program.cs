using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            CompanyContext context = new CompanyContext();
            var customer = context.Customers.First();
            Console.WriteLine("Nom: {0}", customer.Name);
            Console.WriteLine("Adresse: {0}", customer.AddressLine1);
            Console.WriteLine("Adresse: {0}", customer.AddressLine2);
            Console.WriteLine("Code postal - ville: {0} {1}", customer.PostCode, customer.City);
            Console.WriteLine("Pays: {0}", customer.Country);
            Console.WriteLine("Remarque: {0}", customer.Remark);
            //public string AddressLine1 { get; set; }Console.WriteLine("Le client est intéressé par la newsletter: " + customer.IsInterestedInNewsletter.ToString());
            //Console.WriteLine(customer.IsInterestedInNewsletter);
            Console.WriteLine("Appuyez sur une touche pour continuer");
            Console.ReadKey();

            //customer.IsInterestedInNewsletter = !customer.IsInterestedInNewsletter;
            context.SaveChanges();
        }
    }
}
