using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppLessonWPF19
{
    internal class RelayCommsnd : ICommand  
    {
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public RelayCommsnd(Action<object> Execute, Func<object, bool> CanExecute=null) 
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            canExecute = CanExecute;
        }

        public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true; // ?-проверяет на null (если null - возврацает null), если не null -  возвращает следующий метод invoke. ?? true - вернуть значение, если не null, иначе - вернуть true. 

        public void Execute(object? parameter) => execute(parameter);

    }
}
