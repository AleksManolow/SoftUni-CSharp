using System;
using System.Collections.Generic;
using System.Text;
using task08_Collection_Hierarchy.Contracts;

namespace task08_Collection_Hierarchy.Model
{
    public class MyList:AddRemoveCollection,IAddAndRemove
    {
        public MyList()
        {

        }
        public int User => List.Count;

        public override string Remove()
        {
            string firstItem = List[0];
            List.RemoveAt(0);
            return firstItem;
        }

    }
}
