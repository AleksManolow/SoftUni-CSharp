using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;

namespace task07_Military_Elite.Model
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        public LieutenantGeneral(string id, string firstName, string lastName, decimal salary)
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Privates:");

            foreach (IPrivate item in Privates)
            {
                sb.AppendLine($"  {item}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
