using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    class DieTenPercentileModel : DieBaseClass
    {
        #region Constructor
        public DieTenPercentileModel(int dieNumber, int numberOfRolls) : base(dieNumber, numberOfRolls) { }
        #endregion

        #region Die Roll Functions
        /// <summary>
        /// Rolls the die NumberOfRolls times
        /// updates Result and RollLog
        /// </summary>
        public override void Roll()
        {
            for (int i = 0; i < NumberOfRolls; i++)
            {
                int thisRoll = SingleRoll();
                Result += thisRoll;

                if (i == 0)
                {
                    RollLog += thisRoll;
                }
                else
                {
                    RollLog += " + " + thisRoll; 
                }
            }
        }

        /// <summary>
        /// Rolls the percentile die once
        /// </summary>
        /// <returns>10 times a random number between 1 and the DieNumber (inclusive)</returns>
        protected override int SingleRoll()
        {
            // Random number generator for SingleRoll()
            Random _rand = new Random();

            // finds a random number between 1 and 10, then multiplies it by 10
            return 10 * _rand.Next(1, DieNumber + 1);
        }
        #endregion
    }
}
