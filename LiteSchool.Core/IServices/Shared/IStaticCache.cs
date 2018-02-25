using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.IServices
{
    [ServiceContract()]  
    public interface IStaticCache
    {
        [OperationContract()]
        void InitStaticCache();

        [OperationContract()]
        BaseResponse ResetStaticCache();        
    }
}
