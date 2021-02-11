using BusinessLogic.Controller;
using BusinessLogic.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {
            var calture = CultureInfo.CreateSpecificCulture("eng");
            var resourceManager = new ResourceManager("Api.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello")) ;

            Console.WriteLine("Enter your name");

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUSer);

            if (userController.NewUSer)
            {
                Console.Write("Enter gender: ");
                var gender = Console.ReadLine();

                

                DateTime birthday = DateTimePArse();


                var weight = DoubleParse("weight");

                var height = DoubleParse("height");
                

                userController.SetNewUserData(gender, birthday, weight, height);
            }
            Console.WriteLine(userController.CurrentUSer);

            Console.WriteLine("Type of action");

            Console.WriteLine("E - enter ingestion");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.food,foods.weight);
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key}-{item.Value}");
                }
            }
            Console.ReadLine();
        }

        private static (Food food,double weight) EnterEating()
        {
            Console.WriteLine("Enter name of food");
            var food = Console.ReadLine();
            var calories = DoubleParse("calories");
            var prots = DoubleParse("proteins");
            var fats = DoubleParse("fats");
            var carbohydrates = DoubleParse("carbohydrates");
            
            var weight = DoubleParse("weight od food");
            var product = new Food(food);
            return (food:product, weight : weight);
        }
        private static DateTime DateTimePArse()
        {
            DateTime birthday;
            while (true)
            {
                Console.Write("Enter date of birth day");
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid type of birth day");
                }
            }

            return birthday;
        }

        public static double DoubleParse(string name)
        {
            while (true)
            {
                Console.WriteLine($"Enter {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    
                }
                else
                {
                    Console.WriteLine($"Invalid format of {name}");
                }
            }

        }
    }
}
