using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRM.Model;
using CRM.DLL;

namespace Insert
{
    public partial class Form1 : Form
    {
        CustomerDAL cusDLL = new CustomerDAL();
        double x = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int num = int.Parse(this.textNum.Text);
            this.timer1.Enabled = true;
            this.timer1.Start();
            this.timer1.Interval = 100;
            for (int i = 0; i < num; i++)
            {
                CustomerInfo cus = new CustomerInfo();
                cus.Name = this.textName.Text + i.ToString();
                cus.Address = this.text_address.Text;
                cus.Birthday = Convert.ToDateTime(this.dateTimeBir.Value);
                cus.Phone = this.textPhone.Text;
                cus.Gender = true;
                cus.Email = this.textEmail.Text;
                cus.Company = this.textCompany.Text;
                cus.Title = this.textTitle.Text;
                cus.EmpId = Convert.ToInt32(this.textId.Text);
                cus.PhotoUrl = null;
               
                cusDLL.Add(cus);          
            }
            this.timer1.Stop();
            MessageBox.Show(this.x.ToString());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.x += 0.1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
