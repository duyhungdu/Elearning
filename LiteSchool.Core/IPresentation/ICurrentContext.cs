using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;

namespace LiteSchool.Core.IPresentation
{
    public interface ICurrentContext
    {
        string UserId { get; }
        string UserName { get; }
        string Culture { get; }
        bool IsAuthenticated { get; }
        bool IsInRole(string role);
        IList<string> GetRoles();
        ContextMemento CreateMemento();
    }
}
