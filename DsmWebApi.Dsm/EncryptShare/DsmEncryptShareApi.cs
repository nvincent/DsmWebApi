namespace DsmWebApi.Dsm.EncryptShare
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DsmWebApi.Core;

    /// <summary>
    /// The DSM encrypt share API.
    /// </summary>
    public class DsmEncryptShareApi : DsmApiBase
    {
        /// <summary>
        /// The name of the DSM encrypt share API.
        /// </summary>
        private const string DsmEncryptShareApiName = "SYNO.DSM.EncryptShare";

        /// <summary>
        /// Initializes a new instance of the <see cref="DsmEncryptShareApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public DsmEncryptShareApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, DsmEncryptShareApiName, 1)
        {
        }

        /// <summary>
        /// Mounts an encrypted share.
        /// </summary>
        /// <param name="shareName">The name of the share to mount.</param>
        /// <param name="password">The password of the share to mount.</param>
        /// <returns>The response of the mount request.</returns>
        public async Task<DsmApiResponse> Mount(string shareName, string password)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmEncryptShareApiName,
                this.ApiInfo.MaxVersion,
                "mount",
                new Dictionary<string, string>()
                {
                    { "share", shareName },
                    { "password", password }
                });
            return response;
        }

        /// <summary>
        /// Unmounts an encrypted share.
        /// </summary>
        /// <param name="shareName">The name of the share to unmount.</param>
        /// <returns>The response of the unmount request.</returns>
        public async Task<DsmApiResponse> Unmount(string shareName)
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmEncryptShareApiName,
                this.ApiInfo.MaxVersion,
                "unmount",
                new Dictionary<string, string>()
                {
                    { "share", shareName }
                });
            return response;
        }

        /// <summary>
        /// Indicates whether encryption is supported.
        /// </summary>
        /// <returns>A value indicating whether encryption is supported.</returns>
        public async Task<bool> Supported()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                DsmEncryptShareApiName,
                this.ApiInfo.MaxVersion,
                "supported",
                null);
            bool supported = response.Success;
            return supported;
        }
    }
}
