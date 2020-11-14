using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using Manager;
using System.Security.Cryptography.X509Certificates;

namespace ServiceApp
{
	public class WCFService : IWCFContract
	{
		public void TestCommunication()
		{
			Console.WriteLine("Communication established.");
		}

	}
}
