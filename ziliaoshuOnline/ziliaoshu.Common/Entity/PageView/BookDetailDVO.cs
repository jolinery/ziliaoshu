using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZiLiaoShu.Entity
{
    public class BookDetailDVO
    {
        /// <summary>
        /// 搜索关键词
        /// </summary>
        public string searchKey { get; set; }

        /// <summary>
        /// 书列表
        /// </summary>
        public List<BookDetail> List { get; set; } 
    }
}
