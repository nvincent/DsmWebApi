namespace DsmWebApi.Core
{
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    /// <summary>
    /// The core encryption API.
    /// </summary>
    public class EncryptionApi : DsmApiBase
    {
        /// <summary>
        /// The name of the encryption API.
        /// </summary>
        private const string EncryptionApiName = "SYNO.API.Encryption";

        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptionApi"/> class.
        /// </summary>
        /// <param name="dsmApiContext">The context used to access the DSM API.</param>
        public EncryptionApi(IDsmApiContext dsmApiContext)
            : base(dsmApiContext, EncryptionApiName, 1)
        {
        }

        /// <summary>
        /// Gets the information about the encryption.
        /// </summary>
        /// <returns>The information about the encryption.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "The method can perform a time-consuming operation. The method can be perceivably slower than the time that is required to set or get the value of a field.")]
        public async Task<EncryptionInformation> GetInfo()
        {
            DsmApiResponse response = await this.ApiContext.Request(
                this.ApiInfo.Path,
                EncryptionApiName,
                this.ApiInfo.MaxVersion,
                "getinfo",
                null);
            var encryptionInfo = JsonConvert.DeserializeObject<EncryptionInformation>(response.Data.ToString());
            return encryptionInfo;
        }
    }
}
