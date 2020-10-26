using ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SecurityService
{
	public class SecurityService : ISecurityService
	{
		public static Dictionary<string, User> UserAccountsDB = new Dictionary<string, User>();

		/// <summary>
		/// Add new user to UserAccountsDB. Dictionary Key is "username"
		/// </summary>
		public void AddUser(string username, string password)
		{
			if(!UserAccountsDB.ContainsKey(username))
            {
				UserAccountsDB.Add(username, new User(username, password));
            }
			else
            {
				Console.WriteLine($"User with username \"{username}\" already exists");
            }

			IIdentity identity = Thread.CurrentPrincipal.Identity;
			Console.WriteLine($"Authentication type: {identity.AuthenticationType}");

			WindowsIdentity windowsIdentity = identity as WindowsIdentity;

			Console.WriteLine($"Client's name who called the method: {windowsIdentity.Name}");
			Console.WriteLine($"Unique identifier: {windowsIdentity.User}"); //	SI

			Console.WriteLine("Groups of the user: ");
			foreach(var group in windowsIdentity.Groups)
            {
				SecurityIdentifier si = group.Translate(typeof(SecurityIdentifier)) as SecurityIdentifier;
				string name = si.Translate(typeof(NTAccount)).ToString();
				Console.WriteLine(name);
            }
		}

	}
}
