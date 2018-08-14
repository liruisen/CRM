using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Model;
using CRM.DLL;
using CRM.Common;

namespace CRM.BLL
{
   public class CustomerBLL
    {
       CustomerDAL ctmDll=new CustomerDAL();

       public List<CustomerInfo> GetCustomerListByEmpId(int empId, bool isDel)
       {
           return ctmDll.GetCustomerListByEmpId(empId, isDel);
       }
       public bool Add(CustomerInfo ctm)
       {
           return ctmDll.Add(ctm) > 0;
       }
       public bool Update(CustomerInfo ctm)
       {
           return ctmDll.Update(ctm) > 0;
       }
       public bool Delete(int id)
       {
           return ctmDll.Delete(id) > 0;
       }
       public List<CustomerInfo> GetCustomersByPage(int empId,int pageSize, int currentPage, ref int totalPages)
       {
           return ctmDll.GetCustomersByPage(empId,pageSize, currentPage, ref totalPages);
       }
    }
}
