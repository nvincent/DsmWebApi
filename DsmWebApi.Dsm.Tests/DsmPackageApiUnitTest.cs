namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Package;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmPackageApi"/>.
    /// </summary>
    [TestClass]
    public class DsmPackageApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmPackageApi; }
        }

        /// <summary>
        /// Gets or sets the DSM package API to test.
        /// </summary>
        private DsmPackageApi DsmPackageApi { get; set; }

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
            this.DsmPackageApi = new DsmPackageApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmPackageApi.DsmPackageApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmPackageApi = new DsmPackageApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmPackageApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmPackageApi = this.DsmPackageApi;
            Assert.IsNotNull(dsmPackageApi);

            this.TestList(
                (offset, limit) => dsmPackageApi.List(offset, limit).Result,
                packages => ((DsmPackageCollection)packages).Total,
                (package1, package2) => package1.Name == package2.Name);
        }
    }
}
