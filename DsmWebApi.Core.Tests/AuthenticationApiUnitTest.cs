namespace DsmWebApi.Core.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="AuthenticationApi"/>.
    /// </summary>
    [TestClass]
    public class AuthenticationApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.AuthenticationApi; }
        }

        /// <summary>
        /// Gets or sets the authentication API to test.
        /// </summary>
        private AuthenticationApi AuthenticationApi { get; set; }

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
            this.AuthenticationApi = new AuthenticationApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:AuthenticationApi.AuthenticationApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var authenticationApi = new AuthenticationApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:AuthenticationApi.LogOn"/> method.
        /// </summary>
        [TestMethod]
        public void TestLogOn()
        {
            var authenticationApi = this.AuthenticationApi;
            Assert.IsNotNull(authenticationApi);

            AuthenticationInformation authenticationInformation = authenticationApi.LogOn("admin", "admin").Result;
            Assert.IsNotNull(authenticationInformation);
            Assert.IsFalse(string.IsNullOrEmpty(authenticationInformation.Sid));
        }

        /// <summary>
        /// Tests the <see cref="M:AuthenticationApi.LogOff"/> method.
        /// </summary>
        [TestMethod]
        public void TestLogOff()
        {
            var authenticationApi = this.AuthenticationApi;
            Assert.IsNotNull(authenticationApi);

            authenticationApi.LogOff().Wait();
        }
    }
}
