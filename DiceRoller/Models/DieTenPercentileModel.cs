using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller.Models
{
    class DieTenPercentileModel : DieBaseClass
    {
        public DieTenPercentileModel(int dieNumber, int numberOfRolls) : base(dieNumber, numberOfRolls) { }

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
        /// Rolls the die once
        /// </summary>
        /// <returns>A random value between 10 and the DieNumber (inclusive)</returns>
        protected override int SingleRoll()
        {
            // Random number generator for SingleRoll()
            Random _rand = new Random();

            // 10 is for the percentile die
            // 1 will always be the minimum number on a die
            return 10 * _rand.Next(1, DieNumber + 1);
        }
    }
}
