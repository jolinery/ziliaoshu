using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ziliaoshu.Common
{
    class ConstString
    {
        /// <summary>
        /// 数据库可存的最小时间
        /// </summary>
        public static DateTime MinDate = new DateTime(1900, 1, 1);

        /// <summary>
        /// 数据库可存的最大时间
        /// </summary>
        public static DateTime MaxDate = new DateTime(9999, 12, 31);
    }
}
