using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Model
{
    [Serializable]
    /// <summary>
    /// ingestion
    /// </summary>
    public class Eating
    {
        public DateTime MomentOfIngestion { get; }

        public Dictionary<Food, double> Foods {get;}
        public User User { get; }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentException("User name cannot be null or empty", nameof(user));
            MomentOfIngestion = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        public void Add(Food food, double weight)
        {
            
            var checkfood = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (checkfood == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[checkfood] += weight;
            }
        }
    }
}
