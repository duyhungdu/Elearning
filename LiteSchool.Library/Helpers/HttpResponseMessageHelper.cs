using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LiteSchool.Library.Helpers
{
    public static class HttpResponseMessageHelper
    {
        public static HttpResponseMessage CreatePDFResponse(Stream stream, string fileName)
        {
            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);            
            result.Content = new StreamContent(stream);

            result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/pdf");
            //we used attachment to force download
            result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            result.Content.Headers.ContentDisposition.FileName = fileName;

            return result;
        }
    }
}
