using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class EmployeeInfo
    {
        public int Id { get; set; }
        public string EmpNummber { get; set; }
        public string Password { get; set; }

        public static List<EmployeeInfo> TableToList(System.Data.DataTable dt)
        {
            List<EmployeeInfo> empList = new List<EmployeeInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmployeeInfo emp = new EmployeeInfo();
                if (!dt.Rows[i].IsNull("id")) { emp.Id = Convert.ToInt32(dt.Rows[i]["id"]); }
                if (!dt.Rows[i].IsNull("empNo")) { emp.EmpNummber = dt.Rows[i]["empNo"].ToString(); }
                if (!dt.Rows[i].IsNull("pwd")) { emp.Password =dt.Rows[i]["pwd"].ToString(); }

                empList.Add(emp);
            }
            return empList;
        }
    }
}
