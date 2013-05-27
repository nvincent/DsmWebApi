namespace DsmWebApi.Core.Tests
{
    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the abstract class <see cref="DsmApiBase"/>.
    /// </summary>
    public abstract class DsmApiBaseUnitTest
    {
        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets the DSM API context to inject in the DSM API to test.
        /// </summary>
        protected IDsmApiContext DsmApiContext { get; private set; }

        /// <summary>
        /// Gets the DSM API to test.
        /// </summary>
        protected abstract DsmApiBase DsmApiBase { get; }

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
        /// Runs before each test in the class.
        /// </summary>
        [TestInitialize]
        public virtual void MyTestInitialize()
        {
            this.DsmApiContext = ServiceLocator.Current.GetInstance<IDsmApiContext>();
            this.DsmApiContext.LoadAllApiInfo().Wait();
        }

        /// <summary>
        /// Runs after each test in the class.
        /// </summary>
        [TestCleanup]
        public void MyTestCleanup()
        {
            AuthenticationApi authenticationApi = new AuthenticationApi(this.DsmApiContext);
            authenticationApi.LogOff().Wait();
            this.DsmApiContext = null;
        }

        /// <summary>
        /// Tests the <see cref="P:DsmApiBase.ApiInfo"/> property.
        /// </summary>
        [TestMethod]
        public void TestApiInfo()
        {
            var dsmApi = this.DsmApiBase;
            Assert.IsNotNull(dsmApi);

            var apiInfo = dsmApi.ApiInfo;
            Assert.IsNotNull(apiInfo);
            Assert.IsFalse(string.IsNullOrEmpty(apiInfo.Name));
            Assert.IsFalse(string.IsNullOrEmpty(apiInfo.Path));
            Assert.IsTrue(apiInfo.MinVersion <= apiInfo.MaxVersion);
        }
    }
}
