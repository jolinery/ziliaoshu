using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ziliaoshu.Common
{
    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class Extension
    {
        #region ConcurrentDictionary扩展
        /// <summary>
        /// 尝试从 System.Collections.Concurrent.ConcurrentDictionary(TKey,TValue) 中移除并返回具有指定键的值。
        /// </summary>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <typeparam name="TValue">TValue</typeparam>
        /// <param name="dict">要处理的集合</param>
        /// <param name="key">要移除并返回的元素的键。</param>
        /// <param name="defaultValue">此方法返回时，value 包含从 System.Collections.Concurrent.ConcurrentDictionary(TKey,TValue)
        /// 中移除的对象；如果操作失败，则包含默认值。
        /// </param>
        /// <returns>如果成功移除了对象，则为 true；否则为 false。</returns>
        public static bool TryRemoveWith<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            TValue value;
            return dict.TryRemove(key, out value);
        }

        /// <summary>
        /// 尝试从 System.Collections.Concurrent.ConcurrentDictionary(TKey,TValue) 获取与指定的键关联的值。
        /// </summary>
        /// <typeparam name="TKey">TKey</typeparam>
        /// <typeparam name="TValue">TValue</typeparam>
        /// <param name="dict">要处理的集合</param>
        /// <param name="key">要获取的值的键。</param>
        /// <param name="defaultValue">此方法返回时，value 包含 System.Collections.Concurrent.ConcurrentDictionary(TKey,TValue)
        /// 中具有指定键的对象；如果操作失败，则包含默认值。
        /// </param>
        /// <returns>如果在 System.Collections.Concurrent.ConcurrentDictionary(TKey,TValue) 中找到该键，则为TValue，否则为NULL</returns>
        public static TValue TryGetValueWith<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dict, TKey key, TValue defaultValue = default(TValue))
        {
            TValue value;
            return dict.TryGetValue(key, out value) ? value : defaultValue;
        }
        #endregion

        #region string.Format扩展
        /// <summary>
        ///  将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="args">一个对象数组，其中包含零个或多个要设置格式的对象。</param>
        /// <returns></returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }
        /// <summary>
        ///  将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的第一个对象。</param>
        /// <returns></returns>
        public static string FormatWith(this string format, object arg0)
        {
            return string.Format(format, arg0);
        }
        /// <summary>
        ///  将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的第一个对象</param>
        /// <param name="arg1">要设置格式的第二个对象。</param>
        /// <returns></returns>
        public static string FormatWith(this string format, object arg0, object arg1)
        {
            return string.Format(format, arg0, arg1);
        }
        /// <summary>
        ///  将指定字符串中的格式项替换为指定数组中相应对象的字符串表示形式。
        /// </summary>
        /// <param name="format">复合格式字符串。</param>
        /// <param name="arg0">要设置格式的第一个对象</param>
        /// <param name="arg1">要设置格式的第二个对象</param>
        /// <param name="arg2">要设置格式的第三个对象。</param>
        /// <returns></returns>
        public static string FormatWith(this string format, object arg0, object arg1, object arg2)
        {
            return string.Format(format, arg0, arg1, arg2);
        }

        #endregion

        #region string.Join扩展
        /// <summary>
        /// 串联类型为 System.String 的 System.Collections.Generic.IEnumerable<T> 构造集合的成员，其中在每个成员之间使用指定的分隔符。
        /// </summary>
        /// <param name="separator">要用作分隔符的字符串。</param>
        /// <param name="values">一个包含要串联的字符串的集合。</param>
        /// <returns>一个由 values 的成员组成的字符串，这些成员以 separator 字符串分隔。</returns>
        public static string Join(this object values, string separator)
        {
            if (values.GetType() == typeof(System.Object[]))
            {
                object[] v = (object[])values;
                return string.Join(separator, v);
            }
            else if (values.GetType() == typeof(System.String[]))
            {
                string[] v = (string[])values;
                return string.Join(separator, v);
            }
            else if (values.GetType() == typeof(System.Collections.Generic.List<string>))
            {
                List<string> v = (List<string>)values;
                return string.Join(separator, v);
            }
            return string.Join(separator, values);
        }

        /// <summary>
        ///  泛型 数组
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator"></param>
        /// <param name="isString"></param>
        /// <returns></returns>
        public static string JoinWith<T>(this List<T> values, char separator, bool isString = false)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in values)
            {
                if (isString)
                    sb.AppendFormat("'{0}'{1}", item.ToString(), separator);
                else
                    sb.AppendFormat("{0}{1}", item.ToString(), separator);
            }

            string result = sb.ToString();

            if (!string.IsNullOrWhiteSpace(result))
                result = result.TrimEnd(separator);
            return result;
        }

        #endregion

        #region string.IsNullOrWhiteSpace扩展
        /// <summary>
        /// 指示指定的字符串是 null、空还是仅由空白字符组成。
        /// </summary>
        /// <param name="s">要验证的字符串。</param>
        /// <returns>如果 value 参数为 null 或 System.String.Empty，或者如果 value 仅由空白字符组成，则为 true。</returns>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// Json字符串转换成实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T JsonToObject<T>(this string jsonString)
        {
            //将"yyyy-MM-dd HH:mm:ss"格式的字符串转为"\/Date(1294499956278+0800)\/"格式  
            string p = @"\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}";
            MatchEvaluator matchEvaluator = new MatchEvaluator(ConvertDateStringToJsonDate);
            Regex reg = new Regex(p);
            jsonString = reg.Replace(jsonString, matchEvaluator);

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T jsonObject = (T)ser.ReadObject(ms);
            ms.Close();
            return jsonObject;
        }

        #endregion

        private static string ConvertDateStringToJsonDate(Match m)
        {
            string result = string.Empty;
            DateTime dt = DateTime.Parse(m.Groups[0].Value);
            dt = dt.ToUniversalTime();
            TimeSpan ts = dt - DateTime.Parse("1970-01-01");
            result = string.Format("\\/Date({0}+0800)\\/", ts.TotalMilliseconds);
            return result;
        }


        /// <summary>
        /// 连接指定 System.Object 数组中的元素的 System.String 表示形式，包含当前的字符串。
        /// </summary>
        /// <param name="s">返回</param>
        /// <param name="args">一个对象数组，其中包含要连接的元素。</param>
        /// <returns>args 中元素的值经过连接的字符串表示形式。</returns>
        public static string ConcatWith(this string s, params object[] args)
        {
            return string.Concat(s, args);
        }

        #region 数据类型转换
        /// <summary>
        /// 将一个对象转换成Int32
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(int)</param>
        /// <returns></returns>
        public static int ToInt32(this object obj, int defaultValue = default(int))
        {
            int value;
            if (int.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将一个字符串转换成Int32
        /// </summary>
        /// <param name="s">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(int)</param>
        /// <returns></returns>
        public static int ToInt32(this string s, int defaultValue = default(int))
        {
            int value;
            if (int.TryParse(s, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将一个对象转换成Int64
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(long)</param>
        /// <returns></returns>
        public static long ToInt64(this object obj, long defaultValue = default(long))
        {
            long value;
            if (long.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return defaultValue;
        }

        public static long? ToInt64Null(this object obj)
        {
            long? value = null;
            if (obj != null)
                value = obj.ToInt64();
            return value;
        }

        /// <summary>
        /// 将一个字符串转换成Int64
        /// </summary>
        /// <param name="s">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(long)</param>
        /// <returns></returns>
        public static long ToInt64(this string s, long defaultValue = default(long))
        {
            long value;
            if (long.TryParse(s, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将一个对象转换成DateTime
        /// </summary>
        /// <param name="obj">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(DateTime)</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this object obj, DateTime defaultValue = default(DateTime))
        {
            DateTime value;
            if (DateTime.TryParse(obj.ToString(), out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将一个字符串转换成DateTime
        /// </summary>
        /// <param name="s">要转换的对象</param>
        /// <param name="defaultValue">转换失败返回的值，默认为default(DateTime)</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this string s, DateTime defaultValue = default(DateTime))
        {
            DateTime value;
            if (DateTime.TryParse(s, out value))
            {
                return value;
            }
            return defaultValue;
        }

        /// <summary>
        /// 将一个对象转换成字符串
        /// </summary>
        /// <param name="obj">如果对象为NULL，则返回string.Empty</param>
        /// <returns></returns>
        public static string ToStringEmpty(this object obj)
        {
            if (obj == null)
            {
                return string.Empty;
            }

            return obj.ToString();
        }

        /// <summary>
        /// 将一个字符串转换成字符串
        /// </summary>
        /// <param name="s">如果对象为NULL，则返回string.Empty</param>
        /// <returns></returns>
        public static string ToStringEmpty(this string s)
        {
            if (s == null)
            {
                return string.Empty;
            }

            return s;
        }

        #endregion

        /// <summary>
        /// 获取两个时间秒差
        /// </summary>
        /// <param name="nowTime">当前时间</param>
        /// <param name="cdTime">过期时间</param>
        /// <returns>返回大于等于0的秒数</returns>
        public static long GetSpanTime(this DateTime nowTime, DateTime cdTime)
        {
            int seconds = (int)Math.Ceiling((cdTime - nowTime).TotalSeconds);
            return seconds > 0 ? seconds : 0;
        }

        /// <summary>
        /// 格式化 成 yyyy-MM-dd
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static string ToFormatDate(this DateTime? date, TimeType deafult = TimeType.Default)
        {
            DateTime dt = date == null ? DateTime.Now.Date : Convert.ToDateTime(date);
            if (date == null)
            {
                switch (deafult)
                {
                    case TimeType.MaxDate:
                        dt = ConstString.MaxDate;
                        break;
                    case TimeType.MinDate:
                        dt = ConstString.MinDate;
                        break;
                    default:
                        break;
                }
            }
            return dt.ToString("yyyy-MM-dd");
        }
        public static string ToFormatDate(this DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 根据左右字符串获取中间的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <param name="s1"></param>
        /// <param name="s2"></param>
        /// <returns></returns>
        public static string SubstringWith(this string s, string s1, string s2)
        {
            if (s.IsNullOrWhiteSpace())
            {
                return string.Empty;
            }
            int n1, n2;
            n1 = s.IndexOf(s1, 0) + s1.Length;   //开始位置  
            if (s2 == null || s2 == string.Empty)
            {
                return s.Substring(0, n1 - 1);
            }
            n2 = s.IndexOf(s2, n1);               //结束位置  
            return s.Substring(n1, n2 - n1);   //取搜索的条数，用结束的位置-开始的位置,并返回  
        }

        public static T CreateDeepCopy<T>(this T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            formatter.Serialize(stream, item);
            stream.Seek(0, SeekOrigin.Begin);
            T result = (T)formatter.Deserialize(stream);
            stream.Close();
            return result;
        }
        #region 该方法用于生成指定位数的随机字符串
        /// <summary>
        /// 该方法用于生成指定位数的随机字符串
        /// </summary>
        /// <param name="VcodeNum">参数是随机数的位数</param>
        /// <returns>返回一个随机数字符串</returns>
        public static string RndNumStr(int VcodeNum)
        {
            string[] source = { "0", "1", "1", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            string checkCode = String.Empty;
            Random random = new Random();
            for (int i = 0; i < VcodeNum; i++)
            {
                checkCode += source[random.Next(0, source.Length)];

            }
            return checkCode;
        }
        #endregion
        #region 该方法用于生成指定位数的随机字符串
        /// <summary>
        /// 该方法用于生成指定位数的随机字符串
        /// </summary>
        /// <returns>返回一个随机数</returns>
        public static int RndNumStr(int min,int max)
        {
            Random random = new Random();
            return random.Next(100000,999999);
        }
        #endregion


    }
}
