using LiteSchool.Entities;
using LiteSchool.Core.Messages;
using LiteSchool.Core.Queries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.IServices
{
    [ServiceContract()]
    public interface ILogService : IStaticCache
    {

    }
}
