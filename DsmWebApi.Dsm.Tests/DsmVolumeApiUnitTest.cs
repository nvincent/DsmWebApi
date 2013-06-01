namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Volume;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmVolumeApi"/>.
    /// </summary>
    [TestClass]
    public class DsmVolumeApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmVolumeApi; }
        }

        /// <summary>
        /// Gets or sets the DSM volume API to test.
        /// </summary>
        private DsmVolumeApi DsmVolumeApi { get; set; }

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
            this.DsmVolumeApi = new DsmVolumeApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmVolumeApi.DsmVolumeApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmVolumeApi = new DsmVolumeApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmVolumeApi.List(int)"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmVolumeApi = this.DsmVolumeApi;
            Assert.IsNotNull(dsmVolumeApi);

            DsmVolumeCollection volumes = dsmVolumeApi.List(0).Result;
            Assert.IsNotNull(volumes);
            Assert.IsTrue(volumes.Any());
            int volumesCount = volumes.Count();

            volumes = dsmVolumeApi.List(1).Result;
            Assert.IsNotNull(volumes);
            Assert.IsTrue(volumes.Count() == (volumesCount - 1));
        }
    }
}
