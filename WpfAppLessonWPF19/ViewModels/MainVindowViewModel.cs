using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppLessonWPF19.Models;

namespace WpfAppLessonWPF19.ViewModels
{
    internal class MainVindowViewModel : INotifyPropertyChanged
    {
        private enum FuncEnum
        {
            addition,
            subtraction,
            multiplication,
            division,
            notDefinition
        };
        private FuncEnum funcEnum = FuncEnum.notDefinition;

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();
            }
        }

        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }

        private double number3;
        public double Number3
        {
            get => number3;
            set
            {
                number3 = value;
                OnPropertyChanged();
            }
        }

        private string funcTitle = "Введите действие :";
        public string FuncTitle
        {
            get => funcTitle;
            set
            {
                funcTitle = value;
                OnPropertyChanged();
            }
        }

        public ICommand ResultCommand { get; }

        private void OnResultCommandExecute(object p)
        {
            if (funcEnum == FuncEnum.addition) 
                Number3 = Ariph.Addition(Number1, Number2);
            else
            {
                if (funcEnum == FuncEnum.subtraction) 
                    Number3 = Ariph.Subtraction(Number1, Number2);
                else
                {
                    if (funcEnum == FuncEnum.multiplication) 
                        Number3 = Ariph.Multiplication(Number1, Number2);
                    else
                    {
                        if (funcEnum == FuncEnum.division) 
                            Number3 = Ariph.Division(Number1, Number2);
                    }

                }
            }
        }

        private bool CanResultCommandExecuted(object p)
        {
            if (funcEnum != FuncEnum.notDefinition)
            {
                return true;
            }
            else return false;
        }

        public ICommand AdditionCommand { get; }
        public ICommand SubtractionCommand { get; }
        public ICommand MultiplicationCommand { get; }
        public ICommand DivisionCommand { get; }

        private void OnAdditionCommandExecute(object p)
        {
            funcEnum = FuncEnum.addition;
            FuncTitle = "Число1 + Число2 =";
        }
        private void OnSubtractionCommandExecute(object p)
        {
            funcEnum = FuncEnum.subtraction;
            FuncTitle = "Число1 - Число2 =";
        }
        private void OnMultiplicationCommandExecute(object p)
        {
            funcEnum = FuncEnum.multiplication;
            FuncTitle = "Число1 * Число2 =";
        }
        private void OnDivisionCommandExecute(object p)
        {
            funcEnum = FuncEnum.division;
            FuncTitle = "Число1 / Число2 =";  
        }

        private bool CanOperationCommandExecuted(object p)
        {
            if (funcEnum == FuncEnum.notDefinition)
                return true;
            else return false;
        }
        private bool CanDivisionCommandExecuted(object p)
        {
            if (funcEnum == FuncEnum.notDefinition)
            {
                if (Number2 != 0) return true;
                else return false;
            }
            else return false;
        }

        public ICommand DeliteCommand { get; }

        private void OnDeliteCommandExecute(object p)
        {
            funcEnum = FuncEnum.notDefinition;
            FuncTitle = "Введите действие :";
            Number1 = 0;
            Number2 = 0;
            Number3 = 0;
        }

        private bool CanDeliteCommandExecuted(object p)
        {
            return true;
        }

        public ICommand BackCommand { get; }
        
        private void OnBackCommandExecute(object p)
        {
            funcEnum = FuncEnum.notDefinition;
            FuncTitle = "Введите действие :";
            Number3 = 0;
        }
        private bool CanBackCommandExecuted(object p)
        {
            if (funcEnum != FuncEnum.notDefinition)
                return true;
            else return false;
        }

        public MainVindowViewModel()
        { 
            ResultCommand = new RelayCommsnd(OnResultCommandExecute, CanResultCommandExecuted);

            AdditionCommand = new RelayCommsnd(OnAdditionCommandExecute, CanOperationCommandExecuted);
            SubtractionCommand = new RelayCommsnd(OnSubtractionCommandExecute, CanOperationCommandExecuted);
            MultiplicationCommand = new RelayCommsnd(OnMultiplicationCommandExecute, CanOperationCommandExecuted);
            DivisionCommand = new RelayCommsnd(OnDivisionCommandExecute, CanDivisionCommandExecuted);
            
            BackCommand = new RelayCommsnd(OnBackCommandExecute, CanBackCommandExecuted);

            DeliteCommand = new RelayCommsnd(OnDeliteCommandExecute, CanDeliteCommandExecuted);

        }
    }
}
