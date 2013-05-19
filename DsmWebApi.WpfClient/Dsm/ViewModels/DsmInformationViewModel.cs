namespace DsmWebApi.WpfClient.Dsm.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.Dsm;
    using DsmWebApi.WpfClient.ViewModel;

    /// <summary>
    /// The ViewModel of the DSM information API.
    /// </summary>
    internal class DsmInformationViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmInformationViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public DsmInformationViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.DsmInformationApi = new DsmInformationApi(apiContext);
            this.GetInfoCommand = new AsyncRelayCommand(this.GetInfo);
        }

        /// <summary>
        /// Gets the command that gets information about the DSM system.
        /// </summary>
        public ICommand GetInfoCommand { get; private set; }

        /// <summary>
        /// Gets the information about the DSM system.
        /// </summary>
        public DsmInformation DsmInformation { get; private set; }

        /// <summary>
        /// Gets or sets the DSM information API.
        /// </summary>
        private DsmInformationApi DsmInformationApi { get; set; }

        /// <summary>
        /// Gets the information about the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task GetInfo()
        {
            this.DsmInformation = await this.DsmInformationApi.GetInfo();
            this.RaisePropertyChanged(() => this.DsmInformation);
        }
    }
}
