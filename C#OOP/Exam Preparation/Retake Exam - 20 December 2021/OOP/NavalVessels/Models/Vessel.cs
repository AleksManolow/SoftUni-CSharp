using NavalVessels.Models.Contracts;
using NavalVessels.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public abstract class Vessel : IVessel
    {
        private string name;
        private ICaptain captain;
        private double armorThickness;
        private double mainWeaponCaliber;
        private double speed;
        private List<string> targets;

        protected Vessel(string name, double mainWeaponCaliber, double speed, double armorThickness)
        {
            this.Name = name;
            captain = null;
            this.ArmorThickness = armorThickness;
            this.MainWeaponCaliber = mainWeaponCaliber;
            this.Speed = speed;
            targets = new List<string>();
        }

        public string Name
        {
            get { return name; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(ExceptionMessages.InvalidVesselName);
                }
                name = value;
            }
        }
        public ICaptain Captain
        {
            get { return captain; }
            set 
            {
                if (value == null)
                {
                    throw new NullReferenceException(ExceptionMessages.InvalidCaptainToVessel);
                }
                captain = value;
            }
        }
        public double ArmorThickness
        {
            get { return armorThickness; }
            set { armorThickness = value; }
        }
        public double MainWeaponCaliber
        {
            get { return mainWeaponCaliber; }
            protected set { mainWeaponCaliber = value; }
        }
        public double Speed
        {
            get { return speed; }
            protected set { speed = value; }
        }
        public ICollection<string> Targets => targets;
        
        public void Attack(IVessel target)
        {
            if (target == null)
            {
                throw new NullReferenceException(ExceptionMessages.InvalidTarget);
            }
            target.ArmorThickness -= this.MainWeaponCaliber;
            if (target.ArmorThickness < 0)
            {
                target.ArmorThickness = 0;
            }
            this.Targets.Add(target.Name);
        }

        public abstract void RepairVessel();

        public override string ToString()
        {
            var targetsAsString = Targets.Count == 0
               ? "None"
               : string.Join(", ", targets);

            var sb = new StringBuilder();

            sb.AppendLine($"- {Name}");
            sb.AppendLine($" *Type: {GetType().Name}");
            sb.AppendLine($" *Armor thickness: {ArmorThickness}");
            sb.AppendLine($" *Main weapon caliber: {MainWeaponCaliber}");
            sb.AppendLine($" *Speed: {Speed} knots");
            sb.AppendLine($" *Targets: {targetsAsString}");

            return sb.ToString().TrimEnd();

        }

    }
}
