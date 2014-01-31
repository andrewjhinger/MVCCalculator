using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVCCalculator.Models;

namespace MVCCalculator.Tests
{
    [TestClass]
    public class UnitTests
    {

        [TestMethod]
        public void EnterNumber123()
        {
            // Arrange
            Calculator calculator = new Calculator();
            calculator.CurrentValue = 0.0D;
            calculator.FirstOperation = true;

            // Act
            // Update display
            calculator.Process("1");
            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "1");

            // Act
            calculator.Process("2");

            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "12");

            // Act
            calculator.Process("3");

            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "123");
        }

        [TestMethod]
        public void EnterNumber456()
        {
            // Arrange
            Calculator calculator = new Calculator();
            calculator.CurrentValue = 0.0D;
            calculator.FirstOperation = true;

            // Act
            // Update display
            calculator.Process("4");
            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "4");

            // Act
            calculator.Process("5");

            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "45");

            // Act
            calculator.Process("6");

            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "456");
        }

        [TestMethod]
        public void AddNumber()
        {
            // Arrange
            Calculator calculator = new Calculator();
            calculator.CurrentValue = 0.0D;
            calculator.FirstOperation = true;

            // Act
            // Update display
            calculator.Process("4");
            // Assert

            calculator.Process("+");
            calculator.Process("2");
            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "2");
        }

        [TestMethod]
        public void Enter1()
        {
            // Arrange
            Calculator calculator = new Calculator();
            calculator.CurrentValue = 0.0D;
            calculator.FirstOperation = true;

            // Act
            // Update display
            calculator.Process("1");
            // Assert

            // Assert
            Assert.AreEqual(calculator.CurrentValue.ToString(), "1");
        }
    }
}
