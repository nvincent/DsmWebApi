namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Group;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmGroupApi"/>.
    /// </summary>
    [TestClass]
    public class DsmGroupApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmGroupApi; }
        }

        /// <summary>
        /// Gets or sets the DSM group API to test.
        /// </summary>
        private DsmGroupApi DsmGroupApi { get; set; }

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
            this.DsmGroupApi = new DsmGroupApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmGroupApi.DsmGroupApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmGroupApi = new DsmGroupApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmGroupApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmGroupApi = this.DsmGroupApi;
            Assert.IsNotNull(dsmGroupApi);

            DsmGroupCollection groups = dsmGroupApi.List(0).Result;
            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Any());
            int groupsCount = groups.Count();

            groups = dsmGroupApi.List(1).Result;
            Assert.IsNotNull(groups);
            Assert.IsTrue(groups.Count() == (groupsCount - 1));
        }
    }
}
