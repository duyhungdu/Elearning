using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.IPresentation
{
    public interface ICultureSelectionService
    {
        void LoadOnCurrentThread();
        BaseResponse Save(string culture);
    }
}
