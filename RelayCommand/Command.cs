using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Spreadsheet2JsonConverter.RelayCommand
{
    public class Command : ICommand
    {
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        private bool defaultCanExecute = false;

        public Command(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public Command(Action<object> execute, bool deafultAction = true)
        {
            _execute = execute;
            defaultCanExecute = deafultAction;
        }

        //Sample quality event raising.In production you should be listening to properties
        //that CanExecute relies on and raising CanExecuteChanged as PropertyChanged is raised
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }


        public virtual bool CanExecute(object parameter)
        {
            if (_canExecute != null)
            {
                return _canExecute.Invoke(parameter);
            }
            return defaultCanExecute;
        }

        public virtual void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
