using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace Demo
{
    public partial class cropperJS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToUpper()=="POST")
            {
                this.Base64StringToImage(Request.Form["name"]);
                
            }
        }
       
        private void Base64StringToImage(string inputStr)
        {
            if (string.IsNullOrWhiteSpace(inputStr))
                return;
            try
            {
                string filePath = "E:\\bb.jpg";
                byte[] arr = Convert.FromBase64String(inputStr.Substring(inputStr.IndexOf("base64,") + 7).Trim('\0'));
                using (MemoryStream ms = new MemoryStream(arr))
                {
                    Bitmap bmp = new Bitmap(ms);
                    //新建第二个bitmap类型的bmp2变量。
                    Bitmap bmp2 = new Bitmap(bmp, bmp.Width, bmp.Height);
                    //将第一个bmp拷贝到bmp2中
                    Graphics draw = Graphics.FromImage(bmp2);
                    draw.DrawImage(bmp, 0, 0);
                    draw.Dispose();
                    bmp2.Save(filePath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Close();
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
      
    }
}