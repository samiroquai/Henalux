using System.Collections.Generic;
using System.Diagnostics;
namespace ListsDemo
{
    public class ListWithoutInitialSizeInsert:AbstractInsert
    {

        private List<int> lst;
        public ListWithoutInitialSizeInsert()
        {
            lst=new List<int>();
        }
        protected override void Add(int i){
            lst.Add(i);
        }
    }
}