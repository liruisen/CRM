using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Drawing;

namespace Web
{
    public partial class ValidateCode : System.Web.UI.Page
    {
        //Random rd = new Random();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //{
        //    Response.ContentType = "image/jpeg";
        //    string code = this.GetCode(4);
        //    this.CreateValidateImage(code, 100, 45);
        

        #region 注释
        //private string GetCode(int length)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    char[] chs = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '7', '8', '9' };
        //    int cIndex = 0;
        //    for (int i = 0; i < length; i++)
        //    {
        //        cIndex = rd.Next(0, chs.Length);
        //        sb.Append(chs[cIndex]);
        //    }
        //    return sb.ToString();
        //}
        //private void CreateValidateImage(string validateCode,int width,int height)
        //{
        //    //如果验证字符串长度等于0，就直接返回，不再生成图片
        //    if (validateCode.Length==0)
        //    {
        //        return;
        //    }
        //    Bitmap bmp = new Bitmap(width, height);
        //    Graphics g = Graphics.FromImage(bmp);
        //    g.Clear(Color.White);
        //    Font f14 = new Font("黑体", 28, FontStyle.Bold);
        //    //这个刷子能画出颜色渐变的效果
        //    Brush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, width, height), Color.GreenYellow, Color.HotPink, 1.2f, true);

        //    //干扰线
        //    for (int i = 0; i < 100; i++)
        //    {
        //        int x1 = rd.Next(1, width - 2);
        //        int y1 = rd.Next(1, height - 2);
        //        int x2 = x1 - 3;
        //        int y2 = y1 - 3;
        //        g.DrawLine(Pens.Sienna, y1, x1, y2, x2);
        //    }

        //    g.DrawString(validateCode, f14, br, 2, 2);
        //    //g.DrawRectangles(Pens.Black, 0, 0, width - 2, height - 2);


        //    for (int i = 0; i < 100; i++)
        //    {
        //        int x1 = rd.Next(1, width - 2);
        //        int y1 = rd.Next(1, height - 2);
        //        int x2 = x1 + 3;
        //        int y2 = y1 + 3;
        //        g.DrawLine(Pens.SkyBlue, x1, y1, x2, y2);
        //    }
        //    g.DrawRectangle(Pens.Black, 0, 0, width - 2, height - 2);
        //    bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        //} 
        #endregion
    }
}