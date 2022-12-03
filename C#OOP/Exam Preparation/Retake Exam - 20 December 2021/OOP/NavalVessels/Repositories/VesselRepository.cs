using NavalVessels.Models.Contracts;
using NavalVessels.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Repositories
{
    public class VesselRepository : IRepository<IVessel>
    {
        private List<IVessel> vessels;
        public VesselRepository()
        {
            this.vessels = new List<IVessel>();
        }
        public IReadOnlyCollection<IVessel> Models => vessels;

        public void Add(IVessel vessel)
        {
            vessels.Add(vessel);
        }

        public IVessel FindByName(string name)
        {
            return vessels.FirstOrDefault(v => v.Name == name);
        }

        public bool Remove(IVessel vessel)
        {
            return vessels.Remove(vessel);
        }
    }
}
