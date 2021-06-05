using System;
using System.Collections.Generic;
using System.Text;
using DiceRoller.Models;

namespace DiceRoller
{
    class Test
    {
        public static void RunTest()
        {
            DieRollModel diceTest = new DieRollModel(5, 3);
            diceTest.Roll();
            Console.WriteLine("Result = " + diceTest.Result);
            Console.WriteLine("RoleLog = " + diceTest.RollLog);
        }
    }
}
