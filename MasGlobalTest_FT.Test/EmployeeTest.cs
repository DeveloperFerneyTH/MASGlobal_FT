using System;
using MasGlobalTest_FT.BL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MasGlobalTest_FT.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void GetSalaryHour()
        {
            // Arrange
            decimal salary = 70000;
            decimal expected = 100800000;

            // Act
            var cal = new CalculateHourlySalary();
            decimal result = cal.Calculate(salary);

            // Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetSalaryMonth()
        {
            // Arrange
            decimal salary = 820000;
            decimal expected = 9840000;

            // Act
            var cal = new CalculateMonthlySalary();
            decimal result = cal.Calculate(salary);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
