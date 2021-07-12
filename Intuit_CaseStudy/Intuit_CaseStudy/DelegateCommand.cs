using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Intuit_CaseStudy
{
    public class DelegateCommand:ICommand
    {
        //Delegates
        private Action<object> _executeMethodRef;
        private Func<object, bool> _canExecuteMethodRef;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        /// <summary>
        /// DelegateCommand
        /// </summary>
        /// <param name="executeMethodRef">Action to be performed </param>
        /// <param name="canExecuteMethodRef">function need to be executed </param>
        public DelegateCommand(Action<object> executeMethodRef, Func<object, bool> canExecuteMethodRef)
        {
            this._executeMethodRef = executeMethodRef;
            this._canExecuteMethodRef = canExecuteMethodRef;
        }
        public bool CanExecute(object parameter)
        {
            return this._canExecuteMethodRef.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            this._executeMethodRef.Invoke(parameter);
        }
    }
}
