using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Model
{
    /// <summary>
    /// User
    /// </summary>
    public class User
    {
        #region properties
        public string Name { get; }

        public Gender Gender { get; }
        public DateTime BithDay { get; }

        public double Weight { get; set; }

        public double Height { get; set; }
        #endregion
        public User (string name, Gender gender ,DateTime date, double weight, double height)
        {
            #region checking conditions
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("User name cannot be null or empty",nameof(name));
            }
            if (Gender == null)
            {
                throw new ArgumentException("Gender cannot be null or empty", nameof(gender));
            }
            if (date <= DateTime.Parse("01.01.1950")|| date>=DateTime.Now)
            {
                throw new ArgumentException("Birth Day must be more then 01.01.1950", nameof(date));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight must be more then zero",nameof(weight));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height must be more then zero",nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BithDay = date;
            Weight = weight;
            Height = height;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
