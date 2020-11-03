using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Principal;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;

namespace SecurityService
{
	public class Program
	{
		static void Main(string[] args)
		{
			NetTcpBinding binding = new NetTcpBinding();
			string address = "net.tcp://localhost:9999/SecurityService";
			
			binding.Security.Mode = SecurityMode.Transport;
			binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
			binding.Security.Transport.ProtectionLevel = ProtectionLevel.EncryptAndSign;

			ServiceHost host = new ServiceHost(typeof(SecurityService));
			host.AddServiceEndpoint(typeof(ISecurityService), binding, address);
			host.Open();
			
			Console.WriteLine($"User that started the server: {WindowsIdentity.GetCurrent().Name}");
			Console.WriteLine("Service host started...");

			Console.ReadLine();
			
		}
	}
}
