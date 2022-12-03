using NavalVessels.Models.Contracts;
using System.Text;

namespace NavalVessels.Models
{
    public class Submarine : Vessel, ISubmarine
    {
        private bool submergeMode;
        public Submarine(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 200)
        {
            this.SubmergeMode = false;
        }
        public bool SubmergeMode
        {
            get { return submergeMode; }
            private set { submergeMode = value; }
        }
        public void ToggleSubmergeMode()
        {
            if (this.SubmergeMode == false)
            {
                this.SubmergeMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 4;
            }
            else
            {
                this.SubmergeMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = 200;
        }
        public override string ToString()
        {
            string sonarCurrentMode = SubmergeMode == false ? "OFF" : "ON";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Submerge mode: {sonarCurrentMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
