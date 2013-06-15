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
            DsmUserCollection users;

            users = dsmUserApi.List(null, null).Result;
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Any());
            Assert.AreEqual(users.Total, users.Count());
            DsmUser firstUser = users.First();

            users = dsmUserApi.List(null, 1).Result;
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() <= 1);

            users = dsmUserApi.List(1, null).Result;
            Assert.IsNotNull(users);
            Assert.AreEqual(users.Total - 1, users.Count());
            if (users.Any())
            {
                Assert.AreNotEqual(firstUser.Name, users.First().Name);
            }

            users = dsmUserApi.List(1, 1).Result;
            Assert.IsNotNull(users);
            Assert.IsTrue(users.Count() <= 1);
            if (users.Any())
            {
                Assert.AreNotEqual(firstUser.Name, users.First().Name);
            }
        }
    }
}
