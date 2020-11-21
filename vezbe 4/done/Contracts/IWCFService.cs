using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Contracts
{
    [ServiceContract]
    public interface IWCFService
    {
        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        Car Read(int key);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        bool Modify(int key, Car car);

        [OperationContract]
        [FaultContract(typeof(SecurityException))]
        bool Delete(int key);
    }
}