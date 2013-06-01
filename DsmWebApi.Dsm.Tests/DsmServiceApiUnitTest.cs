namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Service;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmServiceApi"/>.
    /// </summary>
    [TestClass]
    public class DsmServiceApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmServiceApi; }
        }

        /// <summary>
        /// Gets or sets the DSM service API to test.
        /// </summary>
        private DsmServiceApi DsmServiceApi { get; set; }

        /// <summary>
        /// Runs once before all tests in the class.
        /// </summary>
        /// <param name="testContext">The test context.</param>
        [ClassInitialize]
        public static new void MyClassInitialize(TestContext testContext)
        {
            DsmApiBaseUnitTest.MyClassInitialize(testContext);
        }

        /// <summary>
        /// Runs before each test in the class.
        /// </summary>
        [TestInitialize]
        public override void MyTestInitialize()
        {
            base.MyTestInitialize();
            this.DsmServiceApi = new DsmServiceApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmServiceApi.DsmServiceApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmServiceApi = new DsmServiceApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmServiceApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmServiceApi = this.DsmServiceApi;
            Assert.IsNotNull(dsmServiceApi);

            DsmServiceCollection services = dsmServiceApi.List(0).Result;
            Assert.IsNotNull(services);
            Assert.IsTrue(services.Any());
            int servicesCount = services.Count();

            services = dsmServiceApi.List(1).Result;
            Assert.IsNotNull(services);
            Assert.IsTrue(services.Count() == (servicesCount - 1));
        }
    }
}
