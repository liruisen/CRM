using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Web
{
    public partial class GDI_ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //GDI+  画一个矩形框
            //画布，笔，人
            
            //1.定义画布
          
            Bitmap bmp = new Bitmap(200, 100);
            //2.定义一个人
            Graphics g = Graphics.FromImage(bmp);
            //3.定义笔的颜色和粗细
            Pen pen = new Pen(Color.Black, 1);
            //4.画之前，需要先清空画布，并给出画布的底色
            g.Clear(Color.Yellow);
            //5.绘制矩形框，重点就是给出矩形框的起点和终点
            g.DrawRectangle(pen, 0, 0, 199, 99);//这里只是画到了内内存里面，显示器上还看不见，需要保存下来才能看到


            //6.把图片输出到页面上（其实就是把绘制出来的这个bitmap输出到响应流里）
            Response.ContentType = "image/jpg";
            bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);

            bmp.Dispose();
            g.Dispose();
        }
    }
}