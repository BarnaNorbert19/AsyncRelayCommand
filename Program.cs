using System.Windows.Input;

public class AsyncRelayCommand : ICommand
    {
        private readonly Func<object, Task> _execute;
        private readonly Predicate<object> _canExecute;

        public AsyncRelayCommand(Func<object, Task> execute, Predicate<object> canExecute)
        {
            if (execute is null) throw new ArgumentNullException(nameof(execute));

            _execute = execute;
            _canExecute = canExecute;
        }

        public AsyncRelayCommand(Func<object, Task> execute) : this(execute, null)
        { }

        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            try
            {
                await _execute.Invoke(parameter);
            }
            catch (Exception ex)
            {
                if (ex.Message != "A task was canceled.")
                    throw;
            }
        }
    }
