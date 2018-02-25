using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading;
using System.Web;
using LiteSchool.Dtos;
using LiteSchool.Core.IPresentation;
using Microsoft.AspNet.Identity;
using System.Security.Claims;

namespace LiteSchool.Presentation
{    
    public class CurrentContext : ICurrentContext
    {  
        public CurrentContext()
        {                    
        }
                
        public string UserId
        {
            get { return HttpContext.Current.User.Identity.GetUserId(); }
        }
        public string UserName 
        {
            get { return HttpContext.Current.User.Identity.Name; }
        }        
        
        public bool IsAuthenticated
        {
            get { return HttpContext.Current.User.Identity.IsAuthenticated; }
        }

        public string Culture
        {
            get { return Thread.CurrentThread.CurrentCulture.Name; }
        }

        public bool IsInRole(string role)
        {
            return HttpContext.Current.User.IsInRole(role);
        }

        public IList<string> GetRoles()
        {
            var claimsIdentity = (ClaimsIdentity)HttpContext.Current.User.Identity;
            var claims = claimsIdentity.Claims;            
            return claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToList();
        }

        public ContextMemento CreateMemento()
        {
            return new ContextMemento(UserId, Culture, IsAuthenticated, GetRoles() );
        }
    }
}