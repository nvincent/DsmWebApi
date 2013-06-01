namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Connection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmConnectionApi"/>.
    /// </summary>
    [TestClass]
    public class DsmConnectionApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmConnectionApi; }
        }

        /// <summary>
        /// Gets or sets the DSM connection API to test.
        /// </summary>
        private DsmConnectionApi DsmConnectionApi { get; set; }

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
            this.DsmConnectionApi = new DsmConnectionApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmConnectionApi.DsmConnectionApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmConnectionApi = new DsmConnectionApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmConnectionApi.List()"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmConnectionApi = this.DsmConnectionApi;
            Assert.IsNotNull(dsmConnectionApi);

            DsmConnectionCollection connections = dsmConnectionApi.List().Result;
            Assert.IsNotNull(connections);
            Assert.IsTrue(connections.Any());
        }
    }
}
