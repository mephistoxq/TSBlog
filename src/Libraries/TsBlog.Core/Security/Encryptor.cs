using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TsBlog.Core.Security
{
    /// <summary>
    /// 加密静态类
    /// </summary>
    public static class Encryptor
    {
        public static string Md5Hash(string text)
        {
            //MD5加密一个字符串
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(Encoding.ASCII.GetBytes(text));

            var result = md5.Hash;

            var strBuilder = new StringBuilder();
            foreach (var t in result)
            {
                strBuilder.Append(t.ToString("x2"));
            }

            return strBuilder.ToString();
        }
        
    }
}
