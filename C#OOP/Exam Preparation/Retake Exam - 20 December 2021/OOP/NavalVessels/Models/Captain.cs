using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavalVessels.Models
{
    public class Captain : ICaptain
    {
        private string fullName;
        private int combatExperience;
        private ICollection<IVessel> vessels;

        public Captain(string fullName)
        {
            this.FullName = fullName;
            this.CombatExperience = 0;
            this.Vessels = new List<IVessel>();
        }

        public string FullName
        {
            get { return fullName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidCaptainName);
                }
                fullName = value;
            }
        }
        public int CombatExperience
        {
            get { return combatExperience; }
            private set { combatExperience = value; }
        }
        public ICollection<IVessel> Vessels
        {
            get { return vessels; }
            private set { vessels = value; }
        }
        public void AddVessel(IVessel vessel)
        {
            if (vessel == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidVesselForCaptain);
            }
            Vessels.Add(vessel);
        }
        public void IncreaseCombatExperience()
        {
            this.CombatExperience += 10;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{FullName} has {CombatExperience} combat experience and commands {Vessels.Count} vessels.");

            if (Vessels.Any())
            {
                foreach (var vessel in Vessels)
                {
                    sb.AppendLine(vessel.ToString());
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}
