using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using ObjectComparer.Formatting.Interfaces;
using ObjectComparer.Workers;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Tests.Workers
{
    [TestClass]
    public class DifferenceStringGeneratorTest
    {
        private IFormatRulesEngine _rulesEngine;
        private IDifferenceStringGenerator _target;

        private string _testProperty;

        [TestInitialize]
        public void SetupTests()
        {
            _rulesEngine = Substitute.For<IFormatRulesEngine>();

            _testProperty = "TestProperty";
            _rulesEngine.ApplyRules(Arg.Any<string>()).Returns(_testProperty);

            _target = new DifferenceStringGenerator(_rulesEngine);
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropName()
        {
            //Arrange
            _testProperty = "TestProperty";
            
            //Act
            var result = _target.Generate(_testProperty, "a", "b");
            
            //Assert
            Assert.IsTrue(result.Contains("Test Property"));
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropAValue()
        {
            //Arrange
            _testProperty = "TestProperty";

            //Act
            var result = _target.Generate(_testProperty, "a", "b");

            //Assert
            Assert.IsTrue(result.Contains("a"));
        }

        [TestMethod]
        public void Generate_AllValuesPresent_ReturnsStringContainingPropBValue()
        {
            //Arrange
            _testProperty = "TestProperty";

            //Act
            var result = _target.Generate(_testProperty, "a", "b");

            //Assert
            Assert.IsTrue(result.Contains("b"));
        }

    }
}
