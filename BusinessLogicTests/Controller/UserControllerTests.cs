using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLogic.Controller;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {


        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var userNAme = Guid.NewGuid().ToString();

            //Act
            var controller = new UserController(userNAme);
            //Assert
            Assert.AreEqual(userNAme, controller.CurrentUSer.Name);
        }

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userNAme = Guid.NewGuid().ToString();
            var birthDay = DateTime.Now.AddYears(-18);
            var gender = "man";
            var weight = 90;
            var height = 190;
            //Act
            var controller = new UserController(userNAme);
            controller.SetNewUserData(gender, birthDay, weight,height);
            var controller2 = new UserController(userNAme);
            //Asssert
            Assert.AreEqual(userNAme, controller2.CurrentUSer.Name);
            Assert.AreEqual(birthDay, controller2.CurrentUSer.BithDay);
            Assert.AreEqual(gender, controller2.CurrentUSer.Gender.Name);
            Assert.AreEqual(height, controller2.CurrentUSer.Height);
            Assert.AreEqual(weight, controller2.CurrentUSer.Weight);


        }
    }
}