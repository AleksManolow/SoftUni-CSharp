using ChristmasPastryShop.Core.Contracts;
using ChristmasPastryShop.Models.Booths;
using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ChristmasPastryShop.Core
{
    public class Controller : IController
    {
        private BoothRepository boothRepository;

        public Controller()
        {
            this.boothRepository = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothID = boothRepository.Models.Count + 1;
            boothRepository.AddModel(new Booth( boothID, capacity));
            return string.Format(OutputMessages.NewBoothAdded, boothID, capacity);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (delicacyTypeName != "Gingerbread" && delicacyTypeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.Name == delicacyName);
            if (delicacy != null) 
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            switch (delicacyTypeName)
            {
                case "Gingerbread":
                    delicacy = new Gingerbread(delicacyName);
                    break;
                case "Stolen":
                    delicacy = new Stolen(delicacyName);
                    break;
            }
            booth.DelicacyMenu.AddModel(delicacy);
            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            if (cocktailTypeName != "MulledWine" && cocktailTypeName != "Hibernation")
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Small" && size != "Middle" && size != "Large")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.Name == cocktailName && c.Size == size);
            if (cocktail != null)
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            switch (cocktailTypeName)
            {
                case "MulledWine":
                    cocktail = new MulledWine(cocktailName, size);
                    break;
                case "Hibernation":
                    cocktail = new Hibernation(cocktailName, size);
                    break;
            }
            booth.CocktailMenu.AddModel(cocktail);
            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }
        public string ReserveBooth(int countOfPeople)
        {
            List<IBooth> booths = boothRepository.Models
                .Where(b => b.IsReserved == false && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();
            if (booths.Count == 0)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth booth = booths[0];
            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Bill {currentBill:f2} lv");
            sb.AppendLine(string.Format(OutputMessages.BoothIsAvailable, booth.BoothId));
            return sb.ToString().TrimEnd();
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = boothRepository.Models.FirstOrDefault(b => b.BoothId == boothId);
            string[] items = order.Split('/');
            string typeName = items[0];
            if (typeName != "MulledWine" && typeName != "Hibernation"
                && typeName != "Gingerbread" && typeName != "Stolen")
            {
                return string.Format(OutputMessages.InvalidCocktailType, typeName);
            }

            booth.DelicacyMenu.ToString();
            booth.CocktailMenu.ToString();

            string name = items[1];
            
            if (!booth.CocktailMenu.Models.Any(c => c.GetType().Name == typeName && c.Name == name) &&
                !booth.DelicacyMenu.Models.Any(d => d.GetType().Name == typeName && d.Name == name))
            {
                return string.Format(OutputMessages.NotRecognizedItemName, typeName, name);
            }

            if (typeName == "MulledWine" || typeName == "Hibernation")
            {
                int coutOfCocktails = int.Parse(items[2]);
                string size = items[3];
                ICocktail cocktail = booth.CocktailMenu.Models
                    .FirstOrDefault(c => c.GetType().Name == typeName && c.Name == name && c.Size == size);
                if (cocktail == null)
                {
                    return string.Format(OutputMessages.CocktailStillNotAdded, size, name);
                }
                else
                {
                    booth.UpdateCurrentBill(cocktail.Price * coutOfCocktails);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, coutOfCocktails, name);
                }
            }
            else
            {
                int coutOfCocktails = int.Parse(items[2]);
                IDelicacy delicacy = booth.DelicacyMenu.Models
                    .FirstOrDefault(d => d.GetType().Name == typeName && d.Name == name);
                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, typeName, name);
                }
                else
                {
                    booth.UpdateCurrentBill(delicacy.Price * coutOfCocktails);
                    return string.Format(OutputMessages.SuccessfullyOrdered, boothId, coutOfCocktails, name);
                }
            }
        }
    }
}
