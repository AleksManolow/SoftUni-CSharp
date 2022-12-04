using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private double engineDisplacement;
        private int horsepower;
        protected FormulaOneCar(string model, double engineDisplacement, int horsepower)
        {
            this.Model = model;
            this.EngineDisplacement = engineDisplacement;
            this.Horsepower = horsepower;
        }
        public string Model
        {
            get { return model; }
            private set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                model = value;
            }
        }
        public int Horsepower
        {
            get { return horsepower; }
            private set 
            {
                if (value < 900 || value > 1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                horsepower = value;
            }
        }
        public double EngineDisplacement
        {
            get { return engineDisplacement; }
            private set 
            {
                if (value < 1.6 || value > 2.0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
                engineDisplacement = value; 
            }
        }
        public double RaceScoreCalculator(int laps)
        {
            return EngineDisplacement / Horsepower * laps;
        }
        
    }
}
