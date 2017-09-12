using System.Collections.Generic;
using System.Diagnostics;
namespace ListsDemo
{
    public class LinkedListInsert:AbstractInsert
    {

        private LinkedList<int> lst;
        public LinkedListInsert()
        {
            lst=new LinkedList<int>();
        }
        private LinkedListNode<int> lastAdded=null;
        protected override void Add(int i){
            
            if(lastAdded!=null)
                lastAdded=lst.AddAfter(lastAdded,i);
            else
                lastAdded=lst.AddFirst(i);
        }
    }
}