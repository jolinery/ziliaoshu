using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
namespace ZiLiaoShu.Models
{
    public class BaseConfig
    {
        public static string configStr()
        {
            string configStr = ConfigurationManager.ConnectionStrings["ziliaoshudbConfig"].ConnectionString;
            return configStr;
        }

    }
}