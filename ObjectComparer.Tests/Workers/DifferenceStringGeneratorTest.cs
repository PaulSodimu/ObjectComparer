using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer.Workers;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Tests.Workers
{
    [TestClass]
    public class DifferenceStringGeneratorTest
    {
        private IDifferenceStringGenerator _target;

        [TestInitialize]
        public void SetupTests()
        {
            _target = new DifferenceStringGenerator();
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropName()
        {
            //Arrange
            
            //Act
            var result = _target.Generate("TestProperty", "a", "b");
            
            //Assert
            Assert.IsTrue(result.Contains("Test Property"));
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropAValue()
        {
            //Arrange

            //Act
            var result = _target.Generate("TestProperty", "a", "b");

            //Assert
            Assert.IsTrue(result.Contains("a"));
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropBValue()
        {
            //Arrange

            //Act
            var result = _target.Generate("TestProperty", "a", "b");

            //Assert
            Assert.IsTrue(result.Contains("b"));
        }

    }
}
