using Ical.Net;
using Ical.Net.Interfaces;
using Ical.Net.Interfaces.Components;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleChecker
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckArguments(args);
            IEnumerable<IEvent> eventsToCome = ParseScheduleFile(args);
            Dictionary<string, TimeSpan> courses = ComputeTimeScheduledForEveryCourse(eventsToCome);
            DisplayStatistics(courses);
        }

        private static void CheckArguments(string[] args)
        {
            if (args.Length != 1)
                throw new ArgumentException("Un paramètre est requis: chemin d'accès au fichier ics (export de l'horaire)");
            if (!File.Exists(args[0]))
                throw new FileNotFoundException("Le fichier ics (export de l'horaire est introuvable");
        }

        private static IEnumerable<IEvent> ParseScheduleFile(string[] args)
        {
            //https://github.com/rianjs/ical.net/wiki/Deserialize-an-ics-file
            IICalendarCollection calendarCollection = Calendar.LoadFromFile(args[0]);
            ICalendar firstCalendar = calendarCollection.First();
            IEnumerable<IEvent> eventsToCome = firstCalendar.Events.Where(e => e.Start.Month >= 9 && e.Start.Year >= 2016);
            return eventsToCome;
        }

        private static Dictionary<string, TimeSpan> ComputeTimeScheduledForEveryCourse(IEnumerable<IEvent> eventsToCome)
        {
            var courses = new Dictionary<string, TimeSpan>();
            foreach (IEvent course in eventsToCome)
            {
                if (!String.IsNullOrEmpty(course.Summary))
                {
                    var courseName = course.Summary.Contains("-") ? course.Summary.Substring(0, course.Summary.IndexOf('-')) : course.Summary;
                    if (!courses.ContainsKey(courseName))
                        courses.Add(courseName, TimeSpan.Zero);
                    courses[courseName] = courses[courseName].Add(course.End.Subtract(course.Start));
                }
            }

            return courses;
        }

        private static void DisplayStatistics(Dictionary<string, TimeSpan> courses)
        {
            foreach (var course in courses)
            {
                Console.WriteLine("{0}: {1} heures", course.Key, course.Value.TotalHours);
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Total des heures programmées: {0}", TimeSpan.FromMinutes(courses.Where(c => !String.IsNullOrEmpty(c.Key)).Sum(c => c.Value.TotalMinutes)).TotalHours);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Il faut rajouter à ces heures les heures de mission, qui ne sont pas planifiées.");
        }
    }
}
