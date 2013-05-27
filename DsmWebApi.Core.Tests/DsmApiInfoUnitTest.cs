namespace DsmWebApi.Core.Tests
{
    using System;
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Unit tests for the class <see cref="DsmApiInfo"/>.
    /// </summary>
    [TestClass]
    public class DsmApiInfoUnitTest
    {
        /// <summary>
        /// Runs once before all tests in the class.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(new UnityContainer().LoadConfiguration()));
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApiInfo.DsmApiInfo(string, string, int, int)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructor()
        {
            var dsmApiInfo = new DsmApiInfo("name", "path", 3, 12);
            Assert.AreEqual("name", dsmApiInfo.Name);
            Assert.AreEqual("path", dsmApiInfo.Path);
            Assert.AreEqual(3, dsmApiInfo.MinVersion);
            Assert.AreEqual(12, dsmApiInfo.MaxVersion);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApiInfo.ConvertFrom"/> method.
        /// </summary>
        [TestMethod]
        public void TestConvertFrom()
        {
            JProperty property = new JProperty(
                "name",
                new JObject(
                    new JProperty("path", "path"),
                    new JProperty("name", "name"),
                    new JProperty("minVersion", 3),
                    new JProperty("maxVersion", 12)));
            var dsmApiInfo = DsmApiInfo.ConvertFrom(property);
            Assert.AreEqual("name", dsmApiInfo.Name);
            Assert.AreEqual("path", dsmApiInfo.Path);
            Assert.AreEqual(3, dsmApiInfo.MinVersion);
            Assert.AreEqual(12, dsmApiInfo.MaxVersion);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApiInfo.ConvertFrom"/> method.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConvertFromArgumentNullException()
        {
            var dsmApiInfo = DsmApiInfo.ConvertFrom(null);
        }
    }
}
