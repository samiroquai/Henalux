using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Henalllux.Ig.CSharp.Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            string excelFilePath=(args.Length>0)?args[0]:
            Path.Combine(System.Environment.CurrentDirectory,
            "Employees.xlsx");
            var dal=new EmployeesDataAccess();
            IEnumerable<Employee> employees = dal.Import(excelFilePath);
            foreach(Employee employee in employees)
            {
                if(employee.Position.Equals("Manager")){
                    Console.WriteLine(employee.FirstName+" est un manager!");
                }
            }
        }
    }
}
//Premier problème: pas de paramètre passé => illustrer comment faire via launch.json. Ensuite, partir du principe qu'on charge à partir du répertoire d'exécution. Trouver comment faire pour assigner à la variable excelFilePath la valeur du répertoire courant dans le cas où args ne contient pas de valeur (forme racourcie du if)
//Second problème: position pas importée => montrer comment débugger. En profiter pour illustrer la notion d'encapsulation. Ne pas trop ouvrir, illustrer utilité du constructeur et du contrôle de l'état. 

