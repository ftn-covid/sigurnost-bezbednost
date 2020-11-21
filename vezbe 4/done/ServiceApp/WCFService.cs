using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.ServiceModel;
using System.Text;
using System.Threading;
using Contracts;

namespace ServiceApp
{
    public class WCFService : IWCFService
    {
        //[PrincipalPermission(SecurityAction.Demand, Role="Admin")]
        public bool Delete(int key)
        {
            if (Thread.CurrentPrincipal.IsInRole("Admin"))
            {
                return Database.cars.Remove(key);
            }
            else
            {
                string name = Thread.CurrentPrincipal.Identity.Name;
                DateTime time = DateTime.Now;
                string message = String.Format("Access is denied. User {0} try to call Delete method (time : {1}). " +
                    "For this method need to be member of group Admin.", name, time.TimeOfDay);
                throw new FaultException<SecurityException>(new SecurityException(message));
            }
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public bool Modify(int key, Car car)
        {
            if (Thread.CurrentPrincipal.IsInRole("Modify"))
            {
                if (Database.cars.ContainsKey(key))
                {
                    Database.cars[key] = car;
                    return true;
                }
                return false;
            }
            else
            {
                string name = Thread.CurrentPrincipal.Identity.Name;
                DateTime time = DateTime.Now;
                string message = String.Format("Access is denied. User {0} try to call Modify method (time : {1}). " +
                    "For this method need to be member of group Modifier.", name, time.TimeOfDay);
                throw new FaultException<SecurityException>(new SecurityException(message));
            }
        }

        //[PrincipalPermission(SecurityAction.Demand, Role = "Reader")]
        public Car Read(int key)
        {
            //if (Thread.CurrentPrincipal.IsInRole("Reader"))
            //{
            if (Database.cars.ContainsKey(key))
            {
                return Database.cars[key];
            }
            return null;
            //}
            //else
            //{
            //    string name = Thread.CurrentPrincipal.Identity.Name;
            //    DateTime time = DateTime.Now;
            //    string message = String.Format("Access is denied. User {0} try to call Read method (time : {1}). " +
            //        "For this method need to be member of group Reader.", name, time.TimeOfDay);
            //    throw new FaultException<SecurityException>(new SecurityException(message));
            //}
        }
    }
}