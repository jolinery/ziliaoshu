using System;
using System.Collections.Generic;
using System.Data;
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
    public partial class BookDetail
    {
        /// <summary>
        /// 书id
        /// </summary>
        [Column(Name = "BookId"), PK]
        public long BookId { get; set; }
        /// <summary>
        /// 书名
        /// </summary>
        [Column(Name = "BookName")]
        public string BookName { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        [Column(Name = "FileSize")]
        public int FileSize { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Column(Name = "Author")]
        public string Author { get; set; }
        /// <summary>
        /// 副作者
        /// </summary>
        [Column(Name = "SecAuthor")]
        public string SecAuthor { get; set; }
        /// <summary>
        /// 出版社
        /// </summary>
        [Column(Name = "Press")]
        public string Press { get; set; }
        /// <summary>
        /// 书的类型 
        /// </summary>
        [Column(Name = "Type")]
        public byte Type { get; set; }
        /// <summary>
        /// 书的状态
        /// </summary>
        [Column(Name = "Status")]
        public byte Status { get; set; }
        /// <summary>
        /// 是否有效 
        /// </summary>
        [Column(Name = "IsActive")]
        public byte IsActive { get; set; }
        /// <summary>
        /// icon
        /// </summary>
        [Column(Name = "icon")]
        public string icon { get; set; }
        /// <summary>
        /// 本地地址
        /// </summary>
        [Column(Name = "Adress")]
        public string Adress { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        [Column(Name = "Detail")]
        public string Detail { get; set; }
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
