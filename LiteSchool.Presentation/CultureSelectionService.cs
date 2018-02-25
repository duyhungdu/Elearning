using LiteSchool.Core.IPresentation;
using LiteSchool.Core.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace LiteSchool.Presentation
{
    public class CultureSelectionService : ICultureSelectionService
    {
        const string COOKIE_NAME = "culture";
        const string DEFAULT_CULTURE = "en-GB";

        ICookieStorageService CookieStorageService;
        public CultureSelectionService(ICookieStorageService CookieStorageService)
        {
            this.CookieStorageService  = CookieStorageService;
        }

        public void LoadOnCurrentThread()
        {
            CultureInfo ci;
            var cultureCookie = CookieStorageService.Retrieve(COOKIE_NAME);
            if (cultureCookie != null)
                ci = new CultureInfo(cultureCookie);
            else
                ci = new CultureInfo(DEFAULT_CULTURE);

            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = ci;
        }

        public BaseResponse Save(string culture)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                CookieStorageService.Save(COOKIE_NAME, culture);
                response.Success = true;
            }
            catch (Exception)
            {
                response.Success = false;
            }
            
            return response;
        }
    }
}
