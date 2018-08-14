using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CRM.Model;
using CRM.BLL;
using System.Text;
using CRM.Common;

namespace Web
{
    public partial class CustomerList : MyBasePage
    {
        protected string ctmTrs = null;
        protected string pageLink = null;
        CustomerBLL ctmBll = new CustomerBLL();
        protected override void Page_Load(object sender, EventArgs e)
        {
            //调用基类的Page_Load方法去检测cookie
            base.Page_Load(sender, e);

            //以下写自己的逻辑
            //分页加载用户信息
            //1.获取当前登录帐号的Id
            EmployeeInfo currentEmp = Session["currentEmp"] as EmployeeInfo;
            if (currentEmp != null)
            {
                int empId = currentEmp.Id;
                //2.把当前的用户信息从数据库加载到页面上
                //  2.1每页显示记录条数，当前页码：这两个数据从QueryString获取
                //  2.2如果获取不到，就默认当前页码是第一页

                int pageSize = Request.QueryString["pageSize"] == null ? 8 : int.Parse(Request.QueryString["pageSize"]);
                int currentPage = Request.QueryString["currentPage"] == null ? 1 : int.Parse(Request.QueryString["currentPage"]);
                int totalPages = 0;

                List<CustomerInfo> ctmList = ctmBll.GetCustomersByPage(empId, pageSize, currentPage, ref totalPages);
                StringBuilder sbTrs = new StringBuilder();
                for (int i = 0; i < ctmList.Count; i++)
                {
                    string gender = ctmList[i].Gender == true ? "男" : "女";
                    sbTrs.Append("<tr>");
                    sbTrs.Append("<td>" + ctmList[i].Id + "</td>");
                    sbTrs.Append("<td>" + ctmList[i].Name + "</td>");
                    sbTrs.Append("<td>" + gender + "</td>");
                    sbTrs.Append("<td>" + ctmList[i].Address + "</td>");
                    sbTrs.Append("<td>" + ctmList[i].Company + "</td>");
                    sbTrs.Append("<td>" + ctmList[i].Phone + "</td>");
                    sbTrs.Append("<td><a href='Customer.aspx?Id=" + ctmList[i].Id + "'class='btn btn-default'>详细信息</a></td>");
                    sbTrs.Append("</tr>");
                }
                this.ctmTrs = sbTrs.ToString();


                //3.成分页导航条
                //  3.1每页显示记录条数，当前页码，总记录条数（从步骤2得到）
                //PageNavigator.CreatPageNavigator

                pageLink = PageNavigator.CreatPageNavigator(pageSize, currentPage, totalPages, "CustomerList.aspx", 2);


            }

           

        

        }
    }
}