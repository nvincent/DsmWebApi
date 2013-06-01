namespace DsmWebApi.Core.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="EncryptionApi"/>.
    /// </summary>
    [TestClass]
    public class EncryptionApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.EncryptionApi; }
        }

        /// <summary>
        /// Gets or sets the encryption API to test.
        /// </summary>
        private EncryptionApi EncryptionApi { get; set; }

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
            this.EncryptionApi = new EncryptionApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:EncryptionApi.EncryptionApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var encryptionApi = new EncryptionApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:EncryptionApi.GetInfo"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetInfo()
        {
            var encryptionApi = this.EncryptionApi;
            Assert.IsNotNull(encryptionApi);

            EncryptionInformation encryptionInformation = encryptionApi.GetInfo().Result;
            Assert.IsNotNull(encryptionInformation);
            Assert.IsFalse(string.IsNullOrEmpty(encryptionInformation.CipherKey));
            Assert.IsFalse(string.IsNullOrEmpty(encryptionInformation.CipherToken));
            Assert.IsFalse(string.IsNullOrEmpty(encryptionInformation.PublicKey));
            Assert.IsTrue(encryptionInformation.ServerTime != new DateTime());
            Assert.IsTrue(encryptionInformation.ServerTime.Kind == DateTimeKind.Utc);
        }
    }
}
