using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestTaskCameras.Models
{
    public class RelayCommand<T>: ICommand where T : class
    {
        private Action<T> execute;
        private Func<T, bool> canExecute;

        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(T parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (!(parameter is T))
                return false;

            return this.canExecute == null || this.canExecute(parameter as T);
        }

        public void Execute(T parameter)
        {
            this.execute(parameter);
        }

        public void Execute(object parameter)
        {
            if(parameter is T)
                this.execute(parameter as T);
        }
    }

    public class RelayCommand: ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter = null)
        {
            return this.canExecute == null || this.canExecute();
        }

        public void Execute(object parameter = null)
        {
            this.execute();
        }
    }
}
