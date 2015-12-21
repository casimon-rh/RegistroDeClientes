using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Secure
{
    public class UnImplementedConnectionTypeException : Exception
    {
        private string _message;
        public UnImplementedConnectionTypeException(string s)
        {
            _message = s;
        }


        public Exception GetBaseException()
        {
            return new NotImplementedException();
        }

        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context)
        {
            new NotImplementedException().GetObjectData(info, context);
        }

        public string HelpLink
        {
            get
            {
                return new NotImplementedException().HelpLink;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public Exception InnerException
        {
            get { return new NotImplementedException(); }
        }

        public string Message
        {
            get { return this._message; }
        }

        public string Source
        {
            get
            {
                return new NotImplementedException().Source;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string StackTrace
        {
            get { return new NotImplementedException().StackTrace; }
        }

        public System.Reflection.MethodBase TargetSite
        {
            get { return new NotImplementedException().TargetSite; }
        }
    }
}
