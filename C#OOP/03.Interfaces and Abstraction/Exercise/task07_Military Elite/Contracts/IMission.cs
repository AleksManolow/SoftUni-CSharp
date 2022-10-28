using System;
using System.Collections.Generic;
using System.Text;
using task07_Military_Elite.Enums;

namespace task07_Military_Elite.Contracts
{
    public interface IMission
    {
        public string CodeName { get; set; }

        public Status Status { get; set; }

        void CompleteMission(string codeName);
    }
}
