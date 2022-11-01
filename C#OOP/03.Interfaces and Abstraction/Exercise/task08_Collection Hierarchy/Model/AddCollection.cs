using System;
using System.Collections.Generic;
using System.Text;
using task08_Collection_Hierarchy.Contracts;

namespace task08_Collection_Hierarchy.Model
{
    public class AddCollection : IAddCollection
    {
        private List<string> list;

        public AddCollection()
        {
            this.list = new List<string>(100);
        }
        public List<string> List
        {
            get { return this.list; }
            set { this.list = value; }
        }
        public virtual int Add(string item)
        {
            list.Add(item);
            return list.Count - 1;
        }
    }
}
