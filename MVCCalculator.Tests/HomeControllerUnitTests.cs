using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVCCalculator.Models;
using MVCCalculator.Controllers;
using MVCCalculator.FormModels;

namespace MVCCalculator.Tests
{
    [TestClass]
    public class HomeControllerUnitTests
    {
        [TestMethod]
        public void TestIndexView()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestIndexView2()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.AreNotEqual("Index2", result.ViewName);
        }

        [TestMethod]
        public void TestIndexViewEnterNumber()
        {
            // Arrange

            HomeController controller = new HomeController();
            Calculator setupCalculator = new Calculator
            {
                CurrentValue = 0.0D,
                FirstOperation = true,
                PendingValue = 0.0D,
                PendingAction = ""
            };

            // Act
            var result = controller.Index(setupCalculator, new CalculatorForm { key = "1" }) as ViewResult;
            var resultCalculator = (Calculator)result.ViewData.Model;

            // Assert
            Assert.AreEqual(1.0D, resultCalculator.CurrentValue);
        }

        [TestMethod]
        public void TestIndexViewEnterNumber2()
        {
            // Arrange

            HomeController controller = new HomeController();
            Calculator setupCalculator = new Calculator
            {
                CurrentValue = 0.0D,
                FirstOperation = true,
                PendingValue = 0.0D,
                PendingAction = ""
            };

            // Act
            var result = controller.Index(setupCalculator, new CalculatorForm { key = "3" }) as ViewResult;
            var resultCalculator = (Calculator)result.ViewData.Model;

            // Assert
            Assert.AreEqual(3.0D, resultCalculator.CurrentValue);
        }
    }
}