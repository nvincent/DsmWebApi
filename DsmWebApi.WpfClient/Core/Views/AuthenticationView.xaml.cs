namespace DsmWebApi.WpfClient.Core.Views
{
    using System.Windows;
    using System.Windows.Controls;
    using DsmWebApi.WpfClient.Core.ViewModels;

    /// <summary>
    /// Interaction logic for AuthenticationView.xaml
    /// </summary>
    public partial class AuthenticationView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationView"/> class.
        /// </summary>
        public AuthenticationView()
        {
            this.InitializeComponent();

            this.passwordBox.PasswordChanged += this.PasswordBox_PasswordChanged;
        }

        /// <summary>
        /// Handles the change of the password by updating its value in the ViewModel.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The arguments of the event.</param>
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                ((AuthenticationViewModel)this.DataContext).Password = passwordBox.Password;
            }
        }
    }
}
