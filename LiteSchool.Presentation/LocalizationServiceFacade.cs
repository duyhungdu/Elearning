using LiteSchool.Core.IPresentation;
using LiteSchool.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Presentation
{
    public class LocalizationServiceFacade : ILocalizationServiceFacade
    {
        ICurrentContext CurrentContext;
        //ILocalizationService LocalizationService;

        public LocalizationServiceFacade(ICurrentContext CurrentContext)//, ILocalizationService LocalizationService)
        {
            this.CurrentContext = CurrentContext;
           // this.LocalizationService = LocalizationService;
        }

        public string Get(string name)
        {
            return "";// LocalizationService.Get(CurrentContext.Culture, name).Value;
        }
    }
}
