using System.Linq;
using System.Reflection;
using NUnit.Framework;
using Service.Dtos;

namespace UnitTests.ServiceUnitTests.DtosTests
{
    [TestFixture]
    public class DomainEntityDtoTests
    {
        [Test]
        public void DomainEntityDto_has_a_default_constructor()
        {
            // Arrange
            var constructorInfo = typeof(DomainEntityDto).GetConstructors();

            // Act

            // Assert
            Assert.IsFalse(constructorInfo.Any(c => c.IsPublic && c.GetParameters().Length == 0));
        }
    }
}
