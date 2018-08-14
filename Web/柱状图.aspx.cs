using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace Web
{
    public partial class 柱状图 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //绘制柱状图， 2016年销售情况柱状图

            //2016年销售额
            int[] sales = new int[] { 30, 25, 16, 52, 18, 22, 59, 85, 42, 36, 58,60 };
            //2.创建画布
            
            Bitmap bmp = new Bitmap(450, 400);
            //bmp.SetResolution(300, 300);
            //3.创建会话的人
            Graphics g = Graphics.FromImage(bmp);
            //4.清空画布，并给白色的底色
            g.Clear(Color.White);
            //5.画出边框
            g.DrawRectangle(Pens.Black, 0, 0, 448, 398);
            //6.画出柱状图的标题
            string title = "2016年销售情况一览";
            Font f18 = new Font("黑体", 18, FontStyle.Bold);
            //定义刷子
            Brush br = new SolidBrush(Color.Black);
            //绘制文字
            g.DrawString(title, f18, br, (225 - g.MeasureString(title, f18).Width / 2), 20);

            //7绘制各个柱子以及对应的文字
            //7.1确定画柱状图内容区域的区域大小（宽，高）
            float v_width = 450;
            float v_height = 400 - g.MeasureString(title, f18).Height - 40;

            //7.2整个版心的宽度分成25份
            float p_width = v_width / 25;
            //7.3把高度平均分成100份，每个月的柱子的高度，应该是：销售额*p_height
            float p_height = v_height / 100;
            //7.4声明变量，用来计算每个柱子的左上角X坐标和Y坐标
            float x = 0;
            float y = 0;
            Font f9=new Font("黑体",9,GraphicsUnit.Pixel);//最后一个参数表示字号单位 像素

            for (int i = 0; i < 12; i++)
            {
                //7.5画柱子
                x = (i * 2 + 1) * p_width;      //每个柱子的左上角坐标
                y = v_height - p_height * sales[i]+40;
                g.FillRectangle(Brushes.SkyBlue, x, y, p_width,p_height*sales[i]);
                //7.6写月份
                int month = i + 1;
                g.DrawString(month.ToString() + "月", f9, Brushes.Black, x, v_height + 45);
                //7.7写销售额
                g.DrawString(sales[i].ToString(), f9, Brushes.Black, x, y - 10);
            }



            Response.ContentType = "image/jpeg";
            bmp.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}