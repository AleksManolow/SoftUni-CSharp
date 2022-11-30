using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> models;

        public CarRepository()
        {
            this.models = new List<ICar>();
        }

        public IReadOnlyCollection<ICar> Models => models;

        public void Add(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
            models.Add(car);
        }

        public ICar FindBy(string vin)
        {
            return models.FirstOrDefault(x => x.VIN == vin);
        }

        public bool Remove(ICar car)
        {
            return models.Remove(car);
        }
    }
}
