using BusinessLogic.Controller;
using System;

namespace Api
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fitness");

            Console.WriteLine("Enter your name");

            var name = Console.ReadLine();

            var userController = new UserController(name);

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
