using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
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


			EndpointAddress endpointAddress = new EndpointAddress(new Uri(address), EndpointIdentity.CreateUpnIdentity("wcfserver"));
			using (ClientProxy proxy = new ClientProxy(binding, address)) // won't work for us if we provided endpointAddress becouse we don't have a domain set up
			{
				Console.WriteLine($"Client name: {WindowsIdentity.GetCurrent().Name}");
				proxy.AddUser("testUser", "testpass");
				//	proxy.AddUser("testUser", "testpass");
				proxy.CreateFile("testFile");
			}

			Console.ReadLine();
		}
	}
}
