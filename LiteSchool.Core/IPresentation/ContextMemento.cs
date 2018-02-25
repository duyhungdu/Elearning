using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Core.IPresentation
{
    [DataContract]
    public class ContextMemento
    {
        public ContextMemento(string userId, string culture, bool isAuthenticated, IList<string> roles)
        {
            this._userId = userId;
            this._culture = Culture;
            this._isAuthenticated = isAuthenticated;
            this._roles = roles;
        }

        string _userId;
        [DataMember]
        public string UserId { get { return _userId; } internal set { _userId = value; } }

        string _culture;
        [DataMember]
        public string Culture { get { return _culture; } internal set { _culture = value; } }

        bool _isAuthenticated;
        [DataMember]
        public bool IsAuthenticated { get { return _isAuthenticated; } internal set { _isAuthenticated = value; } }

        IList<string> _roles;
        [DataMember]
        public IList<string> Roles { get { return _roles; } internal set { _roles = value; } }

        public bool IsInRole(string role)
        {
            return Roles.Contains(role);
        }
    }
}
