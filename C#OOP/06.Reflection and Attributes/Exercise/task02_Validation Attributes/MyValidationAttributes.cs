using System;

namespace ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public abstract class MyValidationAttributes : Attribute
    {
        public abstract bool IsValid(object obj);
    }
    public class MyRequiredAttribute : MyValidationAttributes
    {
        public override bool IsValid(object obj)
            =>  obj != null;
        
    }
    public class MyRangeAttribute : MyValidationAttributes
    {
        private int min;
        private int max;

        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool IsValid(object obj)
        {
            int currentValue = (int)obj;
            return currentValue >= min && currentValue <= max;
        }
    }
}
