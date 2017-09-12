using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ListsDemo
{
    public class Program
    {
        private static AbstractInsert[] strategies=new AbstractInsert[3];
        public static void Main(string[] args)
        {
                strategies[0]=new ListWithoutInitialSizeInsert();
                strategies[1]=new ListWithInitialSizeInsert();
                strategies[2]=new LinkedListInsert();
                RunTests();
        }

        private static void RunTests()
        {
           foreach(AbstractInsert strategy in strategies)
           {
                TimeSpan elapsed=strategy.RunTest();
                Console.WriteLine(strategy.ToString()+" "+ elapsed.Milliseconds);
                GC.Collect();
           }
        }
    }
}
