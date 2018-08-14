using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;

namespace CRM.Common
{
    /// <summary>
    /// 加密解密
    /// </summary>
    public class DEncrypt
    {
        static string secretkey = PubConstant.Secretkey;
        /// <summary>
        /// 用MD5算法把二进制的秘钥进行散列
        /// </summary>
        /// <param name="kb">二进制的秘钥</param>
        /// <returns>散列后的秘钥</returns>
        private static byte[] MakeMD5(byte[] kb)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] keyHsah = md5.ComputeHash(kb);//给秘钥散列
            md5.Clear();//释放资源
            return keyHsah;
        }
        /// <summary>
        /// 根据秘钥加密
        /// </summary>
        /// <param name="original">明文</param>
        /// <param name="key">秘钥</param>
        /// <returns>密文</returns>
        public static string Encrypt(string original, string key)
        {
            byte[] buff = Encoding.Unicode.GetBytes(original);//把明文转换为二进制数组
            byte[] kb = Encoding.Unicode.GetBytes(key);//把秘钥转换为二进制数组
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();//使用TripeDES算法来加密
            des.Key = MakeMD5(kb);
            des.Mode = CipherMode.ECB;//设置算法的模式
            byte[] enByte = des.CreateEncryptor().TransformFinalBlock(buff, 0, buff.Length);
            return Convert.ToBase64String(enByte);//转换成字符串存进数据库
        }
        public static string Encrypt(string original)
        {
            return Encrypt(original,secretkey);
        }

        /// <summary>
        /// 根据秘钥解密
        /// </summary>
        /// <param name="encypted">密文</param>
        /// <param name="key">秘钥</param>
        /// <returns>明文</returns>
        public static string Decrypt(string encypted, string key)
        {
            byte[] buff = Convert.FromBase64String(encypted);
            byte[] kb = Encoding.Unicode.GetBytes(key);
            TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
            des.Key = MakeMD5(kb);
            des.Mode = CipherMode.ECB;
            byte[] original = des.CreateDecryptor().TransformFinalBlock(buff, 0, buff.Length);
            return Encoding.Unicode.GetString(original);
        }
        public static string Decrypt(string encypted)
        {
            return Decrypt(encypted,secretkey);
        }
    }
}
