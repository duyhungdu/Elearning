using LiteSchool.Core.IPresentation;
using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.Factories
{
    public class RequestFactory
    {
        private ICurrentContext currentContext;

        public RequestFactory(ICurrentContext currentContext)
        {
            this.currentContext = currentContext;
        }

        public BaseRequest<T> CreateRequest<T>(T value)
        {
            BaseRequest<T> request = new BaseRequest<T>();
            request.Context = currentContext.CreateMemento();
            request.Value = value;
            return request;
        }
    }
}
