namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Configuration;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.EncryptShare;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmEncryptShareApi"/>.
    /// </summary>
    [TestClass]
    public class DsmEncryptShareApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmEncryptShareApi; }
        }

        /// <summary>
        /// Gets or sets the DSM encrypt share API to test.
        /// </summary>
        private DsmEncryptShareApi DsmEncryptShareApi { get; set; }

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
            this.DsmEncryptShareApi = new DsmEncryptShareApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmEncryptShareApi.DsmEncryptShareApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmEncryptShareApi = new DsmEncryptShareApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmEncryptShareApi.Mount(string, string)"/> and <see cref="M:DsmEncryptShareApi.Unmount(string)"/> methods if supported.
        /// </summary>
        [TestMethod]
        public void TestMountUnmount()
        {
            var dsmEncryptShareApi = this.DsmEncryptShareApi;
            Assert.IsNotNull(dsmEncryptShareApi);

            bool supported = dsmEncryptShareApi.Supported().Result;
            if (supported)
            {
                string shareName = ConfigurationManager.AppSettings["dsm_encryptedShare_name"];
                string sharePassword = ConfigurationManager.AppSettings["dsm_encryptedShare_password"];

                dsmEncryptShareApi.Mount(shareName, sharePassword).Wait();

                dsmEncryptShareApi.Unmount(shareName).Wait();
            }
        }
    }
}
