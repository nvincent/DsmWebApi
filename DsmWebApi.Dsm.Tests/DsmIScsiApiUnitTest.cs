namespace DsmWebApi.Dsm.Tests
{
    using System;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.IScsi;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmIScsiApi"/>.
    /// </summary>
    [TestClass]
    public class DsmIScsiApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmIScsiApi; }
        }

        /// <summary>
        /// Gets or sets the DSM iSCSI API to test.
        /// </summary>
        private DsmIScsiApi DsmIScsiApi { get; set; }

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
            this.DsmIScsiApi = new DsmIScsiApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmIScsiApi.DsmIScsiApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmIScsiApi = new DsmIScsiApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmIScsiApi.List()"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmIScsiApi = this.DsmIScsiApi;
            Assert.IsNotNull(dsmIScsiApi);

            DsmIScsiConfiguration iscsiConfiguration = dsmIScsiApi.List().Result;
            Assert.IsNotNull(iscsiConfiguration);
        }
    }
}
