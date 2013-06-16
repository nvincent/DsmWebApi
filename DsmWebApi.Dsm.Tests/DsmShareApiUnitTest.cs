namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Share;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmShareApi"/>.
    /// </summary>
    [TestClass]
    public class DsmShareApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmShareApi; }
        }

        /// <summary>
        /// Gets or sets the DSM share API to test.
        /// </summary>
        private DsmShareApi DsmShareApi { get; set; }

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
            this.DsmShareApi = new DsmShareApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmShareApi.DsmShareApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmShareApi = new DsmShareApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmShareApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmShareApi = this.DsmShareApi;
            Assert.IsNotNull(dsmShareApi);

            this.TestList<DsmShare>(
                (offset, limit) => dsmShareApi.List(offset, limit).Result,
                shares => ((DsmShareCollection)shares).Total,
                (share1, share2) => share1.Name == share2.Name);
        }
    }
}
