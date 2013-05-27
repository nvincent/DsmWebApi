namespace DsmWebApi.Core.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="InformationApi"/>.
    /// </summary>
    [TestClass]
    public class InformationApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.InformationApi; }
        }

        /// <summary>
        /// Gets or sets the information API to test.
        /// </summary>
        private InformationApi InformationApi { get; set; }

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
            this.InformationApi = new InformationApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:InformationApi.InformationApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var informationApi = new InformationApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:InformationApi.QueryAll"/> method.
        /// </summary>
        [TestMethod]
        public void TestQueryAll()
        {
            var informationApi = this.InformationApi;
            Assert.IsNotNull(informationApi);

            IEnumerable<DsmApiInfo> apiInfo = informationApi.QueryAll().Result;
            Assert.IsNotNull(apiInfo);
            Assert.IsTrue(apiInfo.Any());
        }
    }
}
