using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> astronauts;

        public AstronautRepository()
        {
            this.astronauts = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => astronauts;

        public void Add(IAstronaut astronaut)
        {
            astronauts.Add(astronaut);
        }

        public IAstronaut FindByName(string name)
        {
            return astronauts.FirstOrDefault(astronauts=> astronauts.Name == name);
        }

        public bool Remove(IAstronaut astronaut)
        {
            return astronauts.Remove(astronaut);
        }
    }
}
