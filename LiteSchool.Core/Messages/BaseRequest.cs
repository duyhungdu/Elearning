using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using LiteSchool.Core.IPresentation;

namespace LiteSchool.Core.Messages
{
    /// <summary>
    /// BaseRequest is used to implement the Request-Response pattern.
    /// All methodes in the Service layer should have 1 parameter that inherits from this class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract()]
    public class BaseRequest
    {
        [DataMember()]
        public ContextMemento Context;
    }

    [DataContract()]
    public class BaseRequest<T> : BaseRequest
    {
        public BaseRequest()
        {
        }
    
        public BaseRequest(T value)
        {
            this.Value = value;
        }

        [DataMember()]
        public T Value;       
    }
}
