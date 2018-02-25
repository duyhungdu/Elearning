using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LiteSchool.Services;
using LiteSchool.Core.IServices;
using LiteSchool.Library.Logging;
using LiteSchool.Dtos;
using LiteSchool.Core.Messages;

namespace LiteSchool.Front.Controllers
{
    public class HomeController : BaseController
    {
        IConfigurationService configurationService;
        public HomeController(ILogger logger, IConfigurationService confgurationService) : base(logger)
        {
            this.configurationService = confgurationService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult FooterTop()
        {
            return PartialView("_FooterTop");
        }

        public PartialViewResult FooterBottom()
        {
            return PartialView("_FooterBottom");
        }
    }
}