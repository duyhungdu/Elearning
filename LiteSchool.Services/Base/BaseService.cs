
using LiteSchool.Core.Messages;
using LiteSchool.Library.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Services
{    
    public abstract class BaseService
    {
        protected ILogger logger;

        public BaseService(ILogger logger)
        {        
            this.logger = logger;
        }   

        protected BaseResponse Run(Action action)
        {
            BaseResponse response = new BaseResponse();
            try
            {
                action();
                response.Success = true;
            }
            catch (Exception ex)
            {
                SetErrorResponse(response, ex);
            }

            return response;
        }

        protected BaseResponse<T> Run<T>(Func<T> func)
        {
            BaseResponse<T> response = new BaseResponse<T>();
            try
            {
                response.Value = func();
                response.Success = true;
            }
            catch (Exception ex)
            {
                SetErrorResponse(response, ex);
            }

            return response;
        }

        protected void SetErrorResponse(BaseResponse response, Exception ex)
        {            
            Guid ticket;
            logger.Log(ex, out ticket);
            response.Success = false;

            #if DEBUG
                     response.ErrorMessage = ex.ToString();                     
            #else
                    response.ErrorMessage = string.Format("An error has occurred. Ticket : {0}", ticket);
            #endif
        }
    }
}
