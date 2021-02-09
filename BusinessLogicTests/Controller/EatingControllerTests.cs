using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model;
using System.Linq;

namespace BusinessLogic.Controller.Tests
{
    [TestClass()]
    public class EatingControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var FoodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUSer);
            var food = new Food(FoodName, rnd.Next(50, 400), rnd.Next(50, 400), rnd.Next(50, 400), rnd.Next(50, 400));
            //Act
            eatingController.Add(food, 100);
            //Assert
            Assert.Equals(food.Name, eatingController.Eating.Foods.First().Key.Name);
        }
    }
}