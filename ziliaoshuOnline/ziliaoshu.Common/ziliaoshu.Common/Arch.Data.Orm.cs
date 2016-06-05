using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ziliaoshu.Common
{


    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        // Fields
        private string name;
        private string schema;

        // Methods 

        // Properties
        public string Name { get; set; }
        public string Schema { get; set; }
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public class ColumnAttribute : Attribute
    {
        // 摘要: 
        //     构造
        //public ColumnAttribute();

        // 摘要: 
        //     字段别名
        public string Alias { get; set; }
        //
        // 摘要: 
        //     字段所对应的数据库类型
        public DbType ColumnType { get; set; }
        //
        // 摘要: 
        //     查询ORM时的默认值，不支持NULL作为默认值
        public object DefaultValue { get; set; }
        //
        // 摘要: 
        //     字段的大小
        public int Length { get; set; }
        //
        // 摘要: 
        //     字段名
        public string Name { get; set; }
        public DbType? NullableColumnType { get; set; }
    }
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class PKAttribute : Attribute
    { 
    }
 

}
