using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
	[ServiceContract]
	public interface ISecurityService
	{
		[OperationContract]
		void AddUser(string username, string password);

		[OperationContract]
        [FaultContract(typeof(SecurityException))]
		void CreateFile(string fileName);

	}
}
