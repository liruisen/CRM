using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;

namespace CRM.Common
{
    /// <summary>
    /// 封装读取web.config文件配置节的操作
    /// 使用缓存，提高系统性能
    /// </summary>
    public class PubConstant
    {
        //缓存是在服务器的内存空间里开辟一段存储空间，把系统会反复使用的外部资源缓存到内存里，以减少反复读取硬盘的性能损失
        //缓存也是以键值对的形式来存储数据的

        //思路：但要读取 配置节信息的时候，先去缓存里面去找，如果缓存里面没有，再去读硬盘

        /// <summary>
        /// 读取缓存中的数据
        /// </summary>
        /// <param name="cacheKey">缓存的Key</param>
        /// <returns>obj类型的对象</returns>
        public static object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;      //获取当前系统的缓存
            return objCache[cacheKey];
        }

        /// <summary>
        /// 写入缓存
        /// </summary>
        /// <param name="cacheKey">缓存的Key</param>
        /// <param name="objValue">缓存的Value</param>
        /// <param name="absoluteExiration">有效期</param>
        /// <param name="slidingExpiration">间隔</param>
        public static void SetCache(string cacheKey, object objValue, DateTime absoluteExiration, TimeSpan slidingExpiration)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            objCache.Insert(cacheKey, objValue, null, absoluteExiration, slidingExpiration);
        }

        /// <summary>
        /// 读取位置文件里面的配置节
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            string cacheKey = "AppSetting-" + key;
            object objValue = GetCache(cacheKey);
            if (objValue==null)
            {
                objValue = ConfigurationManager.AppSettings[key];
                SetCache(cacheKey, objValue, DateTime.Now.AddMinutes(120), TimeSpan.Zero);
            }
            return objValue.ToString();
        }

        public static string ConnectionString
        {
            get
            {
                return GetConfigString("ConnectionString");
            }
        }
        public static string Secretkey
        {
            get
            {
                return GetConfigString("secretkey");
            }
        }
    }
}
