namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.User;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmUserApi"/>.
    /// </summary>
    [TestClass]
    public class DsmUserApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmUserApi; }
        }

        /// <summary>
        /// Gets or sets the DSM user API to test.
        /// </summary>
        private DsmUserApi DsmUserApi { get; set; }

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
            this.DsmUserApi = new DsmUserApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmUserApi.DsmUserApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmUserApi = new DsmUserApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmUserApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmUserApi = this.DsmUserApi;
            Assert.IsNotNull(dsmUserApi);

            this.TestList(
                (offset, limit) => dsmUserApi.List(offset, limit).Result,
                users => ((DsmUserCollection)users).Total,
                (user1, user2) => user1.Name == user2.Name);
        }
    }
}
