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
            Console.WriteLine("Enter your gender");
            var gender = Console.ReadLine();
            Console.WriteLine("Enter your bith day");
            var birthDay = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter your weight");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your weight");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDay, weight, height);
            userController.Save();
        }
    }
}
