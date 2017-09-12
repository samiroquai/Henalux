using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace HashExample
{
    public class Program
    {
        const int NUMBER_OF_STUDENTS=10000000;
        const string NAME_TO_SEARCH_FOR="student's last name=9995000";
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Student[] studentsArray = CreateArray();
            Dictionary<string, Student> studentsDictionary = CreateDictionary();


            Stopwatch watch = new Stopwatch();
            for(int i=0;i<5;i++){
                watch.Restart();
                SearchInArray(studentsArray);
                watch.Stop();
                Console.WriteLine("Search time in array:"+watch.ElapsedMilliseconds+"ms");
            }
          
            
            
             for(int i=0;i<5;i++){
                watch.Restart();
                SearchInDictionary(studentsDictionary);
                watch.Stop();
                Console.WriteLine("Search time in dictionary:"+watch.ElapsedMilliseconds+"ms");
             }
           
        }

        private static void SearchInDictionary(Dictionary<string, Student> studentsDictionary)
        {
            Student student=studentsDictionary[NAME_TO_SEARCH_FOR];
                Debug.Assert(student!=null);
        }

        private static void SearchInArray(Student[] studentsArray)
        {
            int i=0;
            for(;i<studentsArray.Length && studentsArray[i].LastName!=NAME_TO_SEARCH_FOR;i++);
            Debug.Assert(i<studentsArray.Length);
        }

        public static Student[] CreateArray()
        {
            var students=new Student[NUMBER_OF_STUDENTS];
            var i=0;
            foreach(Student student in GetStudents()){
                students[i]=student;
                i++;
            }
            return students;
        }

        public static Dictionary<string,Student> CreateDictionary()
        {
            Dictionary<string,Student> students=new Dictionary<string,Student>();
            foreach(var student in GetStudents()){
                students.Add(student.LastName,student);
            }
            return students;
        }

        public static IEnumerable<Student> GetStudents()
        {
            for(int i=0;i<NUMBER_OF_STUDENTS;i++){
                yield return new Student(){
                     FirstName="student "+i.ToString(),
                     LastName="student's last name="+i.ToString()
                   };
            }
        } 
    }
}
