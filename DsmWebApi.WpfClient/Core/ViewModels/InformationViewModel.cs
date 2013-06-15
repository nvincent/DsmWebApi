namespace DsmWebApi.WpfClient.Core.ViewModels
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.WpfClient.ViewModel;

    /// <summary>
    /// The ViewModel of the Information API.
    /// </summary>
    internal class InformationViewModel : ApiViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationViewModel"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        public InformationViewModel(IDsmApiContext apiContext)
            : base(apiContext)
        {
            this.InformationApi = new InformationApi(this.ApiContext);
            this.QueryAllCommand = new AsyncRelayCommand(this.QueryAll);
        }

        /// <summary>
        /// Gets the command that gets the information about all available APIs.
        /// </summary>
        public ICommand QueryAllCommand { get; private set; }

        /// <summary>
        /// Gets the information about all available APIs.
        /// </summary>
        public IDictionary<string, DsmApiInfo> AllApiInfo { get; private set; }

        /// <summary>
        /// Gets or sets the information API.
        /// </summary>
        private InformationApi InformationApi { get; set; }

        /// <summary>
        /// Gets the information about all available APIs.
        /// </summary>
        /// <returns>The task to await.</returns>
        private async Task QueryAll()
        {
            this.AllApiInfo = await this.InformationApi.QueryAll();
            this.RaisePropertyChanged(() => this.AllApiInfo);
        }
    }
}
