namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.SystemLoading;
    using DsmWebApi.Dsm.User;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmSystemLoadingApi"/>.
    /// </summary>
    [TestClass]
    public class DsmSystemLoadingApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmSystemLoadingApi; }
        }

        /// <summary>
        /// Gets or sets the DSM system loading API to test.
        /// </summary>
        private DsmSystemLoadingApi DsmSystemLoadingApi { get; set; }

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
            this.DsmSystemLoadingApi = new DsmSystemLoadingApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmSystemLoadingApi.DsmSystemLoadingApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmSystemLoadingApi = new DsmSystemLoadingApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmSystemLoadingApi.GetInfo()"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetInfo()
        {
            var dsmSystemLoadingApi = this.DsmSystemLoadingApi;
            Assert.IsNotNull(dsmSystemLoadingApi);

            DsmSystemLoad systemLoad = dsmSystemLoadingApi.GetInfo().Result;
            Assert.IsNotNull(systemLoad);

            Assert.IsNotNull(systemLoad.CpuLoad);
            Assert.IsTrue(systemLoad.CpuLoad.HardIrq >= 0 && systemLoad.CpuLoad.HardIrq <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.Idle >= 0 && systemLoad.CpuLoad.Idle <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.IOWait >= 0 && systemLoad.CpuLoad.IOWait <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.Nice >= 0 && systemLoad.CpuLoad.Nice <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.SoftIrq >= 0 && systemLoad.CpuLoad.SoftIrq <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.Steal >= 0 && systemLoad.CpuLoad.Steal <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.System >= 0 && systemLoad.CpuLoad.System <= 1);
            Assert.IsTrue(systemLoad.CpuLoad.User >= 0 && systemLoad.CpuLoad.User <= 1);

            Assert.IsNotNull(systemLoad.MemoryLoad);
            Assert.IsTrue(systemLoad.MemoryLoad.Buffer >= 0 && systemLoad.MemoryLoad.Buffer <= systemLoad.MemoryLoad.Total);
            Assert.IsTrue(systemLoad.MemoryLoad.Cached >= 0 && systemLoad.MemoryLoad.Cached <= systemLoad.MemoryLoad.Total);
            Assert.IsTrue(systemLoad.MemoryLoad.Free >= 0 && systemLoad.MemoryLoad.Free <= systemLoad.MemoryLoad.Total);
            Assert.IsTrue(systemLoad.MemoryLoad.SwapCached >= 0 && systemLoad.MemoryLoad.SwapCached <= systemLoad.MemoryLoad.Total);

            Assert.IsNotNull(systemLoad.NetworkLoads);
            Assert.IsTrue(systemLoad.NetworkLoads.Any());
            foreach (var networkLoad in systemLoad.NetworkLoads)
            {
                Assert.IsFalse(string.IsNullOrEmpty(networkLoad.Name));
                Assert.IsTrue(networkLoad.Receive >= 0);
                Assert.IsTrue(networkLoad.Transmit >= 0);
            }
        }
    }
}
