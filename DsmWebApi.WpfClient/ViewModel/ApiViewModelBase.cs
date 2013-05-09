namespace DsmWebApi.WpfClient.ViewModel
{
    using DsmWebApi.Core;
    using GalaSoft.MvvmLight;

    /// <summary>
    /// Base implementation of an API ViewModel.
    /// </summary>
    internal abstract class ApiViewModelBase : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiViewModelBase"/> class.
        /// </summary>
        /// <param name="apiContext">The API context to use.</param>
        protected ApiViewModelBase(IDsmApiContext apiContext)
        {
            this.ApiContext = apiContext;
        }

        /// <summary>
        /// Gets the API context to use.
        /// </summary>
        protected IDsmApiContext ApiContext { get; private set; }
    }
}
