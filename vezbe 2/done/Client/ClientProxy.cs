using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ClientProxy : ChannelFactory<ISecurityService>, ISecurityService, IDisposable
    {
        ISecurityService factory;

        public ClientProxy(NetTcpBinding binding, string address) : base(binding, address)
        {
            this.Credentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Impersonation;
            factory = this.CreateChannel();
        }
        public ClientProxy(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            factory = this.CreateChannel();
            Credentials.Windows.AllowNtlm = false;
        }

        public void AddUser(string username, string password)
        {
            try
            {
                factory.AddUser(username, password);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }

        public void CreateFile(string fileName)
        {
            try
            {
                factory.CreateFile(fileName);
            }
            catch (FaultException<SecurityException> e)
            {
                Console.WriteLine($"Error: {e.Detail.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
    }
}
