using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    class DieModel : DieBaseClass
    {
        public DieModel(int dieNumber, int numberOfRolls) : base(dieNumber, numberOfRolls) { }

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


        /// <summary>
        /// Rolls the die once
        /// </summary>
        /// <returns>A random value between 1 and the DieNumber (inclusive)</returns>
        protected override int SingleRoll()
        {
            // Random number generator for SingleRoll()
            Random _rand = new Random();
            // 1 will always be the minimum number on a die
            return _rand.Next(1, DieNumber + 1);
        }
        #endregion
    }
}
