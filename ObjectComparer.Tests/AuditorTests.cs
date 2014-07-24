using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using ObjectComparer.Tests.TestHelpers;
using ObjectComparer.Workers.Interfaces;

namespace ObjectComparer.Tests
{
    [TestClass]
    public class AuditorTests
    {
        private IPropertyComparer _propertyComparer;
        private IPropertyGetter _propertyGetter;

        private IAuditor _target;

        [TestInitialize]
        public void SetupTests()
        {
            _propertyComparer = Substitute.For<IPropertyComparer>();
            _propertyGetter = Substitute.For<IPropertyGetter>();

            _target = new Auditor(_propertyComparer, _propertyGetter);
        }

        #region HelperMethods

        private void StubCompareProperties(bool matching)
        {
            string result = matching ? "" : "difference";

            //set compare prop method to return result string.
            _propertyComparer.CompareProperties(Arg.Any<KeyValuePair<string, string>>(),
                Arg.Any<KeyValuePair<string, string>>()).Returns(result);
        }

        private void StubGetProperties()
        {
            var fakeProps = new Dictionary<string, string> {{"PropA", "test"}};

            _propertyGetter.GetProperties(Arg.Any<object>()).Returns(fakeProps);
        }

        #endregion

        [TestMethod]
        public void GetChanges_TwoDifferentObjects_returnsDifferentTypeText()
        {
            //Arrange
            TestObject objA = new TestObject();
            TestObjectB objB = new TestObjectB();

            //Act
            var result = _target.GetChanges(objA, objB);

            //Assert
            Assert.IsTrue(result[0] == "The objects supplied are not of the same type.");
        }

        [TestMethod]
        public void GetChanges_TwoDifferentObjects_DoesntCallPropGetter()
        {
            //Arrange
            TestObject objA = new TestObject();
            TestObjectB objB = new TestObjectB();

            //Act
            _target.GetChanges(objA, objB);

            //Assert
            Assert.IsTrue(_propertyGetter.ReceivedCalls().Count() == 0);
        }

        [TestMethod]
        public void GetChanges_TwoDifferentObjects_DoesntCallPropComparer()
        {
            //Arrange
            TestObject objA = new TestObject();
            TestObjectB objB = new TestObjectB();

            //Act
            _target.GetChanges(objA, objB);

            //Assert
            Assert.IsTrue(_propertyComparer.ReceivedCalls().Count() == 0);
        }

        [TestMethod]
        public void GetChanges_SameTypes_CallsPropertyComparer()
        {
            //Arrange
            TestObject objA = new TestObject(){PropA = "test"};
            TestObject objB = new TestObject(){PropA = "test1"};

            StubGetProperties();
            StubCompareProperties(false);
            
            //Act
            _target.GetChanges(objA, objB);

            //Assert
            _propertyComparer.Received()
                .CompareProperties(new KeyValuePair<string, string>("PropA", "test"),
                    new KeyValuePair<string, string>("PropA", "test"));
        }
    }
}
