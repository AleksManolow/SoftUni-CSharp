using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths
{
    public class Booth : IBooth
    {
        private int boothId;
        private int capacity;
        private DelicacyRepository delicacyRepository;
        private CocktailRepository cocktailRepository;
        private double currentBill;
        private double turnover;
        private bool isReserved;

        public Booth(int boothId, int capacity)
        {
            this.BoothId = boothId;
            this.Capacity = capacity;
            this.delicacyRepository = new DelicacyRepository();
            this.cocktailRepository = new CocktailRepository();
            this.CurrentBill = 0;
            this.Turnover = 0;
            this.IsReserved = false;
        }

        public int BoothId
        {
            get { return boothId; }
            private set { boothId = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            private set 
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }
        public IRepository<IDelicacy> DelicacyMenu => delicacyRepository;
        public IRepository<ICocktail> CocktailMenu => cocktailRepository;
        public double CurrentBill
        {
            get { return currentBill; }
            private set { currentBill = value; }
        }
        public double Turnover
        {
            get { return turnover; }
            private set { turnover = value; }
        }
        public bool IsReserved
        {
            get { return isReserved; }
            private set { isReserved = value; }
        }
        public void ChangeStatus()
        {
            if (this.IsReserved == true)
            {
                this.IsReserved = false;
            }
            else
            {
                this.IsReserved = true;
            }
        }

        public void Charge()
        {
            this.Turnover += this.CurrentBill;
            this.CurrentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            this.CurrentBill += amount;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {this.BoothId}");
            sb.AppendLine($"Capacity: {this.Capacity}");
            sb.AppendLine($"Turnover: {this.Turnover:F2} lv");

            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine("--" + cocktail.ToString());
            }

            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine("--" + delicacy.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
