using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ziliaoshu.Common;

namespace ZiLiaoShu.Entity
{
    /// <summary>
    /// M_CtripHotel
    /// </summary>
    [Serializable]
    [Table(Name = "BookDetail")]
    public partial class FeedBack
    {
        /// <summary>
        /// PK
        /// </summary>
        [Column(Name = "FeedBackID"), PK]
        public int FeedBackID { get; set; }
        /// <summary>
        /// 用户Id
        /// </summary>
        [Column(Name = "UserId")]
        public long UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Column(Name = "UserName")]
        public string UserName { get; set; }
        /// <summary>
        /// 反馈内容
        /// </summary>
        [Column(Name = "Content")]
        public string Content { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "DataChange_CreateTime")]
        public DateTime DataChange_CreateTime { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [Column(Name = "DataChange_CreateUser")]
        public string DataChange_CreateUser { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [Column(Name = "DataChange_LastTime")]
        public DateTime DataChange_LastTime { get; set; }
        /// <summary>
        /// 最后一次修改者
        /// </summary>
        [Column(Name = "DataChange_LastUser")]
        public string DataChange_LastUser { get; set; }

    }
}
