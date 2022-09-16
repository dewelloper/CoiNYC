using System;
using System.Runtime.Serialization;

namespace CoiNYC.Core.Data
{
    [Serializable]
    public class BusinessException : Exception, ISerializable
    {
        public BusinessException()
        {


        }
        public BusinessException(string message)
            : base(message)
        {

        }
        public BusinessException(string message, Exception inner)
            : base(message, inner)
        {

        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
