using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecordRolls
{
    [ServiceContract]
    public interface IRecordRollsService
    {
        [OperationContract]
        void RecordRoll(string rollStr);

        [OperationContract]
        string GetRollRecord();

        [OperationContract]
        void SaveRollRecord();
    }
}
