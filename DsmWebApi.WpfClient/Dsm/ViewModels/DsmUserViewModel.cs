namespace DsmWebApi.WpfClient.Dsm.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.Dsm.User;
    using DsmWebApi.WpfClient.ViewModel;

    /// <summary>
    /// The ViewModel of the DSM user API.
    /// </summary>
    internal class DsmUserViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmUserViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public DsmUserViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.DsmUserApi = new DsmUserApi(apiContext);
            this.ListCommand = new AsyncRelayCommand(this.List);
        }

        /// <summary>
        /// Gets the command that gets a collection of users on the DSM system.
        /// </summary>
        public ICommand ListCommand { get; private set; }

        /// <summary>
        /// Gets or sets the offset of the users to retrieve in the list of users.
        /// </summary>
        public int? Offset { get; set; }

        /// <summary>
        /// Gets or sets the number of users to retrieve in the list of users.
        /// </summary>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets the list of users on the DSM system.
        /// </summary>
        public DsmUserCollection DsmUserCollection { get; private set; }

        /// <summary>
        /// Gets or sets the DSM user API.
        /// </summary>
        private DsmUserApi DsmUserApi { get; set; }

        /// <summary>
        /// Gets a collection of users on the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task List()
        {
            this.DsmUserCollection = await this.DsmUserApi.List(this.Offset, this.Limit);
            this.RaisePropertyChanged(() => this.DsmUserCollection);
        }
    }
}
