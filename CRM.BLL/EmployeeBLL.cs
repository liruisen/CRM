using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common;
using CRM.DLL;
using CRM.Model;

namespace CRM.BLL
{
    public class EmployeeBLL
    {
        EmployeeDAL empDal = new EmployeeDAL();
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="empNo"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        //public LoginState Login(string empNo, string pwd)
        //{
        //    return (LoginState)empDal.Validate(empNo, pwd);
        //}
        //public EmployeeInfo getEmployee(string empNo, string pwd)
        //{
        //    if (empDal.getEmployee(empNo, pwd)!=null)
        //    {
        //        return empDal.getEmployee(empNo, pwd);
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public EmployeeInfo getEmployee(string empNo)
        {
            if (empDal.getEmployee(empNo) != null)
            {
                return empDal.getEmployee(empNo);
            }
            else
            {
                return null;
            }
        }

        public int Login(string empNo, string pwd)
        {
            return empDal.getEmployee(empNo, pwd) == null ? 0 : 1;
        }
        public RegState Register(string empNo, string pwd)
        {

            if (empDal.Validate(empNo, pwd) == -1)
            {
                if (empDal.Add(empNo, pwd) > 0)
                {
                    return RegState.Success;
                }
                else
                {
                    return RegState.Failed;
                }
            }
            else
            {
                return RegState.EnpNumberExists;
            }
        }

        public bool ChangePassword(string empNo, string oldPwd, string newPwd)
        {
            if (empDal.Validate(empNo, oldPwd) == 1)
            {
                return empDal.Update(empNo, newPwd) > 0;
            }
            else
            {
                return false;
            }
        }
    }
}
