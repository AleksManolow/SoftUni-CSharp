using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            equipment= new EquipmentRepository();
            gyms= new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;
            switch (athleteType)
            {
                case "Boxer":
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                    break;
                case "Weightlifter":
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }
            IGym gym = gyms.Find(g => g.Name == gymName);
            string gymType = gym.GetType().Name;

            if ((athleteType == "Boxer" && gymType == "WeightliftingGym") ||
                (athleteType == "Weightlifter" && gymType == "BoxingGym"))
            {
                return OutputMessages.InappropriateGym;
            }
            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipmentequ = null;
            switch (equipmentType)
            {
                case "BoxingGloves":
                    equipmentequ = new BoxingGloves();
                    break;
                case "Kettlebell":
                    equipmentequ = new Kettlebell();
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);  
            }
            equipment.Add(equipmentequ);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }
        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            switch (gymType)
            {
                case "BoxingGym":
                    gym = new BoxingGym(gymName);
                    break;
                case "WeightliftingGym":
                    gym = new WeightliftingGym(gymName);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }
            gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }
        public string EquipmentWeight(string gymName)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipmentequ = equipment.FindByType(equipmentType);
            IGym gym = gyms.Find(x => x.Name == gymName);
            if (equipmentequ == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            gym.AddEquipment(equipmentequ);
            equipment.Remove(equipmentequ);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = gyms.Find(g => g.Name == gymName);
            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
