﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UsingWPF.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            if (execute == null)

                throw new ArgumentNullException("execute");
            _execute = execute;
            //_canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if(execute == null)
           
                throw new ArgumentNullException("execute");
                _execute = execute;
                _canExecute = canExecute;
           
        }        
        public bool CanExecute(object parameters)
        {
            return _canExecute == null ? true : _canExecute(parameters);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        public event EventHandler? CanExecuteChanged;
    }
}
