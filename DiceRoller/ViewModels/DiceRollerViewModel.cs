﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Text;
using System.ComponentModel;
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
            int x = 2;
            if(x == 2)
            {
                Title = "X is 2";
            }
            else
            {
                Title = "X is not 2";
            }
        }

        public string Title { get; set; }
        #endregion


        public ICommand ButtonPressCommand { private set; get; }
        private void ExecuteButtonPressCommand(string button)
        {
            if (button == "Clear")
            {
                RollDisplay = string.Empty;
            }
            else if (button == "Log")
            {
                // Here is where the log box would pop up
            }
            else
            {
                RollDisplay = button;
            }
        }

        /*
        RelayCommand _testCommand;
        public ICommand TestCommand
        {
            get
            {
                if (_testCommand == null)
                {
                    _testCommand = new RelayCommand(
                        param => ExecuteButtonPressCommand(),
                        param => 1);
                }
                return _testCommand;
            }
        }
        //ButtonPressCommand = new RelayCommand(ExecuteButtonPressCommand);
        public ICommand ButtonPressCommand
        {
            private set; get;
        }

        private void ExecuteButtonPressCommand()
        {

        }
        */
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

        public void FindRollDisplay(string button)
        {

        }
        #endregion
    }
}
