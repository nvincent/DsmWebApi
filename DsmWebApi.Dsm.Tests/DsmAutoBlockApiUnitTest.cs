namespace DsmWebApi.Dsm.Tests
{
    using System;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.AutoBlock;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmAutoBlockApi"/>.
    /// </summary>
    [TestClass]
    public class DsmAutoBlockApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmAutoBlockApi; }
        }

        /// <summary>
        /// Gets or sets the DSM auto block API to test.
        /// </summary>
        private DsmAutoBlockApi DsmAutoBlockApi { get; set; }

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
            this.DsmAutoBlockApi = new DsmAutoBlockApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmAutoBlockApi.DsmAutoBlockApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmAutoBlockApi = new DsmAutoBlockApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmAutoBlockApi.GetConfig()"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetConfig()
        {
            var dsmAutoBlockApi = this.DsmAutoBlockApi;
            Assert.IsNotNull(dsmAutoBlockApi);

            DsmAutoBlockConfiguration configuration = dsmAutoBlockApi.GetConfig().Result;
            Assert.IsNotNull(configuration);
            Assert.IsTrue(configuration.Attempts >= 0);
            Assert.IsTrue(configuration.AttemptsPeriod >= 0);
            Assert.IsTrue(configuration.ExpiredDay >= 0);
        }
    }
}
