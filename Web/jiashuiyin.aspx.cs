using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Web
{
    public partial class jiashuiyin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "image/jpeg";
            Bitmap bmp = new Bitmap(Server.MapPath("img/GDI.jpg"));
            Graphics g = Graphics.FromImage(bmp);
            Font f14 = new Font("微软雅黑", 10, FontStyle.Bold);
            g.DrawString("liruisen", f14, Brushes.Gray, 100, 50);
            bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            bmp.Dispose();
            g.Dispose();
        }
    }
}