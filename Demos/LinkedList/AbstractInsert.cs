using System;
using System.Diagnostics;

namespace ListsDemo{
    public abstract class AbstractInsert
    {
        protected const int NUMBER_OF_ITEMS=100000000;
        public TimeSpan RunTest()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < NUMBER_OF_ITEMS; i++)
            {
                Add(i);
            }
            watch.Stop();
            return watch.Elapsed;
        }
        protected abstract void Add(int i);
    }   
}