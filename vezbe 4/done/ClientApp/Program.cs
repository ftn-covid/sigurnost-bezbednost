using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Contracts;

namespace ClientApp
{
	public class Program
	{
		static void Main(string[] args)
		{
			NetTcpBinding binding = new NetTcpBinding();
			string address = "net.tcp://localhost:9999/WCFService";

			using (WCFClient proxy = new WCFClient(binding, new EndpointAddress(new Uri(address))))
			{
				Car car = proxy.Read(1);
				Console.WriteLine(car);

				car = new Car(Brand.Audi, "Q3", 2014, 68);
				proxy.Modify(1, car);

				car = proxy.Read(1);
				Console.WriteLine(car);

				proxy.Delete(1);
				car = proxy.Read(1);
				Console.WriteLine(car);

			}

			Console.ReadLine();

		}
	}
}
