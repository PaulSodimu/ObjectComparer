using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObjectComparer.Workers;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Tests.Workers
{
    [TestClass]
    public class PropertyComparerTests
    {
        private IDifferenceStringGenerator _diffStringGenerator;

        private IPropertyComparer _target;

        KeyValuePair<string, string> propA;
        KeyValuePair<string, string> propB;

        [TestInitialize]
        public void SetupTests()
        {
            _diffStringGenerator = Substitute.For<IDifferenceStringGenerator>();

            _target = new PropertyComparer(_diffStringGenerator);
        }

        [TestMethod]
        public void CompareProperties_TwoProperties_ReturnsString()
        {
            //Arrange 
            propA = new KeyValuePair<string, string>("Colour", "Red");
            propB = new KeyValuePair<string, string>("Colour", "Blue"); 

            //Act
            var result = _target.CompareProperties(propA, propB);

            //Assert
            Assert.IsInstanceOfType(result, typeof(string));
        }

        [TestMethod]
        public void CompareProperties_DifferentProperties_ReturnsCorrectChangeString()
        {
            //Arrange 
            var expected = "test";

            propA = new KeyValuePair<string, string>("Colour", "Red");
            propB = new KeyValuePair<string, string>("Colour", "Blue");

            _diffStringGenerator.Generate(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(expected);
            

            //Act
            var actual = _target.CompareProperties(propA, propB);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CompareProperties_SameProperties_ReturnsEmptyString()
        {
            //Arrange 
            propA = new KeyValuePair<string, string>("Colour", "Red");
            propB = new KeyValuePair<string, string>("Colour", "Red");

            //Act
            var actual = _target.CompareProperties(propA, propB);

            //Assert
            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void CompareProperties_DifferentProperties_CallsDiffStringGenerator()
        {
            //Arrange 
            propA = new KeyValuePair<string, string>("Colour", "Red");
            propB = new KeyValuePair<string, string>("Colour", "Blue");
            
            //Act
            _target.CompareProperties(propA, propB);

            //Assert
            _diffStringGenerator.Received().Generate("Colour", "Red", "Blue");
        }

        [TestMethod]
        public void CompareProperties_SameProperties_DoesntCallDiffStringGenerator()
        {
            //Arrange 
            propA = new KeyValuePair<string, string>("Colour", "Red");
            propB = new KeyValuePair<string, string>("Colour", "Red");

            //Act
            _target.CompareProperties(propA, propB);

            //Assert

            Assert.IsTrue(_diffStringGenerator.ReceivedCalls().Count() == 0); ;
        }


    }
}
