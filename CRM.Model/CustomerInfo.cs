using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Model
{
    public class CustomerInfo
    {
        public int Id { get; set; }
        public int EmpId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public string Email { get; set; } 
        public string  Company { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; } 
        public DateTime  Birthday { get; set; }


        public static List<CustomerInfo> TableToList(System.Data.DataTable dt)
        {
            List<CustomerInfo> ctmList = new List<CustomerInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CustomerInfo ctm = new CustomerInfo();
                if (!dt.Rows[i].IsNull("id")) { ctm.Id = Convert.ToInt32(dt.Rows[i]["id"]); }
                if (!dt.Rows[i].IsNull("empId")) { ctm.EmpId = Convert.ToInt32(dt.Rows[i]["empId"]); }
                if (!dt.Rows[i].IsNull("name")) { ctm.Name = dt.Rows[i]["name"].ToString(); }
                if (!dt.Rows[i].IsNull("gender")) { ctm.Gender =Convert .ToBoolean( dt.Rows[i]["gender"]); }
                if (!dt.Rows[i].IsNull("_address")) { ctm.Address = dt.Rows[i]["_address"].ToString(); }
                if (!dt.Rows[i].IsNull("phone")) { ctm.Phone = dt.Rows[i]["phone"].ToString(); }
                if (!dt.Rows[i].IsNull("email")) { ctm.Email = dt.Rows[i]["email"].ToString(); }
                if (!dt.Rows[i].IsNull("birthday")) { ctm.Birthday =Convert.ToDateTime( dt.Rows[i]["birthday"]); }
                if (!dt.Rows[i].IsNull("title")) { ctm.Title = dt.Rows[i]["title"].ToString(); }
                if (!dt.Rows[i].IsNull("photoUrl")) { ctm.PhotoUrl = dt.Rows[i]["photoUrl"].ToString(); }
                if (!dt.Rows[i].IsNull("company")) { ctm.Company = dt.Rows[i]["company"].ToString(); }

                ctmList.Add(ctm);

            }
            return ctmList;
        }
       
    }

}
