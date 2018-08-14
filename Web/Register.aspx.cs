using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRM.BLL;
using CRM.Model;
using CRM.Common;
namespace Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected string EmpNo;
        protected string codeWrong;
        protected string pwdWrong;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper()=="POST")
            {
                string code = Request.Form["vCode"];
                string empNo = Request.Form["empNo"];
                string pwd = Request.Form["empPwd"];
                string pwds = Request.Form["empPwds"];
                string cookieCode = Request.Cookies["vCode"].Value;
                if (code==cookieCode)
                {
                    
                    if (pwd==pwds)
                    {
                        EmployeeBLL empBll = new EmployeeBLL();
                        switch (empBll.Register(empNo, pwd))
                        {
                            case RegState.Success:
                                Response.Write("<script>alert('注册成功，请登录！');window.location='Login.aspx';</script>");
                                break;
                            case RegState.Failed:
                                Response.Write("<script>alert('注册失败');window.location='Register.aspx';</script>");
                                this.EmpNo = empNo;
                                break;
                            case RegState.EnpNumberExists:
                                Response.Write("<script>alert('注册失败');window.location='Register.aspx';</script>");
                                this.EmpNo = empNo;
                                break;
                            default:
                                Response.Write("<script>alert('注册失败');window.location='Register.aspx';</script>");
                                this.EmpNo = empNo;
                                break;


                        }
                    }
                    else
                    {
                        this.EmpNo = empNo;

                        this.pwdWrong = "两次密码不一致";
                    }
                }
                else
                {
                    this.EmpNo = empNo;

                    this.codeWrong = "验证码有误，请重试";
                }
            }
        }
    }
}