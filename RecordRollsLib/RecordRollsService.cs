using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecordRolls
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    public class RecordRollsService : IRecordRollsService
    {
        private static List<string> _rollList;

        public RecordRollsService()
        {
            _rollList = new List<string> { };
        }


        /// <summary>
        /// Add dice roll representent as a string to _rollList 
        /// </summary>
        /// <param name="rollStr">A dice roll string (ex. "2 + 4 + 1")</param>
        public void RecordRoll(string rollStr)
        {
            _rollList.Add(rollStr);
        }

        /// <summary>
        /// Returns previous rolls
        /// </summary>
        /// <returns>a single concatinated string of previous rolls, delimited by \n</returns>
        public string GetRollRecord()
        {
            string record = string.Empty;

            for(int i = 0; i < _rollList.Count; i++)
            {
                record += _rollList[i] + '\n';
            }
            return record;
        }

        /// <summary>
        /// Saves _rollList in a text file
        /// </summary>
        public void SaveRollRecord()
        {
            // TK to implement
        }

        /// <summary>
        /// Opens a new window to displays all rolls in _rollList
        /// </summary>
        public void OpenRecordWindow()
        {
            // TK to implement
        }
    }
}
