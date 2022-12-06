using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private readonly List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models => weapons;

        public void AddItem(IWeapon weapon)
        {
            weapons.Add(weapon);
        }

        public IWeapon FindByName(string weaponTypeName)
        {
            return weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName);
        }

        public bool RemoveItem(string weaponTypeName)
        {
            return weapons.Remove(weapons.FirstOrDefault(x => x.GetType().Name == weaponTypeName));
        }
    }
}
