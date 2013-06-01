namespace DsmWebApi.Dsm.Tests
{
    using System;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.FindMe;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmFindMeApi"/>.
    /// </summary>
    [TestClass]
    public class DsmFindMeApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmFindMeApi; }
        }

        /// <summary>
        /// Gets or sets the DSM Find Me API to test.
        /// </summary>
        private DsmFindMeApi DsmFindMeApi { get; set; }

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
            this.DsmFindMeApi = new DsmFindMeApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmFindMeApi.DsmFindMeApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmFindMeApi = new DsmFindMeApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmFindMeApi.Start()"/> and <see cref="M:DsmFindMeApi.Stop()"/> methods if supported.
        /// </summary>
        [TestMethod]
        public void TestStartStop()
        {
            var dsmFindMeApi = this.DsmFindMeApi;
            Assert.IsNotNull(dsmFindMeApi);

            bool supported = dsmFindMeApi.Supported().Result;
            if (supported)
            {
                DsmApiResponse startResponse = dsmFindMeApi.Start().Result;
                Assert.IsNotNull(startResponse);
                Assert.IsTrue(startResponse.Success);

                DsmApiResponse stopResponse = dsmFindMeApi.Stop().Result;
                Assert.IsNotNull(stopResponse);
                Assert.IsTrue(stopResponse.Success);
            }
        }
    }
}
