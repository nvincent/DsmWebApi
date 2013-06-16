namespace DsmWebApi.Dsm.EncryptShare
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DsmWebApi.Core;
    using DsmWebApi.Dsm.Properties;

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
        /// <returns>The task containing the mount operation.</returns>
        public async Task Mount(string shareName, string password)
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
            this.ThrowIfError(response);
        }

        /// <summary>
        /// Unmounts an encrypted share.
        /// </summary>
        /// <param name="shareName">The name of the share to unmount.</param>
        /// <returns>The task containing the unmount operation.</returns>
        public async Task Unmount(string shareName)
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
            this.ThrowIfError(response);
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

        /// <inheritdoc />
        protected override string ConvertErrorCodeToErrorMessage(int errorCode)
        {
            switch (errorCode)
            {
                case 401:
                    return Resources.SharedFolderDoesNotExistMessage;
                case 402:
                    return Resources.InvalidPasswordMessage;
                default:
                    return base.ConvertErrorCodeToErrorMessage(errorCode);
            }
        }
    }
}
