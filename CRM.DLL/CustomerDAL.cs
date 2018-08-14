using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CRM.Model;
using CRM.DBUtility;

namespace CRM.DLL
{
    public class CustomerDAL
    {
        public List<CustomerInfo> GetCustomerListByEmpId(int empId,bool isDel)
        {
            string sql = "select id ,name,gender,_address,phone,email,birthday,company,title,photoUrl,empId from Customers where isDel=@isDel and empId=@empId" ;
            SqlParameter spIsDel = new SqlParameter("@isDel", SqlDbType.Bit) { Value = isDel };
            SqlParameter spEmpId = new SqlParameter("@empId", SqlDbType.Int) { Value = empId };
            DataTable dt=DBHelper.GetDataTable(sql,CommandType.Text,spEmpId,spIsDel);
            return CustomerInfo.TableToList(dt);
        }

        public int Add(CustomerInfo ctm)
        {
            //string sql = "insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values(@name,@gender,@address,@phone,@email,@birthday,@company,@title,@photoUrl,@empId) ";
            string sql = "insert into Customers(name,gender,_address,phone,email,birthday,company,title,empId) values(@name,@gender,@address,@phone,@email,@birthday,@company,@title,@empId) ";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = ctm.Name };
            SqlParameter spGender = new SqlParameter("@gender", SqlDbType.Bit) { Value = ctm.Gender };
            SqlParameter spAddress = new SqlParameter("@address", SqlDbType.NVarChar ) { Value = ctm.Address  };
            SqlParameter spPhone = new SqlParameter("@phone", SqlDbType .Char) { Value = ctm.Phone  };
            SqlParameter spEmail = new SqlParameter("@email", SqlDbType.VarChar ) { Value = ctm.Email  };
            SqlParameter spBirthday = new SqlParameter("@birthday", SqlDbType.DateTime ) { Value = ctm.Birthday  };
            SqlParameter spCompany = new SqlParameter("@company", SqlDbType.NVarChar ) { Value = ctm.Company  };
            SqlParameter spTitle = new SqlParameter("@title", SqlDbType.NVarChar ) { Value = ctm .Title };
            //SqlParameter spPhotoUrl = new SqlParameter("@photoUrl", SqlDbType.VarChar ) { Value = ctm .PhotoUrl };
            SqlParameter spEmpId = new SqlParameter("@empId", SqlDbType.Int  ) { Value = ctm.EmpId  };

            //return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spName, spGender, spAddress, spPhone, spBirthday, spEmail, spCompany, spPhotoUrl, spTitle, spEmpId);
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spName, spGender, spAddress, spPhone, spBirthday, spEmail, spCompany, spTitle, spEmpId);
        }

        public int Update(CustomerInfo ctm)
        {
            string sql = "update Customers set name=@name,gender=@gender,_address=@address,phone=@phone,email=@email,birthday=@birthday,company=@company,title=@title,photoUrl=@photoUrl where id=@id";

            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = ctm.Name };
            SqlParameter spGender = new SqlParameter("@gender", SqlDbType.Bit) { Value = ctm.Gender };
            SqlParameter spAddress = new SqlParameter("@address", SqlDbType.NVarChar) { Value = ctm.Address };
            SqlParameter spPhone = new SqlParameter("@phone", SqlDbType.Char) { Value = ctm.Phone };
            SqlParameter spEmail = new SqlParameter("@email", SqlDbType.VarChar) { Value = ctm.Email };
            SqlParameter spBirthday = new SqlParameter("@birthday", SqlDbType.DateTime) { Value = ctm.Birthday };
            SqlParameter spCompany = new SqlParameter("@company", SqlDbType.NVarChar) { Value = ctm.Company };
            SqlParameter spTitle = new SqlParameter("@title", SqlDbType.NVarChar) { Value = ctm.Title };
            SqlParameter spPhotoUrl = new SqlParameter("@photoUrl", SqlDbType.VarChar) { Value = ctm.PhotoUrl };
            SqlParameter spId = new SqlParameter("@id", SqlDbType.Int) { Value = ctm.Id};
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spName, spGender, spAddress, spPhone, spBirthday, spEmail, spCompany, spPhotoUrl, spTitle, spId);

        }

        public int Delete(int empId)
        {
            string sql = "update Customers set isDel=1 where id=@id";
            SqlParameter spId = new SqlParameter("@id", SqlDbType.Int) { Value = empId };
            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spId);
        }
        public List<CustomerInfo> GetRecentlyBirthdayCustomer()
        {
            string sql = "select * from Customers where MONTH(birthday)=MONTH(GETDATE()) and (DAY(birthday)-DAY(GETDATE())) in(1,2,3) and isDel=0";
            DataTable dt = DBHelper.GetDataTable(sql, CommandType.Text);
            return CustomerInfo.TableToList(dt);
        }

        /// <summary>
        /// 分页读取用户信息
        /// </summary>
        /// <param name="pageSize">每页容量</param>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalPages">总页数</param>
        /// <returns></returns>
        public List<CustomerInfo> GetCustomersByPage(int empId,int pageSize, int currentPage,ref int totalPages)
        {
            string sql = "up_GetCustomersByPage";
            SqlParameter spId = new SqlParameter("@empId", SqlDbType.Int) { Value = empId };
            SqlParameter spPageSize = new SqlParameter("@pageSize", pageSize);
            SqlParameter spCurrentPage = new SqlParameter("@currentPage", currentPage);
            SqlParameter spTotalPages = new SqlParameter("@totalPages", totalPages) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.GetDataTable(sql, CommandType.StoredProcedure, spId,spCurrentPage, spPageSize, spTotalPages);
            totalPages = Convert.ToInt32(spTotalPages.Value);
            return CustomerInfo.TableToList(dt);
        }
    }
}
