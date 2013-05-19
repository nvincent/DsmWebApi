namespace DsmWebApi.WpfClient.Dsm.ViewModels
{
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.Dsm.Share;
    using DsmWebApi.WpfClient.ViewModel;

    /// <summary>
    /// The ViewModel of the DSM share API.
    /// </summary>
    internal class DsmShareViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DsmShareViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public DsmShareViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.DsmShareApi = new DsmShareApi(apiContext);
            this.ListCommand = new AsyncRelayCommand(this.List);
        }

        /// <summary>
        /// Gets the command that gets a collection of shares on the DSM system.
        /// </summary>
        public ICommand ListCommand { get; private set; }

        /// <summary>
        /// Gets or sets the offset of the shares collection to query.
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Gets the list of shares on the DSM system.
        /// </summary>
        public DsmShareCollection DsmShareCollection { get; private set; }

        /// <summary>
        /// Gets or sets the DSM share API.
        /// </summary>
        private DsmShareApi DsmShareApi { get; set; }

        /// <summary>
        /// Gets a collection of shares on the DSM system.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task List()
        {
            this.DsmShareCollection = await this.DsmShareApi.List(this.Offset);
            this.RaisePropertyChanged(() => this.DsmShareCollection);
        }
    }
}
