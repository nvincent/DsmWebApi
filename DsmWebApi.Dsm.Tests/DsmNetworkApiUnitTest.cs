namespace DsmWebApi.Dsm.Tests
{
    using System;
    using System.Linq;
    using DsmWebApi.Core;
    using DsmWebApi.Core.Tests;
    using DsmWebApi.Dsm.Network;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Unit tests for the class <see cref="DsmNetworkApi"/>.
    /// </summary>
    [TestClass]
    public class DsmNetworkApiUnitTest : DsmApiBaseUnitTest
    {
        /// <inheritdoc />
        protected override DsmApiBase DsmApiBase
        {
            get { return this.DsmNetworkApi; }
        }

        /// <summary>
        /// Gets or sets the DSM network API to test.
        /// </summary>
        private DsmNetworkApi DsmNetworkApi { get; set; }

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
            this.DsmNetworkApi = new DsmNetworkApi(this.DsmApiContext);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmNetworkApi.DsmNetworkApi(IDsmApiContext)"/> constructor.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestConstructorArgumentNullException()
        {
            var dsmNetworkApi = new DsmNetworkApi(null);
        }

        /// <summary>
        /// Tests the <see cref="M:DsmNetworkApi.List()"/> method.
        /// </summary>
        [TestMethod]
        public void TestList()
        {
            var dsmNetworkApi = this.DsmNetworkApi;
            Assert.IsNotNull(dsmNetworkApi);

            DsmNetworkConfiguration networkConfiguration = dsmNetworkApi.List().Result;
            Assert.IsNotNull(networkConfiguration);

            Assert.IsNotNull(networkConfiguration.DnsServers);
            Assert.IsTrue(networkConfiguration.DnsServers.Any());
            foreach (var dnsServer in networkConfiguration.DnsServers)
            {
                Assert.IsFalse(string.IsNullOrEmpty(dnsServer));
            }

            Assert.IsNotNull(networkConfiguration.Interfaces);
            Assert.IsTrue(networkConfiguration.Interfaces.Any());
            foreach (var networkInterface in networkConfiguration.Interfaces)
            {
                Assert.IsNotNull(networkInterface.IPv4Addresses);
                Assert.IsNotNull(networkInterface.IPv6Addresses);
                Assert.IsTrue(networkInterface.IPv4Addresses.Any() || networkInterface.IPv6Addresses.Any());

                Assert.IsFalse(string.IsNullOrEmpty(networkInterface.Id));
                Assert.IsFalse(string.IsNullOrEmpty(networkInterface.MacAddress));
                Assert.IsFalse(string.IsNullOrEmpty(networkInterface.NetworkInterfaceType));
            }

            Assert.IsFalse(string.IsNullOrEmpty(networkConfiguration.Gateway));
            Assert.IsFalse(string.IsNullOrEmpty(networkConfiguration.HostName));
            Assert.IsFalse(string.IsNullOrEmpty(networkConfiguration.Workgroup));
        }
    }
}
