using Core.ViewModels;
using LiteSchool.Library.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LiteSchool.Front.Controllers
{
    /*http://www.crafted.co.uk/latest/blog/custom-errors-in-asp-net-mvc*/
    public abstract class BaseController : Controller
    {
        protected readonly ILogger logger;

        public BaseController(ILogger logger)
        {        
            this.logger = logger;
        }        

        protected override void OnException(ExceptionContext filterContext)
        {
            if (filterContext == null)
                return;
            
            Guid ticket;
            logger.Log(filterContext.Exception.Message, filterContext.Exception, out ticket);

            var model = new HandleErrorVM();
            model.Ticket = ticket;
            model.ControllerName = filterContext.RouteData.Values["controller"].ToString();
            model.ActionName = filterContext.RouteData.Values["action"].ToString();

            filterContext.Result = View("Error", model);
            filterContext.ExceptionHandled = true;
        }
	}
}