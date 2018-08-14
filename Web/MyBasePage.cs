using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CRM.BLL;

namespace Web
{
    public class MyBasePage:System.Web.UI.Page
    {
        private EmployeeBLL empBll = new EmployeeBLL();
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["empNo"];
            if (cookie == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                string empNo = cookie.Value;
                Session["currentEmp"] = empBll.getEmployee(empNo);
            }
        }
    }
}