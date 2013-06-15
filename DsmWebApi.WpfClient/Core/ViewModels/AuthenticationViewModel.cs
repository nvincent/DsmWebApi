namespace DsmWebApi.WpfClient.Core.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.WpfClient.ViewModel;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// The ViewModel of the Authentication API.
    /// </summary>
    internal class AuthenticationViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Storage field of the <see cref="Account"/> property.
        /// </summary>
        private string account;

        /// <summary>
        /// Storage field of the <see cref="Password"/> property.
        /// </summary>
        private string password;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public AuthenticationViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.AuthenticationApi = new AuthenticationApi(apiContext);
            this.LogOnCommand = new AsyncRelayCommand(this.LogOn);
            this.LogOffCommand = new AsyncRelayCommand(this.LogOff);
        }

        /// <summary>
        /// Gets the command that logs on the DSM system.
        /// </summary>
        public ICommand LogOnCommand { get; private set; }

        /// <summary>
        /// Gets the command that logs off the DSM system.
        /// </summary>
        public ICommand LogOffCommand { get; private set; }

        /// <summary>
        /// Gets or sets the name of the account to log on with.
        /// </summary>
        public string Account
        {
            get
            {
                return this.account;
            }

            set
            {
                if (this.account != value)
                {
                    this.account = value;
                    this.RaisePropertyChanged(() => this.Account);
                }
            }
        }

        /// <summary>
        /// Gets or sets the password of the account to log on with.
        /// </summary>
        public string Password
        {
            get
            {
                return this.password;
            }

            set
            {
                if (this.password != value)
                {
                    this.password = value;
                    this.RaisePropertyChanged(() => this.Password);
                }
            }
        }

        /// <summary>
        /// Gets or sets the authentication API.
        /// </summary>
        private AuthenticationApi AuthenticationApi { get; set; }

        /// <summary>
        /// Logs on the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task LogOn()
        {
            var authenticationInformation = await this.AuthenticationApi.LogOn(this.Account, this.Password);
            NotificationMessage message = new NotificationMessage("Logged On as " + this.Account + " with SID = " + authenticationInformation.SID);
            Messenger.Default.Send(message);
        }

        /// <summary>
        /// Logs off the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task LogOff()
        {
            await this.AuthenticationApi.LogOff();
            NotificationMessage message = new NotificationMessage("Logged Off");
            Messenger.Default.Send(message);
        }
    }
}
