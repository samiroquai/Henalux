using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class CompanyContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CompanyContext()
            : base(@"Data Source=EFJKSDFKKLJLKJSDLJSF\AZA;Initial Catalog=WIKI;User Id=MySuperSA;Password=JKDHFJHAZEGHLKJQSDKLJKLQSDIUIEJHJHQSDGHD")
        {

        }
    }
}
