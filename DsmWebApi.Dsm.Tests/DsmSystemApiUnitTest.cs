namespace DsmWebApi.Dsm.Tests
{
    using System;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.DsmSystem;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmSystemApi"/>.
    /// </summary>
    [TestClass]
    public class DsmSystemApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmSystemApi; }
        }

        /// <summary>
        /// Gets or sets the DSM system API to test.
        /// </summary>
        private DsmSystemApi DsmSystemApi { get; set; }

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
            this.DsmSystemApi = new DsmSystemApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmSystemApi.DsmSystemApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmSystemApi = new DsmSystemApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmSystemApi.PingPong()"/> method.
        /// </summary>
        [TestMethod]
        public void TestPingPong()
        {
            var dsmSystemApi = this.DsmSystemApi;
            Assert.IsNotNull(dsmSystemApi);

            bool ping = dsmSystemApi.PingPong().Result;
            Assert.IsTrue(ping);
        }
    }
}
