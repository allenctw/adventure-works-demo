using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Service.DiscountCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;

namespace AdventureWorks.Service.DiscountCore.Tests
{
    [TestClass()]
    public class RebateStrategyTests
    {
        [TestMethod()]
        public void CalculateDiscount_null_ReturnsZero()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var expected = 0m;
                var sut = autoMock.Create<RebateStrategy>();

                // Act
                var actual = sut.CalculateDiscount(null);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void CalculateDiscount_EmptyList_ReturnsZero()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var products = new List<Product>();
                var expected = 0m;
                var sut = autoMock.Create<RebateStrategy>();

                // Act
                var actual = sut.CalculateDiscount(products);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void CalculateDiscount_Less1000_ReturnsZero()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var products = new List<Product> 
                {
                    new Product
                    {
                        Name = "test",
                        Qty = 2,
                        Price = 100
                    },
                    new Product
                    {
                        Name = "test",
                        Qty = 1,
                        Price = 300
                    }
                };
                var expected = 0m;
                var sut = autoMock.Create<RebateStrategy>();

                // Act
                var actual = sut.CalculateDiscount(products);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void CalculateDiscount_1000To2000_Returns100()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "test",
                        Qty = 2,
                        Price = 500
                    },
                    new Product
                    {
                        Name = "test",
                        Qty = 1,
                        Price = 300
                    }
                };
                var expected = 100m;
                var sut = autoMock.Create<RebateStrategy>();

                // Act
                var actual = sut.CalculateDiscount(products);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }

        [TestMethod()]
        public void CalculateDiscount_5000To6000_Returns500()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var products = new List<Product>
                {
                    new Product
                    {
                        Name = "test",
                        Qty = 2,
                        Price = 2500
                    },
                    new Product
                    {
                        Name = "test",
                        Qty = 1,
                        Price = 300
                    }
                };
                var expected = 500m;
                var sut = autoMock.Create<RebateStrategy>();

                // Act
                var actual = sut.CalculateDiscount(products);

                // Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}