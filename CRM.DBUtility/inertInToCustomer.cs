using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using CRM.Model;

namespace CRM.DBUtility
{
    public partial class inertInToCustomer : Form
    {
        public inertInToCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.textNum.Text);
            for (int i = 0; i < num; i++)
            {
                CustomerInfo cus = new CustomerInfo();
                cus.Name = "快速" + i.ToString();
                cus.Address = this.text_address.Text;
                cus.Birthday = Convert.ToDateTime(this.dateTimeBir);
                cus.Phone = this.textPhone.Text;
                cus.Email = this.textEmail.Text;
                cus.Company = this.textCompany.Text;
                cus.Title = this.textTitle.Text;
                cus.EmpId = Convert.ToInt32(this.textId);
                cus.PhotoUrl = null;

                //Add(cus);           

            }
        }

        private int Add(CustomerInfo ctm)
        {
            string sql = "insert into Customers(name,gender,_address,phone,email,birthday,company,title,photoUrl,empId,isDel) values(@name,@gender,@address,@phone,@email,@birthday,@company,@title,@photoUrl,@empId) ";
            SqlParameter spName = new SqlParameter("@name", SqlDbType.NVarChar) { Value = ctm.Name };
            SqlParameter spGender = new SqlParameter("@gender", SqlDbType.Bit) { Value = ctm.Gender };
            SqlParameter spAddress = new SqlParameter("@address", SqlDbType.NVarChar) { Value = ctm.Address };
            SqlParameter spPhone = new SqlParameter("@phone", SqlDbType.Char) { Value = ctm.Phone };
            SqlParameter spEmail = new SqlParameter("@email", SqlDbType.VarChar) { Value = ctm.Email };
            SqlParameter spBirthday = new SqlParameter("@birthday", SqlDbType.DateTime) { Value = ctm.Birthday };
            SqlParameter spCompany = new SqlParameter("@company", SqlDbType.NVarChar) { Value = ctm.Company };
            SqlParameter spTitle = new SqlParameter("@title", SqlDbType.NVarChar) { Value = ctm.Title };
            SqlParameter spPhotoUrl = new SqlParameter("@photoUrl", SqlDbType.VarChar) { Value = ctm.PhotoUrl };
            SqlParameter spEmpId = new SqlParameter("@empId", SqlDbType.Int) { Value = ctm.EmpId };

            return DBHelper.ExcuteNonQuery(sql, CommandType.Text, spName, spGender, spAddress, spPhone, spBirthday, spEmail, spCompany, spPhotoUrl, spTitle, spEmpId);
        }

        private void inertInToCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
