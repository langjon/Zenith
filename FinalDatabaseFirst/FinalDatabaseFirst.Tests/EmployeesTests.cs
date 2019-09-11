using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FinalDatabaseFirst.Models;

namespace FinalDatabaseFirst.Tests
{
   public class EmployeesTests
    {
        [Fact]
        public void CanChangeEmployeeName()
        {
            //Arrange
            var p = new Employee{ EmpName = "Laura", EmpAddress = "Hurontario 500" };
            // Act
            p.EmpName = "Faiza";
            //Assert
            Assert.Equal("Faiza", p.EmpName);
        }
        [Fact]
        public void CanChangeEmployeeAddress()
        {
            //Arrange
            var p = new Employee { EmpName = "Laura", EmpAddress = "Hurontario 500" };
            // Act
            p.EmpAddress = "Mississauga rd";
            //Assert
            Assert.Equal("Mississauga rd", p.EmpAddress);
        }
        [Fact]
        public void CanAddEmployee()
        {

            //Arrange
            var one = "Czarina";
            var two = "John st";
          
            var p = new Employee { EmpName = one, EmpAddress = two };

            //Assert
            Assert.Equal("Czarina", p.EmpName);
            Assert.Equal("John st", p.EmpAddress);
           
        }
        [Fact]
        public void CanDeleteEmployee()
        {
            //Arrange
            var p = new Employee { EmpName = "Laura", EmpAddress = "Hurontario 500" };

            // Act
            p.EmpName = null;
            p.EmpAddress = null;
      

            //Assert
            Assert.Null(p.EmpName);
            Assert.Null(p.EmpAddress);
        }
        [Fact]
        public void CanGetProduct()
        {
            //Arrange
            var p = new Employee { EmpName = "Laura", EmpAddress = "Hurontario 500" };

            // Act
            var one = p.EmpName;
            var two = p.EmpAddress;
        
            //Assert
            Assert.Equal(one, p.EmpName);
            Assert.Equal(two, p.EmpAddress);
          
        }
    }
}
