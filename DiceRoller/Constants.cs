using System;
using System.Collections.Generic;
using System.Text;

namespace DiceRoller
{
    public enum DieNumberEnum : int
    {
        TWO = 2,
        FOUR = 4,
        SIX = 6,
        EIGHT = 8,
        TEN = 10,
        TWELVE = 12,
        TWENTY = 20,
        ONE_HUNDRED = 100
    }

    internal static class DiceRollerConstants
    {
        public static int MAX_ROLLS = 10;
    }

    internal static class WindowSettings
    {
        public static int WINDOW_STANDARD = 450;
        public static int WINDOW_WITH_HISTORY = 900;
    }
}
