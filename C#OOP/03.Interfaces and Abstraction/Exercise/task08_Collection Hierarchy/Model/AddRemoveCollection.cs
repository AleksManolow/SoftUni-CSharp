using System;
using System.Collections.Generic;
using System.Text;
using task08_Collection_Hierarchy.Contracts;

namespace task08_Collection_Hierarchy.Model
{
    public class AddRemoveCollection : AddCollection, IAddAndRemove
    {
        public AddRemoveCollection()
        {

        }
        public override int Add(string item)
        {
            List.Insert(0, item);
            return 0;
        }
        public virtual string Remove()
        {
            string lastItem = List[List.Count - 1];
            List.RemoveAt(List.Count - 1);
            return lastItem;
        }
    }
}
