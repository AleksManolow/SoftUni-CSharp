using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private bool sonarMode;
        public Battleship(string name, double mainWeaponCaliber, double speed)
            : base(name, mainWeaponCaliber, speed, 300)
        {
            this.SonarMode = false;
        }
        public bool SonarMode
        {
            get { return sonarMode; }
            private set { sonarMode = value; }
        }
        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.SonarMode= true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.SonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = 300;
        }
        public override string ToString()
        {
            string sonarCurrentMode = SonarMode == false ? "OFF" : "ON";

            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {sonarCurrentMode}");

            return sb.ToString().TrimEnd();
        }
    }
}
