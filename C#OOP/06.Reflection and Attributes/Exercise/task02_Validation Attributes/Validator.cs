﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property
                    .GetCustomAttributes<MyValidationAttributes>()
                    .ToArray();

                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj));

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}