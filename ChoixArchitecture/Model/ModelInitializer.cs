using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ModelInitializer : DropCreateDatabaseIfModelChanges<SchoolContext>
    {

        protected override void Seed(SchoolContext context)
        {
            base.Seed(context);

            var john = new Student();
            john.FirstName = "John";
            john.LastName = "Connor";
            john.Country = "USA";
            john.BirthDate = new DateTime(1985, 2, 27);


            var sarah = new Student();
            sarah.FirstName = "Sarah";
            sarah.LastName = "Connor";
            sarah.BirthDate = new DateTime(1965, 11, 10);
            sarah.Country = "USA";

            var db = new Course();
            db.Name = "Bases de données";

            var rechOp = new Course();
            rechOp.Name = "Recherche opérationnelle";

            john.CoursesFollowed.Add(db);
            john.CoursesFollowed.Add(rechOp);
            sarah.CoursesFollowed.Add(rechOp);

            context.Students.Add(john);
            context.Students.Add(sarah);
            context.Courses.Add(db);
            context.Courses.Add(rechOp);

            context.SaveChanges();
        }
    }
}
