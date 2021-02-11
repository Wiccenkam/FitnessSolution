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
    public class ExersiceControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var FoodName = Guid.NewGuid().ToString();
            var activityNAme = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var exersiceController = new ExersiceController(userController.CurrentUSer);
            
            var activity = new Activity(activityNAme, rnd.Next(10, 50));
            //Act
            exersiceController.Add(activity, DateTime.Now , DateTime.Now.AddHours(1));
            //Assert
            Assert.Equals(activity.Name, exersiceController.Activities.First().Name);
        }
    }
}