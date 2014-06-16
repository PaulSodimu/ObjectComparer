using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectComparer.Tests.TestHelpers;
using ObjectComparer.Workers;
using ObjectComparer.Workers.Interfaces;
using System;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class PropertyGetterTests
    {
        public IPropertyGetter _target;
        
        [TestInitialize]
        public void SetupTests()
        {
            _target = new PropertyGetter();
        }

        [TestMethod]
        public void GetProperties_ObjectWithoutProperties_ReturnsDictionaryWithNoItems()
        {
            //Arrange
            var testObject = new { };

            //Act
            var results = _target.GetProperties(testObject);

            //Assert
            Assert.IsTrue(results.Count == 0);
        }

        [TestMethod]
        public void GetProperties_ObjectWithOneProperty_ReturnsDictionaryWithOneItem()
        {
            //Arrange
            var testObject = new TestObject { PropA = "yes" };

            //Act
            var results = _target.GetProperties(testObject);

            //Assert
            Assert.IsTrue(results.Count == 1);
        }

        [Ignore]
        [TestMethod]
        public void GetProperties_ObjectWithDateProperty_ReturnsDictionaryWithCorrectItemValue()
        {
            //Arrange
            var testObject = new TestObjectB { PropA = new DateTime(2014,5,30) };

            //Act
            var results = _target.GetProperties(testObject);

            //Assert
            Assert.IsTrue(false);
        }

        [TestMethod]
        public void GetProperties_ObjectWithOneProperty_ReturnsDictionaryWithCorrectValue()
        {
            //Arrange
            string value = "test";
            var testObject = new TestObject { PropA = value };

            //Act
            var results = _target.GetProperties(testObject);

            //Assert
            Assert.IsTrue(results["PropA"] == value);
        }
    }
}
