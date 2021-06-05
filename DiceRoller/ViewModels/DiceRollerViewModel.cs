using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Text;
using System.ComponentModel;
using DiceRoller.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace DiceRoller.ViewModels
{
    class DiceRollerViewModel : ViewModelBase
    {
        #region hide
        public DiceRollerViewModel()
        {
            ButtonPressCommand = new RelayCommand<string>(ExecuteButtonPressCommand);
            RollDisplay = string.Empty;
            LogDisplay = string.Empty;

        }

        #endregion


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
            else
            {
                // TK second num is test number of rolls, need to change so user can select
                DieRollModel roll = new DieRollModel(ToInt(button), 3);
                roll.Roll();
                RollDisplay = roll.Result.ToString();
                LogDisplay = roll.RollLog;
            }
        }

        #region hide
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
