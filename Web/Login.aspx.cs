using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using CRM.BLL;
using CRM.Model;
using CRM.Common;

namespace Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected string failedTips;
        protected string empNo;


        EmployeeBLL empbll = new EmployeeBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper()=="POST")
            {
                string empNo = Request.Form["empNo"];
                string pwd = Request.Form["pwd"];
                string vCode = Request.Form["checkCode"];
                string realCode = Request.Cookies["vCode"].Value;
                if (vCode==realCode)
                {
                    if (empbll.Login(empNo,DEncrypt.Encrypt(pwd))>0)
                    {
                        //1.写入身份到cookie
                        HttpCookie loginCookie = new HttpCookie("empNo", empNo);
                        loginCookie.Expires = DateTime.Now.AddMinutes(10);
                        Response.Cookies.Add(loginCookie);
                        //2.获取登录者的Model，写入session
                        Session["currentEmp"] = empbll.getEmployee(empNo);
                        Response.Redirect("CustomerList.aspx");
                    }
                    else
                    {
                        this.failedTips = "用户名或密码错误！";

                    }
                    //switch (empbll.Login(empNo,DEncrypt.Encrypt(pwd)))
                    //{
                    //    case LoginState.Success:
                    //        Response.Redirect("CustomerList.aspx");
                    //        break;
                    //    case LoginState.PwdWrong:
                    //        this.failedTips = "密码错误！";
                    //        this.empNo = empNo;
                    //        break;
                    //    case LoginState.EmpNotExist:
                    //        this.failedTips = "用户不存在";
                    //        break;
                    //}
                }
                else
                {
                    this.failedTips = "验证码有误！";
                }
            }
        }
    }
}