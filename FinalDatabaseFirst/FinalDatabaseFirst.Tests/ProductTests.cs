using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using FinalDatabaseFirst.Models;

namespace FinalDatabaseFirst.Tests
{
    public class ProductTests
    {
        [Fact]
        public void CanChangeProductMaterial()
        {
            //Arrange
            var p = new Product { ProdMaterial = "Kraft", ProdSize= "10x12x15", ProdQuantity = 500 };
            // Act
            p.ProdMaterial = "Gloss";
            //Assert
            Assert.Equal("Gloss", p.ProdMaterial);
        }
        [Fact]
        public void CanChangeProductSize()
        {
            //Arrange
            var p = new Product { ProdMaterial = "Kraft", ProdSize = "10x12x15", ProdQuantity = 500 };
            // Act
            p.ProdSize = "15x15x15";
            //Assert
            Assert.Equal("15x15x15", p.ProdSize);
        }
        [Fact]
        public void CanAddProduct()
        {

            //Arrange
            var one = "Kraft";
            var two = "12x13x12";
            var three = 300;
            var p = new Product { ProdMaterial = one, ProdSize = two, ProdQuantity = three };

            //Assert
            Assert.Equal("Kraft", p.ProdMaterial);
            Assert.Equal("12x13x12", p.ProdSize);
            Assert.Equal(300, p.ProdQuantity);
        }
        [Fact]
        public void CanDeleteProduct()
        {
            //Arrange
            var p = new Product { ProdMaterial = "Kraft", ProdSize = "10x12x15", ProdQuantity = 500 };

            // Act
            p.ProdMaterial = null;
            p.ProdSize = null;
            p.ProdQuantity= null;

            //Assert
            Assert.Null(p.ProdMaterial);
            Assert.Null(p.ProdSize);
            Assert.Null(p.ProdQuantity);
        }
        [Fact]
        public void CanGetProduct()
        {
            //Arrange
            var p = new Product { ProdMaterial = "Kraft", ProdSize = "10x12x15", ProdQuantity = 500 };

            // Act
            var one = p.ProdMaterial;
            var two = p.ProdSize;
            var three = p.ProdQuantity;

            //Assert
            Assert.Equal(one, p.ProdMaterial);
            Assert.Equal(two, p.ProdSize);
            Assert.Equal(three, p.ProdQuantity);
        }
    }
}
