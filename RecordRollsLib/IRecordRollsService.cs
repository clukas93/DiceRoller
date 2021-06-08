using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RecordRollsLib
{
    [ServiceContract]
    public interface IRecordRollsService
    {
        [OperationContract]
        void RecordRoll(string rollStr);

        [OperationContract]
        List<string> GetRollRecord();

        [OperationContract]
        void SaveRollRecord();

        [OperationContract]
        void OpenRecordWindow();
    }
}
