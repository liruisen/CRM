using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class VCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper()=="POST")
            {
                string realVCode = Request.Cookies["vCode"].Value;
                string vCode = Request.Form["txtVcode"];
                if (realVCode ==vCode)
                {
                    Response.Write("<script> alert('验证码正确')</script>");
                }
                else
                {
                    Response.Write("<script> alert('验证码不正确')</script>");

                }
            }
        }
    }
}