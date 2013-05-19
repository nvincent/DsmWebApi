namespace DsmWebApi.WpfClient.Core.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.WpfClient.ViewModel;

    /// <summary>
    /// The ViewModel of the Encryption API.
    /// </summary>
    internal class EncryptionViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EncryptionViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public EncryptionViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.EncryptionApi = new EncryptionApi(this.ApiContext);
            this.GetInfoCommand = new AsyncRelayCommand(this.GetInfo);
        }

        /// <summary>
        /// Gets the command that gets the information about the encryption.
        /// </summary>
        public ICommand GetInfoCommand { get; private set; }

        /// <summary>
        /// Gets the encryption information.
        /// </summary>
        public EncryptionInformation EncryptionInformation { get; private set; }

        /// <summary>
        /// Gets or sets the encryption API.
        /// </summary>
        private EncryptionApi EncryptionApi { get; set; }

        /// <summary>
        /// Gets the information about the encryption.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task GetInfo()
        {
            this.EncryptionInformation = await this.EncryptionApi.GetInfo();
            this.RaisePropertyChanged(() => this.EncryptionInformation);
        }
    }
}
