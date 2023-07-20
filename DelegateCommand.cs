﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp
{
    class DelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

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

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute=null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }
        
        public bool CanExecute(object param)
        {
            return this.canExecute == null || this.canExecute(param);
        }

        public void Execute(object param)
        {
            this.execute(param);
        }
    }
}
