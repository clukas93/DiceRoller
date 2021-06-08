using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecordRollsLib
{
    public class RecordRollsService : IRecordRollsService
    {
        private List<string> _rollList;

        /// <summary>
        /// Adds rollStr to _rollList
        /// </summary>
        /// <param name="rollStr">The last roll (ex. "2 + 4 + 1")</param>
        public void RecordRoll(string rollStr)
        {
            _rollList.Add(rollStr);
        }

        /// <summary>
        /// Returns list of previous rolls
        /// </summary>
        /// <returns>_rollList</returns>
        public List<string> GetRollRecord()
        {
            return _rollList;
        }

        /// <summary>
        /// Saves _rollList in a text file
        /// </summary>
        public void SaveRollRecord()
        {
            // TK to implement
        }
    }
}
