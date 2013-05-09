namespace DsmWebApi.WpfClient
{
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// Command that executes asynchronously and that cannot be executed again while it is still executing.
    /// </summary>
    internal class AsyncRelayCommand : ICommand
    {
        /// <summary>
        /// The asynchronous action to execute.
        /// </summary>
        private Action execute;

        /// <summary>
        /// The method that determines whether the command can execute in its current state.
        /// </summary>
        private Func<bool> canExecute;

        /// <summary>
        /// Indicates whether the command is being executed.
        /// </summary>
        private bool executing;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRelayCommand"/> class that can always execute.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="execute"/> argument is null.</exception>
        public AsyncRelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncRelayCommand"/> class.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        /// <exception cref="ArgumentNullException">If the <paramref name="execute"/> argument is null.</exception>
        public AsyncRelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            this.execute = async () => await Task.Run(execute).ContinueWith(t => this.EndExecute());
            if (canExecute == null)
            {
                this.canExecute = () => true;
            }
            else
            {
                this.canExecute = canExecute;
            }
        }

        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">This parameter will always be ignored.</param>
        /// <returns>true if this command can be executed and is not already being executed; otherwise, false.</returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute() && !this.executing;
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">This parameter will always be ignored.</param>
        public virtual void Execute(object parameter)
        {
            this.executing = true;
            this.RaiseCanExecuteChanged();
            this.execute();
        }

        /// <summary>
        /// Raises the <see cref="CanExecuteChanged"/> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var handler = this.CanExecuteChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        /// <summary>
        /// Ends the execution of the command.
        /// </summary>
        private void EndExecute()
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                this.executing = false;
                this.RaiseCanExecuteChanged();
            });
        }
    }
}
