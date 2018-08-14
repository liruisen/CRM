using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Insert
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = this.textBox1.Text.ToString();

           

            this.updownImgByBase64String(str);
        }
        public void updownImgByBase64String(string UserPhoto)
        {
            string result;
            //图片路径
            //string filePath = HttpContext.Current.Server.MapPath("~/" + @System.Configuration.ConfigurationManager.AppSettings["ImagePath"]);
            try
            {
                byte[] bt = Convert.FromBase64String(UserPhoto);//获取图片base64
                string fileName = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString();//年月
                string ImageFilePath = "/Image" + "/" + fileName;
                //if (System.IO.Directory.Exists(HttpContext.Current.Server.MapPath(ImageFilePath)) == false)//如果不存在就创建文件夹
                //{
                System.IO.Directory.CreateDirectory(ImageFilePath);
                //}
                string ImagePath = ImageFilePath + "/" + System.DateTime.Now.ToString("yyyyHHddHHmmss");//定义图片名称
                File.WriteAllBytes(ImagePath + ".png", bt); //保存图片到服务器，然后获取路径  
                result = ImagePath + ".png";//获取保存后的路径
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
