
using LiteSchool.Core.IPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LiteSchool.Presentation
{
    public class CookieStorageService : ICookieStorageService
    {
        const string ROOT_COOKIE_NAME = "liteframework";

        public void Save(string key, string value)
        {
            HttpCookie cookie = new HttpCookie(ROOT_COOKIE_NAME);
            cookie.Expires = DateTime.Now.AddYears(1);
            cookie.Values.Add(key, value);
            HttpContext.Current.Response.Cookies.Add(cookie);            
        }

        public string Retrieve(string key)
        {
            HttpCookie rootCookie = HttpContext.Current.Request.Cookies[ROOT_COOKIE_NAME];
            if(rootCookie != null && rootCookie[key] != null)
                return rootCookie[key];
            else
                return null;            
        }
    }
}
