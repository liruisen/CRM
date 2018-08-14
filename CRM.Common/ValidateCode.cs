using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Drawing.Drawing2D;

namespace CRM.Common
{
   public  class ValidateCode
    {
        private HttpContext context;
        public ValidateCode(HttpContext context)
        {
            this.context = context;
        }
        Random rd = new Random();

        public string GetCode(int length)
        {
            StringBuilder sb = new StringBuilder();
            char[] chs = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '2', '3', '4', '5', '6', '7', '8', '9' };
            int cIndex = 0;
            for (int i = 0; i < length; i++)
            {
                cIndex = rd.Next(0, chs.Length);
                sb.Append(chs[cIndex]);
            }
            return sb.ToString();
        }
        public void CreateValidateImage(string validateCode, int width, int height)
        {
            //如果验证字符串长度等于0，就直接返回，不再生成图片
            if (validateCode.Length == 0)
            {
                return;
            }
            using (Bitmap bmp = new Bitmap(width, height))
            {
                //bmp.SetResolution(150, 100);      设置分辨率
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    //提高绘图质量，但是可能会降低效率
                    //g.SmoothingMode = SmoothingMode.HighQuality;
                    g.Clear(Color.White);
                    Font f14 = new Font("黑体", 20, FontStyle.Bold);
                    //这个刷子能画出颜色渐变的效果
                    Brush br = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, width, height), Color.GreenYellow, Color.HotPink, 1.2f, true);

                    //干扰线
                    for (int i = 0; i < 50; i++)
                    {
                        int x1 = rd.Next(1, width - 2);
                        int y1 = rd.Next(1, height - 2);
                        int x2 = x1 - 3;
                        int y2 = y1 - 3;
                        g.DrawLine(Pens.Sienna, y1, x1, y2, x2);
                    }

                    g.DrawString(validateCode, f14, br, 2, 2);
                    //g.DrawRectangles(Pens.Black, 0, 0, width - 2, height - 2);


                    for (int i = 0; i < 50; i++)
                    {
                        int x1 = rd.Next(1, width - 2);
                        int y1 = rd.Next(1, height - 2);
                        int x2 = x1 + 3;
                        int y2 = y1 + 3;
                        g.DrawLine(Pens.SkyBlue, x1, y1, x2, y2);
                    }
                    g.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
                    

                    //把验证码的字符串写入到cookie，这个cookie不需要长久保持，所以我们不把这个cookie写入硬盘，而是使用缓存cookie
                    HttpCookie vCodeCookie = new HttpCookie("vCode", validateCode);
                    context.Response.Cookies.Add(vCodeCookie);


                    this.context.Response.ContentType = "image/jpeg";
                    bmp.Save(this.context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }
    }
}
