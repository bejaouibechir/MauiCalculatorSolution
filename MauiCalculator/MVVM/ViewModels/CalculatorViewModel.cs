using Dangl.Calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiCalculator.MVVM.ViewModels
{
    public class CalculatorViewModel : ViewModelBase
    {
		private string _formulat;
		public string Formulat
		{
			get { return _formulat; }
			set {
				_formulat = value;
				OnPropertyChanged(nameof(Formulat));
			}
		}

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                _result = value;
                OnPropertyChanged(nameof(Result));
            }
        }

            public ICommand BackspaceCommand => new Command(
            () =>
            {
               if(Formulat.Length>0)
                {
                    Formulat = Formulat.Substring(0, Formulat.Length - 1);
                }
            });

        public ICommand ResetCommand => new Command(
            () =>
            {
                Result = "0";
                Formulat =string.Empty;
            });


        public ICommand OperationCommand => new Command(

            (number) =>
            {
               Formulat += number;
            });


        public ICommand CalculateCommand => new Command(

            () =>
            {
                if (Formulat.Length == 0) return;
                var calculation = Calculator.Calculate(Formulat);
                Result = calculation.Result.ToString();
            });

    }
}
