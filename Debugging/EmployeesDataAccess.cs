using System;
using System.Collections.Generic;
using System.IO;
using ExcelDataReader;
namespace Henalllux.Ig.CSharp.Debugging{
public class EmployeesDataAccess
{
    public IEnumerable<Employee> Import(string filePath)
    {
         System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
         using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            // Auto-detect format, supports:
            //  - Binary Excel files (2.0-2003 format; *.xls)
            //  - OpenXml Excel files (2007 format; *.xlsx)
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                    long linesRead = 0;
                // 1. Use the reader methods
                do
                {

                    while (reader.Read() && reader.FieldCount > 6)
                    {
                        linesRead++;
                        if (linesRead > 1 && linesRead<=151)
                        {
                            string firstName=reader.GetString(0);
                            string lastName=reader.GetString(1);
                            DateTime birthDate=reader.GetDateTime(2);
                            double wage=reader.GetDouble(3);
                            int experience=(int)reader.GetDouble(4);
                            string position=reader.GetString(5);
                            int children=(int)reader.GetDouble(6);
                            yield return new Employee(){
                                 FirstName=firstName,
                                 LastName=lastName,
                                 Experience=experience,
                                 Children=children,
                                 Wage=wage,
                                 BirthDate=birthDate
                            };
                        }
                    }
                    
                }while (reader.NextResult());
            }
        }
    }
}
}
