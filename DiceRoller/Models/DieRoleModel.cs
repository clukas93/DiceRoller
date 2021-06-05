﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    class DieRollModel
    {
        #region Die & Roll Information
        /// <summary>
        /// DieNumber is the number of the die being rolled (ex. 10 for a d10)
        /// </summary>
        private int _dieNumber;
        public int DieNumber 
        {
            get
            {
                return _dieNumber;
            }
            set
            {
                _dieNumber = value;
            }
        }

        /// <summary>
        /// NumberOfRolls is how many times this die is being rolled
        /// </summary>
        private int _numberOfRolls;
        public int NumberOfRolls
        {
            get
            {
                return _numberOfRolls;
            }
            set
            {
                _numberOfRolls = value;
            }
        }

        private int _result;
        public int Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }

        /// <summary>
        /// RollLog contains a string recording each roll in the current instance
        /// ex. if a d6 is rolled 3 times, and the results are 4, 2, 5
        /// _rollLog = "4 + 2 + 5"
        /// </summary>
        private string _rollLog;
        public string RollLog
        {
            get
            {
                return _rollLog;
            }
            set
            {
                _rollLog = value;
            }
        }
        #endregion

        #region Constructor
        public DieRollModel(int dieNumber, int numberOfRolls)
        {
            DieNumber = dieNumber;
            NumberOfRolls = numberOfRolls;
            Result = 0;
            RollLog = string.Empty;
        }
        #endregion

        #region Die Roll Functions
        /// <summary>
        /// Rolls the die NumberOfRolls times
        /// updates Result and RollLog
        /// </summary>
        public void Roll()
        {
            for (int i = 0; i < NumberOfRolls; i++)
            {
                int thisRoll = SingleRoll();
                Result += thisRoll;

                if(i == 0)
                {
                    RollLog += thisRoll;
                }
                else
                {
                    RollLog += " + " + thisRoll;
                }
            }
        }

        // Random number generator for SingleRoll()
        private readonly Random _rand = new Random();

        /// <summary>
        /// Rolls the die once
        /// </summary>
        /// <returns>A random value between 1 and the DieNumber (inclusive)</returns>
        private int SingleRoll()
        {
            // 1 will always be the minimum number on a die
            return _rand.Next(1, DieNumber + 1);
        }
        #endregion
    }
}
