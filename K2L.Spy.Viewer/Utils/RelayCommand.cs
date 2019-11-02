using System;
using System.Windows.Input;

namespace K2L.Spy.Viewer.Utils
{
    public class RelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;

        public RelayCommand(Action<object> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            try
            {
                return this._canExecute == null || this._canExecute(parameter);
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog(ex.StackTrace);
                return false;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (this._canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        public virtual void Execute(object parameter)
        {
            try
            {
                this._execute(parameter);
            }
            catch (Exception ex)
            {
                Logger.Logger.GetLogger().WriteLog(ex.StackTrace);
            }
        }
    }
}