using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common
{
    ///*
    // * 控件名称：分页控件
    // * 开发者：李瑞森
    // * 开发日期：2018.5.30
    // * 使用说明：
    // *            1.
    // *            2.引入bootstrap样式表
    // * /
    public class PageNavigator
    {
        /// <summary>
        /// 页码组件
        /// </summary>
        /// <param name="pageSize">每页容量</param>
        /// <param name="currentPage">当前页码</param>
        /// <param name="totalPages">总页数</param>
        /// <param name="radirectUrl">跳转链接</param>
        /// <param name="range">生成页码数量</param>
        /// <returns>导航条的HTML字符串</returns>
        public static string CreatPageNavigator(int pageSize, int currentPage, int totalPages, string radirectUrl, int range)
        {
            //1.判断pageSize，如果小于等于0，就让每页显示5条记录    容错处理
            pageSize = pageSize <= 0 ? 5 : pageSize;
            StringBuilder sbOutput = new StringBuilder();
            if (totalPages > 1)
            {
                sbOutput.Append("<nav><ul class='pager'>");
                //2.生成首页选项
                if (currentPage != 1)
                {
                    sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage=1'>首页</a></li>", radirectUrl, pageSize);
                }
                else
                {
                    sbOutput.AppendFormat("<li class='disabled'><a href='{0}?pageSize={1}&currentPage=1'>首页</a></li>", radirectUrl, pageSize);

                }

                //3.生成"上一页"选项
                if (currentPage > 1)//如果当前页不是第一页
                {
                    sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>上一页</a></li>", radirectUrl, pageSize, currentPage - 1);

                }
                else//如果是第一页
                {
                    sbOutput.AppendFormat("<li class='disabled'><a href='javascript:void(0);'>上一页</a></li>", radirectUrl, pageSize, currentPage - 1);
                }

                //4.显示当前页码的前 3 个页码和后 3 个页码，加上本页一共是 7 个标签
                //int range = 3;
                for (int i = 0; i < range * 2 + 1; i++)
                {
                    //int pageNumber = currentPage + i - range;//得到本次循环的页码值


                    //if (pageNumber >= 1 && pageNumber <= totalPages)      //判断这个页码值是不是在正常的范围之内
                    //{

                    //    if (pageNumber == currentPage)                //处理当前页，给当前页添加一个active类
                    //    {
                    //        sbOutput.AppendFormat("<li class='active'><a href='javascript:void(0);'>{0}</a></li>", currentPage);

                    //    }
                    //    else                                         //处理一般页
                    //    {
                    //        sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>{3}</a></li>", radirectUrl, pageSize, pageNumber, pageNumber);
                    //    }
                    //}
                    if (currentPage<=range+1)
                    {
                        int pageNumber = i + 1;
                        if (pageNumber==currentPage)
                        {
                            sbOutput.AppendFormat("<li><a href='javascript:void(0);' style='color:red'>{0}</a></li>", currentPage);
                        }
                        else
                        {
                            sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>{3}</a></li>", radirectUrl, pageSize, pageNumber, pageNumber);
                        }
                    }
                    else if (range+1<currentPage&&currentPage<totalPages-range)
                    {
                        int pageNumber = currentPage + i - range;//得到本次循环的页码值
                        if (pageNumber == currentPage)                //处理当前页，给当前页添加一个active类
                        {
                            sbOutput.AppendFormat("<li ><a href='javascript:void(0);'style='color:red'>{0}</a></li>", currentPage);

                        }
                        else                                         //处理一般页
                        {
                            sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>{3}</a></li>", radirectUrl, pageSize, pageNumber, pageNumber);
                        }
                    }
                    else if (currentPage>totalPages-range-1&&currentPage<=totalPages)
                    {
                        int pageNumber = totalPages - 2 * range + i;
                        if (pageNumber == currentPage)                //处理当前页，给当前页添加一个active类
                        {
                            sbOutput.AppendFormat("<li ><a href='javascript:void(0);' style='color:red'>{0}</a></li>", currentPage);

                        }
                        else                                         //处理一般页
                        {
                            sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>{3}</a></li>", radirectUrl, pageSize, pageNumber, pageNumber);
                        }
                    }


             

                }
                //5.生成下一页
                if (currentPage < totalPages)
                {
                    sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>下一页</a></li>", radirectUrl, pageSize, currentPage + 1);

                }
                else
                {
                    sbOutput.AppendFormat("<li class='disabled' ><a href='javascript:void(0);'>下一页</a></li>", radirectUrl, pageSize, currentPage + 1);

                }
                //6.生成末页
                if (currentPage != totalPages)
                {
                    sbOutput.AppendFormat("<li><a href='{0}?pageSize={1}&currentPage={2}'>尾页({2}页)</a></li>", radirectUrl, pageSize, totalPages);
                }
                else
                {
                    sbOutput.AppendFormat("<li class='disabled' ><a href='{0}?pageSize={1}&currentPage={2}'>尾页({2}页)</a></li>", radirectUrl, pageSize, totalPages);
                }


                sbOutput.Append("</ul></nav>");

                return sbOutput.ToString();
            }
            else
            {
                return null;

            }

        }
    }
}
