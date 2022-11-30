using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private List<IRacer> models;

        public RacerRepository()
        {
            this.models = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => models;

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
            models.Add(racer);
        }

        public IRacer FindBy(string username)
        {
            return models.FirstOrDefault(x => x.Username == username);
        }

        public bool Remove(IRacer racer)
        {
            return models.Remove(racer);
        }
    }
}
