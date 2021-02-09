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

        private const string Eating_File_Name = "Eatings.dat";

        private const string Food_File_Name = "Foods.dat";
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("User cannot be Null", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEatings();
        }
 
        /// <summary>
        /// Add new type of food.Add food to current meal
        /// </summary>
        /// <param name="food"></param>
        /// <param name="weight"></param>
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
        /// <summary>
        /// Return all meals
        /// </summary>
        /// <returns></returns>
        private Eating GetEatings()
        {
            return Load<Eating>(Eating_File_Name) ?? new Eating(user);
        }

        /// <summary>
        /// Return all foods
        /// </summary>
        /// <returns></returns>
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(Food_File_Name)?? new List<Food>() ;
            
        }

        private void  Save()
        {
            Save(Food_File_Name,Foods);
            Save(Eating_File_Name, Eating);
        }

        
    }
}
