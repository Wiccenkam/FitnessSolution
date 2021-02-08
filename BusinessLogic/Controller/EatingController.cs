using BusinessLogic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace BusinessLogic.Controller
{
    public class EatingController:BaseController
    {
        private readonly User user;

        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("USser cannot be Null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }
        public bool Add(string FoodName,double weight)
        {
            var food = Foods.SingleOrDefault(f => f.Name == FoodName);
            if (food != null)
            {
                Eating.Add(food, weight);
                Save();
                return true;
            }
            return false;
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
            
        }

        private Eating GetEatings()
        {
            return Load<Eating>("Eatings.dat") ?? new Eating(user);
        }

        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>("Foods.dat")?? new List<Food>() ;
            
        }

        private void  Save()
        {
            Save("Foods.dat",Foods);
            Save("Eatings.dat", Eating);
        }

        
    }
}
