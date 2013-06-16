namespace DsmWebApi.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
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
            AuthenticationApi authenticationApi = new AuthenticationApi(this.DsmApiContext);
            string account = ConfigurationManager.AppSettings["dsm_account"];
            string password = ConfigurationManager.AppSettings["dsm_password"];
            authenticationApi.LogOn(account, password).Wait();
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
            Assert.IsFalse(string.IsNullOrEmpty(apiInfo.Path));
            Assert.IsTrue(apiInfo.MinVersion <= apiInfo.MaxVersion);
        }

        /// <summary>
        /// Tests a list operation that takes an offset and a limit parameter.
        /// </summary>
        /// <typeparam name="T">The type of the listed objects.</typeparam>
        /// <param name="list">The function that takes an offset and a limit parameters and returns a collection of objects.</param>
        /// <param name="getTotal">The function that takes a collection of objects returned by <paramref name="list"/> and returns the total number of objects of type <typeparamref name="T"/>.</param>
        /// <param name="equalityComparer">A function that compares two objects of type <typeparamref name="T"/> and returns true if they are equal, false otherwise.</param>
        protected void TestList<T>(
            Func<int?, int?, IEnumerable<T>> list,
            Func<IEnumerable<T>, int> getTotal,
            Func<T, T, bool> equalityComparer)
        {
            IEnumerable<T> items;

            items = list(null, null);
            Assert.IsNotNull(items);
            if (!items.Any())
            {
                return;
            }

            Assert.IsTrue(items.Any());
            Assert.AreEqual(getTotal(items), items.Count());
            T firstItem = items.First();

            items = list(null, 1);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() <= 1);

            items = list(1, null);
            Assert.IsNotNull(items);
            Assert.AreEqual(getTotal(items) - 1, items.Count());
            if (items.Any())
            {
                Assert.IsFalse(equalityComparer(firstItem, items.First()));
            }

            items = list(1, 1);
            Assert.IsNotNull(items);
            Assert.IsTrue(items.Count() <= 1);
            if (items.Any())
            {
                Assert.IsFalse(equalityComparer(firstItem, items.First()));
            }
        }
    }
}
