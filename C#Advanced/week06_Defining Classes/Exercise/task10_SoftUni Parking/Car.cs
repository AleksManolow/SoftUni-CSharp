using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
		private string make;
        private string model;
        private int horsePower;
        private string registrationNumber;
        public string Make
		{
			get { return make; }
			set { make = value; }
		}
		public string Model
		{
			get { return model; }
			set { model = value; }
		}
		public int  HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}
		public string RegistrationNumber
		{
			get { return registrationNumber; }
			set { registrationNumber = value; }
		}
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Make: {this.Make}");
            output.AppendLine($"Model: {this.Model}");
            output.AppendLine($"HorsePower: {this.HorsePower}");
            output.Append($"RegistrationNumber: {this.RegistrationNumber}");
            return output.ToString();
        }




    }
}
