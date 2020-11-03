using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts
{
    [DataContract]
    public class SecurityException
    {
        [DataMember]
        public string Message { get; set; }

        public SecurityException() : this("")
        {
        }

        public SecurityException(string message)
        {
            this.Message = message;
        }
    }
}
