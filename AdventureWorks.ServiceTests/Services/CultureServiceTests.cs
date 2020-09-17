using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorks.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Moq;
using System.Linq.Expressions;
using AdventureWorks.Dal;

namespace AdventureWorks.Service.Services.Tests
{
    [TestClass()]
    public class CultureServiceTests
    {
        [TestMethod()]
        public void GetCultureIDsTest_Call_ReturnsIDs()
        {
            using (var autoMock = AutoMock.GetLoose())
            {
                // Arrange
                var mockCulture = GenerateMockCulture().AsQueryable();
                var mock = autoMock.Mock<IDbRepository<Culture>>();
                mock.Setup(x => x.Get(It.IsAny<Expression<Func<Culture, bool>>>()))
                    .Returns(mockCulture);

                var expected = new string[] { "", "ar", "en" };
                var sut = autoMock.Create<CultureService>();

                // Act
                var actual = sut.GetCultureIDs();

                // Assert
                mock.Verify(x => x.Get(It.IsAny<Expression<Func<Culture, bool>>>()));
                CollectionAssert.AreEqual(expected, actual);
            }
        }

        private List<Culture> GenerateMockCulture()
        {
            return new List<Culture>
            {
                new Culture
                {
                    CultureID = "      ",
                    Name = "Invariant Language (Invariant Country)",
                    ModifiedDate = new DateTime(2008, 4, 30)
                },
                new Culture
                {
                    CultureID = "ar    ",
                    Name = "Arabic",
                    ModifiedDate = new DateTime(2008, 4, 30)
                },
                new Culture
                {
                    CultureID = "en    ",
                    Name = "English",
                    ModifiedDate = new DateTime(2008, 4, 30)
                }
            };
        }
    }
}