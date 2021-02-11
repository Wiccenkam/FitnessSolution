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

            var   resourceManager = new ResourceManager("Api.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello")) ;

            Console.WriteLine(resourceManager.GetString("EnterName"));

            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUSer);

            if (userController.NewUSer)
            {
                Console.Write(resourceManager.GetString("EnterGender"));
                var gender = Console.ReadLine();

                

                DateTime birthday = DateTimePArse();


                var weight = DoubleParse(resourceManager.GetString("Weight"));

                var height = DoubleParse(resourceManager.GetString("Height"));
                

                userController.SetNewUserData(gender, birthday, weight, height);
            }
            Console.WriteLine(userController.CurrentUSer);

            Console.WriteLine(resourceManager.GetString("TypeAction"));

            Console.WriteLine("E - enter ingestion");
            Console.WriteLine(resourceManager.GetString($"CaseE"+"  \n "+"CaseA"));
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
            var resourceManager = new ResourceManager("Api.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("EnterName"));
            var food = Console.ReadLine();
            var calories = DoubleParse("calories");
            //var prots = DoubleParse("proteins");
            var prots = DoubleParse(resourceManager.GetString("Proteins"));
            var fats = DoubleParse("fats");
            var carbohydrates = DoubleParse("carbohydrates");
            
            var weight = DoubleParse("weight of food");
            var product = new Food(food);
            return (food:product, weight : weight);
        }
        private static DateTime DateTimePArse()
        {
            var resourceManager = new ResourceManager("Api.Languages.Messages", typeof(Program).Assembly);
            DateTime birthday;
            while (true)
            {
                Console.Write(resourceManager.GetString("BirthDay"));
                if (DateTime.TryParse(Console.ReadLine(), out birthday))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("FormatBd"));
                }
            }

            return birthday;
        }

        public static double DoubleParse(string name)
        {
            var resourceManager = new ResourceManager("Api.Languages.Messages", typeof(Program).Assembly);
            while (true)
            {
                Console.WriteLine(resourceManager.GetString("Enter"+name));
                //Console.WriteLine($"Enter {name}");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                    
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("Format" + name));
                    //Console.WriteLine($"Invalid format of {name}");
                }
            }

        }
    }
}
