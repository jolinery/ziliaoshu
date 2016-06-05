using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ziliaoshu.Common
{
    public class PathHelper
    {
        /// <summary>
        /// 获取随机的文件路径名字
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string RadomPath()
        {
            return "zls_" + DateTime.Now.ToString("yyyymmddhhmmss") + Extension.RndNumStr(10000,99999);
        }
        /// <summary>
        /// 获取书的相对存储路径
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string StoreShuPath(string fileName,string secondFilePath)
        {
            return "/shu/{0}/{1}".FormatWith(secondFilePath, fileName);
        }

    }
}
