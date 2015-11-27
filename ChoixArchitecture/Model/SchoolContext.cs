using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SchoolContext : DbContext
    {
        static SchoolContext()
        {
            Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<SchoolContext>());
        }

        public SchoolContext()
            : base("Data Source=(LocalDB)\\MSSQLLOCALDB; Initial Catalog=ChoixArchitecture; Integrated Security=True;")
        {

        }
    }
}
