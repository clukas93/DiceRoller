using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Text;
using System.ComponentModel;
using System.Collections;
using DiceRoller.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;

namespace DiceRoller.ViewModels
{
    class DiceRollerViewModel : ViewModelBase
    {
        #region Constructor
        public DiceRollerViewModel()
        {
            ButtonPressCommand = new RelayCommand<string>(ExecuteButtonPressCommand);
            RollDisplay = string.Empty;
            LogDisplay = string.Empty;

            // 1 is the default number of rolls
            SelectedNumberRolls = 1;
            NumberRolls = new ObservableCollection<int>();
            for(int i = 1; i <= DiceRollerConstants.MAX_ROLLS; i++)
            {
                NumberRolls.Add(i);
            }
        }

        #endregion

        #region Change Number of Rolls (combobox)
        private ObservableCollection<int> _numberRolls;
        public ObservableCollection<int> NumberRolls
        {
            get 
            {
                return _numberRolls;
            }
            set
            {
                _numberRolls = value;
            }
        }

        private int _selectedNumberRolls;
        public int SelectedNumberRolls
        {
            get
            {
                return _selectedNumberRolls;
            }
            set
            {
                _selectedNumberRolls = value;
                RaisePropertyChanged("SelectedNumberRolls");
            }
        }
        #endregion

        #region Roll
        public ICommand ButtonPressCommand { private set; get; }
        private void ExecuteButtonPressCommand(string button)
        {
            if (button == "Clear")
            {
                RollDisplay = string.Empty;
                LogDisplay = string.Empty; 
            }
            else if (button == "Log")
            {
                // Here is where the log box would pop up 
            }
            else if (button == "00")
            {
                // 10 is the number of the d10 percentile die
                // it's the only percentile die in a standard dice set so it will always be 10
                // TK second num is test number of rolls, need to change so user can select
                DieTenPercentileModel roll = new DieTenPercentileModel(10, 3);
                roll.Roll();
                RollDisplay = roll.Result.ToString();
                LogDisplay = roll.RollLog;
            }
            else
            {
                // TK second num is test number of rolls, need to change so user can select
                DieModel roll = new DieModel(ToInt(button), SelectedNumberRolls);
                roll.Roll();
                RollDisplay = roll.Result.ToString();
                LogDisplay = roll.RollLog;
            }
        }
        #endregion

        #region Update Displays
        private string _rollDisplay;
        public string RollDisplay
        {
            get { return _rollDisplay; }
            set
            {
                _rollDisplay = value;
                RaisePropertyChanged("RollDisplay");
            }
        }

        private string _logDisplay;
        public string LogDisplay
        {
            get { return _logDisplay; }
            set
            {
                _logDisplay = value;
                RaisePropertyChanged("LogDisplay");
            }
        }
        #endregion

        #region Private Helpers
        /// <summary>
        /// Converts a string to int32
        /// </summary>
        /// <param name="str">a string to convert</param>
        /// <returns>the string converted to an int</returns>
        private int ToInt(string str)
        {
            bool isParsable = Int32.TryParse(str, out int number);

            if (isParsable)
            {
                return number;
            }
            else
            {
                throw new ArgumentException("Parameter cannot be parsed to int", nameof(str));
            }
        }
        #endregion
    }
}
