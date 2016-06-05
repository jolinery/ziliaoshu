
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ziliaoshu.Common
{
    public class ConfigString
    {
        public readonly static string configString = ConfigurationManager.ConnectionStrings["ziliaoshudbConfig"].ConnectionString;
        public  string configStr()
        {
            string configStr = ConfigurationManager.ConnectionStrings["ziliaoshudbConfig"].ConnectionString;
            return configStr;
        }

    }
    //public class ziliaoshudbConfig
    //{
    //    protected BaseDao baseDao = null;
    //    public ziliaoshudbConfig()
    //    {
    //        baseDao = BaseDaoFactory.CreateBaseDao("ziliaoshudbConfig");
    //    }
    //}
}
