namespace DsmWebApi.Core.Tests
{
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Unit tests for the class <see cref="DsmApiResponse"/>.
    /// </summary>
    [TestClass]
    public class DsmApiResponseUnitTest
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
        /// Tests the <see cref="M:DsmApiResponse.DsmApiResponse(JToken)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructorJToken()
        {
            JToken data = new JObject(new JProperty("prop", "value"));
            var dsmApiResponse = new DsmApiResponse(data);
            Assert.IsTrue(dsmApiResponse.Success);
            Assert.AreEqual(data, dsmApiResponse.Data);
            Assert.IsNull(dsmApiResponse.ErrorCode);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApiResponse.DsmApiResponse(int)"/> constructor.
        /// </summary>
        [TestMethod]
        public void TestConstructorInt()
        {
            int errorCode = 404;
            var dsmApiResponse = new DsmApiResponse(errorCode);
            Assert.IsFalse(dsmApiResponse.Success);
            Assert.IsNull(dsmApiResponse.Data);
            Assert.AreEqual(errorCode, dsmApiResponse.ErrorCode);
        }
    }
}
