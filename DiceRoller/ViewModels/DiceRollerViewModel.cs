﻿using System;
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
using System.ServiceModel;
using RollRecordServiceReference;

namespace DiceRoller.ViewModels
{
    class DiceRollerViewModel : ViewModelBase
    {
        public RollRecordServiceReference.RecordRollsServiceClient _recordService = new RecordRollsServiceClient();

        #region Constructor
        public DiceRollerViewModel()
        {
            ButtonPressCommand = new RelayCommand<string>(ExecuteButtonPressCommand);
            RollDisplay = string.Empty;
            LogDisplay = string.Empty;
            HistoryDisplay = string.Empty;
            WindowWidth = WindowSettings.WINDOW_STANDARD;

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
        // NumberRolls is what displays in the ComboBox,
        // an ObservableCollection of ints from 1 to MAX_ROLLS
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
        // SelectedNumberRolls is the number that has been selected from the ComboBox
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

        #region Window Properties
        private bool _isHistoryOpen;
        // For history display toggle
        // True if history display is open, false if not
        public bool IsHistoryOpen
        {
            get
            {
                return _isHistoryOpen;
            }
            set
            {
                _isHistoryOpen = value;
            }
        }

        private int _windowWidth;
        // Changing this property changes the window width
        public int WindowWidth
        {
            get
            {
                return _windowWidth;
            }
            set
            {
                _windowWidth = value;
                RaisePropertyChanged("WindowWidth");
            }
        }
        #endregion

        #region Roll
        public ICommand ButtonPressCommand { private set; get; }
        /// <summary>
        /// ExecuteButtonPressCommand executes the relevant action when a button is pressed
        /// </summary>
        /// <param name="button">A string representing the button</param>
        private void ExecuteButtonPressCommand(string button)
        {
            if (button == "Clear")
            {
                RollDisplay = string.Empty;
                LogDisplay = string.Empty;
                // return selected rolls to default of 1
                SelectedNumberRolls = 1;
            }
            else if (button == "History")
            {
                // Call service to display history
                HistoryDisplay = _recordService.GetRollRecord();

                if (IsHistoryOpen)
                {
                    WindowWidth = WindowSettings.WINDOW_STANDARD;
                    IsHistoryOpen = false;
                }
                else
                {
                    WindowWidth = WindowSettings.WINDOW_WITH_HISTORY;
                    IsHistoryOpen = true;
                }
            }
            else if (button == "ClearHistory")
            {
                // Call service to clear history
                _recordService.ClearRollRecord();
                HistoryDisplay = _recordService.GetRollRecord();
            }
            else
            {
                // Roll selected die
                if (button == "00")
                {
                    // 10 is the number of the d10 percentile die
                    // it's the only percentile die in a standard dice set so its DieNumber will always be 10
                    DieTenPercentileModel roll = new DieTenPercentileModel(10, SelectedNumberRolls);
                    roll.Roll();
                    RollDisplay = roll.Result.ToString();
                    LogDisplay = roll.RollLog;
                    // TK send roll string to service
                    _recordService.RecordRoll(LogDisplay + System.Environment.NewLine + "   = " + RollDisplay + System.Environment.NewLine);
                }
                else
                {
                    // Check if button is actual a valid die number
                    if (Enum.IsDefined(typeof(StandardDieNumbers), ToInt(button)))
                    {
                        DieStandardModel roll = new DieStandardModel(ToInt(button), SelectedNumberRolls);
                        roll.Roll();
                        RollDisplay = roll.Result.ToString();
                        LogDisplay = roll.RollLog;
                        // TK send roll string to service
                        _recordService.RecordRoll(LogDisplay + System.Environment.NewLine + "   = " + RollDisplay + System.Environment.NewLine);
                    }
                    else
                    {
                        throw new ArgumentException("Parameter is not a valid die number", nameof(button));
                    }
                }

                // update History Display if it's open
                if (IsHistoryOpen)
                {
                    HistoryDisplay = _recordService.GetRollRecord();
                }
            }
        }
        #endregion

        #region Update Displays
        private string _rollDisplay;
        // RollDisplay is a string representing the total value of the current set of rolls
        // ex. if the die was rolled 3 times with values of 4, 3, 7
        // _rollDisplay = "14"
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
        // LogDisplay is a string showing each roll in the current set
        // ex. if the die was rolled 3 times with values of 4, 3, 7
        // _logDisplay = "4 + 3 + 7"
        public string LogDisplay
        {
            get { return _logDisplay; }
            set
            {
                _logDisplay = value;
                RaisePropertyChanged("LogDisplay");
            }
        }

        // TK this is a stand-in for the history that will be implimented with a service
        private string _historyDisplay;
        public string HistoryDisplay
        {
            get { return _historyDisplay; }
            set
            {
                _historyDisplay = _recordService.GetRollRecord();
                RaisePropertyChanged("HistoryDisplay");
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
