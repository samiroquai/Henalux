using System.Collections.Generic;
using System.Diagnostics;
namespace ListsDemo
{
    public class ListWithInitialSizeInsert:AbstractInsert
    {

        private List<int> lst;
        public ListWithInitialSizeInsert()
        {
            lst=new List<int>(NUMBER_OF_ITEMS);
        }
        protected override void Add(int i){
            lst.Add(i);
        }
    }
}