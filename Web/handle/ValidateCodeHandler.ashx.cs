using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.Common;

namespace Web
{
    /// <summary>
    /// ValidateCodeHandler 的摘要说明
    /// </summary>
    public class ValidateCodeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            ValidateCode vs = new ValidateCode(context);
            string code=vs.GetCode(4);
            vs.CreateValidateImage(code, 70, 32);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}