namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Application;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmApplicationApi"/>.
    /// </summary>
    [TestClass]
    public class DsmApplicationApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmApplicationApi; }
        }

        /// <summary>
        /// Gets or sets the DSM application API to test.
        /// </summary>
        private DsmApplicationApi DsmApplicationApi { get; set; }

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
            this.DsmApplicationApi = new DsmApplicationApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApplicationApi.DsmApplicationApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmApplicationApi = new DsmApplicationApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmApplicationApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmApplicationApi = this.DsmApplicationApi;
            Assert.IsNotNull(dsmApplicationApi);

            this.TestList(
                (offset, limit) => dsmApplicationApi.List(offset, limit).Result,
                applications => ((DsmApplicationCollection)applications).Total,
                (application1, application2) => application1.Name == application2.Name);
        }
    }
}
