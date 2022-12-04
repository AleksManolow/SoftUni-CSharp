using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        private bool tookPlace;
        private ICollection<IPilot> pilots;

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
            this.tookPlace = false;
            this.pilots = new List<IPilot>();
        }

        public string RaceName
        {
            get { return raceName; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                raceName = value; 
            }
        }
        public int NumberOfLaps
        {
            get { return numberOfLaps; }
            private set 
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                numberOfLaps = value;
            }
        }
        public bool TookPlace
        {
            get { return tookPlace; }
            set { tookPlace = value; }
        }
        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            string toStringTookPlace = TookPlace ? "Yes" : "No";
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The { RaceName } race has:");
            sb.AppendLine($"Participants: { this.pilots.Count }");
            sb.AppendLine($"Number of laps: {NumberOfLaps }");
            sb.AppendLine($"Took place: {toStringTookPlace}");

            return sb.ToString().TrimEnd();
        }
    }
}
