namespace DsmWebApi.WpfClient.Dsm.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.Dsm;
    using DsmWebApi.WpfClient.ViewModel;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// The ViewModel of the DSM system API.
    /// </summary>
    internal class DsmSystemViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmSystemViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public DsmSystemViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.DsmSystemApi = new DsmSystemApi(apiContext);
            this.RebootCommand = new AsyncRelayCommand(this.Reboot);
            this.ShutdownCommand = new AsyncRelayCommand(this.Shutdown);
            this.PingPongCommand = new AsyncRelayCommand(this.PingPong);
        }

        /// <summary>
        /// Gets the command that reboots the DSM system.
        /// </summary>
        public ICommand RebootCommand { get; private set; }

        /// <summary>
        /// Gets the command that shutdowns the DSM system.
        /// </summary>
        public ICommand ShutdownCommand { get; private set; }

        /// <summary>
        /// Gets the command that pings the DSM system.
        /// </summary>
        public ICommand PingPongCommand { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the boot sequence of the DSM system is over.
        /// A null value indicates that the state of the DSM system is unknown.
        /// </summary>
        public bool? BootDone { get; private set; }

        /// <summary>
        /// Gets or sets the DSM system API.
        /// </summary>
        private DsmSystemApi DsmSystemApi { get; set; }

        /// <summary>
        /// Reboots the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task Reboot()
        {
            var rebootResponse = await this.DsmSystemApi.Reboot();
            GenericMessage<DsmApiResponse> message = new GenericMessage<DsmApiResponse>(rebootResponse);
            Messenger.Default.Send(message);
        }

        /// <summary>
        /// Shutdowns the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task Shutdown()
        {
            var shutdownResponse = await this.DsmSystemApi.Shutdown();
            GenericMessage<DsmApiResponse> message = new GenericMessage<DsmApiResponse>(shutdownResponse);
            Messenger.Default.Send(message);
        }

        /// <summary>
        /// Pings the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task PingPong()
        {
            this.BootDone = await this.DsmSystemApi.PingPong();
            this.RaisePropertyChanged(() => this.BootDone);
        }
    }
}
