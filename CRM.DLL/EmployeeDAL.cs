using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CRM.DBUtility;
using CRM.Model;
using CRM.Common;

namespace CRM.DLL
{
    public class EmployeeDAL
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="empNo">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>登录结果，0：密码错误，-1用户不存在，1成功</returns>
        public int Validate(string empNo, string pwd)
        {
            string sql = "up_Validate";
            SqlParameter spEmpNo = new SqlParameter("@empNo", empNo);

            string encryptedPwd = DEncrypt.Encrypt(pwd);
            SqlParameter spPwd = new SqlParameter("@pwd", encryptedPwd);
            return DBHelper.ExcuteNonQuery(sql, CommandType.StoredProcedure, spEmpNo, spPwd);
        }
        public int Validate(EmployeeInfo emp)
        {
            return this.Validate(emp.EmpNummber, emp.Password);
        }
        public EmployeeInfo getEmployee(string empNo, string pwd)
        {
            string sql = "select id,empNo,pwd from Employees where empNo=@empno and pwd=@emppwd ";
            SqlParameter spNo = new SqlParameter("@empno", SqlDbType.NVarChar) { Value = empNo };
            SqlParameter spPwd = new SqlParameter("@emppwd", SqlDbType.VarChar) { Value = pwd };

           List<EmployeeInfo> empList= EmployeeInfo.TableToList(DBHelper.GetDataSet(sql, CommandType.Text, spNo, spPwd).Tables[0]);

           if (empList.Count>0)
           {
               return empList[0];
           }
           else
           {
               return null;
           }
        }

        public EmployeeInfo getEmployee(string empNo)
        {
            string sql = "select id,empNo,pwd from Employees where empNo=@empno";
            SqlParameter spNo = new SqlParameter("@empno", SqlDbType.NVarChar) { Value = empNo };
            List<EmployeeInfo> empList = EmployeeInfo.TableToList(DBHelper.GetDataSet(sql, CommandType.Text, spNo).Tables[0]);
            if (empList.Count > 0)
            {
                return empList[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="empNo">用户名</param>
        /// <param name="pwd">密码</param>
        /// <returns>添加结果 0/1</returns>
        public int Add(string empNo, string pwd)
        {
            string sql = "insert into  Employees values(@empNo,@pwd)";

            SqlParameter spEmpNo = new SqlParameter("@empNo", empNo);
            string encryptedPwd = DEncrypt.Encrypt(pwd);
            SqlParameter spPwd = new SqlParameter("@pwd", encryptedPwd);

            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spEmpNo, spPwd);

        }
        public int Add(EmployeeInfo emp)
        {
            return this.Add(emp.EmpNummber, emp.Password);
        }
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="empNo">用户名</param>
        /// <param name="newPwd">新密码</param>
        /// <returns>更新状态 0/1</returns>
        public int Update(string empNo, string newPwd)
        {
            string sql = "update Employees set pwd=@pwd where empNo=@empNo";
            SqlParameter spEmpNo = new SqlParameter("@empNo", empNo);
            string encryptedPwd = DEncrypt.Encrypt(newPwd);
            SqlParameter spPwd = new SqlParameter("@pwd", encryptedPwd);
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spEmpNo, spPwd);

        }
        public int Update(EmployeeInfo emp)
        {
            return this.Update(emp.EmpNummber, emp.Password);
        }



    }
}
