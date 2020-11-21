using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Contracts;

namespace ServiceApp
{
    public class WCFService : IWCFService
    {
        public bool Delete(int key)
        {
            throw new NotImplementedException();
        }

        public bool Modify(int key, Car car)
        {
            throw new NotImplementedException();
        }

        public Car Read(int key)
        {
            throw new NotImplementedException();
        }
    }
}
