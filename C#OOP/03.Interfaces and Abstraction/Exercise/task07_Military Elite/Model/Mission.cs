using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Contracts;
using task07_Military_Elite.Enums;

namespace task07_Military_Elite.Model
{
    public class Mission:IMission
    {
        public Mission(string codeName, Status status)
        {
            CodeName = codeName;
            Status = status;
        }
        public string CodeName { get; set; }
        public Status Status { get; set; }
        public void CompleteMission(string codeName)
        {

        }

        public override string ToString()
        {
            return $"Code Name: {CodeName} State: {Status}";
        }
    }
}
