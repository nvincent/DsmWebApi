namespace DsmWebApi.Dsm.Tests
{
    using System;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Info;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmInformationApi"/>.
    /// </summary>
    [TestClass]
    public class DsmInformationApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmInformationApi; }
        }

        /// <summary>
        /// Gets or sets the DSM information API to test.
        /// </summary>
        private DsmInformationApi DsmInformationApi { get; set; }

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
            this.DsmInformationApi = new DsmInformationApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmInformationApi.DsmInformationApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmInformationApi = new DsmInformationApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmInformationApi.GetInfo()"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetInfo()
        {
            var dsmInformationApi = this.DsmInformationApi;
            Assert.IsNotNull(dsmInformationApi);

            DsmInformation dsmInformation = dsmInformationApi.GetInfo().Result;
            Assert.IsNotNull(dsmInformation);
            Assert.IsTrue(dsmInformation.MemoryInstalled > 0);
            Assert.IsFalse(string.IsNullOrEmpty(dsmInformation.Model));
            Assert.IsFalse(string.IsNullOrEmpty(dsmInformation.Serial));
            Assert.IsTrue(dsmInformation.Temperature > 0);
            Assert.IsTrue(dsmInformation.Time != new DateTime());
            Assert.IsTrue(dsmInformation.Uptime != new TimeSpan());
            Assert.IsFalse(string.IsNullOrEmpty(dsmInformation.Version));
            Assert.IsFalse(string.IsNullOrEmpty(dsmInformation.VersionString));
        }
    }
}
