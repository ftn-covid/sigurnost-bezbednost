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
		Car Read(int key);

		[OperationContract]
		bool Modify(int key, Car car);

		[OperationContract]
		bool Delete(int key);	
	}
}
