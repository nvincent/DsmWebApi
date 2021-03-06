namespace DsmWebApi.WpfClient.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using DsmWebApi.Core;
    using DsmWebApi.WpfClient.Core.ViewModels;
    using DsmWebApi.WpfClient.Dsm.ViewModels;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// </summary>
    internal class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Storage field of the <see cref="WebApiBaseUri"/> property.
        /// </summary>
        private string webApiBaseUri;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        public MainViewModel()
        {
            Messenger.Default.Register<GenericMessage<DsmApiResponse>>(this, this.ProcessApiResponse);
            Messenger.Default.Register<NotificationMessage>(this, this.ProcessNotification);

            this.LoadApiContextCommand = new AsyncRelayCommand(() => Task.Run(() => this.LoadApiContext()));
            this.LastApiResponses = new ObservableCollection<DsmApiResponse>();

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

        /// <summary>
        /// Gets the command that loads the API context.
        /// </summary>
        public ICommand LoadApiContextCommand { get; private set; }

        /// <summary>
        /// Gets or sets the base URI of the Web API.
        /// </summary>
        public string WebApiBaseUri
        {
            get
            {
                return this.webApiBaseUri;
            }

            set
            {
                if (this.webApiBaseUri != value)
                {
                    this.webApiBaseUri = value;
                    this.RaisePropertyChanged(() => this.WebApiBaseUri);
                }
            }
        }

        /// <summary>
        /// Gets the list of the last API responses received.
        /// </summary>
        public ObservableCollection<DsmApiResponse> LastApiResponses { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the API context is loaded.
        /// </summary>
        public bool IsApiContextLoaded { get; private set; }

        #region Core APIs ViewModels

        /// <summary>
        /// Gets the authentication API ViewModel.
        /// </summary>
        public AuthenticationViewModel AuthenticationViewModel { get; private set; }

        /// <summary>
        /// Gets the encryption API ViewModel.
        /// </summary>
        public EncryptionViewModel EncryptionViewModel { get; private set; }

        /// <summary>
        /// Gets the information API ViewModel.
        /// </summary>
        public InformationViewModel InformationViewModel { get; private set; }

        #endregion

        #region DSM APIs ViewModels

        /// <summary>
        /// Gets the DSM information API ViewModel.
        /// </summary>
        public DsmInformationViewModel DsmInformationViewModel { get; private set; }

        /// <summary>
        /// Gets the DSM share API ViewModel.
        /// </summary>
        public DsmShareViewModel DsmShareViewModel { get; private set; }

        /// <summary>
        /// Gets the DSM system API ViewModel.
        /// </summary>
        public DsmSystemViewModel DsmSystemViewModel { get; private set; }

        /// <summary>
        /// Gets the DSM user API ViewModel.
        /// </summary>
        public DsmUserViewModel DsmUserViewModel { get; private set; }

        #endregion

        /// <summary>
        /// Gets or sets the context used to access the DSM API.
        /// </summary>
        private IDsmApiContext ApiContext { get; set; }

        /// <summary>
        /// Loads the API context.
        /// </summary>
        private async void LoadApiContext()
        {
            this.ApiContext = new DsmWebApiContext(new Uri(this.WebApiBaseUri));
            await this.ApiContext.LoadAllApiInfo();

            this.AuthenticationViewModel = new AuthenticationViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.AuthenticationViewModel);
            this.EncryptionViewModel = new EncryptionViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.EncryptionViewModel);
            this.InformationViewModel = new InformationViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.InformationViewModel);

            this.DsmInformationViewModel = new DsmInformationViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.DsmInformationViewModel);
            this.DsmShareViewModel = new DsmShareViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.DsmShareViewModel);
            this.DsmSystemViewModel = new DsmSystemViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.DsmSystemViewModel);
            this.DsmUserViewModel = new DsmUserViewModel(this.ApiContext);
            this.RaisePropertyChanged(() => this.DsmUserViewModel);

            this.IsApiContextLoaded = true;
            this.RaisePropertyChanged(() => this.IsApiContextLoaded);
        }

        /// <summary>
        /// Processes an API response.
        /// </summary>
        /// <param name="apiResponseMessage">The message containing the API response to process.</param>
        private void ProcessApiResponse(GenericMessage<DsmApiResponse> apiResponseMessage)
        {
            var apiResponse = apiResponseMessage.Content;
            this.LastApiResponses.Add(apiResponse);
        }

        /// <summary>
        /// Processes a notification message.
        /// </summary>
        /// <param name="notificationMessage">The notification message to process.</param>
        private void ProcessNotification(NotificationMessage notificationMessage)
        {
        }
    }
}
