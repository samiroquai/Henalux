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

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        static SchoolContext()
        {
            Database.SetInitializer(new ModelInitializer());
        }

        public SchoolContext()
            : base("Data Source=(LocalDB)\\MSSQLLOCALDB; Initial Catalog=ChoixArchitecture; Integrated Security=True;")
        {

        }
    }
}
