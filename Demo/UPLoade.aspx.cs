using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Demo
{
    public partial class UPLoade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.HttpMethod.ToLower()=="post")
            {
                //HttpPostedFile file = Request.Files[0];
                //file.SaveAs(Server.MapPath("~/upload/1.jpg"));

                //1.只能上传图片
                //2.给图片标准化

                if (Request.Files.Count>0)
                {
                    //获取上传过来的文件
                    HttpPostedFile file = Request.Files[0];
                    
                    //判断文件是不是一个图片
                    if (file.ContentType.Contains("image/"))
                    {
                        //获取纯净的原始文件名 
                        string fileName = System.IO.Path.GetFileName(file.FileName);
                        //使用GUID，保证生成一个独一无二的字符串
                        fileName = Guid.NewGuid().ToString() + fileName;
                        //映射出保存文件的绝对路径
                        string savePath = Server.MapPath("~/upload/" + fileName);
                        //格式化图片大小（生成缩略图），使用GDI+
                        //从输入流获取原始图片数据，得到Image对象
                        using (System.Drawing.Image img=System.Drawing.Image.FromStream(file.InputStream))
                        {
                            //创建缩略图画板
                            using (System.Drawing.Image imgStandart=new System.Drawing.Bitmap(img.Width/5,img.Height/5) )
                            {
                                //往标准画板上画，不能往原始画板上画
                                using (Graphics g=Graphics.FromImage(imgStandart))
                                {
                                    //把原始图片缩放到标准画板上，GraphicsUnit.Pixel以像素为单位
                                    g.DrawImage(img, new Rectangle(0, 0, imgStandart.Width, imgStandart.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                                    //把img保存到服务器上
                                    imgStandart.Save(savePath);
                                }                                
                            }
                        }
                    }
                }
            }
        }
    }
}