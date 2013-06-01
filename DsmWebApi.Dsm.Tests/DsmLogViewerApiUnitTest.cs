namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.LogViewer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmLogViewerApi"/>.
    /// </summary>
    [TestClass]
    public class DsmLogViewerApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmLogViewerApi; }
        }

        /// <summary>
        /// Gets or sets the DSM log viewer API to test.
        /// </summary>
        private DsmLogViewerApi DsmLogViewerApi { get; set; }

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
            this.DsmLogViewerApi = new DsmLogViewerApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmLogViewerApi.DsmLogViewerApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmLogViewerApi = new DsmLogViewerApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmLogViewerApi.Supported()"/> method.
        /// </summary>
        [TestMethod]
        public void TestSupported()
        {
            var dsmLogViewerApi = this.DsmLogViewerApi;
            Assert.IsNotNull(dsmLogViewerApi);

            IEnumerable<string> supportedLogs = dsmLogViewerApi.Supported().Result;
            Assert.IsNotNull(supportedLogs);
            Assert.IsTrue(supportedLogs.Any());
        }
    }
}
