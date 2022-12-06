using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private readonly List<IMilitaryUnit> militaries;

        public UnitRepository()
        {
            this.militaries = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => militaries;

        public void AddItem(IMilitaryUnit military)
        {
            militaries.Add(military);
        }

        public IMilitaryUnit FindByName(string unitTypeName)
        {
            return militaries.FirstOrDefault(m => m.GetType().Name == unitTypeName);
        }

        public bool RemoveItem(string unitTypeName)
        {
            return militaries.Remove(militaries.FirstOrDefault(m => m.GetType().Name == unitTypeName));
        }
    }
}
