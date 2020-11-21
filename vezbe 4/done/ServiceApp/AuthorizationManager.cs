using System.Security.Principal;
using System.ServiceModel;

namespace ServiceApp
{
    internal class AuthorizationManager : ServiceAuthorizationManager
    {
        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            WindowsIdentity identity = operationContext.ServiceSecurityContext.WindowsIdentity;
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole("Reader");
        }
    }
}